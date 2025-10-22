using APIverso.Domain.Exceptions;

namespace APIverso.Api.GraphQL.ActionsFilter
{
    public class GraphQLErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (error.Exception is DomainFailureException ex)
                return ErrorBuilder
                    .New()
                    .SetMessage(ex.Failure.Title)
                    .SetCode(ex.Failure.Type.ToString())
                    .Build();

            return error;
        }
    }
}