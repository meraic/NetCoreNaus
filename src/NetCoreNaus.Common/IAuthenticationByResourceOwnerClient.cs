using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreNaus.Common
{
    public interface IAuthenticationClientByResourceOwner : IDisposable
    {
        string AccessToken { get; set; }
        DateTime TokenExpiryUtc { get; set; }
        string TokenType { get; set; }
        List<string> Errors { get; set; }
        bool AuthFailed { get; set; }
        Task UsernamePasswordAsync(string apiId, string username, string password);
        Task UsernamePasswordAsync(string apiId, string username, string password, string tokenRequestEndpointUrl);
    }
}
