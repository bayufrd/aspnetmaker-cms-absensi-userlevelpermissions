namespace ASPNETMaker2024.Models;

// Partial class
public partial class project1 {
    /// <summary>
    /// class for table
    /// </summary>
    public class DbTable : DbTableBase
    {
        public string CurrentMode = "view"; // Current mode

        public string UpdateConflict = ""; // Update conflict

        public string EventName = ""; // Event name

        public bool EventCancelled; // Event cancelled

        public string CancelMessage = ""; // Cancel message

        public bool AllowAddDeleteRow = false; // Allow add/delete row

        public bool ValidateKey = true; // Validate key

        public bool DetailAdd; // Allow detail add

        public bool DetailEdit; // Allow detail edit

        public bool DetailView; // Allow detail view

        public bool UseTransaction = Config.UseTransaction; // Use transaction

        public bool ShowMultipleDetails; // Show multiple details

        public int GridAddRowCount; // Number of rows for Grid-Add

        public Dictionary<string, dynamic> CustomActions = new(); // Custom actions

        public bool UseColumnVisibility = false;

        // Constructor
        public DbTable()
        {
        }

        // Display
        public bool IsShow => CurrentAction == "show";

        // Add
        public bool IsAdd => (new [] { "add", "inlineadd" }).Contains(CurrentAction);

        // Copy
        public bool IsCopy => (new [] { "copy", "inlinecopy" }).Contains(CurrentAction);

        // Edit
        public bool IsEdit => (new [] { "edit", "inlineedit" }).Contains(CurrentAction);

        // Delete
        public bool IsDelete => CurrentAction == "delete";

        // Confirm
        public bool IsConfirm => CurrentAction == "confirm";

        // Overwrite
        public bool IsOverwrite => CurrentAction == "overwrite";

        // Cancel
        public bool IsCancel => CurrentAction == "cancel";

        // Grid add
        public bool IsGridAdd => CurrentAction == "gridadd";

        // Grid edit
        public bool IsGridEdit => CurrentAction == "gridedit";

        // Multi edit
        public bool IsMultiEdit => CurrentAction == "multiedit";

        // Add/Copy/Edit/GridAdd/GridEdit
        public bool IsAddOrEdit => IsAdd || IsCopy || IsEdit || IsGridAdd || IsGridEdit || IsMultiEdit;

        // Insert
        public bool IsInsert => (new [] { "insert", "inlineinsert" }).Contains(CurrentAction);

        // Update
        public bool IsUpdate => (new [] { "update", "inlineupdate" }).Contains(CurrentAction);

        // Grid update
        public bool IsGridUpdate => CurrentAction == "gridupdate";

        // Grid insert
        public bool IsGridInsert => CurrentAction == "gridinsert";

        // Multi update
        public bool IsMultiUpdate => CurrentAction == "multiupdate";

        // Grid overwrite
        public bool IsGridOverwrite => CurrentAction == "gridoverwrite";

        // Import
        public bool IsImport => CurrentAction == "import";

        // Search
        public bool IsSearch => CurrentAction == "search";

        // Cancelled
        public bool IsCanceled => LastAction == "cancel" && Empty(CurrentAction);

        // Inline inserted
        public bool IsInlineInserted => (new [] { "insert", "inlineinsert" }).Contains(LastAction) && Empty(CurrentAction);

        // Inline updated
        public bool IsInlineUpdated => (new [] { "update", "inlineupdate" }).Contains(LastAction) && Empty(CurrentAction);

        // Inline edit cancelled
        public bool IsInlineEditCancelled => (new [] { "edit", "inlineedit" }).Contains(LastAction) && Empty(CurrentAction);

        // Grid updated
        public bool IsGridUpdated => LastAction == "gridupdate" && Empty(CurrentAction);

        // Grid inserted
        public bool IsGridInserted => LastAction == "gridinsert" && Empty(CurrentAction);

        // Multi updated
        public bool IsMultiUpdated => LastAction == "multiupdate" && Empty(CurrentAction);

        // Inline-Add row
        public bool IsInlineAddRow => IsAdd && RowType == RowType.Add;

        // Inline-Copy row
        public bool IsInlineCopyRow => IsCopy && RowType == RowType.Add;

        // Inline-Edit row
        public bool IsInlineEditRow => IsEdit && RowType == RowType.Edit;

        // Inline-Add/Copy/Edit row
        public bool IsInlineActionRow => IsInlineAddRow || IsInlineCopyRow || IsInlineEditRow;

        // Export Return Page
        public string ExportReturnUrl
        {
            get => Session.TryGetValue(Config.ProjectName + "_" + TableVar + "_" + Config.TableExportReturnUrl, out string? url) ? url : CurrentPageName();
            set => Session[Config.ProjectName + "_" + TableVar + "_" + Config.TableExportReturnUrl] = value;
        }

        // Records per page
        private int _recordsPerPage = 0; // DN

        public int RecordsPerPage
        {
            get => UseSession ? Session.GetInt(Config.ProjectName + "_" + TableVar + "_" + Config.TableRecordsPerPage) : _recordsPerPage;
            set {
                _recordsPerPage = value;
                Session.SetInt(Config.ProjectName + "_" + TableVar + "_" + Config.TableRecordsPerPage, value);
            }
        }

        // Start record number
        private int _startRecordNumber = 0; // DN

        public int StartRecordNumber
        {
            get => UseSession ? Session.GetInt(Config.ProjectName + "_" + TableVar + "_" + Config.TableStartRec) : _startRecordNumber;
            set {
                _startRecordNumber = value;
                Session.SetInt(Config.ProjectName + "_" + TableVar + "_" + Config.TableStartRec, value);
            }
        }

        // Search Highlight Name
        public string HighlightName => TableVar + "-highlight";

        // Get highlight value
        public string HighlightValue(DbField fld)
        {
            List<string> kwlist = BasicSearch.KeywordList();
            if (Empty(BasicSearch.Type)) // Auto, remove ALL "OR"
                kwlist.Remove("OR");
            List<string> oprs = ["=", "LIKE", "STARTS WITH", "ENDS WITH"]; // Valid operators for highlight
            if (oprs.Contains(fld.AdvancedSearch.GetValue("z"))) {
                string akw = fld.AdvancedSearch.GetValue();
                if (akw.Length > 0)
                    kwlist.Add(akw);
            }
            if (oprs.Contains(fld.AdvancedSearch.GetValue("w"))) {
                string akw = fld.AdvancedSearch.GetValue("y");
                if (akw.Length > 0)
                    kwlist.Add(akw);
            }
            string src = fld.GetViewValue();
            if (kwlist.Count == 0 || Empty(src))
                return src;
            int pos1 = 0;
            int pos2 = 0;
            string val = "";
            string src1 = "";
            foreach (Match match in Regex.Matches(src, @"<([^>]*)>", RegexOptions.IgnoreCase)) {
                pos2 = match.Index;
                if (pos2 > pos1) {
                    src1 = src.Substring(pos1, pos2 - pos1);
                    val += Highlight(kwlist, src1);
                }
                val += match.Value;
                pos1 = pos2 + match.Value.Length;
            }
            pos2 = src.Length;
            if (pos2 > pos1) {
                src1 = src.Substring(pos1, pos2 - pos1);
                val += Highlight(kwlist, src1);
            }
            return val;
        }

        // Highlight keyword
        public string Highlight(List<string> kwlist, string src)
        {
            string pattern = "";
            foreach (var kw in kwlist)
                pattern += (pattern == "" ? "" : "|") + Regex.Escape(kw);
            if (pattern == "")
                return src;
            pattern = "(" + pattern + ")";
            string dest = "<mark class=\"" + PrependClass("mark ew-mark", HighlightName) + "\">$1</mark>";
            src = Config.HighlightCompare
                ? Regex.Replace(src, pattern, dest, RegexOptions.IgnoreCase)
                : src = Regex.Replace(src, pattern, dest);
            return src;
        }

        // Search WHERE clause
        private string _sessionSearchWhere = ""; // DN

        public string SessionSearchWhere
        {
            get => UseSession ? Session.GetString(Config.ProjectName + "_" + TableVar + "_" + Config.TableSearchWhere) : _sessionSearchWhere;
            set {
                _sessionSearchWhere = value;
                Session[Config.ProjectName + "_" + TableVar + "_" + Config.TableSearchWhere] = value;
            }
        }

        // Session WHERE Clause
        private string _sessionWhere = ""; // DN

        public string SessionWhere
        {
            get => UseSession ? Session.GetString(Config.ProjectName + "_" + TableVar + "_" + Config.TableWhere) : _sessionWhere;
            set {
                _sessionWhere = value;
                Session[Config.ProjectName + "_" + TableVar + "_" + Config.TableWhere] = value;
            }
        }

        // Session ORDER BY
        private string _orderBy = ""; // DN

        public string SessionOrderBy
        {
            get => UseSession ? Session.GetString(Config.ProjectName + "_" + TableVar + "_" + Config.TableOrderBy) : _orderBy;
            set {
                _orderBy = value;
                Session[Config.ProjectName + "_" + TableVar + "_" + Config.TableOrderBy] = value;
            }
        }

        // Session layout
        private string _layout = ""; // DN

        public string SessionLayout
        {
            get => UseSession ? Session.GetString(Config.ProjectName + "_" + TableVar + "_" + Config.PageLayout) : _layout;
            set {
                _layout = value;
                Session[Config.ProjectName + "_" + TableVar + "_" + Config.PageLayout] = value;
            }
        }
    }
} // End Partial class
