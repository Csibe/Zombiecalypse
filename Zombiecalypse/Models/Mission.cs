using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zombiecalypse.Models
{

    public abstract class Mission
    {
        public int MissionID { get; set; }
        public string MissionName { get; set; }
        public List<MissionTask> MissionTasks { get; set; }
        public int RequiredLevel { get; set; }
        //public int RewardItemID { get; set; }
        //public int RewardItemPieces { get; set; }
        public bool IsNextMission { get; set; }
    }

    public class CharacterMission {
        public int CharacterMissionID { get; set; }
        public int MissionID { get; set; }
        public int CharacterID { get; set; }
        public List<CharacterMissionTask> CharacterMissionTasks { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class StoryMission : Mission
    {
    }

    public class SideMission : Mission
    {
    }
    public class DailyMission : Mission {
    }

    public class MissionTask
    {
        public int MissionTaskID { get; set; }
        public int MissionID { get; set; }
        public int ItemID { get; set; }
        public int ItemPieces { get; set; }
        public string TaskText { get; set; }
    }

    public class CollectMissionTask : MissionTask
    {

    }

    public class HarvestMissionTask : MissionTask
    {

    }

    public class RepairMissionTask : MissionTask
    {

    }

    public class KillingMissionTask : MissionTask
    {

    }

    public class CharacterMissionTask {

        public int CharacterMissionTaskID { get; set; }
        public int CharacterID { get; set; }
        public int MissionTaskID { get; set; }
        public int CharacterMissionID { get; set; }
        public int TaskProgress { get; set; }
        public bool IsCompleted { get; set; }
    }

    //public class Mission
    //{
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int MissionID { get; set; }
    //    public string MissonName { get; set; }
    //    public int CharacterID { get; set; }
    //    public int MissionTaskID { get; set; }
    //    public int MissionTaskProgress { get; set; }
    //    public int MissionTaskNumber { get; set; }
    //    public int MissionRewardID { get; set; }
    //    public int MissionRewardNumber { get; set; }
    //    public int MissionRewardXP { get; set; }
    //    public string MissionType { get; set; }
    //}

    public class MissionVM : ViewModelBase
    {
        public List<Mission> Missions { get; set; }
        public List<Item> Items { get; set; }
        public List<CharacterMission> InProgressMissions { get; set; }
        public List<Zombie> Zombies { get; set; }


        //public List<CollectableStoryMission> CollectableStoryMissions { get; set; }
        //public List<HarvestStoryMission> HarvestStoryMissions { get; set; }
        //public List<RepairStoryMission> RepairStoryMissions { get; set; }
        //public List<CollectableRepetableMission> CollectableRepetableMissions { get; set; }
        //public List<HarvestRepetableMission> HarvestRepetableMissions { get; set; }
        //public List<RepairRepetableMission> RepairRepetableMissions { get; set; }


        //public int MissionID { get; set; }
        //public string MissonName { get; set; }

        //public int MissionTaskID { get; set; }
        //public int MissionTaskProgress { get; set; }
        //public int MissionTaskNumber { get; set; }
        //public int MissionRewardID { get; set; }
        //public int MissionRewardNumber { get; set; }
        //public bool MissionFinishable { get; set; }
        //public Material CollectionMissionTask { get; set; }
        //public Plant GatheringMissionTask { get; set; }
        //public int MissionRewardXP { get; set; }
        //public string MissionType { get; set; }

        //public Character Character { get; set; }
        //public virtual ICollection<MissionVM> Missions { get; set; }
        //public BuildingMaterial CollectionMissionReward { get; set; }
        //public BuildingMaterial GatheringMissionReward { get; set; }
    }
}