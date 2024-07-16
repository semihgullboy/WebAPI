using FluentValidation;
using ViewModel;

namespace Business.Validators
{
    public class PersonelViewModelValidator : AbstractValidator<PersonelViewModel>
    {
        public PersonelViewModelValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Boş girilmez.")
                .Length(2, 50).WithMessage("Personel adı en az 2 karakter en fazla 50 karakter olmalı.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Boş girilmez.")
                .Length(2, 50).WithMessage("Personel soyadı en az 2 karakter en fazla 50 karakter olmalı.");

            RuleFor(x => x.Gender).NotEmpty().WithMessage("Boş girilmez.");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Boş girilmez.")
                .Must(dateOfBirth => DateTime.Now.Year - dateOfBirth.Year >= 18)
                .WithMessage("Personel en az 18 yaşında olmalıdır.");

            //RuleFor(x => x.DepartmentID)
            //    .NotEmpty().WithMessage("Boş girilmez.")
            //    .GreaterThan(0).WithMessage("Geçersiz departman ID.");

            //RuleFor(x => x.TitleID)
            //    .NotEmpty().WithMessage("Boş girilmez.")
            //    .GreaterThan(0).WithMessage("Geçersiz title ID.");


        }
    }
}
