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
            //context.Bands
            //context.Albums
            //context.Songs

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
                {
                    //Search bands for band name input by user
                    var searchBands = PromptForString("What is the name of the band you would like to add?");

                    var existingBand = context.Bands.FirstOrDefault(Bands => Bands.Name == searchBands);

                    // If we found an existing band.

                    if (existingBand != null)
                    {
                        Console.WriteLine($"{searchBands} already exists in our records as a Band.\nPlease double check.");
                    }

                    else

                    //If not a match, prompt for inputs from user to add Band

                    {
                        Console.WriteLine("Name of the band: ");
                        Console.WriteLine($"{searchBands}");
                        var bandName = searchBands;

                        var countryOfOrigin = PromptForString("\nCountry of origin of the band: \n");

                        Console.WriteLine("Number of members in band:");
                        var numberOfMembers = int.Parse(Console.ReadLine());

                        var website = PromptForString("Band website: \n");

                        var style = PromptForString("Genre of music: \n");

                        Console.WriteLine("Is the band signed with BeatBox Studio - [Answer = Yes/No]: ");
                        var isSigned = getBoolInputValue(Console.ReadLine());

                        var contactName = PromptForString("Contact name: \n");

                        var contactPhoneNumber = PromptForString("Contact phone: \n");

                        var newBand = new Band
                        {
                            Name = bandName,
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
                        Console.WriteLine($"Your entry of {bandName} has been saved.");
                    }
                }

                //Add album
                if (menuOption == "2")
                {
                    //Search albums titles input by user
                    Console.WriteLine("What is the name of the album you would like to add?");
                    var searchAlbums = PromptForString("> : ");


                    var existingAlbum = context.Albums.FirstOrDefault(Albums => Albums.Title == searchAlbums);

                    // If we found an existing album.

                    if (existingAlbum != null)
                    {
                        Console.WriteLine($"{searchAlbums} already exists in our records as an Album.\nPlease double check.");
                    }

                    else

                    //If not a match, prompt for inputs from user to add Band first

                    {

                        var bandName = PromptForString("Name of the band: ");

                        var countryOfOrigin = PromptForString("Country of origin of the band:  ");

                        Console.WriteLine("Number of members in band: ");
                        var numberOfMembers = int.Parse(Console.ReadLine());

                        var website = PromptForString("Band website:  ");

                        var style = PromptForString("Genre of music: ");

                        Console.WriteLine("Is the band signed with BeatBox Studio - [Answer = Yes/No]: ");
                        var isSigned = getBoolInputValue(Console.ReadLine());

                        var contactName = PromptForString("Contact name: ");

                        var contactPhoneNumber = PromptForString("Contact phone: ");

                        var newBand = new Band
                        {
                            Name = bandName,
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

                        // Band added, now to add Album with BandID to link the two together

                        //obtain the newly added band Primary Key to pass as the foreign key

                        int albumPK = context.Bands.FirstOrDefault(BandsId => BandsId = bandName;

                        //Add the Album
                        var albumTitle = PromptForString("Title of the Album: "); ;

                        Console.WriteLine("Rated Explicit - [Answer = Yes/No]: ");
                        var isExplicit = getBoolInputValue(Console.ReadLine());

                        Console.WriteLine("Album Release Date:");
                        var releaseDate = Console.ReadLine(DateTime.ToString);

                        //not entered by user: var BandId = albumPK;

                        var newAlbum = new Album
                        {
                            Title = albumTitle,
                            IsExplicit = isExplicit,
                            ReleaseDate = releaseDate,
                            BandId = albumPK,

                        };

                        //Add and save the album to the db
                        context.Albums.Add(newAlbum);
                        context.SaveChanges();
                        Console.WriteLine($"Your entry of {albumTitle} has been saved.");
                    }
                }

                //Add song
                if (menuOption == "3")

                    //Search albums titles input by user
                    Console.WriteLine("What is the name of the song you would like to add?");
                var searchSong = PromptForString("> : ");


                var existingSong = context.Songs.FirstOrDefault(Songs => Songs.Title == searchSong);

                // If we found an existing album.

                if (existingSong != null)
                {
                    Console.WriteLine($"{searchSong} already exists in our records as an Album.\nPlease double check.");
                }

                else

                //If not a match, prompt for inputs from user to add Band first

                {
                    var bandName = PromptForString("Name of the band: ");

                    var countryOfOrigin = PromptForString("Country of origin of the band:  ");

                    Console.WriteLine("Number of members in band: ");
                    var numberOfMembers = int.Parse(Console.ReadLine());

                    var website = PromptForString("Band website:  ");

                    var style = PromptForString("Genre of music: ");

                    Console.WriteLine("Is the band signed with BeatBox Studio - [Answer = Yes/No]: ");
                    var isSigned = getBoolInputValue(Console.ReadLine());

                    var contactName = PromptForString("Contact name: ");

                    var contactPhoneNumber = PromptForString("Contact phone: ");


                    var newBand = new Band
                    {
                        Name = bandName,
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

                    // Band added, now to add Album with BandID to link the two together

                    //obtain the newly added band Primary Key to pass as the foreign key

                    int albumPK = context.Bands.FirstOrDefault(BandsId => BandsId = bandName;
                    //User enters album information

                    var albumTitle = PromptForString("Title of the Album: ");

                    Console.WriteLine("Rated Explicit - [Answer = Yes/No]: ");
                    var isExplicit = getBoolInputValue(Console.ReadLine());

                    Console.WriteLine("Album Release Date:");
                    var releaseDate = DateTime.Console.ReadLine();

                    //not entered by user: var BandId = albumPK;

                    var newAlbum = new Album
                    {
                        Title = albumTitle,
                        IsExplicit = isExplicit,
                        ReleaseDate = releaseDate,
                        BandId = albumPK,

                    };

                    //Add and save the album to the db
                    context.Albums.Add(newAlbum);
                    context.SaveChanges();

                    //User enters song information
                    Console.WriteLine("Track Number: ");
                    var songTrackNumber = int.Parse(Console.ReadLine());

                    var songTitle = PromptForString("Title of the song: ");

                    Console.WriteLine("Album Release Date:");
                    var songDuration = PromptForString("Song duration - [00:00:00]");

                    //not entered by user: var BandId = albumPK;

                    var newSong = new Song
                    {

                        TrackNumber = songTrackNumber,
                        Title = songTitle,
                        Duration = songDuration,

                    };

                    //Add and save the album to the db
                    context.Albums.Add(newAlbum);
                    context.SaveChanges();

                    Console.WriteLine($"Your entry of {albumTitle} has been saved.");
                }
            }

            //Un-sign a band
            if (menuOption == "4")

            {
                var searchBands = PromptForString("What is the name of the band you would like to un-sign?");

                var existingBand = context.Bands.FirstOrDefault(Bands => Bands.Name == searchBands);

                // If we did not find an existing band.

                if (existingBand == null)
                {
                    Console.WriteLine($"{searchBands} does not exist in our records as a Band.\nPlease double check.");
                }

                else

                //If not a match, prompt for inputs from user to add Band

                {
                    searchBands.Bands.isSigned = false;
                    context.SaveChanges();

                    Console.WriteLine($"{searchBands} has been updated to 'Un-signed'.");

                }


                //Re-sign a band
                if (menuOption == "5")
                {

                    Console.WriteLine("Option 5");

                }


                //View all bands
                if (menuOption == "6")
                {

                    Console.WriteLine("Option 6");

                }
                else

                //View all albums
                if (menuOption == "7")
                {

                    Console.WriteLine("Option 7");

                }
                else

                //View all albums by ReleaseDate
                if (menuOption == "8")
                {

                    Console.WriteLine("Option 8");

                }
                else

                //View all signed bands
                if (menuOption == "9")
                {

                    Console.WriteLine("Option 9");

                }
                else

                //View all non-signed bands
                if (menuOption == "10")
                {

                    Console.WriteLine("Option 10");

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
                    Console.WriteLine("\nPlease input the number from the menu.\n");
                }
            }
        }
    }
}





