namespace ASPNETMaker2024.Entities;

/**
 * Entity class for "userlevelpermissions" table
 */
[Table("userlevelpermissions")]
public class _Userlevelpermission
{
    [Key("UserLevelID")]
    public required int UserLevelId { get; set; } = default!;

    [Key("TableName")]
    public required string TableName { get; set; } = default!;

    [Column("Permission")]
    public required int Permission { get; set; } = default!;
}
