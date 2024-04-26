using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification_Sender_Windows.Send_Notification
{
    public class SendScheduledNotification
    {
        public SendScheduledNotification(string title, string body, DateTime scheduledDateTime) 
        {
            new ToastContentBuilder()
                .AddText(title)
                .AddText(body)
                .Schedule(scheduledDateTime)
                ;
        }
    }
}
