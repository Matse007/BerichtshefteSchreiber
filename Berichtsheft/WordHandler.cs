using Microsoft.Office.Interop.Word;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using Word = Microsoft.Office.Interop.Word;
using System.Windows.Forms;
using Serilog;

namespace Berichtsheft
{
    class WordHandler
    {

        ResourceWriter rw = new ResourceWriter(@".\Resources.resx");
        Microsoft.Office.Interop.Word.Application WordObj;

        Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
        private string str;

        public string Str
        {
            get { return this.str; }
            set { this.str = value; }
        }
        public enum ClosingArguments
        {
            document,
            word
        }
        bool documentopen { get; set; }
        private int year;
        List<string> bookmarks = new List<string>();
        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }
        public DateTime AusbildungsstartDate { get; set; }

        public int AusbildungsYear { get; set; }
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
        public int Berichtnummer {get;set; }
        /// <summary>
        /// The standard constructor that also automatically creates a logger.
        /// </summary>
        public WordHandler()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("logs/BerichtshefteSchreiberLog.txt", shared: true, retainedFileCountLimit: 1)
                .CreateLogger();
            WordObj = (Microsoft.Office.Interop.Word.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
        }

        /// <summary>
        /// A function that loops through the bookmarks in a word document and populates a string list.
        /// This is used as if you iterate through the Bookmark collection in a word document and add new bookmarks,
        /// it will keep looping through the newly added elements over and over again. This forces us 
        /// to create a seperate collection. As this is not altered in a later loop, it does not keep looping through.
        /// </summary>
        public void populateBookmarks()
        {
            try
            {
                bookmarks.Clear();
                foreach (Bookmark bm in doc.Bookmarks)
                {
                    bookmarks.Add(bm.Name);
                }
            }
            catch (Exception e)
            {
                Log.Error("Ein Fehler ist in der Funktion populateBookmarks aufgetreten: " + e.ToString());
                throw;
            }

        }
        /// <summary>
        /// Simple function to open a document that we passed through earlier. 
        /// Currently could cause issues if the path to the file is not set.
        /// </summary>
        public void openDocument()
        {

            try
            {
                foreach (Document docum in WordObj.Documents)
                {
                    if (docum.FullName.Equals(str)){
                        MessageBox.Show("The Word document has already been opened.");
                        Log.Error("Word Document already opened");
                        throw new DocumentAlreadyOpenException("Document already opened");
                    }
                }
                Log.Information("Sucesfully opened the document: " + str);
                doc = app.Documents.Open(str);
            }
            catch (Exception e)
            {
                Log.Error("The following Error occured: " + e.ToString());
                throw;
            }
        }
        /// <summary>
        /// The main Method of this class. Based on the user inputs, calculates the total amount of reports it has to do,
        /// checks what has to be filled out and then starts to generate all the reports in a for loop.
        /// </summary>
        public void writeDocuments()
        {
            Log.Debug("Starting the Word writing Process.");
            //Get the initial week. 
            int currentweek = GetIso8601WeekOfYear(Date1);
            //Get the year of the starting date.
            year = Date1.Year;

            //Calculates total amount of reports that need to be generated. 
            int WeeksInTotal = (int)GetWeeks(Date1, Date2);
            Form1.setloadingBar(WeeksInTotal);
            Log.Debug("Amount of loops: " + WeeksInTotal);
            //Im Falle das die Dokumentation erst ab einen späteren Zeitpunkt beginnen soll, wird hier ein neuer totaler Wert berechnet.
            //Dieser wird um 1 abgezogen, da ansonsten eine zusätzliche Iteration durchlaufen wird.
            if (Berichtnummer > 1)
            {
                WeeksInTotal =  WeeksInTotal + Berichtnummer -1;
            }           
            for (int i = Berichtnummer; i <= WeeksInTotal; i++)
            {


                try
                {
                    WriteInBookmark(bmnummer, i.ToString());
                }
                catch (Exception e)
                {
                    Log.Error("Beim schreiben in die Berichtsheftnummer-Textmarke ist folgender Fehler aufgetreten: " + e.ToString());
                    throw;
                }


                try
                {
                    WriteInBookmark(bmwochestart, Date1.ToString("d"));
                }
                catch (Exception e)
                {
                    Log.Error("Beim schreiben in die Wochenstart-Textmarke ist folgender Fehler aufgetreten: " + e.ToString());
                    throw;
                }   
                Date1 = Date1.AddDays(DaysUntilFriday(Date1));

                try
                {
                    WriteInBookmark(bmwocheende, Date1.ToString("d"));
                }
                catch (Exception e)
                {
                    Log.Error("Beim schreiben in die Ende der Woche Textmarke ist folgender Fehler aufgetreten: " + e.ToString());
                    throw;
                }
                try
                {
                    WriteInBookmark(bmausbildungsjahr, AusbildungsJahr(Date1).ToString());
                }
                catch (Exception e)
                {
                    Log.Error("Beim schreiben in die Ausbildungsjahr-Textmarke ist folgender Fehler aufgetreten: " + e.ToString());
                    throw;
                }
                if (String.IsNullOrEmpty(BmName) == false)
                {
                    try
                    {
                        WriteInBookmark(BmName, UserName.TrimStart(' ').TrimEnd(' '));
                    }
                    catch (Exception e)
                    {
                        Log.Error("Beim schreiben in die Namens-Textmarke ist folgender Fehler aufgetreten: " + e.ToString());
                        throw;
                    }
                }
                if (String.IsNullOrEmpty(BmBerufsbezeichnung) == false)
                {
                    try
                    {
                        WriteInBookmark(BmBerufsbezeichnung, Berufsbezeichnung);
                    }
                    catch (Exception e)
                    {
                        Log.Error("Beim schreiben in die Berufsbezeichnungs-Textmarke ist folgender Fehler aufgetreten: " + e.ToString());
                        throw;
                    }
                }


                try
                {
                    Form1.changelabel("Schreibe " + SaveFileName(i, UserName.TrimStart(' ').TrimEnd(' '), currentweek, year.ToString(), AusbildungsJahr(Date1)));
                    doc.SaveAs2(Foldername + "\\" + SaveFileName(i, UserName.TrimStart(' ').TrimEnd(' '), currentweek, year.ToString(), AusbildungsJahr(Date1)));
                    Date1 = Date1.AddDays(DaysUntilMonday(Date1));
                    currentweek = GetIso8601WeekOfYear(Date1);
                    year = Date1.Year;
                    Form1.increaseLoadingProgress();
                }
                catch (Exception e)
                {
                    Log.Error("Im letzten abschnitt der Schleife ist folgender Fehler aufgetreten: " + e.ToString());
                    throw;
                }
            }
            Form1.changelabel("Fertig!");








        }
        /// <summary>
        /// Gets the week of the year for a specific date, following the ISO8601 norm.
        /// </summary>
        /// <param name="time">The date where you are trying to get the current week from.</param>
        /// <returns>The week of the year of that date.</returns>
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

        /// <summary>
        /// Simple function that creates a String for the filename.
        /// </summary>
        /// <param name="iterator">Current iteration of the loop</param>
        /// <param name="name">Name of the user</param>
        /// <param name="kalenderwoche">Current Calenderweek</param>
        /// <param name="year">Current year</param>
        /// <param name="ausbildungsjahr">Current year of the apprencticeship</param>
        /// <returns>The filename</returns>
        private string SaveFileName(int iterator, string name, int kalenderwoche, string year, int ausbildungsjahr)
        {
            string[] sub = name.Split(' ');
            string seperatedname = String.Join("_", sub);
            string finalsavefilename = iterator + ".Berichtsheft_" + seperatedname + "_" + year + "_KW_" + kalenderwoche + "_00" + ausbildungsjahr + ".docx";

            return finalsavefilename;

        }
        /// <summary>
        /// Function for closing Word, either entirely or the current document. Each time calls the GC, and in case that the 
        /// entire Word instance is closed, it releases the object, so no Word process will be running afterwards. Also, runs the 
        /// GC manually to ensure, that everything is disposed of properly.
        /// </summary>
        /// <param name="closingArguments"> Enum Parameter that determines if you want to close the current doc or the 
        /// entire word instance.</param>
        public void CloseWord(ClosingArguments closingArguments)
        {
            if (doc == null)
            {
                Log.Information("No doc has been opened while closing the application. No instances of Word or any Documents have to be closed.");
            }
            else
            {
                switch (closingArguments)
                {

                    case ClosingArguments.word:
                        doc.Close();
                        doc = null;
                        app.Quit();
                        System.Runtime.InteropServices.Marshal.FinalReleaseComObject(app);
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        Log.Information("Document and Word Application have been closed successfully.");
                        break;
                    case ClosingArguments.document:
                        doc.Close();
                        doc = null;
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        Log.Information("Document has been closed successfully.");
                        break;
                    default:
                        Console.WriteLine("While closing the current word document, something went wrong");
                        break;

                }
            }


        }
        /// <summary>
        /// Checking how many days are until the next monday. If it is already monday, it will return 7 days by default.
        /// </summary>
        /// <param name="currentdate"></param>
        /// <returns>Returns the amount of days until the next monday as an integer.</returns>
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
        /// <summary>
        /// Calculates how many days is until the next friday. In the case of the apprenticeship starting on a 
        /// friday, it will stay on this friday for the calculation. Otherwise goes to the next friday in the current week.
        /// </summary>
        /// <param name="currentdate"></param>
        /// <returns>Days until the next Friday</returns>
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



        /// <summary>
        /// This function is used to write to a bookmark in a word document. Due to FormFields,
        /// possibly breaking it, we are selecting the entire bookmark, then inserting the text and
        /// afterwards creating the new range boundaries for the bookmark that we are readding.
        /// It is being readded, so we can utilize it again in the next iteration.
        /// </summary>
        /// <param name="lesezeichen"></param>
        /// <param name="inhalt"></param>
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

        /// <summary>
        /// Simply calculates the year by dividing by 52 weeks and then rounding the result up.
        /// This does not account for the rare case of a leap year happening.
        /// </summary>
        /// <param name="NachweisNummer"></param>
        /// <returns>Returns the current apprenticeship year.</returns>
        private int AusbildungsJahr(DateTime currentDate)
        {
            DateTime yearDate = AusbildungsstartDate.AddYears(1);
            int returnValue = AusbildungsYear;
            while(currentDate > yearDate)
            {
                returnValue = returnValue + 1;
                yearDate = yearDate.AddYears(1);
            }
            return returnValue;

        }
        /// <summary>
        /// This function calculates the total amount of weeks from a starting date another date.
        /// From dates we are going to the first day of the week and the endDate will go to the sunday of that week.
        /// From there we are calculating the total amount of days between the 2 dates and calculate the amount of weeks.
        /// This number is rounded up in case that the start
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        private decimal GetWeeks(DateTime startDate, DateTime endDate)
        {
            startDate = GetStartOfWeek(startDate);
            endDate = GetStartOfWeek(endDate).AddDays(6);
            decimal days = (int)(endDate - startDate).TotalDays;
            int result = DateTime.Compare(startDate, endDate);
            if (result > 0 && days == 0)
            {
                return 1;
            }
            else
            {
                return Math.Ceiling((days / 7));
            }
        }

        /// <summary>
        /// Getting the start of the week by adding 6 days and then mod 7. 
        /// This way we always have a rest that we can take to subtract from our current date.
        /// If we already have monday the result of the first calculation is 0, which means that no days are
        /// substracted.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>The start of the week date.</returns>
        private DateTime GetStartOfWeek(DateTime input)
        {
            int dayofWeek = (((int)input.DayOfWeek) + 6) % 7;
            return input.Date.AddDays(-dayofWeek);

        }


    }
}