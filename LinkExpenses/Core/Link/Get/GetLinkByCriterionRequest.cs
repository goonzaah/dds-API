using Core.Link.Get.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Core.Link.Get
{
    public class GetLinkByCriterionRequest : IRequest<TransaccionesModel>
    {

    }
}
