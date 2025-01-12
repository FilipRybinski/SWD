using System.Net.Http;
using System.Web.Http;
using WebApplication2.Commands;
using WebApplication2.Utils;

namespace WebApplication2.Controllers
{
    [RoutePrefix("api/framework")]
    public class FrameworkController : ApiController
    {

        [HttpPost]
        [Route("result")]
        public IHttpActionResult Post([FromBody] FrameworkNetworkCommand command)
        {
            return Ok( FrameworkNetwork.CreateAndProcessNetwork(command));
        }

        [HttpOptions]
        public HttpResponseMessage Options()
        {
            var response = new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.OK };
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
            response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization");
            return response;
        }
    }
}
