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
        public MainPage()
        {
            this.InitializeComponent();

            // Set the size of window to be 853x480
            // The grid is set to remain 853x480 so xaml elements stay consistent
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(853, 480));
            ApplicationView.PreferredLaunchViewSize = new Size(853, 480);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }

        private void SendNotification_Click(object sender, RoutedEventArgs e)
        {
            string title = titleTextBox.Text;
            string body = bodyTextBox.Text;

            SendNotification sendNotification = new SendNotification(title, body);
        }
    }
}
