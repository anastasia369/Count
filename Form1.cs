using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Count
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Введите число:";
            label2.Text = "Введите кол-во знаков после запятой:";
            label3.Text = "Результат: ";
            button1.Text = "Рассчитать";
            button2.Text = "Очистить";
         
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем значения из текстовых полей
                string Number = textBox1.Text;
                int decimalPlaces = int.Parse(textBox2.Text);

                // Преобразуем строку в число
                decimal number = decimal.Parse(Number);

                if (decimalPlaces > 15)
                {
                    MessageBox.Show("Максимальное количество знаков после запятой - 15.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Форматируем число до нужного количества знаков после запятой
                string formattedNumber = Math.Round(number, decimalPlaces).ToString($"F{decimalPlaces}");
                label3.Text = $"Результат: {formattedNumber}";
                listBox1.Items.Add(formattedNumber);
            }

            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректное число и количество знаков после запятой.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
