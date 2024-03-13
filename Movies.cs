using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MIS221_Starter_Code
{
    class Movies
    {
        //Here I declare my class variables
        private int id;
        private string name;
        private string genre;
        private int year;
        private string inStock;
        static private int count;

        public Movies(int id, string name, string genre, int year, string inStock)
        {
            //Here is my Movies constructor
            this.id = id;
            this.name = name;
            this.genre = genre;
            this.year = year;
            this.inStock = inStock;
        }

        public Movies()
        {
            //And this is my no-arg constructor followed by getters and setters for each class variable
        }

        public int GetId()
        {
            return id;
        }

        public void SetId(int id)
        {
            this.id = id;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetGenre()
        {
            return genre;
        }

        public void SetGenre(string genre)
        {
            this.genre = genre;
        }

        public int GetYear()
        {
            return year;
        }

        public void SetYear(int year)
        {
            this.year = year;
        }
        public string GetStock()
        {
            return inStock;
        }
        public void SetStock(string inStock)
        {
            this.inStock = inStock;
        }

        public static int GetCount()
        {
            return count;
        }

        public static void SetCount(int count)
        {
            Movies.count = count;
        }

        public static void IncCount()
        {
            count++;
        }

        public int CompareTo(string name)
        {
            return this.name.CompareTo(name);
        }

        public int CompareTo(Movies myMovies)
        {
            return name.CompareTo(myMovies.GetName());
        }

        public override string ToString()
        {
            //ToString() writes all the data from a movie without #'s
            return id + " " + name + " " + genre + " " + year + " " + inStock;
        }

        public string ToFile()
        { 
            //ToFile writes all of the data from a movie with #'s so that it can be used in the .txt file
            return id + "#" + name + "#" + genre + "#" + year + "#" + inStock;
        }

        public static void PrintMovies(Movies[] myMovies)
        {
            //PrintMovies() takes the data from myMovies and displays it
            Console.WriteLine("ID" + "\t" + "Name" + "\t" + "Genre" + "\t" + "Release Year" + "\t"+ "In Stock");

            for (int i = 0; i < GetCount(); i++)
            {
                Console.WriteLine(myMovies[i].ToString());
            }
        }

        public static void SortByGenre(Movies[] myMovies)
        {
            int minIndex;

            for (int i = 0; i < Movies.GetCount() - 1; i++)
            {
                minIndex = i;

                for (int j = i + 1; j < GetCount(); j++)
                {
                    if (myMovies[j].GetGenre().CompareTo(myMovies[minIndex].GetGenre()) < 0)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    Swap(myMovies, i, minIndex);
                }
            }
        }
        public static void SortByID(Movies[] myMovies)
        {
            int minIndex;

            for (int i = 0; i < Movies.GetCount() - 1; i++)
            {
                minIndex = i;

                for (int j = i + 1; j < GetCount(); j++)
                {
                    if (myMovies[j].GetId() < myMovies[minIndex].GetId())
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    Swap(myMovies, i, minIndex);
                }
            }
        }
        public static int SearchByID(Movies[] myMovies, int searchVal)
        {
            Movies.SortByID(myMovies);

            int foundIndex = -1;
            bool notFound = true;

            int firstId = 0;
            int lastId = GetCount() - 1;
            int midId;

            while (notFound && firstId <= lastId)
            {
                midId = (firstId + lastId) / 2;

                if (searchVal == myMovies[midId].GetId())
                {
                    notFound = false;
                    foundIndex = midId;
                }
                else if (searchVal > myMovies[midId].GetId())
                {
                    firstId = midId + 1;
                }
                else
                {
                    lastId = midId - 1;
                }

            }

            return foundIndex;

        }

        public static void Swap(Movies[] myMovies, int x, int y)
        {
            Movies temp = myMovies[x];
            myMovies[x] = myMovies[y];
            myMovies[y] = temp;
        }
        
    }
}
