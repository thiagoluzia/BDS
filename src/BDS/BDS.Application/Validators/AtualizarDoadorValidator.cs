using BDS.Application.CQRS.Commands.Doadores.Atualizar;
using FluentValidation;

namespace BDS.Application.Validators
{
    public class AtualizarDoadorValidator : AbstractValidator<AtualizarDoador>
    {
        public AtualizarDoadorValidator()
        {

            RuleFor(i => i.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemValidator(nameof(AtualizarDoador.Id)));


            RuleFor(i => i.Id).Must(ValidatorMethods.GuidValido)
                .WithMessage("Identificador invalido");

            RuleFor(n => n.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemValidator(nameof(AtualizarDoador.Nome)))
                .Length(10, 200)
                .WithMessage("O nome deve conter entre 10 e 200 caracteres.");

            RuleFor(e => e.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemValidator(nameof(AtualizarDoador.Email)));

            RuleFor(g => g.Genero)
              .NotEmpty()
              .NotNull()
              .WithMessage(ValidatorMethods.MensagemValidator(nameof(AtualizarDoador.Genero)))
              .IsInEnum()
              .WithMessage("Genero é invalido.");

            RuleFor(p => p.Peso)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemValidator(nameof(AtualizarDoador.Peso)));

            RuleFor(e => e.Endereco)
                .Empty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemValidator(nameof(AtualizarDoador.Endereco)));
        }
    }
}
