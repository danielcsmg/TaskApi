
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TaskApi.Auth.Models;

public class User : IdentityUser
{
    public DateTime BirthDate { get; set; }
    public User() : base() { }
}
