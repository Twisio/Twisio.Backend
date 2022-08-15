﻿using AutoMapper;
using Portfol.io.Application.Aggregate.Users.Queries.GetUserById;
using Portfol.io.Application.Common.Exceptions;
using Portfol.io.Persistence;
using Portfol.io.Tests.Common;
using Shouldly;
using Xunit;

namespace Portfol.io.Tests.Aggregate.Users.Queries
{
    [Collection(nameof(QueryCollection))]
    public class GetUserByIdQueryHandlerTest
    {
        private readonly PortfolioDbContext Context;
        private readonly IMapper Mapper;

        public GetUserByIdQueryHandlerTest(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetUserByIdQueryHandlerTest_Success()
        {
            //Arrange
            var handler = new GetUserByIdQueryHandler(Mapper, Context);
            var userId = PortfolioContextFactory.UserAId;

            //Act
            var result = await handler.Handle(
                new GetUserByIdQuery { Id = userId }, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<UserViewModel>();
            result.Id.ShouldBe(userId);
        }

        [Fact]
        public async Task GetUserByIdQueryHandlerTest_FailOnWrongUserId()
        {
            //Arrange
            var handler = new GetUserByIdQueryHandler(Mapper, Context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new GetUserByIdQuery { Id = Guid.NewGuid() }, CancellationToken.None);
            });
        }
    }
}