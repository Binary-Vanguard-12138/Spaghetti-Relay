using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Message_Relay_GUI
{
    public partial class SpaghettiForm : Form
    {
        /// <summary>
        /// Enumeration for socket errors.
        /// </summary>
        private const int SUCCESS = 0, SHUTDOWN = 1, DISCONNECT = 2,
                          BIND_ERROR = 3, CONNECT_ERROR = 4, SETUP_ERROR = 5,
                          STARTUP_ERROR = 6, ADDRESS_ERROR = 7, PARAMETER_ERROR = 8;

        /// <summary>
        /// Private variables required for the C# frontend.
        /// </summary>
        private bool active = false;
        private bool serverMode = true;
        private Thread connectThread = null;
        private delegate void VoidDelegate();
        private delegate void StringDelegate(String data);
        private delegate void IntegerDelegate(int data);

        public SpaghettiForm()
        {
            InitializeComponent();
            portNumberBox.ValidatingType = typeof(ushort);
        }

        private void PortNumberBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MessageBox.Show("Invalid Port Number (Range is 1:65535.)", "Port Entry Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            portNumberBox.Text = "31337";
        }

        private void PortNumberBox_Leave(object sender, EventArgs e)
        {
			try
			{
				ushort.Parse(portNumberBox.Text);
			}
			catch (Exception)
			{
                PortNumberBox_MaskInputRejected(sender, null);				
			}

			if (ushort.Parse(portNumberBox.Text) == 0)
                PortNumberBox_MaskInputRejected(sender, null);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RadioChanged(object sender, EventArgs e)
        {
            serverMode = !serverMode;
            addressBox.Enabled = !addressBox.Enabled;

            if (serverMode)
            {
                connectionDisplayBox.Text = "Not Listening";
                connectionButton.Text = "Listen";
            }
            else
            {
                connectionDisplayBox.Text = "Not Connected";
                connectionButton.Text = "Connect";
            }
        }

        private void ConnectionButton_Click(object sender, EventArgs e)
        {
            if (active)
            {
                active = false;
                SetDisconnected();

                connectThread.Join();
                connectThread = null;
            }
            else
            {
                active = true;
                connectionButton.Text = "Stop";
                serverRadio.Enabled = false;
                clientRadio.Enabled = false;

                if (serverMode)
                    connectionDisplayBox.Text = "Listening";
                else
                    connectionDisplayBox.Text = "Connecting";

                connectThread = new Thread(Connect);
                connectThread.Start();
            }
        }

        private void SetDisconnected()
        {
            active = false;
            sendButton.Enabled = false;
            serverRadio.Enabled = true;
            clientRadio.Enabled = true;
            messageBox.AppendText("\r\n\r\n[Disconnected]\r\n");

            if (serverMode)
            {
                connectionButton.Text = "Listen";
                connectionDisplayBox.Text = "Not Listening";
                Server.stop();
            }
            else
            {
                connectionButton.Text = "Connect";
                connectionDisplayBox.Text = "Not Connected";
                Client.stop();
            }
        }

        private void SetConnected()
        {
            sendButton.Enabled = true;
            connectionDisplayBox.Text = "Connected";
            messageBox.AppendText("\r\n\r\n[Connected]\r\n");
        }

        private void AppendMessage(String message)
        {
            messageBox.AppendText(message);
        }

        private void Connect()
        {
            int result;
            // Bind to port and listen for connections.
            if (serverMode)
                result = Server.init(ushort.Parse(portNumberBox.Text));
            else
                result = Client.init(ushort.Parse(portNumberBox.Text), addressBox.Text);

            if (result != 0)
            {
                // After disconnect, reset the form and shut down the program.
                // Display any errors received.
                if (active)
                {
                    Invoke(new VoidDelegate(SetDisconnected));
                    Invoke(new IntegerDelegate(DisplayError), result);
                }
                return;
            }

            // After a connection is established, enable communication.
            Invoke(new VoidDelegate(SetConnected));

            // Loop, reading from the connection until disconnected.
            byte[] buffer = new byte[256];
            UTF8Encoding encoding = new UTF8Encoding();
            buffer[0] = (byte)'\0';

            while (true)
            {
                if (serverMode)
                    result = Server.readMessage(buffer, buffer.Length);
                else
                    result = Client.readMessage(buffer, buffer.Length);

                if (result != SUCCESS)
                    break;

                Invoke(new StringDelegate(AppendMessage), "\r\n[Received]: " + encoding.GetString(buffer));
            }

            // After program has disconnected, stop the program and reset the form.
            // Display any errors received.
            if (active)
            {
                Invoke(new VoidDelegate(SetDisconnected));
                Invoke(new IntegerDelegate(DisplayError), result);
            }
        }

        private void DisplayError(int errorNumber)
        {
            switch (errorNumber)
            {
                case SUCCESS:
                case SHUTDOWN:
                    break;

                case DISCONNECT:
                    MessageBox.Show("Messenger's connection was severed", "Disconnection",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;

                case BIND_ERROR:
                    MessageBox.Show("Server could not bind to port successfully.", "Server Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;

                case CONNECT_ERROR:
                    MessageBox.Show("Cannot connect to client/server.", "Connect Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;

                case SETUP_ERROR:
                    MessageBox.Show("Messenger encountered an error during setup.", "Setup Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;

                case ADDRESS_ERROR:
                    MessageBox.Show("Server's address not in valid dot notation.", "Client Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;

                case STARTUP_ERROR:
                    MessageBox.Show("Messenger failed in platform-specific startup.", "Startup Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;

                case PARAMETER_ERROR:
                    MessageBox.Show("Messenger buffer is not big enough for message received.", "Buffer Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;

                default:
                    MessageBox.Show("Messenger encountered an unknown error.", "Unknown Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            int result;
            
            if (serverMode)
                result = Server.sendMessage(sendDataBox.Text, sendDataBox.Text.Length + 1);
            else
                result = Client.sendMessage(sendDataBox.Text, sendDataBox.Text.Length + 1);

            if (result != SUCCESS)
                DisplayError(result);
            else
            {
                AppendMessage("\r\n[Sent Out]: " + sendDataBox.Text);
                sendDataBox.Text = "";
            }
        }

        private void SendDataBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (sendButton.Enabled)
                {
                    e.Handled = true;
                    SendButton_Click(sender, e);
                }
            }
        }
        
        private void MessageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            active = false;

            if (serverMode)
                Server.stop();
            else
                Client.stop();
        }
    }
}
