using System;
namespace Hello_World
{
    public class RewardViewModel
    {
        private int cost;
        private string name;
        private string descriptionOfItem;
        private bool purchased = false;
        private string imageName = "Starbucks.png";

        public RewardViewModel(int cost, string name, string description, string imageName)
        {
            this.cost = cost;
            this.name = name;
            this.descriptionOfItem = description;
            this.purchased = false;
            this.imageName = imageName;

        }
        public int getCost()
        {
            return this.cost;
        }
        public string getName()
        {
            return this.name;
        }
        public string getRewardDescription()
        {
            return this.descriptionOfItem;
        }
        public bool isPurchased()
        {
            return this.purchased;
        }
        public string getImageName()
        {
            return imageName;
        }
    }
}

