using System;

namespace WorldCup.DataLayer.Models
{
    public class Team : IComparable<Team>
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string FIFA_code { get; set; }
        public string Code { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int Games_played { get; set; }
        public int Goals { get; set; }
        public int Goals_for { get; set; }
        public int Goals_against { get; set; }
        public int Goal_differential { get; set; }

        public int CompareTo(Team other)
            => Country.CompareTo(other.Country);        

        public override string ToString()
            => $"{Country} ({FIFA_code ?? Code})";
    }
}
