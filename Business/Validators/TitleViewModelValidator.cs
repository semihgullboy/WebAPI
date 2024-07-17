using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Business.Validators
{
    public class TitleViewModelValidator : AbstractValidator<TitleViewModel>
    {
        public TitleViewModelValidator()
        {
            RuleFor(x => x.TitleName)
               .NotEmpty().WithMessage("Boş girilmez.")
               .Length(2, 50).WithMessage("Departman adı en az 2 karakter en fazla 50 karakter olmalı.");
        }
    }
}
