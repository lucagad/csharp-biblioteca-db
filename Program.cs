using System.Data;
using System.Data.SqlClient;
string stringaDiConnessione = "Data Source=localhost;Initial Catalog=db_biblioteca;Persist Security Info=True;User ID=sa;Password=NET2022!";
SqlConnection connessioneSq1 = new SqlConnection(stringaDiConnessione);

int scelta = MenuIniziale();

switch (scelta)
{
    //Stampare Lista Utenti Registrari
    case 1:
        #region
            StampaUtenti();
        break;
    #endregion

    /*// Stampare Lista Libri
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

        break;*/

    default:
        Console.WriteLine("Scelta non prevista!");
        break;
}

// Stampa tutti i Libri del "DB"
/*
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
*/

// Stampa tutti i Libri del "DB"
/*
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
*/

// Stampa tutti i DVD del "DB"
/*
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
*/

// Stampa tutti gli utenti registrati
void StampaUtenti()
{
    try
    {
        connessioneSq1.Open();
        
    } catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    } 
    finally {
        connessioneSq1.Close();
    }

    using (SqlConnection connessioneSql = new SqlConnection(stringaDiConnessione))
    {
        try
        {
            Console.WriteLine("------------");
            Console.WriteLine("--- LISTA DEGLI UTENTI ---");
            connessioneSql.Open();
            // dichiaro la query da eseguire
            string query = "SELECT id,name,surname FROM users";
            // creo il comando ed eseguo la query
            using (SqlCommand cmd = new SqlCommand(query, connessioneSql))
            using (SqlDataReader reader = cmd.ExecuteReader())
                while (reader.Read())
                {
                    ReadSingleRow((IDataRecord)reader);
                }
            Console.WriteLine("------------");

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    static void ReadSingleRow(IDataRecord dataRecord)
    {
        Console.WriteLine(String.Format("{0} | {1} {2}", dataRecord[0], dataRecord[1],dataRecord[2]));
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
/*
int MenuTipoPrestito()
{
    Console.WriteLine("Cosa vuoi prendere in prestito?");
    Console.WriteLine("1 - DVD");
    Console.WriteLine("2 - Libro");

    int sceltaMenuPrestito = Convert.ToInt32(Console.ReadLine());

    return sceltaMenuPrestito;
}
*/

// Scelta su come ricercare il prodotto Nome/Codice

/*
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
*/

// Inseritmento Nome/Codice
/*string InserimentoNomeCodice()
{
    Console.WriteLine(" ");
    Console.WriteLine("------------");
    Console.WriteLine("Inserisci la chiave di ricerca: ");

    string chiaveinserita = Console.ReadLine();

    return chiaveinserita;

}*/