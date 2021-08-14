using System;

namespace RhythmsGonnaGetYou
{

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

        static void Main(string[] args)

        {
            var keepGoing = true;

            //var transactions = new List<Transaction>()

            while (keepGoing)
            {
                DisplayGreeting();

                var menuOption = PromptForString("> : ");

                //( 1.) Add band
                if (menuOption == "1")
                {

                }
                else

                //( 2.) Add album
                if (menuOption == "2")
                {
                }
                else

                //( 3.) Add song
                if (menuOption == "3")
                {


                }
                else

                //( 4.) Un-sign a band
                if (menuOption == "4")
                {

                }
                else

                //( 5.) Re-sign a band
                if (menuOption == "5")
                {

                }
                else

                //( 6.) View all bands
                if (menuOption == "6")
                {

                }
                else

                //( 7.) View all albums
                if (menuOption == "7")
                {

                }
                else

                //( 8.) View all albums by ReleaseDate
                if (menuOption == "8")
                {

                }
                else

                //(9.) View all signed bands
                if (menuOption == "9")
                {

                }
                else

                //(10.) View all non-signed bands
                if (menuOption == "10")
                {

                }
                else

                //(11.) Quit3
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

