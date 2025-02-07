using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    public int Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public DateTime? DateOfBirth  { get; set; }
    public int? Age {  get; set; }

    public string FacebookUrl { get; set; }

    [NotMapped]
    public string  RoleName { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }


}