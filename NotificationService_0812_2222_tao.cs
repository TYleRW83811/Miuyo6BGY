// 代码生成时间: 2025-08-12 22:22:20
using System;
using CommunityToolkit.Maui.Core;
using System.Threading.Tasks;

namespace MauiApp
{
    /// <summary>
    /// Notification service for sending local notifications.
    /// </summary>
    public class NotificationService
    {
        /// <summary>
        /// Sends a notification to the user.
        /// </summary>
        /// <param name="title">The title of the notification.</param>
        /// <param name="message">The message content of the notification.</param>
        /// <param name="sender">Optional sender identifier for the notification.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public async Task SendNotificationAsync(string title, string message, string sender = "")
        {
            try
            {
                // Check for null or empty strings
                if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(message))
                {
                    throw new ArgumentException("Title and message must not be null or empty.");
                }

                // Create notification builder
                var builder = new NotificationBuilder();
                builder.SetContent(new NotificationContent
                {
                    Title = title,
                    Message = message,
                    Sender = sender
                });

                // Build the notification
                var notification = builder.Build();

                // Show the notification
                await notification.Show();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"Error sending notification: {ex.Message}");
            }
        }
    }
}

/*
 * Usage:
 * var notificationService = new NotificationService();
 * await notificationService.SendNotificationAsync("New Message", "You have a new message!");
 */