namespace Muleki.Common.Communication
{
    public class DataResponse
    {
        public static object Error(object? data, string? message = null)
        {
            return Response(data, false, message ?? "Erro ao tentar realizar operação");
        }

        public static object AuthorizationError(object? data, string? message = null)
        {
            return Response(data, false, message ?? "Não Autorizado");
        }

        public static object Success(object? data, string? message = null)
        {
            return Response(data, true, message ?? "Operação realizada com sucesso");
        }

        private static object Response(object? data, bool success, string message)
        {
            return new
            {
                Message = message,
                Success = success,
                Data = data
            };
        }
    }
}