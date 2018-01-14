using System;
using System.IO;
using System.Windows.Forms;

namespace Byte_Converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public String ChangeBytes16(String input)
        {
            input = input.Replace(" ", "");
            String output = "";
            for (int i = 0; i < input.Length; i += 4)
            {
                short tmp = Convert.ToInt16(input.Substring(i, 4), 16);
                short reversedBytes = System.Net.IPAddress.NetworkToHostOrder(tmp);
                String start = reversedBytes.ToString("X").PadLeft(4, '0');
                output += start;
            }
            return (output);
        }

        public String ChangeBytes32(String input)
        {
            input = input.Replace(" ", "");
            String output = "";
            for (int i = 0; i < input.Length; i += 8)
            {
                int tmp = Convert.ToInt32(input.Substring(i, 8), 16);
                int reversedBytes = System.Net.IPAddress.NetworkToHostOrder(tmp);
                String start = reversedBytes.ToString("X").PadLeft(8, '0');
                output += start;
            }
            return (output);
        }

        public String ChangeBytes64(String input)
        {
            input = input.Replace(" ", "");
            String output = "";
            for (int i = 0; i < input.Length; i += 16)
            {
                long tmp = Convert.ToInt64(input.Substring(i, 16), 16);
                long reversedBytes = System.Net.IPAddress.NetworkToHostOrder(tmp);
                String start = reversedBytes.ToString("X").PadLeft(16, '0');
                output += start;
            }
            return (output);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                textBox2.Text = ChangeBytes16(textBox1.Text);
            if (radioButton2.Checked)
                textBox2.Text = ChangeBytes32(textBox1.Text);
            if (radioButton3.Checked)
                textBox2.Text = ChangeBytes64(textBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                textBox1.Text = ChangeBytes16(textBox2.Text);
            if (radioButton2.Checked)
                textBox1.Text = ChangeBytes32(textBox2.Text);
            if (radioButton3.Checked)
                textBox1.Text = ChangeBytes64(textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogue = new OpenFileDialog();
            dialogue.Title = "Open Little Endian File";
            textBox1.Text = "Opening...";
            if (dialogue.ShowDialog() != DialogResult.OK)
            {
                textBox1.Text = "";
            }
            if (dialogue.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(dialogue.FileName, FileMode.Open);
                int input;
                textBox1.Text = "";
                textBox2.Text = "";
                for (int i = 0; (input = fs.ReadByte()) != -1; i++)
                {
                    String hex = string.Format("{0:X2}", input);
                    textBox1.Text += hex;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogue = new OpenFileDialog();
            dialogue.Title = "Open Big Endian File";
            textBox2.Text = "Opening...";
            if (dialogue.ShowDialog() != DialogResult.OK)
            {
                textBox2.Text = "";
            }
            if (dialogue.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(dialogue.FileName, FileMode.Open);
                int input;
                textBox1.Text = "";
                textBox2.Text = "";
                for (int i = 0; (input = fs.ReadByte()) != -1; i++)
                {

                    String hex = string.Format("{0:X2}", input);
                    textBox2.Text += hex;
                }
            }
        }
    }
}
