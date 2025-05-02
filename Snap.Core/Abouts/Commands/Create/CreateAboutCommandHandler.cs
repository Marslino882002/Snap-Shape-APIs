using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Snap.Core.About.Commands.Create;
using Snap.Core.Common;
using Snap.Core.Constants;
using Snap.Core.Entities;
using Snap.Core.Entities.Enums;
using Snap.Core.Repositories;
using Snap.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Core.Abouts.Commands.Create
{
    public class CreateAboutCommandHandler(
        IAboutRepository _aboutRepo,
        IMapper _mapper,
        ICurrentUserService _currentUserService,
        ILogger<CreateAboutCommandHandler> _logger ,
         IHttpContextAccessor _httpContextAccessor ) : ResponseHandler, IRequestHandler<CreateAboutCommand, int>
    {
    
public async Task<int> Handle(CreateAboutCommand request, CancellationToken cancellationToken)
        {

          var about = new Entities.About
            {
                Age = request.Age,
                Tall = request.Tall,
                CurrentWeight = request.CurrentWeight,
                GoalWeight = request.GoalWeight,
                Gender = request.Gender,
                PreferrelFood = request.PreferrelFood,
                DailyMeals = request.DailyMeals,
                ChronicDiseases = request.ChronicDiseases,
                Goal = request.Goal,
              UserId = _currentUserService.GetUserId()

          };
            await _aboutRepo.AddAsync(about);
            return about.Id;

        }
    }
}
