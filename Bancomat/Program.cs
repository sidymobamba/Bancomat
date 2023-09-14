using System;
using System.Collections.Generic;
using System.Linq;

namespace Bancomat
{
    class Program
    {
        static void Main()
        {
            Banca banca = new Banca();
            Utente utenteCorrente = null;

            while (true)
            {
                
                Console.WriteLine("Benvenuto al Bancomat! Scegli un'opzione:");
                Console.WriteLine("1. Accesso");
                Console.WriteLine("2. Esci");
                

                int scelta;
                if (!int.TryParse(Console.ReadLine(), out scelta))
                {
                    Console.WriteLine("Scelta non valida. Riprova.");
                    continue;
                }

                switch (scelta)
                {
                    case 1:
                        Console.Write("Username: ");
                        string username = Console.ReadLine();
                        Console.Write("Password: ");
                        string password = Console.ReadLine();
                        

                        utenteCorrente = banca.TrovaUtente(username);

                        if (utenteCorrente != null && utenteCorrente.EffettuaAccesso(username, password))
                        {
                            while (true)
                            {
                                
                                Console.WriteLine("\nOperazioni disponibili:");
                                Console.WriteLine("1. Visualizza saldo");
                                Console.WriteLine("2. Prelievo");
                                Console.WriteLine("3. Versamento");
                                Console.WriteLine("4. Logout");
                               

                                int sceltaOperazione;
                                if (!int.TryParse(Console.ReadLine(), out sceltaOperazione))
                                {
                                    Console.WriteLine("Scelta non valida. Riprova.");
                                    continue;
                                }

                                switch (sceltaOperazione)
                                {
                                    case 1:
                                        utenteCorrente.VisualizzaSaldo();
                                        break;

                                    case 2:
                                        Console.Write("Inserisci l'importo da prelevare: ");
                                        double importoPrelievo;
                                        if (double.TryParse(Console.ReadLine(), out importoPrelievo))
                                        {
                                            utenteCorrente.EseguiPrelievo(importoPrelievo);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Importo non valido. Riprova.");
                                        }
                                        break;

                                    case 3:
                                        Console.Write("Inserisci l'importo da versare: ");
                                        double importoVersamento;
                                        if (double.TryParse(Console.ReadLine(), out importoVersamento))
                                        {
                                            utenteCorrente.EseguiVersamento(importoVersamento);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Importo non valido. Riprova.");
                                        }
                                        break;

                                    case 4:
                                        utenteCorrente = null; // Logout
                                        Console.WriteLine("Hai effettuato il logout.");
                                        break;

                                    default:
                                        Console.WriteLine("Scelta non valida. Riprova.");
                                        break;
                                }

                                if (utenteCorrente == null)
                                {
                                    // Se l'utente è stato disconnesso, esci dal loop delle operazioni
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Accesso non autorizzato.");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Grazie per aver utilizzato il Bancomat. Arrivederci!");
                        return;

                    default:
                        Console.WriteLine("Scelta non valida. Riprova.");
                        break;
                }
            }
        }
    }
}
