using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALTCS_HlpDskComplaintBox
/// </summary>
public class _DALTCS_HlpDskComplaintBox
{
    DALBase dalobj = new DALBase();

    public _DALTCS_HlpDskComplaintBox()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable TCS_HlpDskComplaintBoxSelectAll()
    {

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_HlpDskComplaintBoxSelectAll");
            return _dt;
        }
        catch (Exception oException)
        {
            throw oException;
        }
        finally
        {
            dalobj.CloseConnection();
        }
    }

    public int TCS_HlpDskComplaintBoxInsert(BLLTCS_HlpDskComplaintBox objbll)
    {
        SqlParameter[] param = new SqlParameter[10];
        
        param[0] = new SqlParameter("@HDSubCat_ID",SqlDbType.Int);
        param[0].Value = objbll.HDSubCat_ID;
        param[1] = new SqlParameter("@HDComplaintDesc",SqlDbType.NVarChar);
        param[1].Value = objbll.HDComplaintDesc;
        param[2] = new SqlParameter("@HD_Resource_ID", SqlDbType.Int);
        param[2].Value = objbll.HD_Resource_ID; 
        //param[2] = new SqlParameter("@HD_Complaint_Status_ID",SqlDbType.Int);	param[2].Value = objbll.HD_Complaint_Status_ID;        
        param[3] = new SqlParameter("@PriorityType_ID",SqlDbType.Int);
        param[3].Value = objbll.PriorityType_ID;
        param[4] = new SqlParameter("@CreatedOn",SqlDbType.DateTime);
        param[4].Value = objbll.CreatedOn;
        param[5] = new SqlParameter("@CreatedBy",SqlDbType.Int);
        param[5].Value = objbll.CreatedBy;        
        param[6] = new SqlParameter("@Region_ID",SqlDbType.Int);
        param[6].Value = objbll.Region_ID;
        param[7] = new SqlParameter("@Center_ID",SqlDbType.Int);
        param[7].Value = objbll.Center_ID;
        param[8] = new SqlParameter("@DueDate", SqlDbType.DateTime);
        param[8].Value = objbll.DueDate;
        param[9] = new SqlParameter("@ComplaintTitle", SqlDbType.NVarChar);
        param[9].Value = objbll.ComplaintTitle;
        //param[8] = new SqlParameter("@Cluster_ID", SqlDbType.Int); 
        //param[8].Value = objbll.Cluster_ID;


        int k = dalobj.sqlcmdExecute("TCS_HlpDskComplaintBoxInsert", param);
        //k = Convert.ToInt32(param[2].Value);
        return k;

    }

    public int TCS_HlpDskComplaintBoxUpdate(BLLTCS_HlpDskComplaintBox objbll)
    {
        SqlParameter[] param = new SqlParameter[8];

        param[0] = new SqlParameter("@HDComplaint_ID",SqlDbType.Int);
        param[0].Value = objbll.HDComplaint_ID;
        param[1] = new SqlParameter("@HDSubCat_ID",SqlDbType.Int);
        param[1].Value = objbll.HDSubCat_ID;
        param[2] = new SqlParameter("@HDComplaintDesc",SqlDbType.NVarChar);
        param[2].Value = objbll.HDComplaintDesc;
        //param[3] = new SqlParameter("@HD_Resource_ID",SqlDbType.Int);	param[3].Value = objbll.HD_Resource_ID;
        param[3] = new SqlParameter("@HD_Complaint_Status_ID",SqlDbType.Int);
        param[3].Value = objbll.HD_Complaint_Status_ID;        
        param[4] = new SqlParameter("@PriorityType_ID",SqlDbType.Int);
        param[4].Value = objbll.PriorityType_ID;        
        param[5] = new SqlParameter("@ModifiedOn",SqlDbType.DateTime);	
        param[5].Value = objbll.ModifiedOn;
        param[6] = new SqlParameter("@ModifiedBy",SqlDbType.Int);	
        param[6].Value = objbll.ModifiedBy;
        //param[10] = new SqlParameter("@Region_ID",SqlDbType.Int);	param[10].Value = objbll.Region_ID;
        //param[11] = new SqlParameter("@Center_ID",SqlDbType.Int);	param[11].Value = objbll.Center_ID;
        param[7] = new SqlParameter("@ComplaintTitle", SqlDbType.NVarChar); 
        param[7].Value = objbll.ComplaintTitle;




        int k = dalobj.sqlcmdExecute("TCS_HlpDskComplaintBoxUpdate", param);

        return k;

    }

    public DataTable TCS_HlpDskComplaintBoxSelectById(BLLTCS_HlpDskComplaintBox objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@HDComplaint_ID", SqlDbType.Int); param[0].Value = objbll.HDComplaint_ID;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_HlpDskComplaintBoxSelectById", param);
            return _dt;
        }
        catch (Exception oException)
        {
            throw oException;
        }
        finally
        {
            dalobj.CloseConnection();
        }
    }

    public int TCS_HlpDskComplaintBoxDelete(BLLTCS_HlpDskComplaintBox objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@HDComplaint_ID", SqlDbType.Int); param[0].Value = objbll.HDComplaint_ID;
        int k = dalobj.sqlcmdExecute("TCS_HlpDskComplaintBoxDelete", param);

        return k;

    }

    public DataTable TCS_HlpDskComplaintBoxSelectByCenterId(BLLTCS_HlpDskComplaintBox objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Center_ID", SqlDbType.Int); 
        param[0].Value = objbll.Center_ID;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_HlpDskComplaintBoxSelectByCenterId", param);
            return _dt;
        }
        catch (Exception oException)
        {
            throw oException;
        }
        finally
        {
            dalobj.CloseConnection();
        }
    }


    public DataTable TCS_HlpDskComplaintBoxSelectResourceCenterIDROType(BLLTCS_HlpDskComplaintBox objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Center_ID", SqlDbType.Int);
        param[0].Value = objbll.Center_ID;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_HlpDskComplaintBoxSelectResourceCenterIDROType", param);
            return _dt;
        }
        catch (Exception oException)
        {
            throw oException;
        }
        finally
        {
            dalobj.CloseConnection();
        }
    }

    /*public DataTable TCS_HlpDskComplaintBoxSelectByCenterId(BLLTCS_HlpDskComplaintBox objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int); param[0].Value = objbll.Center_Id;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_HlpDskComplaintBoxSelectByCenterId", param);
            return _dt;
        }
        catch (Exception oException)
        {
            throw oException;
        }
        finally
        {
            dalobj.CloseConnection();
        }
    }*/

    public DataTable TCS_HlpDskComplaintBoxSelectByResourceID(BLLTCS_HlpDskComplaintBox objbll)
    {

        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@HD_Resource_ID", SqlDbType.Int);
        param[0].Value = objbll.HD_Resource_ID;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_HlpDskComplaintBoxSelectByResourceID", param);
            return _dt;
        }
        catch (Exception oException)
        {
            throw oException;
        }
        finally
        {
            dalobj.CloseConnection();
        }
    }

    public int TCS_HlpDskComplaintBoxUpdateResource(BLLTCS_HlpDskComplaintBox objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@HDComplaint_ID", SqlDbType.Int);
        param[0].Value = objbll.HDComplaint_ID;        
        param[1] = new SqlParameter("@HD_Resource_ID",SqlDbType.Int);
        param[1].Value = objbll.HD_Resource_ID;
        param[2] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        param[2].Value = objbll.ModifiedOn;
        param[3] = new SqlParameter("@DueDate", SqlDbType.DateTime); 
        param[3].Value = objbll.DueDate;
        param[4] = new SqlParameter("@AssignerRemarks", SqlDbType.NVarChar); 
        param[4].Value = objbll.AssignerRemarks;

        int k = dalobj.sqlcmdExecute("TCS_HlpDskComplaintBoxUpdateResource", param);

        return k;

    }
}
