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
        public int RewardXP { get; set; }
        public int RewardICoins { get; set; }
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

    public class AdventureMissionTask : MissionTask
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

    public class MissionVM : ViewModelBase
    {
        public List<Mission> Missions { get; set; }
        public List<Item> Items { get; set; }
        public List<CharacterMission> InProgressMissions { get; set; }
        public List<Zombie> Zombies { get; set; }

    }
}