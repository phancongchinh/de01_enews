using System.ComponentModel.DataAnnotations;

namespace De01_Enews.Models.Entities;

public class Category
{
    [Key]
    public int Id { get; set; }
    
    public int Name { get; set; }
}