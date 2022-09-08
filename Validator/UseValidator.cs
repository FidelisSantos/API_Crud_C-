using API_CRUD.Models;
using System.Text.RegularExpressions;
using FluentValidation;

namespace API_CRUD.Validator
{
  public class UserValidator : AbstractValidator<UserModel>
  {
    public UserValidator()
    {
      RuleFor(user => user.name)
        .NotEmpty().WithMessage("Campo nome não pode estar vazio")
        .Must(x =>
        {
          Regex regex = new Regex("[0-9]");
          return !regex.IsMatch(x);
        }).WithMessage("Campo não pode conter números");

      RuleFor(user => user.cpf)
        .NotEmpty().WithMessage("Campo cpf não pode estar vazio")
        .Must(x =>
          {
            Regex regex = new Regex("[a-zA-Z]");
            return !regex.IsMatch(x.ToString());
          }).WithMessage("Campo não pode conter letras")
          .Must(x =>
          {
            return x.ToString().Length == 11;
          }).WithMessage("Numero inválido de caracteres no CPF")
          .NotEqual(00000000000).WithMessage("CPF inválido");

      RuleFor(user => user.email)
        .NotEmpty().WithMessage("O campo email não pode ser vazio")
        .Must(x =>
        {
          Regex regex = new Regex("@");
          return regex.IsMatch(x);
        }).WithMessage("Email não possui @");
    }
  }
}