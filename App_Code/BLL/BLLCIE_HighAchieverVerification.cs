using System;
using System.Data;

/// <summary>
/// Summary description for BLLCIE_HighAchieverVerification
/// </summary>



public class BLLCIE_HighAchieverVerification
{
    public BLLCIE_HighAchieverVerification()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALCIE_HighAchieverVerification objdal = new DALCIE_HighAchieverVerification();



    #region 'Start Properties Declaration'

    public int HA_Id { get; set; }
    public int Session { get; set; }

    public int AStar { get; set; }
    public int AGrade { get; set; }
    public int VerifiedBy { get; set; }

    public int Session_Id { get; set; }
    public int Center_Id { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int CIE_HighAchieverVerificationAdd(BLLCIE_HighAchieverVerification _obj)
    {
        return objdal.CIE_HighAchieverVerificationAdd(_obj);
    }


    public int CIE_FileUploadProcess(BLLCIE_HighAchieverVerification _obj)
    {
        return objdal.CIE_FileUploadProcess(_obj);
    }

     public int CIE_HighAchieverVerificationVerify(BLLCIE_HighAchieverVerification _obj)
    {
        return objdal.CIE_HighAchieverVerificationVerify(_obj);
    }

    public int CIE_HighAchieverVerificationUnVerify(BLLCIE_HighAchieverVerification _obj)
    {
        return objdal.CIE_HighAchieverVerificationUnVerify(_obj);
    }

    public int CIE_HighAchieverVerificationLock(BLLCIE_HighAchieverVerification _obj)
    {
        return objdal.CIE_HighAchieverVerificationLock(_obj);
    }
    public int CIE_HighAchieverVerificationUnLock(BLLCIE_HighAchieverVerification _obj)
    {
        return objdal.CIE_HighAchieverVerificationUnLock(_obj);
    }
    
    public int CIE_HighAchieverVerificationDelete(BLLCIE_HighAchieverVerification _obj)
    {
        return objdal.CIE_HighAchieverVerificationDelete(_obj);

    }

    #endregion
    #region 'Start Fetch Methods'

    #endregion

}
