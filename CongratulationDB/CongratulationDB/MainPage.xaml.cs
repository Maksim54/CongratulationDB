using CongratulationDB.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CongratulationDB
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Task.Run(AnimeteBackground);
        }
        private async void AnimeteBackground()
        {
            Action<double> forward = input => bdGradient.AnchorY = input;
            Action<double> backward = input => bdGradient.AnchorY = input;

            while (true)
            {
                bdGradient.Animate(name: "forward", callback: forward, start: 0, end: 1, length: 5000, easing: Easing.SinIn);
                await Task.Delay(6000);
                bdGradient.Animate(name: "backward", callback: forward, start: 1, end: 0, length: 5000, easing: Easing.SinIn);
                await Task.Delay(6000);
            }

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            ContactPage ContactPage = new ContactPage();
            await Navigation.PushAsync(ContactPage);
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            CongratulatePage CongratulatePage = new CongratulatePage();
            await Navigation.PushAsync(CongratulatePage);
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            CongratulationsPage CongratulationsPage = new CongratulationsPage();
            await Navigation.PushAsync(CongratulationsPage);
        }
    }
}
