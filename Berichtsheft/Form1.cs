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

namespace Berichtsheft
{
    public partial class Form1 : Form
    {
        /*Inizializing the ressourcewriter and reader and the objects such as the document and the Microsoft App. 
         * Document is given its properties in a later function.
        */
        
        ResourceWriter rw = new ResourceWriter(@".\Resources.resx");
        Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
        Document doc = null;
        string filenameonly;
        int year;
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
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog1 = new FolderBrowserDialog();

            // Show the FolderBrowserDialog.
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;
                //Do your work here!


                //Getting the date that was selected by the guy running the Programm
                var weekstart = dateTimePicker1.Value.Date;
                var endtime = dateTimePicker2.Value.Date;
                int currentweek = GetIso8601WeekOfYear(weekstart);
                DateTime date1 = weekstart;
                DateTime date2 = endtime;
                int BerichtNummer = 1;

                //Debug box


                MessageBox.Show(currentweek.ToString());

                string str = null;
                OpenFileDialog dia = new OpenFileDialog();
                if (dia.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    year = dateTimePicker1.Value.Year;
                    str = dia.FileName;
                    doc = app.Documents.Open(str);
                    filenameonly = doc.FullName;
                    int WeeksInTotal = (int)GetWeeks(weekstart, endtime);
                    MessageBox.Show(WeeksInTotal.ToString());
                    // System.Console.WriteLine(currentweek);
                    // MessageBox.Show(str);
                    //MessageBox.Show(doc.Bookmarks.ToString());          

                    //Checks how many days are left till monday. Currently ignores the fact if its already monday, need to fix that.
                    //MessageBox.Show(DaysUntilMonday(weekstart).ToString());


                    /*   Add all bookmarks
                     * @TODO: Read in names 
                     */
                    for (int i = BerichtNummer; i <= WeeksInTotal; i++)
                    {
                        WriteInBookmark("Nummer", i.ToString());
                        WriteInBookmark("WocheStart", date1.ToString("d"));
                        // TODO: Datum vor der for schleife initializieren.
                        date1 = date1.AddDays(DaysUntilFriday(date1));
                        WriteInBookmark("WocheEnde", date1.ToString("d"));
                        WriteInBookmark("AusbildungsJahr", AusbildungsJahr(BerichtNummer).ToString());



                        // StripFilePath(str, filenameonly);
                        //  MessageBox.Show(SaveFileName(BerichtNummer, "Matthias", "Tobin", currentweek, year.ToString()));
                        doc.SaveAs2(folderName + SaveFileName(i, "Matthias", "Tobin", currentweek, year.ToString()));
                        date1 = date1.AddDays(DaysUntilMonday(date1));
                        currentweek = GetIso8601WeekOfYear(date1);
                        year = date1.Year;

                    }
                    doc.Close();
                    app.Quit();


                    //   MessageBox.Show(date1.ToString());


                }
            }

        }

        //attempt to strip the filename from the path. Not working properly yet
        public string StripFilePath(string FileName, string filenameonly)
        {
            MessageBox.Show(FileName.Length.ToString());
            MessageBox.Show(filenameonly.Length.ToString());
            //FileName.Remove()

                return null;
        }

        //Returns the final savename. 
        private string SaveFileName(int iterator, string firstname, string lastname, int kalenderwoche, string year)
        {
            string finalsavefilename = iterator + ".Berichtsheft_" + firstname + "_" + lastname + "_" + year + "_KW_" + kalenderwoche + "_003.docx";

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


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
          

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
            if(NachweisNummer < 53)
            {
                return 1;
            } else if (NachweisNummer < 52 && NachweisNummer > 105)
            {
                return 2;

            } else if (NachweisNummer < 104)
            {
                return 3;
            }
            else
            {
                return 0;
            }

            
        }

        private int AmountOfWeeksInTotal (DateTime start, DateTime ende)
        {
            int weeks = (int)GetWeeks(start, ende);
            return weeks;

        }

        private decimal GetWeeks(DateTime start, DateTime end)
        {
            start = GetStartOfWeek(start);
            end = GetStartOfWeek(end);
            decimal days = (int)(end - start).TotalDays;
            return Math.Ceiling((days / 7));
        }

        private DateTime GetStartOfWeek (DateTime input)
        {
            int dayofWeek = (((int)input.DayOfWeek) + 6) % 7;
            return input.Date.AddDays(-dayofWeek);

        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
