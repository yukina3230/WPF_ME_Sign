using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_ME_Sign.Models.Helpers;

namespace WPF_ME_Sign.Models.Repositories.Main
{
    public class MainRepository
    {
        private string _connStr;
        private string _cmdStr;
        private OracleConnection _conn;
        private OracleCommand _command;
        private OracleDataAdapter _dataAdapter;
        private DataTable _dataTable;

        public MainRepository()
        {
            _connStr = DBHelper.OracleConnStr;
            _conn = new OracleConnection(_connStr);
        }

        public PriorityModel GetPriority(string roleId)
        {
            PriorityModel priority = new PriorityModel();

            priority.MenuForm = Pri_Form(roleId);
            priority.MenuUser = Pri_User(roleId);

            try
            {
                _cmdStr = FileHelper.GetSQLString("Priority\\GetPriorityList");
                _conn.Open();
                _command = new OracleCommand(_cmdStr, _conn);
                _command.Parameters.Add("roleId", roleId);
                _dataAdapter = new OracleDataAdapter(_command);
                _dataTable = new DataTable();

                if (_dataAdapter.Fill(_dataTable) > 0)
                {
                    foreach (DataRow row in _dataTable.Rows)
                    {
                        string priorityName = row["priority_name"].ToString();

                        switch (priorityName)
                        {
                            case "CreateFormView":
                                priority.CreateForm = true;
                                break;

                            case "QuerySignView":
                                priority.QuerySign = true;
                                break;

                            case "SendMailView":
                                priority.SendMail = true;
                                break;

                            case "CreateUserView":
                                priority.CreateUser = true;
                                break;

                            case "ChangePasswordView":
                                priority.ChangePassword = true;
                                break;
                        }
                    }
                }
                _conn.Close();
            }
            catch (Exception ex)
            {
                _conn.Close();
                MessageBox.Show(ex.ToString());
            }

            return priority;
        }

        private bool Pri_Form(string roleId)
        {
            bool result = false;
            _cmdStr = FileHelper.GetSQLString("Priority\\GetPriority_Form");

            try
            {
                _conn.Open();
                _command = new OracleCommand(_cmdStr, _conn);
                _command.Parameters.Add("roleId", roleId);

                if (int.Parse(_command.ExecuteScalar().ToString()) > 0) result = true;
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

        private bool Pri_User(string roleId)
        {
            bool result = false;
            _cmdStr = FileHelper.GetSQLString("Priority\\GetPriority_User");

            try
            {
                _conn.Open();
                _command = new OracleCommand(_cmdStr, _conn);
                _command.Parameters.Add("roleId", roleId);

                if (int.Parse(_command.ExecuteScalar().ToString()) > 0) result = true;
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
