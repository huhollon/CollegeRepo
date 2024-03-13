using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MIS221_Starter_Code
{
    class TransactionFile
    {
        public static Transactions[] ReadTransFile()
        {
            //ReadTransFile() reads in all of the data from transactions.txt and splits it at each #
            Transactions[] myTrans = new Transactions[100];
            char delimiter = '#';

            if (File.Exists("transactions.txt"))
            {
                StreamReader infile = new StreamReader("transactions.txt");
                string inputLine = infile.ReadLine();
                while (inputLine != null)
                {
                    string[] tempArray = inputLine.Split(delimiter);
                    myTrans[Transactions.GetCount()] = new Transactions(int.Parse(tempArray[0]), tempArray[1], int.Parse(tempArray[2]), tempArray[3], tempArray[4]);

                    Transactions.SetCount(Transactions.GetCount() + 1);
                    inputLine = infile.ReadLine();
                }

                infile.Close();
            }

            else if (!(File.Exists("transactions.txt")))
            {
                //If the file does not exist, the user is informed
                Console.WriteLine("File unavailable");
            }

            return myTrans;
        }



        public static void WriteTransFile(Transactions[] myTrans)
        {
            //WriteTransFile() writes all of the data in myTrans to transactions.txt
            StreamWriter outFile = new StreamWriter("transactions.txt");

            for (int i = 0; i < Transactions.GetCount(); i++)
            {
                outFile.WriteLine(myTrans[i].ToFile());
            }

            outFile.Close();
        }
    }
}
