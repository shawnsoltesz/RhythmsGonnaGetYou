# RhythmsGonnaGetYou

ERD

Lucidchart - https://lucid.app/lucidchart/invitations/accept/inv_2ab226ad-fdb8-4b80-8a90-0922a362c9ec?viewport_loc=-31%2C-112%2C1579%2C911%2C0_0

SQL queries:

Add a new band

INSERT INTO "Band" ("Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Style", "IsSigned", "Contact Name", "ContactPhoneNumber")
VALUES ('Elton John', 'United States', 1, "eltonjohn.com", "Rock", Yes, "Ricky Martin", 800-321-9000);

View all the bands

SELECT \*
From "Bands";

Add an album for a band

INSERT INTO "Album" ("Title", "IsExplicit", "ReleaseDate", "NameId", "SongTitleId") VALUES ("Rocket Man", No, 1980, 1, NULL);

**How do we get and assign FK while adding data? Do we search for it first and add to our query? What if an Album doesn't have a song assigned yet. Populate with NULL?**

Add a song to an album
Let a band go (update isSigned to false)
Resign a band (update isSigned to true)
Given a band name, view all their albums
View all albums (and their associated songs) ordered by ReleaseDate
View all bands that are signed
View all bands that are not signed
