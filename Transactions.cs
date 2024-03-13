using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS221_Starter_Code
{
    class Transactions
    {
        //Here are my Transactions class variables
        private int transId;
        private string email;
        private int movieId;
        private string rentDate;
        private string returnDate;
        static private int count;

        public Transactions(int transId, string email, int movieId, string rentDate, string returnDate)
        {
            //Here is my Transactions constructor
            this.transId = transId;
            this.email = email;
            this.movieId = movieId;
            this.rentDate = rentDate;
        }

        public Transactions()
        {
            //And here is my no-arg constructor followed by getters and setters for my class variables
        }
        public int GetTransId()
        {
            return transId;
        }
        public void SetTransId(int transId)
        {
            this.transId = transId;
        }
        public string GetEmail()
        {
            return email;
        }
        public void SetEmail(string email)
        {
            this.email = email;
        }
        public int GetMovieId()
        {
            return movieId;
        }
        public void SetMovieId(int movieId)
        {
            this.movieId = movieId;
        }
        public string GetRentDate()
        {
            return rentDate;
        }
        public void SetRentDate(string rentDate)
        {
            this.rentDate = rentDate;
        }
        public string GetReturnDate()
        {
            return returnDate;
        }
        public void SetReturnDate(string returnDate)
        {
            this.returnDate = returnDate;
        }
        public static int GetCount()
        {
            return count;
        }
        public static void SetCount(int count)
        {
            Transactions.count = count;
        }
        public override string ToString()
        {
            //ToString() takes the data from transactions.txt and converts it to a string
            return transId + "\t" + email + "\t" + movieId + "\t" + rentDate + "\t" + returnDate;
        }

        public string ToFile()
        {
            //ToFile() takes the data from transactions.txt and adds #'s so that it can be written to the .txt file
            return transId + "#" + email + "#" + movieId + "#" + rentDate + "#" + returnDate;
        }
        public static void SortByTransID(Transactions[] myTrans)
        {
            int minIndex;

            for (int i = 0; i < Transactions.GetCount() - 1; i++)
            {
                minIndex = i;

                for (int j = i + 1; j < GetCount(); j++)
                {
                    if (myTrans[j].GetTransId() < myTrans[minIndex].GetTransId())
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    Swap(myTrans, i, minIndex);
                }
            }
        }
        public static void SortByEmail(Transactions[] myTrans)
        {
            int minIndex;

            for (int i = 0; i < Transactions.GetCount() - 1; i++)
            {
                minIndex = i;

                for (int j = i + 1; j < GetCount(); j++)
                {
                    if (myTrans[j].GetEmail().CompareTo(myTrans[minIndex].GetEmail()) < 0)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    Swap(myTrans, i, minIndex);
                }
            }
        }
       
        public static void Swap(Transactions[] myTrans, int x, int y)
        {
            Transactions  temp = myTrans[x];
            myTrans[x] = myTrans[y];
            myTrans[y] = temp;
        }
        public static void SortByMovieID(Transactions[] myTrans)
        {
            int minIndex;

            for (int i = 0; i < Movies.GetCount() - 1; i++)
            {
                minIndex = i;

                for (int j = i + 1; j < GetCount(); j++)
                {
                    if (myTrans[j].GetMovieId() < myTrans[minIndex].GetMovieId())
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    Swap(myTrans, i, minIndex);
                }
            }
        }
        public static int SearchByMovieID(Transactions[] myTrans, int searchVal)
        {
            Transactions.SortByMovieID(myTrans);

            int foundIndex = -1;
            bool notFound = true;

            int firstId = 0;
            int lastId = GetCount() - 1;
            int midId;

            while (notFound && firstId <= lastId)
            {
                midId = (firstId + lastId) / 2;

                if (searchVal == myTrans[midId].GetTransId())
                {
                    notFound = false;
                    foundIndex = midId;
                }
                else if (searchVal > myTrans[midId].GetTransId())
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
    }
}
