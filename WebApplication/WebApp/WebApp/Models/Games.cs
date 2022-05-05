using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Games
    {
            public int ID { get; set; } 
            public string Title { get; set; } 
            public DateTime RelaseDate { get; set; } 
            public string Genre { get; set; } 
            public string Platforms { get; set; } 
            public decimal Price { get; set; }
    }
}
