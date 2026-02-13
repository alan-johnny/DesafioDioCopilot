namespace CreditCardValidator.Models;

public class CardValidationResult
{
    public string Brand { get; set; } = "Desconhecida";
    public bool IsValid { get; set; }
    public string? ErrorMessage { get; set; }
}
