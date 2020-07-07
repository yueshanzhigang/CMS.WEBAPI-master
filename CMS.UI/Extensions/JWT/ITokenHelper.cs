
using CMS.Models.JWT;
using CMS.Models.ViewModel.SystemViewModel;

namespace CMS.UI.JWT
{
    public interface ITokenHelper
    {
        Token CreateToken(SysLoginInfo user);
    }
}