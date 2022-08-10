﻿using FluentValidation;

namespace Portfol.io.Application.Common.Services.SendVerifyCode
{
    public class SendVerifyCodeCommandValidator : AbstractValidator<SendVerifyCodeCommand>
    {
        public SendVerifyCodeCommandValidator()
        {
            RuleFor(sendVerifyCodeCommand => sendVerifyCodeCommand.Model.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Doesn't match the email format.");

            RuleFor(sendVerifyCodeCommand => sendVerifyCodeCommand.Model.MessageText)
                .NotEmpty().WithMessage("MessageText is required.");

            RuleFor(sendVerifyCodeCommand => sendVerifyCodeCommand.Model.MessageSubject)
                .NotEmpty().WithMessage("MessageSubject is required.");
        }
    }
}