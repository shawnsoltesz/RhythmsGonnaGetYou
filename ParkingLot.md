//PARKING LOT FOR NEW APPROACH
/\*
Option 2
{
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

        var albumPK = context.Bands.FirstOrDefault(BandsId => BandsId.Name = BandsId);}

        Option 3
    {
        else

            /*
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
                context.SaveChanges();*/
