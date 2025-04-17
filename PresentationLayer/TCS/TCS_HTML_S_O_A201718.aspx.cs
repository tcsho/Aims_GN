using System;
using System.Data;
using System.Web.UI.WebControls;
public partial class PresentationLayer_TCS_TCS_HTML_S_O_A201718 : System.Web.UI.Page
{
    BLLResultHidingCode hd = new BLLResultHidingCode();
    string reppath, Section, Sess, Term, Student;

    DataTable dt = new DataTable();
    DataTable dtPer = new DataTable();
    DataTable DistinctResultDate = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BLLResultHidingCode hd = new BLLResultHidingCode();
                DataTable _dtCodes = new DataTable();
                _dtCodes = hd.GETResultHideCodingAll();

                Section = hd.ResultCardDecode(Request.QueryString["sc"], _dtCodes);
                Sess = hd.ResultCardDecode(Request.QueryString["se"], _dtCodes);
                Term = hd.ResultCardDecode(Request.QueryString["tr"], _dtCodes);
                Student = hd.ResultCardDecode(Request.QueryString["st"], _dtCodes);
                LoadReport();

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }



    protected void Page_Unload(object sender, EventArgs e)
    {
        try
        {
            // if (!IsPostBack)
            //abc.Database.Dispose();
            //abc.Close();
            //abc.Dispose();
            //GC.Collect();
            //GC.WaitForPendingFinalizers();
            //GC.Collect();
        }
        catch (Exception ex)
        {

            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }

    }
    public void LoadReport()
    {
        try
        {

            BLLMarks_Entry_Acknowledgement ObjMea = new BLLMarks_Entry_Acknowledgement();
            //ObjMea.Section_Id = Convert.ToInt32(criteria.Substring(3, (criteria.Length - 8)));
            //ObjMea.Session_Id = Convert.ToInt32(criteria.Substring((criteria.Length - 2), 1));
            //ObjMea.TermGroup_Id = Convert.ToInt32(criteria.Substring((criteria.Length - 1), 1));

            ObjMea.Section_Id = Convert.ToInt32(Section);
            ObjMea.Session_Id = Convert.ToInt32(Sess);
            ObjMea.TermGroup_Id = Convert.ToInt32(Term);
            string student_Id = Student;


            if (student_Id != "0")
            {
                ObjMea.Student_Id = Convert.ToInt32(student_Id);
            }
            else
            {
                ObjMea.Student_Id = 0;
            }
            dt = ObjMea.Marks_Entry_DataFetchResult_OA(ObjMea);
            dtPer = ObjMea.Marks_Entry_DataFetchResultPerformance(ObjMea);

            DataView dv = new DataView(dt);
            dv.Sort = "Student_Id ASC";
            DataTable DistinctStudent = dv.ToTable(true, "Student_No", "Student_Id", "StudentName", "Class_Name", "Section_Name", "Strength", "DaysPresent", "Student_Age", "Class_Avg_Age", "Overall_P", "Class_Heighest", "Class_Average", "Overall_G", "ClassTeacher_Comments", "SecondTermDaysCH", "Main_Organisation_Name", "Evaluation_Criteria_Type_Name", "Center_Name", "PromotedToClass", "TtlAct", "ClassMinimum","SessionCode","Class_Id", "Session_Id");
            DistinctResultDate = dv.ToTable(true, "ResultDate");
            Reptr_Student.DataSource = DistinctStudent;
            Reptr_Student.DataBind();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }
    protected void Reptr_Student_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        try
        {
            RepeaterItem item = e.Item;

            if ((item.ItemType == ListItemType.Item) ||
                (item.ItemType == ListItemType.AlternatingItem))
            {
                Repeater Repeater3 = (Repeater)(e.Item.FindControl("SubjectMarks"));
                DataTable dt3 = new DataTable();

                dt3.Columns.Add(new DataColumn("Subject_Id", typeof(string)));
                dt3.Columns.Add(new DataColumn("Subject_Name", typeof(string)));
                dt3.Columns.Add(new DataColumn("Course_Work", typeof(string)));
                dt3.Columns.Add(new DataColumn("Theory_Exam", typeof(string)));
                dt3.Columns.Add(new DataColumn("Marks", typeof(string)));
                dt3.Columns.Add(new DataColumn("Grade", typeof(string)));




                HiddenField hd = (HiddenField)e.Item.FindControl("Student_No");

                DataView dv = new DataView(dt);
                dv.Sort = "OrderofSubject ASC";
                DataTable DistinctSubjects = dv.ToTable(true, "Subject_Id", "Student_No", "SubjectNameCom", "Course_Work", "Theory_Exam", "Marks", "Grade", "OrderofSubject");

                DataRow[] results = DistinctSubjects.Select("Student_No='" + hd.Value + "'");
                OuerHF.Value = hd.Value;

                foreach (DataRow t in results)
                {
                    dt3.NewRow();
                    dt3.Rows.Add(t["Subject_Id"], t["SubjectNameCom"], t["Course_Work"], t["Theory_Exam"], t["Marks"], t["Grade"]);
                }

                Repeater3.DataSource = dt3;
                Repeater3.DataBind();




                Repeater Repeater4 = (Repeater)(e.Item.FindControl("GenPer"));
                DataTable dt4 = new DataTable();

                dt4.Columns.Add(new DataColumn("Activity1", typeof(string)));
                dt4.Columns.Add(new DataColumn("Perf1", typeof(string)));
                dt4.Columns.Add(new DataColumn("Activity2", typeof(string)));
                dt4.Columns.Add(new DataColumn("Perf2", typeof(string)));

                DataRow[] resultsPer = dtPer.Select("Student_Id=" + hd.Value);
                OuerHF.Value = hd.Value;
                int cont = 0;
                foreach (DataRow t in resultsPer)
                {
                    if (cont % 2 == 0)
                    {
                        dt4.NewRow();
                        dt4.Rows.Add(t["Label"], t["RateCode"]);
                    }
                    else
                    {
                        int rc = dt4.Rows.Count;
                        dt4.Rows[rc - 1]["Activity2"] = t["Label"];
                        dt4.Rows[rc - 1]["Perf2"] = t["RateCode"];

                    }
                    cont = cont + 1;
                }

                Repeater4.DataSource = dt4;
                Repeater4.DataBind();

                if (dt4.Rows.Count > 0)
                {
                    //Repeater4.DataSourceID = 1;
                }
                else
                {

                }
            }
            if (DistinctResultDate.Rows.Count > 0)
            {
                Label textbox = item.FindControl("lblResultDate") as Label;
                if (textbox != null)
                {
                    ViewReport obj = new ViewReport();
                    if (!String.IsNullOrEmpty(DistinctResultDate.Rows[0]["ResultDate"].ToString()))
                    {
                        DateTime dt = Convert.ToDateTime(DistinctResultDate.Rows[0]["ResultDate"].ToString());
                        textbox.Text = "<strong>" + string.
                            Format(dt.ToString("dd{0} MMMM yyyy"), "<sup>" + obj.GetSuffix(dt.Day.ToString()) + "</sup>") + "</strong>";
                    }

                }
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }
    protected void Reptr_Subject_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        try
        {

            RepeaterItem item = e.Item;
            if ((item.ItemType == ListItemType.Item) ||
                (item.ItemType == ListItemType.AlternatingItem))
            {
                Repeater Repeater3 = (Repeater)(e.Item.FindControl("RptrComponent"));
                Repeater Repeater4 = (Repeater)(e.Item.FindControl("ComName"));
                DataTable dt3 = new DataTable();

                dt3.Columns.Add(new DataColumn("Comp", typeof(string)));
                dt3.Columns.Add(new DataColumn("Percent_Marks", typeof(string)));

                HiddenField hd = (HiddenField)e.Item.FindControl("Subject_Id");


                DataRow[] results = dt.Select("Student_No='" + OuerHF.Value + "' and Subject_Id='" + hd.Value + "'", "Subject_Id ASC,Comp ASC");



                foreach (DataRow t in results)
                {
                    dt3.NewRow();
                    dt3.Rows.Add(t["Comp"], t["Percent_Marks"]);
                }
                ViewState["Count"] = dt3.Rows.Count;

                Repeater3.DataSource = dt3;
                Repeater3.DataBind();

                Repeater4.DataSource = dt3;
                Repeater4.DataBind();


            }
        }



        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }

    }

    protected void Reptr_ComName_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        RepeaterItem item = e.Item;

        if ((item.ItemType == ListItemType.Item) ||
         (item.ItemType == ListItemType.AlternatingItem))
        {
            int count = Convert.ToInt32(ViewState["Count"].ToString());
            if (e.Item.ItemIndex == count - 1)
            {
                System.Web.UI.HtmlControls.HtmlContainerControl dynamic1 = (System.Web.UI.HtmlControls.HtmlContainerControl)e.Item.FindControl("listitem");
                dynamic1.Attributes.Add("class", "testClass");


            }


        }

    }
    protected void Reptr_RptrComponent_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        RepeaterItem item = e.Item;

        if ((item.ItemType == ListItemType.Item) ||
         (item.ItemType == ListItemType.AlternatingItem))
        {
            int count = Convert.ToInt32(ViewState["Count"].ToString());
            if (e.Item.ItemIndex == count - 1)
            {
                System.Web.UI.HtmlControls.HtmlContainerControl dynamic2 = (System.Web.UI.HtmlControls.HtmlContainerControl)e.Item.FindControl("pecrItem");
                dynamic2.Attributes.Add("class", "testClass");

            }


        }

    }
}