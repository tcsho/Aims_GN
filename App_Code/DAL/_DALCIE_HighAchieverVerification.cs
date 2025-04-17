using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALCIE_HighAchieverVerification
/// </summary>
public class DALCIE_HighAchieverVerification
{
    DALBase dalobj = new DALBase();


    public DALCIE_HighAchieverVerification()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int CIE_HighAchieverVerificationAdd(BLLCIE_HighAchieverVerification objbll)
    {
        SqlParameter[] param = new SqlParameter[7];


        param[0] = new SqlParameter("@HA_Id", SqlDbType.Int);
        param[0].Value = objbll.HA_Id;


        param[6] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[6].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("", param);
        int k = (int)param[6].Value;
        return k;

    }
    public int CIE_FileUploadProcess(BLLCIE_HighAchieverVerification objbll)
    {
        SqlParameter[] param = new SqlParameter[3];


        param[0] = new SqlParameter("@HA_Id", SqlDbType.Int);
        param[0].Value = objbll.HA_Id;
  
        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("", param);
        int k = (int)param[2].Value;
        return k;

    }
    public int CIE_HighAchieverVerificationVerify(BLLCIE_HighAchieverVerification objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@HA_Id", SqlDbType.Int); 
        param[0].Value = objbll.HA_Id;


        param[1] = new SqlParameter("@AStar", SqlDbType.Int);
        param[1].Value = objbll.AStar;

        param[2] = new SqlParameter("@AGrade", SqlDbType.Int);
        param[2].Value = objbll.AGrade;

        param[3] = new SqlParameter("@VerifiedBy", SqlDbType.Int);
        param[3].Value = objbll.VerifiedBy;
        
        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("CIE_HighAchieversStudentsComputedVerify", param);
        int k = (int)param[4].Value;
        return k;
    }

    public int CIE_HighAchieverVerificationUnVerify(BLLCIE_HighAchieverVerification objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@HA_Id", SqlDbType.Int);
        param[0].Value = objbll.HA_Id;

        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[1].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("CIE_HighAchieversStudentsComputedUnVerify", param);
        int k = (int)param[1].Value;
        return k;
    }
    public int CIE_HighAchieverVerificationLock(BLLCIE_HighAchieverVerification objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[1].Value = objbll.Center_Id;

        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("CIE_HighAchieversStudentsComputedLock", param);
        int k = (int)param[2].Value;
        return k;
    }

    public int CIE_HighAchieverVerificationUnLock(BLLCIE_HighAchieverVerification objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@HA_Id", SqlDbType.Int);
        param[0].Value = objbll.HA_Id;

        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[1].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("CIE_HighAchieversStudentsComputedUnlock", param);
        int k = (int)param[1].Value;
        return k;
    }



    public int CIE_HighAchieverVerificationDelete(BLLCIE_HighAchieverVerification objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@HA_Id", SqlDbType.Int);
        param[0].Value = objbll.HA_Id;

        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[1].Direction = ParameterDirection.Output;
        
        int k = dalobj.sqlcmdExecute("", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
   

    #endregion


}
