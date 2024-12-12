namespace ASPNETMaker2024.Entities;

/**
 * Entity class for "users" table
 */
[Table("users")]
public class _User
{
    [Key("user_id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; } = default!;

    [Column("username")]
    public required string Username { get; set; } = default!;

    [Column("password")]
    public required string Password { get; set; } = default!;

    [Column("email")]
    public string? Email { get; set; }

    [Column("user_level_id")]
    public required int UserLevelId { get; set; } = default!;
}
