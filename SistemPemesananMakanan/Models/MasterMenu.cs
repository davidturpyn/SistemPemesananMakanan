using System.ComponentModel.DataAnnotations;

namespace SistemPemesananMakanan.Models
{
    public class MasterMenu
    {
        [Key]
        public Int32 Id { get; set; }
        public string Nama { get; set; }
        public string Jenis { get; set; }
        public int Harga { get; set; }
        public string Status { get; set; }
        public string? createdBy { get; set; }
        public DateTime? createdDate { get; set; }
        public string? updatedBy { get; set; }
        public DateTime? updatedDate { get; set; }
        public string? deletedBy { get; set; }
        public DateTime? deletedDate { get; set; }
    }
}
