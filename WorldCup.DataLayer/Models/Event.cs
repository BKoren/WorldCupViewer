using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WorldCup.DataLayer.Models
{
    public class Event
    {                
        public string Player { get; set; }
        public string Type_of_event { get; set; }

        public override string ToString()
        {
            return
                $"{Player}\n" +
                $"{Type_of_event}\n";
        }
    }
}
