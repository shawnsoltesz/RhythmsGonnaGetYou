using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace RhythmsGonnaGetYou
{
    class BeatBoxStudioContext : DbContext
    {
        // Define a movies property that is a DbSet.
        public DbSet<Band> Bands { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }

        // Define a method required by EF that will configure our connection
        // to the database.
        //
        // DbContextOptionsBuilder is provided to us. We then tell that object
        // we want to connect to a postgres database named BeatBoxStudio on
        // our local machine.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            optionsBuilder.UseNpgsql("server=localhost;database=BeatBoxStudio");


            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }
    }

    class Band

    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryOfOrigin { get; set; }
        public int NumberOfMembers { get; set; }
        public string Website { get; set; }
        public string Style { get; set; }
        public bool IsSigned { get; set; }
        public string ContactName { get; set; }
        public string ContactPhoneNumber { get; set; }
    }

    class Album

    {

        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsExplicit { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string BandId { get; set; }

    }

    class Song

    {

        public int Id { get; set; }
        public int TrackNumber { get; set; }
        public string Duration { get; set; }
        public string AlbumId { get; set; }

    }

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

        public static bool getBoolInputValue(string inputType)
        {
            bool value;
            bool valid;
            do
            {
                Console.WriteLine("Enter yes or no: ");
                var inputString = Console.ReadLine();

                if (String.IsNullOrEmpty(inputString))

                {
                    continue;
                }

                if (string.Equals(inputString, "yes"))

                {
                    value = true;
                    valid = true;
                }

                else if (string.Equals(inputString, "no"))

                {
                    value = false;
                    valid = false;
                }

            } while (!valid);

            return value;
        }

        static void Main(string[] args)

        {
            var context = new BeatBoxStudioContext();
            //context.Bands;
            //context.Albums;
            //context.Songs;

            var bandCount = context.Bands.Count();
            Console.WriteLine($"There are {bandCount} bands!");

            var albumCount = context.Albums.Count();
            Console.WriteLine($"There are {albumCount} albums!");

            var songCount = context.Songs.Count();
            Console.WriteLine($"There are {songCount} songs!");

            var keepGoing = true;

            //var transactions = new List<Transaction>()

            while (keepGoing)
            {
                DisplayGreeting();

                var menuOption = PromptForString("> : ");

                //Add band
                if (menuOption == "1")

                    //Search bands for band name input by user
                    Console.WriteLine("What is the name of the band you would like to add?");
                var searchBands = PromptForString("> : ");


                var existingBand = context.Bands.FirstOrDefault(Band => Band.Name == searchBands);

                // If we found an existing band.

                if (existingBand != null)
                {
                    Console.WriteLine($"{searchBands} already exists in our records as a Band.\nPlease double check.");
                }

                else

                //If not a match, prompt for inputs from user to add Band

                {

                    Console.Write("Name of the band: ");
                    var name = Console.ReadLine();

                    Console.Write("Country of origin of the band: ");
                    var countryOfOrigin = Console.ReadLine();

                    Console.Write("Number of members in band: ");
                    var numberOfMembers = int.Parse(Console.ReadLine());

                    Console.Write("Band website: ");
                    var website = Console.ReadLine();

                    Console.Write("Band's genre of music): ");
                    var style = Console.ReadLine();

                    Console.Write("Is the band signed with BeatBox Studio: [Answer = True/False] ");
                    var isSigned = getBoolInputValue(Console.ReadLine());

                    Console.Write("Contact name: ");
                    var contactName = Console.ReadLine();

                    Console.Write("Contact phone: ");
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
                }
                else
                {
                    Console.WriteLine("ALERT: Unknown menu option.\nPlease input the number from the menu above.\n");
                }
            }
        }
    }
}



