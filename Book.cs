using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Book
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public decimal Price { get; set; }
    public string Author { get; set; }
    [Required]
    public string ISBN { get; set; }
}