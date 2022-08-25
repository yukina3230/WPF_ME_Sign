using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ME_Sign.ViewModels.Menu.Form.CreateForm
{
    public partial class CreateFormViewModel : ObservableObject
    {
        private string _SignId;
        public string SignId { get => _SignId; set { _SignId = value; OnPropertyChanged(); } }

        private string _DeptId;
        public string DeptId { get => _DeptId; set { _DeptId = value; OnPropertyChanged(); } }

        private string _DeptName;
        public string DeptName { get => _DeptName; set { _DeptName = value; OnPropertyChanged(); } }

        private string _Line;
        public string Line { get => _Line; set { _Line = value; OnPropertyChanged(); } }

        private string _FormUserId; 
        public string FormUserId { get => _FormUserId; set { _FormUserId = value; OnPropertyChanged(); } }

        private string _ProjectTitle;
        public string ProjectTitle { get => _ProjectTitle; set { _ProjectTitle = value; OnPropertyChanged(); } }

        private string _Score;
        public string Score { get => _Score; set { _Score = value; OnPropertyChanged(); } }

        private string _Model;
        public string Model { get => _Model; set { _Model = value; OnPropertyChanged(); } }

        private string _Article;
        public string Article { get => _Article; set { _Article = value; OnPropertyChanged(); } }

        private string _Processing;
        public string Processing { get => _Processing; set { _Processing = value; OnPropertyChanged(); } }

        private string _DescribeProblem;
        public string DescribeProblem { get => _DescribeProblem; set { _DescribeProblem = value; OnPropertyChanged(); } }

        private string _ImproveProblem;
        public string ImproveProblem { get => _ImproveProblem; set { _ImproveProblem = value; OnPropertyChanged(); } }

        private string _PictureDesctibePath;
        public string PictureDesctibePath { get => _PictureDesctibePath; set { _PictureDesctibePath = value; OnPropertyChanged(); } }

        private string _PictureImprovePath;
        public string PictureImprovePath { get => _PictureImprovePath; set { _PictureImprovePath = value; OnPropertyChanged(); } }

        private string _CreateUserId;
        public string CreateUserId { get => _CreateUserId; set { _CreateUserId = value; OnPropertyChanged(); } }

        public string CreateDate { get; set; }
    }
}
