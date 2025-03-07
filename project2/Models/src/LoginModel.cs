namespace ASPNETMaker2024.Models;

// Partial class
public partial class project2 {
    /// <summary>
    /// Login model
    /// </summary>
    public class LoginModel
    {
        [Required]
        public string Username { set; get; } = "";

        [Required]
        public string Password { set; get; } = "";

        public string? SecurityCode { set; get; }

        public int Expire { set; get; } = 0;

        public int Permission { set; get; } = 0;
    }
} // End Partial class
