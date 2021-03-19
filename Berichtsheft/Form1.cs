using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Resources;
using Microsoft.WindowsAPICodePack.Dialogs;
using Serilog;

namespace Berichtsheft
{
    public partial class Form1 : Form
    {
        /*Inizializing the ressourcewriter and reader and the objects such as the document and the Microsoft App. 
         * Document is given its properties in a later function.
        */
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        

        List<ComboBox> comboBoxes = new List<ComboBox>();
        List<Control> state1controls = new List<Control>();
        List<Control> state2controls = new List<Control>();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private bool datetimepicker1_changed;
        private bool datetimepicker2_changed;
        private bool datetimepicker3_changed;
        private bool comboBox1set;
        private bool comboBox2set;
        private bool comboBox3set;
        private bool comboBox4set;
        private bool firsttimeallboxesset = true;

        string[] labelstrings = {"Bitte das Lesezeichen für die Berichtsheftnummer auswählen.",
            "Bitte das Lesezeichen für den Anfang der Woche auswählen.",
            "Bitte das Lesezeichen für das Ende der Woche auswählen.",
             "Bitte das Lesezeichen für das Ausbildungsjahr auswählen."};

        

        List<string> bookmarks = new List<string>();
        WordHandler whandler = new WordHandler();
        public static ProgressBar[] prgbar = new ProgressBar[1];
        public static Label[] lbl = new Label[1];
        //Variable for looking at what step we are for the bookmark questioning.
        // This presumes that weeks start with Monday.
        // Week 1 is the 1st week of the year with a Thursday in it.
        public static int GetIso8601WeekOfYear(DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }



        public Form1()
        {

            InitializeComponent();
            new ToolTip().SetToolTip(pictureBox1, "Dieses Feld ist nur verfügbar, wenn die Berichtshefte nicht ab dem 1. generiert werden." +
                "Im Normalfall ist diese Option nicht verfügbar,\njedoch im Falle, dass der Benutzer erst verspätet damit anfängt, seine Berichtshefte" +
                "zu generieren und dadurch nicht mit dem\nBerichtsheft 1 startet, kann der Benutzer so noch die Korrekten Parameter angeben" +
                "die zu der Richtigen Berechnung benötigt werden.");
            new ToolTip().SetToolTip(pictureBox2, "Diesen Wert NUR ändern, wenn neue Berichtshefte ab diesem Ausbildungsjahr generiert werden sollen." +
                "Diese Funktion kommt dann zum\nEinsatz, wenn eispielsweise ein Azubi direkt in das 2. Lehrjahr startet und von dem 2. Lehrjahr aus" +
                "die Hefte Anfangend generiert werden sollen.");
            // Implementing a Logger in this class as well to log all necessary an optional data.
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.File("logs/BerichtshefteSchreiberLog.txt", shared: true, retainedFileCountLimit: 1)
                .CreateLogger();


            comboBoxes.AddRange(this.Controls.OfType<ComboBox>().ToArray());
            state1controls.AddRange(comboBoxes.ToArray());
            foreach (Label l in this.Controls.OfType<Label>().Where(l => l.Name.EndsWith("Combo")))
            {
                state1controls.Add(l);
            }
            state1controls.AddRange(this.Controls.OfType<NumericUpDown>().ToArray());
            state1controls.Add(pictureBox2);
            state2controls.AddRange(new List<Control> { lblAusbildungsstartDate, lblAusbildungsendeDate, lblDokuStartDate , dateTimePicker1,
                dateTimePicker2, dateTimePicker3, lblNameText, lblBerufTextBox, textBox1, textBox2, pictureBox1});
            prgbar[0] = progressBar1;
            lbl[0] = label1;
            alterstate(0);
            Log.Verbose("Finished initializing the UI");
        }
        /// <summary>
        /// Funktion die verschiedene 
        /// </summary>
        /// <param name="state"></param>
        private void alterstate(int state)
        {

            switch (state)
            {
                //starting case, file selection part.
                case 0:
                    dateTimePicker1.Visible = false;
                    dateTimePicker2.Visible = false;
                    dateTimePicker3.Visible = false;
                    PnlNav.Height = btnStep1.Height;
                    PnlNav.Top = btnStep1.Top;
                    PnlNav.Left = btnStep1.Left;

                    btnStep1.BackColor = Color.FromArgb(46, 51, 73);
                    btnStep2.BackColor = Color.FromArgb(24, 30, 54);
                    btnStep3.BackColor = Color.FromArgb(24, 30, 54);

                    label3.Visible = false;
                    foreach (Control c in state1controls)
                    {
                        c.Visible = false;
                        
                    }
                    Log.Verbose("Switched the UI State to 0");
                    break;
                case 1:

                    whandler.populateBookmarks();
                    dateTimePicker1.Visible = false;
                    dateTimePicker2.Visible = false;
                    dateTimePicker3.Visible = false;

                    PnlNav.Height = btnStep2.Height;
                    PnlNav.Top = btnStep2.Top;
                    PnlNav.Left = btnStep2.Left;
                    //Changing all button colours
                    btnStep1.BackColor = Color.FromArgb(24, 30, 54);
                    btnStep3.BackColor = Color.FromArgb(24, 30, 54);
                    btnStep2.BackColor = Color.FromArgb(46, 51, 73);

                    label3.Visible = true;

                    try
                    {
                        foreach (ComboBox c in comboBoxes)
                        {

                            c.Items.Clear();
                            c.Items.Add("");
                            c.Items.AddRange(whandler.Bookmarks.ToArray());


                        }
                        foreach (Control c in state1controls)
                        {
                            c.Visible = true;
                            c.Enabled = true;
                        }
                    }
                    catch (System.NullReferenceException e)
                    {
                        Log.Error(e.ToString());
                        throw;
                    }

                    Log.Verbose("Switched the UI State to 1");
                    break;
                case 2:
                    dateTimePicker1.CustomFormat = " ";
                    dateTimePicker1.Format = DateTimePickerFormat.Custom;
                    dateTimePicker2.CustomFormat = " ";
                    dateTimePicker2.Format = DateTimePickerFormat.Custom;
                    dateTimePicker3.CustomFormat = " ";
                    dateTimePicker3.Format = DateTimePickerFormat.Custom;
                    PnlNav.Height = btnStep3.Height;
                    PnlNav.Top = btnStep3.Top;
                    PnlNav.Left = btnStep3.Left;
                    //Changing all button colours
                    btnStep1.BackColor = Color.FromArgb(24, 30, 54);
                    btnStep2.BackColor = Color.FromArgb(24, 30, 54);
                    btnStep3.BackColor = Color.FromArgb(46, 51, 73);
                    label3.Visible = false;

                    foreach (Control c in state2controls)
                    {

                        c.Visible = true;
                    }
                    Log.Verbose("Switched the UI State to 2");
                    break;
                case 3:
                    PnlNav.Height = btnStep4.Height;
                    PnlNav.Top = btnStep4.Top;
                    PnlNav.Left = btnStep4.Left;
                    btnStep1.BackColor = Color.FromArgb(24, 30, 54);
                    btnStep3.BackColor = Color.FromArgb(24, 30, 54);
                    btnStep2.BackColor = Color.FromArgb(24, 30, 54);
                    btnStep4.BackColor = Color.FromArgb(46, 51, 73);
                    Log.Verbose("Switched the UI State to 3");
                    break;



            }
            buttondesigner();
        }
        private void Form1_Keypress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                closeProgramm();
            }
        }


        /*IMPORTANT FOR LATER
         * 
         * CommonOpenFileDialog folderdialog = new CommonOpenFileDialog();
            folderdialog.Title = "Ordner zum Speichern der Berichtshefte wählen:";
            folderdialog.InitialDirectory = "C:\\Users";
            folderdialog.IsFolderPicker = true;
        */
        private void openwordfile()
        {
            Log.Verbose("Waiting for User to select a Word Document.");
            OpenFileDialog dia = new OpenFileDialog();

            dia.InitialDirectory = "C:\\Users";
            dia.Filter = "Word Documents (*.doc;*docx)|*.doc; *docx";
            if (dia.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                try
                {
                    whandler.CloseWord(WordHandler.ClosingArguments.document);
                    whandler.Str = dia.FileName;

                    whandler.openDocument();
                    alterstate(1);
                    textBox9.Text = dia.FileName;
                }
                catch (DocumentAlreadyOpenException e)
                {
                    Log.Error("openwordfile was unsuccesful. Error that was thrown: " + e);    
                }
            }
            else
            {
                Log.Verbose("The Fileselection was closed without a Word File being attempted to be opened.");
            }


        }
        //Event on when the user clicks the "open word file button".
        private void button1_Click(object sender, EventArgs e)
        {

            openwordfile();
           
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void closeProgramm()
        {
            if
              (

                  MessageBox.Show
                  (
                      "Möchten sie das Programm beenden?",
                      "Achtung!",
                      MessageBoxButtons.YesNo,
                      MessageBoxIcon.Warning,
                      MessageBoxDefaultButton.Button2 // hit Enter == No !
                  )
                  == DialogResult.Yes
              )
            {
                whandler.CloseWord(WordHandler.ClosingArguments.word);
                System.Windows.Forms.Application.Exit();
            }


        }
        private void button2_Click(object sender, EventArgs e)
        {
            closeProgramm();


        }
        //Function to drag the window anywhere you want.
        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        //Function to automatically change the background colour on hovering over those buttons.
        private void buttondesigner()
        {
            btnStep1.FlatAppearance.MouseOverBackColor = btnStep1.BackColor;
            btnStep1.FlatAppearance.MouseDownBackColor = btnStep1.BackColor;
            btnStep1.BackColorChanged += (s, e) =>
            {
                btnStep1.FlatAppearance.MouseOverBackColor = button1.BackColor;
            };
            btnStep2.FlatAppearance.MouseOverBackColor = btnStep2.BackColor;
            btnStep2.FlatAppearance.MouseDownBackColor = btnStep2.BackColor;
            btnStep2.BackColorChanged += (s, e) =>
            {
                btnStep2.FlatAppearance.MouseOverBackColor = button2.BackColor;
            };
            btnStep3.FlatAppearance.MouseOverBackColor = btnStep3.BackColor;
            btnStep3.FlatAppearance.MouseDownBackColor = btnStep3.BackColor;
            btnStep3.BackColorChanged += (s, e) =>
            {
                btnStep3.FlatAppearance.MouseOverBackColor = btnStep3.BackColor;
            };
            btnStep4.FlatAppearance.MouseOverBackColor = btnStep4.BackColor;
            btnStep4.FlatAppearance.MouseDownBackColor = btnStep4.BackColor;
            btnStep4.BackColorChanged += (s, e) =>
            {
                btnStep4.FlatAppearance.MouseOverBackColor = btnStep4.BackColor;
            };
            btnStep5.FlatAppearance.MouseOverBackColor = btnStep5.BackColor;
            btnStep5.FlatAppearance.MouseDownBackColor = btnStep5.BackColor;
            btnStep5.BackColorChanged += (s, e) =>
            {
                btnStep5.FlatAppearance.MouseOverBackColor = btnStep5.BackColor;
            };
        }


        private void comboBox6_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBoxFilled(comboBox6) == false)
            {
                textBox2.Enabled = false;
                textBox2.BackColor = Color.FromArgb(128, 128, 128);
                lblBerufTextBox.ForeColor = Color.FromArgb(128, 128, 128);

            }
            else
            {
                textBox2.Enabled = true;
                textBox2.BackColor = Color.FromArgb(255, 255, 255);
                lblBerufTextBox.ForeColor = Color.FromArgb(255, 255, 255);

            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            datetimepicker2_changed = true;
            datesAndTextSet();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            datetimepicker1_changed = true;
            datesAndTextSet();
            if(dateTimePicker3.Enabled == false)
            {
                dateTimePicker3.CustomFormat = "dd/MM/yyyy";
                dateTimePicker3.Value = dateTimePicker1.Value.Date;
                datetimepicker3_changed = true;
            }
        }
        private void datesAndTextSet()
        {
            if (datetimepicker1_changed && datetimepicker2_changed && datetimepicker3_changed && String.IsNullOrEmpty(textBox1.Text) == false)
            {
                button3.Visible = true;
                button3.Enabled = true;
                alterstate(3);
            }
            else
            {
                button3.Enabled = false;
            }
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBoxFilled(comboBox1))
            {
                comboBox1set = true;
                button3.Enabled = true;

            }
            else
            {
                comboBox1set = false;
                button3.Enabled = false;
            }
            checkComboBoxes();

        }
        private void checkComboBoxes()
        {

            if (comboBox1set && comboBox2set && comboBox3set && comboBox4set && firsttimeallboxesset)
            {
                alterstate(2);
                firsttimeallboxesset = false;
            }
        }

        private void comboBox2_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBoxFilled(comboBox2))
            {
                comboBox2set = true;
                button3.Enabled = true;

            }
            else
            {
                comboBox2set = false;
                button3.Enabled = false;
            }
            checkComboBoxes();
        }

        private void comboBox3_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBoxFilled(comboBox3))
            {
                comboBox3set = true;
                button3.Enabled = true;

            }
            else
            {
                comboBox3set = false;
                button3.Enabled = false;
            }
            checkComboBoxes();
        }

        private void comboBox4_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBoxFilled(comboBox4))
            {
                comboBox4set = true;
                button3.Enabled = true;

            }
            else
            {
                comboBox4set = false;
                button3.Enabled = false;
            }
            checkComboBoxes();

        }
        private bool comboBoxFilled(ComboBox cmbBox)
        {
            try
            {
                if (cmbBox.SelectedIndex < 0)
                {
                    return false;
                }
                else
                {
                    if (String.IsNullOrEmpty(cmbBox.SelectedItem.ToString()))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (System.NullReferenceException error)
            {
                throw new ArgumentOutOfRangeException("oops", "Product Number" + error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            datesAndTextSet();
        }
        public static void setloadingBar(int max)
        {
            prgbar[0].Maximum = max;
        }
        public static void increaseLoadingProgress()
        {

            prgbar[0].Value++;
        }
        public static void changelabel(string text)
        {
            lbl[0].Text = text;
            lbl[0].Refresh();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if(dateTimePicker2.Value.Date < dateTimePicker3.Value.Date && dateTimePicker2.Value.Date < dateTimePicker1.Value.Date)
                {
                Log.Warning("No legal date selection has been made.");
                MessageBox.Show("Datum wurde nicht richtig angegeben.");
                return;
            }
            whandler.Bmnummer = comboBox1.SelectedItem.ToString();
            whandler.Bmwochestart = comboBox2.SelectedItem.ToString();
            whandler.Bmwocheende = comboBox3.SelectedItem.ToString();
            whandler.Bmausbildungsjahr = comboBox4.SelectedItem.ToString();
            if (comboBoxFilled(comboBox5))
            {
                whandler.BmName = comboBox5.SelectedItem.ToString();
            }
            if (comboBoxFilled(comboBox6))
            {
                whandler.BmBerufsbezeichnung = comboBox6.SelectedItem.ToString();
            }

            whandler.UserName = textBox1.Text;
            whandler.Berufsbezeichnung = textBox2.Text;
            whandler.Date1 = dateTimePicker3.Value.Date;
            whandler.Date2 = dateTimePicker2.Value.Date;
            whandler.AusbildungsstartDate = dateTimePicker1.Value.Date;
            whandler.AusbildungsYear = (int)numericUpDown2.Value;
            whandler.Berichtnummer = (int)numericUpDown1.Value;
            /**Creating a folder select window. I am asking for a folder to be selected where we will save the final "Berichtshefte". 
             * I am using Windows CommonOpenFileDialog to make it look like a File Select window while still being able to uzilize it as a folder picker
             * This is part of the Windows API Code Pack, imported through the NuGet Packet Manager.
             * After successfully selecting a folder, the application continues with the following steps.
             * 
             */
            CommonOpenFileDialog folderdialog = new CommonOpenFileDialog();
            folderdialog.Title = "Ordner zum Speichern der Berichtshefte wählen:";
            folderdialog.InitialDirectory = "C:\\Users";
            folderdialog.IsFolderPicker = true;



            if (folderdialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                label1.Visible = true;
                changelabel("Starte...");
                progressBar1.Visible = true;
                whandler.Foldername = folderdialog.FileName;
                whandler.writeDocuments();
                DialogResult result1 = MessageBox.Show("Programm wurde erfolgreich ausgeführt.\nDas Programm wird nun beendet.","Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result1 == DialogResult.OK)
                {
                    whandler.CloseWord(WordHandler.ClosingArguments.word);
                    System.Windows.Forms.Application.Exit();
                }


            }



        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if(numericUpDown1.Value > 1)
            {
                dateTimePicker3.Enabled = true;              
                lblDokuStartDate.ForeColor = Color.FromArgb(255, 255, 255);
            } else
            {
                dateTimePicker3.Enabled = false;
                dateTimePicker3.Value = dateTimePicker1.Value.Date;
                lblDokuStartDate.ForeColor = Color.FromArgb(128, 128, 128);
            }
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker3.CustomFormat = "dd/MM/yyyy";
            datetimepicker3_changed = true;
            datesAndTextSet();
        }
    }


}
