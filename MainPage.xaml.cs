using Notification_Sender_Windows.Send_Notification;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Cryptography.Core;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Notification_Sender_Windows
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DateTimeOffset selectedDate;
        TimeSpan selectedTime;
        bool isScheduled = false;


        public MainPage()
        {
            this.InitializeComponent();

            // Set the size of window to be 853x480
            // The grid is set to remain 853x480 so xaml elements stay consistent
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(853, 480));
            ApplicationView.PreferredLaunchViewSize = new Size(853, 480);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }

        private async void SendNotification_Click(object sender, RoutedEventArgs e)
        {
            string title = titleTextBox.Text;
            string body = bodyTextBox.Text;
            var scheduledDateTime = selectedDate.Date + selectedTime;

            if (!isScheduled)
            {
                SendNotification sendNotification = new SendNotification(title, body);
            }
            else if (isScheduled)
            {
                if (scheduledDateTime < DateTime.Now)
                {
                    var dialog = new MessageDialog("Scheduled notification time cannot be before current time.", "Error");
                    await dialog.ShowAsync();
                }
                else
                {
                    SendScheduledNotification sendScheduledNotification = new SendScheduledNotification(title, body, scheduledDateTime);
                }
            }

        }

        private void ScheduleCalendar_SelectedDatesChanged(object sender, CalendarViewSelectedDatesChangedEventArgs e)
        {
            // .Last() requires that something is selected
            if (scheduleCalendar.SelectedDates.Any())
            {
                selectedDate = e.AddedDates.Last();
                isScheduled = true;
            }
        }

        private void ScheduleTimePicker_SelectedTimeChanged(object sender, TimePickerSelectedValueChangedEventArgs e)
        {
            selectedTime = e.NewTime.Value;
            isScheduled = true;
        }
    }
}
