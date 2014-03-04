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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Load("tab1.png");
                     
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //---------------------------------------------------------------------------------------------------------------------
        //Pizza seçimi yapılırken resimlerin değişmesini sağlayan metot
        // (Selecting pizza section method.)
        //---------------------------------------------------------------------------------------------------------------------
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
              //Picture Load--------------------------------------------------------
                if (listBox1.GetSelected(0))
                { 
                        this.pizzaResim.Load("turkish.jpg");
                        jambon.Checked = true; Mantar.Checked = true; Pizzasosu.Checked = true; Sogan.Checked = true;
                        Mozerella.Checked = false; Mısır.Checked = false; Yesilbiber.Checked = false;
                }
                else if (listBox1.GetSelected(1))
                {
                        this.pizzaResim.Load("callypso.jpg");
                        jambon.Checked = false; Mantar.Checked = false; Pizzasosu.Checked = true; Sogan.Checked = false;
                        Mozerella.Checked = false; Mısır.Checked = true; Yesilbiber.Checked = false;
                }
                else if (listBox1.GetSelected(2))
                { 
                        this.pizzaResim.Load("classic.jpg");
                        jambon.Checked = true; Mantar.Checked = true; Pizzasosu.Checked = true; Sogan.Checked = false;
                        Mozerella.Checked = false; Mısır.Checked = true; Yesilbiber.Checked = false;
                }
                else if (listBox1.GetSelected(3))
                { 
                    this.pizzaResim.Load("dominosFarm.jpg");
                    jambon.Checked = false; Mantar.Checked = false; Pizzasosu.Checked = true; Sogan.Checked = true;
                    Mozerella.Checked = true; Mısır.Checked = false; Yesilbiber.Checked = true;
                }
                else if (listBox1.GetSelected(4))
                { 
                    this.pizzaResim.Load("extragavanza.jpg");
                    jambon.Checked = true; Mantar.Checked = true; Pizzasosu.Checked = true; Sogan.Checked = true;
                    Mozerella.Checked = true; Mısır.Checked = false; Yesilbiber.Checked = true;
                }
                else if (listBox1.GetSelected(5))
                { 
                    this.pizzaResim.Load("italiano.jpg");
                    jambon.Checked = true; Mantar.Checked = true; Pizzasosu.Checked = true; Sogan.Checked = false;
                    Mozerella.Checked = false; Mısır.Checked = false; Yesilbiber.Checked = false;
                }
                else if (listBox1.GetSelected(6))
                { 
                    this.pizzaResim.Load("newyork.jpg");
                    jambon.Checked = false; Mantar.Checked = true; Pizzasosu.Checked = false; Sogan.Checked = true;
                    Mozerella.Checked = true; Mısır.Checked = true; Yesilbiber.Checked = false;
                }
                else if (listBox1.GetSelected(7))
                { 
                    this.pizzaResim.Load("spanish.jpg");
                    jambon.Checked = false; Mantar.Checked = true; Pizzasosu.Checked = false; Sogan.Checked = false;
                    Mozerella.Checked = false; Mısır.Checked = true; Yesilbiber.Checked = true;
                }    
        }
         public double total = 0;
         //---------------------------------------------------------------------------------------------------------------------

        //toplam tutarı hesaplamak için kullandığımız metot
        //(this method is using for calculating total cost of order)
         //---------------------------------------------------------------------------------------------------------------------
        public void CalculateCost()
        {
            total = 0;      
            try
            {
                if (comboBox2.SelectedItem.ToString().Trim() == "Küçük") { total += 5; }
                else if (comboBox2.SelectedItem.ToString().Trim() == "Orta") { total += 10; }
                else if (comboBox2.SelectedItem.ToString().Trim() == "Büyük") { total += 12.5; }
                else if (comboBox2.SelectedItem.ToString().Trim() == "Maxi") { total += 15; }
                
            }
            catch (Exception)
            {
                MessageBox.Show(" Lütfen boyut seçimi yapınız!");
            }
           
            
            try
            {
                if (listBox1.SelectedItem.ToString().Trim() == "TURKISH  => (4.50 TL)") { total += 4.50; }
                else if (listBox1.SelectedItem.ToString().Trim() == "CLASSIC   => (7.50 TL)") { total += 7.50; }
                else if (listBox1.SelectedItem.ToString().Trim() == "ITALIANO  => (12.50 TL)") { total += 12.50; }
                else if (listBox1.SelectedItem.ToString().Trim() == "SPANISH  =>  (2.50 TL)") { total += 2.50; }
                else if (listBox1.SelectedItem.ToString().Trim() == "EXTRAVAGANZA  =>  (4.80 TL)") { total += 4.80; }
                else if (listBox1.SelectedItem.ToString().Trim() == "TUNA  =>  (7.40 TL)") { total += 7.40; }
                else if (listBox1.SelectedItem.ToString().Trim() == "SEAFEED  =>  (4.70 TL)") { total += 4.70; }
                else if (listBox1.SelectedItem.ToString().Trim() == "FARM  =>   (2.50 TL)") { total += 2.50; }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Pizza Seçimini Boş Bıraktınız!..","Tamam", MessageBoxButtons.OK);
                
            }          

            try
            {
                int adet = int.Parse(textBox1.Text);
                total = total * adet;

            }
            catch (Exception)
            {
                MessageBox.Show(" Adet Bölümünü Kontrol Ediniz! Varsayılan olarak adet 1 olarak ayarlandı");
                textBox1.Text = "1";
                textBox2.Text = string.Empty;
            }           
          
        }
        //---------------------------------------------------------------------------------------------------------------------
     
        //içecek seçimi yapılan kısım, kontroller mevcut, boş geçildiğinden diyalog açılıp içecek eklenip eklenmeyeceği soruluyor.
        //(selecting drinks section there are some dialogs to ask whether user don't want to buy drink
        //---------------------------------------------------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            CalculateCost();
            bool control = false;
            try
            {
                if (icecek.SelectedItem.ToString().Trim() == "PEPSİ")
                { total += 2.50; }
                else if (icecek.SelectedItem.ToString().Trim() == "FRUKO")
                { total += 2.50; }
                else if (icecek.SelectedItem.ToString().Trim() == "AYRAN")
                { total += 1.50; }
                else if (icecek.SelectedItem.ToString().Trim() == "SODA")
                { total += 1.50; }
                else if (icecek.SelectedItem.ToString().Trim() == "FANTA")
                { total += 2.50; }
                else if (icecek.SelectedItem.ToString().Trim() == "NESTEA")
                { total += 2.50; }
              

            }
            catch (NullReferenceException)
            {

                if (MessageBox.Show("İçecek kısmı boş bırakıldı, İçecek seçimi yapmak ister misiniz?",
                    "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    icecek.Text = string.Empty;
                }
                else
                {
                    control = true;
                }
            }

            if (radioButton2.Checked == true)
            {
                listBox2.Items.Add("Kenar : " + radioButton2.Text);
                total += 5;
            }
            else
            {
                listBox2.Items.Add("Kenar : " + radioButton1.Text);
            }

            
            listBox2.Items.Add(comboBox2.SelectedItem.ToString().Trim());
            listBox2.Items.Add(listBox1.SelectedItem.ToString().Trim());

            try
            {
                listBox2.Items.Add(icecek.SelectedItem.ToString().Trim());
            }
            catch (NullReferenceException)
            {
                //MessageBox.Show(" İçecek satın almak istemediniz!");                
            }

            if (control==true)
            {
                listBox2.Items.Clear();
                total = 0;
            }
            
            textBox2.Text=(total).ToString()+" TL";
            //total = 0;
            label6.Text = "Toplam Tutar: " + total + " TL";
            //---------------------------------------------------------------------------------------------------------------------
            
        }
        public bool flag = false;
        private void listBox1_Click(object sender, EventArgs e)
        {
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            flag = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {                       
        }
        //-----------------------------------
        
        
        //----------------------------------------------------------------------------------
        // Bu metot sepet kısmından eklenen öğeleri silmek için kullanılıyor
        // this method using for deleting items from listbox2.
        //---------------------------------------------------------------------------------------------------------------------
        private void button4_Click(object sender, EventArgs e)
        {
            if (total<0)
            {
                MessageBox.Show(" İstenmeyen Hata oluştu Lütfen seçimlerinizi tekrar yapınız!");
                listBox2.Items.Clear();
            }
            try
            { 
                if ((string)listBox2.SelectedItem=="PEPSİ" ||
                    (string)listBox2.SelectedItem == "FRUKO" ||
                    (string)listBox2.SelectedItem == "FANTA" ||
                    (string)listBox2.SelectedItem == "NESTEA")
                {
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                    total -= 2.50; }

                else if ((string)listBox2.SelectedItem == "AYRAN" ||
                    (string)listBox2.SelectedItem == "SODA")
                
                { 
                    total -= 1.50;
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex); 
                }

                if ((string)listBox2.SelectedItem == "TURKISH  => (4.50 TL)")
                {
                    
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                    total -= 4.50;}

                else if ((string)listBox2.SelectedItem == "CLASSIC   => (7.50 TL)")
                {
                    
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                    total -= 7.50;}

                else if ((string)listBox2.SelectedItem == "ITALIANO  => (12.50 TL)")
                {
                 
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                    total -= 12.50;}

                else if ((string)listBox2.SelectedItem == "SPANISH  =>  (2.50 TL)")
                {
                    
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                    total -= 2.50;}

                else if ((string)listBox2.SelectedItem == "EXTRAVAGANZA  =>  (4.80 TL)")
                {
                
                    total -= 4.80;
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                }
                else if ((string)listBox2.SelectedItem == "TUNA  =>  (7.40 TL)")
                {
             
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                    total -= 7.40;}

                else if ((string)listBox2.SelectedItem == "SEAFEED  =>  (4.70 TL)")
                {
                    
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                    total -= 4.70;}

                else if ((string)listBox2.SelectedItem == "FARM  =>   (2.50 TL)")
                {
                    
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                    total -= 2.50;
                }



                if ((string)listBox2.SelectedItem == "Küçük")
                {
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                    total -= 5;
                }
                else if ((string)listBox2.SelectedItem == "Orta")
                {
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                    total -= 10;
                }
                else if ((string)listBox2.SelectedItem == "Büyük")
                {
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                    total -= 12.50;
                }
                else if ((string)listBox2.SelectedItem == "Maxi")
                {
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                    total -= 15;
                }

                if ((string)listBox2.SelectedItem == "Kenar : " + radioButton2.Text)
                {
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                    total -= 5;
                }
                if ((string)listBox2.SelectedItem == "Kenar : " + radioButton1.Text)
                {
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
              
                }        
                

                
                label6.Text = "Toplam Tutar: " + total + " TL";
                
                
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Sepetiniz Boş!");
            }           
        }
        //---------------------------------------------------------------------------------------------------------------------
        // Siparişin onaylandığı kısım, son formun objesi oluşturulup gösteriliyor, formda siparişin alındığına dair bilgiler yer alıyor.
        // This method to accept pizza order and it provide to access final page.
        //---------------------------------------------------------------------------------------------------------------------
        private void button3_Click(object sender, EventArgs e)
        {           
            if (listBox2.Items==null)
            {
                MessageBox.Show("Sepetiniz Boş!");
            }
            else
            {
                Information inf = new Information();
                inf.Show();
                this.Hide();            
            }
           
        }


        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {          
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //---------------------------------------------------------------------------------------------------------------------
        //İçecek resimlerini load ettiğimiz kısım
        //this method is using for drinks' pictures in to pictureBox1
        //---------------------------------------------------------------------------------------------------------------------
        private void icecek_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (icecek.SelectedItem.ToString().Trim()=="FANTA")
            {
                pictureBox1.Load("fanta.jpg");
            }
            else if (icecek.SelectedItem.ToString().Trim() == "SODA")
            {
                pictureBox1.Load("soda.jpg");
            }
            else if (icecek.SelectedItem.ToString().Trim() == "AYRAN")
            {
                pictureBox1.Load("ayran.jpg");
            }
            else if (icecek.SelectedItem.ToString().Trim() == "NESTEA")
            {
                pictureBox1.Load("nestea.jpg");
            }
            else if (icecek.SelectedItem.ToString().Trim() == "PEPSİ")
            {
                pictureBox1.Load("pepsi.jpg");
            }
            else if (icecek.SelectedItem.ToString().Trim() == "FRUKO")
            {
                pictureBox1.Load("fruko.jpg");
            }
        }

    }
}
