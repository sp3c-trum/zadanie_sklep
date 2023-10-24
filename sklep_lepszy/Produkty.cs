using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

class Produkty
{
    public string nazwaProduktu = "";
    public string nazwaProducenta = "";
    public string kategoria = "";
    public string cena = "";
    public string opis = "";

    public Produkty(string nazwaProduktu, string nazwaProducenta, string kategoria, string cena, string opis)
    {
        this.nazwaProduktu = nazwaProduktu;
        this.nazwaProducenta = nazwaProducenta;
        this.kategoria = kategoria;
        this.cena = cena;
        this.opis = opis;
    }

    public void setDane(string nazwaProduktu, string nazwaProducenta, string kategoria, string cena, string opis)
    {
        this.nazwaProduktu = nazwaProduktu;
        this.nazwaProducenta = nazwaProducenta;
        this.kategoria = kategoria;
        this.cena = cena;
        this.opis = opis;
    }
}
