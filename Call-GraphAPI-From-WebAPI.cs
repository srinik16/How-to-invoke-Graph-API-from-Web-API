using Azure.Identity;
using Microsoft.Graph;
using System.Collections.Generic;
using System.Web.Http;

namespace WebApiFW.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            var tenantId = "xxxxxxxxxxxxxxxxxxxx";
            var clientId = "xxxxxxxxxxxxxxxxxxxxxxxxxx";
            var clientSecret = "xxxxxxxxxxxxxxxxxxxxxxxxxxxx";

            var clientSecretCredential = new ClientSecretCredential(tenantId, clientId, clientSecret);
            GraphServiceClient graphServiceClient = new GraphServiceClient(clientSecretCredential);

            var users = graphServiceClient.Users.Request()
                .Select(x => x.DisplayName).GetAsync().Result;

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
