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
    public class PedidoFinder : FinderSql, IPedidoFinder
    {
        public PedidoFinder(IFavoDeMelConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        private string SQL_RETORNA_PEDIDOS = @"
select
    *
from
    Pedido
WHERE
    1=1
";

        private string Where_ID_PEDIDO = " AND IDPedido = @idPedido";

        public async Task<IEnumerable<PedidoDto>> ObterPedidos()
        {
            using (var cnn = ConnectionFactory.CreateManaged())
            {
                return await cnn.QueryAsync<PedidoDto>(SQL_RETORNA_PEDIDOS);
            }
        }

        public async Task<PedidoDto> ObterPedido(Guid id)
        {
            using (var cnn = ConnectionFactory.CreateManaged())
            {
                return await cnn.QueryFirstOrDefaultAsync<PedidoDto>(SQL_RETORNA_PEDIDOS + Where_ID_PEDIDO, new { idPedido = id });
            }
        }
    }
}