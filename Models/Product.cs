using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public string Url { get; set; }
        //public DateTime Date { get; set; }
        //public string MarketName { get; set; }
        //public int Price { get; set; }
        public List<Price> Prices = new List<Price>();
    }
}
