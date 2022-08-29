using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
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

        public CreateFormRepository()
        {
            _connStr = DBHelper.OracleConnStr;
            _conn = new OracleConnection(_connStr);
        }

        public bool CreateNewForm(FormModel form, KPIModel kpi, SignModel sign)
        {
            try
            {
                if (InsertKPI(kpi)) if (InsertForm(form)) if (InsertSign(sign))

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return false;
        }

        private bool InsertForm(FormModel form)
        {
            _cmdStr = FileHelper.GetSQLString("CreateSign");

            try
            {
                _conn.Open();
                _command = new OracleCommand(_cmdStr, _conn);
                _command.Parameters.Add("sign_id", form.SignId);
                _command.Parameters.Add("department_id", form.DeptId);
                _command.Parameters.Add("form_user_id", form.FormUserId);
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
                _command.Parameters.Add("create_user_id", form.CreateUserId);
                _command.Parameters.Add("create_date", form.CreateDate);
                _command.Parameters.Add("status", 'N');
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

        private bool InsertKPI(KPIModel kpi)
        {
            _cmdStr = FileHelper.GetSQLString("CreateKPI");

            try
            {
                _conn.Open();
                _command = new OracleCommand(_cmdStr, _conn);
                _command.Parameters.Add("manpower_a", kpi.Manpower_A);
                _command.Parameters.Add("ct_a", kpi.CT_A);
                _command.Parameters.Add("eff_a", kpi.EFF_A);
                _command.Parameters.Add("material_a", kpi.Material_A);
                _command.Parameters.Add("manpower_b", kpi.Manpower_B);
                _command.Parameters.Add("ct_b", kpi.CT_B);
                _command.Parameters.Add("eff_b", kpi.EFF_B);
                _command.Parameters.Add("material_b", kpi.Material_B);
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

        private bool InsertSign(SignModel sign)
        {
            _cmdStr = FileHelper.GetSQLString("CreateSigner");

            try
            {
                _conn.Open();
                _command = new OracleCommand(_cmdStr, _conn);
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
    }
}
