using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zombiecalypse.Models
{

    public class Mission
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MissionID { get; set; }
        public string MissonName { get; set; }
        public int CharacterID { get; set; }
        public int MissionTaskID { get; set; }
        public int MissionTaskProgress { get; set; }
        public int MissionTaskNumber { get; set; }
        public int MissionRewardID { get; set; }
        public int MissionRewardNumber { get; set; }
        public int MissionRewardXP { get; set; }
        public string MissionType { get; set; }
    }

    public class MissionVM : ViewModelBase
    {

        public int MissionID { get; set; }
        public string MissonName { get; set; }
       
        public int MissionTaskID { get; set; }
        public int MissionTaskProgress { get; set; }
        public int MissionTaskNumber { get; set; }
        public int MissionRewardID { get; set; }
        public int MissionRewardNumber { get; set; }
        public bool MissionFinishable { get; set; }
        public Material CollectionMissionTask { get; set; }
        public Plant GatheringMissionTask { get; set; }
        public int MissionRewardXP { get; set; }
        public string MissionType { get; set; }

        public Character Character { get; set; }
        public virtual ICollection<MissionVM> Missions { get; set; }
        public BuildingMaterial CollectionMissionReward { get; set; }
        public BuildingMaterial GatheringMissionReward { get; set; }
    }
}