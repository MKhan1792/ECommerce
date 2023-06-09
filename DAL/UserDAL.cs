﻿using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace ECommerce.DAL
{
    public class UserDAL:DALConnection
    {
        public DataTable PR_User_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(SQL_Connection);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_User_SelectAll");

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable PR_User_SelectbyPK(int? UserId)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(SQL_Connection);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_User_SelectbyPK");
                sqlDB.AddInParameter(dbCMD, "UserId", SqlDbType.Int, UserId);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool? PR_User_DeleteByPK(int? UserId)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(SQL_Connection);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_User_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "UserId", SqlDbType.Int, UserId);
                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool? PR_User_Update(int? UserId, string? UserName, string? Email, string? Password, string? Address, string? ImageUrl)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(SQL_Connection);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_User_UpdateByPK");
                sqlDB.AddInParameter(dbCMD, "@UserId", SqlDbType.Int, UserId);
                sqlDB.AddInParameter(dbCMD, "@UserName", SqlDbType.VarChar, UserName);
                sqlDB.AddInParameter(dbCMD, "@Email", SqlDbType.VarChar, Email);
                sqlDB.AddInParameter(dbCMD, "@Password", SqlDbType.VarChar, Password);
                sqlDB.AddInParameter(dbCMD, "@Address", SqlDbType.VarChar, Address);
                sqlDB.AddInParameter(dbCMD, "@ImageUrl", SqlDbType.NVarChar, ImageUrl);

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable PR_User_SelectByIDPass(String? Email, String? Password)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(SQL_Connection);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_User_SelectByIDPass");
                sqlDB.AddInParameter(dbCMD, "Email", SqlDbType.NVarChar, Email);
                sqlDB.AddInParameter(dbCMD, "Password", SqlDbType.NVarChar, Password);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public bool? PR_User_Register(string? UserName, string? Email, string? Password)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(SQL_Connection);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_User_Register");
                sqlDB.AddInParameter(dbCMD, "@UserName", SqlDbType.VarChar, UserName);
                sqlDB.AddInParameter(dbCMD, "@Email", SqlDbType.VarChar, Email);
                sqlDB.AddInParameter(dbCMD, "@Password", SqlDbType.VarChar, Password);
                sqlDB.AddInParameter(dbCMD, "@CreatedON", SqlDbType.Date, DBNull.Value);

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
