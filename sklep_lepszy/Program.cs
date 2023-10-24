Sklep_lepszy sklep = new Sklep_lepszy();
sklep.menu();

class Sklep_lepszy
{
    List<Produkty> produkty = new List<Produkty>();
    List<Magazyny> magazyny = new List<Magazyny>();
    string input;
    int selector;
    public void menu()
    {
        Console.WriteLine("Wybierz opcję:" +
            "\n1.Dodaj magazyn" +
            "\n2.Edytuj magazyn" +
            "\n3.Usuń magazyn" +
            "\n\n4.Dodaj produkt" +
            "\n5.Edytuj produkt" +
            "\n6.Usuń produkt" +
            "\n\n7.Pokaż produkty" +
            "\n8.Pokaż magazyny");

        input = Console.ReadLine();
        if (Int32.TryParse(input, out selector)) { 
            switch(selector)
            {
                case 1: addMagazyn(); break;
                case 2: editMagazyn(); break;
                case 3: deleteMagazyn(); break;
                case 4: addProdukt(); break;
                case 5: editProdukt(); break;
                case 6: deleteProdukt();  break;
                case 7: showProdukty(true, true); break;
                case 8: showMagazyny(true, true); break;
            }
        } else { menu(); }

    }

    public void addMagazyn()
    {
        Console.Clear();
        List<Produkty> newProdukty = new List<Produkty>();
        Produkty temp;
        Adresy adres = new Adresy("a", "a", "a", "a");
        input = "";
        while (input != "k")
        {
            if (produkty.Count > 0)
            {
                showProdukty(false);
                Console.WriteLine("Wybierz numer produktu który chcess dodać do listy produktów magazynu, lub wpisz k aby zakończyć: ");
                input = Console.ReadLine();
                if (input == "k")
                {
                    magazyny.Add(new Magazyny(newProdukty, adres));
                    Console.Clear();
                    menu();
                }
                else if (Int32.TryParse(input, out selector))
                {
                    temp = produkty.ElementAt(selector);
                    newProdukty.Add(new Produkty(temp.nazwaProduktu, temp.nazwaProducenta, temp.kategoria, temp.cena, temp.opis));
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Nieprawidłowy wybór!");
                    addMagazyn();
                }
            } else
            {
                Console.WriteLine("Brak pdoruktów do dodania! Wciśnij enter aby wrócić");
                Console.ReadLine();
                menu();
            }

        }
        
    }

    public void deleteMagazyn()
    {
        Console.Clear();
        showMagazyny();
        Console.WriteLine("Wybierz numer magazynu do usunięcia: ");
        input = Console.ReadLine();
        if (Int32.TryParse(input, out selector))
        {
            magazyny.RemoveAt(selector);
        }
        else { deleteMagazyn(); }
        Console.Clear();
        menu();
    }

    public void editMagazyn()
    {
        Console.Clear();
        showMagazyny();
        Console.WriteLine("Wybierz numer magazynu do edycji: ");
        input = Console.ReadLine();
        if ((Int32.TryParse(input, out selector))){
            Console.WriteLine("Chcesz usunąć czy dodać produkt (u czy d)?:");
            input = Console.ReadLine();
            Console.Clear();
            if (input == "u")
            {
                Console.WriteLine("Produkty w magazynie:");
                for (int i = 0; i < magazyny[selector].produkty.Count(); i++)
                {
                    Console.WriteLine(i + "." + magazyny[selector].produkty[i].nazwaProduktu);
                }
                Console.WriteLine("Który element chcesz usunąc?");
                input = Console.ReadLine();
                if ((Int32.TryParse(input, out int j)))
                {
                    magazyny.ElementAt(selector).produkty.RemoveAt(j);
                    menu();
                }
                else editMagazyn();
            }
            else if (input == "d")
            {
                while (input != "k")
                {
                    if (produkty.Count > 0)
                    {
                        showProdukty(false);
                        Console.WriteLine("Wybierz numer produktu który chcess dodać do listy produktów magazynu, lub wpisz k aby zakończyć: ");
                        input = Console.ReadLine();
                        if (input == "k")
                        {
                            Console.Clear();
                            menu();
                        }
                        else if (Int32.TryParse(input, out int j))
                        {
                            Produkty temp = produkty.ElementAt(j);
                            magazyny.ElementAt(selector).produkty.Add(new Produkty(temp.nazwaProduktu, temp.nazwaProducenta, temp.kategoria, temp.cena, temp.opis));
                            Console.Clear();
                        }
                        else
                        {
                            editMagazyn();
                        }
                    }
                }
            }
        }
        menu();
    }

    public void addProdukt()
    {
        Console.Clear();
        Console.WriteLine("Nazwa produktu: ");
        string nazwaProduktu = Console.ReadLine();
        Console.WriteLine("Nazwa producenta: ");
        string nazwaProducenta = Console.ReadLine();
        Console.WriteLine("Kategoria: ");
        string kategoria = Console.ReadLine();
        Console.WriteLine("Cena: ");
        string cena = Console.ReadLine();
        Console.WriteLine("Opis: ");
        string opis = Console.ReadLine();
        produkty.Add(new Produkty(nazwaProduktu, nazwaProducenta, kategoria, cena, opis));
        menu();
    }

    public void deleteProdukt()
    {
        Console.Clear();
        showProdukty();
        Console.WriteLine("Wybierz numer produktu do usunięcia: ");
        input = Console.ReadLine();
        if (Int32.TryParse(input, out selector))
        {
            produkty.RemoveAt(selector);
        }
        else { deleteProdukt();  }
        Console.Clear();
        menu(); 
    }

    public void editProdukt()
    {
        Console.Clear();
        if (produkty.Count > 0)
        {
            showProdukty(false);
            Console.WriteLine("Wybierz numer produktu do edycji: ");
            input = Console.ReadLine();

            if (Int32.TryParse(input, out int select) && select  < produkty.Count)
            {
                Console.WriteLine("Nazwa produktu: ");
                string nazwaProduktu = Console.ReadLine();
                Console.WriteLine("Nazwa producenta: ");
                string nazwaProducenta = Console.ReadLine();
                Console.WriteLine("Kategoria: ");
                string kategoria = Console.ReadLine();
                Console.WriteLine("Cena: ");
                string cena = Console.ReadLine();
                Console.WriteLine("Opis: ");
                string opis = Console.ReadLine();
                produkty.ElementAt(select).setDane(nazwaProduktu, nazwaProducenta, kategoria, cena, opis);
                menu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Nieprawidłowy wybór!");
            }
        } else { menu(); }
    }

    public void showProdukty(bool goBack = false, bool verbose = false)
    {
        for (int i = 0; i < produkty.Count; i++)
        {
            Console.WriteLine(i + "." + produkty[i].nazwaProduktu);
            if (verbose == true)
            {
                Console.WriteLine("Producent: " + produkty[i].nazwaProducenta);
                Console.WriteLine("Kategoria: " + produkty[i].kategoria);
                Console.WriteLine("Cena: " + produkty[i].cena);
                Console.WriteLine("Opis: " + produkty[i].opis);
                Console.WriteLine();
            }

        }
        Console.WriteLine();
        if (goBack)
        {
            menu();
        }
    }

    public void showMagazyny(bool goBack = false, bool verbose = false)
    {
        for (int i = 0; i < magazyny.Count; i++)
        {
            Console.WriteLine("Magazyn " + i);
            if(verbose == true)
            {
                for (int j = 0; j < magazyny[i].produkty.Count(); j++)
                {
                    Console.WriteLine(magazyny[i].produkty[j].nazwaProduktu);
                }
            }
        }
        Console.WriteLine();
        if (goBack)
        {
            menu();
        }
    }
}

