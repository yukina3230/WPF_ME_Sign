using DocumentFormat.OpenXml.Spreadsheet;
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
        private bool result;
        private OracleConnection _conn;
        private OracleCommand _command;
        private OracleDataAdapter _dataAdapter;
        private DataTable _dataTable;

        public PreviewSignRepository()
        {
            _connStr = DBHelper.OracleConnStr;
            _conn = new OracleConnection(_connStr);
        }

        public SignPreviewModel LoadPreviewForm(string userId)
        {
            SignPreviewModel previewForm = new SignPreviewModel();
            _cmdStr = FileHelper.GetSQLString("GetPreviewForm");

            try
            {
                _conn.Open();
                _command = new OracleCommand(_cmdStr, _conn);
                _command.Parameters.Add("userId", userId);
                _dataAdapter = new OracleDataAdapter(_command);
                _dataTable = new DataTable();

                if (_dataAdapter.Fill(_dataTable) > 0)
                {
                    foreach (DataRow row in _dataTable.Rows)
                    {
                        previewForm = new SignPreviewModel()
                        {
                            SignId = row["sign_id"].ToString(),
                            DeptName = row["department_name"].ToString(),
                            FormUserId = row["form_user_id"].ToString(),
                            FormUserName = row["form_user_name"].ToString(),
                            Line = row["line"].ToString(),
                            ProjectTitle = row["project_title"].ToString(),
                            Score = row["score"].ToString(),
                            Model = row["model"].ToString(),
                            Processing = row["processing"].ToString(),
                            Article = row["article"].ToString(),
                            DescribeProblem = row["describe_problem"].ToString(),
                            DesctibePicturePath = ReportHelper.CopyTempImage(row["picture_describe_problem"].ToString()),
                            ImproveProblem = row["improve_problem"].ToString(),
                            ImprovePicturePath = ReportHelper.CopyTempImage(row["picture_improve_problem"].ToString()),
                            CreateDate = row["create_date"].ToString(),
                            Manpower_A = row["manpower_a"].ToString(),
                            CT_A = row["ct_a"].ToString(),
                            EFF_A = row["eff_a"].ToString(),
                            Material_A = row["material_a"].ToString(),
                            Manpower_B = row["manpower_b"].ToString(),
                            CT_B = row["ct_b"].ToString(),
                            EFF_B = row["eff_b"].ToString(),
                            Material_B = row["material_b"].ToString()
                        };
                    }
                }
                _conn.Close();
                return previewForm;
            }
            catch (Exception ex)
            {
                _conn.Close();
                MessageBox.Show(ex.ToString());
            }

            return previewForm;
        }

        public List<SignerModel> LoadSignerList(string signId)
        {
            List<SignerModel> signerList = new List<SignerModel>();
            _cmdStr = FileHelper.GetSQLString("GetSignerList");

            try
            {
                _conn.Open();
                _command = new OracleCommand(_cmdStr, _conn);
                _command.Parameters.Add("signId", signId);
                _dataAdapter = new OracleDataAdapter(_command);
                _dataTable = new DataTable();

                if (_dataAdapter.Fill(_dataTable) > 0)
                {
                    foreach (DataRow row in _dataTable.Rows)
                    {
                        signerList.Add(new SignerModel()
                        {
                            SignId = row["sign_id"].ToString(),
                            FormUserId = row["form_user_id"].ToString(),
                            FormUserName = row["form_user_name"].ToString(),
                            FormSignDate = row["form_sign_date"].ToString(),
                            UserId = row["user_sign_id"].ToString(),
                            UserName = row["user_name"].ToString(),
                            DeptName = row["department_name"].ToString(),
                            RoleId = row["role_id"].ToString(),
                            SignDate = row["sign_date"].ToString()
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

            return signerList;
        }

        public bool CheckManagerUser(string userId)
        {
            result = false;
            _cmdStr = FileHelper.GetSQLString("GetUserbyRole");

            try
            {
                _conn.Open();
                _command = new OracleCommand(_cmdStr, _conn);
                _command.Parameters.Add("userId", userId);
                _dataAdapter = new OracleDataAdapter(_command);
                _dataTable = new DataTable();
                result = (_command.ExecuteScalar() != null) ? true : false;
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
