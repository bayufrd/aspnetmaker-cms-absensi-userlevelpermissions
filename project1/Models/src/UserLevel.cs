namespace ASPNETMaker2024.Models;

// Partial class
public partial class project1 {
    /// <summary>
    /// User level class
    /// </summary>
    public class UserLevel
    {
        // User level ID
        [Column("")]
        public int Id { set; get; }

        // Name
        [Column("")]
        public string Name { set; get; } = "";
    }
} // End Partial class
