using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Final_Nba_API.Models
{
    public class CurrentPlayer
    {
        [Display(Name = "Current Player ID")]
        public int CurrentPlayerID { get; set; }

        [Display(Name = "Player Name")]
        public string CurrentPlayerName { get; set; }

        [Display(Name = "Player Position")]
        public string CurrentPlayerPosition { get; set; }
        
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime CurrentPlayerDOB { get; set; }

        //foreign key
        public NbaTeam NbaTeam { get; set; }
        public int NbaTeamID { get; set; }
    }
}
