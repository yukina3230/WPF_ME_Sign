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
                        _signList.Add(new SignModel() { SignId = row["sign_id"].ToString() });
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
    }
}
