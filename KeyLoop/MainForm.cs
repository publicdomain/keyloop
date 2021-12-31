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
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;
    using PInvoke;
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

        private delegate bool EnumDelegate(IntPtr hWnd, int lParam);

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

            // Populate keys
            foreach (var item in Enum.GetNames(typeof(User32.VirtualKey)))
            {
                this.keyComboBox.Items.Add(item.Substring(3));
            }

            // Populate list
            this.PopulateTargetWindowList();
        }

        /// <summary>
        /// Handles the start button click event
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnStartButtonClick(object sender, EventArgs e)
        {
            // todo add code
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
            // TODO Add code
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
                $"Made for: adamok70{Environment.NewLine}DonationCoder.com{Environment.NewLine}Day #365, Week #52 @ December 31, 2021",
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
        /// Handles the exit tool strip menu item click event
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Close program
            this.Close();
        }
		
		void OnMainFormLoad(object sender, EventArgs e)
		{
			
		}
		
		void OnMainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			
		}
    }
}
