using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WorldCup.DataLayer.Models
{
    public class Statistics
    {
        public string Country { get; set; }
        public string Tactics { get; set; }
        public List<Player> Starting_eleven { get; set; }
        public List<Player> Substitutes { get; set; }

        public Player GetPlayer(string name)
        {
            return
                Starting_eleven.Find(player => player.Name == name) ?? 
                Substitutes.Find(player => player.Name == name);            
        }
        public List<Player> GetPlayers()
        {
            List<Player> list = [];

            for(int i = 0; i < Math.Max(Starting_eleven.Count, Substitutes.Count); i++)
            {
                if (i < Starting_eleven.Count)
                    Starting_eleven[i].Country = this.Country;

                if (i <  Substitutes.Count)
                    Substitutes[i].Country = this.Country;
            }

            list.AddRange(Starting_eleven);
            list.AddRange(Substitutes);

            return list;
        }              
    }
}
