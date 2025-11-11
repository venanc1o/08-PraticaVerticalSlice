////using System.Threading.Tasks;
////using Microsoft.EntityFrameworkCore;
////using AprendizadoVerticalSlice.Infraestrutura;
////using AprendizadoVerticalSlice.Funcionalidades.Categorias;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Routing;
//using AprendizadoVerticalSlice.Infraestrutura;


//namespace AprendizadoVerticalSlice.Funcionalidades.Categorias.ObterCategoriaPorId
//{
//    /// <summary>
//    /// Handler responsável por buscar uma Categoria pelo Id.
//    /// Regras desta slice:
//    /// - Não lançar exceção quando não existir (retorna null)
//    /// - Não expor a entidade EF diretamente (usar record de resposta)
//    /// - Usar AsNoTracking para leitura
//    /// </summary>
//    public class ObterCategoriaPorIdHandler
//    {
//        private readonly BancoDeDados _db;

//        public ObterCategoriaPorIdHandler(BancoDeDados db)
//        {
//            _db = db;
//        }

//        public async Task<CategoriaResposta?> Executar(int id)
//        {
//            var categoria = await _db.Categorias
//                .AsNoTracking()
//                .FirstOrDefaultAsync(c => c.Id == id);

//            if (categoria is null) return null;

//            return new CategoriaResposta(
//                categoria.Id,
//                categoria.Nome,
//                categoria.Descricao
//            );
//        }
//    }

//    /// <summary>
//    /// Contrato de saída da slice.
//    /// </summary>
//    /// <param name="Id"></param>
//    /// <param name="Nome"></param>
//    /// <param name="Descricao"></param>
//    public record CategoriaResposta(int Id, string Nome, string? Descricao);
//}


using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // Essencial para AsNoTracking e FirstOrDefaultAsync
using AprendizadoVerticalSlice.Infraestrutura;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

// É provável que você precise desta using para a Entidade Categoria
// usando a abordagem de vertical slice (apenas um palpite)
// using AprendizadoVerticalSlice.Dominio.Entidades; 


namespace AprendizadoVerticalSlice.Funcionalidades.Categorias.ObterCategoriaPorId
{
    /// <summary>
    /// Handler responsável por buscar uma Categoria pelo Id.
    /// Regras desta slice:
    /// - Não lançar exceção quando não existir (retorna null)
    /// - Não expor a entidade EF diretamente (usar record de resposta)
    /// - Usar AsNoTracking para leitura
    /// </summary>
    public class ObterCategoriaPorIdHandler
    {
        private readonly BancoDeDados _db;

        public ObterCategoriaPorIdHandler(BancoDeDados db)
        {
            _db = db;
        }

        // O tipo de retorno deve ser Task<CategoriaResposta?> para permitir o retorno null
        public async Task<CategoriaResposta?> Executar(int id)
        {
            // Nota: Você pode precisar adicionar o DbSet<Categoria> aqui,
            // mas presumo que _db.Categorias esteja corretamente definido como DbSet<Categoria>.
            var categoria = await _db.Categorias
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (categoria is null) return null;

            return new CategoriaResposta(
                categoria.Id,
                categoria.Nome,
                categoria.Descricao
            );
        }
    }

    /// <summary>
    /// Contrato de saída da slice.
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Nome"></param>
    /// <param name="Descricao"></param>
    public record CategoriaResposta(int Id, string Nome, string? Descricao);

} // <-- Esta chave fecha o namespace AprendizadoVerticalSlice.Funcionalidades.Categorias.ObterCategoriaPorId