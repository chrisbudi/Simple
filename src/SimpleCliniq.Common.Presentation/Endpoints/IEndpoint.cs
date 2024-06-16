using Microsoft.AspNetCore.Routing;

namespace SimpleCliniq.Common.Presentation.Endpoints
{
    public interface IEndpoint
    {
        void MapEndPoint(IEndpointRouteBuilder builder);
    }
}
