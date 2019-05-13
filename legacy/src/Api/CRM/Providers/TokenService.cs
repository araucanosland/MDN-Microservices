using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using CRM.Security.Data;
using CRM.Security.Entity;
using Microsoft.Extensions.Configuration;

namespace CRM.Providers
{
    public class TokenService
    {
        /// <summary>
        ///  Function to generate unique token with expiry against the provided userId.
        ///  Also add a record in database for generated token.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Token GenerateToken(int userId)
        {
            string token = Guid.NewGuid().ToString();
            DateTime issuedOn = DateTime.Now;
            DateTime expiredOn = DateTime.Now.AddSeconds(9000);
            var tokendomain = new Token
            {
                UserId = userId,
                AuthToken = token,
                IssuedOn = issuedOn,
                ExpiresOn = expiredOn
            };

            TokenDataAccess.Insertar(tokendomain);

            var tokenModel = new Token()
            {
                UserId = userId,
                IssuedOn = issuedOn,
                ExpiresOn = expiredOn,
                AuthToken = token
            };

            return tokenModel;
        }


        /// <summary>
        /// Method to validate token against expiry and existence in database.
        /// </summary>
        /// <param name="tokenId"></param>
        /// <returns></returns>
        public bool ValidateToken(string tokenId)
        {
            Token token = TokenDataAccess.Obtener(tokenId).FirstOrDefault(x => x.ExpiresOn > DateTime.Now);
            if (token != null && !(DateTime.Now > token.ExpiresOn))
            {
                //token.ExpiresOn = DateTime.Now.AddSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
                //TokenDataAccess.Actualizar(token);
                return true;
            }
            return false;
        }


        /// <summary>
        /// Method to kill the provided token id.
        /// </summary>
        /// <param name="tokenId">true for successful delete</param>
        public bool Kill(string tokenId)
        {
            TokenDataAccess.Eliminar(tokenId);
            var isNotDeleted = TokenDataAccess.Obtener(tokenId).Any();
            if (isNotDeleted) { return false; }
            return true;
        }


        /// <summary>
        /// Delete tokens for the specific deleted user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>true for successful delete</returns>
        public bool DeleteByUserId(string userId)
        {
            TokenDataAccess.EliminarByUsuario(userId);
            var isNotDeleted = TokenDataAccess.Obtener(userId).Any();
            return !isNotDeleted;
        }

    }
}