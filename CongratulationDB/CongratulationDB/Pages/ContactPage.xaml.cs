using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CongratulationDB.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactPage : ContentPage
    {
        public ContactPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text) && !string.IsNullOrWhiteSpace(surnameEntry.Text) && !string.IsNullOrWhiteSpace(phoneEntry.Text) && !string.IsNullOrWhiteSpace(emailEntry.Text))
            {
                await App.Database.SaveAsyncContact(new Table.ContactTable
                {
                    Name = nameEntry.Text,
                    Surname = surnameEntry.Text,
                    Phone = phoneEntry.Text,
                    Email = emailEntry.Text
                });

                nameEntry.Text = surnameEntry.Text = phoneEntry.Text = emailEntry.Text = string.Empty;
            }
        }
    }
}