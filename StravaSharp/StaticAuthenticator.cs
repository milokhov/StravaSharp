using RestSharp.Portable;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace StravaSharp
{
    public class StaticAuthenticator : IAuthenticator
    {
        public StaticAuthenticator(string accessToken)
        {
            AccessToken = accessToken;
        }

        public string AccessToken { get; }

        public bool CanHandleChallenge(IHttpClient client, IHttpRequestMessage request, ICredentials credentials, IHttpResponseMessage response)
        {
            return false;
        }

        public bool CanPreAuthenticate(IRestClient client, IRestRequest request, ICredentials credentials)
        {
            return true;
        }

        public bool CanPreAuthenticate(IHttpClient client, IHttpRequestMessage request, ICredentials credentials)
        {
            return true;
        }

        public Task HandleChallenge(IHttpClient client, IHttpRequestMessage request, ICredentials credentials, IHttpResponseMessage response)
        {
            throw new NotImplementedException();
        }

        public async Task PreAuthenticate(IRestClient client, IRestRequest request, ICredentials credentials)
        {
            request.AddHeader("Authorization", "Bearer " + AccessToken);
        }

        public async Task PreAuthenticate(IHttpClient client, IHttpRequestMessage request, ICredentials credentials)
        {
            request.Headers.Add("Authorization", "Bearer " + AccessToken);
        }
    }
}
