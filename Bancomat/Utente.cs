using System;
using System.Collections.Generic;
using System.Linq;

public class Utente
{
    public string Username { get; set; }
    public string Password { get; set; }
    public double Saldo { get; set; }
    public int TentativiAccesso { get; set; }

    public Utente(string username, string password)
    {
        Username = username;
        Password = password;
        Saldo = 1000; // inizializzazione saldo a 1000 euro
        TentativiAccesso = 0;
    }
    // controllo tentativi di accesso
    public bool EffettuaAccesso(string username, string password)
    {
        if (TentativiAccesso >= 3)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Hai superato il numero massimo di tentativi di accesso. L'account è stato bloccato.");
            Console.ResetColor();
            return false;
        }

        if (Username == username && Password == password)
        {
            TentativiAccesso = 0; // Resetta i tentativi dopo un accesso riuscito
            Console.WriteLine($"Benvenuto, {Username}!");
            return true;
        }
        else
        {
            TentativiAccesso++;
            Console.WriteLine("Credenziali errate. Riprova.");
            return false;
        }
    }

    public void VisualizzaSaldo()
    {
        DateTime dataOraCorrente = DateTime.Now;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine($"Saldo attuale: {Saldo} euro - Data e ora: {dataOraCorrente}");
        Console.ResetColor();
    }


    public void EseguiPrelievo(double importo)
    {
        if (importo > 0 && Saldo >= importo)
        {
            Saldo -= importo;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"Hai prelevato {importo} euro. Saldo rimanente: {Saldo} euro");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("Importo non valido o saldo insufficiente.");
        }
    }

    public void EseguiVersamento(double importo)
    {
        if (importo > 0)
        {
            Saldo += importo;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"Hai versato {importo} euro. Saldo aggiornato: {Saldo} euro");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("Importo non valido.");
        }
    }
}
