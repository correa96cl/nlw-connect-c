
using Connect.Api.Infrastructure;
using Connect.Api.Infrastructure.Security.Cryptography;
using Connect.Communication.Requests;
using Connect.Communication.Responses;
using Connect.Exception;
using FluentValidation.Results;

namespace Connect.Api.UseCases.User.Register;

public class RegisterUserUseCase
{
    public ResponseRegisteredUserJson Execute(RequestUserJson request)
    {
        var dbContext = new TechLibraryDbContext();


        Validate(request, dbContext);

        var cryptography = new BCryptAlogrithm();

        var entity = new Domain.Entities.User
        {
            Name = request.Name,
            Email = request.Email,
            Password = cryptography.HashPassword(request.Password)
        };

        dbContext.Users.Add(entity);
        dbContext.SaveChanges();

        return new ResponseRegisteredUserJson
        {
            Name = entity.Name
        };

    }

    private void Validate(RequestUserJson request, TechLibraryDbContext dbContext)
    {
        var validator = new RegisterUserValidator();
        var result = validator.Validate(request);

        var existUserWithEmail = dbContext.Users.Any(user => user.Email.Equals(request.Email));

        if (existUserWithEmail)
            result.Errors.Add(new ValidationFailure());

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
