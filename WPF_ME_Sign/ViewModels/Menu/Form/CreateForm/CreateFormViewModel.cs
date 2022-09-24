using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ME_Sign.Models;
using WPF_ME_Sign.Models.Helpers;
using WPF_ME_Sign.Models.Services.Menu.Form;

namespace WPF_ME_Sign.ViewModels.Menu.Form.CreateForm
{
    public partial class CreateFormViewModel : BaseViewModel
    {
        public CreateFormViewModel()
        {
            CreateDate = DateTime.Now.ToString("dd/MM/yyyy");
            FormUserId = InfoHelper.UserId;
            FormUserName = InfoHelper.UserName;
            _CreateDate = DateTime.Now.ToString("ddMMyyyy");
            _fileDialog = new OpenFileDialog();
            _fileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            _fileDialog.FilterIndex = 1;
            _fileDialog.Multiselect = false;
            _createFormService = new CreateFormService();
            _querySignService = new QuerySignService();
            CreateFormCommand = new RelayCommand(CreateFormExecute);
            DeptList = _createFormService.LoadDeptList();
        }

        private FormModel GetFormValues()
        {
            return new FormModel()
            {
                SignId = SignId,
                DeptId = DeptId,
                DeptName = DeptList.SingleOrDefault(x => x.DeptId == DeptId).DeptName,
                FormUserId = FormUserId,
                FormUserName = FormUserName,
                Line = Line,
                ProjectTitle = ProjectTitle,
                Score = Score,
                Model = Model,
                Article = Article,
                Processing = Processing,
                DescribeProblem = DescribeProblem,
                ImproveProblem = ImproveProblem,
                DesctibePicturePath = ReportHelper.CopyImageToServer(SignId, DesctibePicturePath, "D"),
                ImprovePicturePath = ReportHelper.CopyImageToServer(SignId, ImprovePicturePath, "I"),
                Manpower_A = Manpower_A,
                CT_A = CT_A,
                EFF_A = EFF_A,
                Material_A = Material_A,
                Manpower_B = Manpower_B,
                CT_B = CT_B,
                EFF_B = EFF_B,
                Material_B = Material_B,
                CreateUserId = FormUserId,
                CreateDate = _CreateDate
            };
        }

        private bool DetectFieldEmpty()
        {
            return ValidateHelper.DetectFieldEmpty
            (
                SignId,
                DeptId,
                Line,
                ProjectTitle,
                FormUserId,
                Score,
                Model,
                Article,
                Processing,
                DescribeProblem,
                ImproveProblem,
                DesctibePicturePath,
                ImprovePicturePath, 
                Manpower_A,
                CT_A,
                EFF_A,
                Material_A,
                Manpower_B,
                CT_B,
                EFF_B,
                Material_B
            );
        }

        
    }
}
