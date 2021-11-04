/* Nickname: @gmarck04
 */

using System;
using System.Collections.Generic;
using System.IO;

namespace Calcio
{
    class Calciatori
    {
        //Attributo
        public string nome;
        //Costruttore
        public Calciatori(string nome)
        {
            this.nome = nome;
        }
        public override string ToString()
        {
            return nome;
        }
    }
    class Squadra
    {
        //Attributi
        public string Nome_squadra;
        int partite_vinte, partite_perse, partite_pareggiate, gol_fatti, gol_subiti;
        public int punti { get; set; }
        List<Calciatori> Lista_calciatori = new List<Calciatori>();

        //Costruttore
        public Squadra(string Nome_squadra, int partite_vinte, int partite_perse, int partite_pareggiate, int gol_fatti, int gol_subiti)
        {
            this.Nome_squadra = Nome_squadra;
            this.partite_vinte = partite_vinte;
            this.partite_pareggiate = partite_pareggiate;
            this.partite_perse = partite_perse;
            this.gol_fatti = gol_fatti;
            this.gol_subiti = gol_subiti;
        }

        //Metodi
        public void Aggiungi_Calciatore(Calciatori calciatori)
        {
            Lista_calciatori.Add(calciatori);
        }
        public void Rimuovi_Calciatore(string nome)
        {
            for(int i = 0; i < Lista_calciatori.Count; i++)
            {
                if(Lista_calciatori[i].nome == nome)
                {
                    Lista_calciatori.Remove(Lista_calciatori[i]);
                }
            }
        }
        public List<Calciatori> Mostra_Calciatori()
        {
                return Lista_calciatori;
        }
        public int Calcola_punti()
        {
           punti = partite_vinte * 3 + partite_pareggiate * 1;
           return punti;
        }
        public void Reset()
        {
            partite_vinte = 0;
            partite_perse = 0;
            partite_pareggiate = 0;
            gol_fatti = 0;
            gol_subiti = 0;
        }
        public void Aggiungi_partite_vinte()
        {
            partite_vinte++;
        }
        public void Aggiungi_partite_pareggiate()
        {
            partite_pareggiate++;
        }
        public void Aggiungi_partite_perse()
        {
            partite_perse++;
        }
        public void Gol_fatti(int gol)
        {
            gol_fatti += gol;
        }
        public void Gol_subiti(int gol)
        {
            gol_subiti += gol;
        }
        public override string ToString()
        {
            return Nome_squadra;
        }
        public int CompareTo(Squadra squadra2, int codice)
        {
            int datoSquadra1 = 0, datoSquadra2 = 0;
            switch (codice)
            {
                case 0:
                    datoSquadra1 = this.Calcola_punti();
                    datoSquadra2 = squadra2.Calcola_punti();
                    break;
                case 1:
                    datoSquadra1 = this.gol_fatti;
                    datoSquadra2 = squadra2.gol_fatti;
                    break;
                case 2:
                    datoSquadra1 = this.gol_subiti;
                    datoSquadra2 = squadra2.gol_subiti;
                    break;
            }

            if(datoSquadra1 > datoSquadra2)
            {
                return 1;
            } 
            else if(datoSquadra1 == datoSquadra2)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }

    class Program
    {
        public static string file = AppDomain.CurrentDomain.BaseDirectory + "/Login.txt";
        public static List<Squadra> Lista_di_squadre = new List<Squadra>();

        static void Main(string[] args)
        {
            if (Controllo_salvataggio() == 0)
            {
                File_trovato();
            }
            else if (Controllo_salvataggio() == -1)
            {
                File_non_trovato();
            }
            Console.ReadKey();
        }

        public static void File_trovato()
        {
            Console.WriteLine("Benvenuto, vuoi caricare i file di salvataggio o creare una nuovo campionato?\n (se selezioni si allora perderai tutti i file)");
        }
        public static void File_non_trovato()
        {
            int numero_squadre = 0;


            Console.WriteLine("Benveuto per iniziare scrivi il numero di squadre che vuoi generare");
            bool controllo_1 = int.TryParse(Console.ReadLine(), out numero_squadre);
            while(!controllo_1 || numero_squadre < 1)
            {
                Console.WriteLine("Errato. Inserisci un numero");
                controllo_1 = int.TryParse(Console.ReadLine(), out numero_squadre);
            }
            
            for(int i = 0; i < numero_squadre; i++)
            {              
                Lista_di_squadre.Add(Inserisci_dati()); 
            }

            menù();

            //StreamWriter File = new StreamWriter(file);
            //File.WriteLine();
        }

        public static void menù()
        {
            int scelta = -1;
            Console.Clear();

            do
            {
                scelta = menu_scelta();

                switch (scelta)
                {
                    case 1:
                        {                            
                            Lista_di_squadre[Id_Squadre(Squadra())].Aggiungi_partite_vinte();
                        }
                        break;
                    case 2:
                        {
                            Lista_di_squadre[Id_Squadre(Squadra())].Aggiungi_partite_pareggiate();
                        }
                        break;
                    case 3:
                        {
                            Lista_di_squadre[Id_Squadre(Squadra())].Aggiungi_partite_perse();
                        }
                        break;
                    case 4:
                        {
                            int gol;
                            Console.WriteLine("Inserisci il numero di gol fatti");
                            bool controllo = int.TryParse(Console.ReadLine(), out gol);
                            while (!controllo)
                            {
                                Console.WriteLine("Errato. Inserisci il numero di gol fatti");
                                controllo = int.TryParse(Console.ReadLine(), out gol);
                            }
                            Lista_di_squadre[Id_Squadre(Squadra())].Gol_fatti(gol);
                        }
                        break;
                    case 5:
                        {
                            int gol;
                            Console.WriteLine("Inserisci il numero di gol subiti");
                            bool controllo = int.TryParse(Console.ReadLine(), out gol);
                            while (!controllo)
                            {
                                Console.WriteLine("Errato. Inserisci il numero di gol subiti");
                                controllo = int.TryParse(Console.ReadLine(), out gol);
                            }
                            Lista_di_squadre[Id_Squadre(Squadra())].Gol_subiti(gol);
                        }
                        break;
                    case 6:
                        {
                            Console.WriteLine("Inserisci nome del giocatore da aggiungere");
                            string nome_calciatore = Console.ReadLine();
                            Lista_di_squadre[Id_Squadre(Squadra())].Aggiungi_Calciatore(new Calciatori(nome_calciatore));
                        }
                        break;
                    case 7:
                        {
                            Console.WriteLine("Inserisci nome del giocatore da riumovere");
                            string nome_calciatore = Console.ReadLine();
                            Lista_di_squadre[Id_Squadre(Squadra())].Rimuovi_Calciatore(nome_calciatore);
                        }
                        break;
                    case 8:
                        {
                            for (int i = 0; i < Lista_di_squadre[Id_Squadre(Squadra())].Mostra_Calciatori().Count; i++)
                            {
                                Console.WriteLine(Lista_di_squadre[Id_Squadre(Squadra())].Mostra_Calciatori()[i]);
                            }
                        }
                        break;
                    case 9:
                        {
                            Classifica_Punti();
                        }
                        break;
                    case 10:
                        {
                            Classifica_gol_fatti();
                        }
                        break;
                    case 11:
                        {
                            Classifica_gol_subiti();
                        }
                        break;
                    case 12:
                        {
                            Lista_di_squadre[Id_Squadre(Squadra())].Reset();
                        }
                        break;

                }
            } while (scelta != 13);
        }

        public static int menu_scelta()
        {
            int scelta;
            Console.WriteLine("Menù:\n -1 Aggiumgi una partita vinta;\n -2 Aggiungi una partita pareggiata;\n -3 Aggiungi una partita persa;\n -4 Aggiungi gol fatti;\n -5 Aggiungi gol subiti\n -6 Aggiungi Calciatore;\n -7 Rimuovi giocatore;\n -8 Mostra i calciatori della squadra;\n -9 Mostra la classifica per punti;\n -10 Mostra la classifica per gol fatti;\n -11 Mostra la classifica per gol subiti;\n -12 Reset;\n -13 Chiudi Gioco.");
            bool controllo = int.TryParse(Console.ReadLine(), out scelta);
            while (!controllo || (scelta < 0 || scelta > 14))
            {
                Console.WriteLine("Errato. Menù:\n -1 Aggiumgi una partita vinta;\n -2 Aggiungi una partita pareggiata;\n -3 Aggiungi una partita persa;\n -4 Aggiungi gol fatti;\n -5 Aggiungi gol subiti\n -6 Aggiungi Calciatore;\n -7 Rimuovi giocatore;\n -8 Mostra i calciatori della squadra;\n -9 Mostra la classifica per punti;\n -10 Mostra la classifica per gol fatti;\n -11 Mostra la classifica per gol subiti;\n -12 Reset;\n -13 Chiudi Gioco.");
                controllo = int.TryParse(Console.ReadLine(), out scelta);
            }
            return scelta;
        }

        public static string Squadra()
        {
            string nome_squadra = "";
            bool controllo = false;
            do
            {
                Console.WriteLine("Inserisci la squadra");
                string nome = Console.ReadLine();
                for (int i = 0; i < Lista_di_squadre.Count; i++)
                {
                    if (Lista_di_squadre[i].Nome_squadra == nome)
                    {
                        nome_squadra = nome;
                        controllo = true;
                    }
                }
                if (controllo == false)
                {
                    Console.Clear();
                    Console.WriteLine("La sqaudra inserita non esiste");
                    Console.WriteLine("Le squadre disponibili sono:");
                    for (int i = 0; i < Lista_di_squadre.Count; i++)
                    {
                        Console.WriteLine(Lista_di_squadre[i].ToString());
                    }
                    controllo = false;
                }
            } while (controllo == false);

            return nome_squadra;
        }
        public static int Id_Squadre(string nome)
        {
            for (int i = 0; i < Lista_di_squadre.Count; i++)
            {
                if (Lista_di_squadre[i].Nome_squadra == nome)
                {
                    return i;
                }
            }
            return -1;
        }

        public static int Controllo_salvataggio()
        {
            
            if (!File.Exists(file))
            {
                //Console.WriteLine("File di salvataggio no trovato");
                return -1;
            }
            return 0;
        }
        public static Squadra Inserisci_dati()
        {
            int partite_vinte, partite_perse, partite_pareggiate, gol_fatti, gol_subiti;

            Console.WriteLine("Inserisci nome squadra");
            string Nome_squadra = Console.ReadLine();
            Console.WriteLine("Inserisci il numero di partite vinte");
            bool controllo_2 = int.TryParse(Console.ReadLine(), out partite_vinte);
            while (!controllo_2)
            {
                Console.WriteLine("Errato. Inserisci il numero di partite vinte");
                controllo_2 = int.TryParse(Console.ReadLine(), out partite_vinte);
            }
            Console.WriteLine("Inserisci il numero di partite perse");
            bool controllo_3 = int.TryParse(Console.ReadLine(), out partite_perse);
            while (!controllo_3)
            {
                Console.WriteLine("Errato. Inserisci il numero di partite perse");
                controllo_3 = int.TryParse(Console.ReadLine(), out partite_perse);
            }
            Console.WriteLine("Inserisci il numero di partite pareggiate");
            bool controllo_4 = int.TryParse(Console.ReadLine(), out partite_pareggiate);
            while (!controllo_4)
            {
                Console.WriteLine("Errato. Inserisci il numero di partite pareggiate");
                controllo_4 = int.TryParse(Console.ReadLine(), out partite_pareggiate);
            }
            Console.WriteLine("Inserisci il numero di gol fatti");
            bool controllo_5 = int.TryParse(Console.ReadLine(), out gol_fatti);
            while (!controllo_5)
            {
                Console.WriteLine("Errato. Inserisci il numero di gol fatti");
                controllo_5 = int.TryParse(Console.ReadLine(), out gol_fatti);
            }
            Console.WriteLine("Inserisci il numero di gol subiti");
            bool controllo_6 = int.TryParse(Console.ReadLine(), out gol_subiti);
            while (!controllo_6)
            {
                Console.WriteLine("Errato. Inserisci il numero di gol subiti");
                controllo_6 = int.TryParse(Console.ReadLine(), out gol_subiti);
            }
            Squadra c = new Squadra(Nome_squadra, partite_vinte, partite_perse, partite_pareggiate, gol_fatti, gol_subiti);
            Console.Clear();
            return c;
        }
        public static void Classifica_Punti()
        {
            for(int i = 0; i < InsertionSort(Lista_di_squadre, 0).Count; i++)
            {
                Console.WriteLine(i + 1 + "-" + InsertionSort(Lista_di_squadre, 0)[i].ToString());
            }
        }

        public static void Classifica_gol_fatti()
        {
            for (int i = 0; i < InsertionSort(Lista_di_squadre, 1).Count; i++)
            {
                Console.WriteLine(i + 1 + "-" + InsertionSort(Lista_di_squadre, 1)[i].ToString());
            }
        }

        public static void Classifica_gol_subiti()
        {
            for (int i = 0; i < InsertionSort(Lista_di_squadre, 2).Count; i++)
            {
                Console.WriteLine(i + 1 + "-" + InsertionSort(Lista_di_squadre, 2)[i].ToString());
            }
        }

        static List<Squadra> InsertionSort(List<Squadra> inputArray, int codice)
        {
            for (int i = 0; i < inputArray.Count - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (inputArray[j - 1].CompareTo(inputArray[j], codice) == -1)
                    {
                        Squadra temp = inputArray[j - 1];
                        inputArray[j - 1] = inputArray[j];
                        inputArray[j] = temp;
                    }
                }
            }
            return inputArray;
        }

    }
}
