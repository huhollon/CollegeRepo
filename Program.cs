using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MIS221_Starter_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            //Starter Code

            //In this block of code is where new Movie ID's are generated
            Movies[] myMovies = MovieFile.ReadMoviesFile();
            Movies.SortByID(myMovies);
            int lastId = myMovies[Movies.GetCount() - 1].GetId();
            int newId = lastId + 1;

            //In this block of code is where new Transaction ID's are generated
            Transactions[] myTrans = TransactionFile.ReadTransFile();
            Transactions.SortByTransID(myTrans);
            int lastTrans = myTrans[Transactions.GetCount() - 1].GetTransId();
            int newTrans = lastTrans + 1;

            CreateMenu(myMovies, newId, myTrans, newTrans);

            Console.ReadKey();
        }

        static void CreateMenu(Movies[] myMovies, int newId, Transactions[] myTrans, int newTrans)
        {
            //In CreateMenu(), the user is given the choice between manager functions, customer functions, or to exit
            Console.WriteLine("Enter 1 for managerial functions, 2 for customer functions, or 3 to exit");
            int menuChoice = int.Parse(Console.ReadLine());

            while (!(menuChoice == 1 || menuChoice == 2 || menuChoice == 3))
            {
                //If the user's choice is invalid, they are asked to make a correct selection
                Console.WriteLine("Please enter a valid choice: ");
                menuChoice = int.Parse(Console.ReadLine());
            }

            while (menuChoice == 1 || menuChoice == 2)
            {
                if (menuChoice == 1)
                {
                    Console.WriteLine("Manager functions: ");
                    ManagerFunctions(myMovies, newId, myTrans, newTrans);
                }

                else
                {
                    Console.WriteLine("Customer functions: ");
                    CustomerFunctions(myMovies, newId, myTrans, newTrans);
                }
            }

            if (menuChoice == 3)
            {
                Console.WriteLine("Goodbye");
                System.Environment.Exit(0);
            }
        }

        static void ManagerFunctions(Movies[] myMovies, int newId, Transactions[] myTrans, int newTrans)
        {
            //In ManagerFunctions(), the user can add a movie, remove a movie, edit a movie, process batch transactions, access the report menu, or return to the main menu
            Console.WriteLine("Enter 1 to add a movie, 2 to remove a movie, 3 to edit a movie, 4 to " +
                              " process a batch transaction file, 5 to access the report menu, or 6 to return to the main menu");
            int managerChoice = int.Parse(Console.ReadLine());

            while (!(managerChoice == 1 || managerChoice == 2 || managerChoice == 3 || managerChoice == 4 || managerChoice == 5 || managerChoice == 6)) 
            {
                //If the user's choice is invalid, they are asked to make a correct choice
                Console.WriteLine("Please enter a valid choice: ");
                managerChoice = int.Parse(Console.ReadLine());
            }

            while (managerChoice == 1 || managerChoice == 2 || managerChoice == 3 || managerChoice == 4 || managerChoice == 5)
            {
                if (managerChoice == 1)
                {
                    Console.WriteLine("Add a movie: ");
                    AddMovie(myMovies, newId, myTrans, newTrans);
                }
                else if (managerChoice == 2)
                {
                    Console.WriteLine("Remove a movie: ");
                    RemoveMovie(myMovies, newId, myTrans, newTrans);
                }
                else if (managerChoice == 3)
                {
                    Console.WriteLine("Edit a movie: ");
                    EditMovie(myMovies, newId, myTrans, newTrans);
                }
                else if (managerChoice == 4)
                {
                    Console.WriteLine("Batch transaction: ");
                    BatchTransactions(myMovies, newId, myTrans, newTrans);
                }
                else if (managerChoice == 5)
                {
                    Console.WriteLine("Report menu: ");
                    ReportMenu(myMovies, newId, myTrans, newTrans);
                }
            }

            if (managerChoice == 6)
            {
                CreateMenu(myMovies, newId, myTrans, newTrans);
            }
        }

        static void CustomerFunctions(Movies[] myMovies, int newId, Transactions[] myTrans, int newTrans)
        {
            //In CustomerFunctions(), the user can view available moves, rent a movie, view thier rented movies, return a movie, or return to the main menu
            Console.WriteLine("Enter 1 to view available movies for rent, 2 to rent a movie, 3 to view your currently " +
                              "rented movies, 4 to return a movie, or 5 to return to the main menu");
            int customerChoice = int.Parse(Console.ReadLine());

            while (!(customerChoice == 1 || customerChoice == 2 || customerChoice == 3 || customerChoice == 4 || customerChoice == 5))
            {
                //If the user makes an invalid choice, they are asked to choose again
                Console.WriteLine("Please enter a valid choice: ");
                customerChoice = int.Parse(Console.ReadLine());
            }

            while (customerChoice == 1 || customerChoice == 2 || customerChoice == 3 || customerChoice == 4)
            {
                if (customerChoice == 1)
                {
                    Console.WriteLine("View movies: ");
                    ViewMovies(myMovies, newId, myTrans, newTrans);
                }
                else if (customerChoice == 2)
                {
                    Console.WriteLine("Rent a movie: ");
                    RentMovie(myMovies, newId, myTrans, newTrans);
                }
                else if (customerChoice == 3)
                {
                    Console.WriteLine("View your currently rented movies: ");
                    CurrentlyRented(myMovies, newId, myTrans, newTrans);
                }
                else if (customerChoice == 4)
                {
                    Console.WriteLine("Return a movie: ");
                    ReturnMovie(myMovies, newId, myTrans, newTrans);
                }
                Console.WriteLine("Enter 1 to view available movies for rent, 2 to rent a movie, 3 to view your currently " +
                                              "rented movies, or 4 to return a movie");
                customerChoice = int.Parse(Console.ReadLine());
            }

            if (customerChoice == 5)
            {
                CreateMenu(myMovies, newId, myTrans, newTrans);
            }
        }

        public static void AddMovie(Movies[] myMovies, int newId, Transactions[] myTrans, int newTrans)
        {
            //In AddMovie(), I created a new movie object called addMovie
            Movies addMovie = new Movies();

            Console.WriteLine("The new movie ID is " + newId);
            //Then I set the ID of the new movie to the ID that is generated in Main()
            addMovie.SetId(newId);

            Console.WriteLine("Enter the movie name: ");
            string name = Console.ReadLine();
            //Now the user inputs the name of the movie and that is set to the name of the addMovie object
            addMovie.SetName(name);

            Console.WriteLine("Enter the genre: ");
            string genre = Console.ReadLine();
            //Here the user inputs the genre of the movie and that is set to the genre of the addMovie object
            addMovie.SetGenre(genre);

            Console.WriteLine("Enter the release year: ");
            int year = int.Parse(Console.ReadLine());
            //Now the user inputs the release year and that is set to the release year of the addMovie object
            addMovie.SetYear(year);

            //Now I display addMovie to the screen
            Console.WriteLine(addMovie.ToString());
            //Using File.AppendText, I add addMovie to the end of the movieinventory.txt file
            StreamWriter outFile = File.AppendText("movieinventory.txt");
            Console.WriteLine();
            outFile.WriteLine(newId + "#" + addMovie.GetName() + "#" + addMovie.GetGenre() + "#" + addMovie.GetYear() + "#" + "In Stock");
            outFile.Close();

            ManagerFunctions(myMovies, newId, myTrans, newTrans);
        }

        static void RemoveMovie(Movies[] myMovies, int newId, Transactions[] myTrans, int newTrans)
        {
            //In RemoveMovie, the user enters the ID of the movie they are removing
            Console.WriteLine("Enter the ID of the movie you would like to remove: ");
            int removeId = int.Parse(Console.ReadLine());
            //Next I use Movies.SearchByID to search for the value of the ID that is being removed
            int foundIndex = Movies.SearchByID(myMovies, removeId);
            string removedMovie = "";

            while (removeId != -1)
            {
                if (foundIndex != -1)
                {
                    //Now I write the deleted movie to the screen to inform the user
                    Console.WriteLine(myMovies[foundIndex].GetName() + " has been deleted");
                    //In the file, I attach the word (Removed) to the name to indicate a soft delete
                    removedMovie = myMovies[foundIndex].GetName() + "(Removed)";
                    myMovies[foundIndex].SetName(removedMovie);
                    
                    Console.WriteLine(myMovies[foundIndex].ToString());

                    StreamWriter outFile = new StreamWriter("movieinventory.txt");
                    Console.WriteLine();

                    for (int i = 0; i < Movies.GetCount(); i++)
                    {
                        //Here I write the deleted movie data to the movieinventory.txt file
                        outFile.WriteLine(myMovies[i].ToFile());
                    }

                    outFile.Close();
                }
                else
                { 
                    //If the user enters an ID that does not exist, they are prompted to try again
                    Console.WriteLine("Invalid choice");
                }

                Console.WriteLine("Enter the ID of the movie you would like to remove or -1 to exit: ");
                removeId = int.Parse(Console.ReadLine());
            }

            ManagerFunctions(myMovies, newId, myTrans, newTrans);
        }

        static void EditMovie(Movies[] myMovies, int newId, Transactions[] myTrans, int newTrans)
        {
            //In EditMovie, I display the list of movies so that the user may make their choice
            Movies.PrintMovies(myMovies);
            //Here the user enter the ID of the movie they want to edit
            Console.WriteLine("Enter the ID of the movie you would like to edit: ");
            int editId = int.Parse(Console.ReadLine());
            //Now I use Movies.SearchByID to find the value that the user has input
            int foundIndex = Movies.SearchByID(myMovies, editId);

            //Now the user selects what data from the movie they would like to change
            Console.WriteLine("Enter 1 to change movie name, 2 to change genre, 3 to change release year, or " + 
                              " 4 to change the In Stock indicator :");
            int changeChoice = int.Parse(Console.ReadLine());

            while (changeChoice  != -1)
            { 
                if (changeChoice == 1)
                {
                    //If the user enters 1, they can change the name of the movie
                    Console.WriteLine("What would you like to change the name to?");
                    string changeName = Console.ReadLine();
                    //Now the movie that has been selected is set to the name that has been input
                    myMovies[foundIndex].SetName(changeName);
                    //Now the new movie is written to the .txt file
                    MovieFile.WriteMoviesFile(myMovies);
                }
                else if (changeChoice == 2)
                {
                    //If the user enters 2, they can change the genre of the movie
                    Console.WriteLine("What would you like to change the genre to?");
                    string changeGenre = Console.ReadLine();
                    //Now the movie that has been selected is set to the name of the new genre
                    myMovies[foundIndex].SetGenre(changeGenre);
                    //Now the new movie is written to the .txt file
                    MovieFile.WriteMoviesFile(myMovies);
                }
                else if (changeChoice  == 3)
                {
                    //If the user enters 3, they can change the release year of the movie
                    Console.WriteLine("What would you like to change the release year to?");
                    int changeYear = int.Parse(Console.ReadLine());
                    //Now the movie that has been selected is set to the new release
                    myMovies[foundIndex].SetYear(changeYear);
                    //Now the new movie is written to the .txt file
                    MovieFile.WriteMoviesFile(myMovies);
                }
                else if (changeChoice == 4)
                {
                    //If the user enters 4, they can change the stock setting of the movie
                    Console.WriteLine("You chose to make this movie out of stock: ");
                    string changeStock = "Out of Stock";
                    //Now the movie is set to be out of stock
                    myMovies[foundIndex].SetStock(changeStock);
                    //Now the new movie is written to the .txt file
                    MovieFile.WriteMoviesFile(myMovies);
                }
                else
                {
                    //If the user makes an invalid choice, they are promted to select again
                    Console.WriteLine("Please make a valid choice: ");
                }
                Console.WriteLine("Enter 1 to change movie name, 2 to change genre, 3 to change release year, or " + "" +
                                  " 4 to change the In Stock indicator, or -1 to exit: ");
                changeChoice = int.Parse(Console.ReadLine());
            }

            ManagerFunctions(myMovies, newId, myTrans, newTrans);
        }

        static void BatchTransactions(Movies[] myMovies, int newId, Transactions[] myTrans, int newTrans)
        {
            ManagerFunctions(myMovies, newId, myTrans, newTrans);
        }

        static void ReportMenu(Movies[] myMovies, int newId, Transactions[] myTrans, int newTrans)
        {
            //In ReportMenu(), the user can choose to view movies currently in stock, movies, that are being rented, the top 5 movies, or the number of movies in each genre
            Console.WriteLine("Enter 1 to view movies that are currently in stock, 2 to view movies that are currently rented" +
                                ", 3 to view top 5 movies, 4 to view number of movies in each genre, or 5 to return to the manager menu");
            int reportChoice = int.Parse(Console.ReadLine());

            while (!(reportChoice == 1 || reportChoice == 2 || reportChoice == 3 || reportChoice == 4 || reportChoice == 5))
            {
                //If the user inputs an invalid option, they are prompted to choose again
                Console.WriteLine("Please enter a valid choice: ");
                reportChoice = int.Parse(Console.ReadLine());
            }

            while (reportChoice == 1 || reportChoice == 2 || reportChoice == 3 || reportChoice == 4)
            {
                if (reportChoice == 1)
                {
                    Console.WriteLine("View movies currently in stock: ");
                    ViewInStock(myMovies, newId, myTrans, newTrans);
                }

                if (reportChoice == 2)
                {
                    Console.WriteLine("View movies currently rented: ");
                    ViewCurrRents(myMovies, newId, myTrans, newTrans);
                }

                if (reportChoice == 3)
                {
                    Console.WriteLine("View top 5 movies: ");
                    ViewTopFive(myMovies, newId, myTrans, newTrans);
                }

                if (reportChoice == 4)
                {
                    Console.WriteLine("View number of rentals in each genre: ");
                    MoviesPerGenre(myMovies, newId, myTrans, newTrans);
                }

                Console.WriteLine("Enter 1 to view movies that are currently in stock, 2 to view movies that are currently rented" +
                                  ", 3 to view top 5 movies, 4 to view number of movies in each genre, or 5 to return to the manager menu");
                reportChoice = int.Parse(Console.ReadLine());
            }

            if (reportChoice == 5)
            {
                Console.WriteLine("Manager functions: ");
                ManagerFunctions(myMovies, newId, myTrans, newTrans);
            }
        }

        static void ViewMovies(Movies[] myMovies, int newId, Transactions[] myTrans, int newTrans)
        {
            //In ViewMovies(), I made a call to the Movies function PrintMovies to display myMovies
            Movies.PrintMovies(myMovies);

            Console.WriteLine();
            CustomerFunctions(myMovies, newId, myTrans, newTrans);
        }

        static void RentMovie(Movies[] myMovies, int newId, Transactions[] myTrans, int newTrans)
        {
            //In RentMovie(), I created a new Transactions object called rental
            Transactions rental = new Transactions();
            //I display the movies so the user can make their selection
            Movies.PrintMovies(myMovies);
            //The user now inputs the ID of the movie they are renting
            Console.WriteLine("Enter the ID of the movie you would like to rent: ");
            int rentChoice = int.Parse(Console.ReadLine());
            //Now the ID selection is set to the MovieID of the rental oject
            rental.SetMovieId(rentChoice);
            //Here the user inputs their email address
            Console.WriteLine("Enter your email address :");
            string userEmail = Console.ReadLine();
            //Now the email is set to the email of the rental object
            rental.SetEmail(userEmail);

            //Using DateTime, I set the rentDate to Now and the returnDate to 2 weeks from now
            DateTime rentDate = DateTime.Now;
            DateTime returnDate = rentDate.AddDays(14);

            //Now I set the rent and return dates to the rental object
            rental.SetRentDate(rentDate.ToString("MM/dd/yyyy"));
            rental.SetReturnDate(returnDate.ToString("MM/dd/yyyy"));
            
            //Here I set the transaction ID for the rental object to the new transaction ID created in Main()
            rental.SetTransId(newTrans);

            //Now I use Movies.SearchByID to search for the ID of the movie the user wants to rent 
            int foundIndex = Movies.SearchByID(myMovies, rentChoice);
            string rentedMovie = "Out of Stock";

            while (rentedMovie != "-1")
            {
                if (foundIndex != -1)
                {
                    //Now that I have found the correct Movie ID, I set the stock of that movie to "Out of Stock"
                    myMovies[foundIndex].SetStock(rentedMovie);

                    StreamWriter outFileMovies = new StreamWriter("movieinventory.txt");
                    for (int i = 0; i < Movies.GetCount(); i++)
                    {
                        //Here I write myMovies to the .txt file to update the stock in teh file
                        outFileMovies.WriteLine(myMovies[i].ToFile());
                    }
                    outFileMovies.Close();
                }
                else
                {
                    //If the user's choice is invalid, they are prompted to choose again
                    Console.WriteLine("Invalid Choice: ");
                }
                
                rentedMovie = "-1";
            }

            //Here I tell the user when the movie is due back
            Console.WriteLine("Your movie is due back in 2 weeks on " + returnDate.ToString("MM/dd/yyyy"));

            //Now I update the transactions.txt file using File.AppendText
            StreamWriter outFile = File.AppendText("transactions.txt");
            Console.WriteLine();
            //The rental object is then written to the file
            outFile.WriteLine(rental.ToFile());
            outFile.Close();


            CustomerFunctions(myMovies, newId, myTrans, newTrans);
        }

        static void CurrentlyRented(Movies[] myMovies, int newId, Transactions[] myTrans, int newTrans)
        {
            //In CurrentlyRented(), the user enters their email to view the movies that they are currently renting
            Console.WriteLine("Enter your email to view the movies you currently have rented: ");
            string email = Console.ReadLine();
            //Here I sorted the transactions by email
            Transactions.SortByEmail(myTrans);

            for (int i = 0; i < Transactions.GetCount(); i++)
            {
                //Now the program goes through all of the transactions to see if the email is the same as the email that the user has entered
                if (myTrans[i].GetEmail() == email)
                {
                    //If the emails match, a search value is created from the Movie ID associated with that email
                    int rentedMovieId = myTrans[i].GetMovieId();
                    //Using Movies.SearchById, the program finds the matching Movie ID in the movies
                    int foundId = Movies.SearchByID(myMovies, rentedMovieId);
                    //Now I display the name of the ID that the search method found
                    Console.WriteLine(myMovies[foundId].GetName());
                }
            }

            Console.WriteLine();
            CustomerFunctions(myMovies, newId, myTrans, newTrans);
        }

        static void ReturnMovie(Movies[] myMovies, int newId, Transactions[] myTrans, int newTrans)
        {
            //In ReturnMovie(), the user can enter the ID of the movie that they are returning
            //I display the movies so that the user can input the ID
            Movies.PrintMovies(myMovies);
            //Now the user inputs the return ID
            Console.WriteLine("Enter the ID of the movie you would like to return: ");
            int returnID = int.Parse(Console.ReadLine());
            //And now the user inputs their email associated with that transaction
            Console.WriteLine("Enter your email address: ");
            string email = Console.ReadLine();
            //Now I use SearchByID to search for the ID of the movie being returned within the movies
            int foundIndex = Movies.SearchByID(myMovies, returnID);

            string inStock = "In Stock";

            while (!(foundIndex == -1 || returnID == -1))
            {
                //Once the Movie ID is found, its stock is changed to "In Stock"
                if (myMovies[foundIndex].GetStock() == "Out of Stock")
                {
                    myMovies[foundIndex].SetStock(inStock);
                    //Now I write the Movies to the .txt file
                    MovieFile.WriteMoviesFile(myMovies);
                }

                returnID = -1;
            }
            //And now I display the name of the movie that the user has returned
            Console.WriteLine("You have returned " + myMovies[foundIndex].GetName());
            //Here the transactions are sorted by email
            Transactions.SortByEmail(myTrans);

            StreamReader inFile = new StreamReader("transactions.txt");

            for (int i = 0; i < Transactions.GetCount(); i++)
            {
                //If the email in the .txt file is the same as what the user has entered it is re written with (Returned) to indicate that the movie has been returned
                if (myTrans[i].GetEmail() == email)
                { 
                    string removedRent = myTrans[i].GetEmail() + "(Returned)";
                    myTrans[i].SetEmail(removedRent);
                }
                
            }
            
            inFile.Close();
            //Now the transactions are resorted by ID and written to the .txt file
            Transactions.SortByTransID(myTrans);
            TransactionFile.WriteTransFile(myTrans);

            CustomerFunctions(myMovies, newId, myTrans, newTrans);
        }

        static void ViewInStock(Movies[] myMovies, int newId, Transactions[] myTrans, int newTrans)
        {
            //In ViewInStock() the user can view all of the movies that are currently in stock
            StreamReader inFile = new StreamReader("movieinventory.txt");
            //Here I sorted the movies by their ID
            Movies.SortByID(myMovies);

            for (int i = 0; i < Movies.GetCount(); i++)
            {
                //Now the program searches through each movie to see if their in stock indicator  == "In Stock"
                if (myMovies[i].GetStock() == "In Stock")
                {
                    //If the movie is in stock, its title is written to the console
                    Console.WriteLine(myMovies[i].GetName());
                }
            }

            inFile.Close();

            Console.WriteLine();
            ReportMenu(myMovies, newId, myTrans, newTrans);
        }

        static void ViewCurrRents(Movies[] myMovies, int newId, Transactions[] myTrans, int newTrans)
        {
            //In ViewCurrRents() the user can view all of the movies that are currently being rented
            StreamReader inFile = new StreamReader("movieinventory.txt");
            //Now I sort the Movies by thier ID
            Movies.SortByID(myMovies);

            for (int i = 0; i < Movies.GetCount(); i++)
            {
                //Now the program checks to see if the in stock indicator of each movie == "Out of Stock" 
                if (myMovies[i].GetStock() == "Out of Stock")
                {
                    //If the movie is out of stock, it is displayed
                    Console.WriteLine(myMovies[i].GetName());
                }
            }

            inFile.Close();

            Console.WriteLine();
            ReportMenu(myMovies, newId, myTrans, newTrans);
        }

        static void ViewTopFive(Movies[] myMovies, int newId, Transactions[] myTrans, int newTrans)
        {
            Transactions.SortByMovieID(myTrans);

            int rentCount = 0;

            for (int i = 0; i < Transactions.GetCount(); i++)
            {
                for (int j = 0; j < Transactions.GetCount() - 1; j++)
                {
                    if (myTrans[i].GetMovieId() == myTrans[j].GetMovieId())
                    {
                        int movieId = Movies.SearchByID(myMovies, myTrans[i].GetMovieId());
                        Console.WriteLine(myMovies[movieId].GetName() + " has been rented " + rentCount + " times");
                        rentCount++;
                    }
                }
            }

            ReportMenu(myMovies, newId, myTrans, newTrans);
        }

        static void MoviesPerGenre(Movies[] myMovies, int newId, Transactions[] myTrans, int newTrans)
        {
            Console.WriteLine("Enter the genre you would like to see a count for: ");
            string userGenre = Console.ReadLine();
            userGenre = userGenre.ToUpper();

            Movies.SortByGenre(myMovies);

            int movieCount = 0;

            for (int i = 0; i < Movies.GetCount(); i++)
            {
                string movieGenre = myMovies[i].GetGenre();
                movieGenre = movieGenre.ToUpper();

                if (movieGenre == userGenre)
                {
                    movieCount++;
                }



            }

            Console.WriteLine("There are " + movieCount + " movies in " + userGenre);


            Console.WriteLine();
            ReportMenu(myMovies, newId, myTrans, newTrans);
        }
        
    }
}
