using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BigPandaHelper.Models;

namespace BigPandaHelper
{
    public class BigPandaDeployments
    {


        private readonly string _token;
        public BigPandaDeployments(string token)
        {
            _token = token;
        }

        public void Start(string product, string version, IEnumerable<string> hosts, string user, string source)
        {
            var baseAddress = "https://api.bigpanda.io/";
            var uri = "data/events/deployments/start";
            var client = new HttpClient();
            var deploymentRequest = new DeploymentStartRequest
            {
                component = product,
                hosts = hosts.ToList(),
                owner = user,
                source = source,
                version = version,
            };

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            client.BaseAddress = new Uri(baseAddress);

            var response = client.PostAsJsonAsync(uri, deploymentRequest).Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException(string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase));
            }
        }

        public void End(string product, string version, IEnumerable<string> hosts, string user, string source, Status status, string errorMessage)
        {
            var baseAddress = "https://api.bigpanda.io/";
            var uri = "data/events/deployments/end";
            var client = new HttpClient();
            var deploymentRequest = new DeploymentEndRequest
            {
                component = product,
                hosts = hosts.ToList(),
                owner = user,
                source = source,
                version = version,
                status = status==Status.Success?"success":"failure",
                errorMessage = errorMessage
            };

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            client.BaseAddress = new Uri(baseAddress);

            var response = client.PostAsJsonAsync(uri, deploymentRequest).Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException(string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase));
            }
        }

        public enum Status
        {
            Success,
            Failure
        }
    }
}
