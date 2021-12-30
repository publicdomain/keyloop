
namespace KeyLoop
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
			this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.alwaysOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.minimizeOnLoopStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rememberSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.freeReleasesPublicDomainWeeklycomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.originalThreadDonationCodercomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sourceCodeGithubcomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
			this.cyclesToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.cyclerCountToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.startButton = new System.Windows.Forms.Button();
			this.keyLabel = new System.Windows.Forms.Label();
			this.pressesLabel = new System.Windows.Forms.Label();
			this.delayLabel = new System.Windows.Forms.Label();
			this.keyComboBox = new System.Windows.Forms.ComboBox();
			this.delayComboBox = new System.Windows.Forms.ComboBox();
			this.pressesNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.refreshButton = new System.Windows.Forms.Button();
			this.targetLabel = new System.Windows.Forms.Label();
			this.targetListView = new System.Windows.Forms.ListView();
			this.windowColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.mainMenuStrip.SuspendLayout();
			this.mainStatusStrip.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pressesNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// mainMenuStrip
			// 
			this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.minimizeToolStripMenuItem,
									this.fileToolStripMenuItem,
									this.optionsToolStripMenuItem,
									this.helpToolStripMenuItem});
			this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.mainMenuStrip.Name = "mainMenuStrip";
			this.mainMenuStrip.Size = new System.Drawing.Size(254, 24);
			this.mainMenuStrip.TabIndex = 43;
			// 
			// minimizeToolStripMenuItem
			// 
			this.minimizeToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
			this.minimizeToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
			this.minimizeToolStripMenuItem.Visible = false;
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.newToolStripMenuItem,
									this.toolStripSeparator,
									this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
			this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.newToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
			this.newToolStripMenuItem.Text = "&New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.OnNewToolStripMenuItemClick);
			// 
			// toolStripSeparator
			// 
			this.toolStripSeparator.Name = "toolStripSeparator";
			this.toolStripSeparator.Size = new System.Drawing.Size(138, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.OnExitToolStripMenuItemClick);
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.alwaysOnTopToolStripMenuItem,
									this.minimizeOnLoopStartToolStripMenuItem,
									this.rememberSettingsToolStripMenuItem});
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.optionsToolStripMenuItem.Text = "&Options";
			this.optionsToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.OnOptionsToolStripMenuItemDropDownItemClicked);
			// 
			// alwaysOnTopToolStripMenuItem
			// 
			this.alwaysOnTopToolStripMenuItem.Name = "alwaysOnTopToolStripMenuItem";
			this.alwaysOnTopToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.alwaysOnTopToolStripMenuItem.Text = "&Always on top";
			// 
			// minimizeOnLoopStartToolStripMenuItem
			// 
			this.minimizeOnLoopStartToolStripMenuItem.Name = "minimizeOnLoopStartToolStripMenuItem";
			this.minimizeOnLoopStartToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.minimizeOnLoopStartToolStripMenuItem.Text = "&Minimize on loop start";
			// 
			// rememberSettingsToolStripMenuItem
			// 
			this.rememberSettingsToolStripMenuItem.Checked = true;
			this.rememberSettingsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.rememberSettingsToolStripMenuItem.Name = "rememberSettingsToolStripMenuItem";
			this.rememberSettingsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.rememberSettingsToolStripMenuItem.Text = "&Remember settings";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.freeReleasesPublicDomainWeeklycomToolStripMenuItem,
									this.originalThreadDonationCodercomToolStripMenuItem,
									this.sourceCodeGithubcomToolStripMenuItem,
									this.toolStripSeparator2,
									this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// freeReleasesPublicDomainWeeklycomToolStripMenuItem
			// 
			this.freeReleasesPublicDomainWeeklycomToolStripMenuItem.Name = "freeReleasesPublicDomainWeeklycomToolStripMenuItem";
			this.freeReleasesPublicDomainWeeklycomToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
			this.freeReleasesPublicDomainWeeklycomToolStripMenuItem.Text = "&Free Releases @ PublicDomain.is";
			this.freeReleasesPublicDomainWeeklycomToolStripMenuItem.Click += new System.EventHandler(this.OnFreeReleasesPublicDomainWeeklycomToolStripMenuItemClick);
			// 
			// originalThreadDonationCodercomToolStripMenuItem
			// 
			this.originalThreadDonationCodercomToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("originalThreadDonationCodercomToolStripMenuItem.Image")));
			this.originalThreadDonationCodercomToolStripMenuItem.Name = "originalThreadDonationCodercomToolStripMenuItem";
			this.originalThreadDonationCodercomToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
			this.originalThreadDonationCodercomToolStripMenuItem.Text = "&Original thread @ DonationCoder.com";
			this.originalThreadDonationCodercomToolStripMenuItem.Click += new System.EventHandler(this.OnOriginalThreadDonationCodercomToolStripMenuItemClick);
			// 
			// sourceCodeGithubcomToolStripMenuItem
			// 
			this.sourceCodeGithubcomToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sourceCodeGithubcomToolStripMenuItem.Image")));
			this.sourceCodeGithubcomToolStripMenuItem.Name = "sourceCodeGithubcomToolStripMenuItem";
			this.sourceCodeGithubcomToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
			this.sourceCodeGithubcomToolStripMenuItem.Text = "&Source code @ Github.com";
			this.sourceCodeGithubcomToolStripMenuItem.Click += new System.EventHandler(this.OnSourceCodeGithubcomToolStripMenuItemClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(275, 6);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
			this.aboutToolStripMenuItem.Text = "&About...";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.OnAboutToolStripMenuItemClick);
			// 
			// mainStatusStrip
			// 
			this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.cyclesToolStripStatusLabel,
									this.cyclerCountToolStripStatusLabel});
			this.mainStatusStrip.Location = new System.Drawing.Point(0, 368);
			this.mainStatusStrip.Name = "mainStatusStrip";
			this.mainStatusStrip.Size = new System.Drawing.Size(254, 22);
			this.mainStatusStrip.SizingGrip = false;
			this.mainStatusStrip.TabIndex = 42;
			// 
			// cyclesToolStripStatusLabel
			// 
			this.cyclesToolStripStatusLabel.Name = "cyclesToolStripStatusLabel";
			this.cyclesToolStripStatusLabel.Size = new System.Drawing.Size(44, 17);
			this.cyclesToolStripStatusLabel.Text = "Cycles:";
			// 
			// cyclerCountToolStripStatusLabel
			// 
			this.cyclerCountToolStripStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.cyclerCountToolStripStatusLabel.Name = "cyclerCountToolStripStatusLabel";
			this.cyclerCountToolStripStatusLabel.Size = new System.Drawing.Size(14, 17);
			this.cyclerCountToolStripStatusLabel.Text = "0";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.startButton, 0, 6);
			this.tableLayoutPanel1.Controls.Add(this.keyLabel, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.pressesLabel, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.delayLabel, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.keyComboBox, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.delayComboBox, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.pressesNumericUpDown, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.refreshButton, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.targetLabel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.targetListView, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 7;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(254, 344);
			this.tableLayoutPanel1.TabIndex = 44;
			// 
			// startButton
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.startButton, 2);
			this.startButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.startButton.Location = new System.Drawing.Point(3, 312);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(248, 29);
			this.startButton.TabIndex = 9;
			this.startButton.Text = "&Start loop";
			this.startButton.UseVisualStyleBackColor = true;
			this.startButton.Click += new System.EventHandler(this.OnStartButtonClick);
			// 
			// keyLabel
			// 
			this.keyLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.keyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.keyLabel.Location = new System.Drawing.Point(3, 204);
			this.keyLabel.Name = "keyLabel";
			this.keyLabel.Size = new System.Drawing.Size(121, 35);
			this.keyLabel.TabIndex = 3;
			this.keyLabel.Text = "&Key:";
			this.keyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// pressesLabel
			// 
			this.pressesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pressesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pressesLabel.Location = new System.Drawing.Point(3, 239);
			this.pressesLabel.Name = "pressesLabel";
			this.pressesLabel.Size = new System.Drawing.Size(121, 35);
			this.pressesLabel.TabIndex = 5;
			this.pressesLabel.Text = "&Presses:";
			this.pressesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// delayLabel
			// 
			this.delayLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.delayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.delayLabel.Location = new System.Drawing.Point(3, 274);
			this.delayLabel.Name = "delayLabel";
			this.delayLabel.Size = new System.Drawing.Size(121, 35);
			this.delayLabel.TabIndex = 7;
			this.delayLabel.Text = "&Delay (ms):";
			this.delayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// keyComboBox
			// 
			this.keyComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.keyComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.keyComboBox.FormattingEnabled = true;
			this.keyComboBox.Location = new System.Drawing.Point(130, 207);
			this.keyComboBox.Name = "keyComboBox";
			this.keyComboBox.Size = new System.Drawing.Size(121, 24);
			this.keyComboBox.TabIndex = 4;
			// 
			// delayComboBox
			// 
			this.delayComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.delayComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.delayComboBox.FormattingEnabled = true;
			this.delayComboBox.Items.AddRange(new object[] {
									"50",
									"100",
									"150",
									"200",
									"250",
									"300",
									"350",
									"400",
									"450",
									"500",
									"600",
									"700",
									"800",
									"900",
									"1000",
									"2000",
									"3000",
									"4000",
									"5000",
									"6000",
									"7000",
									"8000",
									"9000",
									"10000"});
			this.delayComboBox.Location = new System.Drawing.Point(130, 277);
			this.delayComboBox.Name = "delayComboBox";
			this.delayComboBox.Size = new System.Drawing.Size(121, 24);
			this.delayComboBox.TabIndex = 8;
			// 
			// pressesNumericUpDown
			// 
			this.pressesNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pressesNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pressesNumericUpDown.Location = new System.Drawing.Point(130, 242);
			this.pressesNumericUpDown.Maximum = new decimal(new int[] {
									10000,
									0,
									0,
									0});
			this.pressesNumericUpDown.Minimum = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.pressesNumericUpDown.Name = "pressesNumericUpDown";
			this.pressesNumericUpDown.Size = new System.Drawing.Size(121, 22);
			this.pressesNumericUpDown.TabIndex = 6;
			this.pressesNumericUpDown.Value = new decimal(new int[] {
									1,
									0,
									0,
									0});
			// 
			// refreshButton
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.refreshButton, 2);
			this.refreshButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.refreshButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.refreshButton.Location = new System.Drawing.Point(3, 172);
			this.refreshButton.Name = "refreshButton";
			this.refreshButton.Size = new System.Drawing.Size(248, 29);
			this.refreshButton.TabIndex = 2;
			this.refreshButton.Text = "&Refresh";
			this.refreshButton.UseVisualStyleBackColor = true;
			this.refreshButton.Click += new System.EventHandler(this.OnRefreshButtonClick);
			// 
			// targetLabel
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.targetLabel, 2);
			this.targetLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.targetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.targetLabel.Location = new System.Drawing.Point(3, 0);
			this.targetLabel.Name = "targetLabel";
			this.targetLabel.Size = new System.Drawing.Size(248, 35);
			this.targetLabel.TabIndex = 0;
			this.targetLabel.Text = "&Target:";
			this.targetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// targetListView
			// 
			this.targetListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.windowColumnHeader});
			this.tableLayoutPanel1.SetColumnSpan(this.targetListView, 2);
			this.targetListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.targetListView.Location = new System.Drawing.Point(3, 38);
			this.targetListView.MultiSelect = false;
			this.targetListView.Name = "targetListView";
			this.targetListView.Size = new System.Drawing.Size(248, 128);
			this.targetListView.TabIndex = 10;
			this.targetListView.UseCompatibleStateImageBehavior = false;
			this.targetListView.View = System.Windows.Forms.View.Details;
			// 
			// windowColumnHeader
			// 
			this.windowColumnHeader.Text = "Title";
			this.windowColumnHeader.Width = 100;
			// 
			// MainForm
			// 
			this.AcceptButton = this.startButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(254, 390);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.mainMenuStrip);
			this.Controls.Add(this.mainStatusStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "KeyLoop";
			this.mainMenuStrip.ResumeLayout(false);
			this.mainMenuStrip.PerformLayout();
			this.mainStatusStrip.ResumeLayout(false);
			this.mainStatusStrip.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pressesNumericUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ColumnHeader windowColumnHeader;
		private System.Windows.Forms.ListView targetListView;
		private System.Windows.Forms.ToolStripMenuItem rememberSettingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem minimizeOnLoopStartToolStripMenuItem;
		private System.Windows.Forms.Label targetLabel;
		private System.Windows.Forms.Button refreshButton;
		private System.Windows.Forms.NumericUpDown pressesNumericUpDown;
		private System.Windows.Forms.ComboBox delayComboBox;
		private System.Windows.Forms.ComboBox keyComboBox;
		private System.Windows.Forms.Label delayLabel;
		private System.Windows.Forms.Label pressesLabel;
		private System.Windows.Forms.Label keyLabel;
		private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ToolStripStatusLabel cyclerCountToolStripStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel cyclesToolStripStatusLabel;
		private System.Windows.Forms.StatusStrip mainStatusStrip;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem sourceCodeGithubcomToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem originalThreadDonationCodercomToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem freeReleasesPublicDomainWeeklycomToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem alwaysOnTopToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem minimizeToolStripMenuItem;
		private System.Windows.Forms.MenuStrip mainMenuStrip;
	}
}
