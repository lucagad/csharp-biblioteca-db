
public class Libro : Prodotto
{
    public int Pagine { get; set; }

    public Libro(string codice, string titolo, int anno, string settore, bool èDisponibile, int scaffale, string autore,int pagine) : base(codice,titolo,anno,settore,èDisponibile,scaffale,autore)    
        {
            this.Pagine = pagine;
        }
}
