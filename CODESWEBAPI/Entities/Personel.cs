using System.ComponentModel.DataAnnotations.Schema;

namespace CODESWEBAPI.Models
{
    [Table("Personels")]
    public class Personel
    {
        public int ID { get; set; }          // Primary Key
        public string AD { get; set; }
        public string SOYAD { get; set; }
        public string TELEFON { get; set; }
        public string TC { get; set; }
        public string MAIL { get; set; }
        public string IL { get; set; }
        public string ILCE { get; set; }
        public string ADRES { get; set; }
        public string GOREV { get; set; }
    }
}
