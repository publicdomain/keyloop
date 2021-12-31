// <copyright file="MainForm.cs" company="PublicDomain.is">
//     CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication
//     https://creativecommons.org/publicdomain/zero/1.0/legalcode
// </copyright>

namespace KeyLoop
{
    // Directives
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;
    using PInvoke;

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
        /// Initializes a new instance of the <see cref="T:KeyLoop.MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            // The InitializeComponent() call is required for Windows Forms designer support.
            this.InitializeComponent();

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
            // TODO Add code
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
            // TODO Add code
        }

        /// <summary>
        /// Handles the Original Thread @ DonationCoder.com tool strip menu item click event
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOriginalThreadDonationCodercomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Handles the source code githubcom tool strip menu item click event
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSourceCodeGithubcomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Handles the about tool strip menu item click event
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnAboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code	
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
    }
}
