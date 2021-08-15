using System;

namespace RhythmsGonnaGetYou
{
    class Album

    {

        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsExplicit { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int BandId { get; set; }
        public Band Band { get; set; }

        public Song Song { get; set; }
    }
}



