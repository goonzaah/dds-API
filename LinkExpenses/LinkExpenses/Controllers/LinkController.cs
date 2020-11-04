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
            var pendingEntries = request.Ingresos;

            foreach (var criterio in request.Criterio)
            {
                var generator = LinkAlgorithmSelectorService.GetLinkingGenerator(criterio);
                var linkProcessed = generator.LinkingTransactions(pendingEntries, pendingEgresses);

                if (MappingHelper.IsEgressOrder[criterio])
                    response.VinculosEgreso.AddRange(linkProcessed?.Links);
                else
                    response.VinculosIngreso.AddRange(linkProcessed?.Links);

                pendingEgresses = linkProcessed?.PendingEgresses;
                pendingEntries = linkProcessed?.PendingEntries;
            }
            
            return response;
        }
    }
}