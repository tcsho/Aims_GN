using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using ADG.JQueryExtenders.Impromptu;
using Newtonsoft.Json;

public partial class PresentationLayer_Component_Marks_Mark_Entry : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    private DataSet ds = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        
 
        

        var Center_id = "";
        var Code = "";
        var Org_Id = "";
        if (Session["cId"] == null || Session["EmployeeCode"] == null || Session["moID"]==null)
        {

            Response.Redirect("~/login.aspx", false);
        }
        else
        {
            Center_id = Session["cId"].ToString();
            Code = Session["EmployeeCode"].ToString();
            Org_Id = Session["moID"].ToString();
            Response.Redirect("~/PresentationLayer/Component_Marks/Mark_Entry.html?UserID=" + Code + "&Center_ID=" + Center_id+ "&Org_Id="+ Org_Id, false);
        }

    }

    [WebMethod]
    public static string doSomething(int EvaluationCriteriaTypeId, int SectionSubjectId, int Studentid, int EvaluationTypeId, int EvaluationCriteriaId)//
    {
        BLLStudent_Evaluation_Criteria objClsSec = new BLLStudent_Evaluation_Criteria();

        DataTable dtsub = new DataTable();
        DataSet ds = null;



        int Evaluation_Criteria_Type_Id = Convert.ToInt32(EvaluationCriteriaTypeId.ToString());
        int Section_Subject_Id = Convert.ToInt32(SectionSubjectId.ToString());
        int Student_id = Convert.ToInt32(Studentid.ToString());
        int Evaluation_Type_Id = Convert.ToInt32(EvaluationTypeId.ToString());
        int Evaluation_Criteria_Id = Convert.ToInt32(EvaluationCriteriaId.ToString());

        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", Evaluation_Criteria_Type_Id);
        param[1] = new SqlParameter("@Section_Subject_Id", Section_Subject_Id);
        param[2] = new SqlParameter("@Student_id", Student_id);
        param[3] = new SqlParameter("@Evaluation_Type_Id", Evaluation_Type_Id);
        param[4] = new SqlParameter("@Evaluation_Criteria_Id", Evaluation_Criteria_Id);


        ds = DALBase.getDataSetBySp("Student_Evaluation_CriteriaEVlCriteriaBySectSubjId", param);
        if (ds.Tables.Count == 0)
        {
            return "not hello";
        }
        var ss=ds.Tables[0].Columns[3].ToString();
        //Session["scol"] = ss;
        string JSONString = string.Empty;
        JSONString = JsonConvert.SerializeObject(ds.Tables[0]);
        return JSONString;
        //return "hello";
    }

    [WebMethod]
    public static string GenGrid(int EvaluationCriteriaTypeId)//,int SectionSubjectId,int Studentid,int EvaluationTypeId,int EvaluationCriteriaId
    {
        BLLStudent_Evaluation_Criteria objClsSec = new BLLStudent_Evaluation_Criteria();

        DataTable dtsub = new DataTable();
        DataSet ds = null;



        int Evaluation_Criteria_Type_Id =Convert.ToInt32(EvaluationCriteriaTypeId.ToString());
        //int Section_Subject_Id = SectionSubjectId;//Convert.ToInt32(list_Subject.SelectedValue.ToString());
        //int Student_id = Studentid;//Convert.ToInt32(list_student.SelectedValue.ToString());
        //int Evaluation_Type_Id = EvaluationTypeId;//Convert.ToInt32(list_EvlType.SelectedValue.ToString());
        //int Evaluation_Criteria_Id = EvaluationCriteriaId;//Convert.ToInt32(list_EvlCriteria.SelectedValue.ToString());

            SqlParameter[] param = new SqlParameter[5];

            param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", Evaluation_Criteria_Type_Id);
            //param[1] = new SqlParameter("@Section_Subject_Id", Section_Subject_Id);
            //param[2] = new SqlParameter("@Student_id", Student_id);
            //param[3] = new SqlParameter("@Evaluation_Type_Id", Evaluation_Type_Id);
            //param[4] = new SqlParameter("@Evaluation_Criteria_Id", Evaluation_Criteria_Id);


            ds = DALBase.getDataSetBySp("Student_Evaluation_CriteriaEVlCriteriaBySectSubjId", param);
            if (ds.Tables.Count == 0)
            {
                return "not hello";
            }
        return "hello";
        }
}