namespace BookMyHome.Domain.Shared;

public abstract record RecordWithValidation
{
    protected RecordWithValidation()
    {
        // ReSharper disable once VirtualMemberCallInConstructor
        Validate();
    }

    protected virtual void Validate()
    {
    }
}