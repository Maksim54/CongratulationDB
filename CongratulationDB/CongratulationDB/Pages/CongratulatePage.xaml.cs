using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CongratulationDB.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CongratulatePage : ContentPage
    {
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            lv.ItemsSource = await App.Database.GetAsyncContact();
        }
        public CongratulatePage()
        {
            InitializeComponent();
            OnAppearing();
        }

        public async Task SendEmail(string subject, string body, List<string> recipients)
        {
            try
            {
                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    To = recipients,
                };
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException)
            {
                await DisplayAlert("Ошибка", "Электронная почта не поддерживается на этом устройстве!", "OK");
            }
            catch (Exception)
            {
                await DisplayAlert("Ошибка", "Что-то пошло не так!", "OK");
            }
        }

        public async Task SendSms(string messageText, string recipient)
        {
            try
            {
                var message = new SmsMessage(messageText, new[] { recipient });
                await Sms.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException ex)
            {
                await DisplayAlert("Ошибка", "Сообщение не поддерживается на этом устройстве", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", "Что-то пошло не так !", "OK");
            }
        }

        private async void lv_ItemTapped(object sender, ItemTappedEventArgs e)
        { 
            var contact = (Table.ContactTable)e.Item;
            var message = await App.Database.GetAsyncMessage();
            Random rnd = new Random();
            string action = await DisplayActionSheet("Через что отправим сообщение?", "Cancel", null, "Почта", "Сообщение");
            switch (action)
            {
                case "Почта":
                    await SendEmail("Тестик", message[rnd.Next(0, message.Count)].CongratulationText, new List<string>() { contact.Email });
                    break;
                case "Сообщение":
                    await SendSms(message[rnd.Next(0, message.Count)].CongratulationText, contact.Phone);
                    break;
                case "Delete":
                    await App.Database.DeleteAsyncContact(contact);
                    break;
                default:
                    break;
            }
        }
    }
}