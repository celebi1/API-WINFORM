using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using CODESWEBAPI.Models;
using Newtonsoft.Json;

namespace CODESFORM
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient  =new HttpClient();
        public Form1()
        {
            InitializeComponent();
            _httpClient.BaseAddress = new Uri(" https://localhost:44397/");
        }
        sqlbaglantisi sqlbaglantisi = new sqlbaglantisi();
        void PersonelListele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_PERSONELLER", sqlbaglantisi.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;


        }
        void sehirlistesi()
        {
            SqlCommand komut = new SqlCommand("select SEHIR from TBL_ILLER", sqlbaglantisi.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbil.Properties.Items.Add(dr[0]);
            }
            sqlbaglantisi.baglanti().Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           //PersonelListesiGetir();
            //PersonelListele();
            //sehirlistesi();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("insert into TBL_PERSONELLER (AD,SOYAD,TC,TELEFON,MAIL,ADRES,IL,ILCE,GOREV) values " +
                "(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", sqlbaglantisi.baglanti());

            sqlCommand.Parameters.AddWithValue("@p1", txtAd.Text);
            sqlCommand.Parameters.AddWithValue("@p2", txtsoyad.Text);
            sqlCommand.Parameters.AddWithValue("@p3", mskTC.Text);
            sqlCommand.Parameters.AddWithValue("@p4", mskTelefon1.Text);
            sqlCommand.Parameters.AddWithValue("@p5", txtMail.Text);
            sqlCommand.Parameters.AddWithValue("@p6", rchAdres.Text);
            sqlCommand.Parameters.AddWithValue("@p7", cmbil.Text);
            sqlCommand.Parameters.AddWithValue("@p8", cmbilce.Text);
            sqlCommand.Parameters.AddWithValue("@p9", txtGorev.Text);
            sqlCommand.ExecuteNonQuery();
            sqlbaglantisi.baglanti().Close();
            MessageBox.Show("Personel Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            PersonelListele();

        }
        void Temizle()
        {
            Txtid.Text = "";
            txtAd.Text = "";
            txtsoyad.Text = "";
            mskTC.Text = "";
            mskTelefon1.Text = "";
            txtMail.Text = "";
            rchAdres.Text = "";
            cmbil.Text = "";
            cmbilce.Text = "";
            txtGorev.Text = "";
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_PERSONELLER set AD=@p1,SOYAD=@p2,TC=@p3,TELEFON=@p4,MAIL=@p5,ADRES=@p6,IL=@p7,ILCE=@p8,GOREV=@p9 where ID=@p10", sqlbaglantisi.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTC.Text);
            komut.Parameters.AddWithValue("@p4", mskTelefon1.Text);
            komut.Parameters.AddWithValue("@p5", txtMail.Text);
            komut.Parameters.AddWithValue("@p6", rchAdres.Text);
            komut.Parameters.AddWithValue("@p7", cmbil.Text);
            komut.Parameters.AddWithValue("@p8", cmbilce.Text);
            komut.Parameters.AddWithValue("@p9", txtGorev.Text);
            komut.Parameters.AddWithValue("@p10", Txtid.Text);
            komut.ExecuteNonQuery();
            sqlbaglantisi.baglanti().Close();
            MessageBox.Show("Personel Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            PersonelListele();
            Temizle();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("Delete from TBL_PERSONELLER where ID=@p1", sqlbaglantisi.baglanti());
            sqlCommand.Parameters.AddWithValue("@p1", Txtid.Text);
            sqlCommand.ExecuteNonQuery();
            sqlbaglantisi.baglanti().Close();
            MessageBox.Show("Personel Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            PersonelListele();
            Temizle();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();

        }

        private void cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                cmbilce.Properties.Items.Clear();
                SqlCommand komut = new SqlCommand("select ILCE from TBL_ILCELER where SEHIR=@p1", sqlbaglantisi.baglanti());
                komut.Parameters.AddWithValue("@p1", cmbil.SelectedIndex + 1);
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    cmbilce.Properties.Items.Add(dr[0]);
                }
                sqlbaglantisi.baglanti().Close();
            }

        }

        private async void btnGetir_Click(object sender, EventArgs e)
        {
            await PersonelListesiGetir();

        }
        private async Task PersonelListesiGetir()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44397/"); // HTTP portunu kullan
                    client.Timeout = TimeSpan.FromSeconds(30);

                    var response = await client.GetAsync("api/Personel");
                    response.EnsureSuccessStatusCode();

                    var json = await response.Content.ReadAsStringAsync();
                    var personeller = JsonConvert.DeserializeObject<List<Personel>>(json);

                    gridControl1.DataSource = personeller;
                }
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show("HTTP hatası oluştu:\n" + httpEx.ToString());
            }
            catch (Newtonsoft.Json.JsonSerializationException jsonEx)
            {
                MessageBox.Show("JSON işleme hatası:\n" + jsonEx.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmeyen hata:\n" + ex.ToString());
            }
        }



        //private async Task PersonelListesiGetir()
        //{
        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri("http://localhost:44397/"); // API adresin
        //            var response = await client.GetAsync("api/Personel");
        //            response.EnsureSuccessStatusCode();

        //            var json = await response.Content.ReadAsStringAsync();
        //            var personeller = JsonConvert.DeserializeObject<List<Personel>>(json);

        //            gridControl1.DataSource = personeller;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Hata ile karşılaşıldı:\n" + ex.ToString());
        //    }

        //}


    }
}

