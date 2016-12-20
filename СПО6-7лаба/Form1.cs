using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace СПО6_7лаба
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        string text;

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            text = textBox1.Text;
            if (text != "")
            {
                string[] rules = Sintaxis(text);
                if(rules[1] == "true")
                {
                    string[] array_elements = text.Split(' ');
                    string table_leksema = Leksika(array_elements, text);
                    textBox2.Text = table_leksema;
                }
                else
                {
                    textBox2.Text = rules[0];
                }
                
            }
            else { MessageBox.Show("Ошибка! Введите логическую операцию");  }
            
        }
        string[] Sintaxis(string text_original)
        {
            string[] mas_rules = new string[2];

            string[] mas_elem = text_original.Split(' ');
            mas_rules[1] = "true";
            if ((mas_elem[0] != "string"))
            {

                mas_rules[0] = "неправильный тип данных" + Environment.NewLine;
                mas_rules[1] = "false";
            }
            
           
            if (mas_elem.Length <= 2)
            {
                mas_rules[0] += "неполное логическое выражение";
                mas_rules[1] = "false";
               
            }

            if (mas_rules[1] != "false")
            {

                if (mas_elem[4] != "or") 
                {
                    if  (mas_elem[4] != "xor")

                        if (mas_elem[4] != "and")
                            if  (mas_elem[4] != "not")
                            {
                                mas_rules[0] = "нет логической операции";
                                mas_rules[1] = "false";
                            }
                }
                else
                    if (mas_elem[mas_elem.Length - 1] != ";")
                        {
                            mas_rules[0] = " Строка должна завершаться ;";
                            mas_rules[1] = "false";
                        }
            }
           return mas_rules;
        }
        string Leksika(string[] mas_elem, string text_original)
        {
            string leksema = "";
            for (int i = 0; i < mas_elem.Length; i++)
            {
                if ((mas_elem[i] == "string") || (mas_elem[i] == "char"))
                {
                    leksema += mas_elem[i] + "  тип данных " + Environment.NewLine;
                    leksema += mas_elem[i + 1] + " идентификатор" + Environment.NewLine;
                    i++;
                }
                else if ((mas_elem[i] == "or") || (mas_elem[i] == "xor") || (mas_elem[i] == "and") || (mas_elem[i] == "not"))
                {
                    leksema += mas_elem[i] + "  логическая операция " + Environment.NewLine;
                }
                else if (mas_elem[i] == "=")
                {
                    leksema += mas_elem[i] + "  знак сравнения " + Environment.NewLine;
                }
                else if (mas_elem[i] == ";")
                {
                    leksema += mas_elem[i] + "  разделитель " + Environment.NewLine;
                }
                else leksema += mas_elem[i] + "  значение " + Environment.NewLine;
            }
            leksema += "***********************************************************" + Environment.NewLine;
            leksema += "Логическое выражение: операнд и выражение, ключевое слово" + Environment.NewLine;
            mas_elem = text_original.Split('=');
            leksema += "Oперанд -> " + mas_elem[0].Split(' ')[1].ToString() + Environment.NewLine;
            leksema += "Выражение -> " + mas_elem[1].ToString() + Environment.NewLine;
            leksema += "Ключевое слово -> " + mas_elem[1].Split(' ')[2].ToString() + Environment.NewLine;

            return leksema;
        }
    }
}
