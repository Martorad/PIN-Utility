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
        int[] arrayPIN = new int[3]; //0 is code index. 1 is row index. 2 is page index.
        UInt32 numberOfCodes = 0;
        int completedCodes = 0;
        bool complete = false;

        public Form1()
        {
            InitializeComponent();
            //timer1.Start();
            for (int i = 0; i < 3; i++)
            {
                arrayPIN[i] = 1;
            }
            footprint[3] = "PIN_";
            footprint[2] = "_";
            footprint[1] = "_";
            footprint[0] = ".16.png";
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void BtnDone_Click(object sender, EventArgs e)
        {
            if (tbPath.Text == "")
                MessageBox.Show("Please fill in the path");
            else if (!tbPath.Text.EndsWith(@"\"))
            {
                MessageBox.Show(@"Please make sure the path ends with \");
                return;
            }
            else
                userPath = tbPath.Text;

            if (tbNumberOfCodes.Text == "")
                MessageBox.Show("Please fill in the number of codes");
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

            progressMain.Maximum = (int)numberOfCodes;
            MakePath();
            UpdateImage();
            pnlMain.Visible = false;
            pnlMain.Enabled = false;
        }

        private void TbMainInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Increment();
                MakePath();
                UpdateImage();
                progressMain.Value = completedCodes;
                tbMainInput.Clear();
            }
        }

        private void TbMainInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateImage()
        {

            pbMain.BackgroundImage = Image.FromFile(path);
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

                if (completedCodes < numberOfCodes)
                    completedCodes++;
                else
                {
                    MessageBox.Show("All codes are done!");
                    complete = true;
                }
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
    }
}
