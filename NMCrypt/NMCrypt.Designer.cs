
namespace NMCrypt
{
    partial class formNMCrypt
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formNMCrypt));
            this.lblInupt = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPasswordEncrypt = new System.Windows.Forms.TextBox();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.importprkeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keygenerateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.lblStatus = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressContinuous = new System.Windows.Forms.ProgressBar();
            this.txtInputEncrypt = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabEncrypt = new System.Windows.Forms.TabPage();
            this.btnBrowserfolder = new FontAwesome.Sharp.IconButton();
            this.btnBrowserfileEncrypt = new FontAwesome.Sharp.IconButton();
            this.btnHide = new FontAwesome.Sharp.IconButton();
            this.btnShow = new FontAwesome.Sharp.IconButton();
            this.btnEncrypt = new FontAwesome.Sharp.IconButton();
            this.tabCheck = new System.Windows.Forms.TabPage();
            this.btnImportKey = new FontAwesome.Sharp.IconButton();
            this.btnBrowserfileCheck = new FontAwesome.Sharp.IconButton();
            this.btnCheck = new FontAwesome.Sharp.IconButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInputCheck = new System.Windows.Forms.TextBox();
            this.tabDecrypt = new System.Windows.Forms.TabPage();
            this.btnBrowserfileDecrypt = new FontAwesome.Sharp.IconButton();
            this.btnHideD = new FontAwesome.Sharp.IconButton();
            this.btnShowD = new FontAwesome.Sharp.IconButton();
            this.btnDecrypt = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInputDecrypt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPasswordDecrypt = new System.Windows.Forms.TextBox();
            this.btnReset = new FontAwesome.Sharp.IconButton();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPercentcount = new System.Windows.Forms.Label();
            this.progressBarmarquee = new System.Windows.Forms.ProgressBar();
            this.chbTopmost = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabEncrypt.SuspendLayout();
            this.tabCheck.SuspendLayout();
            this.tabDecrypt.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInupt
            // 
            this.lblInupt.AutoSize = true;
            this.lblInupt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInupt.Location = new System.Drawing.Point(61, 106);
            this.lblInupt.Name = "lblInupt";
            this.lblInupt.Size = new System.Drawing.Size(80, 21);
            this.lblInupt.TabIndex = 4;
            this.lblInupt.Text = "Input Path";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPassword.Location = new System.Drawing.Point(61, 31);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(76, 21);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Password";
            // 
            // txtPasswordEncrypt
            // 
            this.txtPasswordEncrypt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPasswordEncrypt.Location = new System.Drawing.Point(141, 28);
            this.txtPasswordEncrypt.MaxLength = 32;
            this.txtPasswordEncrypt.Name = "txtPasswordEncrypt";
            this.txtPasswordEncrypt.PasswordChar = '●';
            this.txtPasswordEncrypt.Size = new System.Drawing.Size(479, 29);
            this.txtPasswordEncrypt.TabIndex = 6;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.importprkeyToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 25);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(306, 26);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(306, 26);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(303, 6);
            // 
            // importprkeyToolStripMenuItem
            // 
            this.importprkeyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.importprkeyToolStripMenuItem.Name = "importprkeyToolStripMenuItem";
            this.importprkeyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.importprkeyToolStripMenuItem.Size = new System.Drawing.Size(306, 26);
            this.importprkeyToolStripMenuItem.Text = "&Import Private Key (.pem)";
            this.importprkeyToolStripMenuItem.Click += new System.EventHandler(this.importpukeyToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(303, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(306, 26);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator3,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator4,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(48, 25);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(170, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(170, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keygenerateToolStripMenuItem,
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(57, 25);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // keygenerateToolStripMenuItem
            // 
            this.keygenerateToolStripMenuItem.Name = "keygenerateToolStripMenuItem";
            this.keygenerateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.keygenerateToolStripMenuItem.Size = new System.Drawing.Size(310, 26);
            this.keygenerateToolStripMenuItem.Text = "Generate RSA Key (.pem)";
            this.keygenerateToolStripMenuItem.Click += new System.EventHandler(this.keygenerateToolStripMenuItem_Click);
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(310, 26);
            this.customizeToolStripMenuItem.Text = "&Customize";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(310, 26);
            this.optionsToolStripMenuItem.Text = "&Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(54, 25);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(139, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(997, 29);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblStatus.Location = new System.Drawing.Point(176, 333);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(58, 21);
            this.lblStatus.TabIndex = 21;
            this.lblStatus.Text = "Ready!";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressContinuous
            // 
            this.progressContinuous.Location = new System.Drawing.Point(177, 359);
            this.progressContinuous.MarqueeAnimationSpeed = 1;
            this.progressContinuous.Name = "progressContinuous";
            this.progressContinuous.Size = new System.Drawing.Size(634, 33);
            this.progressContinuous.Step = 100;
            this.progressContinuous.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressContinuous.TabIndex = 22;
            // 
            // txtInputEncrypt
            // 
            this.txtInputEncrypt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtInputEncrypt.Location = new System.Drawing.Point(141, 100);
            this.txtInputEncrypt.Name = "txtInputEncrypt";
            this.txtInputEncrypt.Size = new System.Drawing.Size(479, 29);
            this.txtInputEncrypt.TabIndex = 24;
            // 
            // tabControl1
            // 
            this.tabControl1.AllowDrop = true;
            this.tabControl1.Controls.Add(this.tabEncrypt);
            this.tabControl1.Controls.Add(this.tabCheck);
            this.tabControl1.Controls.Add(this.tabDecrypt);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.Location = new System.Drawing.Point(0, 43);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(997, 280);
            this.tabControl1.TabIndex = 26;
            // 
            // tabEncrypt
            // 
            this.tabEncrypt.BackColor = System.Drawing.SystemColors.Control;
            this.tabEncrypt.Controls.Add(this.btnBrowserfolder);
            this.tabEncrypt.Controls.Add(this.btnBrowserfileEncrypt);
            this.tabEncrypt.Controls.Add(this.btnHide);
            this.tabEncrypt.Controls.Add(this.btnShow);
            this.tabEncrypt.Controls.Add(this.btnEncrypt);
            this.tabEncrypt.Controls.Add(this.lblInupt);
            this.tabEncrypt.Controls.Add(this.txtInputEncrypt);
            this.tabEncrypt.Controls.Add(this.lblPassword);
            this.tabEncrypt.Controls.Add(this.txtPasswordEncrypt);
            this.tabEncrypt.Location = new System.Drawing.Point(4, 26);
            this.tabEncrypt.Name = "tabEncrypt";
            this.tabEncrypt.Padding = new System.Windows.Forms.Padding(3);
            this.tabEncrypt.Size = new System.Drawing.Size(989, 250);
            this.tabEncrypt.TabIndex = 0;
            this.tabEncrypt.Text = "Lock file or folder";
            // 
            // btnBrowserfolder
            // 
            this.btnBrowserfolder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBrowserfolder.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            this.btnBrowserfolder.IconColor = System.Drawing.Color.Black;
            this.btnBrowserfolder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBrowserfolder.IconSize = 35;
            this.btnBrowserfolder.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnBrowserfolder.Location = new System.Drawing.Point(781, 94);
            this.btnBrowserfolder.Name = "btnBrowserfolder";
            this.btnBrowserfolder.Size = new System.Drawing.Size(156, 39);
            this.btnBrowserfolder.TabIndex = 36;
            this.btnBrowserfolder.Text = "Browser Folder";
            this.btnBrowserfolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBrowserfolder.UseVisualStyleBackColor = true;
            this.btnBrowserfolder.Click += new System.EventHandler(this.btnBrowserfolder_Click);
            // 
            // btnBrowserfileEncrypt
            // 
            this.btnBrowserfileEncrypt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBrowserfileEncrypt.IconChar = FontAwesome.Sharp.IconChar.File;
            this.btnBrowserfileEncrypt.IconColor = System.Drawing.Color.Black;
            this.btnBrowserfileEncrypt.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBrowserfileEncrypt.IconSize = 35;
            this.btnBrowserfileEncrypt.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnBrowserfileEncrypt.Location = new System.Drawing.Point(640, 94);
            this.btnBrowserfileEncrypt.Name = "btnBrowserfileEncrypt";
            this.btnBrowserfileEncrypt.Size = new System.Drawing.Size(135, 39);
            this.btnBrowserfileEncrypt.TabIndex = 35;
            this.btnBrowserfileEncrypt.Text = "Browser File";
            this.btnBrowserfileEncrypt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBrowserfileEncrypt.UseVisualStyleBackColor = true;
            this.btnBrowserfileEncrypt.Click += new System.EventHandler(this.btnBrowserfile_Click);
            // 
            // btnHide
            // 
            this.btnHide.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnHide.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            this.btnHide.IconColor = System.Drawing.Color.Black;
            this.btnHide.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHide.IconSize = 30;
            this.btnHide.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnHide.Location = new System.Drawing.Point(620, 28);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(77, 29);
            this.btnHide.TabIndex = 27;
            this.btnHide.Text = "Hide";
            this.btnHide.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.chbxDisplaypassword_CheckedChanged);
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnShow.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.btnShow.IconColor = System.Drawing.Color.Black;
            this.btnShow.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnShow.IconSize = 30;
            this.btnShow.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnShow.Location = new System.Drawing.Point(620, 28);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(77, 29);
            this.btnShow.TabIndex = 26;
            this.btnShow.Text = "Show";
            this.btnShow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.chbxDisplaypassword_CheckedChanged);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.AllowDrop = true;
            this.btnEncrypt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEncrypt.IconChar = FontAwesome.Sharp.IconChar.Lock;
            this.btnEncrypt.IconColor = System.Drawing.Color.DarkGreen;
            this.btnEncrypt.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEncrypt.IconSize = 60;
            this.btnEncrypt.Location = new System.Drawing.Point(10, 148);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(971, 90);
            this.btnEncrypt.TabIndex = 25;
            this.btnEncrypt.Text = "Lock";
            this.btnEncrypt.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            this.btnEncrypt.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnEncrypt_DragDrop);
            this.btnEncrypt.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnEncrypt_DragEnter);
            // 
            // tabCheck
            // 
            this.tabCheck.BackColor = System.Drawing.SystemColors.Control;
            this.tabCheck.Controls.Add(this.btnImportKey);
            this.tabCheck.Controls.Add(this.btnBrowserfileCheck);
            this.tabCheck.Controls.Add(this.btnCheck);
            this.tabCheck.Controls.Add(this.label3);
            this.tabCheck.Controls.Add(this.txtInputCheck);
            this.tabCheck.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabCheck.Location = new System.Drawing.Point(4, 26);
            this.tabCheck.Name = "tabCheck";
            this.tabCheck.Padding = new System.Windows.Forms.Padding(3);
            this.tabCheck.Size = new System.Drawing.Size(989, 250);
            this.tabCheck.TabIndex = 1;
            this.tabCheck.Text = "Integrity check";
            // 
            // btnImportKey
            // 
            this.btnImportKey.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnImportKey.IconChar = FontAwesome.Sharp.IconChar.Key;
            this.btnImportKey.IconColor = System.Drawing.Color.Black;
            this.btnImportKey.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImportKey.IconSize = 40;
            this.btnImportKey.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImportKey.Location = new System.Drawing.Point(141, 28);
            this.btnImportKey.Name = "btnImportKey";
            this.btnImportKey.Size = new System.Drawing.Size(479, 57);
            this.btnImportKey.TabIndex = 36;
            this.btnImportKey.Text = "Import Public Key";
            this.btnImportKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImportKey.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportKey.UseVisualStyleBackColor = true;
            this.btnImportKey.Click += new System.EventHandler(this.btnImportKey_Click);
            // 
            // btnBrowserfileCheck
            // 
            this.btnBrowserfileCheck.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBrowserfileCheck.IconChar = FontAwesome.Sharp.IconChar.File;
            this.btnBrowserfileCheck.IconColor = System.Drawing.Color.Black;
            this.btnBrowserfileCheck.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBrowserfileCheck.IconSize = 35;
            this.btnBrowserfileCheck.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnBrowserfileCheck.Location = new System.Drawing.Point(640, 94);
            this.btnBrowserfileCheck.Name = "btnBrowserfileCheck";
            this.btnBrowserfileCheck.Size = new System.Drawing.Size(135, 39);
            this.btnBrowserfileCheck.TabIndex = 35;
            this.btnBrowserfileCheck.Text = "Browser File";
            this.btnBrowserfileCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBrowserfileCheck.UseVisualStyleBackColor = true;
            this.btnBrowserfileCheck.Click += new System.EventHandler(this.btnBrowserfileCheck_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.AllowDrop = true;
            this.btnCheck.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCheck.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnCheck.IconColor = System.Drawing.Color.DarkGreen;
            this.btnCheck.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCheck.IconSize = 60;
            this.btnCheck.Location = new System.Drawing.Point(10, 148);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(971, 90);
            this.btnCheck.TabIndex = 29;
            this.btnCheck.Text = "Check";
            this.btnCheck.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnVerifyfile_Click);
            this.btnCheck.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnEncrypt_DragDrop);
            this.btnCheck.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnEncrypt_DragEnter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(61, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 21);
            this.label3.TabIndex = 26;
            this.label3.Text = "Input Path";
            // 
            // txtInputCheck
            // 
            this.txtInputCheck.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtInputCheck.Location = new System.Drawing.Point(141, 100);
            this.txtInputCheck.Name = "txtInputCheck";
            this.txtInputCheck.Size = new System.Drawing.Size(479, 29);
            this.txtInputCheck.TabIndex = 27;
            // 
            // tabDecrypt
            // 
            this.tabDecrypt.BackColor = System.Drawing.SystemColors.Control;
            this.tabDecrypt.Controls.Add(this.btnBrowserfileDecrypt);
            this.tabDecrypt.Controls.Add(this.btnHideD);
            this.tabDecrypt.Controls.Add(this.btnShowD);
            this.tabDecrypt.Controls.Add(this.btnDecrypt);
            this.tabDecrypt.Controls.Add(this.label1);
            this.tabDecrypt.Controls.Add(this.txtInputDecrypt);
            this.tabDecrypt.Controls.Add(this.label2);
            this.tabDecrypt.Controls.Add(this.txtPasswordDecrypt);
            this.tabDecrypt.Location = new System.Drawing.Point(4, 26);
            this.tabDecrypt.Name = "tabDecrypt";
            this.tabDecrypt.Size = new System.Drawing.Size(989, 250);
            this.tabDecrypt.TabIndex = 2;
            this.tabDecrypt.Text = "Unlock file or folder";
            // 
            // btnBrowserfileDecrypt
            // 
            this.btnBrowserfileDecrypt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBrowserfileDecrypt.IconChar = FontAwesome.Sharp.IconChar.File;
            this.btnBrowserfileDecrypt.IconColor = System.Drawing.Color.Black;
            this.btnBrowserfileDecrypt.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBrowserfileDecrypt.IconSize = 35;
            this.btnBrowserfileDecrypt.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnBrowserfileDecrypt.Location = new System.Drawing.Point(640, 94);
            this.btnBrowserfileDecrypt.Name = "btnBrowserfileDecrypt";
            this.btnBrowserfileDecrypt.Size = new System.Drawing.Size(135, 39);
            this.btnBrowserfileDecrypt.TabIndex = 34;
            this.btnBrowserfileDecrypt.Text = "Browser File";
            this.btnBrowserfileDecrypt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBrowserfileDecrypt.UseVisualStyleBackColor = true;
            this.btnBrowserfileDecrypt.Click += new System.EventHandler(this.btnBrowserfileDecrypt_Click);
            // 
            // btnHideD
            // 
            this.btnHideD.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnHideD.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            this.btnHideD.IconColor = System.Drawing.Color.Black;
            this.btnHideD.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHideD.IconSize = 30;
            this.btnHideD.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnHideD.Location = new System.Drawing.Point(620, 28);
            this.btnHideD.Name = "btnHideD";
            this.btnHideD.Size = new System.Drawing.Size(77, 29);
            this.btnHideD.TabIndex = 33;
            this.btnHideD.Text = "Hide";
            this.btnHideD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHideD.UseVisualStyleBackColor = true;
            this.btnHideD.Visible = false;
            this.btnHideD.Click += new System.EventHandler(this.btnShowD_Click);
            // 
            // btnShowD
            // 
            this.btnShowD.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnShowD.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.btnShowD.IconColor = System.Drawing.Color.Black;
            this.btnShowD.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnShowD.IconSize = 30;
            this.btnShowD.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnShowD.Location = new System.Drawing.Point(620, 28);
            this.btnShowD.Name = "btnShowD";
            this.btnShowD.Size = new System.Drawing.Size(77, 29);
            this.btnShowD.TabIndex = 32;
            this.btnShowD.Text = "Show";
            this.btnShowD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShowD.UseVisualStyleBackColor = true;
            this.btnShowD.Click += new System.EventHandler(this.btnShowD_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.AllowDrop = true;
            this.btnDecrypt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDecrypt.IconChar = FontAwesome.Sharp.IconChar.Unlock;
            this.btnDecrypt.IconColor = System.Drawing.Color.DarkGreen;
            this.btnDecrypt.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDecrypt.IconSize = 60;
            this.btnDecrypt.Location = new System.Drawing.Point(10, 148);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(971, 90);
            this.btnDecrypt.TabIndex = 31;
            this.btnDecrypt.Text = "Unlock";
            this.btnDecrypt.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            this.btnDecrypt.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnEncrypt_DragDrop);
            this.btnDecrypt.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnEncrypt_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(61, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 21);
            this.label1.TabIndex = 26;
            this.label1.Text = "Input Path";
            // 
            // txtInputDecrypt
            // 
            this.txtInputDecrypt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtInputDecrypt.Location = new System.Drawing.Point(141, 100);
            this.txtInputDecrypt.Name = "txtInputDecrypt";
            this.txtInputDecrypt.Size = new System.Drawing.Size(479, 29);
            this.txtInputDecrypt.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(61, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 21);
            this.label2.TabIndex = 27;
            this.label2.Text = "Password";
            // 
            // txtPasswordDecrypt
            // 
            this.txtPasswordDecrypt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPasswordDecrypt.Location = new System.Drawing.Point(141, 28);
            this.txtPasswordDecrypt.MaxLength = 32;
            this.txtPasswordDecrypt.Name = "txtPasswordDecrypt";
            this.txtPasswordDecrypt.PasswordChar = '●';
            this.txtPasswordDecrypt.Size = new System.Drawing.Size(479, 29);
            this.txtPasswordDecrypt.TabIndex = 28;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnReset.IconChar = FontAwesome.Sharp.IconChar.Sync;
            this.btnReset.IconColor = System.Drawing.Color.DarkRed;
            this.btnReset.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReset.Location = new System.Drawing.Point(917, 342);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(68, 68);
            this.btnReset.TabIndex = 37;
            this.btnReset.Text = "RESET";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPassword.Location = new System.Drawing.Point(141, 28);
            this.txtPassword.MaxLength = 32;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(262, 29);
            this.txtPassword.TabIndex = 6;
            // 
            // lblPercentcount
            // 
            this.lblPercentcount.AutoSize = true;
            this.lblPercentcount.BackColor = System.Drawing.SystemColors.Control;
            this.lblPercentcount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPercentcount.Location = new System.Drawing.Point(766, 335);
            this.lblPercentcount.Name = "lblPercentcount";
            this.lblPercentcount.Size = new System.Drawing.Size(0, 21);
            this.lblPercentcount.TabIndex = 27;
            // 
            // progressBarmarquee
            // 
            this.progressBarmarquee.Location = new System.Drawing.Point(177, 359);
            this.progressBarmarquee.Name = "progressBarmarquee";
            this.progressBarmarquee.Size = new System.Drawing.Size(634, 33);
            this.progressBarmarquee.Step = 100;
            this.progressBarmarquee.TabIndex = 28;
            // 
            // chbTopmost
            // 
            this.chbTopmost.AutoSize = true;
            this.chbTopmost.Location = new System.Drawing.Point(922, 32);
            this.chbTopmost.Name = "chbTopmost";
            this.chbTopmost.Size = new System.Drawing.Size(75, 19);
            this.chbTopmost.TabIndex = 38;
            this.chbTopmost.Text = "Top Most";
            this.chbTopmost.UseVisualStyleBackColor = true;
            this.chbTopmost.CheckedChanged += new System.EventHandler(this.chbTopmost_CheckedChanged);
            // 
            // formNMCrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(997, 422);
            this.Controls.Add(this.chbTopmost);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.progressBarmarquee);
            this.Controls.Add(this.lblPercentcount);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.progressContinuous);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "formNMCrypt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NMCrypt";
            this.Load += new System.EventHandler(this.formNMCrypt_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabEncrypt.ResumeLayout(false);
            this.tabEncrypt.PerformLayout();
            this.tabCheck.ResumeLayout(false);
            this.tabCheck.PerformLayout();
            this.tabDecrypt.ResumeLayout(false);
            this.tabDecrypt.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblInupt;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPasswordEncrypt;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keygenerateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label lblStatus;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressContinuous;
        private System.Windows.Forms.TextBox txtInputEncrypt;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabEncrypt;
        private System.Windows.Forms.TabPage tabCheck;
        private System.Windows.Forms.TabPage tabDecrypt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInputDecrypt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPasswordDecrypt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInputCheck;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ToolStripMenuItem importprkeyToolStripMenuItem;
        private FontAwesome.Sharp.IconButton btnEncrypt;
        private FontAwesome.Sharp.IconButton btnCheck;
        private FontAwesome.Sharp.IconButton btnDecrypt;
        private FontAwesome.Sharp.IconButton btnShow;
        private FontAwesome.Sharp.IconButton btnHide;
        private FontAwesome.Sharp.IconButton btnHideD;
        private FontAwesome.Sharp.IconButton btnShowD;
        private FontAwesome.Sharp.IconButton btnBrowserfileDecrypt;
        private FontAwesome.Sharp.IconButton btnBrowserfolder;
        private FontAwesome.Sharp.IconButton btnBrowserfileEncrypt;
        private FontAwesome.Sharp.IconButton btnImportKey;
        private FontAwesome.Sharp.IconButton btnBrowserfileCheck;
        private System.Windows.Forms.Label lblPercentcount;
        private System.Windows.Forms.ProgressBar progressBarmarquee;
        private FontAwesome.Sharp.IconButton btnReset;
        private System.Windows.Forms.CheckBox chbTopmost;
    }
}

