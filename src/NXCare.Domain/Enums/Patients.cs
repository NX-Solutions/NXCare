namespace NXCare.Domain.Enums
{
    public enum PatientCreationResults
    {
        Error = -1,
        Created = 201,
        Updated = 204
    }

    public enum PatientDeletionResult
    {
        Success = 0,
        Error = -1,
        DoesNotExist = -2,
    }
}