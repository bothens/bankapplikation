using System;

namespace ConsoleApp2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
           
            Investeringskonto investeringskonto = new Investeringskonto(1500);
            Sparkonto sparkonto = new Sparkonto(10000);
            Personkonto personkonto = new Personkonto(20000);

            
           
            {
                Console.WriteLine("Hej välkommen till menyn! Vilket konto vill du gå in på?");
                Console.WriteLine("1 - Investeringskonto");
                Console.WriteLine("2 - Sparkonto");
                Console.WriteLine("3 - Personkonto");
               

                string selectedAccount = Console.ReadLine()!;

                switch (selectedAccount)
                {
                    case "1":
                        HanteraInvesteringskonto(investeringskonto);
                        break;
                    case "2":
                        HanteraSparkonto(sparkonto);
                        break;
                    case "3":
                        HanteraPersonkonto(personkonto, investeringskonto, sparkonto);
                        break;
                    
                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
            }
        }

        private static void HanteraInvesteringskonto(Investeringskonto investeringskonto)
        {
            while (true)
            {
                Console.WriteLine("Vad vill du göra med investeringskontot?");
                Console.WriteLine("1 - Kolla balans");
                Console.WriteLine("2 - Uttag");
                Console.WriteLine("3 - Investera pengar");
                Console.WriteLine("4 - Visa transaktionshistorik");
               

                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        Console.WriteLine($"Aktuell balans: {investeringskonto.saldo}");
                        break;
                    case "2":
                        decimal withdrawalAmount;
                        Console.WriteLine("Ange belopp att ta ut:");
                        while (!decimal.TryParse(Console.ReadLine(), out withdrawalAmount) || withdrawalAmount > investeringskonto.saldo)
                        {
                            Console.WriteLine("Ogiltigt belopp. Ange ett giltigt belopp:");
                        }
                        investeringskonto.Uttag(withdrawalAmount);
                        break;
                    case "3":
                        decimal investmentAmount;
                        Console.WriteLine("Ange belopp att investera:");
                        while (!decimal.TryParse(Console.ReadLine(), out investmentAmount))
                        {
                            Console.WriteLine("Ogiltigt belopp. Ange ett giltigt belopp:");
                        }
                        investeringskonto.Investmoney(investmentAmount);
                        break;
                    case "4":
                        investeringskonto.TransaktionHistorik.VisaHistorik();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
            }
        }

        private static void HanteraSparkonto(Sparkonto sparkonto)
        {
            while (true)
            {
                Console.WriteLine("\nVad vill du göra med sparkontot?");
                Console.WriteLine("1 - Kolla balans");
                Console.WriteLine("2 - Uttag");
                Console.WriteLine("3 - Spara pengar");
                Console.WriteLine("4 - Visa transaktionshistorik");
               

                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        Console.WriteLine($"Aktuell balans: {sparkonto.saldo}");
                        break;
                    case "2":
                        decimal withdrawalAmount;
                        Console.WriteLine("Ange belopp att ta ut:");
                        while (!decimal.TryParse(Console.ReadLine(), out withdrawalAmount) || withdrawalAmount > sparkonto.saldo)
                        {
                            Console.WriteLine("Ogiltigt belopp. Ange ett giltigt belopp:");
                        }
                        sparkonto.Uttag(withdrawalAmount);
                        break;
                    case "3":
                        decimal savingsAmount;
                        Console.WriteLine("Ange belopp att spara:");
                        while (!decimal.TryParse(Console.ReadLine(), out savingsAmount))
                        {
                            Console.WriteLine("Ogiltigt belopp. Ange ett giltigt belopp:");
                        }
                        sparkonto.Sparapengar(savingsAmount);
                        break;
                    case "4":
                        sparkonto.TransaktionHistorik.VisaHistorik();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
            }
        }

        private static void HanteraPersonkonto(Personkonto personkonto, Investeringskonto investeringskonto, Sparkonto sparkonto)
        {
            while (true)
            {
                Console.WriteLine("Vad vill du göra med personkontot?");
                Console.WriteLine("1 - Kolla balans");
                Console.WriteLine("2 - Uttag");
                Console.WriteLine("3 - Flytta över pengar till respektive konto");
                Console.WriteLine("4 - Visa transaktionshistorik");
              

                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        Console.WriteLine($"Aktuell balans: {personkonto.saldo}");
                        break;
                    case "2":
                        decimal withdrawalAmount;
                        Console.WriteLine("Ange belopp att ta ut:");
                        while (!decimal.TryParse(Console.ReadLine(), out withdrawalAmount) || withdrawalAmount > personkonto.saldo)
                        {
                            Console.WriteLine("Ogiltigt belopp. Ange ett giltigt belopp:");
                        }
                        personkonto.Uttag(withdrawalAmount);
                        break;
                    case "3":
                        Console.WriteLine("Välj ett konto att flytta pengar till:");
                        Console.WriteLine("1 - Investeringskonto");
                        Console.WriteLine("2 - Sparkonto");
                        

                        string transferTo = Console.ReadLine()!;
                        Console.WriteLine("Ange belopp att flytta:");
                        decimal belopp;
                        while (!decimal.TryParse(Console.ReadLine(), out belopp) || belopp > personkonto.saldo)
                        {
                            Console.WriteLine("Ogiltigt belopp. Ange ett giltigt belopp:");
                        }

                        switch (transferTo)
                        {
                            case "1":
                                personkonto.Flyttapengar(investeringskonto, belopp);
                                break;
                            case "2":
                                personkonto.Flyttapengar(sparkonto, belopp);
                                break;
                            case "3":
                                break; // Gå tillbaka till föregående meny
                            default:
                                Console.WriteLine("Ogiltigt val.");
                                break;
                        }
                        break;
                    case "4":
                        personkonto.TransaktionHistorik.VisaHistorik();
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
            }
        }
    }
}