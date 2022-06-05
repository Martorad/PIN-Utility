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
        //Constants used in app.
        const int autosaveInterval = 15;

        //The path for the PNG files and the output path.
        string userPath = "";
        string outputPath = "";
        string formName = "";    //Stores the default name of the main Form. Used for displaying the number of codes in the header of the app.

        uint numberOfCodes = 0;  //Total number of codes.
        int completedCodes;      //Number of codes that the user has entered.

        bool complete = false;   //Whether the codes are all entered or not.
        bool userChange = false; //Whether the change made to the text in the main textbox is from the user or an automatic correction.
        bool newCode = false;    //Whether there is a new code entered. Used to disable autosave function in case of inactivity to save resources.
        bool zenMode = false;    //Whether minimalist mode is on.
        bool debugMode = false;  //Whether debug mode is on.
        bool bckspcPrs = false;  //Whether backspace was pressed recently. Used to make auto-enter feature work correctly.

        List<string> codes = new List<string>(); //Stores all entered codes. Used to generate the output file.
        List<string> paths = new List<string>(); //Stores all paths of the PNG code images.

        DateTime startingTime = new DateTime();  //Used to check the starting time of the app to enable autosave.

        /// <summary>
        /// Initialize all needed resources for the app.
        /// </summary>
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

            formName = Text;
        }

        /// <summary>
        /// Timer used for autosaving every N seconds.
        /// </summary>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if ((DateTime.Now.Second - startingTime.Second) % autosaveInterval == 0 && newCode)
            {
                SaveToFile(false);
                newCode = false;
            }
        }

        /// <summary>
        /// The checkbox for the output path.
        /// </summary>
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

        /// <summary>
        /// Whenever the Done button is clicked, accept both input and output paths if valid, check output file existence and update accordingly.
        /// </summary>
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
            progressMain.Maximum = (int)numberOfCodes;

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

            try //Try to open the output file.
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
            catch (Exception exception) //If the file doesn't exist.
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

        /// <summary>
        /// What happens when a certain key is pressed while the main textbox is highlighted. Used for poweruser keybinds, as well as string formatting.
        /// </summary>
        /// <param name="e">The key which the user pressed.</param>
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
                        UpdateZenMode(false);
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
                    else if (e.Control)
                    {
                        e.SuppressKeyPress = true;
                        Back();
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
                            UpdateZenMode(true);
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
                            UpdateZenMode(true);
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
            bckspcPrs = false;
        }

        /// <summary>
        /// Triggers every time the text in the main textbox is changed. Calls CheckText() to format the user input in realtime.
        /// </summary>
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

            if (cbFastMode.Checked && tbMainInput.Text.Length == 19 && !bckspcPrs)
            {
                object temp = new object();
                KeyEventArgs Enter = new KeyEventArgs(Keys.Enter);
                TbMainInput_KeyDown(temp, Enter);
            }
        }

        /// <summary>
        /// The "<" button.
        /// </summary>
        private void BtnBack_Click(object sender, EventArgs e)
        {
            Back();
        }

        /// <summary>
        /// The checkbox to show the overlay.
        /// </summary>
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

        /// <summary>
        /// The Help button.
        /// </summary>
        private void BtnHelp_Click(object sender, EventArgs e)
        {
            CallHelp();
        }

        /// <summary>
        /// Calls to save to file whenever the form is closed by the user, or otherwise closed by the system.
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveToFile(false);
        }

        /// <summary>
        /// The Save button.
        /// </summary>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveToFile(true);
        }

        /// <summary>
        /// Adjusts the position of the overlay with X and Y coordinates.
        /// </summary>
        /// <param name="sender">Which button called this method.</param>
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

        /// <summary>
        /// Switches between the three panels shown in the main view of the app.
        /// </summary>
        /// <param name="sender">Which radio button called this method.</param>
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

        /// <summary>
        /// String formatting for the three textboxes of the RGB values of the overlay. Limits input values between 0 and 255.
        /// </summary>
        /// <param name="sender">Which textbox called this method.</param>
        private void textboxColorAll_TextChanged(object sender, EventArgs e)
        {
            if (sender == tbR && tbR.Text.Length != 0)
            {
                try
                {
                    if (Convert.ToInt32(tbR.Text) < 0)
                        tbR.Text = "0";
                    if (Convert.ToInt32(tbR.Text) > 255)
                        tbR.Text = "255";
                }
                catch (FormatException)
                {
                    tbR.Text = "";
                }
            }
            else if (sender == tbG && tbG.Text.Length != 0)
            {
                try
                {
                    if (Convert.ToInt32(tbG.Text) < 0)
                    tbG.Text = "0";
                    if (Convert.ToInt32(tbG.Text) > 255)
                        tbG.Text = "255";
                }
                catch (FormatException)
                {
                    tbG.Text = "";
                }
            }
            else if (sender == tbB && tbB.Text.Length != 0)
            {
                try
                {
                    if (Convert.ToInt32(tbB.Text) < 0)
                        tbB.Text = "0";
                    if (Convert.ToInt32(tbB.Text) > 255)
                        tbB.Text = "255";
                }
                catch (FormatException)
                {
                    tbB.Text = "";
                }
            }
        }

        /// <summary>
        /// The Submit button. Located in the Overlay color panel.
        /// </summary>
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

        /// <summary>
        /// The Clear event log button. Located in the debug menu.
        /// </summary>
        private void BtnClearEventLog_Click(object sender, EventArgs e)
        {
            lbEventLog.Items.Clear();
        }

        /// <summary>
        /// Updates the image according to completedCodes. Gets filepath from the paths list.
        /// </summary>
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
        
        /// <summary>
        /// Increments completed codes.
        /// </summary>
        /// <param name="incrementCompletedCodes">Avoids exception when called from automatic output file recognition.</param>
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

        /// <summary>
        /// Decrements completed codes.
        /// </summary>
        private void Decrement()
        {
            if (completedCodes > 0)
            {
                completedCodes--;
            }
        }

        /// <summary>
        /// String formatting of user input.
        /// </summary>
        /// <param name="input">The user input, taken from the main textbox.</param>
        /// <returns>Corrected input. Includes automatic capitalization, character filtering, spacing and character replacement.</returns>
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

        /// <summary>
        /// Sub-method to CheckText(). Used to avoid Cyrillic characters.
        /// </summary>
        /// <param name="c">The character to check.</param>
        /// <returns>A valid character.</returns>
        private bool IsValidCharacter(char c)
        {
            return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9') || c == ' ';
        }

        /// <summary>
        /// Saves to the output file.
        /// </summary>
        /// <param name="manual">Whether the save was manual or automatic. Makes different messages in the debug listbox.</param>
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

        /// <summary>
        /// The method for the Back button. Can also be called from a keybind.
        /// </summary>
        private void Back()
        {
            bckspcPrs = true;
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

        /// <summary>
        /// Checks if the Back button should be enabled or not. Depends on completedCodes.
        /// </summary>
        private void CheckBtnBackAvailability()
        {
            if (completedCodes > 0)
                btnBack.Enabled = true;
            else
                btnBack.Enabled = false;
        }

        /// <summary>
        /// Updates the progress label.
        /// </summary>
        private void UpdateProgress()
        {
            lblCodeProgress.Text = $"{completedCodes} / {numberOfCodes}";
        }

        /// <summary>
        /// Switches between regular and minimalist modes.
        /// </summary>
        /// <param name="updateAll">Whether to update all parameters, or just the main form text.</param>
        private void UpdateZenMode(bool updateAll)
        {
            if (zenMode)
            {
                if (updateAll)
                {
                    SetNewWindowSize(742, 231);
                    ControlBox = false;
                    lbEventLog.Items.Add("Switched minimalist mode ON.");
                }
                Text = $"{completedCodes} / {numberOfCodes}";
            }
            else
            {
                if (updateAll)
                {
                    SetNewWindowSize(742, 354);
                    ControlBox = true;
                    lbEventLog.Items.Add("Switched minimalist mode OFF.");
                }
                Text = formName;
            }
        }

        /// <summary>
        /// Switches between regular and debug modes.
        /// </summary>
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

        /// <summary>
        /// Updates values of labels in the debug menu.
        /// </summary>
        private void UpdateDebugValues()
        {
            if (!complete)
                lblFilename.Text = paths[completedCodes];
        }

        /// <summary>
        /// The method for the Help button. Can also be called from a keybind.
        /// </summary>
        private void CallHelp()
        {
            MessageBox.Show("Write codes and click Return when done.\n" +
                            "The app will save everything automatically when closing.\n" +
                            "Alternatively, you can save manually by clicking the SAVE button.\n" +
                            "\nPoweruser keybinds:\n" +
                            "Alt + M ----------> Toggle minimalist mode.\n" +
                            "Alt + D ----------> Toggle debug mode.\n" +
                            "Alt + H ----------> Bring up this window.\n" +
                            "Ctrl + S ---------> Manually save.\n" +
                            "Ctrl + Backspace -> Go back a code.");
        }

        /// <summary>
        /// Sets the minimum size of the main window and then sets the current size to the new minimum size.
        /// </summary>
        /// <param name="x">The X size of the window.</param>
        /// <param name="y">The Y size of the window.</param>
        private void SetNewWindowSize(int x, int y)
        {
            MinimumSize = new Size(x, y);
            Size = MinimumSize;
        }

        private void cbFastMode_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}