using System;
using System.Collections.Generic;
using WorldCup.DataLayer.Models;

namespace WorldCup.DataLayer.Data
{
    public class DataHandler : IDisposable
    {
        public List<Team> Teams;
        public List<Match> Matches;

        public DataHandler() 
        {
            Teams = new List<Team>();
            Matches = new List<Match>();
        }

        public void Dispose()
        {
            Teams.Clear();
            Teams = null;

            Matches.Clear();
            Matches = null;
        }
    }     
}
