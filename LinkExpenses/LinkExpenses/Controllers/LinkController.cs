using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LinkExpenses.Get.LinkGenerate;
using LinkExpenses.Get.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Presentation.API.V1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LinkController : Controller
    {
        
        [HttpGet("generateLink")]
        public ActionResult SaveRescue([FromBody] TransactionsModel request)
        {
            var generator = LinkAlgorithmSelectorService.GetLinkingGenerator(request.Criterio);
            var response = generator.LinkingTransactions(request);
            
            return Ok(response);
        }
    }
}