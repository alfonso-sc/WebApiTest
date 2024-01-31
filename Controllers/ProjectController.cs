using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTest.EntityModels;

namespace WebApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private BillingTimeContext billingTimeContext;
        public ProjectController(BillingTimeContext _billingTimeContext)
        {
            billingTimeContext = _billingTimeContext;
        }

        [HttpGet("List")]
        public ActionResult List()
        {
            return Ok(
                billingTimeContext
                .Projects
                .Include(p => p.Company)
                .Include(p => p.Entries)
            );
        }
    }
}