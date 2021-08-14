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

**How do we get and assign FK while adding data? Do we search for it first and add to our query? What if an Album doesn't have a song assigned yet. Populate with NULL?**

Add a song to an album

INSERT INTO "Songs" ("TrackNumber", "Title", "Duration") VALUES (4, "Yellow Brick Road", 04:53);

Let a band go (update isSigned to false)

UPDATE "Bands" SET "IsSigned" = 'False' WHERE "Name" = 'Elton John';

Resign a band (update isSigned to true)

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

\*\*\*Same process for Band, Album and Song, just different tables to write to

Add Band

1. Search bands for band name input by user
2. If a match, display message indicating Band already exists and display Band data
3. If not a match, display message indicating Band doesn't exist and prompt for inputs from user to add Band
4. Add Band to db (context.Bands.Add(newBand);
5. Save changes - (context.SaveChanges();)

fail: Microsoft.EntityFrameworkCore.Database.Command[20102]
Failed executing DbCommand (17ms) [Parameters=[@p0='?', @p1='?', @p2='?', @p3='?' (DbType = Boolean), @p4='?', @p5='?' (DbType = Int32), @p6='?', @p7='?'], CommandType='Text', CommandTimeout='30']
INSERT INTO "Bands" ("ContactName", "ContactPhoneNumber", "CountryOfOrigin", "IsSigned", "Name", "NumberOfMembers", "Style", "Website")
VALUES (@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7)
RETURNING "Id";
fail: Microsoft.EntityFrameworkCore.Update[10000]
An exception occurred in the database while saving changes for context type 'RhythmsGonnaGetYou.BeatBoxStudioContext'.
