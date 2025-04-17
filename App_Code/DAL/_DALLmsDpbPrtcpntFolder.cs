using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;

/// <summary>
/// Summary description for _DALLmsDpbPrtcpntFolder
/// </summary>
public class DALLmsDpbPrtcpntFolder
{
    DALBase dalobj = new DALBase();


    public DALLmsDpbPrtcpntFolder()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int LmsDpbPrtcpntFolderAdd(BLLLmsDpbPrtcpntFolder objbll)
    {
        SqlParameter[] param = new SqlParameter[4];
        //param[0] = new SqlParameter("@PrtcpnttDpb_ID", SqlDbType.Int); 
        //param[0].Value = objbll.PrtcpnttDpb_ID;
        param[0] = new SqlParameter("@DropBox_ID", SqlDbType.Int);
        param[0].Value = objbll.DropBox_ID;
        param[1] = new SqlParameter("@FolderName", SqlDbType.NVarChar);
        param[1].Value = objbll.FolderName;
        param[2] = new SqlParameter("@FolderPath", SqlDbType.NVarChar);
        param[2].Value = objbll.FolderPath;
        param[3] = new SqlParameter("@Participant_ID", SqlDbType.Int);
        param[3].Value = objbll.Participant_ID;



        //////////param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        //////////param[14].Direction = ParameterDirection.Output;

        //////////dalobj.sqlcmdExecute("LmsDpbPrtcpntFolderInsert", param);
        //////////int k = (int)param[14].Value;
        //////////return k;


        int k = dalobj.sqlcmdExecute("LmsDpbPrtcpntFolderInsert", param);
        return k;
    }
    public int LmsDpbPrtcpntFolderUpdate(BLLLmsDpbPrtcpntFolder objbll)
    {
        SqlParameter[] param = new SqlParameter[10];
        param[0] = new SqlParameter("@PrtcpnttDpb_ID", SqlDbType.Int); param[0].Value = objbll.PrtcpnttDpb_ID;
        param[0] = new SqlParameter("@DropBox_ID", SqlDbType.Int); param[0].Value = objbll.DropBox_ID;
        param[1] = new SqlParameter("@FolderName", SqlDbType.NVarChar); param[1].Value = objbll.FolderName;
        param[2] = new SqlParameter("@FolderPath", SqlDbType.NVarChar); param[2].Value = objbll.FolderPath;
        param[3] = new SqlParameter("@Participant_ID", SqlDbType.Int); param[3].Value = objbll.Participant_ID;


 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsDpbPrtcpntFolderUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int LmsDpbPrtcpntFolderDelete(BLLLmsDpbPrtcpntFolder objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@LmsDpbPrtcpntFolder_Id", SqlDbType.Int);
     //   param[0].Value = objbll.LmsDpbPrtcpntFolder_Id;


        int k = dalobj.sqlcmdExecute("LmsDpbPrtcpntFolderDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable LmsDpbPrtcpntFolderSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsDpbPrtcpntFolderSelectById", param);
        return _dt;
        }
    catch (Exception _exception)
        {
        throw _exception;
        }
    finally
        {
        dalobj.CloseConnection();
        }

    return _dt;
    }
    
    public DataTable LmsDpbPrtcpntFolderSelect(BLLLmsDpbPrtcpntFolder objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsDpbPrtcpntFolderSelectAll", param);
        return _dt;
        }
    catch (Exception _exception)
        {
        throw _exception;
        }
    finally
        {
        dalobj.CloseConnection();
        }

    return _dt;
    
    }

    public DataTable LmsDpbPrtcpntFolderSelectByStatusID(BLLLmsDpbPrtcpntFolder objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsDpbPrtcpntFolderSelectByStatusID");
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }




    #endregion


}
