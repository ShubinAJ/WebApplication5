using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebApplication5.Models
{
    public class Price
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string MarketName { get; set; }
        public float MarketPrice { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
