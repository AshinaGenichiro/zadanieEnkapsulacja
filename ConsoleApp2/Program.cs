using System;

namespace ConsoleApp2
{
    internal class Program
    {
        class Produkt
        {
            private string nazwa;
            private decimal cena;
            private int iloscNaMagazynie;

            public Produkt(string nazwa, decimal cena, int iloscNaMagazynie)
            {
                Nazwa = nazwa;
                Cena = cena;
                IloscNaMagazynie = iloscNaMagazynie;
            }

            public string Nazwa
            {
                get { return nazwa; }
                set
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        nazwa = value;
                    }
                    else
                        throw new ArgumentException("Nazwa nie może byc pusta");
                }
            }
            public decimal Cena
            {
                get { return cena; }
                set
                {
                    if (value > 0)
                    {
                        cena = value;
                    }
                    else
                        throw new ArgumentException("Cena nie moze być mniejsza od zero ");
                }
            }
            public int IloscNaMagazynie
            {
                get { return iloscNaMagazynie; }
                set
                {
                    if (value >= 0)
                    {
                        iloscNaMagazynie = value;
                    }
                    else
                        throw new ArgumentException("Ilośc na magazynie nie może być ujemna");
                }
            }
            public void OpiszProdukt()
            {
                Console.WriteLine($"Produkt: {Nazwa}, Cena : {Cena}, Ilość na magazynie: {IloscNaMagazynie}");
            }
            public decimal ProcentRabatu(int procentRabatu)
            {
                if (procentRabatu >= 0 && procentRabatu <= 100)
                {
                    int rabat = procentRabatu;
                    decimal cenaPoRabacie = cena - (rabat * cena) / 100;
                    return cenaPoRabacie;
                }
                else
                    throw new ArgumentException("Rabat musi znajdować sie w przedziale 0-100%");

            }
            public bool CzyDostepny()
            {
                if (IloscNaMagazynie > 0)
                    return true;
                else
                    return false;

            }
            public int SprzedajSztuki(int ilosc)
            {
                if (ilosc > 0)
                {
                    if (IloscNaMagazynie >= ilosc)
                    {
                        IloscNaMagazynie -= ilosc;
                        Console.WriteLine($"Zostało sprzedanych {ilosc} sztuk, na magazynie zostało {IloscNaMagazynie}");
                    }
                    else
                    {
                        Console.WriteLine($"Próbujesz sprzedać więcej sztuk:{ilosc}, niż jest dostępnych na magaztnie: {IloscNaMagazynie}");
                    }
                }
                else
                    throw new ArgumentException("Ilość nie może być mniejsza bądź równa zero");
                return IloscNaMagazynie;
            }
            static void Main(string[] args)
            {
                Produkt produkt = new Produkt("Laptop", 400, 15);
                produkt.OpiszProdukt();
                Console.WriteLine($"Cena po rabacie 10%: {produkt.ProcentRabatu(10)}");
                Console.WriteLine($"Czy produkt jest dostępny: {produkt.CzyDostepny()}");
                produkt.SprzedajSztuki(12);
            }

        }
    }
}