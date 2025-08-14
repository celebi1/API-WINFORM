using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace CodesPanelWEBAPI
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

Scaffold - DbContext "Server=ARDAPOS-1\\SQL2019;Database=DbLearn;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer - OutputDir Models - Context MyDbContext
