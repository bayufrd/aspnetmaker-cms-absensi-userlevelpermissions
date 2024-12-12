namespace ASPNETMaker2024.Entities;

/**
 * Entity class for "buku_tamu" table
 */
[Table("buku_tamu")]
public class BukuTamu
{
    [Key("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Column("nama")]
    public required string Nama { get; set; } = default!;

    [Column("tanggal_kunjungan")]
    public required DateTime TanggalKunjungan { get; set; } = default!;

    [Column("tujuan")]
    public required string Tujuan { get; set; } = default!;

    [Column("komentar")]
    public required string Komentar { get; set; } = default!;
}
