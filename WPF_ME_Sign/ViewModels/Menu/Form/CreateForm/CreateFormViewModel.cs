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
    public partial class CreateFormViewModel
    {
        public CreateFormViewModel()
        {
            ClearTempFolder();

            CreateDate = DateTime.Now.ToString("dd/MM/yyyy");
            _CreateDate = DateTime.Now.ToString("ddMMyyyy");
            _fileDialog = new OpenFileDialog();
            _fileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            _fileDialog.FilterIndex = 1;
            _fileDialog.Multiselect = false;
            _createFormService = new CreateFormService();
            AddDescribePictureCommand = new RelayCommand(AddDescribePath);
            AddImprovePictureCommand = new RelayCommand(AddImprovePath);
            CreateFormCommand = new RelayCommand(CreateFormExecute);
            ExportCommand = new RelayCommand(ExportExecute);
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
                DesctibePicturePath = DesctibePicturePathTemp,
                ImprovePicturePath = ImprovePicturePathTemp,
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

        //private void Copy()
        //{
        //    string sourceFile = @"D:\Set.ini";
        //    string destinationFile = @"\\10.1.1.46\New folder (2)\New folder\Set.ini";
        //    try
        //    {
        //        File.Copy(sourceFile, destinationFile, true);
        //    }
        //    catch (IOException iox)
        //    {
        //        Console.WriteLine(iox.Message);
        //    }
        //}

        private string CopyTempImage(string sourceFile)
        {
            string destinationFile = FileHelper.GetTempPath(sourceFile);

            try
            {
                File.Copy(sourceFile, destinationFile, true);
                return destinationFile;
            }
            catch (IOException iox)
            {
                Console.WriteLine(iox.Message);
            }

            return "";
        }

        private void ClearTempFolder()
        {
            DirectoryInfo dInfo = new DirectoryInfo(FileHelper.GetTempPath(""));

            foreach (FileInfo file in dInfo.EnumerateFiles())
            {
                file.Delete();
            }
        }
    }
}
