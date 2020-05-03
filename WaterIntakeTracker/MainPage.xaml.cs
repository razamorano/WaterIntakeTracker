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
        Button clearBTN;
        Entry waterltLBL;
        Entry waterbottleLBL;

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
                Text = "0",
            });

            //Bottle size
            panel.Children.Add(new Label
            {
                Text = "What is your bottle size on ml?",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            });

            panel.Children.Add(bottlesizeLBL = new Entry
            {
                Text = "0",
            });

            //Calculate button                       
            panel.Children.Add(calculateBTN = new Button
            {
                Text = "Calculate the Water Intake",
                //IsEnabled = false,
            });

            panel.Children.Add(waterltLBL = new Entry
            {
                Text = "",
            });

            panel.Children.Add(waterbottleLBL = new Entry
            {
                Text = "",
            });

            //Clear button                     
            panel.Children.Add(clearBTN = new Button
            {
                Text = "Clear entries",
            });

            calculateBTN.Clicked += OnCalculate;
            clearBTN.Clicked += OnClear;

            this.Content = panel;
        }

        private void OnCalculate(object sender, System.EventArgs e)
        {
            //convert string variables on integers
            float enterWeight = float.Parse(weightLBL.Text);
            int enterWorkout = Int32.Parse(workoutLBL.Text);
            int enterBottlesize = Int32.Parse(bottlesizeLBL.Text);
            //to calculate the water intake I have use as a reference a formula that it take the mass on pounds and multipli by 2/3
            //then it will give you the intake on ounces, after this we have to add the workout consume of water and lastly device to 33.814 to pass from
            //ounce to liters
            float waterinLt = (((enterWeight * 2.20462f) * 0.6666666f) + (enterWorkout * 0.4f)) / 33.814f;
            // just print out with 2 decimals
            waterltLBL.Text = waterinLt.ToString("0.00") + " Liters of Water you should intake a day";
            // now calculate how many bottle
            waterbottleLBL.Text = ((waterinLt * 1000) / enterBottlesize).ToString("0.0") + " Bottles of Water you should take a day";
        }
        private void OnClear(object sender, System.EventArgs e)
        {
            weightLBL.Text = "Kg.";
            workoutLBL.Text = "0";
            bottlesizeLBL.Text = "0";
            waterltLBL.Text = "";
            waterbottleLBL.Text = "";
        }
    }
}
