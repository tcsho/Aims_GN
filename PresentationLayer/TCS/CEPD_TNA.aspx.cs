using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADG.JQueryExtenders.Impromptu;
using System.Collections.Generic;

public partial class PresentationLayer_CEPD_TNA: System.Web.UI.Page
{
    DALBase objBase = new DALBase();
   

    BLLCEPD_Category objec = new BLLCEPD_Category();

    protected void ddlTrainingRequired_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTrainingRequired.SelectedValue == "1")
        {
            pnlAcademicTraining.Visible = true;
            pnlNonAcademicTraining.Visible = false;
        }
        else if (ddlTrainingRequired.SelectedValue == "2")
        {
            pnlNonAcademicTraining.Visible = true;
            pnlAcademicTraining.Visible = false;
        }
        else
        {
            pnlNonAcademicTraining.Visible = false;
            pnlAcademicTraining.Visible = false;
        }
    }
}