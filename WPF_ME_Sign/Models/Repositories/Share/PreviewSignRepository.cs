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

namespace WPF_ME_Sign.Models.Repositories.Share
{
    public class PreviewSignRepository
    {
        private string _connStr;
        private string _cmdStr;
        private bool result = false;
        private OracleConnection _conn;
        private OracleCommand _command;
        private OracleDataAdapter _dataAdapter;
        private DataTable _dataTable;

        public PreviewSignRepository()
        {
            _connStr = DBHelper.OracleConnStr;
            _conn = new OracleConnection(_connStr);
        }

        public ObservableCollection<SignModel> LoadSignerList()
        {
            ObservableCollection<SignModel> _signerList = new ObservableCollection<SignModel>();
            _cmdStr = FileHelper.GetSQLString("GetSignerList");

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
                        _signerList.Add(new SignModel()
                        { 
                            UserId = row["department_id"].ToString(),
                            DeptName = row["department_name"].ToString() 
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

            return _signerList;
        }
    }
}
