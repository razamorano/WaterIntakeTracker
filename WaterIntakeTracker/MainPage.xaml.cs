using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace WaterIntakeTracker
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        Entry weightLBL;
        Entry workoutLBL;
        Entry bottlesizeLBL;
        Button calculateBTN;
        Button callButton;

        string wateramount;

        public MainPage()
        {
            this.Padding = new Thickness(20, 60, 20, 20);

            StackLayout panel = new StackLayout
            {
                Spacing = 15
            };
            //Your weight
            panel.Children.Add(new Label
            {
                Text = "What is your Body Weight in Kg?",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            });

            panel.Children.Add(weightLBL = new Entry
            {
                Text = "Kg.",
            });

            //Workout a day
            panel.Children.Add(new Label
            {
                Text = "How many minutes you workout a day?",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            });

            panel.Children.Add(workoutLBL = new Entry
            {
                Text = "Workout",
            });

            //Bottle size
            panel.Children.Add(new Label
            {
                Text = "What is you bottle size on mL?",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            });

            panel.Children.Add(bottlesizeLBL = new Entry
            {
                Text = "mL",
            });

            //Calculate button                       
            panel.Children.Add(calculateBTN = new Button
            {
                Text = "Calculate the Water Intake",
                //IsEnabled = false,
            });

            calculateBTN.Clicked += OnCalculate;
            this.Content = panel;
        }

        private void OnCalculate(object sender, EventArgs e)
        {
            int enterWeight = Int32.Parse(weightLBL.Text);
            int enterWorkout = Int32.Parse(workoutLBL.Text);
            int enterBottlesize = Int32.Parse(bottlesizeLBL.Text);

        }
    }
}
