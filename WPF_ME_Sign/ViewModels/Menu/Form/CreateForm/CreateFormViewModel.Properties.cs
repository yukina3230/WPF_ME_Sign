using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ME_Sign.Models;

namespace WPF_ME_Sign.ViewModels.Menu.Form.CreateForm
{
    public partial class CreateFormViewModel
    {
        private string _SignId;
        public string SignId { get => _SignId; set { _SignId = value; OnPropertyChanged(); } }

        private ObservableCollection<DeptModel> _DeptList;
        public ObservableCollection<DeptModel> DeptList { get => _DeptList; set { _DeptList = value; OnPropertyChanged(); } }

        private string _DeptId;
        public string DeptId { get => _DeptId; set { _DeptId = value; OnPropertyChanged(); } }

        private string _DeptName;
        public string DeptName { get => _DeptName; set { _DeptName = value; OnPropertyChanged(); } }

        private string _Line;
        public string Line { get => _Line; set { _Line = value; OnPropertyChanged(); } }

        private string _FormUserId; 
        public string FormUserId { get => _FormUserId; set { _FormUserId = value; OnPropertyChanged(); } }

        private string _FormUserName;
        public string FormUserName { get => _FormUserName; set { _FormUserName = value; OnPropertyChanged(); } }

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

        private string _DesctibePicturePath;
        public string DesctibePicturePath { get => _DesctibePicturePath; set { _DesctibePicturePath = value; OnPropertyChanged(); } }

        private string _ImprovePicturePath;
        public string ImprovePicturePath { get => _ImprovePicturePath; set { _ImprovePicturePath = value; OnPropertyChanged(); } }

        private string _DesctibePicturePathTemp;
        public string DesctibePicturePathTemp { get => _DesctibePicturePathTemp; set { _DesctibePicturePathTemp = value; OnPropertyChanged(); } }

        private string _ImprovePicturePathTemp;
        public string ImprovePicturePathTemp { get => _ImprovePicturePathTemp; set { _ImprovePicturePathTemp = value; OnPropertyChanged(); } }

        private string _CreateUserId;
        public string CreateUserId { get => _CreateUserId; set { _CreateUserId = value; OnPropertyChanged(); } }

        private string _Manpower_A;
        public string Manpower_A { get => _Manpower_A; set { _Manpower_A = value; OnPropertyChanged(); } }

        private string _CT_A;
        public string CT_A { get => _CT_A; set { _CT_A = value; OnPropertyChanged(); } }

        private string _EFF_A;
        public string EFF_A { get => _EFF_A; set { _EFF_A = value; OnPropertyChanged(); } }

        private string _Material_A;
        public string Material_A { get => _Material_A; set { _Material_A = value; OnPropertyChanged(); } }

        private string _Manpower_B;
        public string Manpower_B { get => _Manpower_B; set { _Manpower_B = value; OnPropertyChanged(); } }

        private string _CT_B;
        public string CT_B { get => _CT_B; set { _CT_B = value; OnPropertyChanged(); } }

        private string _EFF_B;
        public string EFF_B { get => _EFF_B; set { _EFF_B = value; OnPropertyChanged(); } }

        private string _Material_B;
        public string Material_B { get => _Material_B; set { _Material_B = value; OnPropertyChanged(); } }

        private string _CreateDate;
        public string CreateDate { get; set; }
    }
}
