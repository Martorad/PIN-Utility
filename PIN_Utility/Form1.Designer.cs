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
            this.tbPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNumberOfCodes = new System.Windows.Forms.TextBox();
            this.btnDone = new System.Windows.Forms.Button();
            this.progressMain = new System.Windows.Forms.ProgressBar();
            this.tbMainInput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbMain
            // 
            this.pbMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbMain.Location = new System.Drawing.Point(22, 24);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(920, 115);
            this.pbMain.TabIndex = 0;
            this.pbMain.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnDone);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.tbNumberOfCodes);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.tbPath);
            this.pnlMain.Location = new System.Drawing.Point(798, 108);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(169, 136);
            this.pnlMain.TabIndex = 1;
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(12, 29);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(477, 22);
            this.tbPath.TabIndex = 0;
            this.tbPath.Text = "C:\\Users\\marti\\Desktop\\PIN_images\\";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Please enter number of codes";
            // 
            // tbNumberOfCodes
            // 
            this.tbNumberOfCodes.Location = new System.Drawing.Point(12, 78);
            this.tbNumberOfCodes.Name = "tbNumberOfCodes";
            this.tbNumberOfCodes.Size = new System.Drawing.Size(477, 22);
            this.tbNumberOfCodes.TabIndex = 2;
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(12, 116);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(477, 52);
            this.btnDone.TabIndex = 4;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.BtnDone_Click);
            // 
            // progressMain
            // 
            this.progressMain.Location = new System.Drawing.Point(22, 264);
            this.progressMain.Name = "progressMain";
            this.progressMain.Size = new System.Drawing.Size(920, 27);
            this.progressMain.TabIndex = 2;
            // 
            // tbMainInput
            // 
            this.tbMainInput.AcceptsReturn = true;
            this.tbMainInput.Font = new System.Drawing.Font("Lucida Sans Typewriter", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMainInput.Location = new System.Drawing.Point(22, 143);
            this.tbMainInput.Name = "tbMainInput";
            this.tbMainInput.Size = new System.Drawing.Size(920, 78);
            this.tbMainInput.TabIndex = 3;
            this.tbMainInput.TextChanged += new System.EventHandler(this.TbMainInput_TextChanged);
            this.tbMainInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbMainInput_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 353);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.progressMain);
            this.Controls.Add(this.tbMainInput);
            this.Controls.Add(this.pbMain);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PIN Utility v0.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
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
    }
}

