using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;



public partial class PresentationLayer_TCS_AdmTestInst : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    bool flag = false;
    BLLAdmTestSubmissions ObjADST = new BLLAdmTestSubmissions();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            try
            {
                /*Check if Test is done*/
                LoadStudentData();
                //LoadStudentInformation();

            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
            }


        }
    }
  
    protected void LoadStudentData()
    {
        try
        {
            BLLAdmTestSubmissions ObjADS = new BLLAdmTestSubmissions();
            ObjADS.User_ID = Int32.Parse(Session["ContactID"].ToString());
            DataTable dt = ObjADS.AdmTestSubmissionsSelectInfromationByUserId(ObjADS);

            if (dt.Rows.Count > 0)
            {
                Session["StudentTestInfo"] = dt;
                tdReg.InnerText = dt.Rows[0]["Regisration_Id"].ToString();
                Session["Regisration_Id"] = dt.Rows[0]["Regisration_Id"].ToString();
                tdSName.InnerText = dt.Rows[0]["StudentName"].ToString();
                tdClass.InnerText = dt.Rows[0]["Class_Name"].ToString();
                tdCName.InnerText = dt.Rows[0]["Center_Name"].ToString();
                Session["cId"] = dt.Rows[0]["Center_Id"].ToString();
                Session["Class_Id"] = dt.Rows[0]["Grade_Id"].ToString();
                if (dt.Rows[0]["StatusOfStudent"].ToString() == "1" || dt.Rows[0]["StatusOfStudent"].ToString() == "2")
                {
                    trStatus.Visible = true;
                    btnSave.Visible = false;
                    trInstructions1.Visible = false;
                    trInstructions.Visible = false;
                }
                else if (dt.Rows[0]["StatusOfStudent"].ToString() == "0")
                {
                    btnSave.Visible = true;
                    btnSave.Text = "Start Test";
                    trStatus.Visible = false;
                    if (dt.Rows[0]["Grade_Id"].ToString() == "13")
                    {

                        if (dt.Rows[0]["Group_Type"].ToString() != "Not Applicable") // Group type not yet specified 
                        {
                            chkGroup_Type.Enabled = false;
                            chkGroup_Type.SelectedValue = dt.Rows[0]["Group_Type"].ToString();
                        }
                        trGroupType.Visible = true;
                    }
                }
                if (dt.Rows[0]["Lock_Marks"].ToString() == "True")
                {
                    Session["Mode"] = "NoTest";
                    btnSave.Visible = true;
                    btnSave.Text = "Review Report";

                    trStatus.Visible = false;
                }
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

    protected void LoadStudentInformation()
    {
        try
        {
            if (chkGroup_Type.SelectedValue == "Business")
                ObjADST.Group_Type = false;
            else
                ObjADST.Group_Type = true;
            ObjADST.User_ID = Int32.Parse(Session["ContactID"].ToString());

            int AlreadyIn = ObjADST.AdmTestSubmissionsSelectAdminTestByUserId(ObjADST);
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }



    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["Class_Id"].ToString() == "13")
            {
                bool b = chkGroup_Type.Items.Cast<ListItem>().Any(i => i.Selected);
                int count= chkGroup_Type.Items.Cast<ListItem>().Where(item => item.Selected).Count();
                if (b == false)
                {
                    ImpromptuHelper.ShowPrompt("You cannot proceed until you select a Group Type");
                    return;
                }
                if(count>1)
                {
                    ImpromptuHelper.ShowPrompt("Please Select one group Type");
                    return;
                }
                else
                    for (int i = 0; i <= count; i++)
                    {
                        if (chkGroup_Type.Items[i].Selected==true)
                        {
                            Session["Group_Type"] = chkGroup_Type.Items[i].Value;
                        }
                    }
                 //Session["Group_Type"]=0;
                //String s = Session["Group_Type"].ToString();
            }
            
            LoadStudentInformation();
            LoadStudentData();
            Response.Redirect("~/PresentationLayer/TCS/AdmissionTest.aspx", false);

            //Session["Mode"] = "NoTest";
            //Response.Redirect("~/PresentationLayer/TCS/Admission_Registeration_Evaluation_Criteria.aspx", false);

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }

}