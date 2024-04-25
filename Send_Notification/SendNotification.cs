using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace Notification_Sender_Windows.Send_Notification
{
    public class SendNotification
    {
        public SendNotification(string title, string body) 
        {
            new ToastContentBuilder()
                .AddText(title)
                .AddText(body)
                .Show();
        }
    }
}
