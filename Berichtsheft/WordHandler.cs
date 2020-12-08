using Microsoft.Office.Interop.Word;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using Word = Microsoft.Office.Interop.Word;

namespace Berichtsheft
{
    class WordHandler
    {

        ResourceWriter rw = new ResourceWriter(@".\Resources.resx");
        Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
        private string str;

        public string Str
        {
            get { return this.str; }
            set { this.str = value; }
        }

        bool documentopen { get; set; }
        private int year;
        List<string> bookmarks = new List<string>();
        private DateTime date1;
        private DateTime date2;
        public DateTime Date1 { get => date1; set => date1 = value; }
        public DateTime Date2 { get => date2; set => date2 = value; }
        public string FolderName { get => folderName; set => folderName = value; }
        public int Year { get => year; set => year = value; }
        public List<string> Bookmarks { get => bookmarks; set => bookmarks = value; }
        Document doc = null;

        //path where we save the file.

        private string folderName;



        public void everything()
        {
            /**Creating a folder select window. I am asking for a folder to be selected where we will save the final "Berichtshefte". 
             * I am using Windows CommonOpenFileDialog to make it look like a File Select window while still being able to uzilize it as a folder picker
             * This is part of the Windows API Code Pack, imported through the NuGet Packet Manager.
             * After successfully selecting a folder, the application continues with the following steps.
             * 
             **/
            string bmnummer = null;
            string bmwochestart = null;
            string bmwocheende = null;
            string bmausbildungsjahr = null;
            CommonOpenFileDialog folderdialog = new CommonOpenFileDialog();
            folderdialog.Title = "Ordner zum Speichern der Berichtshefte wählen:";
            folderdialog.InitialDirectory = "C:\\Users";
            folderdialog.IsFolderPicker = true;
            // Show the FolderBrowserDialog.

            if (folderdialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                /// <value>folderName is saving the path where the user wants to save.
                string folderName = folderdialog.FileName;

                //Getting the date that was selected by the guy running the Programm
                int currentweek = GetIso8601WeekOfYear(date1);
                int BerichtNummer = 1;

                year = date1.Year;
                //Closing the doc in case it is already opened.
                //str = dia.FileName;
                doc = app.Documents.Open(str);
                //Changing the bool to let us know we have a document opened.
                documentopen = true;
                //needed? Filenameonly1 = doc.FullName;
                foreach (Bookmark bm in doc.Bookmarks)
                {
                    bookmarks.Add(bm.Name);

                }
                // int WeeksInTotal = (int)GetWeeks(weekstart, endtime);

                Form2 selectnummer = new Form2(bookmarks, 0);
                selectnummer.Text = "Berichtsheftnummerierung:";
                /* if (selectnummer.ShowDialog() == DialogResult.OK)
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
                     }*/
            }

        }




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

        //Returns the final savename. 
        private string SaveFileName(int iterator, string firstname, string lastname, int kalenderwoche, string year, int ausbildungsjahr)
        {
            string finalsavefilename = iterator + ".Berichtsheft_" + firstname + "_" + lastname + "_" + year + "_KW_" + kalenderwoche + "_00" + ausbildungsjahr + ".docx";

            return finalsavefilename;

        }

        public void closeWord()
        {
            if (documentopen == true)
            {



            }


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


    }
}