namespace NXCare.Domain.Enums
{
    public enum PatientCreationResults
    {
        Success = 0,
        Error = -1
    }

    public enum PatientDeletionResult
    {
        Success = 0,
        Error = -1,
        DoesNotExist = -2,

    }
}
