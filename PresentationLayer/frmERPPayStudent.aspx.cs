using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using City.Library.SQL;
using City.Library.Utility;
using ADG.JQueryExtenders.Impromptu;

public partial class PresentationLayer_frmERPPayStudent : System.Web.UI.Page
{
    DataAccess obj_Access = new DataAccess();
    Utility obj_Utility = new Utility();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
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
                    Response.Redirect("~/login.aspx", false);
                }
                else
                {
                    FillGrid(); Page.Form.Attributes.Add("enctype", "multipart/form-data");
                }

                //====== End Page Access settings ======================

            }
            catch (Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
            }
        }
    }
    DataTable ExecuteProcedure(string sAction)
    {
        DataTable DT_Data = null;
        obj_Access.CreateProcedureCommand("SP_ERP_PaidStudent");
        obj_Access.AddParameter("P_UserID", Session["ContactID"] == null ? "-" : Session["ContactID"].ToString(), DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_Action", sAction, DataAccess.SQLParameterType.VarChar, true);
        try
        {
            DT_Data = obj_Access.ExecuteDataTable();
        }
        catch (Exception ex)
        {
            obj_Utility.MassageBox(ex.Message, ref UpdatePanel1);
        }
        finally
        {
            if (DT_Data != null) { DT_Data.Dispose(); }
        }
        return DT_Data;
    }
    protected void GV_Student_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (GV_Student.Rows.Count > 0)
            {
                GV_Student.UseAccessibleHeader = false;
                GV_Student.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
    public void FillGrid()
    {
        try
        {
            DataTable DT = ExecuteProcedure("GETD");
            DT.Dispose();
            if (DT.Rows.Count > 0)
            {
                GV_Student.DataSource = DT;
                GV_Student.DataBind();
            }

        }
        catch (Exception ex)
        {

            ImpromptuHelper.ShowPrompt(ex.Message);
        }


    }
}