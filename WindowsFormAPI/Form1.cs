using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* Web servisler http protokolunu kullanarak hizmet sağlarlar. İstemci yani client istek atar ve bir geri dönüş gerçekleşir.
             * Bu geri dönüşte kullanılan servise göre XML , JSON vb yapılar kullanılır.
             * Burada textboxlar üzerinden girilen veriler alınıp sorgulama yapılır ve geri dönüş tip olarak true yada false olan bool bir değer döndürdük.
             *
             */



            long kimlikNo = long.Parse(txtTc.Text);
            int yil = int.Parse(txtBirthYear.Text);
            bool durum;

            try
            {
                using (TcDogrula.KPSPublicSoapClient service = new TcDogrula.KPSPublicSoapClient {})
                {
                    durum = service.TCKimlikNoDogrula(kimlikNo, txtName.Text, txtSurname.Text, yil);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

            if (durum == true)
            {
                MessageBox.Show("Sorgu başarılı. Bilgiler doğru.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Sorgu başarısız. Bilgiler yanlış.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
