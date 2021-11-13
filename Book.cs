using System.ComponentModel.DataAnnotations.Schema;

public class Book
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
}