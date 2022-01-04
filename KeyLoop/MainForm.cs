// <copyright file="MainForm.cs" company="PublicDomain.is">
//     CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication
//     https://creativecommons.org/publicdomain/zero/1.0/legalcode
// </copyright>

namespace KeyLoop
{
    // Directives
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Timers;
    using System.Windows.Forms;
    using System.Xml.Serialization;
    using PublicDomain;

    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "GetWindowText", ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpWindowText, int nMaxCount);

        [DllImport("user32.dll", EntryPoint = "EnumDesktopWindows", ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool EnumDesktopWindows(IntPtr hDesktop, EnumDelegate lpEnumCallbackFunction, IntPtr lParam);

        [DllImport("User32.dll")]
        private static extern int SetForegroundWindow(IntPtr point);

        private delegate bool EnumDelegate(IntPtr hWnd, int lParam);

        private const int MOD_CONTROL = 0x0002;

        private const int WM_HOTKEY = 0x0312;

        [DllImport("User32")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("User32")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        /// <summary>
        /// The target window dictionary.
        /// </summary>
        private Dictionary<IntPtr, string> targetWindowDictionary = new Dictionary<IntPtr, string>();

        /// <summary>
        /// Gets or sets the associated icon.
        /// </summary>
        /// <value>The associated icon.</value>
        private Icon associatedIcon = null;

        /// <summary>
        /// The settings data.
        /// </summary>
        private SettingsData settingsData = null;

        /// <summary>
        /// The settings data path.
        /// </summary>
        private string settingsDataPath = $"{Application.ProductName}-SettingsData.txt";

        /// <summary>
        /// The send key timer.
        /// </summary>
        private System.Timers.Timer sendKeyTimer = null;

        /// <summary>
        /// The cycles.
        /// </summary>
        private int cycles = 0;

        /// <summary>
        /// The send key string.
        /// </summary>
        private string sendKeyString;

        /// <summary>
        /// The target handle.
        /// </summary>
        private IntPtr targetHandle = IntPtr.Zero;

        /// <summary>
        /// The send key dictionary.
        /// </summary>
        private Dictionary<string, string> sendKeyDictionary = new Dictionary<string, string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:KeyLoop.MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            // The InitializeComponent() call is required for Windows Forms designer support.
            this.InitializeComponent();

            // Set associated icon from exe file
            this.associatedIcon = Icon.ExtractAssociatedIcon(typeof(MainForm).GetTypeInfo().Assembly.Location);

            // Set public domain weekly tool strip menu item image
            this.freeReleasesPublicDomainisToolStripMenuItem.Image = this.associatedIcon.ToBitmap();

            // Add to keys dictionary
            sendKeyDictionary.Add("BACKSPACE", "{BACKSPACE}");
            sendKeyDictionary.Add("BREAK", "{BREAK}");
            sendKeyDictionary.Add("CAPS LOCK", "{CAPSLOCK}");
            sendKeyDictionary.Add("DELETE", "{DELETE}");
            sendKeyDictionary.Add("DOWN ARROW", "{DOWN}");
            sendKeyDictionary.Add("END", "{END}");
            sendKeyDictionary.Add("ENTER", "{ENTER}");
            sendKeyDictionary.Add("ESC", "{ESC}");
            sendKeyDictionary.Add("HELP", "{HELP}");
            sendKeyDictionary.Add("HOME", "{HOME}");
            sendKeyDictionary.Add("INS or INSERT", "{INSERT}");
            sendKeyDictionary.Add("LEFT ARROW", "{LEFT}");
            sendKeyDictionary.Add("NUM LOCK", "{NUMLOCK}");
            sendKeyDictionary.Add("PAGE DOWN", "{PGDN}");
            sendKeyDictionary.Add("PAGE UP", "{PGUP}");
            sendKeyDictionary.Add("PRINT SCREEN", "{PRTSC}");
            sendKeyDictionary.Add("RIGHT ARROW", "{RIGHT}");
            sendKeyDictionary.Add("SCROLL LOCK", "{SCROLLLOCK}");
            sendKeyDictionary.Add("TAB", "{TAB}");
            sendKeyDictionary.Add("UP ARROW", "{UP}");
            sendKeyDictionary.Add("F1", "{F1}");
            sendKeyDictionary.Add("F2", "{F2}");
            sendKeyDictionary.Add("F3", "{F3}");
            sendKeyDictionary.Add("F4", "{F4}");
            sendKeyDictionary.Add("F5", "{F5}");
            sendKeyDictionary.Add("F6", "{F6}");
            sendKeyDictionary.Add("F7", "{F7}");
            sendKeyDictionary.Add("F8", "{F8}");
            sendKeyDictionary.Add("F9", "{F9}");
            sendKeyDictionary.Add("F10", "{F10}");
            sendKeyDictionary.Add("F11", "{F11}");
            sendKeyDictionary.Add("F12", "{F12}");
            sendKeyDictionary.Add("F13", "{F13}");
            sendKeyDictionary.Add("F14", "{F14}");
            sendKeyDictionary.Add("F15", "{F15}");
            sendKeyDictionary.Add("F16", "{F16}");
            sendKeyDictionary.Add("Keypad add", "{ADD}");
            sendKeyDictionary.Add("Keypad subtract", "{SUBTRACT}");
            sendKeyDictionary.Add("Keypad multiply", "{MULTIPLY}");
            sendKeyDictionary.Add("Keypad divide", "{DIVIDE}");
            sendKeyDictionary.Add("SHIFT", "+");
            sendKeyDictionary.Add("CTRL", "^");
            sendKeyDictionary.Add("ALT", "%");

            // Add all in dictionary
            foreach (var key in this.sendKeyDictionary)
            {
                this.keyComboBox.Items.Add(key.Key);
            }

            // Add printable characters
            foreach (var key in Enumerable.Range(0, 256).Select(i => (char)i).Where(c => !char.IsControl(c)).ToList())
            {
                this.keyComboBox.Items.Add(key.ToString());
            }

            // Populate list
            this.PopulateTargetWindowList();

            /* Settings data */

            // Check for settings file
            if (!File.Exists(this.settingsDataPath))
            {
                // Create new settings file
                this.SaveSettingsFile(this.settingsDataPath, new SettingsData());
            }

            // Load settings from disk
            this.settingsData = this.LoadSettingsFile(this.settingsDataPath);

            // Set GUI
            this.alwaysOnTopToolStripMenuItem.Checked = this.settingsData.AlwaysOnTop;
            this.minimizeOnLoopStartToolStripMenuItem.Checked = this.settingsData.MinimizeOnLoopStart;
            this.keyComboBox.Text = this.settingsData.Key;
            this.pressesNumericUpDown.Value = this.settingsData.Presses;
            this.intervalComboBox.Text = this.settingsData.Interval;

            // Set topmost
            this.TopMost = this.settingsData.AlwaysOnTop;

            // Register hotkey
            RegisterHotKey(this.Handle, 1, MOD_CONTROL, Convert.ToInt16(Keys.K));
        }

        /// <summary>
        /// Handles the start button click event
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnStartButtonClick(object sender, EventArgs e)
        {
            // Start/stop
            if (this.startButton.Text == "&Start loop")
            {
                /* Prechecks */

                // Target
                if (this.targetHandle == IntPtr.Zero)
                {
                    // Inform user
                    MessageBox.Show("Please select target window.", "Missing target", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Halt flow
                    return;
                }

                // Key
                if (this.keyComboBox.SelectedIndex > -1)
                {
                    // Change to SendKeys format
                    if (this.keyComboBox.Text.Length > 1)
                    {
                        this.sendKeyString = this.sendKeyDictionary[this.keyComboBox.Text];
                    }
                    else
                    {
                        this.sendKeyString = this.keyComboBox.Text;
                    }
                }
                else
                {
                    // Inform user
                    MessageBox.Show("Please choose a valid key", "Invalid key", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Halt flow
                    return;
                }

                // Change button text
                this.startButton.Text = "&Stop loop";

                /* SendKey timer */

                this.sendKeyTimer = new System.Timers.Timer();
                this.sendKeyTimer.Elapsed += new ElapsedEventHandler(OnSendKeyTimerElapsed);

                // Set interval to parsed or default to a second
                int parsedInt;

                if (this.intervalComboBox.Text.Length == 0 || !int.TryParse(this.intervalComboBox.Text, out parsedInt))
                {
                    this.intervalComboBox.Text = "1000";
                    this.sendKeyTimer.Interval = 1000;
                }
                else
                {
                    this.sendKeyTimer.Interval = parsedInt;
                }

                // Start
                this.sendKeyTimer.Start();
            }
            else
            {
                // Reset button text
                this.startButton.Text = "&Start loop";

                // Stop
                this.sendKeyTimer.Stop();
                this.sendKeyTimer.Dispose();
                this.sendKeyTimer = null;
            }
        }

        /// <summary>
        /// Handles the target list view selected index changed event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnTargetListViewSelectedIndexChanged(object sender, EventArgs e)
        {
            this.targetHandle = (IntPtr)this.targetListView.SelectedItems[0].Tag;
        }

        /// <summary>
        /// Handles the send key timer elapsed event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSendKeyTimerElapsed(object sender, ElapsedEventArgs e)
        {
            // TODO Make it the active window [Can be done via PostMessage i.e. for inactive windows]
            SetForegroundWindow(this.targetHandle);

            // Send the key x presses
            for (int i = 0; i < this.pressesNumericUpDown.Value; i++)
            {
                SendKeys.SendWait(this.sendKeyString);
            }

            // Raise & set cycle count
            this.cycles++;
            this.cycleCountToolStripStatusLabel.Text = this.cycles.ToString();
        }

        /// <summary>
        /// Populates the target window list.
        /// </summary>
        private void PopulateTargetWindowList()
        {
            // Begin updating
            this.targetListView.BeginUpdate();

            // Reset 
            this.targetWindowDictionary.Clear();
            this.targetListView.Items.Clear();

            // Add windows
            if (EnumDesktopWindows(IntPtr.Zero, EnumDesktopWindowsCallback, IntPtr.Zero))
            {
                foreach (var window in targetWindowDictionary)
                {
                    // Add 
                    var listVIewItem = new ListViewItem()
                    {
                        Text = window.Value,
                        Tag = window.Key
                    };

                    this.targetListView.Items.Add(listVIewItem);
                }
            }

            // Adjust column width 
            this.targetListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            // End updating
            this.targetListView.EndUpdate();
        }

        /// <summary>
        /// Enums the desktop windows callback.
        /// </summary>
        /// <returns><c>true</c>, if desktop windows callback was enumed, <c>false</c> otherwise.</returns>
        /// <param name="hWnd">H window.</param>
        /// <param name="lParam">L parameter.</param>
        private bool EnumDesktopWindowsCallback(IntPtr hWnd, int lParam)
        {
            StringBuilder titleStringBuilder = new StringBuilder(1024);

            GetWindowText(hWnd, titleStringBuilder, titleStringBuilder.Capacity + 1);

            string windowTitle = titleStringBuilder.ToString();

            // TODO Visible, with text and not self [May be good to handle the start and manager additions]
            if (IsWindowVisible(hWnd) && string.IsNullOrEmpty(windowTitle) == false && hWnd != this.Handle)
            {
                targetWindowDictionary.Add(hWnd, windowTitle);
            }

            return true;
        }

        /// <summary>
        /// The Windows proc.
        /// </summary>
        /// <param name="m">Message.</param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY)
            {
                // Press button
                this.startButton.PerformClick();
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        /// <summary>
        /// Handles the options tool strip menu item drop down item clicked event
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOptionsToolStripMenuItemDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Set clicked item
            var clickedItem = (ToolStripMenuItem)e.ClickedItem;

            // Toggle checked
            clickedItem.Checked = !clickedItem.Checked;

            // Set topmost
            this.TopMost = this.alwaysOnTopToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Handles the new tool strip menu item click event
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnNewToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Refresh
            this.refreshButton.PerformClick();

            // Reset
            this.keyComboBox.SelectedIndex = -1;
            this.pressesNumericUpDown.Value = 1;
            this.intervalComboBox.Text = "1000";
            this.cycles = 0;
            this.cycleCountToolStripStatusLabel.Text = "0";
            this.sendKeyString = string.Empty;
            this.targetHandle = IntPtr.Zero;
        }

        /// <summary>
        /// Handles the Free Releases @ PublicDomain.is tool strip menu item click event
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnFreeReleasesPublicDomainisToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open our website
            Process.Start("https://publicdomain.is");
        }

        /// <summary>
        /// Handles the Original Thread @ DonationCoder.com tool strip menu item click event
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOriginalThreadDonationCodercomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open orignal thread
            Process.Start("https://www.donationcoder.com/forum/index.php?topic=51963.0");
        }

        /// <summary>
        /// Handles the source code @ GitHub.com tool strip menu item click event
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSourceCodeGithubcomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open GitHub repository
            Process.Start("https://github.com/publicdomain/keyloop");
        }

        /// <summary>
        /// Handles the about tool strip menu item click event
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnAboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Set license text
            var licenseText = $"CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication{Environment.NewLine}" +
                $"https://creativecommons.org/publicdomain/zero/1.0/legalcode{Environment.NewLine}{Environment.NewLine}" +
                $"Libraries and icons have separate licenses.{Environment.NewLine}{Environment.NewLine}" +
                $"dotnet-pinvoke by .NET Foundation and Contributors - MIT License{Environment.NewLine}" +
                $"https://github.com/dotnet/pinvoke{Environment.NewLine}{Environment.NewLine}" +
                $"Forever-gold icon by OpenClipart-Vectors - Pixabay License{Environment.NewLine}" +
                $"https://pixabay.com/vectors/forever-gold-infinite-infinity-2028508/{Environment.NewLine}{Environment.NewLine}" +
                $"Patreon icon used according to published brand guidelines{Environment.NewLine}" +
                $"https://www.patreon.com/brand{Environment.NewLine}{Environment.NewLine}" +
                $"GitHub mark icon used according to published logos and usage guidelines{Environment.NewLine}" +
                $"https://github.com/logos{Environment.NewLine}{Environment.NewLine}" +
                $"DonationCoder icon used with permission{Environment.NewLine}" +
                $"https://www.donationcoder.com/forum/index.php?topic=48718{Environment.NewLine}{Environment.NewLine}" +
                $"PublicDomain icon is based on the following source images:{Environment.NewLine}{Environment.NewLine}" +
                $"Bitcoin by GDJ - Pixabay License{Environment.NewLine}" +
                $"https://pixabay.com/vectors/bitcoin-digital-currency-4130319/{Environment.NewLine}{Environment.NewLine}" +
                $"Letter P by ArtsyBee - Pixabay License{Environment.NewLine}" +
                $"https://pixabay.com/illustrations/p-glamour-gold-lights-2790632/{Environment.NewLine}{Environment.NewLine}" +
                $"Letter D by ArtsyBee - Pixabay License{Environment.NewLine}" +
                $"https://pixabay.com/illustrations/d-glamour-gold-lights-2790573/{Environment.NewLine}{Environment.NewLine}";

            // Prepend sponsors
            licenseText = $"RELEASE SPONSORS:{Environment.NewLine}{Environment.NewLine}* Jesse Reichler{Environment.NewLine}* Max P.{Environment.NewLine}{Environment.NewLine}=========={Environment.NewLine}{Environment.NewLine}" + licenseText;

            // Set title
            string programTitle = typeof(MainForm).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyTitleAttribute>().Title;

            // Set version for generating semantic version 
            Version version = typeof(MainForm).GetTypeInfo().Assembly.GetName().Version;

            // Set about form
            var aboutForm = new AboutForm(
                $"About {programTitle}",
                $"{programTitle} {version.Major}.{version.Minor}.{version.Build}",
                $"Made for: adamok70{Environment.NewLine}DonationCoder.com{Environment.NewLine}Day #4, Week #01 @ January 04, 2022",
                licenseText,
                this.Icon.ToBitmap())
            {
                // Set about form icon
                Icon = this.associatedIcon,

                // Set always on top
                TopMost = this.TopMost
            };

            // Show about form
            aboutForm.ShowDialog();
        }

        /// <summary>
        /// /*Handles the refresh button click event*/*
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnRefreshButtonClick(object sender, EventArgs e)
        {
            this.PopulateTargetWindowList();
        }

        /// <summary>
        /// Handles the main form load event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnMainFormLoad(object sender, EventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Handles the main form form closing event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnMainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            // Free hotkey
            UnregisterHotKey(this.Handle, 1);

            /* Setiings data */

            // Save options
            this.settingsData.AlwaysOnTop = this.alwaysOnTopToolStripMenuItem.Checked;
            this.settingsData.MinimizeOnLoopStart = this.minimizeOnLoopStartToolStripMenuItem.Checked;
            this.settingsData.Key = this.keyComboBox.Text;
            this.settingsData.Presses = this.pressesNumericUpDown.Value;
            this.settingsData.Interval = this.intervalComboBox.Text;

            // Save settings data to disk
            this.SaveSettingsFile(this.settingsDataPath, this.settingsData);
        }

        /// <summary>
        /// Loads the settings file.
        /// </summary>
        /// <returns>The settings file.</returns>
        /// <param name="settingsFilePath">Settings file path.</param>
        private SettingsData LoadSettingsFile(string settingsFilePath)
        {
            // Use file stream
            using (FileStream fileStream = File.OpenRead(settingsFilePath))
            {
                // Set xml serialzer
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(SettingsData));

                // Return populated settings data
                return xmlSerializer.Deserialize(fileStream) as SettingsData;
            }
        }

        /// <summary>
        /// Saves the settings file.
        /// </summary>
        /// <param name="settingsFilePath">Settings file path.</param>
        /// <param name="settingsDataParam">Settings data parameter.</param>
        private void SaveSettingsFile(string settingsFilePath, SettingsData settingsDataParam)
        {
            try
            {
                // Use stream writer
                using (StreamWriter streamWriter = new StreamWriter(settingsFilePath, false))
                {
                    // Set xml serialzer
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(SettingsData));

                    // Serialize settings data
                    xmlSerializer.Serialize(streamWriter, settingsDataParam);
                }
            }
            catch (Exception exception)
            {
                // Advise user
                MessageBox.Show($"Error saving settings file.{Environment.NewLine}{Environment.NewLine}Message:{Environment.NewLine}{exception.Message}", "File error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the exit tool strip menu item click event
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Close program
            this.Close();
        }
    }
}
