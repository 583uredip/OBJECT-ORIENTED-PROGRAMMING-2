using System;
using System.Windows.Forms;
using InTheHand.Net.Sockets;
using InTheHand.Net.Bluetooth;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        BluetoothDeviceInfo[] scannedDevices;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // 🔍 Scan Button (button1)
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            try
            {
                BluetoothClient client = new BluetoothClient();
                scannedDevices = client.DiscoverDevices();

                foreach (BluetoothDeviceInfo device in scannedDevices)
                {
                    listBox1.Items.Add(device.DeviceName);
                }

                if (scannedDevices.Length == 0)
                {
                    listBox1.Items.Add("No devices found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // 🔗 Double Click Device
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (scannedDevices == null || listBox1.SelectedIndex < 0)
                    return;

                BluetoothDeviceInfo selectedDevice =
                    scannedDevices[listBox1.SelectedIndex];

                MessageBox.Show("Selected: " + selectedDevice.DeviceName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}