using FluentValidation;
using MongoBookStoreApp.Contracts.DTO;
using System.Text.RegularExpressions;

namespace MongoBookStoreApp.Core.Validators
{
    public class CreateOrUpdateBookDtoValidator : AbstractValidator<CreateOrUpdateBookDto>
    {
        public CreateOrUpdateBookDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Book Name is required");
            
            RuleFor(x => x.Description).NotEmpty().WithMessage("Provide a brief description about the book");
            
            RuleFor(x => x.ISBN)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("ISDN is required")
                .Must(x => x.Length == 13).WithMessage("Invalid ISBN provided")
                .Must(x => Regex.IsMatch(x, @"^\d$")).WithMessage("Invalid ISBN provided");
            
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required");
            
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Author name is required");
        }
    }
}
