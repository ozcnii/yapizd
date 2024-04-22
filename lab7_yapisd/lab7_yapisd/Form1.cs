using Lab5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab7_yapisd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal vectorSize = numericUpDown1.Value;
            string fileName = textBox1.Text.Trim();

            if (fileName == "")
            {
                MessageBox.Show("Название файла обязательно и не должно состоять только из пробелов", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            fileName += ".txt";


            string textOutput = "";

            IVectorable[] vectors = Utility.GetRadnomVectors((int)vectorSize);
            textOutput += "Исходный массив векторов:\n";

            for (int i = 0; i < vectors.Length; i++)
            {
                textOutput += i+1 + ") " + vectors[i] + "\n";
            }

            FileStream outputStream = File.Create(fileName);

            Vectors.OutputVectors(vectors, outputStream);
            outputStream.Close();

            FileStream inputStream = File.OpenRead(fileName);
            IVectorable[] newVectors = Vectors.InputVectors(inputStream);
            inputStream.Close();

            textOutput += "\n";


            for (int i = 0; i < vectors.Length; i++)
            {
                if (vectors[i].Equals(newVectors[i]))
                {
                    textOutput += i+1 + ") (+) " + "Вектор { " + newVectors[i] + " } прошел проверку методом Equals после чтения из файла\n";
                }
                else
                {
                    textOutput += i+1 + ") (-) " + "Вектор { " + newVectors[i] + " } не прошел проверку методом Equals после чтения из файла\n";
                }
            }

            label1.Text = textOutput;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            decimal vectorSize = numericUpDown2.Value;
            string fileName = textBox2.Text.Trim();

            if (fileName == "")
            {
                MessageBox.Show("Название файла обязательно и не должно состоять только из пробелов", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            fileName += ".txt";


            string textOutput = "";
            IVectorable[] vectors = Utility.GetRadnomVectors((int)vectorSize);

            textOutput += "Исходный массив векторов:\n";
            for (int i = 0; i < vectors.Length; i++)
            {
                textOutput += i + 1 + ") " + vectors[i] + "\n";
            }

            FileStream outputStream = File.Create(fileName);

            Vectors.OutputVectors(vectors, outputStream);
            outputStream.Close();

            FileStream inputStream = File.OpenRead(fileName);
            IVectorable[] newVectors = Vectors.InputVectors(inputStream);
            inputStream.Close();

            textOutput += "\n";

            for (int i = 0; i < vectors.Length; i++)
            {
                if (vectors[i].Equals(newVectors[i]))
                {
                    textOutput += i + 1 + ") (+) " + "Вектор { " + newVectors[i] + " } прошел проверку методом Equals после чтения из файла\n";
                }
                else
                {
                    textOutput += i + 1 + ") (-) " + "Вектор { " + newVectors[i] + " } не прошел проверку методом Equals после чтения из файла\n";
                }
            }

            label2.Text = textOutput;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Выбреите тип вектора", "Выбреите тип вектора", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int vectorSize = (int)numericUpDown3.Value;
            
            bool isArrayVector = radioButton1.Checked;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string textOutput = "";
                    IVectorable vector;

                    if (isArrayVector) 
                    {
                        vector = Utility.GetRandomAV(vectorSize);
                    } else
                    {
                        vector = Utility.GetRandomLLV(vectorSize);
                    }

                    textOutput += "Исходный вектор: " + vector.ToString() + "\n";

                    FileStream wirteStream = File.OpenWrite(openFileDialog1.FileName);
                    BinaryFormatter serializerA = new BinaryFormatter();
                    serializerA.Serialize(wirteStream, vector);
                    wirteStream.Close();

                    FileStream readStream = File.OpenRead(openFileDialog1.FileName);
                    IVectorable serializedVector = (IVectorable)serializerA.Deserialize(readStream);
                    readStream.Close();

                    textOutput += "\nДесериализованный вектор: " + serializedVector + "\n";

                    textOutput += "\n";
                   
                    if (vector.Equals(serializedVector))
                    {
                        textOutput += "(+) " + "Вектор { " + serializedVector + " } прошел проверку методом Equals после чтения из файла\n";
                    }
                    else
                    {
                        textOutput += " (-) " + "Вектор { " + serializedVector + " } не прошел проверку методом Equals после чтения из файла\n";
                    }
                  
                    label3.Text = textOutput;
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }
    }
}
