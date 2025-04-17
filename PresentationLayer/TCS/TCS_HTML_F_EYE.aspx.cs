using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class PresentationLayer_TCS_TCS_HTML_F_EYE : System.Web.UI.Page
{
    BLLResultHidingCode hd = new BLLResultHidingCode();
    string reppath, Section, Sess, Term, Student;

    DataTable dt = new DataTable();
    DataTable dtPer = new DataTable();

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
            dt = ObjMea.Marks_Entry_DataFetchResultStudentInformation(ObjMea);
            dtPer = ObjMea.Marks_Entry_DataFetchResultStudentPerformanceGradeSection(ObjMea);

            dt.DefaultView.Sort = "Student_Id ASC";
            Reptr_Student.DataSource = dt;
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
                Repeater Repeater4 = (Repeater)(e.Item.FindControl("GenPer"));
                DataTable dt4 = new DataTable();
                
                Repeater Repeater5 = (Repeater)(e.Item.FindControl("GenPer1"));
                DataTable dt5 = new DataTable();
                
                HiddenField hdStd = (HiddenField)e.Item.FindControl("Student_No");
                ViewState["Student_Id"] = hdStd.Value;


                HiddenField hdClass = (HiddenField)e.Item.FindControl("Class_Id");
                int class_id = Convert.ToInt32(hdClass.Value);


                DataView dv = new DataView(dtPer);

               
                DataTable dtSub1 = new DataTable();

                dtSub1.Columns.Add(new DataColumn("Subject_Name", typeof(string)));
                dtSub1.Columns.Add(new DataColumn("Subject_Id", typeof(int)));

                DataTable dtSub2 = new DataTable();

                dtSub2.Columns.Add(new DataColumn("Subject_Name", typeof(string)));
                dtSub2.Columns.Add(new DataColumn("Subject_Id", typeof(int)));
                DataTable DistinctSubjects = dv.ToTable(true, "Subject_Name", "Subject_Id");

                for (int i = 1; i <= DistinctSubjects.Rows.Count; i++)
                {


                    if (class_id==2)
                    {

                        if (i < 6)
                        {
                            dtSub1.NewRow();
                            dtSub1.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

                            HtmlGenericControl divControl = e.Item.FindControl("divPage1") as HtmlGenericControl;
                            if (divControl != null)
                            {
                                divControl.Style.Add(HtmlTextWriterStyle.PaddingTop, "65px");
                            }
                        }
                        else
                        {
                            dtSub2.NewRow();
                            dtSub2.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);
                        }
                    }

                    else if(class_id==3)
	{
        if (i < 5)
        {
            dtSub1.NewRow();
            dtSub1.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

            HtmlGenericControl divControl = e.Item.FindControl("divPage1") as HtmlGenericControl;
            if (divControl != null)
            {
                divControl.Style.Add(HtmlTextWriterStyle.PaddingTop, "150px");
            }
        }
        else
        {
            dtSub2.NewRow();
            dtSub2.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);
        }
	}
                    else
                    {
                        dtSub1.NewRow();
                        dtSub1.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

                    }
                }

                Repeater4.DataSource = dtSub1;
                Repeater4.DataBind();

                Repeater5.DataSource = dtSub2;
                Repeater5.DataBind();


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



                Repeater Repeater3 = (Repeater)(e.Item.FindControl("GenPerKeys"));
                DataTable dt3 = new DataTable();

                dt3.Columns.Add(new DataColumn("KLO", typeof(string)));
                dt3.Columns.Add(new DataColumn("Key1", typeof(bool)));
                dt3.Columns.Add(new DataColumn("Key2", typeof(bool)));
                dt3.Columns.Add(new DataColumn("Key3", typeof(bool)));


                HiddenField hdSubj = (HiddenField)e.Item.FindControl("Subject_Id");
                string Student_Id = ViewState["Student_Id"].ToString();

                DataRow[] results = dtPer.Select("Student_Id='" + Student_Id + "' and Subject_Id='" + hdSubj.Value + "'");

                foreach (DataRow t in results)
                {
                    dt3.NewRow();
                    dt3.Rows.Add(t["KLO"], t["Key1"], t["Key2"], t["Key3"]);
                }
                ViewState["Count"] = dt3.Rows.Count;
                Repeater3.DataSource = dt3;
                Repeater3.DataBind();

            }
        }



        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }

    }

    protected void Reptr_Subject1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        try
        {

            RepeaterItem item = e.Item;
            if ((item.ItemType == ListItemType.Item) ||
                (item.ItemType == ListItemType.AlternatingItem))
            {



                Repeater Repeater3 = (Repeater)(e.Item.FindControl("GenPerKeys1"));
                DataTable dt3 = new DataTable();

                dt3.Columns.Add(new DataColumn("KLO", typeof(string)));
                dt3.Columns.Add(new DataColumn("Key1", typeof(bool)));
                dt3.Columns.Add(new DataColumn("Key2", typeof(bool)));
                dt3.Columns.Add(new DataColumn("Key3", typeof(bool)));


                HiddenField hdSubj = (HiddenField)e.Item.FindControl("Subject_Id");
                string Student_Id = ViewState["Student_Id"].ToString();

                DataRow[] results = dtPer.Select("Student_Id='" + Student_Id + "' and Subject_Id='" + hdSubj.Value + "'");

                foreach (DataRow t in results)
                {
                    dt3.NewRow();
                    dt3.Rows.Add(t["KLO"], t["Key1"], t["Key2"], t["Key3"]);
                }
                ViewState["Count"] = dt3.Rows.Count;
                Repeater3.DataSource = dt3;
                Repeater3.DataBind();


            }
        }



        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }

    }

}