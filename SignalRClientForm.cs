using Microsoft.AspNetCore.SignalR.Client;
using SignalRClientDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignalRClientDesktopApp
{
    public partial class SignalRClientForm : Form
    {
        HubConnection hubConnection;
        //private string signalRServerUrl = "http://smrhjustedu-003-site5.ctempurl.com/chatHub?userId=100100";
        private const string signalRServerUrl = "https://localhost:7137/chatHub?userId=100100&access_token=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJKV1RTZXJ2aWNlQWNjZXNzVG9rZW4iLCJqdGkiOiJkODc5MTliMi1hYjc3LTRjZDItYjMzZC0zYzU4ZDIzMTYwMWQiLCJpYXQiOjE3MDY5NTExOTgsIm5hbWUiOiJhZG1pbiIsIlVzZXJJZCI6IjEwMDEwMCIsImVtYWlsIjoiYWxhbWluLmNzZS5qdXN0aWFuQGdtYWlsLmNvbSIsInJvbGUiOiJBZG1pbiIsIm5iZiI6MTcwNjk1MTE5OCwiZXhwIjoxNzA3MDM3NTk4fQ.gJ7f8EIixYWgdcMo171YJ-Plnyv81pvLdlydNJqk0Nc";
        public SignalRClientForm()
        {
            InitializeComponent();

            this.connection_status.Text = "Connecting...";

            hubConnection = new HubConnectionBuilder()
                .WithUrl(signalRServerUrl)
                .Build();

            hubConnection.Closed += HubConnection_Closed;

            hubConnection.Reconnected += HubConnection_Reconnected;

            hubConnection.Reconnecting += HubConnection_Reconnecting;

            ReceiveMessage();

        }

        private Task HubConnection_Reconnecting(Exception arg)
        {
            this.Invoke((Action)(() =>
            {
                this.connection_status.Text = "Reconnecting...";
            }));
            return Task.CompletedTask;
        }

        private Task HubConnection_Reconnected(string arg)
        {
            this.Invoke((Action)(() =>
            {
                this.connection_status.Text = "Connected";
            }));
            return Task.CompletedTask;
        }

        private async Task HubConnection_Closed(Exception arg)
        {
            this.Invoke((Action)(() =>
            {
                this.connection_status.Text = "Connection failed";
            }));

            await Task.Delay(500);
            await hubConnection.StartAsync();
        }

        private void ReceiveMessage()
        {
            hubConnection.On("ReceiveMessage", (Models.Message message) =>
            {
                this.Invoke((Action)(() =>
                {
                    this.richTextBox1.Text = message.userName + " : " + message.message;
                }));
            });
        }

        private async void SignalRClientForm_Load(object sender, EventArgs e)
        {
            await hubConnection.StartAsync();
            this.Invoke((Action)(async () =>
            {
                this.connection_status.Text = "Connected";
                await hubConnection.InvokeAsync("JoinGroup", "Benapole");
            }));
        }
    }
}
