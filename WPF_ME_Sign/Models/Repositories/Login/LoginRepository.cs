using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_ME_Sign.Models.Helpers;

namespace WPF_ME_Sign.Models.Repositories.Login
{
    public class LoginRepository
    {
        private string _connStr;
        private string _cmdStr;
        private OracleConnection _conn;
        private OracleCommand _command;

        public LoginRepository()
        {
            _connStr = DBHelper.OracleConnStr;
            _conn = new OracleConnection(_connStr);
        }

        public string LoginById(string userId, string password)
        {
            string _userId;
            _cmdStr = FileHelper.GetSQLString("GetUser");
            try
            {
                _conn.Open();
                _command = new OracleCommand(_cmdStr, _conn);
                _command.Parameters.Add("userId", userId);
                _command.Parameters.Add("password", EncodeHelper.EncodeString(password));
                if (_command.ExecuteScalar() != null) _userId = _command.ExecuteScalar().ToString(); else _userId = "";
                _conn.Close();
                return _userId;
            }
            catch (Exception ex)
            {
                _conn.Close();
                return ex.ToString();
            }
        }

        public string GetUserNamebyId(string userId)
        {
            _cmdStr = FileHelper.GetSQLString("GetUserName");
            string result = "";

            try
            {
                _conn.Open();
                _command = new OracleCommand(_cmdStr, _conn);
                _command.Parameters.Add("userId", userId);
                if (_command.ExecuteScalar() != null)
                {
                    result = _command.ExecuteScalar().ToString();
                }
                _conn.Close();
                return result;
            }
            catch (Exception ex)
            {
                _conn.Close();
                MessageBox.Show(ex.ToString());
            }

            return result;
        }

        public string GetRoleIdbyId(string userId)
        {
            _cmdStr = FileHelper.GetSQLString("GetRoleId");
            string result = "";

            try
            {
                _conn.Open();
                _command = new OracleCommand(_cmdStr, _conn);
                _command.Parameters.Add("userId", userId);
                if (_command.ExecuteScalar() != null)
                {
                    result = _command.ExecuteScalar().ToString();
                }
                _conn.Close();
                return result;
            }
            catch (Exception ex)
            {
                _conn.Close();
                MessageBox.Show(ex.ToString());
            }

            return result;
        }
    }
}
