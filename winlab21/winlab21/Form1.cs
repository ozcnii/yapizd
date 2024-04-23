using System;
using System.Windows.Forms;

namespace winlab21
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            numericUpDown1.Value = 3;
            textBox1.Text = "20 10 30";
            tabControl2.Visible = false;
            radioButton1.Checked = true;
            radioButton3.Checked = true;
            tabControl3.Visible = false;

            textBox2.Text = "10 5 10 12";
            textBox3.Text = "8 12 49 2";
        }

        private ArrayVector vector;

        private ArrayVector vector1;
        private ArrayVector vector2;

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int vectorSize = (int)numericUpDown1.Value;
            string textBoxValue = textBox1.Text.Trim();
            string[] temp = textBoxValue.Split(' ');

            if(textBoxValue == "")
            {
                MessageBox.Show("Строка ввода элементов не должна быть пустой", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (temp.Length != vectorSize)
            {
                MessageBox.Show("Размерность введенного вектора не совпадает с введенной размерностью", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            vector = new ArrayVector(vectorSize);
            
            for (int i = 0; i < temp.Length; i++)
            {
                vector[i] = int.Parse(temp[i]);
            }

            label3.Text = "Получившийся вектор: " + vector.ToString();
            
            tabControl2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int numIndex = (int)numericUpDown2.Value; 
            int newValue = (int)numericUpDown3.Value;


            if (numIndex > vector.Length)
            {
                MessageBox.Show("Номер элемента вышел за пределы допустимого", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            vector[numIndex - 1] = newValue;

            label3.Text = "Получившийся вектор: " + vector.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int sumPositive = vector.SumPositivesFromChetIndex();
                MessageBox.Show($"Сумма равна: {sumPositive}", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int sumLess = vector.SumLessFromNechetIndex();
                MessageBox.Show($"Сумма равна: {sumLess}", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int mulChet = vector.MultChet();
                MessageBox.Show($"Произведение равно: {mulChet}", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int mulNeChet = vector.MultNechet();
                MessageBox.Show($"Произведение равно: {mulNeChet}", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            double norm = vector.GetNorm();
            MessageBox.Show($"Модуль вектора: {norm}", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // 1 - по возрастанию     
            // 2 - по убыванию
            if (radioButton1.Checked) 
            {
                vector.SortUp();
                label3.Text = "Отсортированный вектор: " + vector.ToString();
            } 
            else
            {
                vector.SortDown();
                label3.Text = "Отсортированный вектор: " + vector.ToString();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string textBox2Value = textBox2.Text.Trim();
            string[] temp2 = textBox2Value.Split(' ');

            string textBox3Value = textBox3.Text.Trim();
            string[] temp3 = textBox3Value.Split(' ');

            if (textBox2Value == "")
            {
                MessageBox.Show("Строка ввода элементов первого вектора не должна быть пустой", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textBox3Value == "")
            {
                MessageBox.Show("Строка ввода элементов второго вектора не должна быть пустой", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            vector1 = new ArrayVector(temp2.Length);
            vector2 = new ArrayVector(temp3.Length);

            for (int i = 0; i < temp2.Length; i++)
            {
                vector1[i] = int.Parse(temp2[i]);
            }

            for (int i = 0; i < temp3.Length; i++)
            {
                vector2[i] = int.Parse(temp3[i]);
            }

            tabControl3.Visible = true;
            label8.Text = "Первый вектор: " + vector1.ToString();
            label9.Text = "Второй вектор: " + vector2.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                ArrayVector sumVector = Vectors.Sum(vector1, vector2); 
                MessageBox.Show($"Сумма векторов: {sumVector}", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                double scalar = Vectors.Scalar(vector1, vector2);
                MessageBox.Show($"Скалярное произведение векторов: {scalar}", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            int num = (int)numericUpDown4.Value;

            // если первый
            if (radioButton3.Checked)
            {
                vector1 = Vectors.MultNumber(vector1, num);
                label8.Text = "Первый вектор: " + vector1.ToString();
            }
            else
            {
                vector2 = Vectors.MultNumber(vector2, num);
                label9.Text = "Второй вектор: " + vector2.ToString();
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
