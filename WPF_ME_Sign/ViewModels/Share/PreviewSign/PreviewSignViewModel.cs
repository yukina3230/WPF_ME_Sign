using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ME_Sign.Models;
using WPF_ME_Sign.Models.Helpers;
using WPF_ME_Sign.Models.Services.Share;

namespace WPF_ME_Sign.ViewModels.Share.PreviewSign
{
    public partial class PreviewSignViewModel
    {
        private PreviewSignService _previewSignService;

        public PreviewSignViewModel(string signId)
        {
            _previewSignService = new PreviewSignService();
            SignPreview = new SignPreviewModel();
            SignPreview = _previewSignService.GetPreview(signId);
        }
    }
}
