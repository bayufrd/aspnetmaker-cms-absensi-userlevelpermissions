namespace ASPNETMaker2024.Models;

// Partial class
public partial class project1 {
    /// <summary>
    /// Report Table base class
    /// </summary>
    public class ReportTable : DbTableBase
    {
        public string ReportSourceTable = "";

        public string ReportSourceTableName = ""; // DN

        public RowSummary RowTotalType; // Row summary type

        public RowTotal RowTotalSubType; // Row total subtype

        public int RowGroupLevel; // Row group level

        public bool ShowReport = true;

        // Constructor
        public ReportTable()
        {
            ShowDrillDownFilter = Config.ShowDrillDownFilter;
            UseDrillDownPanel = Config.UseDrillDownPanel;
        }

        // Group Per Page // DN
        public int GroupPerPage
        {
            get => Session.GetInt(Config.ProjectName + "_" + TableVar + "_" + Config.TableRecordsPerPage);
            set => Session.SetInt(Config.ProjectName + "_" + TableVar + "_" + Config.TableRecordsPerPage, value);
        }

        // Start Group // DN
        public int SessionStartGroup
        {
            get => Session.GetInt(Config.ProjectName + "_" + TableVar + "_" + TableReportType + "_" + Config.TableStartRec);
            set => Session.SetInt(Config.ProjectName + "_" + TableVar + "_" + TableReportType + "_" + Config.TableStartRec, value);
        }

        // Order By
        public string OrderBy
        {
            get => Session.GetString(Config.ProjectName + "_" + TableVar + "_" + Config.TableOrderBy);
            set => Session.SetString(Config.ProjectName + "_" + TableVar + "_" + Config.TableOrderBy, value);
        }

        // Session Order By (for non-grouping fields)
        public string DetailOrderBy
        {
            get => Session.GetString(Config.ProjectName + "_" + TableVar + "_" + Config.TableDetailOrderBy);
            set => Session.SetString(Config.ProjectName + "_" + TableVar + "_" + Config.TableDetailOrderBy, value);
        }

        #pragma warning disable 108
        // Get field object by name
        public ReportField? FieldByName(string name) => (ReportField)Fields.FirstOrDefault(kvp => kvp.Key == name).Value;

        // Get field object by parm
        public ReportField? FieldByParam(string parm) => (ReportField)Fields.FirstOrDefault(kvp => kvp.Value.Param == parm).Value;
        #pragma warning restore 108

        // Row Attribute
        public new string RowAttributes
        {
            get {
                int level = HideGroupLevel;
                bool hide = level > 0;
                if (hide && RowGroupLevel == level && RowType == RowType.Total && RowTotalSubType == RowTotal.Header) // Do not hide current grouping header
                    hide = false;
                if (hide)
                    RowAttrs.AppendClass("ew-rpt-grp-hide-" + level);
                string attrs = base.RowAttributes;
                if (hide)
                    RowAttrs.RemoveClass("ew-rpt-grp-hide-" + level);
                return attrs;
            }
        }

        /**
        * Hide group level
        *
        * @return int Hide group level
        */
        public int HideGroupLevel
        {
            get {
                List<ReportField> rflds = new();
                foreach (ReportField fld in Fields.Values) // Get all grouping fields
                    if (fld.GroupingFieldId > 0)
                        rflds.Add(fld);
                rflds = rflds.OrderBy(rfld => rfld.GroupingFieldId).ToList(); // Sort by GroupingFieldId
                foreach (ReportField fld in rflds)
                    if (!fld.Expanded && fld.GroupingFieldId <= RowGroupLevel)
                        return fld.GroupingFieldId;
                return 0;
            }
        }
    }
} // End Partial class
