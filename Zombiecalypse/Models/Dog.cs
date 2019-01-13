using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zombiecalypse.Models
{
    public class OwnedDog 
    {
        public int OwnedDogID { get; set; }
        public string DogPicture { get; set; }
        public int CharacterID { get; set; }
        public int DogLevel { get; set; }
        public string DogName { get; set; }
        public int DogCurrentLife { get; set; }
        public int DogMaxLife { get; set; }
        public int DogCurrentEnergy { get; set; }
        public int DogMaxEnergy { get; set; }
        public bool IsOnExplore { get; set; }
        public DateTime EndOfExplore { get; set; }

    }

    public class Dog : Item
    {
        public int Cost { get; set; }
    }

    public class SendDogToExplore
    {

        public virtual OwnedDog Dog { get; set; }

    }


    public class DogExploreDrop
    {

        public int DogExploreDropID { get; set; }
        public int DogExploreDroCoinReward { get; set; }
        public int DogExploreDroXPReward { get; set; }
        public ICollection<Inventory> Rewards { get; set; }
        public ICollection<Item> ItemList { get; set; }
    }

}