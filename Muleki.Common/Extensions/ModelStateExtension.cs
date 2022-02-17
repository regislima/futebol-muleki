using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Muleki.Common.Extensions
{
    public static class ModelStateExtensions
    {
        public static string GetErrorMessage(this ModelStateDictionary dictionary)
        {
            return dictionary.SelectMany(m => m.Value.Errors)
                    .Select(m => m.ErrorMessage)
                    .First();
        }
    }
}