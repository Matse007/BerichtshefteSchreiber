using Microsoft.Office.Interop.Word;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using Word = Microsoft.Office.Interop.Word;
using System.Windows.Forms;

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
        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }

        public int Year { get => year; set => year = value; }
        public List<string> Bookmarks { get => bookmarks; set => bookmarks = value; }
        private Document doc = null;
        public Document Doc { get => doc; set => doc = value; }
        public string Bmnummer { get => bmnummer; set => bmnummer = value; }
        private string bmnummer = null;
        public string Bmwochestart { get => bmwochestart; set => bmwochestart = value; }
        private string bmwochestart = null;
        public string Bmwocheende { get => bmwocheende; set => bmwocheende = value; }
        private string bmwocheende = null;
        public string Bmausbildungsjahr { get => bmausbildungsjahr; set => bmausbildungsjahr = value; }
        private string bmausbildungsjahr = null;
        public string BmName { get; set; }
        public string BmBerufsbezeichnung { get; set; }
        public string Foldername { get; set; }
        public string UserName { get; set; }
        public string Berufsbezeichnung { get; set; }
        private bool firstInizialization;



        public void populateBookmarks()
        {
            bookmarks.Clear();
            foreach (Bookmark bm in doc.Bookmarks)
            {
                bookmarks.Add(bm.Name);
            }

        }

        public void openDocument()
        {
            doc = app.Documents.Open(str);
        }

        public void writeDocuments()
        {


            int currentweek = GetIso8601WeekOfYear(Date1);
            int BerichtNummer = 1;

            year = Date1.Year;


            int WeeksInTotal = (int)GetWeeks(Date1, Date2);
            Form1.setloadingBar(WeeksInTotal);
            for (int i = BerichtNummer; i <= WeeksInTotal; i++)
            {


                WriteInBookmark(bmnummer, i.ToString());


                WriteInBookmark(bmwochestart, Date1.ToString("d"));

                // TODO: Datum vor der for schleife initializieren.
                Date1 = Date1.AddDays(DaysUntilFriday(Date1));

                WriteInBookmark(bmwocheende, Date1.ToString("d"));
                WriteInBookmark(bmausbildungsjahr, AusbildungsJahr(i).ToString());
                if (String.IsNullOrEmpty(BmName) == false)
                {
                    WriteInBookmark(BmName, UserName.TrimStart(' ').TrimEnd(' '));
                }
                if (String.IsNullOrEmpty(BmBerufsbezeichnung) == false)
                {
                    WriteInBookmark(BmBerufsbezeichnung, Berufsbezeichnung);
                }


                Form1.changelabel("Schreibe " + SaveFileName(i, UserName.TrimStart(' ').TrimEnd(' '), currentweek, year.ToString(), AusbildungsJahr(i)));
                doc.SaveAs2(Foldername + "\\" + SaveFileName(i, UserName.TrimStart(' ').TrimEnd(' '), currentweek, year.ToString(), AusbildungsJahr(i)));
                Date1 = Date1.AddDays(DaysUntilMonday(Date1));
                currentweek = GetIso8601WeekOfYear(Date1);
                year = Date1.Year;
                Form1.increaseLoadingProgress();
            }
            Form1.changelabel("Fertig!");








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
        private string SaveFileName(int iterator, string name, int kalenderwoche, string year, int ausbildungsjahr)
        {
            string[] sub = name.Split(' ');
            string seperatedname = String.Join("_", sub);
            string finalsavefilename = iterator + ".Berichtsheft_" + seperatedname + "_" + year + "_KW_" + kalenderwoche + "_00" + ausbildungsjahr + ".docx";

            return finalsavefilename;

        }

        public void CloseWord(char yes)
        {
            if (doc == null)
            {
                Console.WriteLine("No doc has been opened");
            }
            else
            {
                switch (yes)
                {

                    case 'y':
                        doc.Close();
                        doc = null;
                        app.Quit();
                        System.Runtime.InteropServices.Marshal.FinalReleaseComObject(app);
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        break;
                    case 'n':
                        doc.Close();
                        doc = null;
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        break;
                    default:
                        Console.WriteLine("While closing the current word document, something went wrong");
                        break;

                }
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
            if (firstInizialization)
            {
                if (((((int)DayOfWeek.Friday) - ((int)currentdate.DayOfWeek) + 7) % 7) != 0)
                {
                    firstInizialization = false;
                    return (((int)DayOfWeek.Friday) - ((int)currentdate.DayOfWeek) + 7) % 7;

                }
                else
                {
                    firstInizialization = false;
                    return 0;
                }
            }
            else
            {
                return (((int)DayOfWeek.Friday) - ((int)currentdate.DayOfWeek) + 7) % 7;
            }

        }




        private void WriteInBookmark(string lesezeichen, string inhalt)
        {
            string bookmark = lesezeichen;
            Bookmark bm = doc.Bookmarks[bookmark];
            Range range = bm.Range;
            
            bm.Select();
            app.Selection.TypeText(inhalt);
            range.End = range.Start + inhalt.Length;
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