namespace ASPNETMaker2024.Entities;

/**
 * Entity class for "absensi" table
 */
[Table("absensi")]
public class Absensi
{
    [Key("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("user_id")]
    public required int UserId { get; set; } = default!;

    [Column("tanggal")]
    public required DateTime Tanggal { get; set; } = default!;

    [Column("jam_masuk")]
    public DateTime? JamMasuk { get; set; }

    [Column("jam_keluar")]
    public DateTime? JamKeluar { get; set; }

    [Column("status")]
    public required string Status { get; set; } = default!;

    [Column("lokasi")]
    public string? Lokasi { get; set; }

    [Column("foto_verifikasi")]
    public string? FotoVerifikasi { get; set; }
}
