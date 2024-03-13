using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MIS221_Starter_Code
{
    class MovieFile
    {
        public static Movies[] ReadMoviesFile()
        {
            //ReadMoviesFile() reads in all of the movies in the myMovies array and splits them with # delimiter
            Movies[] myMovies = new Movies[100];
            char delimiter = '#';

            if (File.Exists("movieinventory.txt"))
            {
                StreamReader infile = new StreamReader("movieinventory.txt");
                string inputLine = infile.ReadLine();
                while (inputLine != null)
                {
                    string[] tempArray = inputLine.Split(delimiter);
                    myMovies[Movies.GetCount()] = new Movies(int.Parse(tempArray[0]), tempArray[1], tempArray[2], int.Parse(tempArray[3]), (tempArray[4]));

                    Movies.SetCount(Movies.GetCount() + 1);
                    inputLine = infile.ReadLine();
                }

                infile.Close();
            }

            else if (!(File.Exists("movieinventory.txt")))
            {
                //If movieinventory.txt does not exist, the user is informed
                Console.WriteLine("File unavailable");
            }

            return myMovies;
        }



        public static void WriteMoviesFile(Movies[] myMovies)
        {
            //WriteMoviesFile() writes the movies in myMovies to movieinventory.txt
            StreamWriter outFile = new StreamWriter("movieinventory.txt");

            for (int i = 0; i < Movies.GetCount(); i++)
            {
                outFile.WriteLine(myMovies[i].ToFile());
            }

            outFile.Close();
        }
    }
}
