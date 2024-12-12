namespace ASPNETMaker2024.Models;

// Partial class
public partial class project2 {
    /// <summary>
    /// User level permission class
    /// </summary>
    public class UserLevelPermission
    {
        // Table name
        [Column("TableName")]
        public string Table { set; get; } = "";

        // User level ID
        [Column("UserLevelID")]
        public int Id { set; get; }

        // Permission
        [Column("Permission")]
        public int Permission { set; get; } = 0;
    }
} // End Partial class
