using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using Newtonsoft.Json;
using System.Collections;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using System.Reflection;
using City.Library.SQL;

public partial class PresentationLayer_TCS_IEP_Form_Wizard : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    DataAccess obj_Access = new DataAccess();
    public DataSet exec_SP()
    {


        SqlParameter[] param = new SqlParameter[3];

        
        param[0] = new SqlParameter("@Student_id", Request.QueryString["s"].ToString());
        param[1] = new SqlParameter("@Session_Id", Session["Session_Id"].ToString());//Session["Session_Id"].ToString()
        param[2] = new SqlParameter("@TermId", "1");//Session["Session_Id"].ToString()


        DataSet ds = objBase.sqlcmdFetch_DS("Sp_IEP_Raisec_Wizard", param);
        ds.Dispose();
        return ds;
    }
    public DataSet exec_SP_Save(string json_interst_code)
    {


        SqlParameter[] param = new SqlParameter[5];


        param[0] = new SqlParameter("@Student_id", Request.QueryString["s"].ToString());
        param[1] = new SqlParameter("@user_id", Session["UserId"].ToString());//Session["Session_Id"].ToString()
        param[2] = new SqlParameter("@Session_Id", Session["Session_Id"].ToString());//Session["Session_Id"].ToString()
        param[3] = new SqlParameter("@TermId", "1");//Session["Session_Id"].ToString()
        param[4] = new SqlParameter("@json_intrest_code", json_interst_code);//Session["Session_Id"].ToString()


        DataSet ds = objBase.sqlcmdFetch_DS("SP_IEP_Form_Save", param);
        ds.Dispose();
        return ds;
    }
    private void Credentials()
    {
        //  DIV_Teacher01.Enabled = false;
        //  DIV_Teacher011.Enabled = false;
        //  DIV_Teacher02.Enabled = false;
        //DIV_Counsellor01.Enabled = false;
        // DIV_Counsellor02.Enabled = false;
        //  DIV_Counsellor04.Enabled = false;
        //   DIV_Counsellor03.Enabled = false;
        //  Counselor_div1.Enabled = false;

        string a = Session["UserType_Id"].ToString();



        if (Session["UserType_Id"].ToString() == "1")
        {
        //    DIV_Teacher01.Enabled = true;
      //      DIV_Teacher011.Enabled = true;
         //   DIV_Teacher02.Enabled = true;

         //   DIV_Counsellor03.Visible = false;
            btnSave.Visible = true;

        //    lbl.Text = "Individual Education Plan (Page 1 out of 1)";
          //  DisableControls(Page);
        }
        else if (Session["UserType_Id"].ToString() == "34")
        {
            //    DIV_Counsellor01.Enabled = true;
            //    DIV_Counsellor02.Enabled = true;
            //    DIV_Counsellor04.Enabled = true;

       //     DIV_Teacher01.Visible = false;
        //    DIV_Teacher011.Visible = false;
     //       DIV_Teacher02.Visible = false;
     //       tbl_MYE.Visible = false;


        //    DIV_Counsellor03.Visible = true;
        //    DIV_Counsellor03.Enabled = true;
             Counselor_div1.Enabled = true;
            btnSave.Visible = true;

        }
        else if (Session["UserType_Id"].ToString() == "5")
        {
            btnSave.Visible = false;
           

            //Counselor_div1.Enabled = false ;
            string studendID = Request.QueryString["s"].ToString();
            Response.Redirect("~/PresentationLayer/tcs/IEP_Form.aspx?s="+ studendID, false);

        }
        else if (Session["UserType_Id"].ToString() == "3" || Session["UserType_Id"].ToString() == "25" || Session["UserType_Id"].ToString() == "4")
        {
            string studendID = Request.QueryString["s"].ToString();
            Response.Redirect("~/PresentationLayer/tcs/IEP_Form.aspx?s=" + studendID, false);
            //DisableControls(Page, false);
        }
        else
        {
            Response.Redirect("~/PresentationLayer/Default.aspx", false);
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx", false);
            }

            if (!IsPostBack)
            {
                init();
                Credentials();
                //DropDownList ddlInterest_Code = ctrlIntrestCode.Items[0].FindControl("DdlInterest_Code") as DropDownList;
                //TextBox txtCareer_Goals = ctrlCareerGoals.Items[0].FindControl("txtCareer_Goals") as TextBox;
                //if (txtE_AcademicConcerns.Text != "" && ddlInterest_Code.SelectedItem.Text != "" && txtCareer_Goals.Text != "")
                //{
                //    // btnSend.Visible = false;
                //    // btn_bifurcation.Visible = false;
                //}
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
    public void init()
    {
        try
        {

            // DataSet ds = exec_SP(action: "GET_IEP", Optional1: Request.QueryString["ses"].ToString());
            DataSet ds = exec_SP();
            ViewState["vs_dataset"] = ds;
            ds.Dispose();
            if (ds.Tables[0].Rows[0]["ErpClass"].ToString() == "15" && Session["UserType_Id"].ToString() == "34")
            {

                lbl.Text = "Individual Education Plan (Page 1 out of 3)";
            }
            if (ds.Tables[0].Rows[0]["ErpClass"].ToString() != "15" && Session["UserType_Id"].ToString() == "34")
            {

                lbl.Text = "Individual Education Plan (Page 1 out of 2)";
            }


            if (ds.Tables[0].Rows[0]["PromotedToClass"].ToString() != "0")
            {
                //ieplbl.InnerText = ieplbl.InnerText + " " + ds.Tables[0].Rows[0]["session"].ToString();
                BindStudentDetail(ds.Tables[0]);
                Bind_ResultsoftheRAISECTest_Detail(ds.Tables[1]);
                
              
            }
            else
            {

               // iepstatus.InnerText = " Student Is  Promoted To 9 M (Matric)";
            }

        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
            lblerror.CssClass = "label label-danger text-center";
        }
    }
    protected void ctrlIntrestCode_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataSet ds = (DataSet)ViewState["vs_dataset"];
        if (e.Item.ItemType == ListItemType.Item ||
         e.Item.ItemType == ListItemType.AlternatingItem)
        {

            DropDownList DdlInterest_Codes = (e.Item.FindControl("DdlInterest_Code") as DropDownList);
            DdlInterest_Codes.DataSourceID = null;

            DdlInterest_Codes.DataSource = ds.Tables[2];
            DdlInterest_Codes.DataTextField = "Raisec";
            DdlInterest_Codes.DataValueField = "ID";
            DdlInterest_Codes.DataBind();
            DdlInterest_Codes.Items.Insert(0, new ListItem("Please select"));

            if (ds.Tables[1].Columns.Count > 5)
                DdlInterest_Codes.SelectedItem.Text = ds.Tables[1].Rows[e.Item.ItemIndex][4].ToString();


        }
        else
        {


        }


    }
    public DataTable Data_ResultsoftheRAISECTest()
    {
        try
        {
            DataTable dt_GetValues = new DataTable();
            dt_GetValues.Columns.Add("IEP_Type_Id");
            dt_GetValues.Columns.Add("Field_Name");
            dt_GetValues.Columns.Add("SN");
            dt_GetValues.Columns.Add("Value");

            for (int i = 0; i < ctrlIntrestCode.Items.Count; i++)
            {
                DropDownList ddlInterest_Code = ctrlIntrestCode.Items[i].FindControl("DdlInterest_Code") as DropDownList;
                HiddenField hdIEP_Type_Id = ctrlIntrestCode.Items[i].FindControl("hdIEP_Type_Id") as HiddenField;
                DataRow dr = dt_GetValues.NewRow();
                dr[0] = hdIEP_Type_Id.Value;
                dr[1] = "Interest_Code";
                dr[2] = (i + 1).ToString();
                dr[3] = ddlInterest_Code.SelectedItem.Text;
                dt_GetValues.Rows.Add(dr);
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            for (int i = 0; i < ctrlCareerGoals.Items.Count; i++)
            {
                TextBox txtCareer_Goals = ctrlCareerGoals.Items[i].FindControl("txtCareer_Goals") as TextBox;
                HiddenField hdIEP_Type_Id = ctrlCareerGoals.Items[i].FindControl("hdIEP_Type_Id") as HiddenField;
                DataRow dr = dt_GetValues.NewRow();
                dr[0] = hdIEP_Type_Id.Value;
                dr[1] = "Career_Goals";
                dr[2] = (i + 1).ToString();
                dr[3] = txtCareer_Goals.Text;
                dt_GetValues.Rows.Add(dr);
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            for (int i = 0; i < ctrlPersonalStrengths.Items.Count; i++)
            {
                TextBox Personal_Strengths = ctrlPersonalStrengths.Items[i].FindControl("txtPersonal_Strengths") as TextBox;
                HiddenField hdIEP_Type_Id = ctrlPersonalStrengths.Items[i].FindControl("hdIEP_Type_Id") as HiddenField;
                DataRow dr = dt_GetValues.NewRow();
                dr[0] = hdIEP_Type_Id.Value;
                dr[1] = "Personal_Strengths";
                dr[2] = (i + 1).ToString();
                dr[3] = Personal_Strengths.Text;
                dt_GetValues.Rows.Add(dr);
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            for (int i = 0; i < ctrlQualitiestoDevelop.Items.Count; i++)
            {
                TextBox txtQualities_to_Develop = ctrlQualitiestoDevelop.Items[i].FindControl("txtQualities_to_Develop") as TextBox;
                HiddenField hdIEP_Type_Id = ctrlQualitiestoDevelop.Items[i].FindControl("hdIEP_Type_Id") as HiddenField;
                DataRow dr = dt_GetValues.NewRow();
                dr[0] = hdIEP_Type_Id.Value;
                dr[1] = "Qualities_to_Develop";
                dr[2] = (i + 1).ToString();
                dr[3] = txtQualities_to_Develop.Text;
                dt_GetValues.Rows.Add(dr);
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            for (int i = 0; i < ctrlHobbiesInterests.Items.Count; i++)
            {
                TextBox txtHobbies_Interests = ctrlHobbiesInterests.Items[i].FindControl("txtHobbies_Interests") as TextBox;
                HiddenField hdIEP_Type_Id = ctrlHobbiesInterests.Items[i].FindControl("hdIEP_Type_Id") as HiddenField;
                DataRow dr = dt_GetValues.NewRow();
                dr[0] = hdIEP_Type_Id.Value;
                dr[1] = "Hobbies_Interests";
                dr[2] = (i + 1).ToString();
                dr[3] = txtHobbies_Interests.Text;
                dt_GetValues.Rows.Add(dr);
            }
            return dt_GetValues;
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    protected void btn_bifurcation_Click(object sender, EventArgs e)
    {
       // Response.Redirect("~/PresentationLayer/IEP_Undertaking_Bifurcation.aspx?S=" + spnErpNo.InnerText + "&C=" + hd_section_id.Value + "&T=" + 1);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsStdDetail = (DataSet)ViewState["vs_dataset"];
            string json_intrest_code = JsonConvert.SerializeObject(Data_ResultsoftheRAISECTest());
            DataSet ds = exec_SP_Save(json_intrest_code);
            if (ds.Tables.Count > 0)
            {
                lblerror.Text = ds.Tables[0].Rows[0][0].ToString();
                lblerror.CssClass = "label label-success text-center";

               

                string StudentId = dsStdDetail.Tables[0].Rows[0]["Student_Id"].ToString();
                string Calass = dsStdDetail.Tables[0].Rows[0]["erpclass"].ToString();
                if (dsStdDetail.Tables[0].Rows[0]["erpclass"].ToString() == "15")
                {

                    Response.Redirect("~/PresentationLayer/tcs/IEP_Form_Wizard_Sub.aspx?s=" + StudentId, false);

                //    Page.ClientScript.RegisterStartupScript(this.GetType(), null,
                //   @"
                //    $(document).ready(function () {{
                       

                          
                //            let timerInterval;
                //                Swal.fire({
                //                 title: ""Alert!"",
                //                     html: '" + ds.Tables[0].Rows[0][0].ToString() + @"',
                //                                timer: 2000,
                //                     timerProgressBar: true,
                //                     didOpen: () => {
                //                        Swal.showLoading();
                                         
                //                        timerInterval = setInterval(() => {
                                          
                //                                }, 100);
                //                            },
                //                     willClose: () => {
                //                    clearInterval(timerInterval);
                //                   window.location.href = 'IEP_Form_Wizard_Sub.aspx?s=" + StudentId + @"';

                //                     }
                //                }).then((result) => {
                //                 /* Read more about handling dismissals below */
                //                 if (result.dismiss === Swal.DismissReason.timer) {
                //                             console.log(""I was closed by the timer"");
                //                         }
                //                        });



                //    }});
           
                //", true);
                   // Response.Redirect("~/PresentationLayer/tcs/IEP_Form_Wizard_Sub.aspx?s="+ StudentId + "", false);
                }
                else
                {
                    Response.Redirect("~/PresentationLayer/tcs/IEP_Form_Wizard_CR.aspx?s=" + StudentId, false);
                  
                //    Page.ClientScript.RegisterStartupScript(this.GetType(), null,
                // @"
                //    $(document).ready(function () {{
                       

                //            let timerInterval;
                //                Swal.fire({
                //                 title: ""Alert!"",
                //                     html: '" + ds.Tables[0].Rows[0][0].ToString() + @"',
                //                                timer: 2000,
                //                     timerProgressBar: true,
                //                     didOpen: () => {
                //                        Swal.showLoading();
                                         
                //                        timerInterval = setInterval(() => {
                                          
                //                                }, 100);
                //                            },
                //                     willClose: () => {
                //                    clearInterval(timerInterval);
                //                   window.location.href = 'IEP_Form_Wizard_CR.aspx?s=" + StudentId + @"';

                //                     }
                //                }).then((result) => {
                //                 /* Read more about handling dismissals below */
                //                 if (result.dismiss === Swal.DismissReason.timer) {
                //                             console.log(""I was closed by the timer"");
                //                         }
                //                        });



                //    }});
           
                //", true);
                  //  Response.Redirect("~/PresentationLayer/tcs/IEP_Form_Wizard_CR.aspx?s="+ StudentId + "", false);
                }
                
                //Batch_Id.Value = ds.Tables[0].Rows[0][1].ToString();
            }
            else
            {
                lblerror.Text = "Record Not Saved";
                lblerror.CssClass = "label label-danger text-center";
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    private void Bind_ResultsoftheRAISECTest_Detail(DataTable dt)
    {
        try
        {
            DataTable dt_ResultsoftheRAISECTest = dt.AsEnumerable().Where(row => row.Field<String>("Field_Name") == "Interest_Code").CopyToDataTable();
            dt_ResultsoftheRAISECTest.Dispose();
            if (dt_ResultsoftheRAISECTest.Rows.Count > 0)
            {
                ctrlIntrestCode.DataSource = dt_ResultsoftheRAISECTest;
                ctrlIntrestCode.DataBind();
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            DataTable dt_CareerGoals = dt.AsEnumerable().Where(row => row.Field<String>("Field_Name") == "Career_Goals").CopyToDataTable();
            dt_CareerGoals.Dispose();
            if (dt_CareerGoals.Rows.Count > 0)
            {
                ctrlCareerGoals.DataSource = dt_CareerGoals;
                ctrlCareerGoals.DataBind();
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            DataTable dt_PersonalStrengths = dt.AsEnumerable().Where(row => row.Field<String>("Field_Name") == "Personal_Strengths").CopyToDataTable();
            dt_PersonalStrengths.Dispose();

            if (dt_PersonalStrengths.Rows.Count > 0)
            {
                ctrlPersonalStrengths.DataSource = dt_PersonalStrengths;
                ctrlPersonalStrengths.DataBind();
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            DataTable dt_QualitiestoDevelop = dt.AsEnumerable().Where(row => row.Field<String>("Field_Name") == "Qualities_to_Develop").CopyToDataTable();
            dt_QualitiestoDevelop.Dispose();

            if (dt_QualitiestoDevelop.Rows.Count > 0)
            {
                ctrlQualitiestoDevelop.DataSource = dt_QualitiestoDevelop;
                ctrlQualitiestoDevelop.DataBind();
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            DataTable dt_HobbiesInterests = dt.AsEnumerable().Where(row => row.Field<String>("Field_Name") == "Hobbies_Interests").CopyToDataTable();
            dt_HobbiesInterests.Dispose();

            if (dt_HobbiesInterests.Rows.Count > 0)
            {
                ctrlHobbiesInterests.DataSource = dt_HobbiesInterests;
                ctrlHobbiesInterests.DataBind();
            }



        }
        catch (Exception ex)
        {

            lblerror.Text = "Something went Wrong..";// ex.Message;
            lblerror.CssClass = "label label-danger text-center";
        }
    }

    private void BindStudentDetail(DataTable dt)
    {
        dt.Dispose();
        if (dt.Rows.Count > 0)
        {
            spnStudentName.InnerText = dt.Rows[0]["fullname"].ToString();
            spnErpNo.InnerText = dt.Rows[0]["student_id"].ToString();
            spnClass.InnerText = dt.Rows[0]["className"].ToString();
           // spnEmail.InnerText = dt.Rows[0]["student_email"].ToString();
        //    spnContactNo.InnerText = dt.Rows[0]["PrimaryContactNo"].ToString();
        //    txtExpected_Graduation_Year.Text = dt.Rows[0]["Expected_Graduation_Year"].ToString();
            lblAcknowledge_By_Class_Teacher.InnerText = dt.Rows[0]["Acknowledge_By_Class_Teacher"].ToString();
            lblAcknowledge_By_School_Head.InnerText = dt.Rows[0]["headname"].ToString();
            lblAcknowledge_By_Counselor.InnerText = dt.Rows[0]["Counselor"].ToString();
            if (dt.Rows[0]["erpclass"].ToString() == "12")
            {
                btn_bifurcation.Text = "Bifurcation";
            }
            else
            {

                btn_bifurcation.Text = "Undertaking";
            }
        }
        //if (Session["UserId"].ToString() == dt.Rows[0]["ClassTeacher_Id"].ToString())
        //{
        //    txtE_AcademicConcerns.Enabled = true;
        //    // btn_bifurcation.Visible = true;
        //    btnSend.Visible = true;
        //}

    }

    protected void DisableControls(Control parent, bool State)
    {
        foreach (Control c in parent.Controls)
        {
            if (c is DropDownList)
            {
                ((DropDownList)(c)).Enabled = State;
            }
            if (c is TextBox)
            {
                ((TextBox)(c)).Enabled = State;
            }
            if (c is RadioButton)
            {
                ((RadioButton)(c)).Enabled = State;
            }
        }

    }
}