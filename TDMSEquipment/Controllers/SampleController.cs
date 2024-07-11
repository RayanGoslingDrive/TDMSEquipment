using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tdms.Api;

namespace TDMSEquipment
{
    [Authorize]
    public class SampleController : ControllerBase
    {
        private readonly TDMSApplication ThisApplication;

        public SampleController(TDMSApplication application)
        {
            ThisApplication = application;
        }

        [Route("api/ext/sample/hello"), HttpGet]
        public string Test()
        {
            return "Hello, world";
        }
    }
}