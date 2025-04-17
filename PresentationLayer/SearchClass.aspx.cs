using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ADG.JQueryExtenders.Impromptu;

public partial class PresentationLayer_SearchClass : System.Web.UI.Page
{
    DALBase objBase = new DALBase();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx",false);
            }
        }
        catch (Exception)
        {
        }
        try
        {
            if (!Page.IsPostBack)
            {
                //======== Page Access Settings ========================
                DALBase objBase = new DALBase();
                DataRow row = (DataRow)Session["rightsRow"];
                string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
                string sRet = oInfo.Name;


                DataTable _dtSettings = objBase.ApplyPageAccessSettingsTable(sRet, Convert.ToInt32(row["User_Type_Id"].ToString()));
                this.Page.Title = _dtSettings.Rows[0]["PageTitle"].ToString();
                //tdFrmHeading.InnerHtml = _dtSettings.Rows[0]["PageCaption"].ToString();
                if (Convert.ToBoolean(_dtSettings.Rows[0]["isAllow"]) == false)
                {
                    Session.Abandon();
                    Response.Redirect("~/login.aspx",false);
                }

                //====== End Page Access settings ======================

                ///filling region
                ///
                int moID = Int32.Parse(Session["moID"].ToString());


                ///filling grade
                ///
                BLLGrade objGrade = new BLLGrade();
                objGrade.Main_Organisation_Id = moID;

                DataTable dt = objGrade.GradeSelectBymoID(objGrade);
                objBase.FillDropDown(dt, list_grade, "grade_Id", "grade");


            }

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    protected void but_search_Click(object sender, EventArgs e)
    {
        try
        {
            BLLClass objClass = new BLLClass();

            //SearchClassTableAdapters.SearchClassTableAdapter classDa = new SearchClassTableAdapters.SearchClassTableAdapter();

            objClass.Class_Name = text_className.Text;
            objClass.Grade_IdS = list_grade.SelectedValue.ToString();
            objClass.Main_Organisation_IdS = Session["moID"].ToString();
            DataTable dt = objClass.ClassFetchSearch(objClass);

            //            SearchClass.SearchClassDataTable dt = classDa.GetData(, list_grade.SelectedValue.ToString(), Session["moID"].ToString());
            if (dt.Rows.Count == 0)
            {
                lab_dataStatus.Visible = true;
            }
            else
            {
                dg_class.DataSource = dt;
                lab_dataStatus.Visible = false;
            }
            dg_class.DataBind();


            ViewState["classDT"] = dg_class.DataSource;
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void dg_class_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            dg_class.PageIndex = e.NewPageIndex;
            dg_class.DataSource = (DataTable)ViewState["classDT"];
            dg_class.DataBind();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }

    protected void dg_class_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
}
