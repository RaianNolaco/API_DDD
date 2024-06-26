﻿using System.IdentityModel.Tokens.Jwt;

namespace WebAPIs.Token
{

    public class TokenJWT
    {
        private JwtSecurityToken _token;

        internal TokenJWT(JwtSecurityToken token)
        {
            _token = token;
        }

        public DateTime validTo => _token.ValidTo;

        public string value => new JwtSecurityTokenHandler().WriteToken(_token);
    }
}
