using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

public class MyApiController : ApiController
{
    [HttpGet]
    public MyApiResult GetHelloWorld()
    {
        return new MyApiResult { Data = "Muhammad Ali", Date = DateTime.Now };
    }
}
