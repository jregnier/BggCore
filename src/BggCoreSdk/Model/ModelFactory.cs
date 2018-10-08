using System;
using System.Linq;
using BggCoreSdk.Dto;

namespace BggCoreSdk.Model
{
    /// <inheritdoc />
    internal class ModelFactory : IModelFactory
    {
        /// <inheritdoc />
        public BoardGameSearch CreateBoardGameSearch(BoardGameDto dtoObject)
        {
            if (dtoObject == null)
            {
                return null;
            }

            int.TryParse(dtoObject.Id, out var identifier);
            int.TryParse(dtoObject.YearPublished, out var yearPublished);

            return new BoardGameSearch()
            {
                Id = identifier,
                Name = new BoardGameName() 
                { 
                    Value = dtoObject.Names.FirstOrDefault()?.Value,
                    IsPrimary = dtoObject.Names.FirstOrDefault()?.IsPrimary == bool.TrueString
                },
                YearPublished = yearPublished
            };
        }

                /// <inheritdoc />
        public BoardGame CreateBoardGame(BoardGameDto dtoObject)
        {
            if (dtoObject == null)
            {
                return null;
            }

            return new BoardGame()
            {
                Id = ToInt(dtoObject.Id),
                YearPublished = ToInt(dtoObject.YearPublished),
                MinPlayers = ToInt(dtoObject.MinPlayers),
                MaxPlayers = ToInt(dtoObject.MaxPlayers),
                PlayingTime = ToInt(dtoObject.PlayingTime),
                MinPlayTime = ToInt(dtoObject.MinPlayTime),
                MaxPlayTime = ToInt(dtoObject.MaxPlayTime),
                Age = ToInt(dtoObject.Age),
                Names = dtoObject.Names?.Select(x => new BoardGameName()
                {
                    Value = x.Value,
                    IsPrimary = x.IsPrimary == bool.TrueString,
                    SortIndex = ToInt(x.SortIndex)
                }).ToList(),
                Description = dtoObject.Description,
                Thumbnail = ToUri(dtoObject.Thumbnail),
                Image = ToUri(dtoObject.Image),
                BoardGameSubdomains = dtoObject.BoardGameSubdomains?.Select(x => new ValueIdentifier()
                {
                    Id = ToInt(x.Id),
                    Value = x.Value
                }).ToList(),
                BoardGamePublishers = dtoObject.BoardGamePublishers?.Select(x => new ValueIdentifier()
                {
                    Id = ToInt(x.Id),
                    Value = x.Value
                }).ToList(),
                BoardGameVersions = dtoObject.BoardGameVersions?.Select(x => new ValueIdentifier()
                {
                    Id = ToInt(x.Id),
                    Value = x.Value
                }).ToList(),
                BoardGameCategories = dtoObject.BoardGameCategories?.Select(x => new ValueIdentifier()
                {
                    Id = ToInt(x.Id),
                    Value = x.Value
                }).ToList(),
                BoardgameArtists = dtoObject.BoardgameArtists?.Select(x => new ValueIdentifier()
                {
                    Id = ToInt(x.Id),
                    Value = x.Value
                }).ToList(),
                BoardGameExpansions = dtoObject.BoardGameExpansions?.Select(x => new ValueIdentifier()
                {
                    Id = ToInt(x.Id),
                    Value = x.Value
                }).ToList(),
                BoardGameDesigners = dtoObject.BoardGameDesigners?.Select(x => new ValueIdentifier()
                {
                    Id = ToInt(x.Id),
                    Value = x.Value
                }).ToList(),
                BoardGameFamilies = dtoObject.BoardGameFamilies?.Select(x => new ValueIdentifier()
                {
                    Id = ToInt(x.Id),
                    Value = x.Value
                }).ToList(),
                BoardGameAccessories = dtoObject.BoardGameAccessories?.Select(x => new ValueIdentifier()
                {
                    Id = ToInt(x.Id),
                    Value = x.Value
                }).ToList(),
                VideogameBg = dtoObject.VideogameBg?.Select(x => new ValueIdentifier()
                {
                    Id = ToInt(x.Id),
                    Value = x.Value
                }).ToList(),
                Polls = dtoObject.Polls?.Select(x => new BoardGamePoll()
                {
                    Name = x.Name,
                    Title = x.Title,
                    TotalVotes = ToInt(x.TotalVotes),
                    Results = x.Results?.Select(r => new BoardGamePollResult()
                    {
                        Value = r.Value,
                        NumVotes = ToInt(r.NumVotes)
                    }).ToList()
                }).ToList()
            };
        }

        private int ToInt(string value)
        {
            if (int.TryParse(value, out int v))
            {
                return v;
            }

            return 0;
        }

        private Uri ToUri(string value)
        {
            if (Uri.TryCreate(value, UriKind.Absolute, out Uri v))
            {
                return v;
            }

            return null;
        }
    }
}