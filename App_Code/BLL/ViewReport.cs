using System;
using System.Configuration;
using System.Data;
using System.Web.UI;


/// <summary>
/// Summary description for ViewReport
/// </summary>
public class ViewReport : Page
{
    public int Section_Id { get; set; }
    public int Session_Id { get; set; }
    public int Class_Id { get; set; }
    public int Student_Id { get; set; }
    public int TermGroup_Id { get; set; }
    public bool isBorder { get; set; }
    public static string Report_URL = ConfigurationManager.AppSettings["ReportCard_URL"];
    public ViewReport()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private int GetSectionId(ViewReport r)
    {
        int Section_Id = 0;

        if (r.Student_Id > 0)
        {


            BLLSection objSec = new BLLSection();
            objSec.Session_Id = r.Session_Id;
            objSec.TermGroup_Id = r.TermGroup_Id;
            objSec.Student_Id = r.Student_Id;
            DataTable dt = new DataTable();
            dt = objSec.Section_SelectForResultCard(objSec);

            if (dt.Rows.Count > 0)
            {
                // Qs = "?sc=000" + dt.Rows[0]["Section_Id"].ToString() + "000" + r.Session_Id +
                //r.TermGroup_Id.ToString() + "&st=" + r.Student_Id;
                Section_Id = Convert.ToInt32(dt.Rows[0]["Section_Id"].ToString());
            }
        }
        return Section_Id;
    }
    public string OpenReport(ViewReport r)
    {
        string url = "";
        try
        {

            //obj.Section_Id = Convert.ToInt32(r.Cells[4].Text); // remove dependency over section id for result
            //obj.Student_Id = Convert.ToInt32(r.Cells[0].Text);
            //obj.Session_Id = Convert.ToInt32(r.Cells[1].Text);
            //obj.Class_Id = Convert.ToInt32(r.Cells[3].Text);
            //obj.TermGroup_Id = Convert.ToInt32(r.Cells[2].Text);


            BLLResultHidingCode hd = new BLLResultHidingCode();
            DataTable _dtCodes = new DataTable();
            _dtCodes = hd.GETResultHideCodingAll();

            string Esec = hd.ResultCardEncode(r.Section_Id.ToString(), _dtCodes);
            string ESes = hd.ResultCardEncode(r.Session_Id.ToString(), _dtCodes);
            string ETrG = hd.ResultCardEncode(r.TermGroup_Id.ToString(), _dtCodes);
            string Estd = hd.ResultCardEncode(r.Student_Id.ToString(), _dtCodes);
            /**Chnage 22 dec 2022*/
            string ClId = hd.ResultCardEncode(r.Class_Id.ToString(), _dtCodes);
            /**Chnage 22 dec 2022*/
            bool _isok = false;
            isBorder = false;
            isBorder = r.isBorder;
            string Qs = "?sc=" + Esec + "&se=" + ESes + "&tr=" + ETrG + "&st=" + Estd;

            if (r.Class_Id < 7) // EYE Classes
            {
                if (r.TermGroup_Id == 1)
                {
                    if (r.Session_Id <= 7)
                    {
                        url = "TCS_HTML_F_EYE.aspx" + Qs;
                    }
                    else if (r.Session_Id >= 7 && r.Session_Id <= 10)
                    {
                        url = "TCS_HTML_F_EYE_201617.aspx" + Qs;
                    }
                    else
                    {
                        url = "TCS_HTML_F_EYE_201920.aspx" + Qs;
                    }
                }
                else
                {
                    if (r.Session_Id <= 8)
                    {
                        url = "TCS_HTML_S_EYE_201617.aspx" + Qs;
                    }
                    else if (r.Session_Id == 10)
                    {
                        url = "TCS_HTML_S_EYE_201819.aspx" + Qs;
                    }
                    else if (r.Session_Id == 11)
                    {
                        url = "TCS_HTML_S_EYE_201718.aspx" + Qs;
                    }
                    else
                    {
                        //2024-10-22
                        //if (Student_Id == 597143)
                        //{
                        //    url = "TCS_HTML_S_EYE_202021.aspx" + Qs;

                        //}
                        //else
                        //{
                        //    url = "TCS_EYE_E_REPORT_CARD.aspx" + Qs;
                        //}

                        url = "TCS_HTML_S_EYE_202021.aspx" + Qs;
                    }
                }

                //2024-11-26 by hasan
                if((Class_Id ==5 || Class_Id ==6) && Session_Id==16)
                {
                    //url = "TCS_EYE_E_REPORT_CARD.aspx" + Qs;
                    url = "EYEReport.aspx" + Qs;
                }


                _isok = true;
            }
            else if (r.Class_Id > 6 && r.Class_Id < 13) // Classes 3 to 8
            {
                if (r.TermGroup_Id == 1)
                {
                    if (isBorder)
                    {
                        /*With Border*/
                        if (r.Session_Id <= 7)
                        {
                            url = "TCS_HTML_F_3_8_B.aspx" + Qs;
                        }
                        else if (r.Session_Id >= 8 && r.Session_Id <= 10)
                        {
                            url = "TCS_HTML_F_3_8_B_201617.aspx" + Qs;
                        }
                        else if (r.Session_Id == 11)
                        {
                            url = "TCS_HTML_F_3_8_B_201920.aspx" + Qs;
                        }
                    }
                    else
                    {
                        /*Without Border*/
                        if (r.Session_Id <= 7)
                        {
                            url = "TCS_HTML_F_3_8.aspx" + Qs;
                        }
                        else if (r.Session_Id >= 8 && r.Session_Id <= 10)
                        {
                            url = "TCS_HTML_F_3_8_201617.aspx" + Qs;
                        }
                        else if (r.Session_Id == 11)
                        {
                            url = "TCS_HTML_F_3_8_201920.aspx" + Qs;
                        }
                    }

                    if (r.Session_Id == 12 || r.Session_Id == 13)
                    {
                        url = SubjectWiseCommentsFormatMYE2021(Esec, ESes, ETrG, Estd);
                    }
                    else
                    {
                        url = SubjectWiseCommentsFormatMYE(Esec, ESes, ETrG, Estd);
                    }
                }
                else
                {
                    if (isBorder)
                    {
                        if (r.Session_Id <= 7)
                        {
                            url = "TCS_HTML_S_3_8_B.aspx" + Qs;
                        }
                        else if (r.Session_Id >= 8 && r.Session_Id <= 10)
                        {
                            url = "TCS_HTML_S_3_8_B_201617.aspx" + Qs;
                        }
                        else if (r.Session_Id == 11)
                        {
                            url = "TCS_HTML_S_3_8_B_201920.aspx" + Qs;
                        }
                    }
                    else
                    {
                        if (r.Session_Id <= 7)
                        {
                            url = "TCS_HTML_S_3_8.aspx" + Qs;
                        }
                        else if (r.Session_Id >= 8 && r.Session_Id <= 10)
                        {
                            url = "TCS_HTML_S_3_8_201617.aspx" + Qs;
                        }
                        else if (r.Session_Id == 11)
                        {
                            url = "TCS_HTML_S_3_8_201920.aspx" + Qs;
                        }
                    }

                    if (r.Session_Id == 12 || r.Session_Id == 13)
                    {
                        url = SubjectWiseCommentsFormatEOY2021(Esec, ESes, ETrG, Estd);
                    }
                    else
                    {
                        url = SubjectWiseCommentsFormatEOY(Esec, ESes, ETrG, Estd);
                    }
                }
                _isok = true;
            }
            else // Classes Above 8
            {
                if (r.TermGroup_Id == 1)
                {
                    if (r.Session_Id >= 12)
                    {
                        if (r.Student_Id.ToString() == "0")
                            url = SubjectWiseCommentsFormatClassesGreaterThan8(Esec, ESes, ETrG, Estd);
                        else
                            url = SubjectWiseCommentsFormatClassesGreaterThan8(ClId, ESes, ETrG, Estd);
                    }
                    else
                    {
                        if (isBorder)
                        {
                            if (r.Session_Id <= 7)
                            {
                                url = "TCS_HTML_F_O_A_B.aspx" + Qs;
                            }
                            else if (r.Session_Id > 7 && r.Session_Id < 11)
                            {
                                url = "TCS_HTML_F_O_A_B_201617.aspx" + Qs;
                            }
                            else if (r.Session_Id == 11)
                            {
                                url = "TCS_HTML_F_O_A_B_201920.aspx" + Qs;
                            }
                        }
                        else
                        {
                            if (r.Session_Id <= 7)
                            {
                                url = "TCS_HTML_F_O_A.aspx" + Qs;
                            }
                            else if (r.Session_Id > 7 && r.Session_Id < 11)
                            {
                                url = "TCS_HTML_F_O_A_201617.aspx" + Qs;
                            }
                            else if (r.Session_Id == 11)
                            {
                                url = "TCS_HTML_F_O_A_201920.aspx" + Qs;
                            }
                        }
                    }
                }
                else
                {
                    if (r.Session_Id >= 12)
                    {
                        if (r.Student_Id.ToString() == "0")
                            url = SubjectWiseCommentsFormatClassesGreaterThan8(Esec, ESes, ETrG, Estd);
                        else
                            url = SubjectWiseCommentsFormatClassesGreaterThan8(ClId, ESes, ETrG, Estd);
                    }

                    if (isBorder)
                    {
                        if (r.Session_Id <= 7)
                        {
                            url = "TCS_HTML_S_9_B.aspx" + Qs;
                        }
                        else if (r.Session_Id >= 8 && r.Session_Id <= 10)
                        {
                            url = "TCS_HTML_S_9_B_201617.aspx" + Qs;
                        }
                        else if (r.Session_Id == 11)
                        {
                            url = "TCS_HTML_S_9_B_201920.aspx" + Qs;
                        }
                    }
                    else
                    {
                        if (r.Session_Id <= 7)
                        {
                            url = "TCS_HTML_S_9.aspx" + Qs;
                        }
                        else if (r.Session_Id >= 8 && r.Session_Id <= 10)
                        {
                            url = "TCS_HTML_S_9_201617.aspx" + Qs;
                        }
                        else if (r.Session_Id == 11)
                        {
                            url = "TCS_HTML_S_9_201920.aspx" + Qs;
                        }
                    }
                }
                _isok = true;
            }

            if (_isok)
            {
                if (Session_Id >= 12)
                {
                    url = url;

                }
                else
                {
                    if (r.Class_Id > 7)
                        url = "/" + url;
                    else
                        url = url;
                }
            }
        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
        return url;
    }
    private static string SubjectWiseCommentsFormatMYE2021(string Esec, string ESes, string ETrG, string Estd)
    {

        string url;
        string Ts = "";
        if (Estd != "KLZ")
        {
            Ts = "?ScId=" + Esec + "&Sd=" + ESes + "&Ty=" + ETrG + "&Rno=" + Estd;
            url = "TCS/Reportcard/MYE2021.aspx" + Ts;
        }
        else
        {
            Ts = "?ScId=" + Esec + "&Sd=" + ESes + "&Ty=" + ETrG;
            url = Report_URL + "ReportCard/MYE2021Section.html" + Ts;
        }

        return url;
    }    
    private static string SubjectWiseCommentsFormatEOY2021(string Esec, string ESes, string ETrG, string Estd)
    {
        string url;
        string Ts = "";

        if (Estd != "KLZ")
        {
            Ts = "?a=" + Esec + "&b=" + ESes + "&c=" + ETrG + "&d=" + Estd;
            url = "TCS/ReportCard/EOY2021.aspx" + Ts;
        }
        else
        {
            //Ts = "?a=" + Esec + "&b=" + ESes + "&c=" + ETrG;
            //url = Report_URL + "ReportCard/EOY2021Section.html" + Ts;
             Ts = "?a=" + Esec + "&b=" + ESes + "&c=" + ETrG + "&d=" + Estd;
            url = "TCS/Reportcard/EOY2023SectionWise.aspx" + Ts;
        }

        return url;
    }
    private static string SubjectWiseCommentsFormatMYE(string Esec, string ESes, string ETrG, string Estd)
    {
        string url = "";
        string Ts = "";

        if (Estd != "KLZ")
        {
            Ts = "?a=" + Esec + "&b=" + ESes + "&c=" + ETrG + "&d=" + Estd;
            //url = "/TCS/Reportcard/MYEResult.aspx" + Ts;
            url = "/Presentationlayer/TCS/Reportcard/MYEResult.aspx" + Ts;       //Added by hasan   2024-12-18
        }
        else
        {
            Ts = "?a=" + Esec + "&b=" + ESes + "&c=" + ETrG;
            url = Report_URL + "Reportcard/MYEResultSection.html" + Ts;
        }

        return url;
    }
    private static string SubjectWiseCommentsFormatEOY(string Esec, string ESes, string ETrG, string Estd)
    {
        string url = "";
        string Ts = "";

        if (Estd != "KLZ")
        {
            Ts = "?a=" + Esec + "&b=" + ESes + "&c=" + ETrG + "&d=" + Estd;
            url = "TCS/Reportcard/EOY2023.aspx" + Ts;
        }
        else
        {
            Ts = "?a=" + Esec + "&b=" + ESes + "&c=" + ETrG + "&d=" + Estd;
            url = "TCS/Reportcard/EOY2023SectionWise.aspx" + Ts;
        }

        return url;
    }
    private static string SubjectWiseCommentsFormatClassesGreaterThan8(string ClId, string ESes, string ETrG, string Estd)
    {
        string url = "";
        string Ts = "";
        Ts = "?a=" + ETrG + "&b=" + Estd + "&c=" + ClId + "&d=" + ESes; ;
        url = "TCS/Reportcard/OAndALevelresult.aspx" + Ts;
        return url;
    }
    public string GetSuffix(string day)
    {
        string suffix = "th";

        if (int.Parse(day) < 11 || int.Parse(day) > 20)
        {
            day = day.ToCharArray()[day.ToCharArray().Length - 1].ToString();
            switch (day)
            {
                case "1":
                    suffix = "st";
                    break;
                case "2":
                    suffix = "nd";
                    break;
                case "3":
                    suffix = "rd";
                    break;
            }
        }

        return suffix;
    }
    //private static string AY2022SubjectWiseCommentsFormat(string Esec, string ESes, string ETrG, string Estd)
    //{
    //    string url = "";
    //    string Ts = "";
    //    if (Estd != "KLZ")
    //    {
    //        Ts = "?ScId=" + Esec + "&Sd=" + ESes + "&Ty=" + ETrG + "&Rno=" + Estd;
    //        url = "TCS/Reportcard/MYE2021.aspx" + Ts;//?Rno=JKVBJKHJHJGH&Sd=JKHJ&Ty=JK";
    //    }
    //    else
    //    {
    //        Ts = "?ScId=" + Esec + "&Sd=" + ESes + "&Ty=" + ETrG;
    //        url = Report_URL + "ReportCard/MYE2021Section.html" + Ts;
    //    }

    //    return url;
    //}
    //private static string MockReport(string ClId, string ESes, string ETrG, string Estd)
    //{
    //    string url = "";
    //    string Ts = "";
    //    Ts = "?a=" + ETrG + "&b=" + Estd + "&c=" + ClId + "&d=" + ESes;   
    //    url = "TCS/Reportcard/OAndALevelresult.aspx" + Ts;
    //    return url;
    //}    
    //private static string SubjectWiseCommentsFormatEYEClassesGreaterThan8(string ClId, string ESes, string ETrG, string Estd)
    //{
    //    string url = "";
    //    string Ts = "";
    //    Ts = "?a=" + ETrG + "&b=" + Estd + "&c=" + ClId + "&d=" + ESes; ;
    //    url = "TCS/Reportcard/EOY2023OLevel.aspx" + Ts;
    //    return url;
    //}    
}