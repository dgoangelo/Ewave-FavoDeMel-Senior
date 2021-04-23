#pragma warning disable 1591
namespace FavoDeMel.API.Utils
{
    public static class Endpoints
    {
        public static class Route
        {
            public const string POST = "";
            public const string PUT = "{id}";
            public const string DELETE = "{id}";
            public const string GET_BY_ID = "{id}";
            public const string GET_ALL = "";
        }

        public static class Recursos
        {
            public const string Garcom = "garcom";
            public const string Produto = "produto";
            public const string Comanda = "comanda";
            public const string Cozinhda = "cozinha";
            public const string Pedido = "pedido";
        }
    }
}