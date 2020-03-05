using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Final_Nba_API.Models
{
    public class NbaTeam
    {
        [Display(Name = "Team ID")]
        public int NbaTeamID { get; set; }

        [Display(Name = "Team Name")]
        public string NbaTeamName { get; set; }

        [Display(Name = "Conference")]
        public string NbaTeamConference { get; set; }

        [Display(Name = "Championship Wins")]
        public int ChampionshipWins { get; set; }

        [Display(Name = "Championship Appearances")]
        public int ChampionshipAppearances { get; set; }

    }
}
