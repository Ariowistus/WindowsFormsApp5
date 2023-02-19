using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //obsługa plików

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //https://docs.microsoft.com/pl-pl/dotnet/api/system.windows.forms.openfiledialog?view=windowsdesktop-6.0
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                label3.Text = openFileDialog1.FileName; 

                //Read the contents of the file into a stream
                var fileStream = openFileDialog1.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    textBox1.Text = reader.ReadToEnd();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int shift = 3; // wartość przesunięcia
            string input = textBox1.Text;
            string output = "";

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    char shifted = (char)(((int)char.ToLower(c) - 97 + shift) % 26 + 97);
                    output += char.IsUpper(c) ? char.ToUpper(shifted) : shifted;
                }
                else
                {
                    output += c;
                }
            }

            textBox2.Text = output;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //https://docs.microsoft.com/pl-pl/dotnet/api/system.windows.forms.savefiledialog?view=windowsdesktop-6.0
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveFileDialog1.FileName, textBox2.Text);
                label4.Text = saveFileDialog1.FileName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int shift = 3; // wartość przesunięcia
            string input = textBox2.Text;
            string output = "";

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    char shifted = (char)(((int)char.ToLower(c) - 97 - shift + 26) % 26 + 97);
                    output += char.IsUpper(c) ? char.ToUpper(shifted) : shifted;
                }
                else
                {
                    output += c;
                }
            }

            textBox1.Text = output;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string key = "tajnyklucz"; // klucz szyfrujący
            string input = textBox1.Text;
            string output = "";

            for (int i = 0; i < input.Length; i++)
            {
                // pobierz kolejny znak klucza (cyklicznie)
                char keyChar = key[i % key.Length];

                // oblicz kod znaku wynikowego
                int shifted = ((int)input[i] + (int)keyChar) % 256;

                // dodaj znak wynikowy do wyjścia
                output += (char)shifted;
            }

            textBox2.Text = output;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string key = "tajnyklucz"; // klucz szyfrujący
            string input = textBox2.Text;
            string output = "";

            for (int i = 0; i < input.Length; i++)
            {
                // pobierz kolejny znak klucza (cyklicznie)
                char keyChar = key[i % key.Length];

                // oblicz kod znaku oryginalnego
                int shifted = ((int)input[i] - (int)keyChar + 256) % 256;

                // dodaj znak oryginalny do wyjścia
                output += (char)shifted;
            }

            textBox1.Text = output;
        }
    }
}
