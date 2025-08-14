using System;
using System.Data.SqlClient;
namespace CODESFORM

{
    class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=ARDAPOS-1\SQL2019;Initial Catalog=DbLearn;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
// https://localhost:44397/swagger/index.html