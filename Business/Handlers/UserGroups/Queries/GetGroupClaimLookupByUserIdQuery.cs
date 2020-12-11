﻿using Business.BusinessAspects;
using Business.Handlers.OperationClaims.Queries;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Entities.Dtos;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.UserGroups.Queries
{
    [SecuredOperation]
    public class GetGroupClaimLookupByUserIdQuery : IRequest<IDataResult<IEnumerable<SelectionItem>>>
    {
        public int UserId { get; set; }
        public class GetGroupClaimLookupByUserIdQueryHandler : IRequestHandler<GetGroupClaimLookupByUserIdQuery, IDataResult<IEnumerable<SelectionItem>>>
        {
            private readonly IUserGroupRepository _groupClaimRepository;
            private readonly IMediator _mediator;

            public GetGroupClaimLookupByUserIdQueryHandler(IUserGroupRepository groupClaimRepository, IMediator mediator)
            {
                _groupClaimRepository = groupClaimRepository;
                _mediator = mediator;
            }

            public async Task<IDataResult<IEnumerable<SelectionItem>>> Handle(GetGroupClaimLookupByUserIdQuery request, CancellationToken cancellationToken)
            {
                var data = await _groupClaimRepository.GetUserGroupSelectedList(request.UserId);
                return new SuccessDataResult<IEnumerable<SelectionItem>>(data);
            }
        }
    }
}

