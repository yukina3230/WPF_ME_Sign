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

namespace WPF_ME_Sign.Models.Repositories.Menu.User
{
    public class CreateUserRepository
    {
        string _connStr;
        string _cmdStr;
        OracleConnection _conn;
        OracleCommand _command;
        OracleDataAdapter _dataAdapter;
        DataTable _dataTable;

        public CreateUserRepository()
        {
            _connStr = DBHelper.OracleConnStr;
            _conn = new OracleConnection(_connStr);
        }

        public bool AddNewUser(UserModel user)
        {
            string _userId;
            _cmdStr = FileHelper.GetSQLString("CreateUser");

            using (_conn)
            {
                try
                {
                    _conn.Open();
                    _command = new OracleCommand(_cmdStr, _conn);
                    _command.Parameters.Add("userId", user.UserId);
                    _command.Parameters.Add("password", user.Password);
                    _command.Parameters.Add("userName", user.UserName);
                    _command.Parameters.Add("dept", user.Dept);
                    _command.Parameters.Add("email", user.Password);
                    _command.Parameters.Add("roleId", user.RoleId);
                    _command.Parameters.Add("create_date", user.CreateDate);
                    return (_command.ExecuteScalar() != null) ? true : false; 
                }
                catch (Exception ex)
                {
                    _conn.Dispose();
                    MessageBox.Show(ex.ToString());
                }

            return false;
        }
    }

        public ObservableCollection<DeptModel> LoadDeptList()
        {
            ObservableCollection<DeptModel> _deptList = new ObservableCollection<DeptModel>();
            _cmdStr = FileHelper.GetSQLString("GetDeptList");

            using (_conn)
            {
                try
                {
                    _conn.Open();
                    _command = new OracleCommand(_cmdStr, _conn);
                    _dataAdapter = new OracleDataAdapter(_command);
                    _dataTable = new DataTable();

                    if (_dataAdapter.Fill(_dataTable) > 0)
                    {
                        foreach (DataRow row in _dataTable.Rows)
                        {
                            _deptList.Add(new DeptModel() { DeptId =  row["department_id"].ToString(), DeptName = row["department_name"].ToString() });
                        }
                    }
                }
                catch (Exception ex)
                {
                    _conn.Dispose();
                    MessageBox.Show(ex.ToString());
                }
            }

            return _deptList;
        }

        public ObservableCollection<UserModel> LoadUserList()
        {
            ObservableCollection<UserModel> _deptList = new ObservableCollection<UserModel>();
            _cmdStr = FileHelper.GetSQLString("GetUserList");

            using (_conn)
            {
                try
                {
                    _conn.Open();
                    _command = new OracleCommand(_cmdStr, _conn);
                    _dataAdapter = new OracleDataAdapter(_command);
                    _dataTable = new DataTable();

                    if (_dataAdapter.Fill(_dataTable) > 0)
                    {
                        foreach (DataRow row in _dataTable.Rows)
                        {
                            _deptList.Add
                            (
                                new UserModel()
                                {
                                    UserId = row["user_id"].ToString(),
                                    UserName = row["user_name"].ToString(),
                                    Dept = row["dept"].ToString(),
                                    Email = row["email"].ToString(),
                                    RoleId = row["role_id"].ToString(),
                                    CreateDate = row["create_date"].ToString()
                                }
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    _conn.Dispose();
                    MessageBox.Show(ex.ToString());
                }
            }

            return _deptList;
        }
    }
}
