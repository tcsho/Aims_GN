using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for BLLMessageSettings
/// </summary>
public class BLLMessageSettings
{
    public BLLMessageSettings()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    _DALMessageSettings objdal = new _DALMessageSettings();
     
    #region 'Start Properties Declaration'

    public int Message_Id { get; set; }
    public int Session_Id { get; set; }
    public string Message { get; set; } 
    public string FeeDefaultMessage { get; set; }
    public int Status_Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }
    public string Description { get; set; }

    #endregion

    #region 'Start Executaion Methods' 

    public int MessageSettingsAdd(BLLMessageSettings _obj)
    {
        return objdal.MessageSettingsAdd(_obj);
    }
    public int MessageSettingsUpdate(BLLMessageSettings _obj)
    {
        return objdal.MessageSettingsUpdate(_obj);
    }

    #endregion

    #region 'Start Fetch Methods'
    public DataTable GetMessageSettings()
    {
        return objdal.GetMessageSettings();
    }
    public DataTable GetMessageSettingsById(BLLMessageSettings obj)
    {
        return objdal.GetMessageSettingsById(obj);
    }
    
    #endregion
}