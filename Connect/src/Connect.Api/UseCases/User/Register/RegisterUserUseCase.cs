
using Connect.Api.Infrastructure;
using Connect.Communication.Requests;
using Connect.Communication.Responses;
using Connect.Exception;

namespace Connect.Api.UseCases.User.Register;

public class RegisterUserUseCase
{
    public ResponseRegisteredUserJson Execute(RequestUserJson request)
    {

        Validate(request);

        var entity = new Domain.Entities.User
        {
            Name = request.Name,
            Email = request.Email,
            Password = request.Password
        };
        var DbContext = new TechLibraryDbContext();

        DbContext.Users.Add(entity);
        DbContext.SaveChanges();

        return new ResponseRegisteredUserJson
        {
            Name = entity.Name
        };

    }

    private void Validate(RequestUserJson request)
    {
        var validator = new RegisterUserValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
