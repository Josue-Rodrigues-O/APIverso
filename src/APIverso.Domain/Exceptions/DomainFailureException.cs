using APIverso.Domain.Models;

namespace APIverso.Domain.Exceptions
{
    public class DomainFailureException(Failure failure) : Exception(failure.Title)
    {
        public Failure Failure { get; } = failure;
    }
}