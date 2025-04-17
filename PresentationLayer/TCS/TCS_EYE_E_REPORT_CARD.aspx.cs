
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class PresentationLayer_TCS_EYE_E_REPORT_CARD : System.Web.UI.Page
{
    BLLResultHidingCode hd = new BLLResultHidingCode();
    string reppath, Section, Sess, Term, Student;

    DataTable dt = new DataTable();
    DataTable dtPer = new DataTable();
    DataTable DistinctResultDate = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        //try
        //{

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
        // }
        //catch (Exception ex)
        //{
        //    Session["error"] = ex.Message;
        //    Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        //}
    }


    public void LoadReport()
    {
        //try
        //{

        BLLMarks_Entry_Acknowledgement ObjMea = new BLLMarks_Entry_Acknowledgement();

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
        dt = ObjMea.Marks_Entry_DataFetchResultStudentInformation_New(ObjMea);

        //2024-07-08
        var filteredRows = from row in dt.AsEnumerable()
                           where row.Field<int>("Student_Status_Id") != 9
                           select row;
        DataTable filteredDt = filteredRows.CopyToDataTable();


        //dtPer = ObjMea.Marks_Entry_DataFetchResultStudentPerformanceGradeSection(ObjMea);
        dtPer = ObjMea.Marks_Entry_DataFetchResultStudentPerformanceGradeSection_CLASS1_2(ObjMea);
        DistinctResultDate = dt;
        dt.DefaultView.Sort = "Student_Id ASC";
        //Reptr_Student.DataSource = dt;
        Reptr_Student.DataSource = filteredDt;
        Reptr_Student.DataBind();
        //}
        //catch (Exception ex)
        //{
        //    Session["error"] = ex.Message;
        //    Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        //}
    }


    protected void Reptr_Student_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        RepeaterItem item = e.Item;
        if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
        {
            Repeater Repeater1 = (Repeater)(e.Item.FindControl("GenPer"));
            DataTable dt1 = new DataTable();

            Repeater Repeater2 = (Repeater)(e.Item.FindControl("GenPer1"));
            DataTable dt2 = new DataTable();

            Repeater Repeater3 = (Repeater)(e.Item.FindControl("GenPer2"));
            DataTable dt3 = new DataTable();

            //*
            Repeater Repeater4 = (Repeater)(e.Item.FindControl("GenPer3"));
            DataTable dt4 = new DataTable();

            HiddenField hdStd = (HiddenField)e.Item.FindControl("Student_No");
            ViewState["Student_Id"] = hdStd.Value;


            HiddenField hdClass = (HiddenField)e.Item.FindControl("Class_Id");
            int class_id = Convert.ToInt32(hdClass.Value);


            if (dtPer.Rows.Count > 0)
            {
                DataTable filteredData = dtPer.Select("Student_Id=" + hdStd.Value).CopyToDataTable();

                DataView dv = new DataView(filteredData);

                DataTable dtSub1 = new DataTable();

                dtSub1.Columns.Add(new DataColumn("Subject_Name", typeof(string)));
                dtSub1.Columns.Add(new DataColumn("Subject_Id", typeof(int)));

                DataTable dtSub2 = new DataTable();

                dtSub2.Columns.Add(new DataColumn("Subject_Name", typeof(string)));
                dtSub2.Columns.Add(new DataColumn("Subject_Id", typeof(int)));
                DataTable DistinctSubjects = dv.ToTable(true, "Subject_Name", "Subject_Id");

                DataTable dtSub3 = new DataTable();
                dtSub3.Columns.Add(new DataColumn("Subject_Name", typeof(string)));
                dtSub3.Columns.Add(new DataColumn("Subject_Id", typeof(int)));

                //*
                DataTable dtSub4 = new DataTable();
                dtSub4.Columns.Add(new DataColumn("Subject_Name", typeof(string)));
                dtSub4.Columns.Add(new DataColumn("Subject_Id", typeof(int)));

                for (int i = 1; i <= DistinctSubjects.Rows.Count; i++)
                {





                    if (class_id == 5) //Class Class-1
                    {
                        //if (i < 3)
                        //{
                        //    dtSub1.NewRow();
                        //    dtSub1.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

                        //    HtmlGenericControl divControl = e.Item.FindControl("divPage1") as HtmlGenericControl;
                        //    if (divControl != null)
                        //    {

                        //    }
                        //}
                        //else if (i >= 3 && i < 5)
                        //{
                        //    dtSub2.NewRow();
                        //    dtSub2.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);
                        //    HtmlGenericControl divControl1 = e.Item.FindControl("divPage2") as HtmlGenericControl;
                        //    if (divControl1 != null)
                        //    {

                        //    }
                        //}
                        //else if (i >= 5 && i < 9)//*
                        //{
                        //    dtSub3.NewRow();
                        //    dtSub3.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);
                        //    HtmlGenericControl divControl1 = e.Item.FindControl("divPage3") as HtmlGenericControl;
                        //    if (divControl1 != null)
                        //    {

                        //    }
                        //}
                        //else
                        //{
                        //    dtSub4.NewRow();
                        //    dtSub4.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);
                        //}


                        //*********************************************************Testing Block***********************************************************
                        if (i < 2)
                        {
                            dtSub1.NewRow();
                            dtSub1.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

                            HtmlGenericControl divControl = e.Item.FindControl("divPage1") as HtmlGenericControl;
                            if (divControl != null)
                            {

                            }
                        }
                        else if (i >= 2 && i < 4)
                        {
                            dtSub2.NewRow();
                            dtSub2.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);
                            HtmlGenericControl divControl1 = e.Item.FindControl("divPage2") as HtmlGenericControl;
                            if (divControl1 != null)
                            {

                            }
                        }
                        else if (i >= 4 && i < 7)//*
                        {
                            dtSub3.NewRow();
                            dtSub3.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);
                            HtmlGenericControl divControl1 = e.Item.FindControl("divPage3") as HtmlGenericControl;
                            if (divControl1 != null)
                            {

                            }
                        }
                        else
                        {
                            dtSub4.NewRow();
                            dtSub4.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);
                        }

                        //***************************************************************************************************************************
                    }
                    else if (class_id == 6) //Class Class -2 
                    {
                        if (i < 3)
                        {
                            dtSub1.NewRow();
                            dtSub1.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

                            HtmlGenericControl divControl = e.Item.FindControl("divPage1") as HtmlGenericControl;
                            if (divControl != null)
                            {
                                //divControl.Style.Add(HtmlTextWriterStyle.PaddingTop, "250px");
                            }
                        }
                        else if (i >= 3 && i < 5)
                        {
                            dtSub2.NewRow();
                            dtSub2.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);
                            HtmlGenericControl divControl1 = e.Item.FindControl("divPage2") as HtmlGenericControl;
                            if (divControl1 != null)
                            {
                               // divControl1.Style.Add(HtmlTextWriterStyle.PaddingTop, "250px");
                            }
                        }
                        else if (i >= 5 && i < 9)//*
                        {
                            dtSub3.NewRow();
                            dtSub3.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);
                            HtmlGenericControl divControl1 = e.Item.FindControl("divPage3") as HtmlGenericControl;
                            if (divControl1 != null)
                            {
                                //divControl1.Style.Add(HtmlTextWriterStyle.PaddingTop, "250px");
                            }
                        }
                        else
                        {
                            dtSub4.NewRow();
                            dtSub4.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);
                        }
                    }
                    else
                    {
                        dtSub1.NewRow();
                        dtSub1.Rows.Add(DistinctSubjects.Rows[i - 1]["Subject_Name"], DistinctSubjects.Rows[i - 1]["Subject_Id"]);

                    }
                }

                Repeater1.DataSource = dtSub1;
                Repeater1.DataBind();

                Repeater2.DataSource = dtSub2;
                Repeater2.DataBind();
                Repeater3.DataSource = dtSub3;
                Repeater3.DataBind();

                //*
                Repeater4.DataSource = dtSub4;
                Repeater4.DataBind();
            }
        }

    }



    protected void Reptr_Subject_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        RepeaterItem item = e.Item;
        if ((item.ItemType == ListItemType.Item) ||
            (item.ItemType == ListItemType.AlternatingItem))
        {
            Repeater Repeater3 = (Repeater)(e.Item.FindControl("GenPerKeys"));
            DataTable dt3 = new DataTable();

            dt3.Columns.Add(new DataColumn("KLO", typeof(string)));
            dt3.Columns.Add(new DataColumn("PerformanceInd", typeof(string)));

            HiddenField hdSubj = (HiddenField)e.Item.FindControl("Subject_Id");
            ViewState["Subject_Id"] = hdSubj.Value;

            string Student_Id = ViewState["Student_Id"].ToString();
            if (dtPer.Rows.Count > 0)
            {
                DataRow[] results = dtPer.Select("Student_Id='" + Student_Id + "' and Subject_Id='" + hdSubj.Value + "'");

                foreach (DataRow t in results)
                {
                    dt3.NewRow();
                    // dt3.Rows.Add(t["KLO"], t["Key1"], t["Key2"], t["Key3"], t["Key4"]);
                    dt3.Rows.Add(t["KLO"], t["PerformanceInd"]);
                }
                ViewState["Count"] = dt3.Rows.Count;
                Repeater3.DataSource = dt3;
                Repeater3.DataBind();
            }


            HtmlTableCell subid = (HtmlTableCell)e.Item.FindControl("subid");
            HtmlTableCell PI = (HtmlTableCell)e.Item.FindControl("PI");

            
            ApplyStyleToSubject(subid, PI);
          
        }
        //}
        //catch (Exception ex)
        //{
        //    Session["error"] = ex.Message;
        //    Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        //}
    }



    protected void Reptr_Subject1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        //try
        //{

        RepeaterItem item = e.Item;
        if ((item.ItemType == ListItemType.Item) ||
            (item.ItemType == ListItemType.AlternatingItem))
        {

            Repeater Repeater3 = (Repeater)(e.Item.FindControl("GenPerKeys1"));
            DataTable dt3 = new DataTable();

            dt3.Columns.Add(new DataColumn("KLO", typeof(string)));
            dt3.Columns.Add(new DataColumn("PerformanceInd", typeof(string)));



            HiddenField hdSubj = (HiddenField)e.Item.FindControl("Subject_Id");
            ViewState["Subject_Id"] = hdSubj.Value;
            string Student_Id = ViewState["Student_Id"].ToString();

            if (dtPer.Rows.Count > 0)
            {
                DataRow[] results = dtPer.Select("Student_Id='" + Student_Id + "' and Subject_Id='" + hdSubj.Value + "'");

                foreach (DataRow t in results)
                {
                    dt3.NewRow();
                    dt3.Rows.Add(t["KLO"], t["PerformanceInd"]);
                }
                ViewState["Count"] = dt3.Rows.Count;
                Repeater3.DataSource = dt3;
                Repeater3.DataBind();
            }
            HtmlTableCell subid = (HtmlTableCell)e.Item.FindControl("subid");
            HtmlTableCell PI = (HtmlTableCell)e.Item.FindControl("PI");
            ApplyStyleToSubject(subid,PI);
        }
        //}

        //catch (Exception ex)
        //{
        //    Session["error"] = ex.Message;
        //    Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        //}
    }



    protected void Reptr_Subject2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        //try
        //{

        RepeaterItem item = e.Item;
        if ((item.ItemType == ListItemType.Item) ||
            (item.ItemType == ListItemType.AlternatingItem))
        {

            Repeater Repeater3 = (Repeater)(e.Item.FindControl("GenPerKeys2"));
            DataTable dt3 = new DataTable();

            dt3.Columns.Add(new DataColumn("KLO", typeof(string)));
            dt3.Columns.Add(new DataColumn("PerformanceInd", typeof(string)));



            HiddenField hdSubj = (HiddenField)e.Item.FindControl("Subject_Id");
            ViewState["Subject_Id"] = hdSubj.Value;
            string Student_Id = ViewState["Student_Id"].ToString();

            if (dtPer.Rows.Count > 0)
            {
                DataRow[] results = dtPer.Select("Student_Id='" + Student_Id + "' and Subject_Id='" + hdSubj.Value + "'");

                foreach (DataRow t in results)
                {
                    dt3.NewRow();
                    dt3.Rows.Add(t["KLO"], t["PerformanceInd"]);
                }
                ViewState["Count"] = dt3.Rows.Count;
                Repeater3.DataSource = dt3;
                Repeater3.DataBind();
            }
            HtmlTableCell subid = (HtmlTableCell)e.Item.FindControl("subid");
            HtmlTableCell PI = (HtmlTableCell)e.Item.FindControl("PI");
            ApplyStyleToSubject(subid,PI);
        }
        //}

        //catch (Exception ex)
        //{
        //    Session["error"] = ex.Message;
        //    Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        //}
    }



    //*
    protected void Reptr_Subject3_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        

        RepeaterItem item = e.Item;
        if ((item.ItemType == ListItemType.Item) ||
            (item.ItemType == ListItemType.AlternatingItem))
        {

            Repeater Repeater3 = (Repeater)(e.Item.FindControl("GenPerKeys3"));
            DataTable dt3 = new DataTable();

            dt3.Columns.Add(new DataColumn("KLO", typeof(string)));
            dt3.Columns.Add(new DataColumn("PerformanceInd", typeof(string)));
            dt3.Columns.Add(new DataColumn("Marks_Obtained", typeof(string)));



            HiddenField hdSubj = (HiddenField)e.Item.FindControl("Subject_Id");
            ViewState["Subject_Id"] = hdSubj.Value;
            string Student_Id = ViewState["Student_Id"].ToString();

            if (dtPer.Rows.Count > 0)
            {
                DataRow[] results = dtPer.Select("Student_Id='" + Student_Id + "' and Subject_Id='" + hdSubj.Value + "'");

                foreach (DataRow t in results)
                {
                    dt3.NewRow();
                    dt3.Rows.Add(t["KLO"], t["PerformanceInd"], t["Marks_Obtained"]);
                }
                ViewState["Count"] = dt3.Rows.Count;
                Repeater3.DataSource = dt3;
                Repeater3.DataBind();


                // Handle the footer template for Marks Obtained
                if (dt3.Rows.Count > 0)
                {
                    if (hdSubj.Value == "18")
                    {

                        string marksObtained = dt3.Rows[0]["Marks_Obtained"].ToString();

                        RepeaterItem footer = Repeater3.Controls[Repeater3.Controls.Count - 1] as RepeaterItem;
                        if (footer != null && footer.ItemType == ListItemType.Footer)
                        {
                            //
                            HtmlTableCell footerMarks = footer.FindControl("footerMarks") as HtmlTableCell;
                            if (footerMarks != null)
                            {
                                footerMarks.InnerText = "Nazra :" + marksObtained + "/50";
                                footerMarks.Visible = true;
                            }
                        }
                    }
                }
            }
            HtmlTableCell subid = (HtmlTableCell)e.Item.FindControl("subid");
            HtmlTableCell PI = (HtmlTableCell)e.Item.FindControl("PI");
            ApplyStyleToSubject(subid,PI);
        }
        
    }








































    //Separate case
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
    protected void Reptr_GP3_ItemDataBound(object sender, RepeaterItemEventArgs e)
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


            if (ViewState["Subject_Id"].ToString() == "114" || ViewState["Subject_Id"].ToString() == "123" || ViewState["Subject_Id"].ToString() == "12" || ViewState["Subject_Id"].ToString() == "61" || ViewState["Subject_Id"].ToString() == "17" || ViewState["Subject_Id"].ToString() == "18")
            {
                HtmlTableCell GKLO = (HtmlTableCell)e.Item.FindControl("GKLO");
                if (GKLO != null)
                {
                    GKLO.Style.Add(HtmlTextWriterStyle.TextAlign, "right");
                    GKLO.Style.Add(HtmlTextWriterStyle.PaddingRight, "10px");
                    //GKLO.Style.Add(HtmlTextWriterStyle.Width, "37%");
                    GKLO.Style.Add(HtmlTextWriterStyle.FontFamily, "'Jameel Noori Nastaleeq', 'Urdu Typesetting', serif");
                    GKLO.Style.Add(HtmlTextWriterStyle.FontSize, "11px");
                }

            }
            else
            {
                HtmlTableCell GKLO = (HtmlTableCell)e.Item.FindControl("GKLO");
                GKLO.Style.Add(HtmlTextWriterStyle.FontFamily, "Calibri");
                GKLO.Style.Add(HtmlTextWriterStyle.FontSize, "11px");
            }

            HtmlTableCell pind = (HtmlTableCell)e.Item.FindControl("pind");
            if (pind.InnerText.Trim() == "EXP")
            {
                pind.Style.Add(HtmlTextWriterStyle.Color, "#7030A0");
            }
            else if (pind.InnerText.Trim() == "EXC")
            {
                pind.Style.Add(HtmlTextWriterStyle.Color, "#00B050");
            }
            else
            {
                pind.Style.Add(HtmlTextWriterStyle.Color, "#0070C0");
            }


        }
    }




    private void ApplyStyleToSubject(HtmlTableCell cell, HtmlTableCell cell2)
    {
        if (cell != null && cell.InnerText.Trim() == "English")
        {
            cell.Style.Add(HtmlTextWriterStyle.Color, "#8FB66F");
            cell.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#E0EECB");
            cell2.Style.Add(HtmlTextWriterStyle.Color, "#8FB66F");
            cell2.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#E0EECB");
        }

        if (cell != null && cell.InnerText.Trim() == "Mathematics")
        {
            cell.Style.Add(HtmlTextWriterStyle.Color, "#601872");
            cell.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#DED2E8");
            cell2.Style.Add(HtmlTextWriterStyle.Color, "#601872");
            cell2.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#DED2E8");
        }

        if (cell != null && cell.InnerText.Trim() == "General Knowledge")
        {
            cell.Style.Add(HtmlTextWriterStyle.Color, "#FBB571");
            cell.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FFE3B8");
            cell2.Style.Add(HtmlTextWriterStyle.Color, "#FBB571");
            cell2.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FFE3B8");
        }


        if (cell != null && cell.InnerText.Trim() == "Urdu")
        {
            cell.Style.Add(HtmlTextWriterStyle.Color, "#632423");
            cell.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#E5B8B7");
            cell2.Style.Add(HtmlTextWriterStyle.Color, "#632423");
            cell2.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#E5B8B7");
        }

        if (cell != null && cell.InnerText.Trim() == "Music and Art")
        {
            cell.Style.Add(HtmlTextWriterStyle.Color, "#7030A0");
            cell.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#CCC0D9");
            cell2.Style.Add(HtmlTextWriterStyle.Color, "#7030A0");
            cell2.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#CCC0D9");
        }

        if (cell != null && cell.InnerText.Trim() == "Computing")
        {
            cell.Style.Add(HtmlTextWriterStyle.Color, "#01B3F0");
            cell.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#CDECFC");
            cell2.Style.Add(HtmlTextWriterStyle.Color, "#01B3F0");
            cell2.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#CDECFC");
        }

        if (cell != null && cell.InnerText.Trim() == "Physical Education")
        {
            cell.Style.Add(HtmlTextWriterStyle.Color, "#413253");
            cell.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#B2A1C7");
            cell2.Style.Add(HtmlTextWriterStyle.Color, "#413253");
            cell2.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#B2A1C7");
        }

        if (cell != null && cell.InnerText.Trim() == "Islamiyat")
        {
            cell.Style.Add(HtmlTextWriterStyle.Color, "#012161");
            cell.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#C6D9F1");
            cell2.Style.Add(HtmlTextWriterStyle.Color, "#012161");
            cell2.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#C6D9F1");
        }

        if (cell != null && cell.InnerText.Trim() == "Nazra")
        {
            cell.Style.Add(HtmlTextWriterStyle.Color, "#B58029");
            cell.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#F0F371");
            cell2.Style.Add(HtmlTextWriterStyle.Color, "#B58029");
            cell2.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#F0F371");
        }
    }

}