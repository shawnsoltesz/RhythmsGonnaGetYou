using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
            Console.WriteLine("( 7.) View all albums by a band");
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

        static DateTime PromptForDateTime(string prompt)
        {
            Console.Write(prompt);
            DateTime userInput;
            var isThisGoodInput = DateTime.TryParse(Console.ReadLine(), out userInput);

            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, that was not valid. I'm going to use a default date as your date.");
                return default(DateTime);
            }
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
                        Console.WriteLine($"Name of the band: {searchBands} ");
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

                        //Add Band to db
                        //Save changes 

                        context.Bands.Add(newBand);
                        context.SaveChanges();
                        Console.WriteLine($"Your entry of {bandName} has been saved.");
                    }
                }


                //Add album
                if (menuOption == "2")

                {
                    //Search for Album

                    Console.WriteLine("What is the name of the album you would like to add?");
                    var searchAlbums = PromptForString("> : ");


                    var existingAlbum = context.Albums.FirstOrDefault(Albums => Albums.Title == searchAlbums);

                    // If we found an existing album.

                    if (existingAlbum != null)
                    {
                        Console.WriteLine($"{searchAlbums} already exists in our records as an Album.\nPlease double check.");
                    }

                    else

                    {
                        //Check for the Band

                        var searchBands = PromptForString("What is the name of the band for this album?");

                        var existingBand = context.Bands.FirstOrDefault(Bands => Bands.Name == searchBands);

                        // If we found an existing band.

                        if (existingBand == null)

                        {
                            Console.WriteLine($"\n\n{searchBands} does not exist in our records. Please add band first.");
                        }

                        else

                        {  //Add the Album
                            Console.WriteLine($"Name of the Band: {searchBands}\n");

                            Console.WriteLine($"Album: {searchAlbums}\n");
                            var albumTitle = searchAlbums;

                            var isExplicit = getBoolInputValue("Rated Explicit - [Answer = Yes/No]: \n");

                            var releaseDate = PromptForDateTime("Album Release Date: \n");

                            var newAlbum = new Album
                            {
                                Title = albumTitle,
                                IsExplicit = isExplicit,
                                ReleaseDate = releaseDate
                            };

                            //Add and save the album to the db
                            context.Albums.Add(newAlbum);
                            context.SaveChanges();
                            Console.WriteLine($"\n\nYour entry of {albumTitle} has been saved.");

                        }
                    }
                }

                //Add song
                if (menuOption == "3")

                {
                    //Search song titles input by user
                    Console.WriteLine("What is the name of the song you would like to add?");
                    var searchSong = PromptForString("> : ");


                    var existingSong = context.Songs.FirstOrDefault(Songs => Songs.Title == searchSong);

                    // If we found an existing album.

                    if (existingSong != null)
                    {
                        Console.WriteLine($"The song {existingSong} already exists in our records.\nPlease double check.");
                    }
                    else
                    {
                        //Search for Album

                        Console.WriteLine("What is the name of the album that contains this song?");
                        var searchAlbums = PromptForString("> : ");


                        var existingAlbum = context.Albums.FirstOrDefault(Albums => Albums.Title == searchAlbums);

                        // If we found an existing album.
                        if (existingAlbum == null)

                            Console.WriteLine($"\n\n{searchAlbums} does not exist in our records. Please add Album first.");

                        else

                        {
                            //User enters song information

                            Console.WriteLine($"Album: {searchAlbums}\n");

                            Console.WriteLine($"Song Title: {searchSong}\n");

                            Console.WriteLine("Track Number: \n");
                            var songTrackNumber = int.Parse(Console.ReadLine());

                            var songDuration = PromptForString("Song duration - [00:00:00]\n");

                            var newSong = new Song
                            {
                                TrackNumber = songTrackNumber,
                                Title = searchSong,
                                Duration = songDuration,
                            };

                            //Add and save the album to the db
                            context.Songs.Add(newSong);
                            context.SaveChanges();

                            Console.WriteLine($"Your entry of {searchSong} has been saved.\n");
                        }
                    }
                }

                //Un-sign a band
                if (menuOption == "4")

                {
                    var searchBands = PromptForString("What is the name of the band you would like to un-sign?\n");

                    var existingBand = context.Bands.FirstOrDefault(Bands => Bands.Name == searchBands);

                    // If we did not find an existing band.

                    if (existingBand == null)
                    {
                        Console.WriteLine($"\n\n{searchBands} does not exist in our records as a Band.\nPlease double check.\n");
                    }

                    else

                    //If a match, update isSigned to False

                    {
                        existingBand.IsSigned = false;
                        context.SaveChanges();

                        Console.WriteLine($"\n\n{searchBands} has been updated to 'Un-signed'.\n");

                    }
                }

                //Re-sign a band
                if (menuOption == "5")
                {
                    var searchBands = PromptForString("What is the name of the band you would like to re-sign?\n");

                    var existingBand = context.Bands.FirstOrDefault(Bands => Bands.Name == searchBands);

                    // If we did not find an existing band.

                    if (existingBand == null)
                    {
                        Console.WriteLine($"\n\n{searchBands} does not exist in our records as a Band.\nPlease double check.\n");
                    }

                    else

                    //If a match, update isSigned to True

                    {
                        existingBand.IsSigned = true;

                        context.SaveChanges();

                        Console.WriteLine($"\n\n{searchBands} has been updated to 'Re-signed'.\n");
                    }
                }


                //View all bands
                if (menuOption == "6")
                {
                    foreach (var band in context.Bands)
                    {
                        Console.WriteLine($"There is a band named {band.Name} in our records.\n");
                    }
                }


                //View all albums by a band
                if (menuOption == "7")
                {

                    var bandQuery = PromptForString("Which band's albums would you like to view?\n");

                    var albumsFromBand = context.Bands.FirstOrDefault(band => band.Name == bandQuery);
                    var albumName = context.Albums.Include(album => album.Band).Where(album => album.Band == albumsFromBand);

                    foreach (var album in context.Albums)
                    {
                        Console.WriteLine($"There is an album titled {album.Title} in our records for {band.Name}.\n");

                    }

                }

                //View all albums by ReleaseDate
                if (menuOption == "8")
                {

                    var albumsByReleaseDate = context.Albums.OrderBy(Album => Album.ReleaseDate);

                    foreach (var album in albumsByReleaseDate)
                    {
                        Console.WriteLine($"{album.Title} was released on {album.ReleaseDate.ToString("MM/dd/yyyy")}");
                    }

                }
                else

                //View all signed bands
                if (menuOption == "9")
                {

                    var signedBands = context.Bands.Where(Band => Band.IsSigned == true);

                    foreach (var band in signedBands)
                    {
                        Console.WriteLine($"{band.Name} is a signed band");
                    }

                }
                else

                //View all non-signed bands
                if (menuOption == "10")
                {

                    var nonsignedBands = context.Bands.Where(Band => Band.IsSigned == false);

                    foreach (var band in nonsignedBands)
                    {
                        Console.WriteLine($"{band.Name} is an unsigned band");
                    }

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















