using ADG.JQueryExtenders.Impromptu;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PresentationLayer_TCS_SetupResultAnnouncement : Page
{
    private static readonly int[] AllowedTermGroupIds = { 1, 2, 3 };

    private const string SelectListSql =
        "SELECT rad.Id, rad.Session_Id, " +
        "ISNULL((SELECT TOP 1 sess.Description FROM dbo.Session sess WHERE sess.Session_Id = rad.Session_Id), CAST(rad.Session_Id AS NVARCHAR(20))) AS Session_Name, " +
        "rad.TermGroup_Id, " +
        "CASE rad.TermGroup_Id WHEN 1 THEN N'First Term' WHEN 2 THEN N'Second Term' WHEN 3 THEN N'Mock Exam' ELSE CAST(rad.TermGroup_Id AS NVARCHAR(20)) END AS Term_Name, " +
        "rad.Class_Id, " +
        "ISNULL((SELECT TOP 1 c.Class_Name FROM dbo.Class c WHERE c.Class_Id = rad.Class_Id), N'All Classes') AS Class_Name, " +
        "rad.AnnouncementDateTime, rad.Description, rad.IsActive, rad.CreatedDate, rad.ModifiedDate " +
        "FROM dbo.ResultAnnouncementDates rad " +
        "WHERE rad.Session_Id = @Session_Id AND rad.TermGroup_Id = @TermGroup_Id " +
        "ORDER BY rad.Class_Id ASC, rad.AnnouncementDateTime DESC, rad.Id DESC";

    private DALBase objBase;

    private static void ShowPopup(string message)
    {
        if (string.IsNullOrEmpty(message))
            return;

        string safeMessage = message.Replace("\\", "\\\\").Replace("'", "\\'").Replace("\r", " ").Replace("\n", " ");
        ImpromptuHelper.ShowPrompt(safeMessage);
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        objBase = new DALBase();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ContactID"] == null)
        {
            Response.Redirect("~/Login.aspx", false);
            return;
        }

        if (IsPostBack)
        {
            EnsureSessionFilterOnPostBack();
        }
        else
        {
            try
            {
                ApplyPageAccess();
                FillSessions();
                FillTermGroups();
                FillClasses();
                FillActiveFilter();
                CopyFilterToModalDropdowns();
                BindGrid();
            }
            catch (Exception ex)
            {
                ShowPopup("Page load error: " + ex.Message);
                pnlGrid.Visible = false;
            }
            return;
        }

        CopyFilterToModalDropdowns();
    }

    private void EnsureSessionFilterOnPostBack()
    {
        int sessionId;
        if (TryGetSessionFilterId(out sessionId))
            return;

        BLLSession sessionBll = new BLLSession();
        DataTable allSessions = sessionBll.SessionSelectAllActive();
        DataRow currentSession = GetCurrentActiveSessionRow(allSessions);
        BindSingleSessionDropDown(ddlSession, currentSession, false);
        if (!HasSelectedValue(ddlModalSession))
            BindSingleSessionDropDown(ddlModalSession, currentSession, true);
        SyncSessionHiddenField();
    }

    private void ApplyPageAccess()
    {
        DataRow row = (DataRow)Session["rightsRow"];
        if (row == null)
            return;

        string pageFile = new System.IO.FileInfo(Request.Url.AbsolutePath).Name;
        DataTable settings = objBase.ApplyPageAccessSettingsTable(pageFile, Convert.ToInt32(row["User_Type_Id"]));

        if (settings == null || settings.Rows.Count == 0)
            return;

        Title = settings.Rows[0]["PageTitle"].ToString();
        lblHeading.Text = settings.Rows[0]["PageCaption"].ToString();
        if (!Convert.ToBoolean(settings.Rows[0]["isAllow"]))
        {
            Session.Abandon();
            Response.Redirect("~/Login.aspx", false);
        }
    }

    protected void FilterChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void btnClearFilters_Click(object sender, EventArgs e)
    {
        if (ddlClassFilter.Items.Count > 0)
            ddlClassFilter.SelectedValue = "0";
        if (ddlActiveFilter.Items.Count > 0)
            ddlActiveFilter.SelectedValue = "-1";
        ApplyDefaultTermSelection(ddlTerm);
        BindGrid();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ResetModalForm();
        upModal.Update();
        ScriptManager.RegisterStartupScript(Page, GetType(), "showModal", "$('#myModal').modal('show');", true);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (!HasSelectedValue(ddlModalSession) || !HasSelectedValue(ddlModalTerm))
            {
                ShowPopup("Please select Session and Term.");
                ScriptManager.RegisterStartupScript(Page, GetType(), "showModalSave", "$('#myModal').modal('show'); resetSaveButton();", true);
                return;
            }

            DateTime announcementDt;
            if (!TryParseAnnouncementDateTime(txtAnnouncementDate.Text, txtAnnouncementTime.Text, out announcementDt))
            {
                ShowPopup("Please enter a valid announcement date and time.");
                ScriptManager.RegisterStartupScript(Page, GetType(), "showModalSave2", "$('#myModal').modal('show'); resetSaveButton();", true);
                return;
            }

            int sessionId = Convert.ToInt32(ddlModalSession.SelectedValue, CultureInfo.InvariantCulture);
            int termGroupId = Convert.ToInt32(ddlModalTerm.SelectedValue, CultureInfo.InvariantCulture);
            string description = string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text.Trim();
            bool isActive = chkIsActive.Checked;
            int recordId = Convert.ToInt32(hfId.Value, CultureInfo.InvariantCulture);

            if (recordId > 0)
            {
                SaveEditedAnnouncement(recordId, sessionId, termGroupId, announcementDt, description, isActive);
            }
            else
            {
                SaveNewAnnouncements(sessionId, termGroupId, announcementDt, description, isActive);
            }

            ddlTerm.SelectedValue = termGroupId.ToString(CultureInfo.InvariantCulture);
            hfSessionId.Value = sessionId.ToString(CultureInfo.InvariantCulture);
            ResetModalForm();
            BindGrid();
            UpdatePanel1.Update();
            upModal.Update();
            ScriptManager.RegisterStartupScript(Page, GetType(), "hideModal", "$('#myModal').modal('hide'); resetSaveButton();", true);
        }
        catch (Exception ex)
        {
            ShowPopup("Save failed: " + ex.Message);
            ScriptManager.RegisterStartupScript(Page, GetType(), "showModalErr", "$('#myModal').modal('show'); resetSaveButton();", true);
        }
    }

    private void SaveNewAnnouncements(int sessionId, int termGroupId, DateTime announcementDt, string description, bool isActive)
    {
        int? classId = ParseOptionalClassId(ddlModalClass.SelectedValue);
        List<int> classIds = GetClassIdsForInsert(classId);
        if (classIds.Count == 0)
            throw new InvalidOperationException("No classes available to save.");

        List<string> duplicateClasses = new List<string>();
        int insertedCount = 0;

        for (int i = 0; i < classIds.Count; i++)
        {
            int currentClassId = classIds[i];
            if (AnnouncementExists(sessionId, termGroupId, currentClassId, 0))
            {
                duplicateClasses.Add(GetClassDisplayName(currentClassId));
                continue;
            }

            int newId = InsertAnnouncement(sessionId, termGroupId, currentClassId, announcementDt, description, isActive);
            if (newId > 0)
                insertedCount++;
        }

        if (insertedCount <= 0)
        {
            if (duplicateClasses.Count > 0)
                throw new InvalidOperationException("Announcement date already exists for: " + string.Join(", ", duplicateClasses.ToArray()) + ".");
            throw new InvalidOperationException("No record was inserted.");
        }

        if (duplicateClasses.Count > 0)
        {
            ShowPopup(
                insertedCount.ToString(CultureInfo.InvariantCulture) + " record(s) added. Skipped existing class(es): "
                + string.Join(", ", duplicateClasses.ToArray()) + ".");
            return;
        }

        if (insertedCount == 1)
            ShowPopup("Record added successfully.");
        else
            ShowPopup(insertedCount.ToString(CultureInfo.InvariantCulture) + " records added successfully (one per class).");
    }

    private void SaveEditedAnnouncement(int recordId, int sessionId, int termGroupId, DateTime announcementDt, string description, bool isActive)
    {
        int? classId = ParseOptionalClassId(ddlModalClass.SelectedValue);
        if (!classId.HasValue || classId.Value <= 0)
            throw new InvalidOperationException("Please select a class for edit.");

        if (AnnouncementExists(sessionId, termGroupId, classId.Value, recordId))
            throw new InvalidOperationException("An announcement date already exists for the selected session, term and class.");

        int rows = UpdateAnnouncement(recordId, sessionId, termGroupId, classId.Value, announcementDt, description, isActive);
        if (rows <= 0)
            throw new InvalidOperationException("No record was updated.");

        ShowPopup("Record updated successfully.");
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton btn = sender as LinkButton;
            if (btn == null || string.IsNullOrWhiteSpace(btn.CommandArgument))
            {
                ShowPopup("Record not found.");
                return;
            }

            int id = Convert.ToInt32(btn.CommandArgument, CultureInfo.InvariantCulture);
            DataRow row = SelectAnnouncementById(id);
            if (row == null)
            {
                ShowPopup("Record not found.");
                return;
            }

            hfId.Value = id.ToString(CultureInfo.InvariantCulture);
            lblModalTitle.Text = "Edit Result Announcement Dates";
            btnSave.Text = "Update";

            SetDropDownValue(ddlModalSession, row["Session_Id"]);
            SetDropDownValue(ddlModalTerm, row["TermGroup_Id"]);
            if (row["Class_Id"] == DBNull.Value)
                ddlModalClass.SelectedValue = "0";
            else
                SetDropDownValue(ddlModalClass, row["Class_Id"]);

            DateTime announcementDt = Convert.ToDateTime(row["AnnouncementDateTime"], CultureInfo.InvariantCulture);
            txtAnnouncementDate.Text = announcementDt.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            txtAnnouncementTime.Text = announcementDt.ToString("HH:mm", CultureInfo.InvariantCulture);
            txtDescription.Text = row["Description"] == DBNull.Value ? string.Empty : row["Description"].ToString();
            chkIsActive.Checked = row["IsActive"] != DBNull.Value && Convert.ToBoolean(row["IsActive"]);

            upModal.Update();
            ScriptManager.RegisterStartupScript(Page, GetType(), "showModalEdit", "$('#myModal').modal('show'); resetSaveButton();", true);
        }
        catch (Exception ex)
        {
            ShowPopup("Unable to load record: " + ex.Message);
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton btn = sender as LinkButton;
            if (btn == null || string.IsNullOrWhiteSpace(btn.CommandArgument))
            {
                ShowPopup("Record could not be deleted.");
                return;
            }

            int id = Convert.ToInt32(btn.CommandArgument, CultureInfo.InvariantCulture);
            int rows = DeleteAnnouncement(id);
            if (rows <= 0)
            {
                ShowPopup("Record could not be deleted.");
                return;
            }

            BindGrid();
            UpdatePanel1.Update();
            ShowPopup("Record deleted successfully.");
        }
        catch (Exception ex)
        {
            ShowPopup("Delete failed: " + ex.Message);
        }
    }

    protected void gvAnnouncements_PreRender(object sender, EventArgs e)
    {
        if (gvAnnouncements.Rows.Count > 0)
        {
            gvAnnouncements.UseAccessibleHeader = true;
            gvAnnouncements.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    private void BindGrid()
    {
        int sessionId;
        int termId;
        if (!TryGetSessionFilterId(out sessionId) || !TryGetTermFilterId(out termId))
        {
            pnlGrid.Visible = false;
            lblEmptyGrid.Visible = false;
            gvAnnouncements.DataSource = null;
            gvAnnouncements.DataBind();
            return;
        }

        try
        {
            int classId;
            int activeFilter;
            GetClassFilterId(out classId);
            GetActiveFilterValue(out activeFilter);

            DataTable dt = SelectAnnouncements(sessionId, termId);
            dt = ApplyGridFilters(dt, classId, activeFilter);

            gvAnnouncements.DataSource = dt;
            gvAnnouncements.DataBind();
            pnlGrid.Visible = true;
            lblEmptyGrid.Visible = dt == null || dt.Rows.Count == 0;
        }
        catch (Exception ex)
        {
            pnlGrid.Visible = false;
            lblEmptyGrid.Visible = false;
            gvAnnouncements.DataSource = null;
            gvAnnouncements.DataBind();
            ShowPopup("Unable to load announcements. Details: " + ex.Message);
        }
    }

    private void FillSessions()
    {
        BLLSession sessionBll = new BLLSession();
        DataTable allSessions = sessionBll.SessionSelectAllActive();
        DataRow currentSession = GetCurrentActiveSessionRow(allSessions);

        BindSingleSessionDropDown(ddlSession, currentSession, false);
        BindSingleSessionDropDown(ddlModalSession, currentSession, true);
        SyncSessionHiddenField();
    }

    private void FillTermGroups()
    {
        BLLEvaluation_Criteria_Type ect = new BLLEvaluation_Criteria_Type();
        DataTable allTerms = ect.Evaluation_Criteria_TypeFetch(ect);
        DataTable allowedTerms = FilterAllowedTermGroups(allTerms);

        BindTermDropDown(ddlTerm, allowedTerms);
        BindTermDropDown(ddlModalTerm, allowedTerms);
        ApplyDefaultTermSelection(ddlTerm);
        ApplyDefaultTermSelection(ddlModalTerm);
    }

    private static DataRow GetCurrentActiveSessionRow(DataTable sessions)
    {
        if (sessions == null || sessions.Rows.Count == 0)
            return null;

        foreach (DataRow row in sessions.Rows)
        {
            string status = Convert.ToString(row["Status_Id"], CultureInfo.InvariantCulture);
            if (status == "1")
                return row;
        }

        return sessions.Rows[0];
    }

    private static void BindSingleSessionDropDown(DropDownList ddl, DataRow sessionRow, bool enabled)
    {
        ddl.Items.Clear();
        ddl.Enabled = enabled;

        if (sessionRow == null)
        {
            ddl.Items.Add(new ListItem("No active session", "0"));
            return;
        }

        string sessionId = Convert.ToString(GetColumnValue(sessionRow, "Session_Id", "Session_ID"), CultureInfo.InvariantCulture);
        string description = Convert.ToString(GetColumnValue(sessionRow, "Description", "Session_Name"), CultureInfo.InvariantCulture);
        ddl.Items.Add(new ListItem(description, sessionId));
        ddl.SelectedIndex = 0;
    }

    private static DataTable FilterAllowedTermGroups(DataTable source)
    {
        DataTable result = source != null ? source.Clone() : new DataTable();
        if (source == null || source.Rows.Count == 0)
            return result;

        List<DataRow> rows = new List<DataRow>();
        HashSet<int> seenTermIds = new HashSet<int>();
        foreach (DataRow row in source.Rows)
        {
            int termGroupId;
            if (!int.TryParse(Convert.ToString(row["TermGroup_Id"], CultureInfo.InvariantCulture), NumberStyles.Integer, CultureInfo.InvariantCulture, out termGroupId))
                continue;

            if (Array.IndexOf(AllowedTermGroupIds, termGroupId) < 0)
                continue;

            if (!seenTermIds.Add(termGroupId))
                continue;

            rows.Add(row);
        }

        rows.Sort(delegate(DataRow a, DataRow b)
        {
            int idA = Convert.ToInt32(a["TermGroup_Id"], CultureInfo.InvariantCulture);
            int idB = Convert.ToInt32(b["TermGroup_Id"], CultureInfo.InvariantCulture);
            return idA.CompareTo(idB);
        });

        foreach (DataRow row in rows)
            result.ImportRow(row);

        return result;
    }

    private static void BindTermDropDown(DropDownList ddl, DataTable terms)
    {
        ddl.Items.Clear();
        if (terms == null || terms.Rows.Count == 0)
        {
            ddl.Items.Add(new ListItem("No terms available", "0"));
            return;
        }

        HashSet<string> addedTermIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (DataRow row in terms.Rows)
        {
            string termId = Convert.ToString(row["TermGroup_Id"], CultureInfo.InvariantCulture);
            if (!addedTermIds.Add(termId))
                continue;

            string termName = NormalizeTermDisplayName(Convert.ToString(row["Type"], CultureInfo.InvariantCulture));
            ddl.Items.Add(new ListItem(termName, termId));
        }
    }

    private static string NormalizeTermDisplayName(string termType)
    {
        if (string.IsNullOrWhiteSpace(termType))
            return string.Empty;

        string trimmed = termType.Trim();
        if (trimmed.Equals("Mock Examination", StringComparison.OrdinalIgnoreCase))
            return "Mock Exam";
        return trimmed;
    }

    private static void ApplyDefaultTermSelection(DropDownList ddl)
    {
        if (ddl == null || ddl.Items.Count == 0)
            return;

        DateTime now = DateTime.Now;
        string defaultTermId = (now.Month >= 3 && now.Month <= 7) ? "2" : "1";
        if (ddl.Items.FindByValue(defaultTermId) != null)
            ddl.SelectedValue = defaultTermId;
        else
            ddl.SelectedIndex = 0;
    }

    private static object GetColumnValue(DataRow row, params string[] columnNames)
    {
        if (row == null || row.Table == null)
            return string.Empty;

        foreach (string columnName in columnNames)
        {
            if (row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value)
                return row[columnName];
        }

        return string.Empty;
    }

    private static bool HasSelectedValue(ListControl control)
    {
        return control != null
            && !string.IsNullOrWhiteSpace(control.SelectedValue)
            && control.SelectedValue != "0";
    }

    private void SyncSessionHiddenField()
    {
        if (HasSelectedValue(ddlSession))
            hfSessionId.Value = ddlSession.SelectedValue;
        else if (HasSelectedValue(ddlModalSession))
            hfSessionId.Value = ddlModalSession.SelectedValue;
        else
            hfSessionId.Value = "0";
    }

    private bool TryGetSessionFilterId(out int sessionId)
    {
        sessionId = 0;
        string rawValue = !string.IsNullOrWhiteSpace(hfSessionId.Value) && hfSessionId.Value != "0"
            ? hfSessionId.Value
            : HasSelectedValue(ddlSession) ? ddlSession.SelectedValue : null;

        if (string.IsNullOrWhiteSpace(rawValue))
            return false;

        if (!int.TryParse(rawValue, NumberStyles.Integer, CultureInfo.InvariantCulture, out sessionId) || sessionId <= 0)
            return false;

        hfSessionId.Value = sessionId.ToString(CultureInfo.InvariantCulture);
        return true;
    }

    private bool TryGetTermFilterId(out int termId)
    {
        termId = 0;
        if (!HasSelectedValue(ddlTerm))
            return false;

        return int.TryParse(ddlTerm.SelectedValue, NumberStyles.Integer, CultureInfo.InvariantCulture, out termId)
            && termId > 0;
    }

    private void FillClasses()
    {
        BLLClass classBll = new BLLClass();
        DataTable dt = classBll.ClassFetch(classBll);

        ddlModalClass.Items.Clear();
        ddlModalClass.Items.Add(new ListItem("All Classes", "0"));

        ddlClassFilter.Items.Clear();
        ddlClassFilter.Items.Add(new ListItem("All Classes", "0"));

        if (dt != null)
        {
            foreach (DataRow r in dt.Rows)
            {
                string classId = r["Class_Id"].ToString();
                string className = r["Class_Name"].ToString();
                ddlModalClass.Items.Add(new ListItem(className, classId));
                ddlClassFilter.Items.Add(new ListItem(className, classId));
            }
        }
    }

    private void FillActiveFilter()
    {
        ddlActiveFilter.Items.Clear();
        ddlActiveFilter.Items.Add(new ListItem("All", "-1"));
        ddlActiveFilter.Items.Add(new ListItem("Active", "1"));
        ddlActiveFilter.Items.Add(new ListItem("Inactive", "0"));
        ddlActiveFilter.SelectedValue = "-1";
    }

    private void GetClassFilterId(out int classId)
    {
        classId = 0;
        int parsedClassId;
        if (ddlClassFilter != null
            && !string.IsNullOrWhiteSpace(ddlClassFilter.SelectedValue)
            && int.TryParse(ddlClassFilter.SelectedValue, NumberStyles.Integer, CultureInfo.InvariantCulture, out parsedClassId)
            && parsedClassId > 0)
        {
            classId = parsedClassId;
        }
    }

    private void GetActiveFilterValue(out int activeFilter)
    {
        activeFilter = -1;
        int parsedActiveFilter;
        if (ddlActiveFilter != null
            && !string.IsNullOrWhiteSpace(ddlActiveFilter.SelectedValue)
            && int.TryParse(ddlActiveFilter.SelectedValue, NumberStyles.Integer, CultureInfo.InvariantCulture, out parsedActiveFilter)
            && (parsedActiveFilter == 0 || parsedActiveFilter == 1))
        {
            activeFilter = parsedActiveFilter;
        }
    }

    private void ResetModalForm()
    {
        hfId.Value = "0";
        lblModalTitle.Text = "Add Result Announcement Dates";
        btnSave.Text = "Save";
        CopyFilterToModalDropdowns();

        if (ddlClassFilter != null && ddlClassFilter.SelectedValue != "0")
            SetDropDownValue(ddlModalClass, ddlClassFilter.SelectedValue);
        else if (ddlModalClass.Items.Count > 0)
            ddlModalClass.SelectedValue = "0";

        txtAnnouncementDate.Text = string.Empty;
        txtAnnouncementTime.Text = string.Empty;
        txtDescription.Text = string.Empty;
        chkIsActive.Checked = true;
    }

    private List<int> GetClassIdsForInsert(int? selectedClassId)
    {
        List<int> classIds = new List<int>();

        if (selectedClassId.HasValue && selectedClassId.Value > 0)
        {
            classIds.Add(selectedClassId.Value);
            return classIds;
        }

        for (int i = 0; i < ddlModalClass.Items.Count; i++)
        {
            int classId;
            if (int.TryParse(ddlModalClass.Items[i].Value, NumberStyles.Integer, CultureInfo.InvariantCulture, out classId)
                && classId > 0)
            {
                classIds.Add(classId);
            }
        }

        return classIds;
    }

    private string GetClassDisplayName(int classId)
    {
        string classIdText = classId.ToString(CultureInfo.InvariantCulture);
        ListItem item = ddlModalClass.Items.FindByValue(classIdText);
        if (item != null && !string.IsNullOrWhiteSpace(item.Text))
            return item.Text;
        return classIdText;
    }

    private void CopyFilterToModalDropdowns()
    {
        if (HasSelectedValue(ddlSession))
            ddlModalSession.SelectedValue = ddlSession.SelectedValue;
        if (HasSelectedValue(ddlTerm))
            ddlModalTerm.SelectedValue = ddlTerm.SelectedValue;
    }

    private static void SetDropDownValue(DropDownList ddl, object value)
    {
        string s = Convert.ToString(value, CultureInfo.InvariantCulture);
        if (ddl.Items.FindByValue(s) != null)
            ddl.SelectedValue = s;
    }

    private static int? ParseOptionalClassId(string value)
    {
        int classId;
        if (!int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out classId) || classId <= 0)
            return null;
        return classId;
    }

    private static bool TryParseAnnouncementDateTime(string dateText, string timeText, out DateTime result)
    {
        result = DateTime.MinValue;
        if (string.IsNullOrWhiteSpace(dateText))
            return false;

        string dateTrim = dateText.Trim();
        string timeTrim = string.IsNullOrWhiteSpace(timeText) ? string.Empty : timeText.Trim();
        string combined = string.IsNullOrEmpty(timeTrim) ? dateTrim : dateTrim + " " + timeTrim;

        DateTime parsed;
        string[] dateFormats =
        {
            "yyyy-MM-dd", "dd/MM/yyyy", "d/M/yyyy", "MM/dd/yyyy", "M/d/yyyy"
        };
        string[] dateTimeFormats =
        {
            "yyyy-MM-dd HH:mm", "yyyy-MM-dd H:mm", "yyyy-MM-dd hh:mm tt", "yyyy-MM-dd h:mm tt",
            "dd/MM/yyyy HH:mm", "dd/MM/yyyy H:mm", "dd/MM/yyyy hh:mm tt", "dd/MM/yyyy h:mm tt",
            "MM/dd/yyyy HH:mm", "MM/dd/yyyy hh:mm tt"
        };

        if (DateTime.TryParseExact(combined, dateTimeFormats, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out parsed)
            || DateTime.TryParseExact(combined, dateTimeFormats, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces, out parsed)
            || DateTime.TryParse(combined, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces, out parsed))
        {
            result = parsed;
            return true;
        }

        DateTime datePart;
        if (!DateTime.TryParseExact(dateTrim, dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out datePart)
            && !DateTime.TryParseExact(dateTrim, dateFormats, CultureInfo.CurrentCulture, DateTimeStyles.None, out datePart)
            && !DateTime.TryParse(dateTrim, CultureInfo.CurrentCulture, DateTimeStyles.None, out datePart))
            return false;

        if (string.IsNullOrEmpty(timeTrim))
        {
            result = datePart;
            return true;
        }

        TimeSpan timePart;
        if (TimeSpan.TryParseExact(timeTrim, new[] { @"hh\:mm", @"h\:mm", @"hh\:mm\:ss" }, CultureInfo.InvariantCulture, out timePart)
            || TimeSpan.TryParse(timeTrim, CultureInfo.InvariantCulture, out timePart))
        {
            result = datePart.Date.Add(timePart);
            return true;
        }

        DateTime timeAsDate;
        if (DateTime.TryParse(timeTrim, CultureInfo.CurrentCulture, DateTimeStyles.None, out timeAsDate))
        {
            result = datePart.Date.Add(timeAsDate.TimeOfDay);
            return true;
        }

        return false;
    }

    private static DataTable ApplyGridFilters(DataTable source, int classId, int activeFilter)
    {
        if (source == null)
            return new DataTable();

        if (classId <= 0 && activeFilter < 0)
            return source;

        DataTable filtered = source.Clone();
        foreach (DataRow row in source.Rows)
        {
            if (classId > 0)
            {
                if (row["Class_Id"] == DBNull.Value)
                    continue;

                int rowClassId = Convert.ToInt32(row["Class_Id"], CultureInfo.InvariantCulture);
                if (rowClassId != classId)
                    continue;
            }

            if (activeFilter >= 0)
            {
                bool isActive = row["IsActive"] != DBNull.Value && Convert.ToBoolean(row["IsActive"]);
                if (activeFilter == 1 && !isActive)
                    continue;
                if (activeFilter == 0 && isActive)
                    continue;
            }

            filtered.ImportRow(row);
        }

        return filtered;
    }

    private DataTable SelectAnnouncements(int sessionId, int termGroupId)
    {
        SqlParameter[] param =
        {
            new SqlParameter("@Session_Id", SqlDbType.Int) { Value = sessionId },
            new SqlParameter("@TermGroup_Id", SqlDbType.Int) { Value = termGroupId }
        };

        return ExecuteDataTable(SelectListSql, param);
    }

    private DataRow SelectAnnouncementById(int id)
    {
        const string selectByIdSql =
            "SELECT Id, Session_Id, TermGroup_Id, Class_Id, AnnouncementDateTime, Description, IsActive, CreatedDate, ModifiedDate " +
            "FROM dbo.ResultAnnouncementDates WHERE Id = @Id";

        SqlParameter[] param =
        {
            new SqlParameter("@Id", SqlDbType.Int) { Value = id }
        };

        DataTable dt = ExecuteDataTable(selectByIdSql, param);
        if (dt == null || dt.Rows.Count == 0)
            return null;

        return dt.Rows[0];
    }

    private bool AnnouncementExists(int sessionId, int termGroupId, int classId, int excludeId)
    {
        const string existsSql =
            "SELECT COUNT(1) FROM dbo.ResultAnnouncementDates " +
            "WHERE Session_Id = @Session_Id AND TermGroup_Id = @TermGroup_Id AND Class_Id = @Class_Id " +
            "AND IsActive = 1 AND (@ExcludeId = 0 OR Id <> @ExcludeId)";

        SqlParameter[] param =
        {
            new SqlParameter("@Session_Id", SqlDbType.Int) { Value = sessionId },
            new SqlParameter("@TermGroup_Id", SqlDbType.Int) { Value = termGroupId },
            new SqlParameter("@Class_Id", SqlDbType.Int) { Value = classId },
            new SqlParameter("@ExcludeId", SqlDbType.Int) { Value = excludeId }
        };

        object count = ExecuteScalarSql(existsSql, param);
        return ToIntResult(count) > 0;
    }

    private int InsertAnnouncement(int sessionId, int termGroupId, int classId, DateTime announcementDateTime, string description, bool isActive)
    {
        SqlParameter[] param =
        {
            new SqlParameter("@Session_Id", SqlDbType.Int) { Value = sessionId },
            new SqlParameter("@TermGroup_Id", SqlDbType.Int) { Value = termGroupId },
            new SqlParameter("@Class_Id", SqlDbType.Int) { Value = classId },
            new SqlParameter("@AnnouncementDateTime", SqlDbType.DateTime) { Value = announcementDateTime },
            new SqlParameter("@Description", SqlDbType.NVarChar, 200) { Value = (object)description ?? DBNull.Value },
            new SqlParameter("@IsActive", SqlDbType.Bit) { Value = isActive }
        };

        try
        {
            object scalar = ExecuteScalar("sp_ResultAnnouncementDates_Insert", param);
            return ToIntResult(scalar);
        }
        catch
        {
            const string insertSql =
                "INSERT INTO dbo.ResultAnnouncementDates (Session_Id, TermGroup_Id, Class_Id, AnnouncementDateTime, Description, IsActive, CreatedDate) " +
                "VALUES (@Session_Id, @TermGroup_Id, @Class_Id, @AnnouncementDateTime, @Description, @IsActive, GETDATE()); SELECT CAST(SCOPE_IDENTITY() AS INT);";
            object scalar = ExecuteScalarSql(insertSql, param);
            return ToIntResult(scalar);
        }
    }

    private int UpdateAnnouncement(int id, int sessionId, int termGroupId, int classId, DateTime announcementDateTime, string description, bool isActive)
    {
        SqlParameter[] param =
        {
            new SqlParameter("@Id", SqlDbType.Int) { Value = id },
            new SqlParameter("@Session_Id", SqlDbType.Int) { Value = sessionId },
            new SqlParameter("@TermGroup_Id", SqlDbType.Int) { Value = termGroupId },
            new SqlParameter("@Class_Id", SqlDbType.Int) { Value = classId },
            new SqlParameter("@AnnouncementDateTime", SqlDbType.DateTime) { Value = announcementDateTime },
            new SqlParameter("@Description", SqlDbType.NVarChar, 200) { Value = (object)description ?? DBNull.Value },
            new SqlParameter("@IsActive", SqlDbType.Bit) { Value = isActive }
        };

        const string updateSql =
            "UPDATE dbo.ResultAnnouncementDates SET Session_Id = @Session_Id, TermGroup_Id = @TermGroup_Id, Class_Id = @Class_Id, " +
            "AnnouncementDateTime = @AnnouncementDateTime, Description = @Description, IsActive = @IsActive, ModifiedDate = GETDATE() " +
            "WHERE Id = @Id";

        try
        {
            object scalar = ExecuteScalar("sp_ResultAnnouncementDates_Update", param);
            return ToIntResult(scalar);
        }
        catch
        {
            return ExecuteNonQuerySql(updateSql, param);
        }
    }

    private int DeleteAnnouncement(int id)
    {
        SqlParameter[] param =
        {
            new SqlParameter("@Id", SqlDbType.Int) { Value = id }
        };

        const string deleteSql = "DELETE FROM dbo.ResultAnnouncementDates WHERE Id = @Id";

        int rows = ExecuteNonQuerySql(deleteSql, param);
        if (rows <= 0)
            throw new InvalidOperationException("Record was not found or could not be deleted.");

        return rows;
    }

    private DataTable ExecuteDataTable(string sql, SqlParameter[] param)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = sql;
        cmd.Connection = objBase._cn;

        if (param != null)
        {
            for (int i = 0; i < param.Length; i++)
                cmd.Parameters.Add(param[i]);
        }

        DataTable dt = new DataTable();
        try
        {
            objBase.OpenConnection();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                dt.Load(reader);
            }
            return dt;
        }
        finally
        {
            objBase.CloseConnection();
        }
    }

    private object ExecuteScalar(string procedureName, SqlParameter[] param)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = procedureName;
        cmd.Connection = objBase._cn;

        if (param != null)
        {
            for (int i = 0; i < param.Length; i++)
                cmd.Parameters.Add(param[i]);
        }

        try
        {
            objBase.OpenConnection();
            return cmd.ExecuteScalar();
        }
        finally
        {
            objBase.CloseConnection();
        }
    }

    private object ExecuteScalarSql(string sql, SqlParameter[] param)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = sql;
        cmd.Connection = objBase._cn;

        if (param != null)
        {
            for (int i = 0; i < param.Length; i++)
                cmd.Parameters.Add(param[i]);
        }

        try
        {
            objBase.OpenConnection();
            return cmd.ExecuteScalar();
        }
        finally
        {
            objBase.CloseConnection();
        }
    }

    private int ExecuteNonQuerySql(string sql, SqlParameter[] param)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = sql;
        cmd.Connection = objBase._cn;

        if (param != null)
        {
            for (int i = 0; i < param.Length; i++)
                cmd.Parameters.Add(param[i]);
        }

        try
        {
            objBase.OpenConnection();
            return cmd.ExecuteNonQuery();
        }
        finally
        {
            objBase.CloseConnection();
        }
    }

    private static int ToIntResult(object value)
    {
        if (value == null || value == DBNull.Value)
            return 0;

        if (value is decimal)
            return Convert.ToInt32((decimal)value, CultureInfo.InvariantCulture);

        return Convert.ToInt32(value, CultureInfo.InvariantCulture);
    }
}
