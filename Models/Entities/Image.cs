using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace De01_Enews.Models.Entities;

public class Image
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }
    
    public string Path { get; set; }
    
    [Required]
    [Display(Name = "Article")]
    public int ArticleId { get; set; }

    [ForeignKey("ArticleId")]
    public virtual Article Article { get; set; }
}