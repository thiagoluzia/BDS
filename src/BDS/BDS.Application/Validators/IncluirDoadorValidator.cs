using BDS.Application.CQRS.Commands.Doadores.Incluir;
using FluentValidation;

namespace BDS.Application.Validators
{
    public class IncluirDoadorValidator : AbstractValidator<IncluirDoador>
    {
        //TODO: Melhorar como evitar repetir codigo entre incluir e atualizar
        public IncluirDoadorValidator()
        {

            RuleFor(n => n.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemValidator(nameof(IncluirDoador.Nome)))
                .Length(10, 200)
                .WithMessage("O nome deve conter entre 10 e 200 caracteres.");

            RuleFor(e => e.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemValidator(nameof(IncluirDoador.Email)));

            RuleFor(d => d.DataNascimento)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemValidator(nameof(IncluirDoador.DataNascimento)));

            RuleFor(g => g.Genero)
              .NotEmpty()
              .NotNull()
              .WithMessage(ValidatorMethods.MensagemValidator(nameof(IncluirDoador.Genero)))
              .IsInEnum()
              .WithMessage("Genero é invalido.");

            RuleFor(p => p.Peso)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemValidator(nameof(IncluirDoador.Peso)));

            RuleFor(t => t.TipoSanquineo)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemValidator(nameof(IncluirDoador.TipoSanquineo)));

            RuleFor(f => f.Fator)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemValidator(nameof(IncluirDoador.Fator)));

            RuleFor(e => e.Endereco)
                .Empty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemValidator(nameof(IncluirDoador.Endereco)));
        }

    }
}
