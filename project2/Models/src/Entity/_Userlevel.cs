namespace ASPNETMaker2024.Entities;

/**
 * Entity class for "userlevels" table
 */
[Table("userlevels")]
public class _Userlevel
{
    [Key("UserLevelID")]
    public required int UserLevelId { get; set; } = default!;

    [Column("UserLevelName")]
    public required string UserLevelName { get; set; } = default!;
}
