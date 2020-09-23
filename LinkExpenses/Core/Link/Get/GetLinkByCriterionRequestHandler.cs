using Core.Link.Get.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Link.Get
{
    public class GetLinkByCriterionRequestHandler : IRequestHandler<GetLinkByCriterionRequest, TransaccionesModel>
    {
        public GetLinkByCriterionRequestHandler()
        {
        }

        public async Task<TransaccionesModel> Handle(GetLinkByCriterionRequest request, CancellationToken cancellationToken)
        {
            return new TransaccionesModel();
        }
    }
}
