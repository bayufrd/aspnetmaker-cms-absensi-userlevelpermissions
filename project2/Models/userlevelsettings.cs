namespace ASPNETMaker2024.Models;

// Partial class
public partial class project2 {
    // Configuration
    public static partial class Config
    {
        //
        // ASP.NET Maker 2024 user level settings
        //

        // User level info
        public static List<UserLevel> UserLevels = [
            new() { Id = -2, Name = "Anonymous" },
            new() { Id = 0, Name = "Default" }
        ];

        // User level priv info
        public static List<UserLevelPermission> UserLevelPermissions = [
            new() { Table = "{6B580F13-1C7B-4CD6-99ED-4CAEF98066CD}buku_tamu", Id = -2, Permission = 0 },
            new() { Table = "{6B580F13-1C7B-4CD6-99ED-4CAEF98066CD}buku_tamu", Id = 0, Permission = 0 },
            new() { Table = "{6B580F13-1C7B-4CD6-99ED-4CAEF98066CD}userlevelpermissions", Id = -2, Permission = 0 },
            new() { Table = "{6B580F13-1C7B-4CD6-99ED-4CAEF98066CD}userlevelpermissions", Id = 0, Permission = 0 },
            new() { Table = "{6B580F13-1C7B-4CD6-99ED-4CAEF98066CD}userlevels", Id = -2, Permission = 0 },
            new() { Table = "{6B580F13-1C7B-4CD6-99ED-4CAEF98066CD}userlevels", Id = 0, Permission = 0 },
            new() { Table = "{6B580F13-1C7B-4CD6-99ED-4CAEF98066CD}users", Id = -2, Permission = 0 },
            new() { Table = "{6B580F13-1C7B-4CD6-99ED-4CAEF98066CD}users", Id = 0, Permission = 0 },
            new() { Table = "{6B580F13-1C7B-4CD6-99ED-4CAEF98066CD}absensi", Id = -2, Permission = 0 },
            new() { Table = "{6B580F13-1C7B-4CD6-99ED-4CAEF98066CD}absensi", Id = 0, Permission = 0 }
        ];

        // User level table info // DN
        public static List<UserLevelTablePermission> UserLevelTablePermissions = [
            new() { TableName = "buku_tamu", TableVar = "buku_tamu", Caption = "buku tamu", Allowed = true, ProjectId = "{6B580F13-1C7B-4CD6-99ED-4CAEF98066CD}", Url = "BukuTamuList" },
            new() { TableName = "userlevelpermissions", TableVar = "userlevelpermissions", Caption = "userlevelpermissions", Allowed = true, ProjectId = "{6B580F13-1C7B-4CD6-99ED-4CAEF98066CD}", Url = "UserlevelpermissionsList" },
            new() { TableName = "userlevels", TableVar = "userlevels", Caption = "userlevels", Allowed = true, ProjectId = "{6B580F13-1C7B-4CD6-99ED-4CAEF98066CD}", Url = "UserlevelsList" },
            new() { TableName = "users", TableVar = "users", Caption = "users", Allowed = true, ProjectId = "{6B580F13-1C7B-4CD6-99ED-4CAEF98066CD}", Url = "UsersList" },
            new() { TableName = "absensi", TableVar = "absensi", Caption = "absensi", Allowed = true, ProjectId = "{6B580F13-1C7B-4CD6-99ED-4CAEF98066CD}", Url = "AbsensiList" }
        ];
    }
} // End Partial class
