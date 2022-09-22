using API_CRUD.Models;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace API_CRUD.Validator
{
  public class UserValidator : AbstractValidator<UserModel>
  {
    public UserValidator()
    {
      RuleFor(user => user.name)
        .NotEmpty().WithMessage("Campo nome não pode estar vazio")
        .Must(name =>
        {
          Regex regex = new Regex("[0-9]");
          return !regex.IsMatch(name);
        }).WithMessage("Campo não pode conter números");

      RuleFor(user => user.cpf)
        .NotEmpty().WithMessage("Campo cpf não pode estar vazio")
        .Must(cpf =>
          {
            Regex regex = new Regex("[a-zA-Z]");
            return !regex.IsMatch(cpf.ToString());
          }).WithMessage("Campo não pode conter letras")
          .Must(cpf =>
          {
            return cpf.ToString().Length == 11;
          }).WithMessage("Numero inválido de caracteres no CPF")
          .NotEqual(00000000000).WithMessage("CPF inválido");

      RuleFor(user => user.email)
        .NotEmpty().WithMessage("O campo email não pode ser vazio")
        .Must(email =>
        {
          return new EmailAddressAttribute().IsValid(email);
        }).WithMessage("Email não é valido");
    }
  }
}