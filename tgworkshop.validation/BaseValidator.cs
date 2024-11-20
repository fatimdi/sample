using FluentValidation;

namespace tgworkshop.validation;

public abstract class BaseValidator<TModel> : AbstractValidator<TModel> where TModel : class
{
    #region Ctor

    protected BaseValidator()
    {
        PostInitialize();
    }

    #endregion

    #region Utilities

    protected virtual void PostInitialize()
    {
    }


    #endregion
}
