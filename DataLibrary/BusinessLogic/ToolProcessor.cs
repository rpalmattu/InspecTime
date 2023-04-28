using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class ToolProcessor
    {
        public static int CreateTool(string toolNumber, string D_Remove, string P_Return, string WC, string EmpNo)
        {
            ToolsModel data = new ToolsModel
            {
                toolNumber = toolNumber,
                D_Remove = D_Remove,
                P_Return = P_Return,
                WC = WC,
                EmpNo = EmpNo
            };

            string sql = @"insert into dbo.Tool_Move (ToolNo, D_Remove, P_Return, WC, EmpNo) 
                            Values (@toolNumber, @D_Remove, @P_Return, @WC, @EmpNo);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int UpdateTool(string toolNumber, string D_Remove, string P_Return, string WC, string EmpNo)
        {
            ToolsModel data = new ToolsModel
            {
                toolNumber = toolNumber,
                D_Remove = D_Remove,
                P_Return = P_Return,
                WC = WC,
                EmpNo = EmpNo
            };

            string sql = @"UPDATE dbo.Tool_Move SET ToolNo = @toolNumber, D_Remove = @D_Remove, P_Return = @P_Return, WC = @WC, EmpNo = @EmpNo WHERE ToolNo = @toolNumber;";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<ToolsModel> LoadCheckedOutTools()
        {
            string sql = @"SELECT ToolNo as toolNumber, D_Remove, P_Return, WC, EmpNo 
                            FROM dbo.Tool_Move; ";


            return SqlDataAccess.LoadData<ToolsModel>(sql);
        }

        public static List<ToolsModel> LoadToolsHistory()
        {
            string sql = @"SELECT ToolNo as toolNumber, D_Remove, P_Return, WC, EmpNo, DateReturned, ID
                            FROM dbo.Tool_Move_History; ";


            return SqlDataAccess.LoadData<ToolsModel>(sql);
        }


        public static int getMaxInHistory()
        {
            string sqlMax = @"SELECT Max(ID) AS ID FROM dbo.Tool_Move_History;";
            return SqlDataAccess.GetMax(sqlMax);
        }


        public static int returnCheckedOutTool(string toolNumber, string D_Remove, string P_Return, string WC, string EmpNo)
        {
            ToolsModel data = new ToolsModel
            {
                toolNumber = toolNumber,
                D_Remove = D_Remove,
                P_Return = P_Return,
                WC = WC,
                EmpNo = EmpNo,
                DateReturned = DateTime.Now.ToString("MM/dd/yyyy"),
                ID = (getMaxInHistory() + 1).ToString(),

            };

            string sqlDelete = @"DELETE FROM dbo.Tool_Move
                                WHERE ToolNo = @toolNumber; ";

            string sqlInsert = @"insert into dbo.Tool_Move_History (ID, ToolNo, D_Remove, P_Return, WC, EmpNo, DateReturned) 
                            Values (@ID, @toolNumber, @D_Remove, @P_Return, @WC, @EmpNo, @DateReturned);";


            return SqlDataAccess.ReturnTool(sqlDelete, sqlInsert, data);
        }

        // Get List item based on field
        public static List<string> LoadFields(string type)
        {
            string sql = @"SELECT Item
                            FROM dbo.siteFields
                            WHERE type = '" + type + "';";

            return SqlDataAccess.LoadData<string>(sql);
        }


        // Return true if the toolNo is in the database is in there
        public static bool InDB(string toolNo)
        {

            string sql = @"SELECT COUNT(ToolNo) FROM dbo.Tool_Move WHERE ToolNo = '" + toolNo + "';";

            return SqlDataAccess.LoadData<string>(sql)[0] == "0";

        }


    }


}
