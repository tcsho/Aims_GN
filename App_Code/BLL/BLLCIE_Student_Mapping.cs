using System;
using System.Data;

/// <summary>
/// Summary description for BLLCIE_Student_Mapping
/// </summary>



public class BLLCIE_Student_Mapping
{
    public BLLCIE_Student_Mapping()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALCIE_Student_Mapping objdal = new DALCIE_Student_Mapping();



    #region 'Start Properties Declaration'

    public int CIE_Can_Id { get; set; }
    public int Session_Id { get; set; }
    public int Student_Id { get; set; }
    public string CandidateNo { get; set; }
    public int Section_Id { get; set; }
    public int Class_Id { get; set; }
    public int Center_Id { get; set; }
    public string Glevel { get; set; }
    public string StudentName { get; set; }
    public int Records { get; set; }
    public string FileName { get; set; }
    public int CIE_FileUp_Id { get; set; }
    public int RegisteredAs { get; set; }
    public int ResultSeries_Id { get; set; }
    public int Region_Id { get; set; }




    #endregion

    #region 'Start Executaion Methods'

    public int CIE_Student_MappingAdd(BLLCIE_Student_Mapping _obj)
    {
        return objdal.CIE_Student_MappingAdd(_obj);
    }



    public int CIE_Student_MappingAddAllInOne(BLLCIE_Student_Mapping _obj)
    {
        return objdal.CIE_Student_MappingAddAllInOne(_obj);
    }



    public int CIE_FileUploadHistoryInsert(BLLCIE_Student_Mapping _obj)
    {
        return objdal.CIE_FileUploadHistoryInsert(_obj);
    }

    public int CIE_FileUploadHistoryAllInOneInsert(BLLCIE_Student_Mapping _obj)
    {
        return objdal.CIE_FileUploadHistoryAllInOneInsert(_obj);
    }

    public int CIE_FileUploadProcess(BLLCIE_Student_Mapping _obj)
    {
        return objdal.CIE_FileUploadProcess(_obj);
    }
    
        public int CIE_FileHighAchieversProcess(BLLCIE_Student_Mapping _obj)
    {
        return objdal.CIE_FileHighAchieversProcess(_obj);
    }

    public int CIE_Student_MappingAllAdd(BLLCIE_Student_Mapping _obj)
    {
        return objdal.CIE_Student_MappingAllAdd(_obj);
    }

    public int CIE_Student_MappingAllInOneAdd(BLLCIE_Student_Mapping _obj)
    {
        return objdal.CIE_Student_MappingAllInOneAdd(_obj);
    }


    public int CIE_Student_MappingUpdate(BLLCIE_Student_Mapping _obj)
    {
        return objdal.CIE_Student_MappingUpdate(_obj);
    }
    public int CIE_Student_MappingDelete(BLLCIE_Student_Mapping _obj)
    {
        return objdal.CIE_Student_MappingDelete(_obj);

    }

    public int CIE_Student_MappingDeleteAllRecords(BLLCIE_Student_Mapping _obj)
    {
        return objdal.CIE_Student_MappingDeleteAllRecords(_obj);

    }



    #endregion
    #region 'Start Fetch Methods'

    public DataTable CIE_ClassLevelSelect(BLLCIE_Student_Mapping _obj)
    {
        return objdal.CIE_ClassLevelSelect(_obj);
    }
    public DataTable CIE_Student_MappingSelect(BLLCIE_Student_Mapping _obj)
    {
        return objdal.CIE_Student_MappingSelect(_obj);
    }

    public DataTable CIE_StudentMappingSelectByCenter_Id(BLLCIE_Student_Mapping _obj)
    {
        return objdal.CIE_StudentMappingSelectByCenter_Id(_obj);
    }

    public DataTable CIE_Student_MappingUploadedDataSelectByCenter_Id(BLLCIE_Student_Mapping _obj)
    {
        return objdal.CIE_Student_MappingUploadedDataSelectByCenter_Id(_obj);
    }


    public DataTable CIE_FileUploadAllInDataSelectById(BLLCIE_Student_Mapping _obj)
    {
        return objdal.CIE_FileUploadAllInDataSelectById(_obj);
    }

    


    public DataTable CIE_Student_MappingSelectBySession_Id(BLLCIE_Student_Mapping _obj)
    {
        return objdal.CIE_Student_MappingSelectBySession_Id(_obj);
    }


    public DataTable CIE_FileUploadHistorySelectByRecord(BLLCIE_Student_Mapping _obj)
    {
        return objdal.CIE_FileUploadHistorySelectByRecord(_obj);
    }
    

    public DataTable CIE_FileUploadHistoryAllInOneSelectByRecord(BLLCIE_Student_Mapping _obj)
    {
        return objdal.CIE_FileUploadHistoryAllInOneSelectByRecord(_obj);
    }
    public DataTable CIE_StudentMappingSelectByStudent_Id(BLLCIE_Student_Mapping _obj)
    {
        return objdal.CIE_StudentMappingSelectByStudent_Id(_obj);
    }


    public DataTable CIE_CenterMappingSelectByCenter_Id(BLLCIE_Student_Mapping _obj)
    {
        return objdal.CIE_CenterMappingSelectByCenter_Id(_obj);
    }


    public DataTable CIE_Student_MappingFetch(int _id)
    {
        return objdal.CIE_Student_MappingSelect(_id);
    }


    public DataTable CIE_ResultSeriesSelectAll()
    {
        return objdal.CIE_ResultSeriesSelectAll();
    }

    public DataTable CIE_HighAchieversSelectByCenter(BLLCIE_Student_Mapping _obj)
    {
        return objdal.CIE_HighAchieversSelectByCenter(_obj);
    }


    //2023-Aug-08
    public DataTable CIE_Check_File_Duplication(string File_Name)
    {
        return objdal.CIE_Check_File_Duplication(File_Name);
    }
    //2023-Aug-08
    public DataTable CIE_Check_status_For_Compilation(BLLCIE_Student_Mapping _obj)
    {
        return objdal.CIE_Check_status_For_Compilation(_obj);
    }


    ////2023-08-21 CIE_Student_MappingDeleteAllRecords
    public int CIE_Delete_Forecasted_Grade_Data(BLLCIE_Student_Mapping _obj)
    {
        return objdal.CIE_Delete_Forecasted_Grade_Data(_obj);

    }


    #endregion

}
