using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

/// <summary>
/// Summary description for BLLStudentNameFixedUpsert
/// </summary>



public class BLLStudentNameFixedUpsert
    {
    public BLLStudentNameFixedUpsert()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    _DALStudentNameFixedUpsert objdal = new _DALStudentNameFixedUpsert();



    #region 'Start Properties Declaration'
    public int Student_Id { get; set; }
    public string First_Name { get; set; }
    public string Last_Name { get; set; }
    public string NameUrdu { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int StudentNameFixedUpsertAdd(BLLStudentNameFixedUpsert _obj)
        {
        return objdal.StudentNameFixedUpsertAdd(_obj);
        }
    public int StudentNameFixedUpsertUpdate(BLLStudentNameFixedUpsert _obj)
        {
        return objdal.StudentNameFixedUpsertUpdate(_obj);
        }
    public int StudentNameFixedUpsertDelete(BLLStudentNameFixedUpsert _obj)
        {
        return objdal.StudentNameFixedUpsertDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable StudentNameFixedUpsertFetch(BLLStudentNameFixedUpsert _obj)
        {
        return objdal.StudentNameFixedUpsertSelect(_obj);
        }

    public DataTable StudentNameFixedUpsertFetch(int _id)
      {
        return objdal.StudentNameFixedUpsertSelect(_id);
      }
    public int StudentNameFixedUpsertFetchField(int _Id)
        {
        return objdal.StudentNameFixedUpsertSelectField(_Id);
        }


    #endregion

    }
