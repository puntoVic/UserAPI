using Entities.Interfaces;

namespace Entities.Definitions
{
    public static class DefinitionHelper
    {
        public static IUser ToUser(this UserDefinition definition)
        {
            IUser newUser = definition?.Type.ToLower() switch
            {
                "normal" => new NormalUser(),
                "nuperUser" => new SuperUser(),
                "premium" => new PremiumUser(),
                _ => null,
            };
            if (newUser != null)
            {
                newUser.Name = definition.Name;
                newUser.Email = definition.Email;
                newUser.Address = definition.Address;
                newUser.Phone = definition.Phone;
                newUser.Type = definition.Type;
                newUser.Money = definition.Money;
            }
            return newUser ?? null;

        }
    }
}
