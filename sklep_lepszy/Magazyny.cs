using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Magazyny
{
    public List<Produkty> produkty = new List<Produkty>();
    public Adresy adres;
    public Magazyny(List<Produkty> produkty, Adresy adres)
    {
        this.produkty = produkty;
        this.adres = adres;
    }
}
