using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADG.JQueryExtenders.Impromptu;
using System.Web.UI;

public partial class PresentationLayer_TCS_SearchStudent : System.Web.UI.UserControl
{
    DALBase objBase = new DALBase();
    int UL_ID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ContactID"] == null)
        {
            Response.Redirect("~/login.aspx", false);
        }

        UL_ID = Convert.ToInt32(Session["UserLevel_Id"].ToString());

        if (!Page.IsPostBack)
        {
            //======== Page Access Settings ========================
            //DALBase objBase = new DALBase();
            DataRow row = (DataRow)Session["rightsRow"];
            //string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            //System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
            //string sRet = oInfo.Name;


            //DataTable _dtSettings = objBase.ApplyPageAccessSettingsTable(sRet, Convert.ToInt32(row["User_Type_Id"].ToString()));
            //this.Page.Title = _dtSettings.Rows[0]["PageTitle"].ToString();
            ////tdFrmHeading.InnerHtml = _dtSettings.Rows[0]["PageCaption"].ToString();
            //if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
            //{
            //    Session.Abandon();
            //    Response.Redirect("~/login.aspx", false);
            //}

            //====== End Page Access settings ======================


            #region Filling lists
            DALBase oDALBase = new DALBase();
            DataSet ods = new DataSet();
            ods = null;

            ods = oDALBase.get_Gender();

            DataTable dt = ods.Tables[0];

            objBase.FillDropDown(dt, list_gender, "Gender_Id", "Gender");

            BLLRegion oDALRegion = new BLLRegion();

            oDALRegion.Main_Organisation_Country_Id = Int32.Parse(Session["moID"].ToString());
            dt = oDALRegion.RegionFetch(oDALRegion);

            objBase.FillDropDown(dt, list_region, "Region_Id", "Region_Name");


            BLLStudent_Status objSS = new BLLStudent_Status();
            dt = objSS.Student_StatusFetch(objSS);
            objBase.FillDropDown(dt, list_studentStatus, "student_status_Id", "student_status");


            if (Convert.ToBoolean(row["Center"].ToString()) != true)
            {
                BLLClass objCS = new BLLClass();
                objCS.Main_Organisation_Id = Int32.Parse(Session["moID"].ToString());
                dt = objCS.ClassFetch(objCS);
            }
            else
            {
                BLLClass_Center objCC = new BLLClass_Center();

                DataRow rrow = (DataRow)Session["rightsRow"];
                objCC.Center_ID = Convert.ToInt32(rrow["Center_Id"].ToString());
                dt = objCC.Class_CenterFetch(objCC);
            }
            objBase.FillDropDown(dt, list_class, "Class_Id", "Class_Name");

            #endregion

            int UserLevel_ID = Convert.ToInt32(row["UserLevel_ID"].ToString());
            if (UserLevel_ID == 1 || UserLevel_ID == 2) //Head Office
            { }
            else if (UserLevel_ID == 3) //Regional Officer
            {
                list_region.SelectedValue = row["Region_Id"].ToString();
                list_region.Enabled = false;
                list_region_SelectedIndexChanged(sender, e);
            }
            else if (UserLevel_ID == 4) //Campus Officer
            {
                list_region.SelectedValue = row["Region_Id"].ToString();
                list_region.Enabled = false;
                list_region_SelectedIndexChanged(sender, e);

                list_center.SelectedValue = row["Center_Id"].ToString();
                list_center.Enabled = false;
                list_center_SelectedIndexChanged(sender, e);

                //lab_section.Visible = true;
                //list_section.Visible = true;
                list_section.Items.Insert(0, new ListItem("Select", ""));

            }
            else if (UserLevel_ID == 10) //Network
            {
                list_region.SelectedValue = row["Region_Id"].ToString();
                list_region.Enabled = false;
                list_region_SelectedIndexChanged(sender, e);

                lab_section.Visible = true;
                list_section.Visible = true;
                list_section.Items.Insert(0, new ListItem("Select", ""));
            }
            else if (UserLevel_ID == 5) //Teacher
            {
                list_region.SelectedValue = row["Region_Id"].ToString();
                list_region.Enabled = false;
                list_region_SelectedIndexChanged(sender, e);

                list_center.SelectedValue = row["Center_Id"].ToString();
                list_center.Enabled = false;
                list_center_SelectedIndexChanged(sender, e);

                list_teacher.SelectedValue = row["User_Id"].ToString();
                list_teacher.Enabled = false;

                lab_section.Visible = true;
                list_section.Visible = true;
                list_section.Items.Insert(0, new ListItem("Select", ""));
            }

            if (list_center.Enabled == false)
            {
                lab_center.Text = list_center.SelectedItem.Text;
                list_center.Visible = false;
            }
            if (list_region.Enabled == false)
            {
                lab_region.Text = list_region.SelectedItem.Text;
                list_region.Visible = false;
            }
            if (list_teacher.Enabled == false)
            {
                lab_teacher.Text = list_teacher.SelectedItem.Text;
                list_teacher.Visible = false;
            }


        }
    }

    protected void but_Export_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            BLLSearchStudent objSer = new BLLSearchStudent();

            objSer.First_Name = text_firstName.Text;
            objSer.Last_Name = text_lastName.Text;
            objSer.Middle_Name = text_middleName.Text;
            objSer.Date_Of_Birth = text_dateOfBirth.Text;
            objSer.Gender_Id = list_gender.SelectedValue;
            objSer.Student_No = text_studentNo.Text;
            objSer.Region_Id = list_region.SelectedValue;
            objSer.Student_Status_Id = list_studentStatus.SelectedValue;
            objSer.Center_Id = list_center.SelectedValue;
            objSer.Grade_Id = list_class.SelectedValue;
            objSer.Section_Id = list_section.SelectedValue;
            objSer.Main_Organisation_Id = Session["moId"].ToString();
            objSer.Teacher_Id = list_teacher.SelectedValue;
            dt = objSer.SearchStudentFetchExport(objSer);
            if (dt != null)
            {
                ExportToSpreadsheet(dt, "Students");


            }
            else
            {
                ImpromptuHelper.ShowPrompt("There Are No Search Results To Export!");
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }


    protected void list_class_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataRow row = (DataRow)Session["rightsRow"];
            if (Convert.ToBoolean(row["Center"].ToString()) == true || Convert.ToBoolean(row["Teacher"].ToString()) == true)
            {

                if (list_class.SelectedValue == "")
                {
                    list_section.Items.Clear();
                    list_section.Items.Insert(0, new ListItem("Select", ""));
                }
                else
                {
                    BLLSection objSec = new BLLSection();

                    objSec.Center_Id = Convert.ToInt32(row["Center_Id"].ToString());
                    objSec.Class_Id = Int32.Parse(list_class.SelectedValue);
                    DataTable dt = objSec.SectionFetchByClassCenter(objSec);
                    objBase.FillDropDown(dt, list_section, "section_Id", "section_name");

                }
            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    public void ExportToSpreadsheet(DataTable table, string name)
    {


        HttpContext context = HttpContext.Current;
        context.Response.Clear();

        foreach (DataColumn column in table.Columns)
        {
            context.Response.Write(column.ColumnName + "\t");

        }
        context.Response.Write(Environment.NewLine);
        foreach (DataRow row in table.Rows)
        {
            for (int i = 0; i < table.Columns.Count; i++)
            {
                context.Response.Write(row[i].ToString().Replace(",", string.Empty) + "\t");
            }

            context.Response.Write(Environment.NewLine);
        }

        context.Response.ContentType = "application/ms-excel";
        context.Response.AppendHeader("Content-Disposition", "attachment; filename = " + name + ".xls");



        context.Response.Flush();
        context.Response.SuppressContent = true;
        context.ApplicationInstance.CompleteRequest();


    }


    protected void list_region_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (list_region.SelectedValue == "")
            {
                list_center.Items.Clear();
                list_center.Items.Insert(0, new ListItem("Select", ""));
            }
            if (UL_ID == 10)//Load Network specifc centers
            {
                BLLNetworkCenter objnet = new BLLNetworkCenter();
                objnet.User_Id = Convert.ToInt32(Session["ContactID"].ToString());
                DataTable dt = new DataTable();
                dt = objnet.NetworkCenterSelectByUserID(objnet);
                objBase.FillDropDown(dt, list_center, "Center_Id", "Center_Name");
            }
            else
            {

                BLLCenter objCen = new BLLCenter();
                objCen.Region_Id = Int32.Parse(list_region.SelectedValue);
                DataTable dt = objCen.CenterFetchByRegionID(objCen);
                objBase.FillDropDown(dt, list_center, "center_Id", "center_name");
            }


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void list_center_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (list_center.SelectedValue == "")
            {
                list_teacher.Items.Clear();
                list_teacher.Items.Insert(0, new ListItem("Select", ""));
            }
            else
            {
                BLLSection_Subject objSecSub = new BLLSection_Subject();

                objSecSub.Center_Id = Int32.Parse(list_center.SelectedValue.ToString());
                DataTable dt = objSecSub.Section_SubjectSelectTeacherByCenter_Id(objSecSub);
                objBase.FillDropDown(dt, list_teacher, "user_Id", "name");
            }


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    public string firstName
    {
        get
        {
            return text_firstName.Text;
        }
    }
    public string lasttName
    {
        get
        {
            return text_lastName.Text;
        }
    }
    public string MiddletName
    {
        get
        {
            return text_middleName.Text;
        }
    }
    public string DOB
    {
        get
        {
            return text_dateOfBirth.Text;
        }
    }
    public string Gender
    {
        get
        {
            return list_gender.SelectedValue;
        }
    }
    public string StudentNo
    {
        get
        {
            return text_studentNo.Text;
        }
    }
    public string Region
    {
        get
        {
            return list_region.SelectedValue;
        }
    }
    public string StudentStatus
    {
        get
        {
            return list_studentStatus.SelectedValue;
        }

    }
    public string Center
    {
        get
        {
            return list_center.SelectedValue;
        }
    }
    public string Class
    {
        get
        {
            return list_class.SelectedValue;
        }
    }
    public string Section
    {
        get
        {
            return list_section.SelectedValue;
        }
    }
    public string Teacher
    {
        get
        {
            return list_teacher.SelectedValue;
        }
    }
}