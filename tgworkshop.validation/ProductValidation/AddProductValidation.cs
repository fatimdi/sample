using FluentValidation;
using tgworkshop.models.ProductModels;

namespace tgworkshop.validation.ProductValidation;

public class AddProductValidation : BaseValidator<AddProductModel>
{
    public AddProductValidation()
    {
        CustomerId();
        Price();
        Stock();
        CategoryId();
    }

    public void CustomerId() => RuleFor(s => s.Name).NotEmpty().MaximumLength(500).WithMessage("Name is required and much be less than 500 character");
    public void Price() => RuleFor(s => s.Price).GreaterThan(0).WithMessage("Price must be greater than zero");
    public void Stock() => RuleFor(s => s.Stock).GreaterThan(0).WithMessage("Stock count must be greater than zero");
    public void CategoryId() => RuleFor(s => s.CategoryId).GreaterThan(0).WithMessage("Category must be select");
}
