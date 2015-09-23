using System;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;

namespace ChatClient
{
    public static class IpDialog
    {
        public static System.Net.IPEndPoint ShowDialog(string text, string caption)
        {
            var prompt = new Form
            {
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Width = 170,
                Height = 130,
                Text = caption,
                StartPosition = FormStartPosition.CenterParent
            };
            System.Net.IPAddress ip = null;
            var textLabel = new Label() { Left = 20, Top = 10, Text = text, AutoSize = true };
            var inputBox = new TextBox() { Left = 20, Top = 30, Width = 120, Text = @"217.197.6.138:2032" };
            var defaultIpButton = new Button() { Text = @"Reset", Left = 20, Width = 60, Top = 55 };
            var confirmationButton = new Button() { Text = @"Ok", Left = 80, Width = 60, Top = 55 };
            var correct = false;
            defaultIpButton.Click += delegate { inputBox.Text = @"217.197.6.138:2032"; };
            string endPointS = inputBox.Text;
            int port = 2032;
            IPAddress ipd_ip = IPAddress.Parse("217.197.6.138");
            inputBox.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    confirmationButton.PerformClick();
            };
            confirmationButton.Click += (sender, e) =>
            {
                try
                {
                    endPointS = inputBox.Text;
                    string[] ep = endPointS.Split(':');
                    if (ep.Length != 2) throw new FormatException("Invalid endpoint format");
                    if (!IPAddress.TryParse(ep[0], out ipd_ip))
                    {
                        throw new FormatException("Invalid ip-adress");
                    }
                    if (!int.TryParse(ep[1], NumberStyles.None, NumberFormatInfo.CurrentInfo, out port))
                    {
                        throw new FormatException("Invalid port");
                    }
                    correct = true;
                    prompt.Close();
                }
                catch (FormatException exception)
                { MessageBox.Show(exception.Message, @"Chat error!", MessageBoxButtons.OK, MessageBoxIcon.Error);}
            };
            prompt.FormClosing += delegate (object sender, FormClosingEventArgs e)
            {
                if (!correct)
                {
                    port = 0;
                    ipd_ip = IPAddress.None;
                }
            };
            prompt.Controls.Add(confirmationButton);
            prompt.Controls.Add(defaultIpButton);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.ShowDialog();
            IPEndPoint endpointR = new IPEndPoint(ipd_ip, port);
            return endpointR;
        }
    }
}
