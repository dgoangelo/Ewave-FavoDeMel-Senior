using System;

namespace FavoDeMel.Domain.Core.RabbitMQ.Pedido
{
    public class MensagemCozinhaPedido
    {
        public Guid IDMensagem { get; set; }

        public string Mensagem { get; set; }
        public DateTime DataMensagem { get; set; }
    }
}