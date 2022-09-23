using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using WPF_ME_Sign.Models.Helpers;

namespace WPF_ME_Sign.Models.Repositories.Menu.User
{
    public class CreateUserRepository
    {
        private string _connStr;
        private string _cmdStr;
        private bool result;
        private OracleConnection _conn;
        private OracleCommand _command;
        private OracleDataAdapter _dataAdapter;
        private DataTable _dataTable;

        public CreateUserRepository()
        {
            _connStr = DBHelper.OracleConnStr;
            _conn = new OracleConnection(_connStr);
        }

        public bool AddNewUser(UserModel user)
        {
            _cmdStr = FileHelper.GetSQLString("User\\CreateUser");
            result = false;

            try
            {
                _conn.Open();
                _command = new OracleCommand(_cmdStr, _conn);
                _command.Parameters.Add("userId", user.UserId);
                _command.Parameters.Add("password", user.Password);
                _command.Parameters.Add("userName", user.UserName);
                _command.Parameters.Add("deptId", user.DeptId);
                _command.Parameters.Add("email", user.Email);
                _command.Parameters.Add("roleId", user.RoleName);
                _command.Parameters.Add("create_date", user.CreateDate);
                _command.Parameters.Add("status", "A");
                result = (_command.ExecuteNonQuery() > 0) ? true : false;
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

        public bool EditUser(string Password, string UserName, string Email, string DeptId, string RoleId, DateTime CreateDate, string Me_UserId)
        {
            _cmdStr = FileHelper.GetSQLString("User\\UpdateUser");
            result = false;

            try
            {
                _conn.Open();
                _command = new OracleCommand(_cmdStr, _conn);
                _command.Parameters.Add("password", EncodeHelper.EncodeString(Password));
                _command.Parameters.Add("user_name", UserName);
                _command.Parameters.Add("email", Email);
                _command.Parameters.Add("dept_id", DeptId);
                _command.Parameters.Add("role_id", RoleId);
                _command.Parameters.Add("create_date", CreateDate);
                _command.Parameters.Add("me_user_id", Me_UserId);
                result = (_command.ExecuteNonQuery() > 0) ? true : false;
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

        public bool SuspendUser(string userId)
        {
            _cmdStr = FileHelper.GetSQLString("User\\SuspendUser");
            result = false;

            try
            {
                _conn.Open();
                _command = new OracleCommand(_cmdStr, _conn);
                _command.Parameters.Add("userId", userId);
                result = (_command.ExecuteNonQuery() > 0) ? true : false;
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

        public ObservableCollection<DeptModel> LoadDeptList()
        {
            ObservableCollection<DeptModel> _deptList = new ObservableCollection<DeptModel>();
            _cmdStr = FileHelper.GetSQLString("GetDeptList");

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
                        _deptList.Add(new DeptModel() { DeptId = row["department_id"].ToString(), DeptName = row["department_name"].ToString() });
                    }
                }
                _conn.Close();
            }
            catch (Exception ex)
            {
                _conn.Close();
                MessageBox.Show(ex.ToString());
            }

            return _deptList;
        }

        public ObservableCollection<RoleModel> LoadRoleList()
        {
            ObservableCollection<RoleModel> _deptList = new ObservableCollection<RoleModel>();
            _cmdStr = FileHelper.GetSQLString("User\\GetRoleList");

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
                        _deptList.Add(new RoleModel() { RoleId = row["role_id"].ToString(), RoleName = row["role_name"].ToString() });
                    }
                }
                _conn.Close();
            }
            catch (Exception ex)
            {
                _conn.Close();
                MessageBox.Show(ex.ToString());
            }

            return _deptList;
        }

        public ObservableCollection<UserModel> LoadUserList()
        {
            ObservableCollection<UserModel> _userList = new ObservableCollection<UserModel>();
            _cmdStr = FileHelper.GetSQLString("User\\GetUserList");

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
                        _userList.Add
                        (
                            new UserModel()
                            {
                                MeUserId = row["me_user_id"].ToString(),
                                UserId = row["user_id"].ToString(),
                                Password = row["password"].ToString(),
                                UserName = row["user_name"].ToString(),
                                DeptId = row["dept_id"].ToString(),
                                DeptName = row["department_name"].ToString(),
                                Email = row["email"].ToString(),
                                RoleId = row["role_id"].ToString(),
                                RoleName = row["role_name"].ToString(),
                                CreateDate = Convert.ToDateTime(row["create_date"].ToString()).ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                                Status = row["status"].ToString()
                            }
                        );
                    }
                }
                _conn.Close();
            }
            catch (Exception ex)
            {
                _conn.Close();
                MessageBox.Show(ex.ToString());
            }

            return _userList;
        }

        public bool UpdatePassword(string userId, string passwordText)
        {
            _cmdStr = FileHelper.GetSQLString("User\\UpdatePassword");
            result = false;

            try
            {
                _conn.Open();
                _command = new OracleCommand(_cmdStr, _conn);
                _command.Parameters.Add("userId", userId);
                _command.Parameters.Add("password", EncodeHelper.EncodeString(passwordText));
                result = (_command.ExecuteNonQuery() > 0) ? true : false;
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
