using System.Security.Cryptography;

namespace Cleaning.Helpers
{
    public interface IValidationDictionary
    {
        void AddError(string key, string errorMessage);
        bool IsValid { get; }
    }
}
