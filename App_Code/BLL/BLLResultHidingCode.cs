using System.Data;

/// <summary>
/// Summary description for BLLResultHidingCode
/// </summary>
public class BLLResultHidingCode
{

    _DALResultHidingCode objdal = new _DALResultHidingCode();

    public int Id { get; set; }
    public int Num { get; set; }
    public string Cod { get; set; }



    public BLLResultHidingCode()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GETResultHideCodingAll()
    {
        return objdal.GETResultHideCodingAll();
    }





    public string ResultCardEncode(string str,DataTable dtHdCodes)
    {

        string returnstring = "";

        if (dtHdCodes.Rows.Count > 0)
        {
            foreach (char item in str)
            {
                DataRow[] dr = dtHdCodes.Select("Num=" + item);
                returnstring += dr[0]["Cod"].ToString();
                returnstring += "Z";

            }
        }
        return returnstring;
    }
    public string ResultCardDecode(string str, DataTable dtHdCodes)
    {
        string returnstring = "";

        if (dtHdCodes.Rows.Count > 0)
        {
            string[] words = str.Split('Z');

            foreach (string item in words)
            {
                if (item.Length>0)
                {
                    DataRow[] dr = dtHdCodes.Select("Cod='" + item+"'");
                    returnstring += dr[0]["Num"].ToString();
                }


            }
        }
        return returnstring;
    }
}