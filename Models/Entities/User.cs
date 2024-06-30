﻿using System.ComponentModel.DataAnnotations;

namespace De01_Enews.Models.Entities;

public class User
{
    [Key] public int Id { get; set; }

    public string Username { get; set; }

    public string FullName { get; set; }
    
    public string Password { get; set; }
    
    public string Phone { get; set; }
    
    public string Email { get; set; }

    public int RoleId { get; set; }

    
    public virtual Role Role { get; set; }
}