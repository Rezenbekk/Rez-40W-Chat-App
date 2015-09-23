using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Diagnostics;
using System.Drawing;

namespace ChatClient
{
    public partial class ClientForm : Form
    {
        //public static Hashtable emotes;
        public static Socket ClientSocket;
        public static bool Connected;
        private IAsyncResult result;
        private bool sendBoxFocused = false;

        public ClientForm()
        {
            InitializeComponent();
            sendBox.ShortcutsEnabled = true;
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        private void joinBtn_Click(object sender, EventArgs e)
        {
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            if (Connected)
                Disconnect();
            var ep = IpDialog.ShowDialog("Enter server IP and port", "Connect to server");
            if (ep.Address.Equals(IPAddress.None))
                return;
            try
            {
                if (ClientSocket.Connected)
                    Thread.Sleep(500);
                result = ClientSocket.BeginConnect(ep, null, null);
                statusLbl.Text = @"Connecting...";
                bool success = result.AsyncWaitHandle.WaitOne(3000, true);
                if (!success)
                {
                    // NOTE, MUST CLOSE THE SOCKET
                    ClientSocket.Close();
                    Connected = false;
                    statusLbl.Text = @"Try again.";
                    throw new ApplicationException("Connection timeout.");
                }
                if (!ClientSocket.Connected)
                {
                    Disconnect();
                    return;
                }
                Connected = true;
                Post(@">>>CONNECTED<<<");
                statusLbl.Text = @"Connected.";
                Task incomingMessages = new Task(() => ProcessIn(ClientSocket));
                incomingMessages.Start();
            }
            catch (ApplicationException exception)
            {
                MessageBox.Show(exception.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
                Post(exception.Message);
            }
        }

        private void ProcessIn(object sck)
        {
            var socket = (Socket) sck;
            try
            {
                var buffer = new byte[1000];
                while (true)
                {
                    int n = socket.Receive(buffer);
                    string msg = Encoding.GetEncoding(1251).GetString(buffer, 0, n);
                    Post(@"["+DateTime.Now.ToShortTimeString()+@"] "+ msg);
                }
            }
            catch (SocketException exception)
            {
                Post(exception.Message);
                Disconnect();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void Disconnect()
        {
            ClientSocket.Close();
            Connected = false;
            statusLbl.Invoke((MethodInvoker)(() =>
            {
                statusLbl.Text = @"Not connected";
            }));
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        private void Post(string msg)
        {
            chatBox.Invoke((MethodInvoker)(() =>
            {
                chatBox.Text += Environment.NewLine + msg; }));
        }

        private void chatBox_TextChanged(object sender, EventArgs e)
        {
            if (chatBox.Visible)
            {
                chatBox.SelectionStart = chatBox.TextLength;
                chatBox.ScrollToCaret();
            }
        }

        private void sendBox_Enter(object sender, EventArgs e)
        {
            sendBox.SelectAll();
            sendBoxFocused = true;
        }
        private void sendBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (!sendBoxFocused && sendBox.SelectionLength == 0)
            {
                sendBoxFocused = true;
                sendBox.SelectAll();
            }
        }
        private void sendBox_Leave(object sender, EventArgs e)
        {
            sendBoxFocused = false;
        }
        private void sendBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendBtn_Click(null, null);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.Control && (e.KeyCode == Keys.A))
            {
                sendBox.SelectAll();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void sendBtn_Click(object sender, EventArgs e)
        {
            if (!Connected)
                MessageBox.Show(@"Connect to a server first.", @"Sending error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            if (sendBox.Text.Trim() == "")
                return;
            string msg = nickBox.Text.Trim() + ": " + sendBox.Text.TrimEnd();
            chatBox.Text += Environment.NewLine + @"[" + DateTime.Now.ToShortTimeString() + @"] " + msg;
            var bytesToServer = Encoding.GetEncoding(1251).GetBytes(msg);
            try
            {
                ClientSocket.Send(bytesToServer);
                sendBox.Text = "";
            }
            catch (Exception exception)
            {
                chatBox.Text += Environment.NewLine + exception.Message;
            }
        }

        private void nickBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nickLbl.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                nickBox.Undo();
                nickLbl.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

    }
}
