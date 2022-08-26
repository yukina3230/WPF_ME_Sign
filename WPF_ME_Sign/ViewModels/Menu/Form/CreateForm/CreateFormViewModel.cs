using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ME_Sign.Models;
using WPF_ME_Sign.Models.Helpers;
using WPF_ME_Sign.Models.Services.Menu.Form;

namespace WPF_ME_Sign.ViewModels.Menu.Form.CreateForm
{
    public partial class CreateFormViewModel
    {
        public CreateFormViewModel()
        {
            CreateDate = DateTime.Now.ToString("dd/MM/yyyy");
            _CreateDate = DateTime.Now.ToString("ddMMyyyy");
            _fileDialog = new OpenFileDialog();
            _fileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            _fileDialog.FilterIndex = 1;
            _fileDialog.Multiselect = false;
            AddDescribePictureCommand = new RelayCommand(AddDescribePath);
            AddImprovePictureCommand = new RelayCommand(AddImprovePath);
            CreateFormCommand = new RelayCommand(CreateFormExecute);
        }

        private FormModel GetFormValues()
        {
            return new FormModel()
            {
                SignId = SignId,
                DeptId = DeptId,
                FormUserId = FormUserId,
                Line = Line,
                ProjectTitle = ProjectTitle,
                Score = Score,
                Model = Model,
                Article = Article,
                Processing = Processing,
                DescribeProblem = DescribeProblem,
                ImproveProblem = ImproveProblem,
                DesctibePicturePath = DesctibePicturePath,
                ImprovePicturePath = ImprovePicturePath,
                CreateUserId = FormUserId,
                CreateDate = _CreateDate
            };
        }

        private KPIModel GetKPIValues()
        {
            return new KPIModel()
            {
                Manpower_A = Manpower_A,
                CT_A = CT_A,
                EFF_A = EFF_A,
                Material_A = Material_A,
                Manpower_B = Manpower_B,
                CT_B = CT_B,
                EFF_B = EFF_B,
                Material_B = Material_B,
            };
        }

        private SignModel GetSignValues()
        {
            return new SignModel()
            {
                UserId = FormUserId,
                SignDate = _CreateDate
            };
        }

        //private FormModel GetFormValues()
        //{
        //    return new FormModel()
        //    {
        //        SignId = "1",
        //        DeptId = "1",
        //        FormUserId = "1",
        //        Line = "1",
        //        ProjectTitle = "1",
        //        Score = "1",
        //        Model = "1",
        //        Article = "1",
        //        Processing = "1",
        //        DescribeProblem = "1",
        //        ImproveProblem = "1",
        //        DesctibePicturePath = "1",
        //        ImprovePicturePath = "1",
        //        CreateUserId = "1",
        //        CreateDate = _CreateDate
        //    };
        //}

        //private KPIModel GetKPIValues()
        //{
        //    return new KPIModel()
        //    {
        //        Manpower_A = "1",
        //        CT_A = "1",
        //        EFF_A = "1",
        //        Material_A = "1",
        //        Manpower_B = "1",
        //        CT_B = "1",
        //        EFF_B = "1",
        //        Material_B = "1",
        //    };
        //}

        //private SignModel GetSignValues()
        //{
        //    return new SignModel()
        //    {
        //        UserId = "1",
        //        SignDate = _CreateDate
        //    };
        //}

        private bool DetectFieldEmpty()
        {
            return ValidateHelper.DetectFieldEmpty(SignId, DeptId, Line, ProjectTitle, FormUserId, Score, Model, Article, Processing, DescribeProblem, ImproveProblem, DesctibePicturePath, ImprovePicturePath);
        }
    }
}
