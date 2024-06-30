using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using De01_Enews.Models.enums;

namespace De01_Enews.Models.Entities;

public class Article
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [Display(Name = "Category")]
    public int CategoryId { get; set; }
    
    [Required]
    public string Title { get; set; }
    
    [Required]
    [DataType(DataType.Html)]
    public string Content { get; set; }
    
    [Required]
    public string Summary { get; set; }

    [Required]
    [EnumDataType(typeof(ArticleStatus))]
    public ArticleStatus Status { get; set; }
    
    [Required]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy H:mm:ss zzz}", ApplyFormatInEditMode = true)]
    public DateTime PostedAt { get; set; }
    
    
    public virtual List<Image> Images { get; set; }
    
    [ForeignKey("CategoryId")]
    public virtual Category Category { get; set; }
}