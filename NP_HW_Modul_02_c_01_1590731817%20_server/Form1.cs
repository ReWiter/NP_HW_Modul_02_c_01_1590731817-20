using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace NP_HW_Modul_02_c_01_1590731817_20_server
{
    public partial class Form1 : Form
    {
        NetworkStream client_stream;
        public Form1()
        {
            InitializeComponent();
        }
        string word;
        private void Form1_Load(object sender, EventArgs e)
        {
            //Connect();
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
        private async void HumanNCOM()
        {//Human(Client) and COM(server)
            string[] WtA = { "Hello", "Bye", "How do you do", "Still the same" };
            Random rnd = new Random();
            var server = new TcpListener(IPAddress.Any, 1562);
            BinaryFormatter bf = new BinaryFormatter();
            server.Start();
            while (true)
            {
                int i = rnd.Next(0, WtA.Length);
                var client = await server.AcceptTcpClientAsync();
                client_stream = client.GetStream();
                word = (string)bf.Deserialize(client_stream);
                client_stream.Write(GetByteDataSet(WtA[i]), 0, GetByteDataSet(WtA[i]).Length);
                if (word == "Bye")
                {
                    richTextBox1.Text = word + " " + DateTime.Now;
                    client.Close();
                    break;

                }
                else
                {
                    richTextBox1.Text = word + " " + DateTime.Now;
                    client_stream.Flush();
                }
                client.Close();
            }
            Close();
        }
        private async void COMnCOM()
        { //COM and COM
            string[] WtA = { "Hello", "Bye", "How do you do", "Still the same" };
            Random rnd = new Random();
            var server = new TcpListener(IPAddress.Any, 1562);
            BinaryFormatter bf = new BinaryFormatter();
            server.Start();
            while (true)
            {
                int i = rnd.Next(0, WtA.Length);
                var client = await server.AcceptTcpClientAsync();
                client_stream = client.GetStream();
                word = (string)bf.Deserialize(client_stream);
                client_stream.Write(GetByteDataSet(WtA[i]), 0, GetByteDataSet(WtA[i]).Length);
                if (word == "Bye")
                {
                    richTextBox1.Text = word + " " + DateTime.Now;
                    client.Close();
                    break;

                }
                else
                {
                    richTextBox1.Text = word + " " + DateTime.Now;
                    client_stream.Flush();
                }
                client.Close();
            }
            Close();
        }
        private async void COMnHuman()
        {
            button1.Enabled=false;
            var server = new TcpListener(IPAddress.Any, 1562);
            BinaryFormatter bf = new BinaryFormatter();
            server.Start();
            while (true)
            {
                var client = await server.AcceptTcpClientAsync();
                client_stream = client.GetStream();
                word = (string)bf.Deserialize(client_stream);
                client_stream.Write(GetByteDataSet(richTextBox2.Text), 0, GetByteDataSet(richTextBox2.Text).Length);
                if (word == "Bye")
                {
                    richTextBox1.Text = word + " " + DateTime.Now;
                    client.Close();
                    break;

                }
                else
                {
                    richTextBox1.Text = word + " " + DateTime.Now;
                    client_stream.Flush();
                }
                client.Close();
            }
            Close();
        }
        private void Connect()
        {
            //HumanNCOM();
            //COMnCOM();
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            COMnHuman();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
