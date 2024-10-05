using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{


   public class TransaktionHistorik
{
    private string[] transaktioner;
    private int index;

    public TransaktionHistorik()
    {
        transaktioner = new string[10];
        index = 0;
    }

    public void LäggTillTransaktion(string transaktion)
    {
        if (index < transaktioner.Length)
        {
            transaktioner[index] = transaktion;
            index++;
        }
        else
        {
           
            Console.WriteLine("Transaktionshistoriken är full.");
        }
    }

    public void VisaHistorik()
    {
        Console.WriteLine("Transaktionshistorik:");
        for (int i = 0; i < index; i++)
        {
            Console.WriteLine(transaktioner[i]);
        }
    }
}
}

