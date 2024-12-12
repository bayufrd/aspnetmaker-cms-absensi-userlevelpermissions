namespace ASPNETMaker2024.Models;

// Partial class
public partial class project1 {
    // Configuration
    public static partial class Config
    {
        //
        // ASP.NET Maker 2024 user level settings
        //

        // User level info
        public static List<UserLevel> UserLevels = [
            new() { Id = -2, Name = "Anonymous" }
        ];

        // User level priv info
        public static List<UserLevelPermission> UserLevelPermissions = [
            new() { Table = "{8DD78519-7A1C-4419-9633-452AEF519930}buku_tamu", Id = -2, Permission = 0 }
        ];

        // User level table info // DN
        public static List<UserLevelTablePermission> UserLevelTablePermissions = [
            new() { TableName = "buku_tamu", TableVar = "buku_tamu", Caption = "buku tamu", Allowed = true, ProjectId = "{8DD78519-7A1C-4419-9633-452AEF519930}", Url = "BukuTamuList" }
        ];
    }
} // End Partial class
