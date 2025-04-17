using System;
using System.Linq;
using System.Data;
using ADG.JQueryExtenders.Impromptu;
using System.Web.UI.WebControls;

public partial class PresentationLayer_Section : System.Web.UI.Page
{
    BLLSection objSec = new BLLSection();
    DALBase objbase = new DALBase();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx", false);
            }
        }
        catch (Exception)
        {
        }
        try
        {
            ta_comments.Attributes.Add("OnChange", "javascript:if(this.value.length>=200){var textField=this.value;this.value=textField.substring(0,200);this.blur();alert('Comments Length Maximum Exceeded. Only First 200 Characters Will Be Saved')}");

            DataRow userrow = (DataRow)Session["rightsRow"];
            if (!Page.IsPostBack)
            {
                //======== Page Access Settings ========================
                DALBase objBase = new DALBase();
                string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
                string sRet = oInfo.Name;

               

                //====== End Page Access settings ======================

                int moID = Int32.Parse(Session["MoID"].ToString());

                if (Session["cId"] != null)
                {
                    BLLClass objCv = new BLLClass();
                    DataTable _dt = objCv.GetClassesByMOId(moID);
                    objBase.FillDropDown(_dt, list_class, "class_Id", "class_name");
                }
            } //end of postback

           
        } // end of try

        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }

    private void enableSection(bool command)
    {
        try
        {
            listb_subjectList.Enabled = command;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void but_saveClass_Click(object sender, EventArgs e)
    {
        try
        {


            DataTable dt;

            int cID = Int32.Parse(Session["cId"].ToString());

            if (text_sectionName.Text == "")
            {
                ImpromptuHelper.ShowPrompt("Enter name of the section.");
            }
            else
            {
                objSec.Class_Id = Int32.Parse(list_class.SelectedValue);
                objSec.Center_Id = Int32.Parse(Session["cId"].ToString());

                objSec.Section_Name = text_sectionName.Text;
                dt = objSec.SectionFetchBySetionNameClassCenter_Id(objSec);
                if (dt.Rows.Count == 0)
                {
                    objSec.Status_Id = 1;
                    objSec.Comments = ta_comments.Text;

                    objSec.SectionAdd(objSec);
                    clear();

                    ImpromptuHelper.ShowPrompt("Section successfully created.");
                }
                else
                {
                    ImpromptuHelper.ShowPrompt("Section name already exists. Section creation failed!");
                }
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }

    private void clear()
    {
        text_sectionName.Text = "";
        ta_comments.Text = "";
        BindSectionsGrid();
    }

    protected void lb_checkAvailability_Click(object sender, EventArgs e)
    {
        try
        {

            BLLSection objSec = new BLLSection();

            DataTable dt;

            if (text_sectionName.Text == "")
            {
                ImpromptuHelper.ShowPrompt("Please Enter Section Name");
            }
            else
            {
                objSec.Class_Id = Int32.Parse(list_class.SelectedValue.ToString());
                objSec.Center_Id = Int32.Parse(Session["cId"].ToString());
                objSec.Section_Name = text_sectionName.Text;
                dt = objSec.SectionFetchBySetionNameClassCenter_Id(objSec);

                if (dt.Rows.Count == 0)
                {
                    lab_availability.Text = "Available";
                    lab_availability.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lab_availability.Text = "Not available";
                    lab_availability.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }

    protected void BindSectionsGrid()
    {

        if (list_class.SelectedValue != "0")
        {
            BLLSection objSec = new BLLSection();
            objSec.Class_Id = Convert.ToInt32(list_class.SelectedValue);
            objSec.Center_Id = Int32.Parse(Session["cId"].ToString());
            DataTable dtSection = objSec.SectionFetchByClassCenter(objSec);
            gvSections.DataSource = dtSection;
            gvSections.DataBind();
        }


    }
    protected void list_class_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (list_class.SelectedValue != "0")
        {
            BindSectionsGrid();
        }

    }

    protected void btnDeleteSection_Click(object sender, EventArgs e)
    {
        try
        {
            BLLSection obj = new BLLSection();
            LinkButton btn = (LinkButton)sender;
            int SectionID = Convert.ToInt32(btn.CommandArgument);
            int ClassID = Convert.ToInt32(btn.CommandName);
            obj.Section_Id = SectionID;
            obj.Class_Id = ClassID;
            int k = obj.Class_SectionDelete(obj);
            if (k == 2)
            {
                //Success
            }
            else
            {
                //Unsuccessful
            }
            BindSectionsGrid();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }

    }
}
