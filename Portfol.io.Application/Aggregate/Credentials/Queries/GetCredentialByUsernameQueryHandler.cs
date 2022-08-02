﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Application.Interfaces;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Credentials.Queries
{
    public class GetCredentialByUsernameQueryHandler : IRequestHandler<GetCredentialByUsernameQuery, CredentialUsernameVm>
    {
        private readonly IPortfolioDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCredentialByUsernameQueryHandler(IMapper mapper, IPortfolioDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<CredentialUsernameVm> Handle(GetCredentialByUsernameQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Credentials.FirstOrDefaultAsync(u => u.Username == request.Username, cancellationToken);

            if (entity == null || entity.Username != request.Username) throw new NotFoundException(nameof(Credential), request.Username);

            return _mapper.Map<CredentialUsernameVm>(entity);
        }
    }
}
