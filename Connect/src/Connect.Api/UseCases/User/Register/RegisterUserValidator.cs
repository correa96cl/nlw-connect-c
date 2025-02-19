using System;
using System.Data;
using Connect.Communication.Requests;
using FluentValidation;

namespace Connect.Api.UseCases.User.Register;

public class RegisterUserValidator : AbstractValidator<RequestUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("o Email é obrigatório");
        RuleFor(x => x.Name).NotEmpty().WithMessage("O nome é obrigatório");
        RuleFor(x => x.Password).NotEmpty().WithMessage("A senha é obrigatória");
        When(x => string.IsNullOrEmpty(x.Password) == false, () => {
        RuleFor(x => x.Password.Length).GreaterThanOrEqualTo(6).WithMessage("A senha deve ter no mínimo 6 caracteres");
        });
    }


}
