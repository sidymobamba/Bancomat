using System;
using System.Collections.Generic;
using System.Linq;

public class Banca
{
    private List<Utente> Utenti;

    public Banca()
    {
        Utenti = new List<Utente>
        {
            new Utente("sidy", "hello"),
            new Utente("sandro", "1234"),
            new Utente("dario", "ciao")
        };
    }

    public Utente TrovaUtente(string username)
    {
        return Utenti.FirstOrDefault(u => u.Username == username);
    }
}