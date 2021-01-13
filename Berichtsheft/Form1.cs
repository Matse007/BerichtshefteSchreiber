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

namespace Berichtsheft
{
    public partial class Form1 : Form
    {
        /*Inizializing the ressourcewriter and reader and the objects such as the document and the Microsoft App. 
         * Document is given its properties in a later function.
        */
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;


        enum UIState
        {
            Dokumentwahl,
            Dateneingabe,
            Speichern,
            Starten

        }


        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        //    ResourceWriter rw = new ResourceWriter(@".\Resources.resx");
        //Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
        Document doc = null;
        bool documentopen;
        int year;
        string[] labelstrings = {"Bitte das Lesezeichen für die Berichtsheftnummer auswählen.",
            "Bitte das Lesezeichen für den Anfang der Woche auswählen.",
            "Bitte das Lesezeichen für das Ende der Woche auswählen.",
             "Bitte das Lesezeichen für das Ausbildungsjahr auswählen."};

        List<string> bookmarks = new List<string>();
        WordHandler whandler = new WordHandler();
        //Variable for looking at what step we are for the bookmark questioning.
        int askingbm = 0;
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
            alterstate(0);
            documentopen = false;
            listBox1.AllowDrop = true;
            listBox2.AllowDrop = true;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";

        }

        private void alterstate(int state)
        {

            switch (state)
            {
                //starting case, file selection part.
                case 0:
                    dateTimePicker1.Visible = false;
                    dateTimePicker2.Visible = false;
                    listBox1.Visible = false;
                    PnlNav.Height = btnStep1.Height;
                    PnlNav.Top = btnStep1.Top;
                    PnlNav.Left = btnStep1.Left;
                    continueBtn.Visible = false;
                    btnStep1.BackColor = Color.FromArgb(46, 51, 73);
                    btnStep2.BackColor = Color.FromArgb(24, 30, 54);
                    btnStep3.BackColor = Color.FromArgb(24, 30, 54);
                    label1.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                    labelselectionresult.Visible = false;
                    button3.Visible = false;


                    break;
                case 1:

                    whandler.populateBookmarks();
                    dateTimePicker1.Visible = false;
                    dateTimePicker2.Visible = false;
                    listBox1.Visible = true;
                    listBox2.Visible = true;
                    PnlNav.Height = btnStep2.Height;
                    PnlNav.Top = btnStep2.Top;
                    PnlNav.Left = btnStep2.Left;
                    //Changing all button colours
                    btnStep1.BackColor = Color.FromArgb(24, 30, 54);
                    btnStep3.BackColor = Color.FromArgb(24, 30, 54);
                    btnStep2.BackColor = Color.FromArgb(46, 51, 73);
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    label1.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;
                    labelselectionresult.Text = "Ausgewählte Lesezeichen: ";
                    labelselectionresult.Visible = true;
                    label1.Text = labelstrings[0];
                    continueBtn.Visible = true;
                    foreach (String bm in whandler.Bookmarks)
                    {
                        listBox1.Items.Add(bm);
                    }

                    break;
                case 2:
                    dateTimePicker1.Visible = true;
                    dateTimePicker2.Visible = true;
                    listBox1.Visible = false;
                    listBox2.Visible = false;
                    PnlNav.Height = btnStep3.Height;
                    PnlNav.Top = btnStep3.Top;
                    PnlNav.Left = btnStep3.Left;
                    //Changing all button colours
                    btnStep1.BackColor = Color.FromArgb(24, 30, 54);
                    btnStep2.BackColor = Color.FromArgb(24, 30, 54);
                    btnStep3.BackColor = Color.FromArgb(46, 51, 73);
                    label1.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                    labelselectionresult.Visible = false;
                    button1.Enabled = false;
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
            whandler.CloseWord('n');
            OpenFileDialog dia = new OpenFileDialog();

            dia.InitialDirectory = "C:\\Users";
            dia.Filter = "Word Documents (*.doc;*docx)|*.doc; *docx";
            if (dia.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                whandler.Str = dia.FileName;
                whandler.openDocument();
                alterstate(1);
                textBox9.Text = dia.FileName;
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            openwordfile();
            /**Creating a folder select window. I am asking for a folder to be selected where we will save the final "Berichtshefte". 
             * I am using Windows CommonOpenFileDialog to make it look like a File Select window while still being able to uzilize it as a folder picker
             * This is part of the Windows API Code Pack, imported through the NuGet Packet Manager.
             * After successfully selecting a folder, the application continues with the following steps.
             */


            //year = dateTimePicker1.Value.Year;
            //Closing the doc in case it is already opened.
            //str = dia.FileName;
            //doc = app.Documents.Open(str);
            //Changing the bool to let us know we have a document opened.
            //documentopen = true;
            /* foreach (Bookmark bm in doc.Bookmarks)
             {
                 bookmarks.Add(bm.Name);

             }
             //SHIFT FUNCTIONALITY
             int WeeksInTotal = (int)GetWeeks(weekstart, endtime);

             Form2 selectnummer = new Form2(bookmarks, 0);
             selectnummer.Text = "Berichtsheftnummerierung:";
             if (selectnummer.ShowDialog() == DialogResult.OK)
             {
                 bmnummer = selectnummer.bmnummer;
                 Form2 selectweekstart = new Form2(selectnummer.bmlist, 1);
                 selectweekstart.Text = "Wochenstartlesezeichen:";
                 if (selectweekstart.ShowDialog() == DialogResult.OK)
                 {
                     bmwochestart = selectweekstart.bmweekstart;
                     Form2 selectweekend = new Form2(selectweekstart.bmlist, 2);
                     selectweekend.Text = "Wochen:";
                     if (selectweekend.ShowDialog() == DialogResult.OK)

                     {
                         bmwocheende = selectweekend.bmweekend;
                         Form2 selectyear = new Form2(selectweekend.bmlist, 3);
                         selectyear.Text = "Jahrlesezeichen:";

                         if (selectyear.ShowDialog() == DialogResult.OK)
                         {
                             bmausbildungsjahr = selectyear.bmjahr;



                             // System.Console.WriteLine(currentweek);
                             // MessageBox.Show(str);
                             //MessageBox.Show(doc.Bookmarks.ToString());          

                             //Checks how many days are left till monday. Currently ignores the fact if its already monday, need to fix that.
                             //MessageBox.Show(DaysUntilMonday(weekstart).ToString());


                             /*   Add all bookmarks
                              * @TODO: Read in names 
                              *
                             for (int i = BerichtNummer; i <= WeeksInTotal; i++)
                             {
                                 WriteInBookmark(bmnummer, i.ToString());
                                 WriteInBookmark(bmwochestart, date1.ToString("d"));
                                 // TODO: Datum vor der for schleife initializieren.
                                 date1 = date1.AddDays(DaysUntilFriday(date1));
                                 WriteInBookmark(bmwocheende, date1.ToString("d"));
                                 WriteInBookmark(bmausbildungsjahr, AusbildungsJahr(i).ToString());



                                 // StripFilePath(str, filenameonly);
                                 //  MessageBox.Show(SaveFileName(BerichtNummer, "Matthias", "Tobin", currentweek, year.ToString()));
                                 doc.SaveAs2(folderName + "\\" + SaveFileName(i, "Matthias", "Tobin", currentweek, year.ToString(), AusbildungsJahr(i)));
                                 date1 = date1.AddDays(DaysUntilMonday(date1));
                                 currentweek = GetIso8601WeekOfYear(date1);
                                 year = date1.Year;

                             }
                             doc.Close();
                             app.Quit();



                         }
                     }
                 }
             }*/

        }




        //attempt to strip the filename from the path. Not working properly yet


        //Returns the final savename. 
        private string SaveFileName(int iterator, string firstname, string lastname, int kalenderwoche, string year, int ausbildungsjahr)
        {
            string finalsavefilename = iterator + ".Berichtsheft_" + firstname + "_" + lastname + "_" + year + "_KW_" + kalenderwoche + "_00" + ausbildungsjahr + ".docx";

            return finalsavefilename;

        }

        private int DaysUntilMonday(DateTime currentdate)
        {
            if (((((int)DayOfWeek.Monday) - ((int)currentdate.DayOfWeek) + 7) % 7) != 0)
            {
                return (((int)DayOfWeek.Monday) - ((int)currentdate.DayOfWeek) + 7) % 7;
            }
            else
            {
                return 7;
            }

        }

        /*Calculates the days until the next friday.
         */

        private int DaysUntilFriday(DateTime currentdate)
        {
            return (((int)DayOfWeek.Friday) - ((int)currentdate.DayOfWeek) + 7) % 7;

        }



        private void WriteInBookmark(string lesezeichen, string inhalt)
        {
            string bookmark = lesezeichen;
            Bookmark bm = doc.Bookmarks[bookmark];
            Range range = bm.Range;
            range.Text = inhalt;
            doc.Bookmarks.Add(bookmark, range);

        }
        private int AusbildungsJahr(int NachweisNummer)
        {
            if (NachweisNummer < 53)
            {
                return 1;
            }
            else if (NachweisNummer > 52 && NachweisNummer < 105)
            {
                return 2;

            }
            else if (NachweisNummer > 104)
            {
                return 3;
            }
            else
            {
                return 0;
            }


        }

        private void writebmtowhandler(int state)
        {
            switch (state)
            {
                case 0:
                    whandler.Bmnummer = listBox2.Items[0].ToString();
                    listBox2.Items.Clear();
                    label1.Text = labelstrings[1];
                    button3.Visible = true;
                    labelselectionresult.Text = labelselectionresult.Text + "\nBerichtsheftnummer: " + whandler.Bmnummer;
                    break;
                case 1:
                    whandler.Bmwochestart = listBox2.Items[0].ToString();
                    listBox2.Items.Clear();
                    label1.Text = labelstrings[2];
                    labelselectionresult.Text = labelselectionresult.Text + "\nWochenstart: " + whandler.Bmwochestart;
                    break;
                case 2:
                    whandler.Bmwocheende = listBox2.Items[0].ToString();
                    listBox2.Items.Clear();
                    label1.Text = labelstrings[3];
                    labelselectionresult.Text = labelselectionresult.Text + "\nEnde der Woche: " + whandler.Bmwocheende;
                    break;
                case 3:
                    whandler.Bmausbildungsjahr = listBox2.Items[0].ToString();
                    listBox2.Items.Clear();
                    label1.Text = "Alle Lesezeichen ausgewählt";
                    continueBtn.Visible = false;
                    labelselectionresult.Text = labelselectionresult.Text + "\nAusbildungsjahr: " + whandler.Bmwochestart;
                    break;
            }
        }
        private void undowritingbmhandler(int state)
        {
            switch (state)
            {
                case 0:
                    break;
                case 1:
                    if (whandler.Bmnummer != null)
                    {
                        listBox1.Items.Add(whandler.Bmnummer);
                        whandler.Bmnummer = null;
                    }
                    if (listBox2.Items.Count != 0)
                    {
                        listBox1.Items.Add(listBox2.Items[0]);
                    }
                    label1.Text = labelstrings[0];
                    button3.Visible = false;
                    labelselectionresult.Text = labelselectionresult.Text.Substring(0, labelselectionresult.Text.LastIndexOf("\n"));
                    askingbm--;


                    break;
                case 2:
                    if (whandler.Bmwochestart != null)
                    {
                        listBox1.Items.Add(whandler.Bmwochestart);
                        whandler.Bmwochestart = null;
                    }
                    if (listBox2.Items.Count != 0)
                    {
                        listBox1.Items.Add(listBox2.Items[0]);
                    }
                    label1.Text = labelstrings[1];
                    labelselectionresult.Text = labelselectionresult.Text.Substring(0, labelselectionresult.Text.LastIndexOf("\n"));
                    askingbm--;
                    break;
                case 3:
                    if (whandler.Bmwocheende != null)
                    {
                        listBox1.Items.Add(whandler.Bmwocheende);
                        whandler.Bmwocheende = null;
                    }
                    if (listBox2.Items.Count != 0)
                    {
                        listBox1.Items.Add(listBox2.Items[0]);
                    }
                    label1.Text = labelstrings[2];
                    labelselectionresult.Text = labelselectionresult.Text.Substring(0, labelselectionresult.Text.LastIndexOf("\n"));
                    askingbm--;
                    break;
                case 4:
                    if (whandler.Bmausbildungsjahr != null)
                    {
                        listBox1.Items.Add(whandler.Bmausbildungsjahr);
                        whandler.Bmausbildungsjahr = null;
                    }
                    if (listBox2.Items.Count != 0)
                    {
                        listBox1.Items.Add(listBox2.Items[0]);
                    }
                    label1.Text = labelstrings[3];
                    continueBtn.Visible = true;
                    labelselectionresult.Text = labelselectionresult.Text.Substring(0, labelselectionresult.Text.LastIndexOf("\n"));
                    askingbm--;                   
                    break;
            }
        }
        private int AmountOfWeeksInTotal(DateTime start, DateTime ende)
        {
            int weeks = (int)GetWeeks(start, ende);
            return weeks;

        }

        /**Function to get the total amount of weeks. In case it is not a full 
         * 
         */
        private decimal GetWeeks(DateTime start, DateTime end)
        {
            start = GetStartOfWeek(start);
            end = GetStartOfWeek(end).AddDays(6);
            decimal days = (int)(end - start).TotalDays;
            int result = DateTime.Compare(start, end);
            if (result > 0 && days == 0)
            {
                return 1;
            }
            else
            {
                return Math.Ceiling((days / 7));
            }
        }


        private DateTime GetStartOfWeek(DateTime input)
        {
            int dayofWeek = (((int)input.DayOfWeek) + 6) % 7;
            return input.Date.AddDays(-dayofWeek);

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
                whandler.CloseWord('y');
                System.Windows.Forms.Application.Exit();
            }


        }
        private void button2_Click(object sender, EventArgs e)
        {
            closeProgramm();


        }

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            openwordfile();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (listBox2.Items.Count == 0)
            {
                if (labelstrings.Any(x => label1.Text.EndsWith(x)) && label1.Text.StartsWith("Keine Auswahl wurde getroffen!"))
                {
                    //Alles bleibt so wie es ist 

                    label1.Text = label1.Text;

                }
                else
                {
                    label1.Text = "Keine Auswahl wurde getroffen! " + label1.Text;
                }
            }
            else if (listBox2.Items.Count == 1)
            {
                writebmtowhandler(askingbm);
                askingbm++;

            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnStep1_Click(object sender, EventArgs e)
        {

        }

        private void btnStep2_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }


        private void listBox2_DragDrop(object sender, DragEventArgs e)
        {
            if (listBox2.Items.Count == 0)
            {
                listBox2.Items.Add(e.Data.GetData(DataFormats.Text));
                listBox1.Items.Remove(e.Data.GetData(DataFormats.Text));
            }
            else
            {
                listBox1.Items.Add(listBox2.Items[0]);
                listBox2.Items.Remove(listBox2.Items[0]);
                listBox2.Items.Add(e.Data.GetData(DataFormats.Text));
                listBox1.Items.Remove(e.Data.GetData(DataFormats.Text));
            }
        }

        private void listBox_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                listBox2.DoDragDrop(listBox1.SelectedItem.ToString(), DragDropEffects.Copy);
            }
            catch (System.NullReferenceException)
            {

                throw;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            undowritingbmhandler(askingbm);


        }
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
                btnStep3.FlatAppearance.MouseOverBackColor = button3.BackColor;
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
    }


}
