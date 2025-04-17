using City.Library.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PresentationLayer_TCS_EmailSend_ByUser : System.Web.UI.Page
{
    DALBase objBase = new DALBase();
    DataAccess obj_Access = new DataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            loadRegions();
        }

    }


    private void loadRegions()
    {
        try
        {

            BLLRegion oDALRegion = new BLLRegion();
            DataTable dt = new DataTable();

            BLLSection_Subject obj = new BLLSection_Subject();

            oDALRegion.Main_Organisation_Country_Id = Convert.ToInt32(1);
            dt = oDALRegion.RegionFetch(oDALRegion);

            objBase.FillDropDown(dt, ddl_region, "Region_Id", "Region_Name");
            DataTable dt_class = exec_SP("", "", "LOV_Class");

            dt_class = dt_class.AsEnumerable().Where(r => r.Field<int>("Class_id") > 12).CopyToDataTable();
            dt_class = dt_class.AsEnumerable().Where(r => r.Field<int>("Class_id") < 15).CopyToDataTable();
            objBase.FillDropDown(dt_class, ddlClass, "Class_id", "Class_Name");


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }


    }
    public DataTable exec_SP(string Center, string Class, string Action)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Center_id", Center);
        param[1] = new SqlParameter("@Class_id", Class);
        param[2] = new SqlParameter("@Action", Action);
        DataTable dt = objBase.sqlcmdFetch("Sp_View_IEP", param);
        dt.Dispose();
        return dt;
    }

    protected void ddlterm_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt1 = GetUndertaking_studentsbyregion(ddl_region.SelectedValue, ddlClass.SelectedValue, ddlterm.SelectedValue);
        ViewState["Datatable"] = dt1;
        Grid.DataSource = dt1;
        Grid.DataBind();
    }
    protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        BLLSection_Subject obj = new BLLSection_Subject();
        obj.Org_Id = Convert.ToInt32(Session["moID"].ToString());
        obj.Section_Id = Convert.ToInt32(ddlClass.SelectedValue);

        DataTable dt1 = obj.Evaluation_Criteria_TypeBySectionId(obj);
        objBase.FillDropDown(dt1, ddlterm, "TermGroup_ID", "Type");

        Grid.DataSource = null;
        Grid.DataBind();
    }

    public DataTable GetUndertaking_studentsbyregion(string Center, string Class, string Action)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Region_id", Center);
        param[1] = new SqlParameter("@Class_id", Class);
        param[2] = new SqlParameter("@Term", Action);
        DataTable dt = objBase.sqlcmdFetch("Sp_GetUndertaking_studentsbyregion", param);
        dt.Dispose();
        return dt;
    }


    protected void btn_email_Click(object sender, EventArgs e)
    {

        DataTable dt = (DataTable)ViewState["Datatable"];


        for (int i = 0; i < dt.Rows.Count; i++)
        {

            //  Email_Reports Bulk_Mail_sent = new Email_Reports();
            MailMessage mail = new MailMessage();
            var Body = "";
            var To = "";

            var Email = new MailAddress("AppNotifications@csn.edu.pk", "The City School");
            To = dt.Rows[i]["Email"].ToString();
            var getclass = (dt.Rows[i][2].ToString()); //ViewState["classids"].ToString();
            var getterm = (dt.Rows[i][8].ToString());//ViewState["TermGroupID"].ToString();
            var term = "";
            if (getterm == "1")
                term = "1st";
            else
                term = "2nd";
            TextLog(dt.Rows[4].ToString() + Environment.NewLine);
            /***********HTML TEMPLET***/
            var Subject = "";
            if (getclass == "13" && getterm == "1" || getterm == "2")
                Subject = "Undertaking – Class 9 (" + term + " term)";
            else
                Subject = "Undertaking – Class 10 (" + term + " term)";



            var onclassbase = "";

            /***********HTML TEMPLET***/
            Body += "<body style='margin:0;padding:0;'>";
            Body += "<table role='presentation' style='width:100%;border-collapse:collapse;border:0;border-spacing:0;background:#ffffff;'>";
            Body += "<tr>";
            Body += "<td align='center' style='padding:0;'>";
            Body += "<table role='presentation' style='width:602px;border-collapse:collapse;border:1px solid #cccccc;border-spacing:0;text-align:left;'>";
            Body += "<tr>";
            Body += "<td align='center' style='padding:40px 0 30px 0;background:#0c4da2;'>";//#0c4da2



            //Body += "< img src = 'http://tcsresults.csn.edu.pk/ReportCard/images/logo.png' alt = '' width = '300' style = 'height:auto;display:block;' /> ";
            Body += "<img src = 'https://rebill.csn.edu.pk:8096/inassets/city/tcslogowhite.png'>";
            Body += "</td>";
            Body += "</tr>";
            Body += "<tr>";
            Body += "<td style='padding:36px 30px 42px 30px;'>";
            Body += "<table role='presentation' style='width:100%;border-collapse:collapse;border:0;border-spacing:0;'>";
            Body += "<tr>";
            Body += "<td style='padding:0 0 36px 0;color:#153643;'>";
            Body += "<h1 style='font-size:24px;margin:0 0 20px 0;font-family:Arial,sans-serif;'>Dear Parent/Guardian</h1>";



            Body += "<p style='margin:0 0 12px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;'>If you wish for your child to continue on the O-Level route, then please read & submit the application for undertaking. </p><br/><br/>";




            Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>I, as a parent / guardian of <strong>" + dt.Rows[i][1].ToString() + "</strong>ERP # " + dt.Rows[i][0].ToString() + "</strong> studying in Class " + dt.Rows[i][3].ToString() + " </strong> confirm that I have fully read and understood the points below. My acknowledgement indicates full agreement and consent to apply the appropriate consequences stated:</p>";



            /**on basis change**/
            /**CLASS UNDERTAKING**/

            if (getclass == "12" && getterm == "1")
            {

                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 1) tThe school, after careful deliberation and consideration of the Class 8 Results, has advised me to transfer my child to the Matric system.</p>";
                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 2) However, I am insisting that my child should continue the O-Level route.</p>";
                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 3) I take the responsibility that my child will meet the school’s required attainment levels.</p>";
                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 4) Failure to meet the minimum requirements in the internal exams may result in my child’s private registration for his/her CAIE Exams.</p>";
            }
            if (getclass == "12" && getterm == "2")
            {

                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 1) The school has clearly explained that my child’s class 8 (2nd term) result is not up to the mark.</p>";
                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 2) I take the responsibility that my child will meet the school’s required attainment levels.</p>";
                onclassbase += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 3) Failure to meet the minimum requirements in the internal exams may result in my child’s private registration for his/her CAIE Exams</p>";

            }

            if (getclass == "13" && getterm == "2")
            {


                onclassbase = "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>" +
                    " 1) The school has clearly explained that my child’s class 9 (2nd term) result is not up to the mark.</p>" +
                    "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> " +
                    "2) I take the responsibility that my child will meet the school’s required attainment levels.</p>" +
                     "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> " +
                    "3) Failure to meet the minimum requirements in the internal exams may result in my child’s private registration for his/her CAIE Exams.</p>";

            }

            if (getclass == "13" && getterm == "1")
            {


                onclassbase = "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> " +
                    "1) The school has clearly explained that my child’s class 9 (1st term) result is not up to the mark." +
                      "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> " +
               " 2) I take the responsibility that my child will meet the school’s required attainment levels.+ " +
                 "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> " +
                "3) Failure to meet the minimum requirements in the internal exams may result in my child’s private registration for his/her CAIE Exams. </p>";

            }


            if (getclass == "14" && getterm == "2")
            {

                onclassbase = "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 1) The school has clearly explained that my child’s class 10 (1st term) result is not up to the mark.</p>" +
                    "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> " +
                    "2) I take the responsibility that my child will meet the school’s required attainment levels.</li>" +
                    "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> " +
                    "<li> Failure to meet the minimum requirements in the upcoming CAIE and the internal exams may result in my child’s private registration for his/her CAIE Exams next year.</p>";

            }
            if (getclass == "14" && getterm == "1")
            {

                onclassbase = "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 1) That the school, after careful deliberation and consideration of the Class 9 EOY Results, had provisionally promoted my child to Year 10.</p><p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 2) My child has not passed the Class 10 Mid-year examinations with the minimum required attainment levels and is provisionally being allowed to appear for Year 10 Mock examinations with the condition of attaining overall 60%. Failing to meet the minimum requirements may result in my child being privatized at the time of final Cambridge exams.</p>";

            }

            if (getclass == "15" && getterm == "2")
            {

                onclassbase = "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 1) That the school, after careful deliberation and consideration of the Class 11 Mid-year examination Results, had provisionally allowed my child to sit for Year 11 Mock examinations. </p><p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 2) My child has not passed the Class 11 Mock examinations with the minimum required attainment levels and is going to be privatized for Cambridge Exams.</p>";

            }

            if (getclass == "15" && getterm == "1")
            {

                onclassbase = "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 1) That the school, after careful deliberation and consideration of the Class 10 Mocks and Cambridge Results, had provisionally promoted my child to Year 11.</p><p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'> 2) My child has not passed the Class 11 Mid-year examinations with the minimum required attainment levels and is provisionally being allowed to appear for Year 11 Mock examinations with the condition of attaining overall 60%. Failing to meet the minimum requirements may result in my child being privatized at the time of final Cambridge exams.</p>";

            }




            Body += onclassbase;

            Body += "<p style='margin:0 0 12px 0;font-size:14px;line-height:24px;font-family:Arial,sans-serif;'>Please press confirm button to submit your request</p>";

            var url = "http://tcsaims.com/PresentationLayer/Bifurcation_Confirmation.aspx?St_Id=" + dt.Rows[i][0].ToString() + "&Cl_Id=" + dt.Rows[i][2].ToString() + "&Sess_Id=" + Session["Session_Id"].ToString();//ddlStudent.SelectedValue
            Body += "<p style='text-align:center'><b><a style='color: #fff;text-decoration:none;border:none;padding:10px 100px !important;background:#0C4DA2;border-radius:10px;' href='" + url + "'>Confirm</a></b></p>";

            Body += "</td>";
            Body += "</tr>";

            Body += "</table>";
            Body += "</td>";
            Body += "</tr>";
            Body += "<tr>";
            Body += "<td style='padding:30px;background:#FBEE26;'>";
            Body += "<table role='presentation' style='width:100%;border-collapse:collapse;border:0;border-spacing:0;font-size:9px;font-family:Arial,sans-serif;'>";
            Body += "<tr>";
            Body += "<td style='padding:0;width:100%;' align='Center'>";
            Body += "<p style='margin:0;font-size:14px;line-height:16px;font-family:Arial,sans-serif;color:#000;font-weight:bold'>The City School Management</p>";

            Body += "</td>";

            Body += "</tr>";
            Body += "</table>";
            Body += "</td>";
            Body += "</tr>";
            Body += "</table>";
            Body += "</td>";
            Body += "</tr>";
            Body += "</table>";
            Body += "</body>";
            /*****HTML TEMPLET*********/
            var Password = "Jup31963";

            try
            {
                using (MailMessage mm = new MailMessage(Email.Address, To))
                {
                    mm.Subject = Subject;
                    mm.From = new MailAddress("AppNotifications@csn.edu.pk", "The City School");
                    mm.Body = Body;
                    mm.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = "smtp.office365.com"; //"mail.bizar.pk";
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential(Email.Address, Password);
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;
                        smtp.Timeout = 1000000000;
                        try
                        {
                            DataTable dtinsert = ExecuteProcedure("IN", "", "", dt.Rows[i][4].ToString(), dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString(), 1);
                            dtinsert.Dispose();
                            TextLog("Sening");
                            smtp.Send(mm);
                            TextLog("Sent");
                        }
                        catch (SmtpFailedRecipientException ex)
                        {

                            TextLog(ex.Message);

                        }
                        //Debug.WriteLine("Email :" + item.Email);
                        //Bulk_Mail_sent.Student_Id = item.Student_Id;
                        //Bulk_Mail_sent.Name = item.Name;
                        //Bulk_Mail_sent.Center = item.Center;
                        //Bulk_Mail_sent.Email = item.Email;
                        //Bulk_Mail_sent.Status = 1;
                        //Bulk_Mail_se += "{'Student_Id' : '" + item.Student_Id + "','Name':'" + item.Name + "','Center':'" + item.Center + "','Email':'" + item.Email + "','Status':1},";
                    }
                }
            }

            catch (Exception ex)
            {
                DataTable dtinsert = ExecuteProcedure("IN", "", "", dt.Rows[i][4].ToString(), dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString(), 0);
                // dtinsert.Dispose();
                TextLog("1" + ex.Message);
                //Bulk_Mail_sent.Student_Id = item.Student_Id;
                //Bulk_Mail_sent.Name = item.Name;
                //Bulk_Mail_sent.Center = item.Center;
                //Bulk_Mail_sent.Email = item.Email;
                //Bulk_Mail_sent.Status = 2;

                //Bulk_Mail_se += "{'Student_Id' : '" + item.Student_Id + "','Name':'" + item.Name + "','Center':'" + item.Center + "','Email':'" + item.Email + "','Status':2},";

            }
        }


    }
    DataTable ExecuteProcedure(string sAction, string sEmployee_Id, string sSessionID, string sCenterID, string SStudentID = "", string sStudentName = "", string sClassID = "", int isSuccess = 0)
    {
        DataTable DT_Data = null;
        obj_Access.CreateProcedureCommand("SP_BifurcationLetter");
        obj_Access.AddParameter("P_Employee_Id", sEmployee_Id, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_Action", sAction, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_SessionID", sSessionID, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_CenterID", sCenterID, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_StudentID", SStudentID, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_StudentName", sStudentName, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("P_ClassID", sClassID, DataAccess.SQLParameterType.VarChar, true);
        obj_Access.AddParameter("Is_success", isSuccess, DataAccess.SQLParameterType.VarChar, true);


        try
        {
            DT_Data = obj_Access.ExecuteDataTable();
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
        finally
        {
            if (DT_Data != null) { DT_Data.Dispose(); }
        }
        return DT_Data;
    }

    public void TextLog(string sText)
    {
        //if (ConfigurationManager.AppSettings["txtLogWriter"].ToString() == "true")
        //{
        string st = Server.MapPath("~/PresentationLayer");

        try
        {
            string ProcessPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            FileInfo fileInfo = new FileInfo(ProcessPath);
            string CurrentPath = st + "\\" + DateTime.Now.ToString("ddMMyyyyHH") + "-log.txt";

            if (!File.Exists(CurrentPath))
            {
                File.Create(CurrentPath).Close();
            }


            //string subdir = @"C:\_PublishedApps_\AIMS\Live\log";
            // If directory does not exist, create it. 
            //if (!Directory.Exists(root))
            //{
            //    Directory.CreateDirectory(root);
            //}

            StreamWriter logWriter = new StreamWriter(CurrentPath, true);
            logWriter.WriteLine(" " + System.DateTime.Now.ToString("hh:mm:ss") + System.Environment.NewLine + sText);
            logWriter.Close();
        }
        catch (Exception ex)
        {
            string ProcessPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            FileInfo fileInfo = new FileInfo(ProcessPath);

            string CurrentPath = st + "\\" + DateTime.Now.ToString("ddMMyyyyHH") + "-Exception-log.txt";

            if (!File.Exists(CurrentPath))
            {
                File.Create(CurrentPath).Close();
            }

            //StreamWriter logWriter = new StreamWriter(CurrentPath, true);
            //logWriter.WriteLine(" " + System.DateTime.Now.ToString("hh:mm:ss") + System.Environment.NewLine + sText + ": Exception in Try " + ex.Message);
            //logWriter.Close();
        }
        //  }
    }

    protected void gv_details_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (Grid.Rows.Count > 0)
            {
                Grid.UseAccessibleHeader = false;
                Grid.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }
}