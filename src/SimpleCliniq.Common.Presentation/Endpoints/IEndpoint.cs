using Microsoft.AspNetCore.Routing;

namespace Simple.Common.Presentation.Endpoints;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}
