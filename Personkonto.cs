using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Personkonto
    {
        public int bankKontoNummer;
        public decimal saldo;
        public TransaktionHistorik TransaktionHistorik { get; private set; }

        public Personkonto(decimal startSaldo)
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

        public void Flyttapengar(Investeringskonto investeringskonto, decimal belopp)
        {
            if (belopp > saldo)
            {
                Console.WriteLine("Fel: Uttagsbeloppet överstiger saldot.");
                return;
            }
            saldo -= belopp;
            investeringskonto.saldo += belopp;
            TransaktionHistorik.LäggTillTransaktion($"Flyttade {belopp} till investeringskontot.");
            Console.WriteLine($"Flyttade {belopp} till investeringskontot. Nytt saldo: {saldo}");
        }

        public void Flyttapengar(Sparkonto sparkonto, decimal belopp)
        {
            if (belopp > saldo)
            {
                Console.WriteLine("Fel: Uttagsbeloppet överstiger saldot.");
                return;
            }
            saldo -= belopp;
            sparkonto.saldo += belopp;
            TransaktionHistorik.LäggTillTransaktion($"Flyttade {belopp} till sparkontot.");
            Console.WriteLine($"Flyttade {belopp} till sparkontot. Nytt saldo: {saldo}");
        }
    }
}