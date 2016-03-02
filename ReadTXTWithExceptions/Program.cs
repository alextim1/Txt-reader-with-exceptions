using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadTXTWithExceptions
{
    class FileTxtReader
    {
        public bool TxtRead (out string fileText, string path)
        {

             

            try
            {
                string[] extenshion = path.Split('.');

                StreamReader fileTxt = new StreamReader(path);

                if (extenshion[extenshion.Length-1]!="txt")
                {
                    throw new ArgumentException();
                }

                

                fileText = fileTxt.ReadToEnd();

                fileTxt.Close();

                return true;

            }

            catch (ArgumentException)
            {
                Console.WriteLine("wrong path or file name or file is not txt. Check path and try again");
                fileText = "";
                return false;
            }

            catch (IOException)
            {
                Console.WriteLine("Something went wrong during attemtion to  read file. Check file and try again");
                fileText = "";
                return false;
            }

          
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FileTxtReader currentReader = new FileTxtReader();
            Console.WriteLine("Enter path to txt file");

            bool success = false;
            string fileText="";
            while (success==false)
            {

                success = currentReader.TxtRead(out fileText, Console.ReadLine());
            }

            Console.Write(fileText);
            Console.ReadKey();
        }
    }
}
