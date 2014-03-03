using System;
using System.Collections;
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
    public partial class StartPage : Form
    {
        public StartPage()
        {
            InitializeComponent();
        }

        //kullanıcı girişi için arraylist
        // arraylist for user interface
        public ArrayList list = new ArrayList();
        
        //giriş şifre-kullanıcı adı kontrol
        // controlling sync
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if ((textBox1.Text.Trim() + textBox2.Text.Trim()) == (string)list[i])
                {
                    MessageBox.Show("Giriş Başarılı");
                    Form1 main = new Form1();
                    this.Hide();
                    main.Show();
                    break;
                }
                else
                {
                    MessageBox.Show("Kayıt Bulunamadı");
                }
            }
          

        }
        //Yeni kayıt oluşturmak için butona bağlanan form object i oluşturma kısmı
        private void button2_Click(object sender, EventArgs e)
        {
            Register reg = new Register();
            reg.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
