
namespace GPLA_Assessment
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadProgramMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProgramMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userGuidelinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandLineWindow = new System.Windows.Forms.TextBox();
            this.programWindow = new System.Windows.Forms.RichTextBox();
            this.displayCanvas = new System.Windows.Forms.PictureBox();
            this.errorDisplayArea = new System.Windows.Forms.RichTextBox();
            this.checkSyntaxButton = new System.Windows.Forms.Button();
            this.displayCanvasLbl = new System.Windows.Forms.Label();
            this.programWindowLbl = new System.Windows.Forms.Label();
            this.errorWindowLbl = new System.Windows.Forms.Label();
            this.commandWindowLbl = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.displayCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1305, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadProgramMenu,
            this.saveProgramMenu,
            this.exitMenu});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadProgramMenu
            // 
            this.loadProgramMenu.Name = "loadProgramMenu";
            this.loadProgramMenu.Size = new System.Drawing.Size(258, 34);
            this.loadProgramMenu.Text = "Load Program File";
            this.loadProgramMenu.Click += new System.EventHandler(this.loadProgramMenu_Click);
            // 
            // saveProgramMenu
            // 
            this.saveProgramMenu.Name = "saveProgramMenu";
            this.saveProgramMenu.Size = new System.Drawing.Size(258, 34);
            this.saveProgramMenu.Text = "Save Program";
            this.saveProgramMenu.Click += new System.EventHandler(this.saveProgramMenu_Click);
            // 
            // exitMenu
            // 
            this.exitMenu.Name = "exitMenu";
            this.exitMenu.Size = new System.Drawing.Size(258, 34);
            this.exitMenu.Text = "Exit";
            this.exitMenu.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.userGuidelinesToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(235, 34);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // userGuidelinesToolStripMenuItem
            // 
            this.userGuidelinesToolStripMenuItem.Name = "userGuidelinesToolStripMenuItem";
            this.userGuidelinesToolStripMenuItem.Size = new System.Drawing.Size(235, 34);
            this.userGuidelinesToolStripMenuItem.Text = "User Guidelines";
            this.userGuidelinesToolStripMenuItem.Click += new System.EventHandler(this.userGuidelinesToolStripMenuItem_Click);
            // 
            // commandLineWindow
            // 
            this.commandLineWindow.Location = new System.Drawing.Point(768, 419);
            this.commandLineWindow.Name = "commandLineWindow";
            this.commandLineWindow.Size = new System.Drawing.Size(525, 26);
            this.commandLineWindow.TabIndex = 2;
            this.commandLineWindow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.commandLineWindow_KeyDown);
            // 
            // programWindow
            // 
            this.programWindow.Location = new System.Drawing.Point(768, 47);
            this.programWindow.Name = "programWindow";
            this.programWindow.Size = new System.Drawing.Size(525, 347);
            this.programWindow.TabIndex = 3;
            this.programWindow.Text = "";
            // 
            // displayCanvas
            // 
            this.displayCanvas.BackColor = System.Drawing.Color.White;
            this.displayCanvas.Location = new System.Drawing.Point(12, 47);
            this.displayCanvas.Name = "displayCanvas";
            this.displayCanvas.Size = new System.Drawing.Size(750, 620);
            this.displayCanvas.TabIndex = 4;
            this.displayCanvas.TabStop = false;
            this.displayCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.displayCanvas_Paint);
            // 
            // errorDisplayArea
            // 
            this.errorDisplayArea.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.errorDisplayArea.Location = new System.Drawing.Point(768, 467);
            this.errorDisplayArea.Name = "errorDisplayArea";
            this.errorDisplayArea.ReadOnly = true;
            this.errorDisplayArea.Size = new System.Drawing.Size(525, 200);
            this.errorDisplayArea.TabIndex = 5;
            this.errorDisplayArea.Text = "";
            // 
            // checkSyntaxButton
            // 
            this.checkSyntaxButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.checkSyntaxButton.Location = new System.Drawing.Point(1147, 361);
            this.checkSyntaxButton.Name = "checkSyntaxButton";
            this.checkSyntaxButton.Size = new System.Drawing.Size(146, 33);
            this.checkSyntaxButton.TabIndex = 6;
            this.checkSyntaxButton.Text = "Check Syntax";
            this.checkSyntaxButton.UseVisualStyleBackColor = false;
            this.checkSyntaxButton.Click += new System.EventHandler(this.checkSyntaxButton_Click);
            // 
            // displayCanvasLbl
            // 
            this.displayCanvasLbl.AutoSize = true;
            this.displayCanvasLbl.Location = new System.Drawing.Point(334, 33);
            this.displayCanvasLbl.Name = "displayCanvasLbl";
            this.displayCanvasLbl.Size = new System.Drawing.Size(117, 20);
            this.displayCanvasLbl.TabIndex = 7;
            this.displayCanvasLbl.Text = "Display Canvas";
            // 
            // programWindowLbl
            // 
            this.programWindowLbl.AutoSize = true;
            this.programWindowLbl.Location = new System.Drawing.Point(1154, 33);
            this.programWindowLbl.Name = "programWindowLbl";
            this.programWindowLbl.Size = new System.Drawing.Size(129, 20);
            this.programWindowLbl.TabIndex = 8;
            this.programWindowLbl.Text = "Program Window";
            // 
            // errorWindowLbl
            // 
            this.errorWindowLbl.AutoSize = true;
            this.errorWindowLbl.Location = new System.Drawing.Point(1179, 457);
            this.errorWindowLbl.Name = "errorWindowLbl";
            this.errorWindowLbl.Size = new System.Drawing.Size(104, 20);
            this.errorWindowLbl.TabIndex = 9;
            this.errorWindowLbl.Text = "Error Window";
            // 
            // commandWindowLbl
            // 
            this.commandWindowLbl.AutoSize = true;
            this.commandWindowLbl.Location = new System.Drawing.Point(1107, 409);
            this.commandWindowLbl.Name = "commandWindowLbl";
            this.commandWindowLbl.Size = new System.Drawing.Size(176, 20);
            this.commandWindowLbl.TabIndex = 10;
            this.commandWindowLbl.Text = "Command Line Window";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1305, 679);
            this.Controls.Add(this.commandWindowLbl);
            this.Controls.Add(this.errorWindowLbl);
            this.Controls.Add(this.programWindowLbl);
            this.Controls.Add(this.displayCanvasLbl);
            this.Controls.Add(this.checkSyntaxButton);
            this.Controls.Add(this.errorDisplayArea);
            this.Controls.Add(this.displayCanvas);
            this.Controls.Add(this.programWindow);
            this.Controls.Add(this.commandLineWindow);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.displayCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenu;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userGuidelinesToolStripMenuItem;
        private System.Windows.Forms.TextBox commandLineWindow;
        private System.Windows.Forms.RichTextBox programWindow;
        private System.Windows.Forms.PictureBox displayCanvas;
        private System.Windows.Forms.RichTextBox errorDisplayArea;
        private System.Windows.Forms.Button checkSyntaxButton;
        private System.Windows.Forms.Label displayCanvasLbl;
        private System.Windows.Forms.Label programWindowLbl;
        private System.Windows.Forms.Label errorWindowLbl;
        private System.Windows.Forms.Label commandWindowLbl;
        private System.Windows.Forms.ToolStripMenuItem loadProgramMenu;
        private System.Windows.Forms.ToolStripMenuItem saveProgramMenu;
    }
}

