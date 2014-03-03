using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PizzaSiparis
{
    public partial class Information : Form
    {
        public Information()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                 if (textBox1.Text!=string.Empty && textBox2.Text!=string.Empty && textBox3.Text!=string.Empty )
                {
                     Final fin = new Final();
                     fin.Show();
                     this.Hide();
                }
                 else
                 {
                     throw new Exception();
                 }

            }
            catch (Exception)
            {
                MessageBox.Show(" Gerekli bilgileri doldurun! ");
            }

            try
            {
                if (textBox3.Text.Length<10)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(" Adres 10 karakterden kısa olamaz! ");
            }
                     
        }
    }
}
