using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace TouristHelper.Shared.Services
{
    public class ChatService
    {
        private HubConnection? _connection;

        public event Action<string, string, string>? OnMessageReceived;
        public bool IsConnected => _connection?.State == HubConnectionState.Connected;

        public async Task StartAsync(string userId)
        {
            if (_connection != null && _connection.State == HubConnectionState.Connected)
                return;

            _connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5103/chatHub", options =>
                {
                    // You can pass headers here if needed
                    options.Headers.Add("UserId", userId);
                })
                .WithAutomaticReconnect()
                .Build();

            _connection.On<string, string, string>("ReceiveMessage", (senderRole, senderId, message) =>
            {
                OnMessageReceived?.Invoke(senderRole, senderId, message);
            });

            _connection.Closed += async (error) =>
            {
                Console.WriteLine($"SignalR disconnected: {error?.Message}");
                await Task.Delay(3000); // Wait before reconnect
                await StartAsync(userId); // Retry
            };

            await _connection.StartAsync();

            // Register user on the server-side (recommended)
            await _connection.InvokeAsync("RegisterUser", userId);
        }

        public async Task SendMessage(string senderRole, string senderId, string receiverId, string message)
        {
            if (_connection?.State == HubConnectionState.Connected)
            {
                try
                {
                    await _connection.InvokeAsync("SendMessage", senderRole, senderId, receiverId, message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending message: {ex.Message}");
                }
            }
        }

        public async Task StopAsync()
        {
            if (_connection != null)
            {
                try
                {
                    await _connection.StopAsync();
                    await _connection.DisposeAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error stopping connection: {ex.Message}");
                }
            }

            _connection = null;
        }
    }
}
