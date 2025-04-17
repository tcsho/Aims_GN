using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PresentationLayer_TCS_EYE_HTML_B : System.Web.UI.Page
{
    string reppath, criteria;
    DataTable dt = new DataTable();
    DataTable dtPer = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!IsPostBack)
            {
                criteria = Request.QueryString["sc"];
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
            //ObjMea.Section_Id = 484;
            //ObjMea.Session_Id = 7;
            //ObjMea.TermGroup_Id = 1;

            ObjMea.Section_Id = Convert.ToInt32(criteria.Substring(3, (criteria.Length - 8)));
            ObjMea.Session_Id = Convert.ToInt32(criteria.Substring((criteria.Length - 2), 1));
            ObjMea.TermGroup_Id = Convert.ToInt32(criteria.Substring((criteria.Length - 1), 1));

            string student_Id = Request.QueryString["st"];


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

                HiddenField hdStd = (HiddenField)e.Item.FindControl("Student_No");
                ViewState["Student_Id"] = hdStd.Value;


                DataView dv = new DataView(dtPer);
                DataTable DistinctSubjects = dv.ToTable(true, "Subject_Name", "Subject_Id");

                Repeater4.DataSource = DistinctSubjects;
                Repeater4.DataBind();



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

                if (e.Item.ItemIndex == 3)
                {
                    //System.Web.UI.HtmlControls.HtmlContainerControl dynamic2 = (System.Web.UI.HtmlControls.HtmlContainerControl)e.Item.FindControl("pagebreak");
                    //dynamic2.Attributes.Add("class", "pagebreakhere");
                    e.Item.Controls.Add(new LiteralControl("<div class=\"page\"></div>"));
                }


            }
        }



        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }

    }

    protected void Reptr_GenPerKey_ItemDataBound(object sender, RepeaterItemEventArgs e)
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



