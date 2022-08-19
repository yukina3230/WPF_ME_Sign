﻿using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ME_Sign.Models.Helpers;

namespace WPF_ME_Sign.Models.Repositories
{
    public class LoginRepository
    {
        string _connStr;
        string _cmdStr;
        OracleConnection _conn;
        OracleCommand _command;

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
                _conn.Dispose();
                return _userId;
            }
            catch (Exception ex)
            {
                _conn.Dispose();
                return ex.ToString();
            }
        }
    }
}
