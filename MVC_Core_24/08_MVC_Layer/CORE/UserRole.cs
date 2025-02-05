using CORE;
using System.ComponentModel.DataAnnotations.Schema;

public class UserRole
{
    public int Id { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }

    [ForeignKey("Role")]
    public int RoleId { get; set; }

    public Role Role { get; set; }
    public User User { get; set; }

}