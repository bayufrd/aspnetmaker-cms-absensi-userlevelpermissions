namespace ASPNETMaker2024.Models;

// Partial class
public partial class project1 {
    /// <summary>
    /// Sub page class
    /// </summary>
    public class SubPage
    {
        public bool Active = false;

        public bool Visible = true; // If false, add class "d-none", for tabs/pills only

        public bool Disabled = false; // If true, add class "disabled", for tabs/pills only
    }
} // End Partial class
