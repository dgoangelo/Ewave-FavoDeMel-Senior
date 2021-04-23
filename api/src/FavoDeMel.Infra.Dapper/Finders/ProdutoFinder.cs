using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using FavoDeMel.Domain.Entities.Dto;
using FavoDeMel.Infra.Application.Interface;
using FavoDeMel.Infra.Application.Interface.Finders;
using FavoDeMel.Infra.Dapper.Abstractions;
using FavoDeMel.Infra.Dapper.ExtensionsMethods;

namespace FavoDeMel.Infra.Dapper.Finders
{
    public class ProdutoFinder : FinderSql, IProdutoFinder
    {
        public ProdutoFinder(IFavoDeMelConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        private string SQL_RETORNA_PRODUTOS = @"
SELECT
    IDProduto,
    Nome,
    Valor
FROM
    Produto
WHERE
    1=1 
";

        private string Where_IDPRODUTO = " AND IDProduto = @idProduto";



        public async Task<ProdutoDto> ObterProduto(Guid id)
        {
            using (var cnn = ConnectionFactory.CreateManaged())
            {
                var garcom = await cnn.QueryFirstOrDefaultAsync<ProdutoDto>(SQL_RETORNA_PRODUTOS + Where_IDPRODUTO, new { idProduto = id });
                return garcom;
            }
        }

        public async Task<IEnumerable<ProdutoDto>> ObterProdutos()
        {
            using (var cnn = ConnectionFactory.CreateManaged())
            {
                var produtos = await cnn.QueryAsync<ProdutoDto>(SQL_RETORNA_PRODUTOS);
                return produtos;
            }
        }
    }
}