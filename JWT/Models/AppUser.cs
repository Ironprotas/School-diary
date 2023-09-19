using JWT.Base;
using JWT.Dto;
using JWT.Models;
using Microsoft.AspNetCore.Identity;
using StackExchange.Redis;
using System.ComponentModel.DataAnnotations.Schema;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public int? ClassId { get; set; }

    public int? WorkClassId { get; set; } // Для учителя

    public  JWT.Models.Class? Class { get; set; }

    public string? ParentId { get; set; }


}


