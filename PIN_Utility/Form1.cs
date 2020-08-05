using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        UInt32 numberOfCodes = 0;
        int completedCodes = 0;
        bool complete = false;
        bool userChange = false;
        int[] minutes = new int[2]; //0 is seconds, 1 is minutes.
        float codesPerMinute;

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
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:MM:ss");
            minutes[0]++;
            if (minutes[0] > 60)
            {
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

            if (tbNumberOfCodes.Text == "")
            {
                MessageBox.Show("Please fill in the number of codes");
                return;
            }
            else
            {
                try
                {
                    numberOfCodes = (UInt32)Convert.ToInt32(tbNumberOfCodes.Text);
                }
                catch (FormatException fe)
                {
                    MessageBox.Show("Please make sure the number of codes is in the correct format\n" + fe.Message);
                }
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
                    outputPath = tbOutput.Text;
            }
            else
                outputPath = userPath;

            progressMain.Maximum = (int)numberOfCodes;
            MakePath();
            UpdateImage();
            pnlMain.Visible = false;
            pnlMain.Enabled = false;
        }

        private void TbMainInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && tbMainInput.Text.Length == 19)
            {
                e.SuppressKeyPress = true;
                Increment();
                MakePath();
                UpdateImage();
                progressMain.Value = completedCodes;
                tbMainInput.Clear();
                if (completedCodes == numberOfCodes)
                {
                    complete = true;
                    MessageBox.Show("All codes are done!");
                }
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
            progressMain.Value = completedCodes;
            tbMainInput.Clear();
        }

        private void UpdateImage()
        {
            try
            {
                pbMain.BackgroundImage = Image.FromFile(path);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void Increment()
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
                completedCodes++;
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

            input = input.ToUpper();
            if (input.Contains("O"))
                input = input.Replace("O", "0");

            if (!IsValidCharacter(lastChar) && lastChar != '#')
            {
                input = input.Remove(input.Length - 1);
                return input;
            }

            if (input.Replace(" ", String.Empty).Length % 4 == 0 && 
                input.Replace(" ", String.Empty).Length < 16 &&
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

            return input;
        }

        private bool IsValidCharacter(char c)
        {
            return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9') || c == ' ';
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
    }
}
