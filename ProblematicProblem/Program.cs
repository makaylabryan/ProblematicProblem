using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        Random rng;

        static bool cont = true;
        
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            bool cont;
            var contResponse = Console.ReadLine().ToLower();

            if (contResponse == "yes")
            {
                cont = true;
            
            
         
             Console.WriteLine();
        
             Console.Write("We are going to need your information first! What is your name? ");
             string userName = Console.ReadLine();
             Console.WriteLine();
   
             Console.Write("What is your age? ");
             int userAge = int.Parse(Console.ReadLine());
             Console.WriteLine();

             Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
             bool seeList;
             var seeListResponse = Console.ReadLine().ToLower();

                 if (seeListResponse == "sure") 
                 {
                        seeList = true;
                        foreach (string activity in activities)
                        {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                        }
                        Console.WriteLine();
                 }
                 else if (seeListResponse == "no thanks")
                 { 
                        seeList = false;
                 }
                               
                
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                bool addToList = (Console.ReadLine().ToLower() == "yes") ? true : false;
                Console.WriteLine();

                            while (addToList)
                            {
                                Console.Write("What would you like to add? ");
                                string userAddition = Console.ReadLine();
                                
                                activities.Add(userAddition);

                                foreach (string activity in activities)
                                {
                                     Console.Write($"{activity} ");
                                     Thread.Sleep(250);
                                }

                                Console.WriteLine();
                                Console.WriteLine("Would you like to add more? yes/no: ");

                                addToList = (Console.ReadLine().ToLower() == "yes") ? true: false;
                               
                            }
                                              
                            Console.WriteLine();
       
                     
                

                while (cont)
                {
                    Console.Write("Connecting to the database");


                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine(". ");
                        Thread.Sleep(500);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Choosing your random activity");

                    for (int i = 0; i < 9; i++)
                    {
                        Console.WriteLine(". ");
                        Thread.Sleep(500);
                    }

                    Console.WriteLine();

                    Random rng = new Random();
                    int randomNumber = rng.Next(activities.Count);
                    var randomActivity = activities[randomNumber];

                    if (userAge > 21 && randomActivity == "Wine Tasting")
                    {
                        Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                        Console.WriteLine("Pick something else!");
                        activities.Remove(randomActivity);
                        randomNumber = rng.Next(activities.Count);
                        randomActivity = activities[randomNumber];

                    }

                    Console.WriteLine($"Ah got it! {randomActivity}, your random activity is: {userName}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                    Console.WriteLine();
                    cont = ( Console.ReadLine().ToLower() == "redo") ? true : false;
                }
               
            }
        }
    }
}