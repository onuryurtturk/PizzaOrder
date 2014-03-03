using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace PizzaSiparis
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textBox3.Text == string.Empty))
                {
                   throw new Exception();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(" Kullanıcı Adı Boş Bırakıldı! ");
            }
            try
            {
                if (textBox4.Text == string.Empty)
                {
                    throw new Exception();                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show(" Şifre Girilmeli Boş Bırakılamaz! ");
            }
            if (textBox3.Text != string.Empty && textBox4.Text != string.Empty)
            {
                ((StartPage)Application.OpenForms["StartPage"]).list.Add(textBox3.Text.Trim() + textBox4.Text.Trim());
                MessageBox.Show("Kullanıcı Kayıt Edildi!");
                this.Hide();    
            }            
        }
    }
}
