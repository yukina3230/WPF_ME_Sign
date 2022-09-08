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

namespace WPF_ME_Sign.Models.Repositories.Menu.Form
{
    public class QuerySignRepository
    {
        private string _connStr;
        private string _cmdStr;
        private bool result = false;
        private OracleConnection _conn;
        private OracleCommand _command;
        private OracleDataAdapter _dataAdapter;
        private DataTable _dataTable;

        public QuerySignRepository()
        {
            _connStr = DBHelper.OracleConnStr;
            _conn = new OracleConnection(_connStr);
        }

        public ObservableCollection<SignModel> LoadSignList()
        {
            ObservableCollection<SignModel> _signList = new ObservableCollection<SignModel>();
            _cmdStr = FileHelper.GetSQLString("GetSignList");

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
                        _signList.Add(new SignModel()
                        {
                            SignId = row["sign_id"].ToString(),
                            ProjectTitle = row["project_title"].ToString(),
                            CreateDate = row["create_date"].ToString(),
                            FormUserId = row["form_user_id"].ToString(),
                            FormUserName = row["form_user_name"].ToString(),
                            DeptName = row["department_name"].ToString(),
                            SignStatus = row["status_sign"].ToString()
                        });
                    }
                }
                _conn.Close();
            }
            catch (Exception ex)
            {
                _conn.Close();
                MessageBox.Show(ex.ToString());
            }

            return _signList;
        }

        public bool InsertSign(SignModel sign)
        {
            if (InsertSigner(sign))
            {
                return UpdateSignStatus(sign.SignId);
            }

            return false;
        }

        private bool InsertSigner(SignModel sign)
        {
            _cmdStr = FileHelper.GetSQLString("InsertSigner");

            try
            {
                _conn.Open();
                _command = new OracleCommand(_cmdStr, _conn);
                _command.Parameters.Add("sign_id", sign.SignId);
                _command.Parameters.Add("user_id", sign.UserId);
                _command.Parameters.Add("create_date", sign.SignDate);
                result = (_command.ExecuteNonQuery() > 0) ? true : false;
                _conn.Close();
                return result;
            }
            catch (Exception ex)
            {
                _conn.Close();
                MessageBox.Show(ex.ToString());
            }

            return false;
        }

        private bool UpdateSignStatus(string signId)
        {
            _cmdStr = FileHelper.GetSQLString("UpdateSignedStatus");

            try
            {
                _conn.Open();
                _command = new OracleCommand(_cmdStr, _conn);
                _command.Parameters.Add("sign_id", signId);
                result = (_command.ExecuteNonQuery() > 0) ? true : false;
                _conn.Close();
                return result;
            }
            catch (Exception ex)
            {
                _conn.Close();
                MessageBox.Show(ex.ToString());
            }

            return false;
        }
    }
}
