using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodesPanelWEBAPI
{
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        //sqlbaglantisi bgl = new sqlbaglantisi();
        sqlbaglantisi sqlbaglantisi = new sqlbaglantisi();
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            sehirlistesi();
            PersonelListele();
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
        void PersonelListele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_PERSONELLER", sqlbaglantisi.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;


        }
    }
}
