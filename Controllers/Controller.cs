using System;
using System.IO;
using System.Threading.Tasks;
using CSVReader.Models;

namespace CSVReader.Controllers
{
    public sealed class Controller
        {
        private static readonly Controller instance = new Controller();


        public void ReadFile()
        {
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(Model.Instance.FileName))
                {
                    string line;
                    // Read and display lines from the file until the end of
                    // the file is reached.

                    int Count = 0;

                    while ((line = sr.ReadLine()) != null)
                    {
                        if(Model.Instance.Header == true && Count == 0)
                        {
                            // There is a header and this is the row. 
                            Model.Instance.ColumnHeaders = line.Split(",");
                            Model.Instance.Columns = Model.Instance.ColumnHeaders.Length;

                        } else {
                            // Only works if I read the whole file. 
                            Model.Instance.Rows++;
                        }

                        // Trying to keep under the one meg memory. I am resisting loading the entire big file 
                        // into memory. Normally I would read the file, keep it in some list or database and do the
                        // searching from there. 
                        switch(Model.Instance.Mode)
                        {
                            case 5:
                                // search for phone number
                                // And if I could do a sort on the list, I would sort by phone number
                                if(line.IndexOf(Model.Instance.SearchPhoneNumber) > -1)
                                {
                                    Console.WriteLine(line);
                                    return; 
                                }
                            break; 

                            case 4:
                                // All I need is the header information and I have it. 
                                return;

                           
                        }
                        
                        Count++;
                        

                        // Console.WriteLine(line);
                    }
                }

                Console.WriteLine("End of File");
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public void AddRow(string newRow)
        {
            try{

                using (StreamWriter stream = new StreamWriter(Model.Instance.FileName, true))
                {
                    stream.WriteLine(newRow);
                }

            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could written to:");
                Console.WriteLine(e.Message);
            }
        }

        public void ChangeRow()
        {
            using(StreamReader sr = new StreamReader(Model.Instance.FileName))
            using(StreamWriter sw = new StreamWriter("temp.txt"))
            {
                string line; 

                while((line = sr.ReadLine()) != null)
                {
                    if(line.IndexOf(Model.Instance.SearchPhoneNumber) > -1)
                    {
                        // need the simple interface 
                    } else {
                        sw.WriteLine(line);
                    }
                }

            }

            File.Delete(Model.Instance.FileName);
            File.Move("temp.txt", Model.Instance.FileName);
        }

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Controller()
        {
        }

        private Controller()
        {
        }

        public static Controller Instance
        {
            get
            {
            return instance;
            }
        }
    }
}