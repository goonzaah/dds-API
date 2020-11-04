using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Shared.Helpers;
using LinkExpenses.Get.LinkGenerate;
using LinkExpenses.Get.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Presentation.API.V1.Controllers
{
    [ApiController]
    [Route("links")]
    public class LinkController : Controller
    {
        
        [HttpGet("generate")]
        public LinkedTransactions GenerateLink([FromBody] TransactionsModel request)
        {
            LinkedTransactions response = new LinkedTransactions()
            {
                VinculosEgreso = new List<Link>(),
                VinculosIngreso = new List<Link>()
            };

            var pendingEgresses = request.Egresos;
            var pendingEntrys = request.Ingresos;

            foreach (var criterio in request.Criterio)
            {
                var generator = LinkAlgorithmSelectorService.GetLinkingGenerator(criterio);
                var links = generator.LinkingTransactions(request);
                if (MappingHelper.IsEgressOrder[criterio])
                    response.VinculosEgreso.AddRange(links);
                else
                    response.VinculosIngreso.AddRange(links);
            }
            
            return response;
        }
    }
}