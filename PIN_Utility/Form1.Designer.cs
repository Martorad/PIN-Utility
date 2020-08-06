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
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblOutput = new System.Windows.Forms.Label();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.cbOutput = new System.Windows.Forms.CheckBox();
            this.btnDone = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNumberOfCodes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.progressMain = new System.Windows.Forms.ProgressBar();
            this.tbMainInput = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblCodesPerMinute = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblCopy = new System.Windows.Forms.Label();
            this.cbOverlay = new System.Windows.Forms.CheckBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbMain
            // 
            this.pbMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbMain.Location = new System.Drawing.Point(25, 24);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(917, 115);
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
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.tbNumberOfCodes);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.tbPath);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(966, 353);
            this.pnlMain.TabIndex = 1;
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(12, 140);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(306, 17);
            this.lblOutput.TabIndex = 7;
            this.lblOutput.Text = "Please enter the desired path for the output file";
            this.lblOutput.Visible = false;
            // 
            // tbOutput
            // 
            this.tbOutput.Location = new System.Drawing.Point(12, 160);
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.Size = new System.Drawing.Size(477, 22);
            this.tbOutput.TabIndex = 6;
            this.tbOutput.Visible = false;
            // 
            // cbOutput
            // 
            this.cbOutput.AutoSize = true;
            this.cbOutput.Checked = true;
            this.cbOutput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOutput.Location = new System.Drawing.Point(12, 117);
            this.cbOutput.Name = "cbOutput";
            this.cbOutput.Size = new System.Drawing.Size(228, 21);
            this.cbOutput.TabIndex = 4;
            this.cbOutput.Text = "Save output file in parent folder";
            this.cbOutput.UseVisualStyleBackColor = true;
            this.cbOutput.CheckedChanged += new System.EventHandler(this.CbOutput_CheckedChanged);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(12, 290);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(477, 52);
            this.btnDone.TabIndex = 5;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.BtnDone_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Please enter total number of codes";
            // 
            // tbNumberOfCodes
            // 
            this.tbNumberOfCodes.Location = new System.Drawing.Point(12, 78);
            this.tbNumberOfCodes.Name = "tbNumberOfCodes";
            this.tbNumberOfCodes.Size = new System.Drawing.Size(477, 22);
            this.tbNumberOfCodes.TabIndex = 2;
            this.tbNumberOfCodes.Text = "105";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please paste the folder path (please use an absolute path)";
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(12, 29);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(477, 22);
            this.tbPath.TabIndex = 0;
            this.tbPath.Text = "C:\\Users\\marti\\Desktop\\PIN_images\\";
            // 
            // progressMain
            // 
            this.progressMain.Location = new System.Drawing.Point(22, 236);
            this.progressMain.Name = "progressMain";
            this.progressMain.Size = new System.Drawing.Size(920, 27);
            this.progressMain.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressMain.TabIndex = 2;
            // 
            // tbMainInput
            // 
            this.tbMainInput.AcceptsReturn = true;
            this.tbMainInput.Font = new System.Drawing.Font("Lucida Sans Typewriter", 40.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMainInput.Location = new System.Drawing.Point(70, 143);
            this.tbMainInput.MaxLength = 19;
            this.tbMainInput.Name = "tbMainInput";
            this.tbMainInput.Size = new System.Drawing.Size(845, 87);
            this.tbMainInput.TabIndex = 3;
            this.tbMainInput.TextChanged += new System.EventHandler(this.TbMainInput_TextChanged);
            this.tbMainInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbMainInput_KeyDown);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.ForeColor = System.Drawing.Color.Black;
            this.lblTime.Location = new System.Drawing.Point(889, 327);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 17);
            this.lblTime.TabIndex = 4;
            this.lblTime.Click += new System.EventHandler(this.LblTime_Click);
            // 
            // lblCodesPerMinute
            // 
            this.lblCodesPerMinute.AutoSize = true;
            this.lblCodesPerMinute.Location = new System.Drawing.Point(22, 270);
            this.lblCodesPerMinute.Name = "lblCodesPerMinute";
            this.lblCodesPerMinute.Size = new System.Drawing.Size(123, 17);
            this.lblCodesPerMinute.TabIndex = 5;
            this.lblCodesPerMinute.Text = "Codes per minute:";
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(423, 269);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(169, 47);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "<";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // lblCopy
            // 
            this.lblCopy.AutoSize = true;
            this.lblCopy.BackColor = System.Drawing.Color.Transparent;
            this.lblCopy.Font = new System.Drawing.Font("OcrB", 40.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopy.ForeColor = System.Drawing.Color.Red;
            this.lblCopy.Location = new System.Drawing.Point(65, 70);
            this.lblCopy.Name = "lblCopy";
            this.lblCopy.Size = new System.Drawing.Size(0, 74);
            this.lblCopy.TabIndex = 7;
            // 
            // cbOverlay
            // 
            this.cbOverlay.AutoSize = true;
            this.cbOverlay.Checked = true;
            this.cbOverlay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOverlay.Location = new System.Drawing.Point(22, 292);
            this.cbOverlay.Name = "cbOverlay";
            this.cbOverlay.Size = new System.Drawing.Size(107, 21);
            this.cbOverlay.TabIndex = 8;
            this.cbOverlay.Text = "Text overlay";
            this.cbOverlay.UseVisualStyleBackColor = true;
            this.cbOverlay.CheckedChanged += new System.EventHandler(this.CbOverlay_CheckedChanged);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(598, 269);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(169, 47);
            this.btnHelp.TabIndex = 9;
            this.btnHelp.Text = "HELP";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(773, 270);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(169, 46);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(966, 353);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.progressMain);
            this.Controls.Add(this.tbMainInput);
            this.Controls.Add(this.lblCodesPerMinute);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.cbOverlay);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lblCopy);
            this.Controls.Add(this.pbMain);
            this.Controls.Add(this.btnSave);
            this.MaximumSize = new System.Drawing.Size(984, 400);
            this.MinimumSize = new System.Drawing.Size(520, 400);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PIN Utility v0.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMain;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNumberOfCodes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.ProgressBar progressMain;
        private System.Windows.Forms.TextBox tbMainInput;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblCodesPerMinute;
        private System.Windows.Forms.CheckBox cbOutput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblCopy;
        private System.Windows.Forms.CheckBox cbOverlay;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnSave;
    }
}

