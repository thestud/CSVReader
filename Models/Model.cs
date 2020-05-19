namespace CSVReader.Models
{
    public sealed class Model
    {
        private static readonly Model instance = new Model();

        public string FileName = "small_data.txt";

        public bool Header = true;

        public string[] ColumnHeaders; 

        public int Rows = 0;

        public int Columns = 0; 

        public int Mode = 0; 

        public string SearchPhoneNumber = "";


        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Model()
        {
        }

        private Model()
        {
        }

        public static Model Instance
        {
            get
            {
                return instance;
            }
        }
    }
}