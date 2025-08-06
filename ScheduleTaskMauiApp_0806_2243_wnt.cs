// 代码生成时间: 2025-08-06 22:43:23
using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Essentials;
using System.Reactive.Subjects;

namespace MauiApp
{
    public class ScheduleTaskMauiApp : Application
n    {
        private BehaviorSubject<bool> _isRunning = new BehaviorSubject<bool>(false);
        private IDisposable _timerSubscription;
        private readonly TimeSpan _interval = TimeSpan.FromSeconds(10); // Interval time for the task

        public ScheduleTaskMauiApp()
        {
            MainPage = new MainPage();

            // Start the scheduler
            StartScheduler();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private async void StartScheduler()
        {
            try
            {
                if (_isRunning.Value) return;

                _isRunning.OnNext(true);

                _timerSubscription = _isRunning
                    .Throttle(TimeSpan.FromSeconds(5)) // Throttle to reduce frequency
                    .Subscribe(async _ =>
                    {
                        await ExecuteTask();
                    });
            }
            catch (Exception ex)
            {
                // Handle any errors that occur
                Console.WriteLine($"Error starting scheduler: {ex.Message}");
            }
        }

        private async Task ExecuteTask()
        {
            try
            {
                // Your task logic here
                Console.WriteLine($"Task executed at {DateTime.Now}.");
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine($"Error executing task: {ex.Message}");
            }
        }

        private void StopScheduler()
        {
            _timerSubscription?.Dispose();
            _isRunning.OnNext(false);
        }
    }
}
