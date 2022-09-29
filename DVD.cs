public class DVD : Prodotto
{
    public int Durata { get; set; }

    public DVD(int durata, string codice, string titolo, int anno, string settore, bool èDisponibile, int scaffale, string autore) : base(codice, titolo, anno, settore, èDisponibile, scaffale, autore)
        {
            this.Durata = durata;
        }
}
