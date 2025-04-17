using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class PresentationLayer_TCS_TCS_HTML_F_EYE_201920 : System.Web.UI.Page
{
    BLLResultHidingCode hd = new BLLResultHidingCode();
    string reppath, Section, Sess, Term, Student;

    DataTable dt = new DataTable();
    DataTable dtPer = new DataTable();
    //DataTable DistinctResultDate = new DataTable();

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

            //if (dt.Rows.Count > 0)
            //{
            //    ViewState["ResultDate"] = dt.Rows[0]["ResultDate"].ToString();
            //}

            Reptr_Student.DataSource = dt;
            Reptr_Student.DataBind();
            //DistinctResultDate = dt;
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

                Repeater Repeater6 = (Repeater)(e.Item.FindControl("GenPer2"));
                DataTable dt6 = new DataTable();

                HiddenField hdStd = (HiddenField)e.Item.FindControl("Student_No");
                ViewState["Student_Id"] = hdStd.Value;


                HiddenField hdClass = (HiddenField)e.Item.FindControl("Class_Id");
                int class_id = Convert.ToInt32(hdClass.Value);

                //if (dtPer.Rows.Count > 0)
                //{
                DataView dv = new DataView(dtPer);

                DataTable dtSub1 = new DataTable();

                dtSub1.Columns.Add(new DataColumn("Subject_Name", typeof(string)));
                dtSub1.Columns.Add(new DataColumn("Subject_Id", typeof(int)));

                DataTable dtSub2 = new DataTable();

                dtSub2.Columns.Add(new DataColumn("Subject_Name", typeof(string)));
                dtSub2.Columns.Add(new DataColumn("Subject_Id", typeof(int)));

                DataTable dtSub3 = new DataTable();

                dtSub3.Columns.Add(new DataColumn("Subject_Name", typeof(string)));
                dtSub3.Columns.Add(new DataColumn("Subject_Id", typeof(int)));

                DataTable DistinctSubjects = dv.ToTable(true, "Subject_Name", "Subject_Id");

                if (Convert.ToInt32(Sess) <= 9)
                {
                    Session2017Settings(e, class_id, dtSub1, dtSub2, dtSub3, DistinctSubjects);
                }
                else if (Convert.ToInt32(Sess) > 9 && Convert.ToInt32(Sess) <= 12)
                {
                    Session2018Settings(e, class_id, dtSub1, dtSub2, dtSub3, DistinctSubjects);
                }
                else
                {
                    Session2021Settings(e, class_id, dtSub1, dtSub2, dtSub3, DistinctSubjects);
                }

                Repeater4.DataSource = dtSub1;
                Repeater4.DataBind();

                Repeater5.DataSource = dtSub2;
                Repeater5.DataBind();

                Repeater6.DataSource = dtSub3;
                Repeater6.DataBind();
                //}
            }

            //if (ViewState["ResultDate"] != null && ViewState["ResultDate"] != "")
            //{
            //    Label textbox = item.FindControl("lblResultDate") as Label;

            //    textbox.Text = Convert.ToDateTime(ViewState["ResultDate"].ToString()).ToLongDateString();
            //}
            //else
            //{
            //    Label textbox = item.FindControl("lblResultDate") as Label;

            //    textbox.Text = "Result issuance Date is not defined";
            //}
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }
    private void Session2017Settings(RepeaterItemEventArgs e, int class_id, DataTable dtSub1, DataTable dtSub2, DataTable dtSub3, DataTable DistinctSubjects)
    {
        for (int i = 1; i <= DistinctSubjects.Rows.Count; i++)
        {


            if (class_id == 2) //Class Playgroup
            {

                if (i < 6)
                {
                    dtSub1.NewRow();
                    dtSub1.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

                    HtmlGenericControl divControl = e.Item.FindControl("divPage2") as HtmlGenericControl;
                    if (divControl != null)
                    {
                        divControl.Style.Add(HtmlTextWriterStyle.PaddingTop, "105px");
                    }

                    Repeater Repeater3 = (Repeater)(e.Item.FindControl("GenPerKeys"));
                    DataTable dt3 = new DataTable();




                }
                else
                {
                    dtSub2.NewRow();
                    dtSub2.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);
                }
            }

            else if (class_id == 3) //Class Nursery
            {
                if (i < 5)
                {
                    dtSub1.NewRow();
                    dtSub1.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

                    HtmlGenericControl divControl = e.Item.FindControl("divPage2") as HtmlGenericControl;
                    if (divControl != null)
                    {
                        divControl.Style.Add(HtmlTextWriterStyle.PaddingTop, "95px");
                    }
                }
                else
                {
                    dtSub2.NewRow();
                    dtSub2.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);
                }
            }
            else if (class_id == 4) //Class Kindergarten
            {
                if (i < 4)
                {
                    dtSub1.NewRow();
                    dtSub1.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

                    HtmlGenericControl divControl = e.Item.FindControl("divPage2") as HtmlGenericControl;
                    if (divControl != null)
                    {
                        divControl.Style.Add(HtmlTextWriterStyle.PaddingTop, "185px");
                    }
                }
                else
                {
                    dtSub2.NewRow();
                    dtSub2.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);
                }
            }
            else if (class_id == 5) //Class Class-1
            {
                if (i < 5)
                {
                    dtSub1.NewRow();
                    dtSub1.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

                    HtmlGenericControl divControl = e.Item.FindControl("divPage2") as HtmlGenericControl;
                    if (divControl != null)
                    {
                        if (Convert.ToInt32(Sess) == 9)
                        {
                            divControl.Style.Add(HtmlTextWriterStyle.PaddingTop, "160px");
                        }
                        else
                        {
                            divControl.Style.Add(HtmlTextWriterStyle.PaddingTop, "80px");
                        }

                    }
                }
                else
                {
                    dtSub2.NewRow();
                    dtSub2.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);
                }
            }
            else if (class_id == 6) //Class Class -2 
            {
                if (i < 5)
                {
                    dtSub1.NewRow();
                    dtSub1.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

                    HtmlGenericControl divControl = e.Item.FindControl("divPage2") as HtmlGenericControl;
                    if (divControl != null)
                    {
                        if (Convert.ToInt32(Sess) == 9)
                        {
                            divControl.Style.Add(HtmlTextWriterStyle.PaddingTop, "200px");
                        }
                        else
                        {
                            divControl.Style.Add(HtmlTextWriterStyle.PaddingTop, "150px");
                        }
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
    }
    private void Session2018Settings(RepeaterItemEventArgs e, int class_id, DataTable dtSub1, DataTable dtSub2, DataTable dtSub3, DataTable DistinctSubjects)
    {
        for (int i = 1; i <= DistinctSubjects.Rows.Count; i++)
        {


            if (class_id == 2) //Class Playgroup
            {

                if (i < 6)
                {
                    dtSub1.NewRow();
                    dtSub1.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

                    HtmlGenericControl divControl = e.Item.FindControl("divPage2") as HtmlGenericControl;
                    if (divControl != null)
                    {
                        divControl.Style.Add(HtmlTextWriterStyle.PaddingTop, "100px");
                    }

                    Repeater Repeater3 = (Repeater)(e.Item.FindControl("GenPerKeys"));
                    DataTable dt3 = new DataTable();

                }
                else
                {
                    dtSub2.NewRow();
                    dtSub2.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);


                    HtmlGenericControl divControl = e.Item.FindControl("divPage3") as HtmlGenericControl;
                    divControl.Visible = false;
                }
            }

            else if (class_id == 3) //Class Nursery
            {
                if (i < 6)
                {
                    dtSub1.NewRow();
                    dtSub1.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

                    HtmlGenericControl divControl = e.Item.FindControl("divPage2") as HtmlGenericControl;
                    if (divControl != null)
                    {
                        divControl.Style.Add(HtmlTextWriterStyle.PaddingTop, "200px");
                    }
                }
                else
                {
                    dtSub2.NewRow();
                    dtSub2.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

                    HtmlGenericControl divControl = e.Item.FindControl("divPage3") as HtmlGenericControl;
                    divControl.Visible = false;
                }
            }
            else if (class_id == 4) //Class Kindergarten
            {
                if (i < 5)
                {
                    dtSub1.NewRow();
                    dtSub1.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

                    HtmlGenericControl divControl = e.Item.FindControl("divPage2") as HtmlGenericControl;
                    if (divControl != null)
                    {
                        divControl.Style.Add(HtmlTextWriterStyle.PaddingTop, "200px");
                    }
                }
                else
                {
                    dtSub2.NewRow();
                    dtSub2.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

                    HtmlGenericControl divControl = e.Item.FindControl("divPage3") as HtmlGenericControl;

                    HtmlGenericControl divControlCmt = e.Item.FindControl("classteachercomment") as HtmlGenericControl;


                    if (divControlCmt != null)
                    {
                        divControlCmt.Style.Add(HtmlTextWriterStyle.PaddingTop, "300px");
                    }
                    divControl.Visible = false;
                }
            }
            else if (class_id == 5) //Class Class-1
            {
                if (i < 3)
                {
                    dtSub1.NewRow();
                    dtSub1.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

                    HtmlGenericControl divControl = e.Item.FindControl("divPage2") as HtmlGenericControl;
                    HtmlGenericControl divControlKeys = e.Item.FindControl("cityschoolKyes") as HtmlGenericControl;

                    if (divControlKeys != null)
                    {

                        divControlKeys.Style.Add(HtmlTextWriterStyle.PaddingTop, "80px");

                    }

                    if (divControl != null)
                    {

                        divControl.Style.Add(HtmlTextWriterStyle.PaddingTop, "300px");

                    }
                }
                else if (i >= 3 && i < 8)
                {
                    dtSub2.NewRow();
                    dtSub2.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

                    HtmlGenericControl divControl = e.Item.FindControl("divPage3") as HtmlGenericControl;
                    if (divControl != null)
                    {

                        divControl.Style.Add(HtmlTextWriterStyle.PaddingTop, "250px");

                    }

                }
                else
                {
                    dtSub3.NewRow();
                    dtSub3.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);
                }
            }
            else if (class_id == 6) //Class Class -2 
            {
                if (i < 5)
                {
                    dtSub1.NewRow();
                    dtSub1.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

                    HtmlGenericControl divControl = e.Item.FindControl("divPage2") as HtmlGenericControl;
                    if (divControl != null)
                    {

                        divControl.Style.Add(HtmlTextWriterStyle.PaddingTop, "300px");

                    }
                }
                else if (i >= 3 && i < 10)
                {
                    dtSub2.NewRow();
                    dtSub2.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

                    HtmlGenericControl divControl = e.Item.FindControl("divPage3") as HtmlGenericControl;
                    if (divControl != null)
                    {

                        divControl.Style.Add(HtmlTextWriterStyle.PaddingTop, "100px");

                    }
                    divControl.Visible = false;
                }
                else
                {
                    HtmlGenericControl divControl = e.Item.FindControl("divPage3") as HtmlGenericControl;
                    //dtSub3.NewRow();
                    //dtSub3.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);
                    divControl.Visible = false;


                }
                HtmlGenericControl divControlCmt = e.Item.FindControl("classteachercomment") as HtmlGenericControl;


                if (divControlCmt != null)
                {
                    divControlCmt.Style.Add(HtmlTextWriterStyle.PaddingTop, "330px");
                }
            }
            else
            {
                dtSub1.NewRow();
                dtSub1.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

            }
        }
    }    
    private void Session2021Settings(RepeaterItemEventArgs e, int class_id, DataTable dtSub1, DataTable dtSub2, DataTable dtSub3, DataTable DistinctSubjects)
    {
        for (int i = 1; i <= DistinctSubjects.Rows.Count; i++)
        {
            int region_Id = Convert.ToInt32(Session["RegionID"].ToString());
            int firstP, SecondP;
            string div1 = "", div2 = "", divcmt = "";


            if (class_id == 2) //Class Playgroup
            {

                if (i < 6)
                {
                    dtSub1.NewRow();
                    dtSub1.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

                    HtmlGenericControl divControl = e.Item.FindControl("divPage2") as HtmlGenericControl;
                    if (divControl != null)
                    {
                        divControl.Style.Add(HtmlTextWriterStyle.PaddingTop, "140px");
                    }

                    Repeater Repeater3 = (Repeater)(e.Item.FindControl("GenPerKeys"));
                    DataTable dt3 = new DataTable();

                }
                else
                {
                    dtSub2.NewRow();
                    dtSub2.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);


                    HtmlGenericControl divControl = e.Item.FindControl("divPage3") as HtmlGenericControl;
                    divControl.Visible = false;
                }
            }

            else if (class_id == 3) //Class Nursery
            {
                if (i < 5)
                {
                    dtSub1.NewRow();
                    dtSub1.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

                    HtmlGenericControl divControl = e.Item.FindControl("divPage2") as HtmlGenericControl;
                    if (divControl != null)
                    {
                        divControl.Style.Add(HtmlTextWriterStyle.PaddingTop, "300px");
                    }
                }
                else if (i >= 5 && i < 8)
                {
                    dtSub2.NewRow();
                    dtSub2.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

                    HtmlGenericControl divControl = e.Item.FindControl("divPage3") as HtmlGenericControl;
                    if (divControl != null)
                    {

                        divControl.Style.Add(HtmlTextWriterStyle.PaddingTop, "500px");

                    }
                    divControl.Visible = false;
                }
                else
                {

                    dtSub3.NewRow();
                    dtSub3.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);
                    HtmlGenericControl divControl = e.Item.FindControl("divPage3") as HtmlGenericControl;

                    divControl.Visible = true;
                    HtmlGenericControl divControlCmt = e.Item.FindControl("classteachercomment") as HtmlGenericControl;


                    if (divControlCmt != null)
                    {
                        divControlCmt.Style.Add(HtmlTextWriterStyle.PaddingTop, "50px");
                    }
                }
            }
            else if (class_id == 4) //Class Kindergarten
            {

                if (region_Id == 20000000 || region_Id == 20105998)
                {
                    firstP = 5;
                    SecondP = 10;
                    div1 = "400px";
                    div2 = "200px";
                    divcmt = "50px";
                }
                else
                {
                    firstP = 5;
                    SecondP = 8;
                    div1 = "200px";
                    div2 = "500px";
                    divcmt = "50px";
                }

                if (i < firstP)
                {
                    dtSub1.NewRow();
                    dtSub1.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

                    HtmlGenericControl divControl = e.Item.FindControl("divPage2") as HtmlGenericControl;
                    if (divControl != null)
                    {
                        divControl.Style.Add(HtmlTextWriterStyle.PaddingTop, div1);
                    }
                }
                else if (i >= firstP && i < SecondP)
                {
                    dtSub2.NewRow();
                    dtSub2.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

                    HtmlGenericControl divControl = e.Item.FindControl("divPage3") as HtmlGenericControl;
                    if (divControl != null)
                    {

                        divControl.Style.Add(HtmlTextWriterStyle.PaddingTop, div2);

                    }
                    divControl.Visible = false;
                }

                else
                {
                    dtSub3.NewRow();
                    dtSub3.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);
                    HtmlGenericControl divControl = e.Item.FindControl("divPage3") as HtmlGenericControl;

                    divControl.Visible = true;
                    HtmlGenericControl divControlCmt = e.Item.FindControl("classteachercomment") as HtmlGenericControl;


                    if (divControlCmt != null)
                    {
                        divControlCmt.Style.Add(HtmlTextWriterStyle.PaddingTop, divcmt);
                    }

                }
            }
            else if (class_id == 5) //Class Class-1
            {


                if (region_Id == 20000000 || region_Id == 20105998)
                {
                    firstP = 3;
                    SecondP = 7;
                    div1 = "300px";
                    div2 = "250px";
                    divcmt = "150px";
                }
                else
                {
                    firstP = 4;
                    SecondP = 8;
                    div1 = "300px";
                    div2 = "550px";
                    divcmt = "50px";
                }
                if (i < firstP)
                {
                    dtSub1.NewRow();
                    dtSub1.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

                    HtmlGenericControl divControl = e.Item.FindControl("divPage2") as HtmlGenericControl;
                    HtmlGenericControl divControlKeys = e.Item.FindControl("cityschoolKyes") as HtmlGenericControl;

                    if (divControlKeys != null)
                    {

                        divControlKeys.Style.Add(HtmlTextWriterStyle.PaddingTop, "80px");

                    }

                    if (divControl != null)
                    {

                        divControl.Style.Add(HtmlTextWriterStyle.PaddingTop, div1);

                    }
                }
                else if (i >= firstP && i < SecondP)
                {
                    dtSub2.NewRow();
                    dtSub2.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

                    HtmlGenericControl divControl = e.Item.FindControl("divPage3") as HtmlGenericControl;
                    if (divControl != null)
                    {

                        divControl.Style.Add(HtmlTextWriterStyle.PaddingTop, div2);

                    }

                }
                else
                {
                    dtSub3.NewRow();
                    dtSub3.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);
                }
            }
            else if (class_id == 6) //Class Class -2 
            {

                if (region_Id == 20000000 || region_Id == 20105998)
                {
                    firstP = 5;
                    SecondP = 10;
                    div1 = "100px";
                    div2 = "150px";
                    divcmt = "250px";
                }
                else
                {
                    firstP = 4;
                    SecondP = 9;
                    div1 = "150px";
                    div2 = "500px";
                    divcmt = "100px";
                }

                if (i < firstP)
                {
                    dtSub1.NewRow();
                    dtSub1.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

                    HtmlGenericControl divControl = e.Item.FindControl("divPage2") as HtmlGenericControl;
                    if (divControl != null)
                    {

                        divControl.Style.Add(HtmlTextWriterStyle.PaddingTop, div1);

                    }
                }
                else if (i >= firstP && i < SecondP)
                {
                    dtSub2.NewRow();
                    dtSub2.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

                    HtmlGenericControl divControl = e.Item.FindControl("divPage3") as HtmlGenericControl;
                    if (divControl != null)
                    {

                        divControl.Style.Add(HtmlTextWriterStyle.PaddingTop, div2);

                    }
                    if (region_Id == 20000000 || region_Id == 20105998)
                    {
                        divControl.Visible = false;
                    }
                    else
                    {
                        divControl.Visible = true;

                    }
                }
                else
                {
                    HtmlGenericControl divControl = e.Item.FindControl("divPage3") as HtmlGenericControl;
                    dtSub3.NewRow();
                    dtSub3.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

                    if (region_Id == 20000000 || region_Id == 20105998)
                    {
                        divControl.Visible = false;
                    }
                    else
                    {
                        divControl.Visible = true;

                    }

                }
                HtmlGenericControl divControlCmt = e.Item.FindControl("classteachercomment") as HtmlGenericControl;


                if (divControlCmt != null)
                {
                    divControlCmt.Style.Add(HtmlTextWriterStyle.PaddingTop, divcmt);
                }
            }
            else
            {
                dtSub1.NewRow();
                dtSub1.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

            }
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

                AssgningRepeater(e, "GenPerKeys");

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
                AssgningRepeater(e, "GenPerKeys1");
            }
        }



        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }

    }
    protected void Reptr_Subject2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        try
        {

            RepeaterItem item = e.Item;
            if ((item.ItemType == ListItemType.Item) ||
                (item.ItemType == ListItemType.AlternatingItem))
            {
                AssgningRepeater(e, "GenPerKeys2");

            }
        }



        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }

    }
    private void AssgningRepeater(RepeaterItemEventArgs e, string GPKeys)
    {
        Repeater Repeater3 = (Repeater)(e.Item.FindControl(GPKeys));
        DataTable dt3 = new DataTable();

        dt3.Columns.Add(new DataColumn("KLO", typeof(string)));
        dt3.Columns.Add(new DataColumn("Key1", typeof(bool)));
        dt3.Columns.Add(new DataColumn("Key2", typeof(bool)));
        dt3.Columns.Add(new DataColumn("Key3", typeof(bool)));
        dt3.Columns.Add(new DataColumn("Key4", typeof(bool)));


        HiddenField hdSubj = (HiddenField)e.Item.FindControl("Subject_Id");
        ViewState["Subject_Id"] = hdSubj.Value;
        string Student_Id = ViewState["Student_Id"].ToString();

        if (dtPer.Rows.Count > 0)
        {
            DataRow[] results = dtPer.Select("Student_Id='" + Student_Id + "' and Subject_Id='" + hdSubj.Value + "'");

            foreach (DataRow t in results)
            {
                dt3.NewRow();
                dt3.Rows.Add(t["KLO"], t["Key1"], t["Key2"], t["Key3"], t["Key4"]);
            }
            //ViewState["Count"] = dt3.Rows.Count;
            Repeater3.DataSource = dt3;
            Repeater3.DataBind();
        }
    }
    protected void Reptr_GP_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        try
        {

            UrduSubjectSettings(e);
        }



        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }

    }
    protected void Reptr_GP1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        try
        {

            UrduSubjectSettings(e);
        }



        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }

    }
    protected void Reptr_GP2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        try
        {

            UrduSubjectSettings(e);
        }



        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }

    }
    private void UrduSubjectSettings(RepeaterItemEventArgs e)
    {
        RepeaterItem item = e.Item;
        if ((item.ItemType == ListItemType.Item) ||
            (item.ItemType == ListItemType.AlternatingItem))
        {

            if (ViewState["Subject_Id"].ToString() == "114" || ViewState["Subject_Id"].ToString() == "123" || ViewState["Subject_Id"].ToString() == "12" || ViewState["Subject_Id"].ToString() == "61" || ViewState["Subject_Id"].ToString() == "18" || ViewState["Subject_Id"].ToString() == "17")
            //                if (new [] { "114","123","12","61"}.Contains(ViewState["Subject_Id"].ToString()))
            {
                HtmlTableCell GKLO = (HtmlTableCell)e.Item.FindControl("GKLO");
                if (GKLO != null)
                {
                    GKLO.Style.Add(HtmlTextWriterStyle.TextAlign, "right");
                    GKLO.Style.Add(HtmlTextWriterStyle.PaddingRight, "10px");
                    GKLO.Style.Add(HtmlTextWriterStyle.Width, "36.6%");

                    // GKLO.Style.Add(HtmlTextWriterStyle.Width, "38.8%");

                }

            }


        }
    }
}