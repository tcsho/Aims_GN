using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Linq;
using Ionic.Zip;
using System.Data;
using System.IO;
/// <summary>
/// Summary description for PdfBulkExport
/// </summary>
public class PdfBulkExport
{
 


    private void FillPDF(List<ResultCardDto> resultData, string folderName,string fileN,string _TemplatePath)
    {
        if (!System.IO.Directory.Exists(System.Web.HttpContext.Current.Server.MapPath("~/PDFFiles/" + folderName)))
        {
            System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~/PDFFiles/" + folderName));
        }
        else
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(System.Web.HttpContext.Current.Server.MapPath("~/PDFFiles/" + folderName));
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }
        var students = resultData.GroupBy(t => new
        {
            t.Session_Code,
            t.Center_Name,
            t.Class_Name,
            t.Student_No,
            t.Student_Name,
            t.Section_Name,
            t.SecondTermDaysCH,
            t.Evaluation_Criteria_Type_Name,
            t.Strength,
            t.Class_Avg_Age,
            t.Student_Age,
            t.ClassTeacher_Comments,
            t.PromotedToClass,
            t.ResultDate
        });
        foreach (var studentGrouped in students)
        {

            using (FileStream outFile = new FileStream(System.Web.HttpContext.Current.Server.MapPath("~/PDFFiles/" + folderName + "/" + studentGrouped.Key.Student_No + ".pdf"), FileMode.Create))
            {

                //var path = System.Web.HttpContext.Current.Server.MapPath("~/PDFFiles/ResultCard.pdf");

                var path = System.Web.HttpContext.Current.Server.MapPath(_TemplatePath);

                PdfReader pdfReader = new PdfReader(path);
                PdfStamper pdfStamper = new PdfStamper(pdfReader, outFile);
                AcroFields fields = pdfStamper.AcroFields;
                fields.SetField("fldSessionCode", studentGrouped.Key.Session_Code);
                fields.SetField("fldCenter_Name", studentGrouped.Key.Center_Name);
                fields.SetField("fldClass_Name", studentGrouped.Key.Class_Name);
                fields.SetField("fldStudent_No", studentGrouped.Key.Student_No);
                fields.SetField("fldStudent_Name", studentGrouped.Key.Student_Name);
                fields.SetField("fldSection_Name", studentGrouped.Key.Section_Name);
                fields.SetField("fldSecondTermDaysCH", studentGrouped.Key.SecondTermDaysCH);
                fields.SetField("fldEvaluation_Criteria_Type_Name", studentGrouped.Key.Evaluation_Criteria_Type_Name);
                fields.SetField("fldStrength", studentGrouped.Key.Strength);
                fields.SetField("fldClass_Avg_Age", studentGrouped.Key.Class_Avg_Age);
                fields.SetField("fldStudent_Age", studentGrouped.Key.Student_Age);
                fields.SetField("fldTeacherComments", studentGrouped.Key.ClassTeacher_Comments);
                fields.SetField("fldPromotedToClass", studentGrouped.Key.PromotedToClass);
                fields.SetField("fldFixDate", "th");

                //var targetPosition = pdfStamper.AcroFields.GetFieldPositions("fldTeacherComments")[0].position;
                //var fontNormal = FontFactory.GetFont("Arial", 12, Font.UNDERLINE, BaseColor.BLACK);
                //var url = new Anchor("", fontNormal) { Reference = null };
                //var data = new ColumnText(pdfStamper.GetOverContent(1));
                //data.SetSimpleColumn(url, targetPosition.Left, targetPosition.Bottom, targetPosition.Right, targetPosition.Top, 0, 0);
                //data.Go();



                fields.SetField("fldResultDate", studentGrouped.Key.ResultDate);
                PdfPTable table = new PdfPTable(4);
                table.DefaultCell.BorderWidth = 200f;
                Font tableHeaderFont = FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK);
                Font tableCellFont = FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK);
                PdfPCell cellSubject = new PdfPCell(new Phrase("Subject", tableHeaderFont));
                cellSubject.Colspan = 2;
                cellSubject.BorderWidth = 1f;
                cellSubject.HorizontalAlignment = Element.ALIGN_LEFT;
                cellSubject.NoWrap = false;
                cellSubject.Padding = 5;
                table.AddCell(cellSubject);

                PdfPCell cellMidYear = new PdfPCell(new Phrase("Mid-Year Exam %", tableHeaderFont));
                cellMidYear.BorderWidth = 1f;
                cellMidYear.HorizontalAlignment = Element.ALIGN_CENTER;
                cellMidYear.NoWrap = false;
                cellMidYear.Padding = 5;
                table.AddCell(cellMidYear);

                PdfPCell cellEndOfYearLearning = new PdfPCell(new Phrase("End Of Year Class Learning %", tableHeaderFont));

                cellEndOfYearLearning.HorizontalAlignment = Element.ALIGN_CENTER;
                cellEndOfYearLearning.BorderWidth = 1f;
                table.AddCell(cellEndOfYearLearning);
                cellEndOfYearLearning.NoWrap = false;
                cellEndOfYearLearning.Padding = 5;
                table.HeaderRows = 1;
                //table.SetWidths(new int[] { 0, 3 });
                foreach (var student in studentGrouped)
                {
                    var addSubject = new PdfPCell(new Phrase(student.Subject_Name, tableCellFont));
                    addSubject.Colspan = 2;
                    addSubject.BorderWidth = 1f;
                    addSubject.HorizontalAlignment = Element.ALIGN_LEFT;
                    addSubject.Padding = 5;
                    var addMidYear = new PdfPCell(new Phrase(student.Mid_Year, tableCellFont));
                    addMidYear.HorizontalAlignment = Element.ALIGN_CENTER;
                    addMidYear.Padding = 5;
                    addMidYear.BorderWidth = 1f;
                    var addEOF = new PdfPCell(new Phrase(student.Course_Work, tableCellFont));
                    addEOF.HorizontalAlignment = Element.ALIGN_CENTER;
                    addEOF.Padding = 5;
                    addEOF.BorderWidth = 1f;
                    table.AddCell(addSubject);
                    table.AddCell(addMidYear);
                    table.AddCell(addEOF);
                }
                ColumnText column = new ColumnText(pdfStamper.GetOverContent(1));
                Rectangle rectPage1 = new Rectangle(-20, 10, 615, 640, 0);
                //(lower-left-x, lower-left-y, upper-right-x (llx + width), upper-right-y (lly + height), rotation angle 

                column.SetSimpleColumn(rectPage1);
                column.AddElement(table);
                //Rectangle rectPage2 = new Rectangle(36, 36, 400, 600);
                int status = column.Go();
                pdfStamper.FormFlattening = true;
                RenderTable(pdfStamper, resultData.Where(t => t.Student_No == studentGrouped.Key.Student_No).FirstOrDefault().GeneralPerformance);
                pdfStamper.Close();
                pdfReader.Close();
            }
        }

        var fileName = string.Format(fileN + ".zip");


        var resultZIPOutputPath = System.Web.HttpContext.Current.Server.MapPath("~/PDFFiles/" + folderName + "/" + fileName);
        if (System.IO.File.Exists(resultZIPOutputPath))
            System.IO.File.Delete(resultZIPOutputPath);
        System.Web.HttpContext.Current.Response.Clear();
        System.Web.HttpContext.Current.Response.BufferOutput = false;
        System.Web.HttpContext.Current.Response.ContentType = "application/zip";
        System.Web.HttpContext.Current.Response.AppendHeader("content-disposition", "attachment; filename="+ fileN + ".zip;");
        using (ZipFile zipFile = new ZipFile())
        {
            zipFile.AddDirectory(System.Web.HttpContext.Current.Server.MapPath("~/PDFFiles/" + folderName));
            //zipFile.Save(resultZIPOutputPath);
            zipFile.Save(System.Web.HttpContext.Current.Response.OutputStream);
        }

        //Response.TransmitFile(resultZIPOutputPath);
        //Response.End();
        System.Web.HttpContext.Current.Response.Close();

        System.IO.DirectoryInfo di2 = new DirectoryInfo(System.Web.HttpContext.Current.Server.MapPath("~/PDFFiles/" + folderName));
        foreach (FileInfo file in di2.GetFiles())
        {
            file.Delete();
        }
        foreach (DirectoryInfo dir in di2.GetDirectories())
        {
            dir.Delete(true);
        }
    }
    private void RenderTable(PdfStamper pdfStamper, List<PerformanceDto> performanceDto)
    {
        var rnd = new Random();
        PdfPTable table = new PdfPTable(6);
        Font tableHeaderFont = FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK);
        Font tableCellFont = FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK);

        PdfPCell cellActivity = new PdfPCell(new Phrase("Activity", tableHeaderFont));
        cellActivity.Colspan = 2;
        cellActivity.HorizontalAlignment = Element.ALIGN_LEFT;
        cellActivity.NoWrap = false;
        cellActivity.Padding = 5;
        cellActivity.BorderWidth = 1f;
        table.AddCell(cellActivity);

        PdfPCell cellGrade = new PdfPCell(new Phrase("Grade", tableHeaderFont));
        cellGrade.HorizontalAlignment = Element.ALIGN_CENTER;
        cellGrade.NoWrap = false;
        cellGrade.Padding = 5;
        cellGrade.BorderWidth = 1f;
        table.AddCell(cellGrade);

        PdfPCell cellActivity2 = new PdfPCell(new Phrase("Activity", tableHeaderFont));
        cellActivity2.Colspan = 2;
        cellActivity2.HorizontalAlignment = Element.ALIGN_LEFT;
        cellActivity2.NoWrap = false;
        cellActivity2.Padding = 5;
        cellActivity2.BorderWidth = 1f;
        table.AddCell(cellActivity2);

        table.HeaderRows = 1;
        table.DefaultCell.BorderWidth = 200f;
        PdfPCell cellGrade2 = new PdfPCell(new Phrase("Grade", tableHeaderFont));
        cellGrade2.HorizontalAlignment = Element.ALIGN_CENTER;
        cellGrade2.NoWrap = false;
        cellGrade2.Padding = 5;
        cellGrade2.BorderWidth = 1f;
        table.AddCell(cellGrade2);
        for (var i = 0; i < performanceDto.Count(); i++)
        {
            PdfPCell addActivity = new PdfPCell(new Phrase(performanceDto[i].Activity, tableCellFont));
            addActivity.Colspan = 2;
            addActivity.HorizontalAlignment = Element.ALIGN_LEFT;
            addActivity.Padding = 5;
            addActivity.BorderWidth = 1f;
            table.AddCell(addActivity);
            var addGrade = new PdfPCell(new Phrase(performanceDto[i].Grade, tableCellFont));
            addGrade.HorizontalAlignment = Element.ALIGN_CENTER;
            addGrade.Padding = 5;
            addGrade.BorderWidth = 1f;
            table.AddCell(addGrade);
            if (performanceDto.Count() % 2 != 0 && i >= performanceDto.Count() - 1)
            {
                PdfPCell addActivity2 = new PdfPCell(new Phrase("", tableCellFont));
                addActivity2.Colspan = 2;
                addActivity2.HorizontalAlignment = Element.ALIGN_LEFT;
                addActivity2.Padding = 5;
                addActivity2.BorderWidth = 1f;
                table.AddCell(addActivity2);
                var addGrade2 = new PdfPCell(new Phrase("", tableCellFont));
                addGrade2.HorizontalAlignment = Element.ALIGN_CENTER;
                addGrade2.Padding = 5;
                addGrade2.BorderWidth = 1f;
                table.AddCell(addGrade2);
            }
        }
        ColumnText column2 = new ColumnText(pdfStamper.GetOverContent(1));
        Rectangle rectPage2 = new Rectangle(-20, 100, 615, 410, 0);
        column2.SetSimpleColumn(rectPage2);
        column2.AddElement(table);
        int status = column2.Go();
        pdfStamper.FormFlattening = true;
    }

    public void ExportBulkPdf(string section, string session, string term, string student, string _TemplatePath)
    {
        string clName="", scName="", SchName="", filename="";
        try
        {
            BLLResultHidingCode hd = new BLLResultHidingCode();
            DataTable _dtCodes = new DataTable();
            _dtCodes = hd.GETResultHideCodingAll();

            string Section = section;
            string Sess = session;
            string Term = term;
            string Student = student;



            string folderName = Section + "_" + Sess + "_" + Term;
            BLLMarks_Entry_Acknowledgement ObjMea = new BLLMarks_Entry_Acknowledgement();

            ObjMea.Section_Id = Convert.ToInt32(Section);
            ObjMea.Session_Id = Convert.ToInt32(Sess);
            ObjMea.TermGroup_Id = Convert.ToInt32(Term);
            string student_Id = Student;



            if (student_Id != "0")
            {
                ObjMea.Student_Id = Convert.ToInt32(student_Id);
            }
            else
            {
                ObjMea.Student_Id = 0;
            }
            List<ResultCardDto> resultCardDto = new List<ResultCardDto>();
            DataTable dt = ObjMea.Marks_Entry_DataFetchResult(ObjMea);
            DataTable dtPer = ObjMea.Marks_Entry_DataFetchResultPerformance(ObjMea);
            foreach (DataRow row in dt.Rows)
            {
                var resultCard = new ResultCardDto();
                resultCard.Session_Code = "End of Year Examination " + Convert.ToString(row["SessionCode"]);
                resultCard.Center_Name = Convert.ToString(row["Center_Name"]);
                resultCard.Class_Name = "Progress Report for " + Convert.ToString(row["Class_Name"]);
                resultCard.Student_No = Convert.ToString(row["Student_No"]);
                resultCard.Student_Name = Convert.ToString(row["StudentName"]);
                resultCard.Section_Name = Convert.ToString(row["Section_Name"]);
                resultCard.SecondTermDaysCH = Convert.ToString(row["SecondTermDaysCH"]);
                resultCard.FirstTermDaysCH = Convert.ToString(row["FirstTermDaysCH"]);
                resultCard.Evaluation_Criteria_Type_Name = Convert.ToString(row["Evaluation_Criteria_Type_Name"]);
                resultCard.Strength = Convert.ToString(row["Strength"]);
                resultCard.Class_Avg_Age = Convert.ToString(row["Class_Avg_Age"]);
                resultCard.Student_Age = Convert.ToString(row["Student_Age"]);
                resultCard.Subject_Name = Convert.ToString(row["Subject_Name"]);
                resultCard.Mid_Year = Convert.ToString(row["Mid_Year"]);
                resultCard.Course_Work = Convert.ToString(row["Course_Work"]);
                resultCard.ClassTeacher_Comments = Convert.ToString(row["ClassTeacher_Comments"]);
                resultCard.PromotedToClass = Convert.ToString(row["PromotedToClass"]);
                var resultDate = Convert.ToDateTime(row["ResultDate"]);
                resultCard.ResultDate = resultDate.ToString("dd  MMMM yyyy");

                resultCard.GeneralPerformance = new List<PerformanceDto>();


                clName= Convert.ToString(row["Class_Name"]);
                scName = Convert.ToString(row["Section_Name"]); ;
                SchName= Convert.ToString(row["Center_Name"]);


                foreach (DataRow performance in dtPer.Select("Student_Id=" + Convert.ToString(row["Student_No"])))
                {
                    PerformanceDto performanceItem = new PerformanceDto();
                    performanceItem.Activity = Convert.ToString(performance["Label"]);
                    performanceItem.Grade = Convert.ToString(performance["RateCode"]);
                    resultCard.GeneralPerformance.Add(performanceItem);
                }
                resultCardDto.Add(resultCard);

            }
            filename = SchName+ "_"+ clName + "_" + scName;

            FillPDF(resultCardDto, folderName,filename, _TemplatePath);

        }
        catch (Exception ex)
        {
            System.Web.HttpContext.Current.Session["error"] = ex.Message;
            System.Web.HttpContext.Current.Response.Redirect("~/presentationlayer/ErrorPage.aspx", false);
        }
    }


}


public class ResultCardDto
{
    public string Subject_Name { get; set; }
    public string Class_Name { get; set; }
    public string Mid_Year { get; set; }
    public string Student_No { get; set; }
    public string Student_Name { get; set; }
    public string Section_Name { get; set; }
    public string Strength { get; set; }
    public string Student_Age { get; set; }
    public string Class_Avg_Age { get; set; }
    public string Center_Name { get; set; }
    public string Session_Code { get; set; }
    public string ResultDate { get; set; }
    public string Evaluation_Criteria { get; set; }
    public string PromotedToClass { get; set; }
    public string Course_Work { get; set; }
    public string SecondTermDaysCH { get; set; }
    public string Evaluation_Criteria_Type_Name { get; set; }
    public string FirstTermDaysCH { get; set; }
    public string ClassTeacher_Comments { get; set; }
    public List<PerformanceDto> GeneralPerformance { get; set; }
}
public class PerformanceDto
{
    public string Activity { get; set; }
    public string Grade { get; set; }
}