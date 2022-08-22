﻿using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
            _cmdStr = FileHelper.GetSQLString("CreateUser");

            try
            {
                _conn.Open();
                _command = new OracleCommand(_cmdStr, _conn);
                _command.Parameters.Add("userId", user.UserId);
                _command.Parameters.Add("password", user.Password);
                _command.Parameters.Add("userName", user.UserName);
                _command.Parameters.Add("dept", user.DeptName);
                _command.Parameters.Add("email", user.Email);
                _command.Parameters.Add("roleId", user.RoleName);
                _command.Parameters.Add("create_date", user.CreateDate);
                _command.Parameters.Add("status", "A");
                return (_command.ExecuteNonQuery() > 0) ? true : false;
                _conn.Close();
            }
            catch (Exception ex)
            {
                _conn.Close();
                MessageBox.Show(ex.ToString());
            }

            return false;
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
            _cmdStr = FileHelper.GetSQLString("GetRoleList");

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
            _cmdStr = FileHelper.GetSQLString("GetUserList");

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
                                UserId = row["user_id"].ToString(),
                                UserName = row["user_name"].ToString(),
                                DeptName = row["dept_name"].ToString(),
                                Email = row["email"].ToString(),
                                RoleName = row["role_name"].ToString(),
                                CreateDate = row["create_date"].ToString(),
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
    }
}
