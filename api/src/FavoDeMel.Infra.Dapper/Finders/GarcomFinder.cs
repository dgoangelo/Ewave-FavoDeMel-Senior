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
    public class GarcomFinder : FinderSql, IGarcomFinder
    {
        public GarcomFinder(IFavoDeMelConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        private string SQL_RETORNA_Garcom = @"
SELECT
    IDGarcom,
    Nome,
    Cpf
FROM
    Garcom
WHERE
    1=1
";
        private string Where_IDGARCOM = " AND IDGarcom = @idGarcom";
        private string Where_CPF = "AND Cpf = @cpf";
        

        public async Task<GarcomDto> ObterGarcomPorId(Guid id)
        {
            using (var cnn = ConnectionFactory.CreateManaged())
            {
                var garcom = await cnn.QueryFirstOrDefaultAsync<GarcomDto>(SQL_RETORNA_Garcom + Where_IDGARCOM, new { idGarcom = id });
                return garcom;
            }
        }

        public async Task<GarcomDto> ObterGarcomPorCpf(string cpf)
        {
            using (var cnn = ConnectionFactory.CreateManaged())
            {
                var garcom = await cnn.QueryFirstOrDefaultAsync<GarcomDto>(SQL_RETORNA_Garcom + Where_CPF, new { cpf = cpf });
                return garcom;
            }
        }

        public async Task<IEnumerable<GarcomDto>> ObterGarcoms()
        {
            using (var cnn = ConnectionFactory.CreateManaged())
            {
                var garcoms = await cnn.QueryAsync<GarcomDto>(SQL_RETORNA_Garcom);
                return garcoms;
            }
        }
    }
}