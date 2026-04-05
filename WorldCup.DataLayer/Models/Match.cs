using System.Collections.Generic;

namespace WorldCup.DataLayer.Models
{
    public class Match
    {
        public string Location { get; set; }
        public string Attendance { get; set; }
        public string Home_team_country { get; set; }
        public string Away_team_country { get; set; }       
        public string Datetime {  get; set; }
        public Team Home_team { get; set; } = new Team();
        public Team Away_team { get; set; } = new Team();
        public Statistics Home_team_statistics { get; set; }
        public Statistics Away_team_statistics { get; set; }
        public List<Event> Home_team_events { get; set; }
        public List<Event> Away_team_events { get; set; }

        public override string ToString()
            => $"{Home_team} vs {Away_team}";
    }

}
