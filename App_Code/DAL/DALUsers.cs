using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Country
/// </summary>
public class DALUsers : DALBase
{
    public DALUsers()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALBase dalobj = new DALBase();

    public DataSet get_Users(BLLUser ObjUser)
    {
        SqlConnection oConnection = GetConnection();

        // build the command
        SqlCommand oCommand;
        if (ObjUser.isSuperUser)
        {
            oCommand = new SqlCommand("GetUsersForSuperAdmin", oConnection);
        }
        else
        {
            oCommand = new SqlCommand("GetUsersForAdmin", oConnection);
            oCommand.Parameters.Add(new SqlParameter("sp_mo_id", ObjUser.moID));
        }

        oCommand.CommandType = CommandType.StoredProcedure;


        // Adapter and DataSet
        SqlDataAdapter oAdapter = new SqlDataAdapter();
        oAdapter.SelectCommand = oCommand;
        DataSet oDataSet = new DataSet();

        try
        {
            oConnection.Open();
            oAdapter.Fill(oDataSet, "obj");
            return oDataSet;
        }
        catch (Exception oException)
        {
            throw oException;
        }
        finally
        {
            oConnection.Close();
        }

    }

    public DataSet GetUsersByUserTypeID(BLLUser ObjUser)
    {
        SqlConnection oConnection = GetConnection();

        // build the command
        SqlCommand oCommand;

        oCommand = new SqlCommand("GetUsersByUserTypeID", oConnection);
        oCommand.Parameters.Add(new SqlParameter("sp_mo_id", ObjUser.moID));
        oCommand.Parameters.Add(new SqlParameter("User_Type_ID", ObjUser.userTypeID));

        oCommand.CommandType = CommandType.StoredProcedure;


        // Adapter and DataSet
        SqlDataAdapter oAdapter = new SqlDataAdapter();
        oAdapter.SelectCommand = oCommand;
        DataSet oDataSet = new DataSet();

        try
        {
            oConnection.Open();
            oAdapter.Fill(oDataSet, "obj");
            return oDataSet;
        }
        catch (Exception oException)
        {
            throw oException;
        }
        finally
        {
            oConnection.Close();
        }

    }


    public void Delete(int ID)
    {

        // Establish Connection
        SqlConnection oConnection = GetConnection();

        // build the command
        SqlCommand oCommand = new SqlCommand("DeleteUser", oConnection);
        oCommand.CommandType = CommandType.StoredProcedure;

        // Parameters

        SqlParameter paraID = new SqlParameter("@ID", SqlDbType.Int, 4);
        paraID.Value = ID;
        oCommand.Parameters.Add(paraID);

        try
        {
            oConnection.Open();
            oCommand.ExecuteNonQuery();

        }
        catch (Exception oException)
        {
            throw oException;
        }
        finally
        {
            oConnection.Close();
        }


    }
    public int BLLUser_Add(BLLUser objbll)
    {
        SqlParameter[] param = new SqlParameter[12];
        param[0] = new SqlParameter("@User_Id", SqlDbType.Int);
        param[0].Value = objbll.User_Id;
        param[1] = new SqlParameter("@User_Name", SqlDbType.NVarChar);
        param[1].Value = objbll.usrName;
        param[2] = new SqlParameter("@User_Type_Id", SqlDbType.Int);
        param[2].Value = objbll.userTypeID;
        param[3] = new SqlParameter("@First_Name", SqlDbType.NVarChar);
        param[3].Value = objbll.fName;
        param[4] = new SqlParameter("@Last_Name", SqlDbType.NVarChar);
        param[4].Value = objbll.lName;
        param[5] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[5].Value = objbll.centerID;
        param[6] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[6].Value = objbll.regionID;
        param[7] = new SqlParameter("@Gender", SqlDbType.Int);
        param[7].Value = objbll.genderID;
        param[8] = new SqlParameter("@Email", SqlDbType.NVarChar);
        param[8].Value = objbll.eMail;
        param[9] = new SqlParameter("@Address", SqlDbType.NVarChar);
        param[9].Value = objbll.address;
        param[10] = new SqlParameter("@Mobile", SqlDbType.NVarChar);
        param[10].Value = objbll.mPhone;
        param[11] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[11].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("User_Add", param);
        int k = (int)param[11].Value;
        return k;

    }
    public int BLUser_SharedLoginAdd(BLLUser objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[0].Value = objbll.ID;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[1].Value = objbll.centerID;

        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("User_SharedLoginAdd", param);
        int k = (int)param[2].Value;
        return k;

    }
    public int Add(BLLUser objUser)
    {
        //        nAlreadyIn = 0;
        // Establish Connection
        SqlConnection oConnection = GetConnection();

        // build the command
        SqlCommand oCommand = new SqlCommand("AddUser", oConnection);
        oCommand.CommandType = CommandType.StoredProcedure;

        // Parameters
        SqlParameter para_usrName = new SqlParameter("@usrName", SqlDbType.NVarChar, 50);
        para_usrName.Value = objUser.usrName;
        oCommand.Parameters.Add(para_usrName);

        SqlParameter para_password = new SqlParameter("@password", SqlDbType.NVarChar, 50);
        para_password.Value = objUser.password;
        oCommand.Parameters.Add(para_password);

        SqlParameter para_fName = new SqlParameter("@fName", SqlDbType.NVarChar, 30);
        para_fName.Value = objUser.fName;
        oCommand.Parameters.Add(para_fName);

        SqlParameter para_mName = new SqlParameter("@mName", SqlDbType.NVarChar, 50);
        para_mName.Value = objUser.mName;
        oCommand.Parameters.Add(para_mName);

        SqlParameter para_lName = new SqlParameter("@lName", SqlDbType.NVarChar, 50);
        para_lName.Value = objUser.lName;
        oCommand.Parameters.Add(para_lName);

        SqlParameter para_genderID = new SqlParameter("@genderID", SqlDbType.Int, 4);
        para_genderID.Value = objUser.genderID;
        oCommand.Parameters.Add(para_genderID);

        SqlParameter para_birthDay = new SqlParameter("@birthDay", SqlDbType.DateTime, 10);
        para_birthDay.Value = Convert.ToDateTime(objUser.birthDay);
        oCommand.Parameters.Add(para_birthDay);

        SqlParameter para_eMail = new SqlParameter("@eMail", SqlDbType.NVarChar, 50);
        para_eMail.Value = objUser.eMail;
        oCommand.Parameters.Add(para_eMail);

        SqlParameter para_hPhone = new SqlParameter("@hPhone", SqlDbType.NVarChar, 50);
        para_hPhone.Value = objUser.hPhone;
        oCommand.Parameters.Add(para_hPhone);

        SqlParameter para_mPhone = new SqlParameter("@mPhone", SqlDbType.NVarChar, 50);
        para_mPhone.Value = objUser.mPhone;
        oCommand.Parameters.Add(para_mPhone);

        SqlParameter para_address = new SqlParameter("@address", SqlDbType.NVarChar, 200);
        para_address.Value = objUser.address;
        oCommand.Parameters.Add(para_address);

        SqlParameter para_city = new SqlParameter("@city", SqlDbType.NVarChar, 50);
        para_city.Value = objUser.city;
        oCommand.Parameters.Add(para_city);

        SqlParameter para_state = new SqlParameter("@state", SqlDbType.NVarChar, 50);
        para_state.Value = objUser.state;
        oCommand.Parameters.Add(para_state);

        SqlParameter para_postalCode = new SqlParameter("@postalCode", SqlDbType.NVarChar, 50);
        para_postalCode.Value = objUser.postalCode;
        oCommand.Parameters.Add(para_postalCode);

        SqlParameter para_groupID = new SqlParameter("@groupID", SqlDbType.Int, 4);
        para_groupID.Value = objUser.groupID;
        oCommand.Parameters.Add(para_groupID);

        if (objUser.MOrgID == 0)
        {
            SqlParameter para_MOrgID = new SqlParameter("@MOrgID", SqlDbType.Int, 4);
            para_MOrgID.Value = DBNull.Value;
            oCommand.Parameters.Add(para_MOrgID);
        }
        else
        {
            SqlParameter para_MOrgID = new SqlParameter("@MOrgID", SqlDbType.Int, 4);
            para_MOrgID.Value = objUser.MOrgID;
            oCommand.Parameters.Add(para_MOrgID);
        }

        SqlParameter para_countryID = new SqlParameter("@countryID", SqlDbType.NVarChar, 50);
        para_countryID.Value = objUser.countryID;
        oCommand.Parameters.Add(para_countryID);


        if (objUser.regionID == 0)
        {
            SqlParameter para_regionID = new SqlParameter("@regionID", SqlDbType.Int, 4);
            para_regionID.Value = DBNull.Value;
            oCommand.Parameters.Add(para_regionID);
        }
        else
        {
            SqlParameter para_regionID = new SqlParameter("@regionID", SqlDbType.Int, 4);
            para_regionID.Value = objUser.regionID;
            oCommand.Parameters.Add(para_regionID);
        }

        if (objUser.centerID == 0)
        {
            SqlParameter para_centerID = new SqlParameter("@centerID", SqlDbType.Int, 4);
            para_centerID.Value = DBNull.Value;
            oCommand.Parameters.Add(para_centerID);
        }
        else
        {
            SqlParameter para_centerID = new SqlParameter("@centerID", SqlDbType.Int, 4);
            para_centerID.Value = objUser.centerID;
            oCommand.Parameters.Add(para_centerID);
        }

        if (objUser.gradeID == 0)
        {
            SqlParameter para_gradeID = new SqlParameter("@gradeID", SqlDbType.Int, 4);
            para_gradeID.Value = DBNull.Value;
            oCommand.Parameters.Add(para_gradeID);
        }
        else
        {
            SqlParameter para_gradeID = new SqlParameter("@gradeID", SqlDbType.Int, 4);
            para_gradeID.Value = objUser.gradeID;
            oCommand.Parameters.Add(para_gradeID);
        }

        SqlParameter paraAlreadyIn = new SqlParameter("@AlreadyIn", SqlDbType.Int, 4);
        paraAlreadyIn.Direction = ParameterDirection.Output;

        if (objUser.lib_ID == 0)
        {
            SqlParameter para_libID = new SqlParameter("@Lib_ID", SqlDbType.Int, 4);
            para_libID.Value = DBNull.Value;
            oCommand.Parameters.Add(para_libID);
        }
        else
        {
            SqlParameter para_libID = new SqlParameter("@Lib_ID", SqlDbType.Int, 4);
            para_libID.Value = objUser.lib_ID;
            oCommand.Parameters.Add(para_libID);
        }
        if (objUser.cluster_Id == 0)
        {
            SqlParameter para_clusterId = new SqlParameter("@ClusterID", SqlDbType.Int, 4);
            para_clusterId.Value = DBNull.Value;
            oCommand.Parameters.Add(para_clusterId);
        }
        else
        {
            SqlParameter para_clusterId = new SqlParameter("@ClusterID", SqlDbType.Int, 4);
            para_clusterId.Value = objUser.cluster_Id;
            oCommand.Parameters.Add(para_clusterId);
        }

        if (objUser.warehouse_ID == 0)
        {
            SqlParameter para_warehouseID = new SqlParameter("@Warehouse_ID", SqlDbType.Int, 4);
            para_warehouseID.Value = DBNull.Value;
            oCommand.Parameters.Add(para_warehouseID);
        }
        else
        {
            SqlParameter para_warehouseID = new SqlParameter("@Warehouse_ID", SqlDbType.Int, 4);
            para_warehouseID.Value = objUser.warehouse_ID;
            oCommand.Parameters.Add(para_warehouseID);
        }


        oCommand.Parameters.Add(paraAlreadyIn);



        try
        {
            oConnection.Open();
            oCommand.ExecuteNonQuery();
            objUser.nAlreadyIn = (int)paraAlreadyIn.Value;

        }
        catch (Exception oException)
        {
            throw oException;
        }
        finally
        {
            oConnection.Close();
        }

        return objUser.nAlreadyIn;
    }



    public void Update(BLLUser ObjUser)
    {
        // Establish Connection
        SqlConnection oConnection = GetConnection();

        // build the command
        SqlCommand oCommand = new SqlCommand("UpdateUser", oConnection);
        oCommand.CommandType = CommandType.StoredProcedure;

        // Parameters
        SqlParameter para_usrName = new SqlParameter("@usrName", SqlDbType.NVarChar, 50);
        para_usrName.Value = ObjUser.usrName;
        oCommand.Parameters.Add(para_usrName);

        SqlParameter para_password = new SqlParameter("@password", SqlDbType.NVarChar, 25);
        para_password.Value = ObjUser.password;
        oCommand.Parameters.Add(para_password);

        SqlParameter para_fName = new SqlParameter("@fName", SqlDbType.NVarChar, 30);
        para_fName.Value = ObjUser.fName;
        oCommand.Parameters.Add(para_fName);

        SqlParameter para_mName = new SqlParameter("@mName", SqlDbType.NVarChar, 25);
        para_mName.Value = ObjUser.mName;
        oCommand.Parameters.Add(para_mName);

        SqlParameter para_lName = new SqlParameter("@lName", SqlDbType.NVarChar, 25);
        para_lName.Value = ObjUser.lName;
        oCommand.Parameters.Add(para_lName);

        SqlParameter para_genderID = new SqlParameter("@genderID", SqlDbType.Int, 4);
        para_genderID.Value = ObjUser.genderID;
        oCommand.Parameters.Add(para_genderID);

        SqlParameter para_birthDay = new SqlParameter("@birthDay", SqlDbType.DateTime, 10);
        para_birthDay.Value = Convert.ToDateTime(ObjUser.birthDay);
        oCommand.Parameters.Add(para_birthDay);

        SqlParameter para_eMail = new SqlParameter("@eMail", SqlDbType.NVarChar, 50);
        para_eMail.Value = ObjUser.eMail;
        oCommand.Parameters.Add(para_eMail);

        SqlParameter para_hPhone = new SqlParameter("@hPhone", SqlDbType.NVarChar, 25);
        para_hPhone.Value = ObjUser.hPhone;
        oCommand.Parameters.Add(para_hPhone);

        SqlParameter para_mPhone = new SqlParameter("@mPhone", SqlDbType.NVarChar, 25);
        para_mPhone.Value = ObjUser.mPhone;
        oCommand.Parameters.Add(para_mPhone);

        SqlParameter para_address = new SqlParameter("@address", SqlDbType.NVarChar, 200);
        para_address.Value = ObjUser.address;
        oCommand.Parameters.Add(para_address);

        SqlParameter para_city = new SqlParameter("@city", SqlDbType.NVarChar, 25);
        para_city.Value = ObjUser.city;
        oCommand.Parameters.Add(para_city);

        SqlParameter para_state = new SqlParameter("@state", SqlDbType.NVarChar, 25);
        para_state.Value = ObjUser.state;
        oCommand.Parameters.Add(para_state);

        SqlParameter para_postalCode = new SqlParameter("@postalCode", SqlDbType.NVarChar, 25);
        para_postalCode.Value = ObjUser.postalCode;
        oCommand.Parameters.Add(para_postalCode);

        SqlParameter para_groupID = new SqlParameter("@groupID", SqlDbType.Int, 4);
        para_groupID.Value = ObjUser.groupID;
        oCommand.Parameters.Add(para_groupID);

        if (ObjUser.MOrgID == 0)
        {
            SqlParameter para_MOrgID = new SqlParameter("@MOrgID", SqlDbType.Int, 4);
            para_MOrgID.Value = DBNull.Value;
            oCommand.Parameters.Add(para_MOrgID);
        }
        else
        {
            SqlParameter para_MOrgID = new SqlParameter("@MOrgID", SqlDbType.Int, 4);
            para_MOrgID.Value = ObjUser.MOrgID;
            oCommand.Parameters.Add(para_MOrgID);
        }

        SqlParameter para_countryID = new SqlParameter("@countryID", SqlDbType.NVarChar, 50);
        para_countryID.Value = ObjUser.countryID;
        oCommand.Parameters.Add(para_countryID);

        if (ObjUser.regionID == 0)
        {
            SqlParameter para_regionID = new SqlParameter("@regionID", SqlDbType.Int, 4);
            para_regionID.Value = DBNull.Value;
            oCommand.Parameters.Add(para_regionID);
        }
        else
        {
            SqlParameter para_regionID = new SqlParameter("@regionID", SqlDbType.Int, 4);
            para_regionID.Value = ObjUser.regionID;
            oCommand.Parameters.Add(para_regionID);
        }

        if (ObjUser.centerID == 0)
        {
            SqlParameter para_centerID = new SqlParameter("@centerID", SqlDbType.Int, 4);
            para_centerID.Value = DBNull.Value;
            oCommand.Parameters.Add(para_centerID);
        }
        else
        {
            SqlParameter para_centerID = new SqlParameter("@centerID", SqlDbType.Int, 4);
            para_centerID.Value = ObjUser.centerID;
            oCommand.Parameters.Add(para_centerID);
        }

        if (ObjUser.gradeID == 0)
        {
            SqlParameter para_gradeID = new SqlParameter("@gradeID", SqlDbType.Int, 4);
            para_gradeID.Value = DBNull.Value;
            oCommand.Parameters.Add(para_gradeID);
        }
        else
        {
            SqlParameter para_gradeID = new SqlParameter("@gradeID", SqlDbType.Int, 4);
            para_gradeID.Value = ObjUser.gradeID;
            oCommand.Parameters.Add(para_gradeID);
        }

        SqlParameter paraID = new SqlParameter("@ID", SqlDbType.Int, 4);
        paraID.Value = ObjUser.ID;
        oCommand.Parameters.Add(paraID);


        if (ObjUser.lib_ID == 0)
        {
            SqlParameter para_libID = new SqlParameter("@Lib_ID", SqlDbType.Int, 4);
            para_libID.Value = DBNull.Value;
            oCommand.Parameters.Add(para_libID);
        }
        else
        {
            SqlParameter para_libID = new SqlParameter("@Lib_ID", SqlDbType.Int, 4);
            para_libID.Value = ObjUser.lib_ID;
            oCommand.Parameters.Add(para_libID);
        }
        if (ObjUser.cluster_id == 0)
        {
            SqlParameter para_clusterId = new SqlParameter("@ClusterID", SqlDbType.Int, 4);
            para_clusterId.Value = DBNull.Value;
            oCommand.Parameters.Add(para_clusterId);
        }
        else
        {
            SqlParameter para_clusterId = new SqlParameter("@ClusterID", SqlDbType.Int, 4);
            para_clusterId.Value = ObjUser.cluster_id;
            oCommand.Parameters.Add(para_clusterId);
        }

        if (ObjUser.warehouse_ID == 0)
        {
            SqlParameter para_warehouseID = new SqlParameter("@Warehouse_ID", SqlDbType.Int, 4);
            para_warehouseID.Value = DBNull.Value;
            oCommand.Parameters.Add(para_warehouseID);
        }
        else
        {
            SqlParameter para_warehouseID = new SqlParameter("@Warehouse_ID", SqlDbType.Int, 4);
            para_warehouseID.Value = ObjUser.warehouse_ID;
            oCommand.Parameters.Add(para_warehouseID);
        }


        try
        {
            oConnection.Open();
            oCommand.ExecuteNonQuery();
            //            nAlreadyIn = (int)paraAlreadyIn.Value;

        }
        catch (Exception oException)
        {
            throw oException;
        }
        finally
        {
            oConnection.Close();
        }
    }


    public int ChangePassword(BLLUser objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@User_Id", SqlDbType.Int);
        param[0].Value = objbll.User_Id;
        param[1] = new SqlParameter("@OldPassword", SqlDbType.NVarChar);
        param[1].Value = objbll.OldPassword;
        param[2] = new SqlParameter("@NewPassword", SqlDbType.NVarChar);
        param[2].Value = objbll.NewPassword;

        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("UserPasswordChange", param);
        int k = (int)param[3].Value;
        return k;
    }

    public bool GetUserAvailabilityWRTOrg(string userName, int orgID)
    {

        // Establish Connection
        SqlConnection oConnection = GetConnection();

        // build the command
        SqlCommand oCommand = new SqlCommand("spCheckUserNameAvailabilityWRTOrg", oConnection);
        oCommand.CommandType = CommandType.StoredProcedure;

        // Parameters

        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@UserName", userName);
        param[1] = new SqlParameter("@OrgID", orgID);

        try
        {
            int res = Convert.ToInt32(SqlHelper.ExecuteScalar(oConnection, "spCheckUserNameAvailabilityWRTOrg", param));

            if (res > 0)
                return false;
            return true;
        }
        catch (Exception oException)
        {
            throw oException;
        }
    }

    public DataSet UserSelectByUserLevel(int userLevel_ID, int userType_ID, int main_Organisation_Id, int region_ID, int cluster_ID, int center_ID)
    {
        SqlConnection oConnection = GetConnection();

        // build the command
        SqlCommand oCommand;


        oCommand = new SqlCommand("UserSelectByUserLevel", oConnection);

        oCommand.Parameters.Add(new SqlParameter("@UserLevel_ID", userLevel_ID));
        oCommand.Parameters.Add(new SqlParameter("@UserType_ID", userType_ID));
        oCommand.Parameters.Add(new SqlParameter("@Main_Organisation_Id", main_Organisation_Id));
        oCommand.Parameters.Add(new SqlParameter("@Region_ID", region_ID));
        oCommand.Parameters.Add(new SqlParameter("@Cluster_ID", cluster_ID));
        oCommand.Parameters.Add(new SqlParameter("@Center_ID", center_ID));

        oCommand.CommandType = CommandType.StoredProcedure;

        // Adapter and DataSet
        SqlDataAdapter oAdapter = new SqlDataAdapter();
        oAdapter.SelectCommand = oCommand;
        DataSet oDataSet = new DataSet();

        try
        {
            oConnection.Open();
            oAdapter.Fill(oDataSet, "obj");
            return oDataSet;
        }
        catch (Exception oException)
        {
            throw oException;
        }
        finally
        {
            oConnection.Close();
        }

    }

    public DataSet UserSelectByUserLevel(int userLevel_ID, int userType_ID, int main_Organisation_Id, int region_ID, int cluster_ID, int center_ID, string param)
    {
        SqlConnection oConnection = GetConnection();

        // build the command
        SqlCommand oCommand;


        oCommand = new SqlCommand("UserSelectByUserLevel_New", oConnection);

        oCommand.Parameters.Add(new SqlParameter("@UserLevel_ID", userLevel_ID));
        oCommand.Parameters.Add(new SqlParameter("@UserType_ID", userType_ID));
        oCommand.Parameters.Add(new SqlParameter("@Main_Organisation_Id", main_Organisation_Id));
        oCommand.Parameters.Add(new SqlParameter("@Region_ID", region_ID));
        oCommand.Parameters.Add(new SqlParameter("@Cluster_ID", cluster_ID));
        oCommand.Parameters.Add(new SqlParameter("@Center_ID", center_ID));
        oCommand.Parameters.Add(new SqlParameter("@param", param));

        oCommand.CommandType = CommandType.StoredProcedure;

        // Adapter and DataSet
        SqlDataAdapter oAdapter = new SqlDataAdapter();
        oAdapter.SelectCommand = oCommand;
        DataSet oDataSet = new DataSet();

        try
        {
            oConnection.Open();
            oAdapter.Fill(oDataSet, "obj");
            return oDataSet;
        }
        catch (Exception oException)
        {
            throw oException;
        }
        finally
        {
            oConnection.Close();
        }

    }

    public DataTable UserSelectByUserName(BLLUser objbll)
    {

        DataTable _dt = new DataTable();

        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@sp_main_organisation_id", SqlDbType.Int);
        param[0].Value = objbll.MOrgID;

        param[1] = new SqlParameter("@sp_user_name", SqlDbType.NVarChar);
        param[1].Value = objbll.usrName;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("UserSelectByUserName", param);
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


    public DataTable StatSelectByUserId(BLLUser ObjUser)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@UserId", SqlDbType.Int);
        param[0].Value = ObjUser.User_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("HomePageStatics_All", param);
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



    }

    public DataTable UserTypeSelectAll()
    {


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("User_TypeSelectAll");
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



    }
    public DataTable UserSelectAll()
    {


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("NotifUserSelectAll");
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



    }
}
