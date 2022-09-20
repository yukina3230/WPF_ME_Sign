using DocumentFormat.OpenXml.Spreadsheet;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_ME_Sign.Models.Helpers;

namespace WPF_ME_Sign.Models.Repositories.Menu.Form
{
    public class CreateFormRepository
    {
        private string _connStr;
        private string _cmdStr;
        private bool result = false;
        private OracleConnection _conn;
        private OracleCommand _command;
        private OracleDataAdapter _dataAdapter;
        private DataTable _dataTable;

        public CreateFormRepository()
        {
            _connStr = DBHelper.OracleConnStr;
            _conn = new OracleConnection(_connStr);
        }

        public bool CreateNewForm(FormModel form)
        {
            try
            {
                return CreateForm(form);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return false;
        }

        private bool CreateForm(FormModel form)
        {
            _cmdStr = FileHelper.GetSQLString("CreateSign");

            try
            {
                _conn.Open();
                _command = new OracleCommand(_cmdStr, _conn);
                _command.Parameters.Add("sign_id", form.SignId);
                _command.Parameters.Add("department_id", form.DeptId);
                _command.Parameters.Add("form_user_id", form.FormUserId);
                _command.Parameters.Add("form_user_name", form.FormUserName);
                _command.Parameters.Add("line", form.Line);
                _command.Parameters.Add("project_title", form.ProjectTitle);
                _command.Parameters.Add("score", form.Score);
                _command.Parameters.Add("model", form.Model);
                _command.Parameters.Add("article", form.Article);
                _command.Parameters.Add("processing", form.Processing);
                _command.Parameters.Add("describe_problem", form.DescribeProblem);
                _command.Parameters.Add("improve_problem", form.ImproveProblem);
                _command.Parameters.Add("picture_describe_problem", form.DesctibePicturePath);
                _command.Parameters.Add("picture_improve_problem", form.ImprovePicturePath);
                _command.Parameters.Add("manpower_a", form.Manpower_A);
                _command.Parameters.Add("ct_a", form.CT_A);
                _command.Parameters.Add("eff_a", form.EFF_A);
                _command.Parameters.Add("material_a", form.Material_A);
                _command.Parameters.Add("manpower_b", form.Manpower_B);
                _command.Parameters.Add("ct_b", form.CT_B);
                _command.Parameters.Add("eff_b", form.EFF_B);
                _command.Parameters.Add("material_b", form.Material_B);
                _command.Parameters.Add("create_user_id", form.CreateUserId);
                _command.Parameters.Add("create_date", form.CreateDate);
                _command.Parameters.Add("status", 'W');
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

        public ObservableCollection<DeptModel> LoadDeptList()
        {
            ObservableCollection<DeptModel> deptList = new ObservableCollection<DeptModel>();
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
                        deptList.Add(new DeptModel() { DeptId = row["department_id"].ToString(), DeptName = row["department_name"].ToString() });
                    }
                }
                _conn.Close();
            }
            catch (Exception ex)
            {
                _conn.Close();
                MessageBox.Show(ex.ToString());
            }

            return deptList;
        }
    }
}
