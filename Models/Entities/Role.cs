using System.ComponentModel.DataAnnotations;

namespace De01_Enews.Models.Entities;

public class Role
{
    [Key] public int Id { get; set; }

    public string Name { get; set; }

    public virtual List<User> Users { get; set; }
}