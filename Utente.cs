
public class Utente
{
    public string Cognome { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Telefono { get; set; }

    public Utente(string cognome, string nome, string email, string password, string telefono)
    {
        this.Cognome = cognome;
        this.Nome = nome;
        this.Email = email;
        this.Password = password;
        this.Telefono = telefono;
    }
}