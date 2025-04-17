using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using ADG.JQueryExtenders.Impromptu;
using System.Text.RegularExpressions;



public partial class PresentationLayer_StudentCriteriaMarksNew : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    private DataSet ds = null;
    private static log4net.ILog Log = log4net.LogManager.GetLogger(typeof(Login));
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                FillClassSection();
                trButtons.Visible = false;
            }

            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);


            }

        }
        if (PlaceHolder1.Controls.Count == 0)
        {
            BindGrid(false);
        }
            
    }

    private void FillClassSection()
    {
        try
        {
       BLLClass_Section obj = new BLLClass_Section();

        int EmployeeId = Convert.ToInt32(Session["EmployeeCode"].ToString());
        DataTable dt = (DataTable)obj.Class_SectionByEmployeeId(EmployeeId);

        objBase.FillDropDown(dt, List_ClassSection, "Section_Id", "FullClassSection");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void List_ClassSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (List_ClassSection.SelectedValue != "")
            {
                WelcomeLetterAcknowledgement objWLA = new WelcomeLetterAcknowledgement();
                objWLA.Session_id = Convert.ToInt32(Session["Session_Id"].ToString());
                objWLA._ddl = List_ClassSection;
                objWLA.ISWelcomeAcknowledge(objWLA);

                PlaceHolder1.Controls.Clear(); 
                BindSubject();
                BindTerm();

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    private void BindGrid(bool doOverride)
    {

        try
        {
            

            PlaceHolder1.Controls.Clear();

            BLLStudent_Evaluation_Criteria objClsSec = new BLLStudent_Evaluation_Criteria();

            DataTable dtsub = new DataTable();

            if (list_Term.SelectedIndex > 0 && list_Subject.SelectedIndex > 0)
            {
                trButtons.Visible = true;

                int Evaluation_Criteria_Type_Id = Convert.ToInt32(list_Term.SelectedValue.ToString());
                int Section_Subject_Id = Convert.ToInt32(list_Subject.SelectedValue.ToString());
                int Student_id = Convert.ToInt32(list_student.SelectedValue.ToString());

                SqlParameter[] param = new SqlParameter[3];

                param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", Evaluation_Criteria_Type_Id);
                param[1] = new SqlParameter("@Section_Subject_Id", Section_Subject_Id);
                param[2] = new SqlParameter("@Student_id", Student_id);
                ds = DALBase.getDataSetBySp("Student_Evaluation_CriteriaBySectionSubjectId", param);
                if (ds.Tables.Count == 0)
                {
                    return;
                }


                ViewState["dtDetails"] = ds.Tables[0];
                DataSet lockMarkDs = DALBase.getDataSetBySp("Student_Evaluation_CriteriaBySectionSubjectIdMarksLock", param);
                DataRow[] lockMarkRow = null;



                if (ds.Tables.Count == 0)
                {
                    return;
                }
                TextBox tb;
                RegularExpressionValidator regVal;
                RangeValidator ranVal;
                Label lab_error;
                String myClass;
                int x;

                PlaceHolder1.Controls.Add(new LiteralControl("<table border='1'>"));
                PlaceHolder1.Controls.Add(new LiteralControl("<tr style='color:#FFF; background-color: #868B74; '>"));
                int[] studentId = new int[ds.Tables[0].Rows.Count];
                int[] criteriaId = new int[ds.Tables[0].Columns.Count];

                string tempStudentId, header, totalmarks;
                string[] t;
                char[] del = new char[2];
                del[0] = '=';
                del[1] = '=';

                for (int c = 0; c < ds.Tables[0].Columns.Count; c++)
                {
                    if (c == 0)
                        PlaceHolder1.Controls.Add(new LiteralControl("<td>No.</td>"));
                    else if (c == 1)
                    {
                        header = ds.Tables[0].Columns[c].ToString();
                        PlaceHolder1.Controls.Add(new LiteralControl("<td style='padding: 5px; '>" + header + "</td>"));

                    }
                    else if (c > 2)
                    {
                        header = ds.Tables[0].Columns[c].ToString();

                        tempStudentId = ds.Tables[0].Columns[c].ToString();
                        t = tempStudentId.Split(del);
                        criteriaId[c] = Int32.Parse(t[2]);
                        header = t[0];
                        totalmarks = t[1];
                        string headerNew = "<Center style='text-align:center'>" + header + " <br> Total Marks " + totalmarks + "</Center>";
                        if (header== "Class Learning")
                        {
                            headerNew = "<Center style='text-align:center'>" + header + " <br> Percentage " + totalmarks + "</Center>";
                        }
                        else
                        {
                            headerNew = "<Center style='text-align:center'>" + header + " <br> Total Marks " + totalmarks + "</Center>";
                        }



                        PlaceHolder1.Controls.Add(new LiteralControl("<td style='padding: 5px; ' class='verticaltext'>" + headerNew + "</td>"));

                    }
                }
                PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));

                for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                {
                    Math.DivRem(r, 2, out x);
                    if (x == 0)
                        myClass = "trgv1";
                    else
                        myClass = "trgv2";

                    PlaceHolder1.Controls.Add(new LiteralControl("<tr>"));

                    for (int c = 0; c < ds.Tables[0].Columns.Count; c++)
                    {
                        if (c > 2)
                        {
                            lockMarkRow = lockMarkDs.Tables[0].Select("student_section_subject_id = " + ds.Tables[0].Rows[r][0].ToString() + " and SSEC_Id = " + criteriaId[c].ToString());

                            PlaceHolder1.Controls.Add(new LiteralControl("<td  class='" + myClass + "'>"));
                            tb = new TextBox();
                            tb.ID = "hello" + r.ToString() + "_" + c.ToString();
                            tb.Attributes.Add("onkeyup", "decimal_notallowed(this)");
                            if (doOverride)
                                tb.Text = ds.Tables[0].Rows[r][c].ToString();
                            if (tb.Text == "")
                                tb.Text = "";

                           
                            tb.TabIndex = short.Parse(c.ToString());
                            tb.Width = 70;

                            tb.EnableViewState = true;
                            tb.ValidationGroup = "valSave";

                            if (lockMarkRow != null && lockMarkRow.GetLength(0) != 0)
                            {

                                tb.Enabled = !(bool.Parse(lockMarkRow[0]["lock_mark"].ToString()));
                            }
                            
                            tb.Font.Size = 10;
                            String s = lockMarkRow[0]["lock_mark"].ToString(); 
                            //String s = lockMarkRow["lock_mark"].ToString();
                            if ((bool.Parse(lockMarkRow[0]["lock_mark"].ToString())) == true)
                            {
                                tb.ForeColor = Color.Indigo;
                                tb.BackColor = Color.LightGray;
                                tb.Font.Bold = true;
                                tb.Font.Size = 13; 
                                tb.ToolTip = "Marks editing is locked.";
                            }
                            if (tb.Text == "0")
                            {
                                if (tb.ForeColor!=Color.Indigo)
                                {
                                    tb.BackColor = Color.Yellow;
                                }
                                else
                                {
                                    tb.BackColor = Color.LightGray;

                                }

                            }
                            else
                            {
                                if (tb.ForeColor == Color.Indigo)
                                {   
                                    tb.BackColor = Color.LightGray;

                                }

                            }


                            PlaceHolder1.Controls.Add(tb);

                            lab_error = new Label();
                            lab_error.ForeColor = System.Drawing.Color.Red;
                            lab_error.ID = "error" + r.ToString() + "_" + c.ToString();
                            PlaceHolder1.Controls.Add(lab_error);
                            PlaceHolder1.Controls.Add(new LiteralControl("</td>"));


                        }

                        else if (c == 0)
                        {
                            PlaceHolder1.Controls.Add(new LiteralControl("<td class='" + myClass + "'>" + ((int)(r + 1)).ToString() + "</td>"));
                            studentId[r] = Int32.Parse(ds.Tables[0].Rows[r][c].ToString());
                        }
                        else if (c == 1)
                        {


                            PlaceHolder1.Controls.Add(new LiteralControl("<td width='300px' class='" + myClass + "'>" + ds.Tables[0].Rows[r][c].ToString() + "</td>"));


                        }

                    }

                    PlaceHolder1.Controls.Add(new LiteralControl("</tr>"));

                }

                PlaceHolder1.Controls.Add(new LiteralControl("<table>"));



                ViewState["skill_ids"] = studentId;
                ViewState["student_ids"] = criteriaId;


            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
   
    private void BindSubject()
    {
        try
        {
        BLLSection_Subject obj = new BLLSection_Subject();
        
        obj.Section_Id = Convert.ToInt32(List_ClassSection.SelectedValue.ToString());
        obj.Employee_Id = Convert.ToInt32(Session["EmployeeCode"].ToString());

        DataTable dt = (DataTable)obj.Section_SubjectSelectBySectionTeacherEvaluation(obj);
        objBase.FillDropDown(dt, list_Subject, "Section_Subject_Id", "Subject_Name");
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    private void BindStudent()
    {
        try
        {

        BLLSection_Subject obj = new BLLSection_Subject();
        int SectionSubjectId = Convert.ToInt32(list_Subject.SelectedValue.ToString());

        DataTable dt = (DataTable)obj.StudentBySectionSubjectId(SectionSubjectId);
        objBase.FillDropDown(dt, list_student, "Student_Id", "FullStudentName");
        ViewState["StudentList"] = dt;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    private void AddMissingStudent()
    {
        try
        {
        BLLStudent_Evaluation_Criteria obje = new BLLStudent_Evaluation_Criteria();
        int AlreadyIn = 0;
        DataTable DTs = (DataTable)ViewState["StudentList"];

        for (int i = 0; i < DTs.Rows.Count; i++)
        {
             obje.Student_Id = Convert.ToInt32(DTs.Rows[i]["Student_Id"].ToString().Trim());
             obje.Section_Id = Convert.ToInt32(List_ClassSection.SelectedValue);

             AlreadyIn = obje.Student_Evaluation_CriteriaInsertMissingStudent(obje);
        }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    private void BindTerm()
    {
        try
        {
        if (List_ClassSection.SelectedIndex>0)
        {
            BLLSection_Subject obj = new BLLSection_Subject();

            obj.Org_Id = Convert.ToInt32(Session["moID"].ToString());
            obj.Section_Id = Convert.ToInt32(List_ClassSection.SelectedValue);

            DataTable dt = obj.Evaluation_Criteria_TypeBySectionId(obj);

            objBase.FillDropDown(dt, list_Term, "Id", "Type");

   
        }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    int chkloop;
    protected void btnSave_Click(object sender, EventArgs e)
       
    {
        TextBox tb = new TextBox();

        try
        {
            
            BLLStudent_Evaluation_Criteria obj = new BLLStudent_Evaluation_Criteria();
            int AlreadyIn = 0;
            System.Text.StringBuilder buildXml = new System.Text.StringBuilder("");

            int[] sssId = (int[])(ViewState["student_ids"]);
            int[] studentId = (int[])(ViewState["skill_ids"]);
            //
           
            Label lab_error;
            decimal result;
            //long result;
            int MinusNum = 0;
            DataTable dtDetails = (DataTable)ViewState["dtDetails"];
            string StudentNames = "";
           // int seterror = 0;
            //int correct_error = 0;
           for (int c = 3; c < sssId.GetLength(0); c++)
            {
                for (int r = 0; r < studentId.GetLength(0); r++)
                {
                    tb = (TextBox)(PlaceHolder1.FindControl("hello" + r.ToString() + "_" + c.ToString()));
                   //if(tb.Text != "")
                   // { 
                   // if (!Regex.Match(tb.Text, @"^\d+$").Success)
                   // {
                   //         // zip was incorrect  
                   //         //Response.Write("Invalid zip code", "Message");
                   //         tb.BackColor = Color.Red;
                            
                   //         tb.Focus();
                        
                   //     ImpromptuHelper.ShowPrompt("Entry in decimal numbers not allowed");
                   //         //return;
                   //         seterror = 1;


                   //     }
                   // }
                    if (decimal.TryParse(tb.Text, out result))
                    {
                        //correct_error = 1;
                        if (result == -1)
                            MinusNum++;
                        
                    }
                   
                }
               
                if (MinusNum != studentId.GetLength(0) && MinusNum != 0)
                {
                    string[] Names = dtDetails.Columns[c].ColumnName.Split('#');
                    if (StudentNames != "")
                        StudentNames = StudentNames + ", " + Names[0];
                    else
                        StudentNames = Names[0];

                }
                MinusNum = 0;
            }

            //if (seterror == 1)
            //{
            //    tb.BackColor = Color.Red;
            //    seterror = 0;
            //    return;
            //}
           

            if (StudentNames != "")
            {
                return;
            }

            chkloop = 0;
            

            for (int r = 0; r < studentId.GetLength(0); r++) // for all students
            {
               

                    for (int c = 3; c < sssId.GetLength(0); c++) // for every Criteria of a Student
                        {
                            
                        tb = (TextBox)(PlaceHolder1.FindControl("hello" + r.ToString() + "_" + c.ToString()));
                        lab_error = (Label)(PlaceHolder1.FindControl("error" + r.ToString() + "_" + c.ToString()));
                    //if (tb.Text != "")
                    //{
                    //    if (!Regex.Match(tb.Text, @"^\d+$").Success)
                    //    {
                         
                    //        tb.BackColor = Color.Red;
                    //        tb.Focus();
                    //        ImpromptuHelper.ShowPrompt("Entry in decimal numbers not allowed");
                        
                    //    }
                    //}

                    if (decimal.TryParse(tb.Text, out result))
                        {
                            string tempStudentId, header;
                            int totalmarks;
                            string[] t;
                            char[] del = new char[2];
                            del[0] = '=';
                            del[1] = '=';

                            header = ds.Tables[0].Columns[c].ToString();

                            tempStudentId = ds.Tables[0].Columns[c].ToString();
                            t = tempStudentId.Split(del);
                            header = t[0];
                            totalmarks = Int32.Parse(t[1]);

                            if (result >=0 && result <= totalmarks)
                            {
                                obj.Student_Section_Subject_Id = studentId[r];
                                obj.SSEC_Id = sssId[c];
                                obj.Marks_Obtained = result;


                                buildXml.Append("<row>");
                                buildXml.Append("<Student_Section_Subject_Id>");
                                buildXml.Append(studentId[r]);
                                buildXml.Append("</Student_Section_Subject_Id>");

                                buildXml.Append("<SSEC_Id>");
                                buildXml.Append(sssId[c]);
                                buildXml.Append("</SSEC_Id>");

                                buildXml.Append("<Marks_Obtained>");
                                buildXml.Append(result);
                                buildXml.Append("</Marks_Obtained>");

                                buildXml.Append("<mlock>");
                                buildXml.Append(0);
                                buildXml.Append("</mlock>");

                                buildXml.Append("</row>");
                                lab_error.Text = "";
                               

                            }
                            
                            
                            
                            if (result==0)
                            {
                                tb.BackColor = Color.Yellow;
                            }
                            else if(result <0 || result>totalmarks)
                            {
                                tb.BackColor = Color.Red;
                                tb.Focus();
                                chkloop = 1;
                            }
                            else
                            {
                                if (tb.ForeColor!=Color.Indigo)
                                {
                                    tb.BackColor = Color.White;    
                                }
                                else
                                {
                                    tb.BackColor = Color.LightGray;
                                }
                                

                            }
                        }
                        else
                        {
                            tb.Focus();

                        }

                    
                }
            }

            obj.XMLData = "<data>" + buildXml.ToString() + "</data>";

            AlreadyIn = obj.Student_Evaluation_CriteriaUpdateXML(obj);

            if (chkloop == 0)
            {
                ImpromptuHelper.ShowPrompt("Record Saved Successfully");
                BindGrid(true);
            }
            else
            {
                ImpromptuHelper.ShowPrompt("Values less than zero or exceed Total Marks are not saved!");

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }

    protected void list_Subject_SelectedIndexChanged(object sender, EventArgs e)
    {
         try
        {
            if (list_Subject.SelectedValue != "")
            {
                 BindStudent();
                 PlaceHolder1.Controls.Clear();
                 if (list_Term.SelectedIndex>0)
                 {
                     list_Term.SelectedValue = "0";
                 }
            }
        }
         catch (Exception ex)
         {
             Session["error"] = ex.Message;
             Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
         }
       
    }
    protected void list_Term_SelectedIndexChanged(object sender, EventArgs e)
    {
         try
        {
            if (list_Term.SelectedValue != "")
            {

                AddMissingStudent();
                BindGrid(true);

            }
        }
         catch (Exception ex)
         {
             Session["error"] = ex.Message;
             Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
         }
    }
    protected void list_student_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        if (list_Term.SelectedIndex>0)
        {
            BindGrid(true);
        }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }



   
}