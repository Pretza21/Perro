using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;

namespace Visual_Instru2018
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            serialPort1 = new SerialPort();
            serialPort1.PortName = "COM22";
            serialPort1.BaudRate = 9600;
            serialPort1.DtrEnable = true;
            serialPort1.Open();

            serialPort1.DataReceived += serialPort1_DataReceived;
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string line = serialPort1.ReadLine();
            this.BeginInvoke(new LineReceivedEvent(LineReceived), line);

        }

        private delegate void LineReceivedEvent(string line);
        private void LineReceived(string line)
        {
            textBox1.Text = line;
            int perro;
            int.TryParse(line, out perro);
            if (perro >= 10 && perro<= 100)
            {
                label1.Text = "Temperatura";
            }
            else if (perro >= 500 && perro<= 1500){
                label1.Text = "Presion";
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
