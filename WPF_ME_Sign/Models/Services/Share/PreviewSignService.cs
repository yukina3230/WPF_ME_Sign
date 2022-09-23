using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ME_Sign.Models.Helpers;
using WPF_ME_Sign.Models.Repositories.Share;

namespace WPF_ME_Sign.Models.Services.Share
{
    public class PreviewSignService
    {
        private PreviewSignRepository _previewSignRepository;

        public PreviewSignService()
        {
            _previewSignRepository = new PreviewSignRepository();
        }

        public SignPreviewModel GetPreview(string signId)
        {
            SignPreviewModel result = _previewSignRepository.LoadPreviewForm(signId);

            List<SignerModel> signerList = _previewSignRepository.LoadSignerList(signId);

            foreach (var item in signerList)
            {
                result.RequestUserId = item.FormUserId;
                result.RequestUserName = item.FormUserName;
                result.RequestSignDate = item.FormSignDate;

                if (item.RoleId == "2" && item.UserId == item.FormUserId)
                {
                    result.DeptUserId = item.UserId;
                    result.DeptUserName = item.UserName;
                    result.DeptSignDate = item.SignDate;
                }

                switch (item.DeptName)
                {
                    case "QC":
                        result.QCUserId = item.UserId;
                        result.QCUserName = item.UserName;
                        result.QCSignDate = item.SignDate;
                        break;
                    case "Tech":
                        result.TechUserId = item.UserId;
                        result.TechUserName = item.UserName;
                        result.TechSignDate = item.SignDate;
                        break;
                    case "Production":
                        result.ProductionUserId = item.UserId;
                        result.ProductionUserName = item.UserName;
                        result.ProductionSignDate = item.SignDate;
                        break;
                    case "ME":
                        result.MEUserId = item.UserId;
                        result.MEUserName = item.UserName;
                        result.MESignDate = item.SignDate;
                        break;
                }
            }

            return result;
        }

        public bool SignCheck(string userId) => _previewSignRepository.CheckManagerUser(userId);
    }
}
