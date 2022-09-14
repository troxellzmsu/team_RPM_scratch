using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Hello_World
{
    public partial class MainPage : ContentPage
    {
        //Load some kind of score from a server
        private int score = 0;

        private Reward[] rewards;

        public MainPage()
        {
            InitializeComponent();

            Reward reward = new Reward(10, "Starbucks", "Buy this gift card");
            Reward reward1 = new Reward(20, "Dunkin", "Buy this gift card");
            Reward reward2 = new Reward(20, "Home Depot", "Buy this gift card");

            ToDo.Children.Add(CreateRewardBox(reward));
            ToDo.Children.Add(CreateRewardBox(reward1));
            ToDo.Children.Add(CreateRewardBox(reward2));

        }
        public void Handle_Clicked(object sender, EventArgs args)
        {
            int oldScore = score;
            score += 10;
            Points.Text = "Points: " + score;
        }

        public async void Reward_Clicked(object sender, EventArgs args)
        {
            string result = await DisplayPromptAsync("Confirm Purchase", "Type \"CONFIRM\" to confirm the purchase.");
        }

        private StackLayout CreateRewardBox(Reward reward)
        {
            StackLayout rewardBox = new StackLayout();

            Button label = new Button();
            label.Text = reward.getName() + " " + reward.getRewardDescription();
            label.FontSize = 14;
            rewardBox.Children.Add(label);
            label.Clicked += Reward_Clicked;


            return rewardBox;
        }
    }

    class Reward
    {
        private int cost;
        private string name;
        private string descriptionOfItem;
        private bool purchased = false;

        public Reward(int cost, string name, string description)
        {
            this.cost = cost;
            this.name = name;
            this.descriptionOfItem = description;
            this.purchased = false;

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
    }


}

