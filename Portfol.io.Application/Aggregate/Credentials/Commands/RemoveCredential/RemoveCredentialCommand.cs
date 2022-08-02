﻿using MediatR;

namespace Portfol.io.Application.Aggregate.Credentials.Commands.RemoveCredential
{
    public class RemoveCredentialCommand : IRequest<Unit>
    {
        public string Username { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
    }
}
