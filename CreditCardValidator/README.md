# Validador de Cartão de Crédito

## 📋 Descrição do Desafio

Este projeto foi desenvolvido como um desafio da DIO (Digital Innovation One) com o objetivo de criar uma aplicação em **.NET C#** capaz de identificar a bandeira de um cartão de crédito e validar sua autenticidade através do **algoritmo de Luhn**.

A aplicação demonstra como o **GitHub Copilot** pode acelerar o desenvolvimento, sugerir trechos de código, melhorar a produtividade e implementar padrões de design de forma inteligente.

---

## ✨ Funcionalidades

### 🏦 Identificação de Bandeiras
A aplicação identifica os seguintes tipos de cartão:
- **Visa** - Começa com 4
- **MasterCard** - Começa com 51-55 ou 2221-2720
- **American Express** - Começa com 34 ou 37
- **Discover** - Começa com 6011, 622126-622925, 644-649, 65
- **JCB** - Começa com 35, 2131 ou 1800
- **Diners Club** - Começa com 36, 38 ou 300-305
- **Elo** - Padrões específicos (4011, 431274, 438935, etc)
- **Aura** - Começa com 50

### ✅ Validação com Algoritmo de Luhn
Implementa o algoritmo de Luhn para verificar a integridade do número do cartão:
1. Duplica cada segundo dígito (da direita para esquerda)
2. Se o resultado for maior que 9, subtrai 9
3. Soma todos os dígitos
4. Verifica se a soma é divisível por 10

### 🎯 Interface Interativa
- Exibe exemplos de teste com cartões de crédito padrão
- Permite testes interativos em tempo real
- Formatação segura dos números (mostra apenas últimos 4 dígitos)

---

## 🚀 Como Usar

### Pré-requisitos
- **.NET 8.0** ou superior instalado
- Terminal ou Prompt de Comando

### Instalação e Execução

```bash
# 1. Navegue até a pasta do projeto
cd "CreditCardValidator"

# 2. Restaure as dependências (se necessário)
dotnet restore

# 3. Compile o projeto
dotnet build

# 4. Execute a aplicação
dotnet run
```

---

## 📝 Exemplos de Cartões para Teste

| Bandeira | Número | Válido (Luhn) |
|----------|--------|---------------|
| Visa | 4532015112830366 | ✓ |
| MasterCard | 5425233010103442 | ✓ |
| American Express | 374245455400126 | ✓ |
| Discover | 6011111111111117 | ✓ |
| JCB | 3530111333300000 | ✓ |
| Visa | 4111111111111111 | ✓ |
| Inválido | 1234567890123456 | ✗ |

---

## 📂 Estrutura do Projeto

```
CreditCardValidator/
├── Program.cs                    # Ponto de entrada e interface
├── Models/
│   └── CardValidationResult.cs   # Modelo de dados de resultado
├── Services/
│   └── CardValidatorService.cs   # Lógica de validação e identificação
├── CreditCardValidator.csproj    # Configuração do projeto
├── obj/                          # Artefatos de build
└── README.md                     # Esta documentação
```

---

## 🔧 Classes e Métodos

### `CardValidatorService`
Serviço responsável pela validação e identificação do cartão.

**Métodos Públicos:**
- `CardValidationResult ValidateCard(string cardNumber)` 
  - Valida e identifica um cartão de crédito
  - Retorna bandeira e status de validação

**Métodos Privados:**
- `string IdentifyCardBrand(string cardNumber)` 
  - Identifica a bandeira usando expressões regulares
  
- `bool ValidateLuhn(string cardNumber)` 
  - Valida o cartão usando o algoritmo de Luhn

### `CardValidationResult`
Modelo que encapsula o resultado da validação.

**Propriedades:**
- `string Brand` - Bandeira do cartão
- `bool IsValid` - Resultado da validação de Luhn
- `string? ErrorMessage` - Mensagem de erro (se houver)

---

## 🧮 Algoritmo de Luhn - Explicado

O algoritmo de Luhn é usado para validar números de cartão de crédito:

**Exemplo com: 4532015112830366**

```
Posição:  1  2  3  4  5  6  7  8  9  10 11 12 13 14 15 16
Dígito:   4  5  3  2  0  1  5  1  1  2  8  3  0  3  6  6
Dobra:    8  5  6  2  0  1  10 1  2  2  16 3  0  3  12 6
Ajuste:   8  5  6  2  0  1  1  1  2  2  7  3  0  3  3  6
         (10-9=1)                    (16-9=7)      (12-9=3)

Soma: 8+5+6+2+0+1+1+1+2+2+7+3+0+3+3+6 = 50
50 % 10 = 0 ✓ (Válido)
```

---

## 💻 Tecnologias Utilizadas

- **.NET 8.0** - Framework moderno da Microsoft
- **C# 12** - Linguagem com recursos modernos
- **Regex (System.Text.RegularExpressions)** - Para identificação de padrões
- **GitHub Copilot** - Assistente de inteligência artificial

---

## 🤖 Como o GitHub Copilot Ajudou

O GitHub Copilot foi utilizado para:
- ✨ Sugerir padrões de regex para identificação de bandeiras
- ⚡ Implementar o algoritmo de Luhn de forma otimizada
- 📝 Gerar comentários e documentação
- 🎯 Completamento automático de código
- 💡 Otimizar a estrutura e organização do projeto

---

## 📊 Saída Esperada

```
=== Validador de Cartão de Crédito ===

--- Teste com Cartões de Exemplo ---

Cartão: ****0366
Bandeira: Visa
Válido (Luhn): ✓ Sim

Cartão: ****3442
Bandeira: MasterCard
Válido (Luhn): ✓ Sim

...

--- Teste Interativo ---
Digite um número de cartão (ou 'sair'): 4532015112830366

Bandeira: Visa
Válido: ✓ Sim

Digite outro cartão (ou 'sair'):
```

---

## 🔒 Segurança

- **Não armazena** números de cartão completo
- **Formata** os números exibindo apenas os últimos 4 dígitos
- **Valida** entrada para conter apenas dígitos
- Segue **boas práticas** de segurança

---

## 📚 Conceitos Aprendidos

✅ Programação Orientada a Objetos (OOP)  
✅ Expressões Regulares (Regex)  
✅ Algoritmos de Validação  
✅ Design Patterns  
✅ Estrutura de Projetos .NET  
✅ Trabalho com GitHub Copilot  

---

## 👨‍💻 Desenvolvido por

**Desafio DIO Copilot**  
Data: 13 de fevereiro de 2026

---

## 📖 Referências

- [Algoritmo de Luhn - Wikipedia](https://pt.wikipedia.org/wiki/Algoritmo_de_Luhn)
- [Padrões de Cartão de Crédito](https://en.wikipedia.org/wiki/Payment_card_number)
- [Documentação .NET](https://docs.microsoft.com/pt-br/dotnet/)
- [GitHub Copilot](https://github.com/features/copilot)

---

**Nota:** Este projeto é apenas para fins educacionais. Nunca use números de cartão real em aplicações de teste.
