using System;
using System.Data;


/// <summary>
/// Summary description for BLLMain_Organisation
/// </summary>
public class BLLMain_Organisation
    {
    public BLLMain_Organisation()
        {
        //
        // TODO: Add constructor logic here
        //
        }
    
    DALMain_Organisation objdal = new DALMain_Organisation();


    #region 'Start Properties Declaration'
    public int Main_Organisation_Id { get; set; }
    public string Main_Organisation_Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Organisation_ID { get; set; }
    public string Website { get; set; }
    public string Email { get; set; }
    public int Status_Id { get; set; }
    public string File_Name { get; set; }
    public int File_Size { get; set; }
    public int Bank_Id { get; set; }




    #endregion

    

    #region 'Start Executaion Methods'

    public int Main_OrganisationAdd(BLLMain_Organisation _obj)
        {
        return objdal.Main_OrganisationAdd(_obj);
        }
    public int Main_OrganisationUpdate(BLLMain_Organisation _obj)
        {
        return objdal.Main_OrganisationUpdate(_obj);
        }
    public int Main_OrganisationDelete(BLLMain_Organisation _obj)
        {
        return objdal.Main_OrganisationDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Main_OrganisationFetch(BLLMain_Organisation _obj)
        {
        return objdal.Main_OrganisationSelect(_obj);
        }

    public DataTable Main_OrganisationFetchByStatusID(BLLMain_Organisation _obj)
    {
        return objdal.Main_OrganisationSelectByStatusID(_obj);
    }



    public DataTable Main_OrganisationFetch(int _id)
      {
        return objdal.Main_OrganisationSelect(_id);
      }


    #endregion

    }
