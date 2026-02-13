using CreditCardValidator.Models;
using System.Text.RegularExpressions;

namespace CreditCardValidator.Services;

public class CardValidatorService
{
    /// <summary>
    /// Valida um cartão de crédito identificando a bandeira e aplicando o algoritmo de Luhn
    /// </summary>
    public CardValidationResult ValidateCard(string cardNumber)
    {
        var result = new CardValidationResult();

        // Remove espaços e caracteres especiais
        cardNumber = Regex.Replace(cardNumber, @"\s|-", string.Empty);

        // Verifica se contém apenas dígitos
        if (!Regex.IsMatch(cardNumber, @"^\d+$"))
        {
            result.ErrorMessage = "O cartão deve conter apenas dígitos";
            return result;
        }

        // Identifica a bandeira
        result.Brand = IdentifyCardBrand(cardNumber);

        // Valida o cartão usando o algoritmo de Luhn
        result.IsValid = ValidateLuhn(cardNumber);

        return result;
    }

    /// <summary>
    /// Identifica a bandeira do cartão baseado no padrão de números
    /// </summary>
    private string IdentifyCardBrand(string cardNumber)
    {
        return cardNumber switch
        {
            // Visa: começa com 4
            var n when Regex.IsMatch(n, @"^4[0-9]{12}(?:[0-9]{3})?$") => "Visa",

            // MasterCard: começa com 51-55 ou 2221-2720
            var n when Regex.IsMatch(n, @"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$") => "MasterCard",

            // American Express: começa com 34 ou 37
            var n when Regex.IsMatch(n, @"^3[47][0-9]{13}$") => "American Express",

            // Discover: começa com 6011, 622126-622925, 644, 645, 646, 647, 648, 649, 65
            var n when Regex.IsMatch(n, @"^6(?:011|5[0-9]{2}|4[4-9][0-9]|22(?:12[6-9]|1[3-9][0-9]|[2-8][0-9]{2}|9[01][0-9]|92[0-5]))[0-9]{12}$") => "Discover",

            // JCB: começa com 35
            var n when Regex.IsMatch(n, @"^(?:2131|1800|35\d{3})\d{11}$") => "JCB",

            // Diners Club: começa com 36, 38, 300-305
            var n when Regex.IsMatch(n, @"^3(?:0[0-5]|[68][0-9])[0-9]{11}$") => "Diners Club",

            // Elo: começa com 4011, 431274, 438935, 451416, 457393, 504706, 627780, 636297, 636368
            var n when Regex.IsMatch(n, @"^(4011|431274|438935|451416|457393|504706|627780|636297|636368)[0-9]{12}$") => "Elo",

            // Aura: começa com 50
            var n when Regex.IsMatch(n, @"^50[0-9]{14}$") => "Aura",

            _ => "Desconhecida"
        };
    }

    /// <summary>
    /// Valida um cartão usando o algoritmo de Luhn
    /// </summary>
    private bool ValidateLuhn(string cardNumber)
    {
        if (string.IsNullOrWhiteSpace(cardNumber) || cardNumber.Length < 13)
            return false;

        int sum = 0;
        int parity = cardNumber.Length % 2;

        for (int i = 0; i < cardNumber.Length; i++)
        {
            int digit = int.Parse(cardNumber[i].ToString());

            if (i % 2 == parity)
            {
                digit *= 2;
                if (digit > 9)
                    digit -= 9;
            }

            sum += digit;
        }

        return sum % 10 == 0;
    }
}
