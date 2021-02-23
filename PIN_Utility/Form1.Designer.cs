namespace PIN_Utility
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblOutput = new System.Windows.Forms.Label();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.cbOutput = new System.Windows.Forms.CheckBox();
            this.btnDone = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.progressMain = new System.Windows.Forms.ProgressBar();
            this.tbMainInput = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblOverlay = new System.Windows.Forms.Label();
            this.cbOverlay = new System.Windows.Forms.CheckBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.lblCodeProgress = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbMain
            // 
            this.pbMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbMain.Location = new System.Drawing.Point(19, 20);
            this.pbMain.Margin = new System.Windows.Forms.Padding(2);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(688, 93);
            this.pbMain.TabIndex = 0;
            this.pbMain.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.lblOutput);
            this.pnlMain.Controls.Add(this.tbOutput);
            this.pnlMain.Controls.Add(this.cbOutput);
            this.pnlMain.Controls.Add(this.btnDone);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.tbPath);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(724, 293);
            this.pnlMain.TabIndex = 1;
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(9, 66);
            this.lblOutput.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(227, 13);
            this.lblOutput.TabIndex = 7;
            this.lblOutput.Text = "Please enter the desired path for the output file";
            this.lblOutput.Visible = false;
            // 
            // tbOutput
            // 
            this.tbOutput.Location = new System.Drawing.Point(9, 82);
            this.tbOutput.Margin = new System.Windows.Forms.Padding(2);
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.Size = new System.Drawing.Size(359, 20);
            this.tbOutput.TabIndex = 6;
            this.tbOutput.Visible = false;
            // 
            // cbOutput
            // 
            this.cbOutput.AutoSize = true;
            this.cbOutput.Checked = true;
            this.cbOutput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOutput.Location = new System.Drawing.Point(9, 47);
            this.cbOutput.Margin = new System.Windows.Forms.Padding(2);
            this.cbOutput.Name = "cbOutput";
            this.cbOutput.Size = new System.Drawing.Size(168, 17);
            this.cbOutput.TabIndex = 4;
            this.cbOutput.Text = "Save output file in same folder";
            this.cbOutput.UseVisualStyleBackColor = true;
            this.cbOutput.CheckedChanged += new System.EventHandler(this.CbOutput_CheckedChanged);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(9, 236);
            this.btnDone.Margin = new System.Windows.Forms.Padding(2);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(358, 42);
            this.btnDone.TabIndex = 5;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.BtnDone_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please paste the folder path (please use an absolute path)";
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(9, 24);
            this.tbPath.Margin = new System.Windows.Forms.Padding(2);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(359, 20);
            this.tbPath.TabIndex = 0;
            this.tbPath.Text = "C:\\Users\\marti\\Desktop\\PIN_images";
            // 
            // progressMain
            // 
            this.progressMain.Location = new System.Drawing.Point(16, 192);
            this.progressMain.Margin = new System.Windows.Forms.Padding(2);
            this.progressMain.MarqueeAnimationSpeed = 0;
            this.progressMain.Name = "progressMain";
            this.progressMain.Size = new System.Drawing.Size(690, 22);
            this.progressMain.TabIndex = 2;
            // 
            // tbMainInput
            // 
            this.tbMainInput.AcceptsReturn = true;
            this.tbMainInput.Font = new System.Drawing.Font("OcrB", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMainInput.Location = new System.Drawing.Point(54, 116);
            this.tbMainInput.Margin = new System.Windows.Forms.Padding(2);
            this.tbMainInput.MaxLength = 19;
            this.tbMainInput.Name = "tbMainInput";
            this.tbMainInput.Size = new System.Drawing.Size(633, 71);
            this.tbMainInput.TabIndex = 3;
            this.tbMainInput.TextChanged += new System.EventHandler(this.TbMainInput_TextChanged);
            this.tbMainInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbMainInput_KeyDown);
            // 
            // btnBack
            // 
            this.btnBack.Enabled = false;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(317, 219);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(127, 60);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "<";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // lblOverlay
            // 
            this.lblOverlay.AutoSize = true;
            this.lblOverlay.BackColor = System.Drawing.Color.Transparent;
            this.lblOverlay.Font = new System.Drawing.Font("OcrB", 40.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverlay.ForeColor = System.Drawing.Color.Red;
            this.lblOverlay.Location = new System.Drawing.Point(49, 57);
            this.lblOverlay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOverlay.Name = "lblOverlay";
            this.lblOverlay.Size = new System.Drawing.Size(0, 58);
            this.lblOverlay.TabIndex = 7;
            // 
            // cbOverlay
            // 
            this.cbOverlay.AutoSize = true;
            this.cbOverlay.Checked = true;
            this.cbOverlay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOverlay.Location = new System.Drawing.Point(16, 219);
            this.cbOverlay.Margin = new System.Windows.Forms.Padding(2);
            this.cbOverlay.Name = "cbOverlay";
            this.cbOverlay.Size = new System.Drawing.Size(84, 17);
            this.cbOverlay.TabIndex = 8;
            this.cbOverlay.Text = "Text overlay";
            this.cbOverlay.UseVisualStyleBackColor = true;
            this.cbOverlay.CheckedChanged += new System.EventHandler(this.CbOverlay_CheckedChanged);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(448, 219);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(2);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(127, 60);
            this.btnHelp.TabIndex = 9;
            this.btnHelp.Text = "HELP";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(580, 220);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 59);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDown);
            this.groupBox1.Controls.Add(this.btnUp);
            this.groupBox1.Controls.Add(this.btnRight);
            this.groupBox1.Controls.Add(this.btnLeft);
            this.groupBox1.Location = new System.Drawing.Point(191, 219);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(122, 60);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adjust text overlay";
            // 
            // btnDown
            // 
            this.btnDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDown.Location = new System.Drawing.Point(43, 36);
            this.btnDown.Margin = new System.Windows.Forms.Padding(2);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(37, 20);
            this.btnDown.TabIndex = 3;
            this.btnDown.Text = "\\/";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnUp
            // 
            this.btnUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUp.Location = new System.Drawing.Point(43, 17);
            this.btnUp.Margin = new System.Windows.Forms.Padding(2);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(37, 18);
            this.btnUp.TabIndex = 2;
            this.btnUp.Text = "/\\";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnRight
            // 
            this.btnRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRight.Location = new System.Drawing.Point(81, 17);
            this.btnRight.Margin = new System.Windows.Forms.Padding(2);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(37, 38);
            this.btnRight.TabIndex = 1;
            this.btnRight.Text = ">";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeft.Location = new System.Drawing.Point(4, 17);
            this.btnLeft.Margin = new System.Windows.Forms.Padding(2);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(37, 38);
            this.btnLeft.TabIndex = 0;
            this.btnLeft.Text = "<";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // lblCodeProgress
            // 
            this.lblCodeProgress.AutoSize = true;
            this.lblCodeProgress.Location = new System.Drawing.Point(16, 242);
            this.lblCodeProgress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCodeProgress.Name = "lblCodeProgress";
            this.lblCodeProgress.Size = new System.Drawing.Size(0, 13);
            this.lblCodeProgress.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(724, 293);
            this.Controls.Add(this.lblCodeProgress);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.progressMain);
            this.Controls.Add(this.tbMainInput);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.cbOverlay);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lblOverlay);
            this.Controls.Add(this.pbMain);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(742, 332);
            this.MinimumSize = new System.Drawing.Size(394, 332);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PIN Utility v0.3.4";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMain;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.ProgressBar progressMain;
        private System.Windows.Forms.TextBox tbMainInput;
        private System.Windows.Forms.CheckBox cbOutput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblOverlay;
        private System.Windows.Forms.CheckBox cbOverlay;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Label lblCodeProgress;
    }
}

