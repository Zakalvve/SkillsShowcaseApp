using System.Xml.Serialization;

namespace MVCSkillsShowcaseApp.Models.Games
{
    [XmlRoot("boardgames")]
    public class BoardGameSearchResults
    {
        [XmlElement("boardgame")]
        public BoardGameResultModel[] Results { get; set; }
    }

    [XmlRoot("boardgame")]
    public class BoardGameResultModel
    {
        [XmlAttribute("objectid")]
        public string Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("yearpublished")]
        public int YearPublished { get; set; }
    }


    [XmlRoot("boardgames")]
    public class BoardGameSearchResult
    {
        [XmlElement("boardgame")]
        public BoardGameModel Result { get; set; }
    }
    public class BoardGameModel
    {
        [XmlAttribute("objectid")]
        public string Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("yearpublished")]
        public int YearPublished { get; set; }
        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("image")]
        public string Image { get; set; }
    }
}
