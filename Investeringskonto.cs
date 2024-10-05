using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{


    public class Investeringskonto
{
    public int bankKontoNummer;
    public decimal saldo;
    public TransaktionHistorik TransaktionHistorik { get; private set; }

    public Investeringskonto(decimal startSaldo)
    {
        saldo = startSaldo;
        TransaktionHistorik = new TransaktionHistorik();
    }

    public void Uttag(decimal withdrawalAmount)
    {
        if (withdrawalAmount <= 0)
        {
            throw new ArgumentException("Uttagsbeloppet måste vara större än noll.");
        }

        if (withdrawalAmount > saldo)
        {
            Console.WriteLine("Fel: Uttagsbeloppet överstiger saldot.");
        }
        else
        {
            saldo -= withdrawalAmount;
            TransaktionHistorik.LäggTillTransaktion($"Uttag: {withdrawalAmount}");
            Console.WriteLine($"Uttag: {withdrawalAmount}. Nytt saldo: {saldo}");
        }
    }

    public void Investmoney(decimal investedamount)
    {
        if (investedamount <= 0)
        {
            throw new ArgumentException("Investeringsbeloppet måste vara större än noll.");
        }
        saldo += investedamount; 
        TransaktionHistorik.LäggTillTransaktion($"Investering: {investedamount}");
        Console.WriteLine($"Investerat belopp: {investedamount}. Nytt saldo: {saldo}");
    }
}
}