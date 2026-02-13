using CreditCardValidator.Models;
using CreditCardValidator.Services;

var validatorService = new CardValidatorService();

Console.WriteLine("=== Validador de Cartão de Crédito ===\n");

// Exemplos de teste
var testCards = new[]
{
    "4532015112830366",      // Visa
    "5425233010103442",      // MasterCard
    "374245455400126",       // American Express
    "6011111111111117",      // Discover
    "3530111333300000",      // JCB
    "4111111111111111",      // Visa (válido Luhn)
    "1234567890123456"       // Inválido
};

Console.WriteLine("--- Teste com Cartões de Exemplo ---\n");
foreach (var cardNumber in testCards)
{
    var result = validatorService.ValidateCard(cardNumber);
    
    Console.WriteLine($"Cartão: {FormatCardNumber(cardNumber)}");
    Console.WriteLine($"Bandeira: {result.Brand}");
    Console.WriteLine($"Válido (Luhn): {(result.IsValid ? "✓ Sim" : "✗ Não")}");
    Console.WriteLine();
}

Console.WriteLine("\n--- Teste Interativo ---");
Console.Write("Digite um número de cartão (ou 'sair'): ");
string? input = Console.ReadLine();

while (input?.ToLower() != "sair" && !string.IsNullOrEmpty(input))
{
    var result = validatorService.ValidateCard(input);
    Console.WriteLine($"\nBandeira: {result.Brand}");
    Console.WriteLine($"Válido: {(result.IsValid ? "✓ Sim" : "✗ Não")}");
    
    Console.Write("\nDigite outro cartão (ou 'sair'): ");
    input = Console.ReadLine();
}

static string FormatCardNumber(string cardNumber)
{
    if (cardNumber.Length < 4) return cardNumber;
    return $"****{cardNumber.Substring(cardNumber.Length - 4)}";
}
