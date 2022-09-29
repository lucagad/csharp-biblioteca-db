
public class Prodotto
{
    public string Codice { get; set; }
    public string Titolo { get; set; }
    public int Anno { get; set; }
    public string Settore { get; set; }
    public bool EDisponibile { get; set; }
    public int Scaffale { get; set; }
    public string Autore{ get; set; }

public Prodotto(string codice, string titolo, int anno, string settore, bool èDisponibile, int scaffale, string autore)
    {
        this.Codice = codice;
        this.Titolo = titolo;
        this.Anno = anno;
        this.Settore = settore;
        this.EDisponibile = èDisponibile;
        this.Scaffale = scaffale;
        this.Autore = autore;
    }
}
