using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Sparkonto
    {
        public int bankKontoNummer;
        public decimal saldo;
        public TransaktionHistorik TransaktionHistorik { get; private set; }
        public Sparkonto(decimal startSaldo)
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
        public void Sparapengar(decimal Savedmoney)
        {
            if (Savedmoney <= 0)
            {
                new ArgumentException("du måste spara mer än noll.");
            }
            saldo += Savedmoney; // lägg sparat belop i samma saldo
            TransaktionHistorik.LäggTillTransaktion($"Sparat: {Savedmoney}");
            Console.WriteLine($"Sparat belopp: {Savedmoney}. Nytt saldo: {saldo}");
        }
    }
}
