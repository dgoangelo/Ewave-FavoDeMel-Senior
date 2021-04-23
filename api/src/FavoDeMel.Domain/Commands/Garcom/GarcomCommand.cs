using System;
using FavoDeMel.Domain.Core.Commands;

namespace FavoDeMel.Domain.Commands.Garcom
{
    public abstract class GarcomCommand : Command
    {
        public Guid IDGarcom { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
    }
}