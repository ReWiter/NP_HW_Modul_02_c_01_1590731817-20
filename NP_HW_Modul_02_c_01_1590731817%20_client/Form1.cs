using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace NP_HW_Modul_02_c_01_1590731817_20_client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void IP_Box_TextChanged(object sender, EventArgs e)
        {

        }

        private void Port_Box_TextChanged(object sender, EventArgs e)
        {

        }
        private void HumanNCOM()
        {
            try
            {
                TcpClient client = new TcpClient(IP_Box.Text, Convert.ToInt32(Port_Box.Text));
                IP_Box.Enabled = false;
                Port_Box.Enabled = false;
                //string word;
                BinaryFormatter bf = new BinaryFormatter();
                NetworkStream client_stream = client.GetStream();
                client_stream.Write(GetByteDataSet(richTextBox1.Text), 0, GetByteDataSet(richTextBox1.Text).Length);
                richTextBox2.Text = (string)bf.Deserialize(client_stream);
                client_stream.Flush();
                if (richTextBox2.Text == "Bye")
                {
                    client.Close();
                    Close();
                }
            }
            catch { MessageBox.Show("Ошибка подключения"); }
        }
        private void COMnCOM()
        {
            string[] WrS = { "Hello", "Bye", "How do you do", "Still the same" };
            Random rn = new Random();
            int i = 0;
            try
            {
                i= rn.Next(WrS.Length);
                TcpClient client = new TcpClient(IP_Box.Text, Convert.ToInt32(Port_Box.Text));
                IP_Box.Enabled = false;
                Port_Box.Enabled = false;
                //string word;
                BinaryFormatter bf = new BinaryFormatter();
                NetworkStream client_stream = client.GetStream();
                client_stream.Write(GetByteDataSet(WrS[i]), 0, GetByteDataSet(WrS[i]).Length);
                richTextBox2.Text = (string)bf.Deserialize(client_stream);
                client_stream.Flush();
                if (richTextBox2.Text == "Bye")
                {
                    client.Close();
                    Close();
                }
            }
            catch { MessageBox.Show("Ошибка подключения"); }
        }
        private void COMnHuman()
        {
            string[] WrS = { "Hello", "Bye", "How do you do", "Still the same" };
            Random rn = new Random();
            int i = 0;
            try
            {
                i = rn.Next(WrS.Length);
                TcpClient client = new TcpClient(IP_Box.Text, Convert.ToInt32(Port_Box.Text));
                IP_Box.Enabled = false;
                Port_Box.Enabled = false;
                //string word;
                BinaryFormatter bf = new BinaryFormatter();
                NetworkStream client_stream = client.GetStream();
                client_stream.Write(GetByteDataSet(WrS[i]), 0, GetByteDataSet(WrS[i]).Length);
                richTextBox2.Text = (string)bf.Deserialize(client_stream);
                client_stream.Flush();
                if (richTextBox2.Text == "Bye")
                {
                    client.Close();
                    Close();
                }
            }
            catch { MessageBox.Show("Ошибка подключения"); }
        }
        private void Send_Click(object sender, EventArgs e)
        {
            //HumanNCOM();
            //COMnCOM();
            COMnHuman();
        }
        public static byte[] GetByteDataSet(string data)
        {
            byte[] data_rez;
            MemoryStream mem_streem = new MemoryStream();
            BinaryFormatter bin_format = new BinaryFormatter();
            bin_format.Serialize(mem_streem, data);
            data_rez = mem_streem.ToArray();
            mem_streem.Close();
            mem_streem.Dispose();
            return data_rez;
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
