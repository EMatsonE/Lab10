using System;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            bool redo = true;
            while (redo == true)
            {
                List<Movies> movies = ListOfMovies();
                Console.WriteLine("Hello! Please select a genre by typing a number" +
                    " 1=animated 2=drama 3=horror 4=scifi.");
                ListByCatagory(movies);
                redo = GoAgain();
            }
        }
        public static int IsValidNumber(string userInput)
        {
            bool redo = true;
            while (redo == true)
            {
                int validNumber;
                //is technically broken and must be fixed, ask Nick
                bool success = int.TryParse(userInput, out validNumber);
                if (success == true)
                {

                    if (validNumber >= 1 && validNumber <= 4)
                    {
                        redo = false;
                        return validNumber;
                    }
                    else
                    {
                        Console.WriteLine("Sorry But I need a number between 1 and 4.");
                        ListByCatagory(ListOfMovies());
                    }
                }
                else
                {
                    Console.WriteLine("I need a number between 1 and 4.");
                    ListByCatagory(ListOfMovies());
                }

                //ValidUserInput();
            }
            return 0;
        }

        public static bool GoAgain()
        {
            Console.WriteLine("Would you like to try again?");
            string userInput = Console.ReadLine().Trim().ToLower();
            if (userInput == "yes")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Goodbye!");
                return false;
            }
        }
        public static void ListByCatagory(List<Movies> ListOfMovies)
        {
            //int userInput = IsValidNumber(ValidUserInput());
            int userInput = int.Parse(ValidUserInput());
            List<Movies> filteredMovies = ListOfMovies
                .Where(movie => (int)movie.Catagory == userInput)
                .OrderBy(x => x.Title)
                .ToList();
            foreach (var movie in filteredMovies)
            {
                Console.WriteLine(movie.Title);
            }
        }
        //public static void ListByCatagory(List<Movies> ListOfMovies)
        //{
        //    //comment this out later
        //    int userInput = int.Parse(Console.ReadLine());

        //    foreach (var movie in ListOfMovies)
        //    {
        //        if(userInput == (int)movie.Catagory)
        //        {
        //            Console.WriteLine(movie.Title);
        //        }
        //    }
        //}
        public static List<Movies> ListOfMovies()
        {
            List<Movies> movieList = new List<Movies>();

            movieList.Add(new Movies("Dune", Genre.scifi));
            movieList.Add(new Movies("Frozen", Genre.animated));
            movieList.Add(new Movies("IT", Genre.horror));
            movieList.Add(new Movies("High School Musical", Genre.drama));
            movieList.Add(new Movies("Alien Vs. Predator", Genre.scifi));
            movieList.Add(new Movies("Tangled", Genre.animated));
            movieList.Add(new Movies("Sound of Music", Genre.drama));
            movieList.Add(new Movies("The Shining", Genre.horror));
            movieList.Add(new Movies("Star Wars", Genre.scifi));
            movieList.Add(new Movies("Inside Out", Genre.animated));



            List<string> movieTitles = movieList.Select(x => x.Title).ToList();
            movieTitles.Sort();

            return movieList;
        }
        public static string ValidUserInput()
        {
            string input;
            bool redo = true;

            while (redo == true)
            {
                input = Console.ReadLine(); 
                bool isEmpty = string.IsNullOrEmpty(input);
                if (isEmpty == false)
                {
                    redo = false;
                    return input;
                }
                else
                {
                    Console.WriteLine("Sorry but you have to actually type something...");
                }
            }
            return "";
        }
        public static void Rubric()
        {
            //NOTE: Points will be awarded for items that are written correctly in themselves but don’t
            //actually work because other things are broken.There is a total of 10 points available for
            //this lab.

            //Task: List movies by category

            //What will the application do?
            //● The application stores a list of 10 movies and displays them by category.---
            //● The user can enter any of the following categories to display the films in the list that
            //match the category: 1-animated, 2-drama, 3-horror, 4-scifi.
            //● After the list is displayed, the user is asked if he or she wants to continue. If no, the
            //program ends.

            //Build Specifications:
            //● 1 Point: Each movie should be represented by an object of type Movie.---
            //● 1 Point: The Movie class must provide two private fields: title and category and the---
            //properties that go with them.---
            //● 2 Point: The class should also provide a constructor that accepts a title and category---
            //as parameters and uses the values passed to it to initialize its fields.---
            //● 2 Points: When the user enters a category, the program should read through all of---
            //the movies in the List and display a line for any movie whose category matches the---
            //category entered by the user.---
            //● 1 Point: Validate input don’t accept blanks for any of the questions./use regex

            //Additional Requirements:
            //● 1 Point: For answering Lab Summary when submitting to the LMS
            //● -2 Points: if there are any syntax errors or if the program does not run (for example,
            //in a Main method).

            //Extended Exercises:
            //● 1 Point: Standardize the category codes by displaying a menu of categories and---
            //having the user select the category by number rather than entering the name.---
            //maybe a list or dictionary?---
            //● 1 Point: Display the movies for the selected category in alphabetical order.---
            //use the Sort(); command---
        }
    }
}
