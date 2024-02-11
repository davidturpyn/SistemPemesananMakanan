using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace SistemPemesananMakanan.Models
{
    public class Pesanan
    {
        [Key]
        public int Id { get; set; }
        public string NomorPesanan { get; set; }
        public int NomorMeja { get; set; }
        public int MakananId { get; set; }
        public int MinumanId { get; set; }
        public string Status { get; set; }
        public string? createdBy { get; set; }
        public DateTime? createdDate { get; set; }
        public string? updatedBy { get; set; }
        public DateTime? updatedDate { get; set; }
        public string? deletedBy { get; set; }
        public DateTime? deletedDate { get; set; }
    }
}
