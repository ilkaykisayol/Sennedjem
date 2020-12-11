﻿using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Entities.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Users.Queries
{
    public class GetUserLookupQuery : IRequest<IDataResult<IEnumerable<SelectionItem>>>
    {
        public class GetUserLookupQueryHandler : IRequestHandler<GetUserLookupQuery, IDataResult<IEnumerable<SelectionItem>>>
        {
            private readonly IUserRepository _userRepository;
            public GetUserLookupQueryHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }
            public async Task<IDataResult<IEnumerable<SelectionItem>>> Handle(GetUserLookupQuery request, CancellationToken cancellationToken)
            {
                var userLookup = _userRepository.GetList().Select(x => new SelectionItem()
                {
                    Id = x.UserId.ToString(),
                    Label = x.FullName
                });
                return new SuccessDataResult<IEnumerable<SelectionItem>>(userLookup);
            }
        }
    }
}
