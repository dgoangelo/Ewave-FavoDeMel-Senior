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
    public class ComandaFinder : FinderSql, IComandaFinder
    {
        public ComandaFinder(IFavoDeMelConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        private string SQL_RETORNA_Comanda = @"
SELECT
    *
FROM
    Comanda
WHERE
    1=1
";

        private string Where_ID_COMANDA = " AND IDComanda = @idComanda";

        public async Task<ComandaDto> ObterComanda(Guid id)
        {
            using (var cnn = ConnectionFactory.CreateManaged())
            {
                var comanda = await cnn.QueryFirstOrDefaultAsync<ComandaDto>(SQL_RETORNA_Comanda + Where_ID_COMANDA, new { idComanda = id });
                return comanda;
            }
        }

        public async Task<IEnumerable<ComandaDto>> ObterComanda()
        {
            using (var cnn = ConnectionFactory.CreateManaged())
            {
                var comanda = await cnn.QueryAsync<ComandaDto>(SQL_RETORNA_Comanda);
                return comanda;
            }
        }
    }
}