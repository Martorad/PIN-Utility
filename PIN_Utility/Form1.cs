using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PIN_Utility
{
    public partial class Form1 : Form
    {
        string userPath = "";
        string outputPath = "";

        uint numberOfCodes = 0;
        int completedCodes;

        bool complete = false;
        bool userChange = false;
        bool newCode = false;
        bool zenMode = false;
        bool debugMode = false;

        List<string> codes = new List<string>();
        List<string> paths = new List<string>();

        DateTime startingTime = new DateTime();

        public Form1()
        {
            InitializeComponent();

            var pos = this.PointToScreen(lblOverlay.Location);
            pos = pbMain.PointToClient(pos);
            lblOverlay.Parent = pbMain;
            lblOverlay.Location = pos;
            lblOverlay.BackColor = Color.Transparent;
            lblOverlay.Font = new Font(lblOverlay.Font.FontFamily, 40.6f);
            tbMainInput.Font = new Font(tbMainInput.Font.FontFamily, 41.6f);
            SetNewWindowSize(394, 332);

            Point pt = pbMain.PointToClient(lblOverlay.PointToScreen(new Point(0, 0)));
            lblOverlay.Location = pt;

            startingTime = DateTime.Now;
            gbDebug.Visible = false;
            gbTextOverlay.Visible = false;
            gbColor.Visible = false;
            lblOverlay.Left -= 7;
            lblOverlay.Top -= 9;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if ((DateTime.Now.Second - startingTime.Second) % 15 == 0  && newCode)
            {
                SaveToFile(false);
                newCode = false;
            }
        }

        private void BtnDone_Click(object sender, EventArgs e)
        {
            if (tbPath.Text == "")
            {
                MessageBox.Show("Please fill in the path.");
                return;
            }
            else
                userPath = tbPath.Text;

            DirectoryInfo d = new DirectoryInfo(userPath);

            if (d.Exists == false)
            {
                MessageBox.Show("The provided path does not exist.");
                return;
            }

            FileInfo[] Files = d.GetFiles("*.png");

            foreach (FileInfo file in Files)
            {
                paths.Add(file.FullName);
            }

            numberOfCodes = (uint)Directory.GetFiles(userPath).Length;

            if (!cbOutput.Checked)
            {
                if (tbOutput.Text == "")
                {
                    MessageBox.Show("Please fill in the output path");
                    return;
                }
                if (tbOutput.Text.EndsWith(@"\") || tbOutput.Text.EndsWith(@"/"))
                    outputPath = tbOutput.Text + "output.txt";
                else
                    outputPath = tbOutput.Text + "/output.txt";
            }
            else
                outputPath = userPath + "/output.txt";

            try
            {
                using (StreamReader reader = new StreamReader(outputPath))
                {
                    string temp = reader.ReadLine() ?? "";
                    if (temp != "")
                    {
                        temp = temp.TrimStart('#');
                        completedCodes = Convert.ToInt32(temp);
                        for (int i = 0; i < completedCodes; i++)
                        {
                            Increment(false);
                            codes.Add(reader.ReadLine());
                        }
                        numberOfCodes--;
                    }
                }
                progressMain.Maximum--;
            }
            catch (Exception exception)
            {
                if (exception is FileNotFoundException)
                    completedCodes = 0;
                else if (exception is DirectoryNotFoundException)
                {
                    MessageBox.Show("The output path entered is not valid. Please enter a valid output path.");
                    return;
                }
            }
            finally
            {
                if (completedCodes == numberOfCodes)
                {
                    complete = true;
                    MessageBox.Show("This folder is already complete!");
                }
                UpdateImage();
                progressMain.Value = completedCodes;
                CheckBtnBackAvailability();
            }

            progressMain.Maximum = (int)numberOfCodes;
            pnlMain.Visible = false;
            pnlMain.Enabled = false;

            timer1.Start();
            UpdateProgress();
            UpdateDebugValues();
            SetNewWindowSize(742, 354);
        }

        private void TbMainInput_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    userChange = true;
                    break;
                case Keys.Enter:
                    if (tbMainInput.Text.Length == 19)
                    {
                        e.SuppressKeyPress = true;
                        codes.Add(tbMainInput.Text);
                        Increment(true);
                        if (!complete)
                            UpdateImage();
                        progressMain.Value = completedCodes;
                        tbMainInput.Clear();
                        UpdateProgress();
                        if (completedCodes == numberOfCodes)
                        {
                            complete = true;
                            MessageBox.Show("All codes are done!");
                            SaveToFile(false);
                            lbEventLog.Items.Add("Codes completed.");
                        }
                        newCode = true;
                        UpdateDebugValues();
                        CheckBtnBackAvailability();
                    }
                    break;
                case Keys.Back:
                    if (tbMainInput.Text.EndsWith(" "))
                    {
                        string temp = tbMainInput.Text;
                        temp = temp.Substring(0, temp.Length - 2);
                        tbMainInput.Text = temp + " ";
                    }
                    break;
                case Keys.M:
                    if (e.Alt)
                    {
                        e.SuppressKeyPress = true;
                        if (debugMode)
                        {
                            MessageBox.Show("Cannot turn on minimalist mode while debug mode is active.\n" +
                                            "Please disable debug mode first.");
                        }
                        else
                        {
                            zenMode ^= true;
                            UpdateZenMode();
                        }
                    }
                    break;
                case Keys.H:
                    if (e.Alt)
                    {
                        e.SuppressKeyPress = true;
                        CallHelp();
                    }
                    break;
                case Keys.D:
                    if (e.Alt)
                    {
                        e.SuppressKeyPress = true;
                        debugMode ^= true;
                        if (zenMode == true) {
                            zenMode = false;
                            UpdateZenMode();
                        }
                        UpdateDebugMode();
                    }
                    break;
                case Keys.S:
                    if (e.Control)
                    {
                        SaveToFile(true);
                    }
                    break;
            }
        }

        private void TbMainInput_TextChanged(object sender, EventArgs e)
        {
            tbMainInput.Text = CheckText(tbMainInput.Text);
            if (!userChange)
            {
                tbMainInput.Focus();
                tbMainInput.SelectionStart = tbMainInput.Text.Length;
            }
            else
            {
                userChange = false;
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Decrement();
            UpdateImage();
            UpdateProgress();
            if (complete)
                complete = false;
            UpdateDebugValues();
            CheckBtnBackAvailability();
            progressMain.Value = completedCodes;
            tbMainInput.Clear();
            tbMainInput.Text = codes[completedCodes];
            codes.Remove(codes.Last());
            lbEventLog.Items.Add("Went back a code.");
        }

        private void CbOutput_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbOutput.Checked)
            {
                tbOutput.Visible = true;
                lblOutput.Visible = true;
            }
            else
            {
                tbOutput.Visible = false;
                lblOutput.Visible = false;
            }
        }

        private void CbOverlay_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOverlay.Checked)
            {
                lblOverlay.Visible = true;
            }
            else
            {
                lblOverlay.Visible = false;
            }
        }

        private void BtnHelp_Click(object sender, EventArgs e)
        {
            CallHelp();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveToFile(false);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveToFile(true);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            int jump = Control.ModifierKeys == Keys.Shift ? 3 : 1;
            if (sender == btnLeft)
            {
                lblOverlay.Left -= jump;
            }
            else if (sender == btnRight)
            {
                lblOverlay.Left += jump;
            }
            else if (sender == btnUp)
            {
                lblOverlay.Top -= jump;
            }
            else if (sender == btnDown)
            {
                lblOverlay.Top += jump;
            }
        }

        private void radioButtonAll_Click(object sender, EventArgs e)
        {
            if (sender == radioButton1)
            {
                if (radioButton1.Checked)
                {
                    gbTextOverlay.Visible = false;
                    gbColor.Visible = false;
                    lblCodeProgress.Visible = true;
                }
            }
            else if (sender == radioButton2)
            {
                if (radioButton2.Checked)
                {
                    gbTextOverlay.Visible = true;
                    gbColor.Visible = false;
                    lblCodeProgress.Visible = false;
                }
            }
            else if (sender == radioButton3)
            {
                if (radioButton3.Checked)
                {
                    gbTextOverlay.Visible = false;
                    gbColor.Visible = true;
                    lblCodeProgress.Visible = false;
                }
            }
        }

        private void textboxColorAll_TextChanged(object sender, EventArgs e)
        {
            if (sender == tbR)
            {
                if (Convert.ToInt32(tbR.Text) < 0)
                    tbR.Text = "0";
                if (Convert.ToInt32(tbR.Text) > 255)
                    tbR.Text = "255";
            }
            else if (sender == tbG)
            {
                if (Convert.ToInt32(tbG.Text) < 0)
                    tbG.Text = "0";
                if (Convert.ToInt32(tbG.Text) > 255)
                    tbG.Text = "255";
            }
            else if (sender == tbB)
            {
                if (Convert.ToInt32(tbB.Text) < 0)
                    tbB.Text = "0";
                if (Convert.ToInt32(tbB.Text) > 255)
                    tbB.Text = "255";
            }
        }

        private void btnSubmitColor_Click(object sender, EventArgs e)
        {
            try
            {
                Color newColor = new Color();
                newColor = Color.FromArgb(Convert.ToInt32(tbR.Text), Convert.ToInt32(tbG.Text), Convert.ToInt32(tbB.Text));
                lblOverlay.ForeColor = newColor;
                lbEventLog.Items.Add("Updated color of overlay.");
            }
            catch (Exception exception)
            {
                MessageBox.Show("RGB values are not in correct format, please use values between 0 and 255.\n" +
                                exception.Message);
            }
        }

        private void BtnClearEventLog_Click(object sender, EventArgs e)
        {
            lbEventLog.Items.Clear();
        }

        private void UpdateImage()
        {
            if (!(completedCodes < numberOfCodes))
            {
                return;
            }
            try
            {
                pbMain.BackgroundImage = Image.FromFile(paths[completedCodes]);
            }
            catch (Exception e)
            {
                MessageBox.Show("Could not find " + e.Message);
            }
        }

        private void Increment(bool incrementCompletedCodes)
        {
            if (!complete)
            {
                if (incrementCompletedCodes)
                {
                    completedCodes++;
                }
            }
        }

        private void Decrement()
        {
            if (completedCodes > 0)
            {
                completedCodes--;
            }
        }

        private string CheckText(string input)
        {
            char lastChar;
            if (input.Length > 0)
                lastChar = input[input.Length - 1];
            else
                lastChar = '#';

            if (lastChar == ' ' && userChange == true)
            {
                input = input.Remove(input.Length - 1);
                //userChange = false;
            }

            input = input.ToUpper();

            if (input.Contains("O"))
                input = input.Replace("O", "0");

            if (!IsValidCharacter(lastChar) && lastChar != '#')
            {
                input = input.Remove(input.Length - 1);
                return input;
            }

            if (input.Replace(" ", string.Empty).Length % 4 == 0 && 
                input.Replace(" ", string.Empty).Length < 16 &&
                lastChar != '#')
            {
                try
                {
                    if (input[input.Length - 1] != ' ')
                    {
                        input += ' ';
                    }
                }
                catch (IndexOutOfRangeException) {}
            }

            if (input.Length > 19)
            {
                input = input.Remove(input.Length - 1);
            }

            lblOverlay.Text = tbMainInput.Text;

            return input;
        }

        private bool IsValidCharacter(char c)
        {
            return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9') || c == ' ';
        }

        private void SaveToFile(bool manual)
        {
            if (!pnlMain.Visible)
            {
                File.Delete(outputPath);
                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    writer.WriteLine("#" + completedCodes.ToString());
                    foreach (string code in codes)
                    {
                        writer.WriteLine(code);
                    }
                    writer.Close();
                    writer.Dispose();
                }
            }
            if (manual)
            {
                lbEventLog.Items.Add("Manually saved to file at " + DateTime.Now);
            }
            else
            {
                lbEventLog.Items.Add("Automatically saved to file at " + DateTime.Now);
            }
        }

        private void CheckBtnBackAvailability()
        {
            if (completedCodes > 0)
                btnBack.Enabled = true;
            else
                btnBack.Enabled = false;
        }

        private void UpdateProgress()
        {
            lblCodeProgress.Text = $"{completedCodes} / {numberOfCodes}";
        }

        private void UpdateZenMode()
        {
            if (zenMode)
            {
                SetNewWindowSize(742, 231);
                ControlBox = false;
                lbEventLog.Items.Add("Switched minimalist mode ON.");
            }
            else
            {
                SetNewWindowSize(742, 354);
                ControlBox = true;
                lbEventLog.Items.Add("Switched minimalist mode OFF.");
            }
        }

        private void UpdateDebugMode()
        {
            if (debugMode)
            {
                SetNewWindowSize(742, 493);
                lbEventLog.Items.Add("Switched debug mode ON.");
            }
            else
            {
                SetNewWindowSize(742, 354);
                lbEventLog.Items.Add("Switched debug mode OFF.");
            }
            gbDebug.Visible = debugMode;
            lbEventLog.Visible = debugMode;
        }

        private void UpdateDebugValues()
        {
            if (!complete)
                lblFilename.Text = paths[completedCodes];
        }

        private void CallHelp()
        {
            MessageBox.Show("Write codes and click Return when done.\n" +
                            "The app will save everything automatically when closing.\n" +
                            "Alternatively, you can save manually by clicking the SAVE button.\n" +
                            "\nPoweruser keybinds:\n" +
                            "Alt + M  -> Toggle minimalist mode.\n" +
                            "Alt + D  -> Toggle debug mode.\n" +
                            "Alt + H  -> Bring up this window.\n" +
                            "Ctrl + S -> Manually save.");
        }

        private void SetNewWindowSize(int x, int y)
        {
            MinimumSize = new Size(x, y);
            Size = MinimumSize;
        }
    }
}