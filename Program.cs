//Esercizio:
//Si vuole progettare un sistema per la gestione di una biblioteca. Gli utenti si possono registrare al sistema, fornendo:
//    cognome,
//    nome,
//    email,
//    password,
//    recapito telefonico,

//Gli utenti registrati possono effettuare dei prestiti sui documenti che sono di vario tipo (libri, DVD). I documenti sono caratterizzati da:
//    un codice identificativo di tipo stringa (ISBN per i libri, numero seriale per i DVD),
//    titolo,
//    anno,
//    settore(storia, matematica, economia, …),
//    stato(In Prestito, Disponibile),
//    uno scaffale in cui è posizionato,
//    un autore (Nome, Cognome).

//Per i libri si ha in aggiunta il numero di pagine, mentre per i dvd la durata.

//L’utente deve poter eseguire delle ricerche per codice o per titolo e, eventualmente, effettuare dei prestiti registrando il periodo (Dal/Al) del prestito e il documento.
//Deve essere possibile effettuare la ricerca dei prestiti dato nome e cognome di un utente.

using System.Runtime.ConstrainedExecution;

// Lista di utenti registrati
List<Utente> listaIscritti = new List <Utente>();

// Lista di libri
List <Libro> listaLibri = new List <Libro>();

// Lista di DVD
List <DVD> listaDVD = new List <DVD>();

// Creazione di utenti di test
Utente utente1 = new Utente("Rossi", "Mario","rossi.mario@gmail.com","Password", "0583142536" );
Utente utente2 = new Utente("Rossi", "Paolo", "Rossi.Paolo@gmail.com", "Password", "0583142536");
Utente utente3 = new Utente("Bianchi", "Mario", "Bianchi.Mario@gmail.com", "Password", "0583142536");
listaIscritti.Add(utente1);
listaIscritti.Add(utente2);
listaIscritti.Add(utente3);

// Creazione di libri di test
Libro libro1 = new Libro("1000001", "Titolo Libro 1", 2020, "Fantasy", true, 1,"Autore 1",100);
Libro libro2 = new Libro("1000002", "Titolo Libro 2", 2020, "Thriller", false, 2, "Autore 2", 200);
listaLibri.Add(libro1);
listaLibri.Add(libro2);

// Creazione di DVD di test
DVD DVD1 = new DVD(120, "2000001", "Titolo DVD 1", 2020, "Fantasy", true, 1, "Regista 1");
DVD DVD2 = new DVD(180, "2000002", "Titolo DVD 2", 2020, "Thriller", false, 2, "Regista 2");
listaDVD.Add(DVD1);


int scelta = MenuIniziale();

switch (scelta)
{
    //Stampare Lista Utenti Registrari
    case 1:
        #region
            StampaUtenti();
        break;
    #endregion

    // Stampare Lista Libri
    case 2:
        #region
            StampaLibri();
        break;
    #endregion

    //Stampare Lista DVD
    case 3:
        #region
            StampaDVD();
        break;
    #endregion

    //Prendi in prestito un prodotto
    case 4:

        Console.WriteLine(" ");
        Console.WriteLine("Inserisci il tuo Nome");
        string nome = Console.ReadLine();

        Console.WriteLine(" ");
        Console.WriteLine("Inserisci il tuo Cognome");
        string cognome = Console.ReadLine();

        Console.WriteLine(" ");
        Console.WriteLine("Inserisci la tua Email");
        string email = Console.ReadLine();

        foreach (var utente in listaIscritti)
        {
            if ((utente.Nome == nome) & (utente.Cognome == cognome) & (utente.Email == email))
            {
                Console.WriteLine(" ");
                Console.WriteLine("------------");
                Console.WriteLine("Essendo registrato puoi procedere con la scelta del prodotto!");
                Console.WriteLine(" ");

                // RICHIAMO LA FUNZIONE PER APRIRE IL MENU DI SELEZIONE DEL PRODOTTO LIBRO/DVD
                int sceltaTipoPrestito = MenuTipoPrestito();

                switch (sceltaTipoPrestito)
                {
                    //DVD
                    case 1:

                        // 1 NOME / 2 CODICE
                        int sceltaTipoRicercaDVD = MenuRicercaProdotto();

                        


                        break;

                    // LIBRO
                    case 2:

                        // 1 NOME / 2 CODICE
                        int sceltaTipoRicercaLibro = MenuRicercaProdotto();

                        string chiaveRicercaLibro = InserimentoNomeCodice();

                        if (sceltaTipoRicercaLibro == 1)
                        {
                            CercaLibro(sceltaTipoRicercaLibro, chiaveRicercaLibro);

                        } else if (sceltaTipoRicercaLibro == 2) {

                            CercaLibro(sceltaTipoRicercaLibro, Convert.ToString( chiaveRicercaLibro));
                        }



                        break;

                    default:

                        Console.WriteLine("Scelta non prevista!");
                        break;

                }

            } else{

                Console.WriteLine(" ");
                Console.WriteLine("------------");
                Console.WriteLine("NON essendo registrato NON puoi procedere con la scelta del prodotto!");

                break;
            }
        }

        break;

    default:
        Console.WriteLine("Scelta non prevista!");
        break;
}

// Stampa tutti i Libri del "DB"
void StampaLibri()
{
    Console.WriteLine("------------");
    Console.WriteLine("--- LISTA DEI LIBRI ---");


    foreach (var libro in listaLibri)
    {
        Console.WriteLine(" ");
        Console.WriteLine("------------");
        Console.WriteLine("TITOLO: " + libro.Titolo);
        Console.WriteLine("AUTORE: " + libro.Autore);
        Console.WriteLine("GENERE: " + libro.Settore);
        Console.WriteLine("ANNO: " + libro.Anno);
        Console.WriteLine("PAGINE: " + libro.Pagine);
        Console.WriteLine("SCAFFALE: " + libro.Scaffale);
        if (libro.EDisponibile == true) { Console.WriteLine("DISPONIBILE: SI"); }
        else Console.WriteLine("DISPONIBILE: NO");
        Console.WriteLine("------------");
    }
}

// Stampa tutti i Libri del "DB"
void CercaLibro(int tipoRicerca , string chiaveRicerca)
{
    Console.WriteLine("------------");
    Console.WriteLine("--- RISULTATI RICERCA ---");
    bool risultati = false;

    foreach (var libro in listaLibri)
    {
        if(tipoRicerca == 1){

            if (libro.Titolo == chiaveRicerca)
            {
                Console.WriteLine(" ");
                Console.WriteLine("------------");
                Console.WriteLine("TITOLO: " + libro.Titolo);
                Console.WriteLine("AUTORE: " + libro.Autore);
                Console.WriteLine("GENERE: " + libro.Settore);
                Console.WriteLine("ANNO: " + libro.Anno);
                Console.WriteLine("PAGINE: " + libro.Pagine);
                Console.WriteLine("SCAFFALE: " + libro.Scaffale);
                if (libro.EDisponibile == true) { Console.WriteLine("DISPONIBILE: SI"); }
                else Console.WriteLine("DISPONIBILE: NO");
                Console.WriteLine("------------");
                risultati = true;
                break;

            }

        } else if (tipoRicerca == 2){

            if (libro.Codice == chiaveRicerca)
            {
                Console.WriteLine(" ");
                Console.WriteLine("------------");
                Console.WriteLine("TITOLO: " + libro.Titolo);
                Console.WriteLine("AUTORE: " + libro.Autore);
                Console.WriteLine("GENERE: " + libro.Settore);
                Console.WriteLine("ANNO: " + libro.Anno);
                Console.WriteLine("PAGINE: " + libro.Pagine);
                Console.WriteLine("SCAFFALE: " + libro.Scaffale);
                if (libro.EDisponibile == true) { Console.WriteLine("DISPONIBILE: SI"); }
                else Console.WriteLine("DISPONIBILE: NO");
                Console.WriteLine("------------");
                risultati = true;
                break;
            }
        }

    }

    if(risultati == false)
    {
        Console.WriteLine(" ");
        Console.WriteLine("------------");
        Console.WriteLine("La Ricerca non ha prodotto un risultato");
    }
    
}

// Stampa tutti i DVD del "DB"
void StampaDVD()
{
    Console.WriteLine("------------");
    Console.WriteLine("--- LISTA DEI DVD ---");

    foreach (var dvd in listaDVD)
    {
        Console.WriteLine(" ");
        Console.WriteLine("------------");
        Console.WriteLine("TITOLO: " + dvd.Titolo);
        Console.WriteLine("AUTORE: " + dvd.Autore);
        Console.WriteLine("GENERE: " + dvd.Settore);
        Console.WriteLine("ANNO: " + dvd.Anno);
        Console.WriteLine("DURATA: " + dvd.Durata + " Minuti");
        Console.WriteLine("SCAFFALE: " + dvd.Scaffale);
        if (dvd.EDisponibile == true) { Console.WriteLine("DISPONIBILE: SI"); }
        else Console.WriteLine("DISPONIBILE: NO");
        Console.WriteLine("------------");
    }
}

// Stampa tutti gli utenti registrati
void StampaUtenti()
{
    Console.WriteLine("------------");
    Console.WriteLine("--- LISTA DEGLI UTENTI ---");

    foreach (var utente in listaIscritti)
    {
        Console.WriteLine(" ");
        Console.WriteLine("------------");
        Console.WriteLine("NOME: " + utente.Nome);
        Console.WriteLine("COGNOME: " + utente.Cognome);
        Console.WriteLine("EMAIL: " + utente.Email);
        Console.WriteLine("------------");
    }
}

// Menu inziale
int MenuIniziale()
{
    Console.WriteLine("Benvenuto!");
    Console.WriteLine("Cosa vuoi fare?");
    Console.WriteLine("1 - Stampare Lista Utenti Registrari");
    Console.WriteLine("2 - Stampare Lista Libri");
    Console.WriteLine("3 - Stampare Lista DVD");
    Console.WriteLine("4 - Prendi in prestito un prodotto");

    int sceltaMenu = Convert.ToInt32(Console.ReadLine());

    return sceltaMenu;
}

// Scelta su che tipo di prodotto prendere in prestito Libro/DVD
int MenuTipoPrestito()
{
    Console.WriteLine("Cosa vuoi prendere in prestito?");
    Console.WriteLine("1 - DVD");
    Console.WriteLine("2 - Libro");

    int sceltaMenuPrestito = Convert.ToInt32(Console.ReadLine());

    return sceltaMenuPrestito;
}

// Scelta su come ricercare il prodotto Nome/Codice
int MenuRicercaProdotto()
{
    Console.WriteLine(" ");
    Console.WriteLine("------------");
    Console.WriteLine("Come desideri ricercare il prodotto?");
    Console.WriteLine("1 - Nome");
    Console.WriteLine("2 - Codice Prodotto");

    int sceltaTipoRicerca = Convert.ToInt32(Console.ReadLine());

    return sceltaTipoRicerca;

}


// Inseritmento Nome/Codice
string InserimentoNomeCodice()
{
    Console.WriteLine(" ");
    Console.WriteLine("------------");
    Console.WriteLine("Inserisci la chiave di ricerca: ");

    string chiaveinserita = Console.ReadLine();

    return chiaveinserita;

}