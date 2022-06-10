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
        private const string signalRServerUrl = "https://localhost:44338/message";
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
            hubConnection.On<MessageHub>("BroadcastMessageAsync", (message) =>
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
            this.Invoke((Action)(() =>
            {
                this.connection_status.Text = "Connected";
            }));
        }
    }
}
