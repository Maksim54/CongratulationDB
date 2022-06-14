using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CongratulationDB.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CongratulationsPage : ContentPage
    {
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            lv.ItemsSource = await App.Database.GetAsyncMessage();
            OnAppearing();
        }
        public CongratulationsPage()
        {
            InitializeComponent();
            lv.Margin = new Thickness(20, 90, 20, 90);
            OnAppearing();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(messageEntry.Text))
            {
                await App.Database.SaveAsyncMessage(new Table.CongratulationsTable
                {
                    CongratulationText = messageEntry.Text
                });

                messageEntry.Text = string.Empty;
            }
        }

        private async void lv_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var message = (Table.CongratulationsTable)e.Item;
            Random rnd = new Random();
            string action = await DisplayActionSheet("Actions", "Cancel", null, "Delete");
            switch (action)
            {
                case "Delete":
                    await App.Database.DeleteAsyncMessage(message);
                    break;
                default:
                    break;
            }
        }
    }
}