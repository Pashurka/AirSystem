using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using AndroidX.Core.App;


namespace AirSystem.Droid
{
    [Activity(Label = "AirSystem", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
   
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            Xamarin.FormsMaps.Init(this, savedInstanceState);

            // Виклик простого сповіщення
            SendSimpleNotification("Увага!", "Для Вас є рекомендації. Індекс якості повітря AQI=56.");
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        // метод передачи повідомлення на панель сповіщення
        private void SendSimpleNotification(string title, string message)
        {
            // Ідентифікатор каналу для Android 8.0+
            const string channelId = "simple_notification_channel";

            // Створення каналу (обов'язково для Android 8.0+)
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var channel = new NotificationChannel(
                    channelId,
                    "Основний канал",
                    NotificationImportance.Default)
                {
                    Description = "Канал для основних сповіщень"
                };

                var notificationManager = (NotificationManager)GetSystemService(NotificationService);
                notificationManager.CreateNotificationChannel(channel);
            }

            // Побудова сповіщення
            var notificationBuilder = new NotificationCompat.Builder(this, channelId)
                .SetContentTitle(title)                 // Заголовок сповіщення
                .SetContentText(message)                // Текст сповіщення
                .SetSmallIcon(Resource.Drawable.icon_danger)   // Іконка сповіщення
                .SetAutoCancel(true);                   // Автозакриття після натискання

            // Надсилання сповіщення
            var manager = NotificationManagerCompat.From(this);
            manager.Notify(1000, notificationBuilder.Build());
        }
    }
}