# RhythmsGonnaGetYou

ERD

Lucidchart - https://lucid.app/lucidchart/invitations/accept/inv_2ab226ad-fdb8-4b80-8a90-0922a362c9ec?viewport_loc=-31%2C-112%2C1579%2C911%2C0_0

SQL queries:

Add a new band

INSERT INTO "Bands" ("Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Style", "IsSigned", "ContactName", "ContactPhoneNumber")
VALUES ('Elton John', 'United States', 1, 'eltonjohn.com', 'Rock', Yes, 'Ricky Martin', 800-321-9000);

View all the bands

SELECT \*
FROM "Bands";

Add an album for a band

INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "NameId", "SongTitleId") VALUES ("Rocket Man", No, 1980, 1, NULL);

Add a song to an album

INSERT INTO "Songs" ("TrackNumber", "Title", "Duration") VALUES (4, "Yellow Brick Road", 04:53);

Let a band go (update isSigned to false)

UPDATE "Bands" SET "IsSigned" = 'False' WHERE "Name" = 'Elton John';

Re-sign a band (update isSigned to true)

UPDATE TO "Bands"
UPDATE "Bands" SET "IsSigned" = 'True' WHERE "Name" = 'Elton John';

Given a band name, view all their albums

SELECT \*
FROM "Albums"
JOIN "Bands" ON "Albums"."BandId" = "Bands"."Id"
WHERE "Bands"."Name" = 'Kendrick Lamar';

SELECT \*
FROM "Albums"
JOIN "Bands" ON "Albums"."BandId" = "Bands"."Id"
JOIN "Songs" ON "Songs"."AlbumId" = "Albums"."Id"
WHERE "Bands"."Name" = 'ABBA';

View all albums (and their associated songs) ordered by ReleaseDate

SELECT \*
FROM "Albums"
JOIN "Songs" ON "AlbumId"="Albums"."Id"
ORDER BY "ReleaseDate";

View all bands that are signed

SELECT \*
FROM "Bands"
WHERE "Bands"."IsSigned" = True;

View all bands that are not signed

SELECT \*
FROM "Bands"
WHERE "Bands"."IsSigned" = False;

PARKING LOT
Figure out loop through menu so doesn't have to be restarted over and over
Input validation on menu entries

Question: Review how to create the multiple criteria queries in SQL on the joined query.
Review: Clarity on the assignment, when we add, we need to build an entire query that prompts to search for item before adding (band, album, song). Then if no match, add? So are the inputs a multi-step process:

1. Search for item to add
2. If match, terminate add
3. If no match, collect the data in prompts needed for the table
4. If a field is blank for adding, just accept the user input, assign NULL and add to table

Please review the adding of the foreign keys to the classes in VSC

- Why is Roles a list for the join, but Actors and Rating are the db?
- SQL to C# conversion
- Unable to load BandId FK on Albums table

\*\*\*Same process for Band, Album and Song, just different tables to write to

Add Band

1. Search bands for band name input by user
2. If a match, display message indicating Band already exists and cancel request
3. If not a match, display message indicating Band doesn't exist and prompt for inputs from user to add Band
4. Add Band to db (context.Bands.Add(newBand);
5. Save changes - (context.SaveChanges();)

Add Album

1. Search albums for album title input by user
2. If a match, display message indicating album already exists and cancel request
3. If not a match, display message indicating Album doesn't exist and prompt for inputs from user to add Band and Album

Prompt for new band entires
Add Band to db
Save changes
Search for newly added band and obtain PK
Prompt for new album entries
auto add PK as FK into query submission
Add Album to db
Save changes
