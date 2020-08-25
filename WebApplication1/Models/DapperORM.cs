using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;


namespace WebApplication1.Models
{
    public static class DapperORM
    {
        private static string connectionstring = @"Server=54.36.224.103\MSSQL2017;Database=DapperDB;User Id=UniSQL;Password=Lcgytr@cGGH103;";


        public static void ExecuteWithoutReturn(string EmployeeAddOrEdit, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {

                sqlcon.Open();
                sqlcon.Execute(EmployeeAddOrEdit, param, commandType: CommandType.StoredProcedure);
            }


        }

        //DapperORM.ExecuteReturnScalar<int>(_,_);
        public static T ExecuteReturnScalar<T>(string EmployeeAddOrEdit, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {

                sqlcon.Open();
                return (T)Convert.ChangeType(sqlcon.ExecuteScalar(EmployeeAddOrEdit, param, commandType: CommandType.StoredProcedure),typeof(T));
            }
        }


        //DapperORM.ReturnList<EmployeeModel> <= IEnumerable<EmployeeModel>
        public static IEnumerable<T> ReturnList<T>(string EmployeeAddOrEdit, DynamicParameters param= null)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {

                sqlcon.Open();
                return sqlcon.Query<T>(EmployeeAddOrEdit, param, commandType: CommandType.StoredProcedure);
            }
        }


    }
}