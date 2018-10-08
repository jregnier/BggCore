using System;
using System.Collections.Generic;

namespace BggCoreSdk.Model
{
    public class BoardGame
    {
        internal BoardGame()
        {
        }

        public int Id { get; set; }

        public int YearPublished { get; set; }

        public int MinPlayers { get; set; }

        public int MaxPlayers { get; set; }

        public int PlayingTime { get; set; }

        public int MinPlayTime { get; set; }

        public int MaxPlayTime { get; set; }

        public int Age { get; set; }

        public List<BoardGameName> Names { get; set; }

        public string Description { get; set; }

        public Uri Thumbnail { get; set; }

        public Uri Image { get; set; }

        public List<ValueIdentifier> BoardGameSubdomains { get; set; }

        public List<ValueIdentifier> BoardGamePublishers { get; set; }

        public List<ValueIdentifier> BoardGameVersions { get; set; }

        public List<ValueIdentifier> BoardGameCategories { get; set; }

        public List<ValueIdentifier> BoardgameArtists { get; set; }

        public List<ValueIdentifier> BoardGameExpansions { get; set; }

        public List<ValueIdentifier> BoardGameDesigners { get; set; }

        public List<ValueIdentifier> BoardGameFamilies { get; set; }

        public List<ValueIdentifier> BoardGameAccessories { get; set; }

        public List<ValueIdentifier> VideogameBg { get; set; }

        public List<BoardGamePoll> Polls { get; set; }
    }
}