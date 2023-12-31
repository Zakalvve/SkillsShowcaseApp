﻿using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;
using MVCSkillsShowcaseApp.Models.Games;

namespace MVCSkillsShowcaseApp.Services
{
    public class BoardGameGeekClient : IBoardGameClient
    {
        private readonly string _rootPath = "https://boardgamegeek.com/xmlapi";
        private readonly IApiClient _client;

        public BoardGameGeekClient(IApiClient client)
        {
            _client = client;
        }

        public async Task<BoardGameModel> GetGameByIdAsync(string gameId)
        {
            string url = $"{_rootPath}/boardgame/{gameId}";

            using (HttpResponseMessage response = await _client.Instance.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var buffer = await response.Content.ReadAsByteArrayAsync();

                    var result = DeserializeXmlResponse<BoardGameSearchResult>(buffer).Result;

                    if (result.Id == null || result.Name == null && result.Description == null && result.Image == null)
                    {
                        throw new ArgumentException("The given gameId returned an empty object");
                    }

                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<IEnumerable<BoardGameResultModel>> SearchGamesAsync(string searchTerm)
        {
            string url = $"{_rootPath}/search/?search={searchTerm}";

            using (HttpResponseMessage response = await _client.Instance.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var buffer = await response.Content.ReadAsByteArrayAsync();

                    var results = DeserializeXmlResponse<BoardGameSearchResults>(buffer).Results;

                    return results ?? throw new InvalidEnumArgumentException("The given search term did not return any results");
                } 
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }


        private T DeserializeXmlResponse<T>(byte[] buffer)
        {
            using (var stream = new MemoryStream(buffer))
            {
                var serializer = new XmlSerializer(typeof(T));

                return (T)serializer.Deserialize(stream);
            }
        }
    }
}
