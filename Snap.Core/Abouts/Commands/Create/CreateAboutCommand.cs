using MediatR;
using Snap.Core.Common;
using Snap.Core.DTOs;
using Snap.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Core.About.Commands.Create
{
    public class CreateAboutCommand : IRequest<Response<string>>
    {
        public AboutDto About { get; set; }






    }
}
