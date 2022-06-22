/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using OutSystems.HubEdition.RuntimePlatform.Internal;
using OutSystems.ObjectKeys;
using OutSystems.RuntimeCommon;
using OutSystems.RuntimeCommon.Settings;

namespace OutSystems.HubEdition.RuntimePlatform.Internal {
    public class SecurityTokenManager {

        public static string GenerateAuthorizationHeader(ISettingsProvider settingsProvider, string issuer, string audience, int userId, int tenantId) {
            return $"Bearer {SecurityTokenAPI.GenerateJWTTokenString(settingsProvider, issuer, audience, userId, tenantId, new byte[1])}";
        }

        public static void ValidateAuthorizationHeader(ISettingsProvider settingsProvider, string token, int userId, int tenantId, string eSpaceKey) {

            var authHeaderParts = token?.Trim().Split(new[] { ' ' }, 2);
            if (authHeaderParts == null || authHeaderParts.Length != 2) {
                ThrowTokenValidationFailed("Invalid auth header parts");
            }

            var type = authHeaderParts[0];
            var credentials = authHeaderParts[1];

            if (!"bearer".EqualsIgnoreCase(type)) {
                ThrowTokenValidationFailed("Invalid type header");
            }

            SecurityTokenAPI.RequestSecurityTokenPayload payload = SecurityTokenAPI.GetValidatedToken<SecurityTokenAPI.RequestSecurityTokenPayload>(settingsProvider, credentials);
            if(payload == null) {
                ThrowTokenValidationFailed("Invalid payload");
            }
            if(userId != 0 && payload.UserId != userId) {
                ThrowTokenValidationFailed("Invalid userId");
            }
            if (tenantId != 0 && payload.TenantId != tenantId) {
                ThrowTokenValidationFailed("Invalid tenantId");
            }
            if(payload.ProducerKey != eSpaceKey) {
                ThrowTokenValidationFailed("Invalid eSpaceKey");
            }
        }

        private static void ThrowTokenValidationFailed(string context) {
            OSTrace.Debug("SecurityTokenManager validation failed: " + context);
            throw new Exception("Token validation failed");
        }
    }
}