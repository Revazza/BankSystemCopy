using IbanNet;
using IbanNet.Registry;


namespace InternetBank.Services;



public class IbanService
{
    public string GenerateIBan()
    {
        var generator = new IbanGenerator();
        var iban = generator.Generate("GE").ToString();
        return ValidateIban(iban) ? iban : "";
    }
    public bool ValidateIban(string iban)
    {
        var validator = new IbanValidator();
        var validationRes = validator.Validate(iban);
        return validationRes.IsValid;
    }
}