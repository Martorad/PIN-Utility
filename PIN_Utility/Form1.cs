using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIN_Utility
{
    public partial class Form1 : Form
    {
        string userPath = "";
        string[] footprint = new string[4];
        string path = "";
        string outputPath = "";

        int[] arrayPIN = new int[3]; //0 is code index. 1 is row index. 2 is page index.
        int[] minutes = new int[2]; //0 is seconds, 1 is minutes.
        uint numberOfCodes = 0;
        int completedCodes;

        bool complete = false;
        bool userChange = false;
        bool newCode = false;
        
        float codesPerMinute;

        List<string> codes = new List<string>();

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 3; i++)
            {
                arrayPIN[i] = 1;
            }
            footprint[3] = "PIN_";
            footprint[2] = "_";
            footprint[1] = "_";
            footprint[0] = ".16.png";
            minutes[1] = 1;

            var pos = this.PointToScreen(lblOverlay.Location);
            pos = pbMain.PointToClient(pos);
            lblOverlay.Parent = pbMain;
            lblOverlay.Location = pos;
            lblOverlay.BackColor = Color.Transparent;
            lblOverlay.Font = new Font(lblOverlay.Font.FontFamily, 40.6f);
            tbMainInput.Font = new Font(tbMainInput.Font.FontFamily, 41.6f);

            Point pt = pbMain.PointToClient(lblOverlay.PointToScreen(new Point(0, 0)));
            lblOverlay.Location = pt;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:MM:ss");
            minutes[0]++;
            if (minutes[0] > 59)
            {
                if (minutes[0] % 15 == 0 && newCode)
                {
                    SaveToFile();
                    newCode = false;
                }
                minutes[0] = 0;
                minutes[1]++;
            }
            codesPerMinute = completedCodes / minutes[1];
            lblCodesPerMinute.Text = $"Codes per minute: {codesPerMinute}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Size = MinimumSize;
        }

        private void BtnDone_Click(object sender, EventArgs e)
        {
            timer1.Start();
            Size = new Size(984, 400);
            if (tbPath.Text == "")
            {
                MessageBox.Show("Please fill in the path");
                return;
            }
            else if (!tbPath.Text.EndsWith(@"\"))
            {
                MessageBox.Show(@"Please make sure the path ends with \");
                return;
            }
            else
                userPath = tbPath.Text;

            try
            {
                numberOfCodes = (uint)Directory.GetFiles(userPath.Remove(userPath.Length - 1)).Length;
            }
            catch (FileNotFoundException fnfe)
            {
                MessageBox.Show("Files could not be loaded. Please restart the app and try again.\n" + fnfe.Message);
            }

            if (!cbOutput.Checked)
            {
                if (tbOutput.Text == "")
                {
                    MessageBox.Show("Please fill in the output path");
                    return;
                }
                else if (!tbOutput.Text.EndsWith(@"\"))
                {
                    MessageBox.Show(@"Please make sure the output path ends with \");
                    return;
                }
                else
                    outputPath = tbOutput.Text + "output.txt";
            }
            else
                outputPath = userPath + "output.txt";

            progressMain.Maximum = (int)numberOfCodes;
            pnlMain.Visible = false;
            pnlMain.Enabled = false;

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
            }
            catch (FileNotFoundException fnfe)
            {
                completedCodes = 0;
            }
            finally
            {
                progressMain.Value = completedCodes;
                MakePath();
                UpdateImage();
            }
        }

        private void TbMainInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                userChange = true;
            }
            else if (e.KeyCode == Keys.Enter && tbMainInput.Text.Length == 19)
            {
                e.SuppressKeyPress = true;
                codes.Add(tbMainInput.Text);
                Increment(true);
                MakePath();
                UpdateImage();
                progressMain.Value = completedCodes;
                tbMainInput.Clear();
                if (completedCodes == numberOfCodes)
                {
                    complete = true;
                    MessageBox.Show("All codes are done!");
                }
                newCode = true;
                if (completedCodes > 0)
                    btnBack.Enabled = true;
                else
                    btnBack.Enabled = false;
            }
            else if (e.KeyCode == Keys.Back && tbMainInput.Text.EndsWith(" "))
            {
                string temp = tbMainInput.Text;
                temp = temp.Substring(0, temp.Length - 2);
                tbMainInput.Text = temp + " ";
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
            MakePath();
            UpdateImage();
            if (completedCodes > 0)
                btnBack.Enabled = true;
            else
                btnBack.Enabled = false;
            progressMain.Value = completedCodes;
            tbMainInput.Clear();
            tbMainInput.Text = codes[completedCodes];
            codes.Remove(codes.Last());
        }

        private void LblTime_Click(object sender, EventArgs e)
        {
            if (lblTime.ForeColor == Color.Black)
                lblTime.ForeColor = Color.Honeydew;
            else
                lblTime.ForeColor = Color.Black;
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
            MessageBox.Show("Write codes and click Return when done.\n" +
                "The app will save everything automatically when closing the file.\n" +
                "Alternatively, you can save manually by clicking the SAVE button.\n" +
                "\nKnown bugs:\n" +
                "Pressing space as the first character will cause an exception.\n" +
                "Opening a saved file to continue working will break the Codes per minute value.");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveToFile();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveToFile();
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

        private void UpdateImage()
        {
            try
            {
                pbMain.BackgroundImage = Image.FromFile(path);
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
                arrayPIN[0]++;
                if (arrayPIN[0] > 7)
                {
                    arrayPIN[0] = 1;
                    arrayPIN[1]++;
                }
                if (arrayPIN[1] > 3)
                {
                    arrayPIN[1] = 1;
                    arrayPIN[2]++;
                }
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
                if (arrayPIN[0] != 0)
                {
                    arrayPIN[0]--;
                }
                else if (arrayPIN[1] != 1)
                {
                    arrayPIN[1]--;
                }
                else
                {
                    arrayPIN[2]--;
                    arrayPIN[1] = 3;
                    arrayPIN[0] = 7;
                }
                completedCodes--;
            }
        }

        private void MakePath()
        {
            switch (arrayPIN[2])
            {
                case int n when (n < 10):
                    path = userPath + footprint[3] + "0000" + arrayPIN[2].ToString() + footprint[2] + arrayPIN[1].ToString() +
                        footprint[1] + arrayPIN[0].ToString() + footprint[0];
                    break;
                case int n when (n < 100):
                    path = userPath + footprint[3] + "000" + arrayPIN[2].ToString() + footprint[2] + arrayPIN[1].ToString() +
                        footprint[1] + arrayPIN[0].ToString() + footprint[0];
                    break;
                case int n when (n < 1000):
                    path = userPath + footprint[3] + "00" + arrayPIN[2].ToString() + footprint[2] + arrayPIN[1].ToString() +
                        footprint[1] + arrayPIN[0].ToString() + footprint[0];
                    break;
                case int n when (n < 10000):
                    path = userPath + footprint[3] + "0" + arrayPIN[2].ToString() + footprint[2] + arrayPIN[1].ToString() +
                        footprint[1] + arrayPIN[0].ToString() + footprint[0];
                    break;
                default:
                    path = userPath + footprint[3] + arrayPIN[2].ToString() + footprint[2] + arrayPIN[1].ToString() +
                        footprint[1] + arrayPIN[0].ToString() + footprint[0];
                    break;
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
                catch (IndexOutOfRangeException ioore)
                {
                    
                }
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

        private void SaveToFile()
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
        }
    }
}