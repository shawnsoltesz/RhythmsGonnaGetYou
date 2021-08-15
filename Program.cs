using System;
using System.Linq;
using System.Collections.Generic;

namespace RhythmsGonnaGetYou
{

    class Program

    {
        static void DisplayGreeting()

        {

            Console.WriteLine("\n\n");
            Console.WriteLine("  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * \n");
            Console.WriteLine("                     Welcome to BeatBOX Studio\n");
            Console.WriteLine("                      Music Collection Manager \n");
            Console.WriteLine("    *-*-*-*-*-*-*-*-*-*-*-*-*- MENU -*-*-*-*-*-*-*-*-*-*-*-*  \n");

            Console.WriteLine("MUSIC ADMINISTRATION\n");
            Console.WriteLine("( 1.) Add band");
            Console.WriteLine("( 2.) Add album");
            Console.WriteLine("( 3.) Add song");
            Console.WriteLine("( 4.) Un-sign a band"); //(update isSigned to false)
            Console.WriteLine("( 5.) Re-sign a band\n"); //(update isSigned to true)

            Console.WriteLine("REPORTS\n");
            Console.WriteLine("( 6.) View all bands");
            Console.WriteLine("( 7.) View all albums");
            Console.WriteLine("( 8.) View all albums by ReleaseDate");
            Console.WriteLine("( 9.) View all signed bands");
            Console.WriteLine("(10.) View all non-signed bands\n");
            Console.WriteLine("(11.) Quit\n");

            Console.WriteLine("Please input the number from the menu and press ENTER.\n");

        }

        static string PromptForString(string prompt)

        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();

            return userInput;

        }

        static int PromptForInteger(string prompt)
        {
            var isThisGoodInput = false;
            do
            {
                var stringInput = PromptForString(prompt);

                int numberInput;
                isThisGoodInput = Int32.TryParse(stringInput, out numberInput);

                if (isThisGoodInput)
                {
                    return numberInput;
                }
                else
                {
                    Console.WriteLine("Sorry, that isn't a valid input - Please try again.");
                }
            } while (!isThisGoodInput);

            // We shouldn't get here, but this makes C# happy
            return 0;
        }

        public static bool getBoolInputValue(string IsSigned)
        {
            var IsSignedToLower = IsSigned.ToLower();

            if (IsSigned.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else if (IsSigned.Equals("n", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            else
            {
                return false;

            }
        }
        static void Main(string[] args)
        {
            var context = new BeatBoxStudioContext();

            //var bandCount = context.Bands.Count();
            //Console.WriteLine($"There are {bandCount} bands!");

            //var albumCount = context.Albums.Count();
            //Console.WriteLine($"There are {albumCount} albums!");

            //var songCount = context.Songs.Count();
            //Console.WriteLine($"There are {songCount} songs!");

            var keepGoing = true;

            while (keepGoing)
            {
                DisplayGreeting();

                var menuOption = PromptForString("> : ");

                //Add band
                if (menuOption == "1")

                    //Search bands for band name input by user
                    Console.WriteLine("What is the name of the band you would like to add?");
                var searchBands = PromptForString("> : ");


                var existingBand = context.Bands.FirstOrDefault(Bands => Bands.Name == searchBands);

                // If we found an existing band.

                if (existingBand != null)
                {
                    Console.WriteLine($"{searchBands} already exists in our records as a Band.\nPlease double check.");
                    break;
                }

                else

                //If not a match, prompt for inputs from user to add Band

                {
                    Console.WriteLine("Name of the band: ");
                    Console.WriteLine($"{searchBands}");
                    var name = searchBands;

                    Console.WriteLine("Country of origin of the band: ");
                    var countryOfOrigin = Console.ReadLine();

                    Console.WriteLine("Number of members in band: ");
                    var numberOfMembers = int.Parse(Console.ReadLine());

                    Console.WriteLine("Band website: ");
                    var website = Console.ReadLine();

                    Console.WriteLine("Band's genre of music: ");
                    var style = Console.ReadLine();

                    Console.WriteLine("Is the band signed with BeatBox Studio - [Answer = Yes/No]: ");
                    var isSigned = getBoolInputValue(Console.ReadLine());

                    Console.WriteLine("Contact name: ");
                    var contactName = Console.ReadLine();

                    Console.WriteLine("Contact phone: ");
                    var contactPhoneNumber = Console.ReadLine();

                    var newBand = new Band
                    {
                        Name = name,
                        CountryOfOrigin = countryOfOrigin,
                        NumberOfMembers = numberOfMembers,
                        Website = website,
                        Style = style,
                        IsSigned = isSigned,
                        ContactName = contactName,
                        ContactPhoneNumber = contactPhoneNumber,
                    };

                    //4. Add Band to db (context.Bands.Add(newBand);
                    //5. Save changes - (context.SaveChanges();)

                    context.Bands.Add(newBand);
                    context.SaveChanges();
                    Console.WriteLine($"Your entry of {name} has been saved.");
                }

                //Add album
                if (menuOption == "2")
                {

                }
                else

                //Add song
                if (menuOption == "3")
                {

                }
                else

                //Un-sign a band
                if (menuOption == "4")
                {

                }
                else

                //Re-sign a band
                if (menuOption == "5")
                {

                }
                else

                //View all bands
                if (menuOption == "6")
                {

                }
                else

                //View all albums
                if (menuOption == "7")
                {

                }
                else

                //View all albums by ReleaseDate
                if (menuOption == "8")
                {

                }
                else

                //View all signed bands
                if (menuOption == "9")
                {

                }
                else

                //View all non-signed bands
                if (menuOption == "10")
                {

                }
                else

                //Quit
                if (menuOption == "11")
                {
                    keepGoing = false;
                    break;
                }
                else
                {
                    Console.WriteLine("ALERT: Unknown menu option.\nPlease input the number from the menu above.\n");
                }
            }
        }
    }
}



