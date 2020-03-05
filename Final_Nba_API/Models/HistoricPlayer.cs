using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Nba_API.Models
{
    public class HistoricPlayer
    {
        [Display(Name = "Historic Player ID")]
        public int HistoricPlayerID { get; set; }
        [Display(Name = "Player Name")]
        public string HistoricPlayerName { get; set; }
        [Display(Name = "Player Position")]
        public string HistoricPlayerPosition { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime HistoricPlayerDOB { get; set; }

        [Display(Name = "Date Retired")]
        [DataType(DataType.Date)]
        public DateTime PlayerRetired { get; set; }

        //foreign key
        public NbaTeam NbaTeam { get; set; }
        public int NbaTeamID { get; set; }
    }
}
