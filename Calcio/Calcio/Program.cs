/* Nickname: @gmarck04
 * Data: 04/11/2021
 * Consegna: 
 *          Descrivere nel dettaglio il funzionamento del seguente software, come se la richiesta di laboratorio fosse

 *          Testo dell'esercizio di laboratorio
 *          Creare una classe Squadra che rappresenta una squadra di calcio e ha come attributi il numero di partite vinte, il numero di partite perse, 
 *          il numero di partite pareggiate e i gol fatti e subiti.
 *          Ha opportuni metodi per impostare i parametri e farli visualizzare, inoltre ha:
 *
 *              ● il metodo punti() che restituisce quanti punti ha in campionato (ogni partita vinta vale 3 punti, ogni partita pareggiata 1, quelle perse 0)
 *              ● un metodo inizioanno() che resetta il numero di partite vinte, pareggiate e perse portandole a zero.
 *              ● il metodo goalFatto()
 *              ● il motodo goalSubito()

 *          eventualmente, con x = valore intero positivo
 *              ● il metodo goalFatto( int x)
 *              ● il motodo goalSubito(int x)

 *          Creare un main per provare la classe creando due istanze (ad es: Juventus e Milan) e si provino ad utilizzare facendo inserire all’utente 
 *          per entrambe le squadre, il numero di partite vinte, perse e pareggiate e quanti gol fatti e subiti e poi confrontando quale delle due ha più punti 
 *          in campionato e quale delle due ha subito più goal e quale ne ha fatti di più.

 *          NB: lo sviluppo deve essere fatto usando il paradigma della programmazione ad oggetti ed in particolare rispettando l’information hiding: parametri privati, 
 *          metodi pubblici.

 *          Esercizio per casa: creare il programma.
 */

using System;
using System.Collections.Generic;
using System.IO;

namespace Calcio
{
    class Calciatori //Classe che mi registra i nomi dei calciatori della squadra.
    {
        //Attributo.
        public string nome; //Inizzializzo la stringa nome.
        //Costruttore, che chiede in entrata un nome.
        public Calciatori(string nome)
        {
            this.nome = nome; //this.nome fa riferimento all'istanza corrente della classe e viene anche usata come modificatore della stringa contenuta in nome.
        }
        public override string ToString() //Metodo ToString, che ritorna la stringa nome.
        {
            return nome; //Ritorna la stringa nome.
        }
    }
    class Squadra /*Classe che mi registra tutti i parametri della squadra, come il nome della squadra, il numero di partite vinte, le perse, 
                   *le pareggiate, i gol fatti, i gol subiti, i punti e tutti i calciatori della squadra. */
        {
        //Attributi
        public string Nome_squadra; //Inizzializzo la stringa Nome_squadra.
        int partite_vinte, partite_perse, partite_pareggiate, gol_fatti, gol_subiti; //Inizzializzo le avriabili di tipo int partite_vinte, partite_perse, partite_pareggiate, gol_fatti, gol_subiti.
        public int punti { get; set; } //Inizializzo la variabile punti, con get e set pubblici.
        List<Calciatori> Lista_calciatori = new List<Calciatori>(); //Inizzializzazione della lista Lista_calciatori di tipo Calciatori (lista di classi).

        //Costruttore, che chiede in entrata la stringa Nome_squadra e le avriabili di tipo int partite_vinte, partite_perse, partite_pareggiate, gol_fatti, gol_subiti.
        public Squadra(string Nome_squadra, int partite_vinte, int partite_perse, int partite_pareggiate, int gol_fatti, int gol_subiti)
        {
            this.Nome_squadra = Nome_squadra; //this.Nome_squadra fa riferimento all'istanza corrente della classe e viene anche usata come modificatore della stringa contenuta in Nome_squadra.
            this.partite_vinte = partite_vinte; //this.partite_vinte fa riferimento all'istanza corrente della classe e viene anche usata come modificatore della stringa contenuta in partite_vinte.
            this.partite_pareggiate = partite_pareggiate; //this.partite_pareggiate fa riferimento all'istanza corrente della classe e viene anche usata come modificatore della stringa contenuta in partite_pareggiate.
            this.partite_perse = partite_perse; //this.partite_perse fa riferimento all'istanza corrente della classe e viene anche usata come modificatore della stringa contenuta in partite_perse.
            this.gol_fatti = gol_fatti; //this.gol_fatti fa riferimento all'istanza corrente della classe e viene anche usata come modificatore della stringa contenuta in gol_fatti.
            this.gol_subiti = gol_subiti; //this.gol_subiti fa riferimento all'istanza corrente della classe e viene anche usata come modificatore della stringa contenuta in gol_subiti.
        }

        //Metodi
        public void Aggiungi_Calciatore(Calciatori calciatori) //Metodo che aggiunge i calciatori alla lista Lista_calciatori.
        {
            Lista_calciatori.Add(calciatori); //Aggiungo la variabile di tipo Calciatori calciatori alla lista Lista_calciatori, con la funzione Add.
        }
        public void Rimuovi_Calciatore(string nome) //Metodo che rimuove i calciatori dalla Lista_calciatori.
        {
            for(int i = 0; i < Lista_calciatori.Count; i++) //Ciclo for che inizializza la variabile di tipo int a cui assegnio il nome i e la pongo pari a 0, che continua fino a quando il valore della i è minore della lunghezza della lista Lista_calciatori, la i ad ogni ciclo viene incrementata di 1.
            {
                if(Lista_calciatori[i].nome == nome) //If che controlla se la stringa contenuta in Lista_calciatori[].nome è uguale a nome.
                {
                    Lista_calciatori.Remove(Lista_calciatori[i]); //Rimuovo la riga della lista Lista_calciatori posizionata sulla posizione i, con la funzione Remove.
                }
            }
        }
        public List<Calciatori> Mostra_Calciatori() //Metodo che ritorna la Lista_calciatori.
        {
            return Lista_calciatori; //Ritorna la lista Lista_calciatori.
        }
        public int Calcola_punti() //Metodo che calcola i punti in base alle partite vinte o pareggiate, se sono vinte vi è un moltiplicatore di 3.
        {
            punti = partite_vinte * 3 + partite_pareggiate; //punti uguale alla variabile partite_vinte moltiplicata per 3 a cui aggiungo la variabile partite_pareggiate. 
            return punti; //Ritorna la variabile punti.
        }
        public void Reset() //Metodo che resetta tutti i parametri della squadra, ponendo le avriabili di tipo int partite_vinte, partite_perse, partite_pareggiate, gol_fatti, gol_subiti a 0.
        {
            partite_vinte = 0; //Pongo la variabile partite_vinte pari a 0.
            partite_perse = 0; //Pongo la variabile partite_perse pari a 0.
            partite_pareggiate = 0; //Pongo la variabile partite_pareggiate pari a 0.
            gol_fatti = 0; //Pongo la variabile gol_fatti pari a 0.
            gol_subiti = 0; //Pongo la variabile gol_subiti pari a 0.
        }
        public void Aggiungi_partite_vinte() //Metodo che aggiunge una partita vinta.
        {
            partite_vinte++; //Incremento la variabile partite_vinte di 1.
        }
        public void Aggiungi_partite_pareggiate() //Metodo che aggiunge una partita pareggiata.
        {
            partite_pareggiate++; //Incremento la variabile partite_pareggiate di 1.
        }
        public void Aggiungi_partite_perse() //Metodo che aggiunge una partita persa.
        {
            partite_perse++; //Incremento la variabile partite_perse di 1.
        }
        public void Gol_fatti(int gol) //Metodo che aggiunge i gol fatti, chiedendo in input il numero di gol da aggiungere.
        {
            gol_fatti += gol; //Aggiungo alla variabile gol_fatti il valore della variabile gol.
        }
        public void Gol_subiti(int gol) //Metodo che aggiunge i gol subiti, chiedendo in input il numero di gol da aggiungere.
        {
            gol_subiti += gol; //Aggiungo alla variabile gol_subiti il valore della variabile gol.
        }
        public override string ToString() //Metodo ToString, che ritorna la stringa Nome_squadra.
        {
            return Nome_squadra; //Ritorno il valore della stringa Nome_squadra.
        }
        public int CompareTo(Squadra squadra2, int codice) //Metodo che serve per comparare i gol fatti, gol subiti o i punti in base al codice inserito.
        {
            int datoSquadra1 = 0, datoSquadra2 = 0; //Inizializzo le variabili di tipo int datoSquadra1 e datoSquadra2 e le pongo pari a 0.
            switch (codice) //Switch con la variabile codice.
            {
                case 0: //Se pari a 0.
                    datoSquadra1 = this.Calcola_punti(); //Pongo la variablie datoSquadra1 pari al valore restituito dal metodo Calcola_punti di questa classe.
                    datoSquadra2 = squadra2.Calcola_punti(); //Pongo la variablie datoSquadra2 pari al valore restituito dal metodo della squadra 2 Calcola_punti.
                    break; //Chiudo.
                case 1: //Se pari a 1.
                    datoSquadra1 = this.gol_fatti; //Pongo la variablie datoSquadra1 pari al valore della variabile gol_fatti di questa classe.
                    datoSquadra2 = squadra2.gol_fatti; //Pongo la variablie datoSquadra2 pari al valore della variabile gol_fatti della squadra 2 Calcola_punti.
                    break; //Chiudo.
                case 2: //Se pari a 2.
                    datoSquadra1 = this.gol_subiti; //Pongo la variablie datoSquadra1 pari al valore della variabile gol_subiti di questa classe.
                    datoSquadra2 = squadra2.gol_subiti; //Pongo la variablie datoSquadra2 pari al valore della variabile gol_subiti della squadra 2 Calcola_punti.
                    break; //Chiudo.
            }

            if(datoSquadra1 > datoSquadra2) //Se il valore di datoSquadra1 è maggiore del valore di datoSquadra2 allora...
            {
                return 1; //Ritorna 1.
            } 
            else if(datoSquadra1 == datoSquadra2) //Se il valore di datoSquadra1 è uguale del valore di datoSquadra2 allora...
            {
                return 0; //Ritorna 0.
            }
            else //Oppure...
            {
                return -1; //Ritorna -1.
            }
        }
    }

    class Program
    {
        public static string file = AppDomain.CurrentDomain.BaseDirectory + "/Login.txt"; //Inizializzo la stringa file e le do valore pari al valore del percorso della directory di base + /Login.txt.
        public static List<Squadra> Lista_di_squadre = new List<Squadra>(); //Inizzializzazione della lista Lista_di_squadre di tipo Squadra (lista di classi).

        static void Main(string[] args)
        {
            if (Controllo_salvataggio() == 0) //Se il valore della funzione Controllo_salvataggio è uguale a 0 allora...
            {
                File_trovato(); //Richiamo la funzione File_trovato.
            }
            else if (Controllo_salvataggio() == -1) //Se il valore della funzione Controllo_salvataggio è uguale a -1 allora...
            {
                File_non_trovato(); //Richiamo la funzione File_non_trovato.
            }
            Console.ReadKey(); //Blocco il programma, fino a pressione del tasto invio.
        }

        public static void File_trovato() //Funzione File_trovato (da fare...)
        {
            Console.WriteLine("Benvenuto, vuoi caricare i file di salvataggio o creare una nuovo campionato?\n (se selezioni si allora perderai tutti i file)"); //Scrive su console la stringa.
        }
        public static void File_non_trovato() //Funzione File_non_trovato, che contiene il codice in caso di file non trovato o di primo avvio.
        {
            int numero_squadre = 0; //Inizzializzo la avriabile di tipo int numero_squadre e la pongo uguale a 0.


            Console.WriteLine("Benveuto per iniziare scrivi il numero di squadre che vuoi generare"); //Scrive su console la stringa.
            bool controllo = int.TryParse(Console.ReadLine(), out numero_squadre); //Inizializzo la variabile di tipo bool controllo e le do valore pari al valore ritornato dalla funzione TryParse, che prende in entrata il valore preso dalla funzione Console.ReadLine, restituisce il valore convertito in int e lo inserisce in numero_squadre.
            while (!controllo || numero_squadre < 1) //Ciclo while, che si avvia se controllo è falso o se la variabile numero_squadre è minore di 1.
            {
                Console.WriteLine("Errato. Inserisci un numero"); //Scrive su console la stringa.
                controllo = int.TryParse(Console.ReadLine(), out numero_squadre); //Do alla variabile di tipo bool controllo e le do valore pari al valore ritornato dalla funzione TryParse, che prende in entrata il valore preso dalla funzione Console.ReadLine, restituisce il valore convertito in int e lo inserisce in numero_squadre.
            }
            
            for(int i = 0; i < numero_squadre; i++) //Ciclo for che inizializza la variabile di tipo int a cui assegnio il nome i e la pongo pari a 0, che continua fino a quando il valore della i è minore della variabile numero_squadre, la i ad ogni ciclo viene incrementata di 1.
            {              
                Lista_di_squadre.Add(Inserisci_dati()); //Aggiungo la variabile restituita dalla funzione Inserisci_dati alla lista Lista_calciatori, con la funzione Add.
            }

            menù(); //Richiamo la funzione menù.

            //StreamWriter File = new StreamWriter(file);
            //File.WriteLine();
        }

        public static void menù() //Funzione menù, che va a indirizzare la scelta fatta con la funzione menu_scelta.
        {
            int scelta = -1; //Inizzializzo la avriabile di tipo int scelta e la pongo uguale a -1.
            Console.Clear(); //Funzione, che pulisce la console.

            do //Ciclo do while, che continua se la variabile di tipo int è diversa da 0.
            {
                scelta = menu_scelta(); //Assegno il valore restituito dalla funzione menu_scelta alla variabile scelta.

                switch (scelta) //Switch con la variabile scelta.
                {
                    case 1: //Se la variabile scelta è uguale a 1.
                        {                            
                            Lista_di_squadre[Id_Squadre(Squadra())].Aggiungi_partite_vinte(); //Con la lista Lista_di_squadre[funzione Id_Squadre(a cui invio il valore restituito da (Squadra())]. richiamo il metodo della classe Squadra Aggiungi_partite_vinte.
                        }
                        break; //Chiudo.
                    case 2: //Se la variabile scelta è uguale a 2.
                        {
                            Lista_di_squadre[Id_Squadre(Squadra())].Aggiungi_partite_pareggiate(); //Con la lista Lista_di_squadre[funzione Id_Squadre(a cui invio il valore restituito da (Squadra())]. richiamo il metodo della classe Squadra Aggiungi_partite_pareggiate.
                        }
                        break; //Chiudo.
                    case 3: //Se la variabile scelta è uguale a 3.
                        {
                            Lista_di_squadre[Id_Squadre(Squadra())].Aggiungi_partite_perse(); //Con la lista Lista_di_squadre[funzione Id_Squadre(a cui invio il valore restituito da (Squadra())]. richiamo il metodo della classe Squadra Aggiungi_partite_perse.
                        }
                        break; //Chiudo.
                    case 4: //Se la variabile scelta è uguale a 4.
                        {
                            int gol; //Inizializzo la variabile di tipo int gol.
                            Console.WriteLine("Inserisci il numero di gol fatti"); //Scrive su console la stringa.
                            bool controllo = int.TryParse(Console.ReadLine(), out gol); //Inizializzo la variabile di tipo bool controllo e le do valore pari al valore ritornato dalla funzione TryParse, che prende in entrata il valore preso dalla funzione Console.ReadLine, restituisce il valore convertito in int e lo inserisce in gol.
                            while (!controllo)
                            {
                                Console.WriteLine("Errato. Inserisci il numero di gol fatti"); //Scrive su console la stringa.
                                controllo = int.TryParse(Console.ReadLine(), out gol); //Do alla variabile di tipo bool controllo e le do valore pari al valore ritornato dalla funzione TryParse, che prende in entrata il valore preso dalla funzione Console.ReadLine, restituisce il valore convertito in int e lo inserisce in gol.
                            }
                            Lista_di_squadre[Id_Squadre(Squadra())].Gol_fatti(gol); //Con la lista Lista_di_squadre[funzione Id_Squadre(a cui invio il valore restituito da (Squadra())]. richiamo il metodo della classe Squadra Gol_fatti a cui invio il valore della variablie gol.
                        }
                        break; //Chiudo.
                    case 5: //Se la variabile scelta è uguale a 5.
                        {
                            int gol; //Inizializzo la variabile di tipo int gol.
                            Console.WriteLine("Inserisci il numero di gol subiti"); //Scrive su console la stringa.
                            bool controllo = int.TryParse(Console.ReadLine(), out gol); //Inizializzo la variabile di tipo bool controllo e le do valore pari al valore ritornato dalla funzione TryParse, che prende in entrata il valore preso dalla funzione Console.ReadLine, restituisce il valore convertito in int e lo inserisce in gol.
                            while (!controllo)
                            {
                                Console.WriteLine("Errato. Inserisci il numero di gol subiti"); //Scrive su console la stringa.
                                controllo = int.TryParse(Console.ReadLine(), out gol); //Do alla variabile di tipo bool controllo e le do valore pari al valore ritornato dalla funzione TryParse, che prende in entrata il valore preso dalla funzione Console.ReadLine, restituisce il valore convertito in int e lo inserisce in gol.
                            }
                            Lista_di_squadre[Id_Squadre(Squadra())].Gol_subiti(gol); //Con la lista Lista_di_squadre[funzione Id_Squadre(a cui invio il valore restituito da (Squadra())]. richiamo il metodo della classe Squadra Gol_subiti a cui invio il valore della variablie gol.
                        }
                        break; //Chiudo.
                    case 6: //Se la variabile scelta è uguale a 6.
                        {
                            Console.WriteLine("Inserisci nome del giocatore da aggiungere"); //Scrive su console la stringa.
                            string nome_calciatore = Console.ReadLine(); //Inizializzo la variabile di tipo string nome_calciatore e le assegno il valore restituito dalla funzione Console.ReadLine.
                            Lista_di_squadre[Id_Squadre(Squadra())].Aggiungi_Calciatore(new Calciatori(nome_calciatore)); //Con la lista Lista_di_squadre[funzione Id_Squadre(a cui invio il valore restituito da (Squadra())]. richiamo il metodo della classe Squadra Aggiungi_Calciatore a cui invio un nuovo valore di tipo Calciatore, nome_calciatore.
                        }
                        break; //Chiudo.
                    case 7: //Se la variabile scelta è uguale a 7.
                        {
                            Console.WriteLine("Inserisci nome del giocatore da riumovere"); //Scrive su console la stringa.
                            string nome_calciatore = Console.ReadLine(); //Inizializzo la variabile di tipo string nome_calciatore e le assegno il valore restituito dalla funzione Console.ReadLine.
                            Lista_di_squadre[Id_Squadre(Squadra())].Rimuovi_Calciatore(nome_calciatore); //Con la lista Lista_di_squadre[funzione Id_Squadre(a cui invio il valore restituito da (Squadra())]. richiamo il metodo della classe Squadra Rimuovi_Calciatore a cui invio il valore della variablie nome_calciatore.
                        }
                        break; //Chiudo.
                    case 8: //Se la variabile scelta è uguale a 8.
                        {
                            for (int i = 0; i < Lista_di_squadre[Id_Squadre(Squadra())].Mostra_Calciatori().Count; i++) //Ciclo for che inizializza la variabile di tipo int a cui assegnio il nome i e la pongo pari a 0, che continua fino a quando il valore della i è minore della lunghezza della lista Lista_di_squadre[funzione Id_Squadre(a cui invio il valore restituito da (Squadra())]. richiamo il metodo della classe Squadra Mostra_Calciatori, la i ad ogni ciclo viene incrementata di 1.
                            {
                                Console.WriteLine(Lista_di_squadre[Id_Squadre(Squadra())].Mostra_Calciatori()[i]); //Scrivo il contenuto della lista Lista_di_squadre[funzione Id_Squadre(a cui invio il valore restituito da (Squadra())]. richiamo il metodo della classe Squadra Mostra_Calciatori[i].
                            }
                        }
                        break; //Chiudo.
                    case 9://Se la variabile scelta è uguale a 9.
                        {
                            Classifica_Punti(); //Funzione Classifica_Punti, fa una classifica attraverso i punti registrati.
                        }
                        break; //Chiudo.
                    case 10: //Se la variabile scelta è uguale a 10.
                        {
                            Classifica_gol_fatti(); //Funzione Classifica_gol_fatti, fa una classifica attraverso i gol_fatti registrati.
                        }
                        break; //Chiudo.
                    case 11: //Se la variabile scelta è uguale a 11.
                        {
                            Classifica_gol_subiti(); //Funzione Classifica_gol_subiti, fa una classifica attraverso i gol_subiti registrati.
                        } 
                        break; //Chiudo.
                    case 12: //Se la variabile scelta è uguale a 12.
                        {
                            Lista_di_squadre[Id_Squadre(Squadra())].Reset(); //Con la lista Lista_di_squadre[funzione Id_Squadre(a cui invio il valore restituito da (Squadra())]. richiamo il metodo della classe Squadra Reset.
                        }
                        break; //Chiudo.

                }
            } while (scelta != 13);
        }

        public static int menu_scelta() //Funzione che visualizza il menu.
        {
            int scelta; //Inizzializzo la avriabile di tipo int numero_squadre.
            Console.WriteLine("Menù:\n -1 Aggiumgi una partita vinta;\n -2 Aggiungi una partita pareggiata;\n -3 Aggiungi una partita persa;\n -4 Aggiungi gol fatti;\n -5 Aggiungi gol subiti\n -6 Aggiungi Calciatore;\n -7 Rimuovi giocatore;\n -8 Mostra i calciatori della squadra;\n -9 Mostra la classifica per punti;\n -10 Mostra la classifica per gol fatti;\n -11 Mostra la classifica per gol subiti;\n -12 Reset;\n -13 Chiudi Gioco."); //Scrive su console la stringa.
            bool controllo = int.TryParse(Console.ReadLine(), out scelta); //Inizializzo la variabile di tipo bool controllo e le do valore pari al valore ritornato dalla funzione TryParse, che prende in entrata il valore preso dalla funzione Console.ReadLine, restituisce il valore convertito in int e lo inserisce in scelta.
            while (!controllo || (scelta < 0 || scelta > 14)) //Ciclo while, che si avvia se controllo è falso o se la variabile numero_squadre è minore di 0 o maggiore di 14.
            {
                Console.WriteLine("Errato. Menù:\n -1 Aggiumgi una partita vinta;\n -2 Aggiungi una partita pareggiata;\n -3 Aggiungi una partita persa;\n -4 Aggiungi gol fatti;\n -5 Aggiungi gol subiti\n -6 Aggiungi Calciatore;\n -7 Rimuovi giocatore;\n -8 Mostra i calciatori della squadra;\n -9 Mostra la classifica per punti;\n -10 Mostra la classifica per gol fatti;\n -11 Mostra la classifica per gol subiti;\n -12 Reset;\n -13 Chiudi Gioco."); //Scrive su console la stringa.
                controllo = int.TryParse(Console.ReadLine(), out scelta); //Do alla variabile di tipo bool controllo e le do valore pari al valore ritornato dalla funzione TryParse, che prende in entrata il valore preso dalla funzione Console.ReadLine, restituisce il valore convertito in int e lo inserisce in scelta.
            }
            return scelta; //Ritorna la variabile scelta.
        }

        public static string Squadra() //Richiede all'utente il nome della squadra, controlla che esista e restituisce il valore.
        {
            string nome_squadra = ""; //Inizializzo la variabile di tipo string nome_squadra e le assegno il valore .
            bool controllo = false; //Inizializzo la variabile di tipo bool e le assegno il valore false.
            do //Ciclo do while, che continua se la variabile di tipo bool è false.
            {
                Console.WriteLine("Inserisci la squadra"); //Scrive su console la stringa.
                string nome = Console.ReadLine(); //Inizializzo la variabile di tipo string nome e le assegno il valore restituito dalla funzione Console.ReadLine.
                for (int i = 0; i < Lista_di_squadre.Count; i++) //Ciclo for che inizializza la variabile di tipo int a cui assegnio il nome i e la pongo pari a 0, che continua fino a quando il valore della i è minore della lunghezza della lista Lista_di_squadre, la i ad ogni ciclo viene incrementata di 1.
                {
                    if (Lista_di_squadre[i].Nome_squadra == nome) //Se la stringa contenuta Lista_di_squadre[i].Nome_squadra è uguale alla stringa nome.
                    {
                        nome_squadra = nome; //Pongo la stringa nome_squadra uguale al valore della stringa nome.
                        controllo = true; //Pongo controllo uguale a true.
                    }
                }
                if (controllo == false) //Se controllo è uguale a false allora...
                {
                    Console.Clear(); //Pulisci la console.
                    Console.WriteLine("La sqaudra inserita non esiste"); //Scrive su console la stringa.
                    Console.WriteLine("Le squadre disponibili sono:"); //Scrive su console la stringa.
                    for (int i = 0; i < Lista_di_squadre.Count; i++) //Ciclo for che inizializza la variabile di tipo int a cui assegnio il nome i e la pongo pari a 0, che continua fino a quando il valore della i è minore della lunghezza della lista Lista_di_squadre, la i ad ogni ciclo viene incrementata di 1.
                    {
                        Console.WriteLine(Lista_di_squadre[i].ToString()); //Scrive su console il valore ritornato da Lista_di_squadre[i].ToString().
                    }
                    controllo = false; //Pongo controllo uguale a false.
                }
            } while (controllo == false);

            return nome_squadra; //Ritorna la stringa nome_squadra.
        }
        public static int Id_Squadre(string nome) //Funzione Id_Squadre, che ritorna la lunghezza della lista Lista_di_squadre
        {
            for (int i = 0; i < Lista_di_squadre.Count; i++)  //Ciclo for che inizializza la variabile di tipo int a cui assegnio il nome i e la pongo pari a 0, che continua fino a quando il valore della i è minore della lunghezza della lista Lista_di_squadre, la i ad ogni ciclo viene incrementata di 1.
            {
                if (Lista_di_squadre[i].Nome_squadra == nome) //Se la stringa contenuta Lista_di_squadre[i].Nome_squadra è uguale alla stringa nome.
                {
                    return i; //Ritorna il valore di i.
                }
            }
            return -1; //Ritorna -1.
        }

        public static int Controllo_salvataggio() //Funzione Controllo_salvataggio, che controlla che il file esista.
        {
            
            if (!File.Exists(file)) //Se il file esiste allora...
            {
                //Console.WriteLine("File di salvataggio non trovato"); //Scrive su console la stringa.
                return -1; //Ritorna -1.
            }
            return 0; //Ritorna 0.
        }
        public static Squadra Inserisci_dati() //Funzione Inserisci_dati, che inserisce i dati da inviare al costruttore della classe squadra.
        {
            int partite_vinte, partite_perse, partite_pareggiate, gol_fatti, gol_subiti; //Inizzializzo le avriabili di tipo int partite_vinte, partite_perse, partite_pareggiate, gol_fatti, gol_subiti.

            Console.WriteLine("Inserisci nome squadra"); //Scrive su console la stringa.
            string Nome_squadra = Console.ReadLine(); //Inizializzo la variabile di tipo string Nome_squadra e le assegno il valore restituito dalla funzione Console.ReadLine.
            Console.WriteLine("Inserisci il numero di partite vinte"); //Scrive su console la stringa.
            bool controllo_2 = int.TryParse(Console.ReadLine(), out partite_vinte); //Inizializzo la variabile di tipo bool controllo_2 e le do valore pari al valore ritornato dalla funzione TryParse, che prende in entrata il valore preso dalla funzione Console.ReadLine, restituisce il valore convertito in int e lo inserisce in partite_vinte.
            while (!controllo_2 || partite_vinte < 0) //Ciclo while, che si avvia se controllo_2 è falso o se la variabile partite_vinte è minore di 0.
            {
                Console.WriteLine("Errato. Inserisci il numero di partite vinte"); //Scrive su console la stringa.
                controllo_2 = int.TryParse(Console.ReadLine(), out partite_vinte); //Do alla variabile di tipo bool controllo e le do valore pari al valore ritornato dalla funzione TryParse, che prende in entrata il valore preso dalla funzione Console.ReadLine, restituisce il valore convertito in int e lo inserisce in partite_vinte.
            }
            Console.WriteLine("Inserisci il numero di partite perse"); //Scrive su console la stringa.
            bool controllo_3 = int.TryParse(Console.ReadLine(), out partite_perse); //Inizializzo la variabile di tipo bool controllo_3 e le do valore pari al valore ritornato dalla funzione TryParse, che prende in entrata il valore preso dalla funzione Console.ReadLine, restituisce il valore convertito in int e lo inserisce in partite_perse.
            while (!controllo_3 || partite_perse < 0) //Ciclo while, che si avvia se controllo_3 è falso o se la variabile partite_perse è minore di 0.
            {
                Console.WriteLine("Errato. Inserisci il numero di partite perse"); //Scrive su console la stringa.
                controllo_3 = int.TryParse(Console.ReadLine(), out partite_perse); //Do alla variabile di tipo bool controllo e le do valore pari al valore ritornato dalla funzione TryParse, che prende in entrata il valore preso dalla funzione Console.ReadLine, restituisce il valore convertito in int e lo inserisce in partite_perse.
            }
            Console.WriteLine("Inserisci il numero di partite pareggiate"); //Scrive su console la stringa.
            bool controllo_4 = int.TryParse(Console.ReadLine(), out partite_pareggiate); //Inizializzo la variabile di tipo bool controllo_4 e le do valore pari al valore ritornato dalla funzione TryParse, che prende in entrata il valore preso dalla funzione Console.ReadLine, restituisce il valore convertito in int e lo inserisce in partite_pareggiate.
            while (!controllo_4 || partite_pareggiate < 0) //Ciclo while, che si avvia se controllo_4 è falso o se la variabile partite_pareggiate è minore di 0.
            {
                Console.WriteLine("Errato. Inserisci il numero di partite pareggiate"); //Scrive su console la stringa.
                controllo_4 = int.TryParse(Console.ReadLine(), out partite_pareggiate); //Do alla variabile di tipo bool controllo e le do valore pari al valore ritornato dalla funzione TryParse, che prende in entrata il valore preso dalla funzione Console.ReadLine, restituisce il valore convertito in int e lo inserisce in partite_pareggiate.
            }
            Console.WriteLine("Inserisci il numero di gol fatti"); //Scrive su console la stringa.
            bool controllo_5 = int.TryParse(Console.ReadLine(), out gol_fatti); //Inizializzo la variabile di tipo bool controllo_5 e le do valore pari al valore ritornato dalla funzione TryParse, che prende in entrata il valore preso dalla funzione Console.ReadLine, restituisce il valore convertito in int e lo inserisce in gol_fatti.
            while (!controllo_5 || gol_fatti < 0) //Ciclo while, che si avvia se controllo_5 è falso o se la variabile gol_fatti è minore di 0.
            {
                Console.WriteLine("Errato. Inserisci il numero di gol fatti"); //Scrive su console la stringa.
                controllo_5 = int.TryParse(Console.ReadLine(), out gol_fatti); //Do alla variabile di tipo bool controllo e le do valore pari al valore ritornato dalla funzione TryParse, che prende in entrata il valore preso dalla funzione Console.ReadLine, restituisce il valore convertito in int e lo inserisce in gol_fatti.
            }
            Console.WriteLine("Inserisci il numero di gol subiti"); //Scrive su console la stringa.
            bool controllo_6 = int.TryParse(Console.ReadLine(), out gol_subiti); //Inizializzo la variabile di tipo bool controllo_6 e le do valore pari al valore ritornato dalla funzione TryParse, che prende in entrata il valore preso dalla funzione Console.ReadLine, restituisce il valore convertito in int e lo inserisce in gol_subiti.
            while (!controllo_6 || gol_subiti < 0) //Ciclo while, che si avvia se controllo_6 è falso o se la variabile gol_subiti è minore di 0.
            {
                Console.WriteLine("Errato. Inserisci il numero di gol subiti"); //Scrive su console la stringa.
                controllo_6 = int.TryParse(Console.ReadLine(), out gol_subiti); //Do alla variabile di tipo bool controllo e le do valore pari al valore ritornato dalla funzione TryParse, che prende in entrata il valore preso dalla funzione Console.ReadLine, restituisce il valore convertito in int e lo inserisce in gol_subiti.
            } 
            Squadra c = new Squadra(Nome_squadra, partite_vinte, partite_perse, partite_pareggiate, gol_fatti, gol_subiti); //Richiamo la classe Squadra, invio la stringa Nome_squadra e le variabili partite_vinte, partite_perse, partite_pareggiate, gol_fatti, gol_subiti e gli assegno la lettera c.
            Console.Clear(); //Funzione che pulisce la console.
            return c; //Ritorna c.
        }
        public static void Classifica_Punti() //Funzione Classifica_Punti, che mostra la classifica dei punti, attraverso la funzione InsertionSort.
        {
            for(int i = 0; i < InsertionSort(Lista_di_squadre, 0).Count; i++) //Ciclo for che inizializza la variabile di tipo int a cui assegnio il nome i e la pongo pari a 0, che continua fino a quando il valore della i è minore della lunghezza del valore restituito dalla funzione InsertionSort, a cui invio la lista Lista_di_squadre e 0, la i ad ogni ciclo viene incrementata di 1.
            {
                Console.WriteLine(i + 1 + "-" + InsertionSort(Lista_di_squadre, 0)[i].ToString()); //Mostra su console il valore di i incrementato di 1, un "-" e il valore restituito dalla funzione InsertionSort, a cui invio la lista Lista_di_squadre e 0.
            }
        }

        public static void Classifica_gol_fatti() //Funzione Classifica_gol_fatti, che mostra la classifica dei punti, attraverso la funzione InsertionSort.
        {
            for (int i = 0; i < InsertionSort(Lista_di_squadre, 1).Count; i++) //Ciclo for che inizializza la variabile di tipo int a cui assegnio il nome i e la pongo pari a 0, che continua fino a quando il valore della i è minore della lunghezza del valore restituito dalla funzione InsertionSort, a cui invio la lista Lista_di_squadre e 1, la i ad ogni ciclo viene incrementata di 1.
            {
                Console.WriteLine(i + 1 + "-" + InsertionSort(Lista_di_squadre, 1)[i].ToString()); //Mostra su console il valore di i incrementato di 1, un "-" e il valore restituito dalla funzione InsertionSort, a cui invio la lista Lista_di_squadre e 1.
            }
        }

        public static void Classifica_gol_subiti() //Funzione Classifica_gol_subiti, che mostra la classifica dei punti, attraverso la funzione InsertionSort.
        {
            for (int i = 0; i < InsertionSort(Lista_di_squadre, 2).Count; i++) //Ciclo for che inizializza la variabile di tipo int a cui assegnio il nome i e la pongo pari a 0, che continua fino a quando il valore della i è minore della lunghezza del valore restituito dalla funzione InsertionSort, a cui invio la lista Lista_di_squadre e 2, la i ad ogni ciclo viene incrementata di 1.
            {
                Console.WriteLine(i + 1 + "-" + InsertionSort(Lista_di_squadre, 2)[i].ToString()); //Mostra su console il valore di i incrementato di 1, un "-" e il valore restituito dalla funzione InsertionSort, a cui invio la lista Lista_di_squadre e 2.
            }
        }

        static List<Squadra> InsertionSort(List<Squadra> inputArray, int codice) //Funzione InsertionSort, che richiede in ingresso una lista di tipo Squadra inputArray e un codice (0,1,2).
        {
            for (int i = 0; i < inputArray.Count - 1; i++) //Ciclo for che inizializza la variabile di tipo int a cui assegnio il nome i e la pongo pari a 0, che continua fino a quando il valore della i è minore della lunghezza della lista inputArray, la i ad ogni ciclo viene incrementata di 1.
            {
                for (int j = i + 1; j > 0; j--) //Ciclo for che inizializza la variabile di tipo int a cui assegnio il nome j e la pongo pari a i + 1, che continua fino a quando il valore della j è maggiore di 0, la j ad ogni ciclo viene decrementata di 1.
                {
                    if (inputArray[j - 1].CompareTo(inputArray[j], codice) == -1) //Se il valore di inputArray[j - 1].CompareTo(inputArray[j], codice) è uguale a -1, allora...
                    {
                        Squadra temp = inputArray[j - 1]; //inizializzo la variabile di tipo Squadra temp e le assegnio il valore dell'array inputArray[j - 1].
                        inputArray[j - 1] = inputArray[j]; //Do all'array inputArray[j - 1] il valore dell'array inputArray[j].
                        inputArray[j] = temp; //Do all'array inputArray[j] il valore della variabile di tipo Squadra temp.
                    }
                }
            }
            return inputArray; //Ritorna la variabile inputArray.
        }
    }
}
