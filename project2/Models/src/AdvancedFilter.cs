namespace ASPNETMaker2024.Models;

// Partial class
public partial class project2 {
    /// <summary>
    /// Advanced filter class
    /// </summary>
    public class AdvancedFilter
    {
        public string ID;

        public string Name;

        public string MethodName;

        public bool Enabled = true;

        public AdvancedFilter(string id, string name, string methodName)
        {
            ID = id;
            Name = name;
            MethodName = methodName;
        }
    }
} // End Partial class
