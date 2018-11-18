using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zombiecalypse.Models
{

    public class Mission
    {
        public int MissionID { get; set; }
        public string MissonName { get; set; }
        public string CharacterID { get; set; }
        public int MissionTaskID { get; set; }
        public int MissionTaskNumber { get; set; }
        public int MissionRewardID { get; set; }
        public int MissionRewardNumber { get; set; }
    }


    public class MissionVM : ViewModelBase
    {
        public int MissionID { get; set; }
        public string MissonName { get; set; }
        public Material MissionTask { get; set; }
        public int MissionTaskNumber { get; set; }
        public BuildingMaterial MissionReward { get; set; }
        public int MissionRewardNumber { get; set; }
    }
}