using System;
using System.IO;
using System.Threading.Tasks;
using CSVReader.Controllers; 
using CSVReader.Models;

/*

Your application should accomplish the following:
    1. Count the number of rows in each file
    2. Count the number of columns in each file
    3. Remove rows by matching phone numbers
    4. Add additional rows
    5. Allow searching by phone number
    6. Change the data in a row
    7. Append the contents of the smaller file to the larger file and then check for and remove duplicates (phone numbers MUST all be unique)


The app should follow these rules:
    1. Command line or web based
    2. Memory footprint should never exceed 1 MB
    3. No databases
    4. May be written in the language of your choice.

*/

namespace CSVReader
{
    class Program
    {
        static void Main()
        {
            Model model = Model.Instance; 

            // 4 is append a phone number
            // 5 is search for phone number 
            model.Mode = 4;
            // model.SearchPhoneNumber = "8991215354";

            Controller.Instance.ReadFile();

            Program.AddRow();

            Console.WriteLine("The amount of rows are {0}.",model.Rows);
            Console.WriteLine("The amount of cols are {0}.",model.Columns);
        }

        static void AddRow()
        {
            // string[] newRow = new string[Model.Instance.ColumnHeaders.Length];
            string newRow = "";

            for (int i = 0; i < Model.Instance.ColumnHeaders.Length; i++)
            {
                Console.WriteLine("{0}?",Model.Instance.ColumnHeaders[i]);
                newRow += Console.ReadLine();

                if( i != Model.Instance.ColumnHeaders.Length-1)
                {
                    newRow += ",";
                }
            }

            Controller.Instance.AddRow(newRow);
        }

        
    }
}
