using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Button = Xamarin.Forms.Button;

namespace Hello_World
{
    public delegate void Notify();  // delegate

    public partial class MainPage : ContentPage
    {
        //Load some kind of score from a server
        private int score = 0;

        private List<RewardViewModel> rewards = new List<RewardViewModel>();

        public event Notify ProcessCompleted;

        public MainPage()
        {
            InitializeComponent();

            RewardViewModel reward = new RewardViewModel(10, "Starbucks", "Buy this gift card", "Starbucks.png");
            RewardViewModel reward1 = new RewardViewModel(20, "Dunkin", "Buy this gift card", "Dunkin");
            RewardViewModel reward2 = new RewardViewModel(20, "Lowes", "Buy this gift card", "Lowes");

            rewards.Add(reward);
            rewards.Add(reward2);
            rewards.Add(reward1);

            foreach (RewardViewModel rewardViewModel in rewards)
            {
                ToDo.Children.Add(CreateRewardBox(rewardViewModel));
            }
        }
        public void Handle_Clicked(object sender, EventArgs args)
        {
            int oldScore = score;
            score += 10;
            Points.Text = "Points: " + score;
        }

        public async void Reward_Clicked(object sender, EventArgs args, String name)
        {
            string result = await DisplayPromptAsync("Confirm Purchase", "Type \"CONFIRM\" to confirm the purchase.");
            if (result == "CONFIRM")
            {
                Messages.Text = "Confirmed purchase of: " + name;
            }
        }

        private StackLayout CreateRewardBox(RewardViewModel reward)
        {
            StackLayout rewardBox = new StackLayout();

            Button label = new Button
            {
                Text = reward.getName() + " " + reward.getRewardDescription(),
                FontSize = 14

            };
            label.Clicked += async (sender, args) => await label.RelRotateTo(360, 1000);
            rewardBox.Children.Add(label);
            label.Clicked += (sender, e) => Reward_Clicked(sender, e, reward.getName());
            Image image = new Image();
            image.Source = reward.getImageName();
            rewardBox.Children.Add(image);


            return rewardBox;
        }
    }
}