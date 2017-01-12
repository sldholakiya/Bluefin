using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Mvc;
using WebApi.Helper;

namespace WebApi.Controllers
{
    [EnableCors(origins: "http://localhost:56060", headers: "*", methods: "*")]
    public class AssessmentController : ApiController
    {
        [ResponseType(typeof(string))]
        [System.Web.Http.HttpGet]
        public IHttpActionResult ReverseWords(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
                return Ok(string.Empty);

            string result = new ReverseWordHelpter().ReverseWords(inputString);

            return Ok(result);
        }


        [ResponseType(typeof(string))]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Triangle(int a, int b, int c)
        {
            var triangle = new TriangleHelper().ClassifyTriangleType(a,b,c);
            return Ok(triangle.ToString());
        }

        [ResponseType(typeof(string))]
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetElement()
        {
            var element = new LinkedListHelper().FifithElement();
            return Ok(element.ToString());
        }
    }
}