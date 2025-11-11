using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using AprendizadoVerticalSlice.Infraestrutura;


namespace AprendizadoVerticalSlice.Funcionalidades.Categorias.ObterCategoriaPorId
{
    public static class ObterCategoriaPorIdEndpoint
    {
        /// <summary>
        /// Mapeia GET /api/categorias/{id:int}
        /// </summary>
        public static IEndpointRouteBuilder MapObterCategoriaPorId(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/api/categorias/{id:int}", async (
                [FromRoute] int id,
                [FromServices] ObterCategoriaPorIdHandler handler) =>
            {
                var resposta = await handler.Executar(id);
                return resposta is null
                    ? Results.NotFound(new { mensagem = "Categoria não encontrada." })
                    : Results.Ok(resposta);
            })
            .WithName("ObterCategoriaPorId")
            .WithTags("Categorias")
            .Produces<CategoriaResposta>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            return endpoints;
        }
    }
}
