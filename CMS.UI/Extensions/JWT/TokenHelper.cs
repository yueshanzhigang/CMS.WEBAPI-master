using CMS.Common;
using CMS.IServices.System;
using CMS.Models.JWT;
using CMS.Models.ViewModel.SystemViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CMS.UI.JWT
{
    public class TokenHelper : ITokenHelper
    {
        private IOptions<JWTConfig> _options;
        private ISysModuleService _sysModuleService;
        private readonly CMSConstant _cMSConstant;
        private AESHelper _aESHelper;
        public TokenHelper(IOptions<JWTConfig> options, ISysModuleService sysModuleService, CMSConstant cMSConstant,AESHelper aESHelper)
        {
            _options = options;
            _sysModuleService = sysModuleService;
            _cMSConstant = cMSConstant;
            _aESHelper = aESHelper;
        }

        public Token CreateToken(SysLoginInfo user)
        {
            Claim[] claims = { new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()), new Claim(ClaimTypes.Role, user.RoleID.ToString()),new Claim(ClaimTypes.Name,user.UserName) };

            return CreateToken(claims,user);
        }
        private Token CreateToken(Claim[] claims, SysLoginInfo user)
        {
            var _roleID = claims.First(x => x.Type == ClaimTypes.Role).Value;
            var BroadcastKey = string.Empty;
            if (_sysModuleService.GetModulesByRoleID(_roleID).Where(x=>x.ModuleTitle== _cMSConstant.Broadcast).Count()>0)
            {
                BroadcastKey = _aESHelper.Encrypt(user.UserID);
            }
            var now = DateTime.Now; 
            var expires = now.Add(TimeSpan.FromMinutes(_options.Value.AccessTokenExpiresMinutes));
            var token = new JwtSecurityToken(
                issuer: _options.Value.Issuer,    //Token发布者
                audience: _options.Value.Audience,//Token接受者
                claims: claims,
                notBefore: now,
                expires: expires,                 //过期时间
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.IssuerSigningKey)),
                SecurityAlgorithms.HmacSha256));
            return new Token { TokenContent = new JwtSecurityTokenHandler().WriteToken(token), Expires = expires, BroadcastKey = BroadcastKey };
        }
    }
}
