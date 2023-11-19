
using System.Collections.Generic;
using System.Net.Http.Headers;

static void PrviPut(bool prviput)
{
    if (!prviput)
    {
        Console.WriteLine("Nepravilan unos, pokusajte ponovo");
        Console.WriteLine("");
    }
}
static float Zbroj(List<string> arti, List<string> kolic, Dictionary<string, List<string>> artikli)
{
    var zbr = 0.0f;
    for (int i = 0; i < arti.Count; i++)
    {
        zbr += int.Parse(artikli[arti[i]][1]) * int.Parse(kolic[i]);
    }
    return zbr;
}

var banana = new List<string>() { "5", "1", "2023/11/25" };
var cokolada = new List<string>() { "2", "2.5", "2023/12/2" };
var jogurt = new List<string>() { "3", "1.5", "1998/2/8" };
var artikli = new Dictionary<string, List<string>>()
{
    {"banana", banana },
    {"jogurt", jogurt },
    {"cokolada", cokolada }
};

var radnici = new Dictionary<string, string>()
{
    {"Mate Matic", "2000/1/1" },
    {"Ante Antic", "1995/9/8" },
    {"Ivo Ivic", "2003/7/17" }
};


Tuple<List<string>, List<string>> ban = new Tuple<List<string>, List<string>>(new List<string> { "banana" }, new List<string> { "1" });
Tuple<int, string, float> dtm = new Tuple<int, string, float>(1, Convert.ToString(DateTime.Parse("2022, 10, 10")), 1);
//string dtm = Convert.ToString(DateTime.Parse("2022, 10, 10"));
var racuni = new Dictionary<Tuple<int, string, float>, Tuple<List<string>, List<string>>>()
{
    {dtm, ban }
};



var izbor = "";
//ARTIKLI ISPIS NAJPRODAVANIJI
while (izbor != "0")
{
    var flag = false;
    var prviput = true;
    var potvrda = "";
    var los_unos = false;
    Console.WriteLine("1 - Artikli");
    Console.WriteLine("2 - Radnici");
    Console.WriteLine("3 - Racuni");
    Console.WriteLine("4 - Statistika");
    Console.WriteLine("0 - Izlaz iz aplikacije");

    izbor = Console.ReadLine();
    switch (izbor)
    {
        case "0":
            break;
        case "1":
            string artikli_izbor = "";
            while (prviput || flag == false)
            {
                Console.Clear();
                Console.WriteLine("> Artikli");
                Console.WriteLine("");
                PrviPut(prviput);
                prviput = false;
                Console.WriteLine("1 - Unos artikla");
                Console.WriteLine("2 - Brisanje artikla");
                Console.WriteLine("3 - Uredivanje artikla");
                Console.WriteLine("4 - Ispis");
                Console.WriteLine("0 - Glavni meni");
                artikli_izbor = Console.ReadLine();
                if (artikli_izbor == "0" || artikli_izbor == "1" || artikli_izbor == "2" || artikli_izbor == "3" || artikli_izbor == "4")
                    flag = true;
            }
            switch (artikli_izbor)
            {
                case "1":
                    
                    var ime = "";
                    var ime_flag = false;
                    prviput = true;
                    flag = false;
                    while (prviput || ime_flag == false)
                    {
                        Console.Clear();
                        Console.WriteLine("> Artikli > Unos artikla");
                        Console.WriteLine("");
                        PrviPut(prviput);
                        prviput = false;
                        Console.WriteLine("Unesite ime artikla (za vratiti se na glavni meni, ostavite prazno): ");
                        ime = Console.ReadLine();
                        if (ime == "")
                        {
                            Console.Clear();
                            flag = true;
                            break;
                        }
                        ime_flag = true;
                        foreach (var item in artikli)
                        {
                            if (item.Key == ime)
                            {
                                ime_flag = false;
                                break;
                            }
                        }
                    }
                    if (flag)
                        continue;

                    var skolicina = "";
                    var kolicina = -1;
                    prviput = true;
                    while (kolicina < 0) {
                        Console.Clear();
                        PrviPut(prviput);
                        prviput = false;
                        Console.WriteLine("Unesite kolicinu artikala (za vratiti se na glavni meni, ostavite prazno): ");
                        
                        skolicina = Console.ReadLine();
                        if (skolicina == "")
                        {
                            Console.Clear();
                            flag = true;
                            break;
                        }
                        int.TryParse(skolicina, out kolicina);
                    }
                    if (flag)
                        continue;

                    var scijena = "";
                    var cijena = -1.0f;
                    prviput = true;
                    while(cijena < 0) 
                    {
                        Console.Clear();
                        PrviPut(prviput);
                        prviput = false;
                        Console.WriteLine("Unesite cijenu artikla (za vratiti se na glavni meni, ostavite prazno): ");
                        scijena = Console.ReadLine();
                        if (scijena == "")
                        {
                            Console.Clear();
                            flag = true;
                            break;
                        }
                        cijena = -1.0f;
                        float.TryParse(scijena, out cijena);
                    }
                    
                    if (flag)
                        continue;

                    DateTime datum;
                    string sdatum = "0";
                    prviput = true;
                    while (!(DateTime.TryParse(sdatum, out datum)))
                    {
                        Console.Clear();
                        PrviPut(prviput);
                        prviput = false;
                        Console.WriteLine("Unesite datum isteka (format: 'godina/mjesec/dan') (za vratiti se na glavni meni, ostavite prazno): ");
                        sdatum = Console.ReadLine();
                        if (sdatum == "")
                        {
                            Console.Clear();
                            flag = true;
                            break; 
                        }
                        
                    }
                    if (flag)
                        continue;


                    potvrda = "";
                    prviput = true;
                    while ((potvrda != "1") && (potvrda != "0"))
                    {
                        Console.Clear();
                        PrviPut(prviput);
                        prviput = false;
                        Console.WriteLine($"Jeste li sigurni da želite unijeti artikl {ime}({kolicina}) - {cijena} - {sdatum}?");
                        Console.WriteLine("1 - Da");
                        Console.WriteLine("0 - Ne");
                        potvrda = Console.ReadLine();
                    }

                    if (potvrda == "1")
                    {
                        var temp_list = new List<string>() { skolicina, scijena, sdatum };
                        artikli.Add(ime, temp_list);
                        Console.Clear();
                        Console.WriteLine("Artikl uspjesno unesen!");
                        Console.WriteLine("");
                        continue;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Artikl nije unesen");
                        Console.WriteLine("");
                        continue;
                    }
                    
                case "2":
                    
                    string bris_izbor = "";
                    flag = false;
                    prviput = true;
                    while (bris_izbor != "0" && bris_izbor != "1" && bris_izbor != "2")
                    {
                        Console.Clear();
                        Console.WriteLine("> Artikli > Brisanje artikla");
                        Console.WriteLine("");
                        PrviPut(prviput); 
                        prviput = false;
                        Console.WriteLine("1 - Po imenu artikla");
                        Console.WriteLine("2 - Svi artikli kojima je istekao rok trajanja");
                        Console.WriteLine("0 - Glavni meni");
                        bris_izbor = Console.ReadLine();
                    }
                    switch (bris_izbor)
                    {
                        case "1":
                            prviput = true;
                            flag = false;
                            string bris_ime;
                            while (prviput == true || flag == false)
                            {
                                Console.Clear();
                                Console.WriteLine("> Artikli > Brisanje artikla > Po imenu artikla");
                                Console.WriteLine("");
                                if(!prviput)
                                {
                                    Console.WriteLine("Artikl nije pronaden, pokusajte ponovo");
                                    Console.WriteLine("");
                                }
                                prviput = false;

                                Console.WriteLine("Unesite ime artikla kojeg zelite izbrisati (za vratiti se na glavni meni, ostavite prazno)");
                                foreach (var item in artikli)
                                {
                                    Console.WriteLine($"    - {item.Key}");
                                }
                                bris_ime = Console.ReadLine();
                                if (bris_ime == "")
                                {
                                    Console.Clear();
                                    break;
                                }
                                foreach (var item in artikli)
                                {
                                    if (bris_ime == item.Key)
                                    {
                                        potvrda = "";
                                        prviput = true;
                                        while ((potvrda != "1") && (potvrda != "0"))
                                        {
                                            Console.Clear();
                                            Console.WriteLine("> Artikli > Brisanje artikla > Po imenu artikla");
                                            Console.WriteLine("");
                                            PrviPut(prviput);
                                            prviput = false;
                                            Console.WriteLine($"Jeste li sigurni da zelite izbrisati artikl {bris_ime}?");
                                            Console.WriteLine("1 - Da");
                                            Console.WriteLine("0 - Ne");
                                            potvrda = Console.ReadLine();
                                        }
                                        if (potvrda == "1")
                                        {
                                            artikli.Remove(bris_ime);
                                            Console.Clear();
                                            Console.WriteLine("Artikl uspjesno izbrisan!");
                                            Console.WriteLine("");
                                            flag = true;
                                            break;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Artikl nije izbrisan");
                                            Console.WriteLine("");
                                            flag = true;
                                            break;
                                        }
                                        
                                    }
                                }

                            }
                            break;

                        case "2":
                            prviput = true;
                            potvrda = "";
                            while ((potvrda != "1") && (potvrda != "0"))
                            {
                                Console.Clear();
                                PrviPut(prviput);
                                prviput = false;
                                Console.WriteLine("Jeste li sigurni da zelite izbrisati sve artikle kojima je istekao rok trajanja ?");
                                Console.WriteLine("1 - Da");
                                Console.WriteLine("0 - Ne");
                                potvrda = Console.ReadLine();
                            }
                            if (potvrda == "1")
                            {
                                foreach (var item in artikli)
                                {
                                    DateTime sad = DateTime.Now;
                                    DateTime rok = Convert.ToDateTime(item.Value[2]);
                                    if (rok < sad)
                                        artikli.Remove(item.Key);

                                }
                                Console.Clear();
                                Console.WriteLine("Artikli uspjesno izbrisani!");
                                Console.WriteLine("");
                                continue;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Artikli nisu izbrisani");
                                Console.WriteLine("");
                                continue;
                            }
                            break;

                        case "0":
                            Console.Clear();
                            continue;
                            
                    }
                    break;

                case "3":
                    var ured_izbor = "";
                    prviput = true;
                    flag = false;
                    while (ured_izbor != "0" && ured_izbor != "1" && ured_izbor != "2")
                    {
                        Console.Clear();
                        Console.WriteLine("> Artikli > Uredivanje artikla");
                        PrviPut(prviput);
                        prviput = false;
                        Console.WriteLine("");
                        Console.WriteLine("1 - Pojedinacno");
                        Console.WriteLine("2 - Promjena cijene svih artikala");
                        Console.WriteLine("0 - Glavni meni");
                        ured_izbor = Console.ReadLine();
                    }

                    switch (ured_izbor)
                    {
                        case "1":
                            prviput = true;
                            flag = false;
                            string ured_ime;
                            while ((prviput == true) || (flag == false))
                            {
                                Console.Clear();
                                Console.WriteLine("> Artikli > Uredivanje artikla > Pojedinacno");
                                Console.WriteLine("");
                                PrviPut(prviput);
                                prviput = false;

                                Console.WriteLine("Unesite ime artikla cije podatke zelite urediti (za vratiti se na glavni meni, ostavite prazno): ");
                                foreach (var item in artikli)
                                {
                                    Console.WriteLine($"    - {item.Key}");
                                }
                                ured_ime = Console.ReadLine();
                                if (ured_ime == "")
                                {
                                    Console.Clear();
                                    break;
                                }
                                foreach (var item in artikli)
                                {
                                    if (ured_ime == item.Key)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("> Artikli > Uredivanje artikla > Pojedinacno");
                                        Console.WriteLine("");
                                        Console.WriteLine($"Unesite koji podatak zelite urediti artiklu {ured_ime} (za vratiti se na glavni meni, ostavite prazno):");
                                        Console.WriteLine($"k - kolicina ({item.Value[0]})");
                                        Console.WriteLine($"c - cijena ({item.Value[1]})");
                                        Console.WriteLine($"d - datum isteka ({item.Value[2]})");

                                        var podatak_izbor = Console.ReadLine();
                                        if (podatak_izbor == "")
                                        {
                                            Console.Clear();
                                            flag = true;
                                            break;
                                        }
                                        while (podatak_izbor != "k" && podatak_izbor != "c" && podatak_izbor != "d")
                                        {
                                            Console.Clear();
                                            Console.WriteLine("> Artikli > Uredivanje artikla > Pojedinacno");
                                            Console.WriteLine("");
                                            Console.WriteLine("Nepravilan unos, pokusajte ponovo");
                                            Console.WriteLine("");
                                            Console.WriteLine($"Unesite koji podatak zelite urediti artiklu {ured_ime} (za vratiti se na glavni meni, ostavite prazno):");
                                            Console.WriteLine($"k - kolicina ({item.Value[0]})");
                                            Console.WriteLine($"c - cijena ({item.Key[1]})");
                                            Console.WriteLine($"d - datum isteka ({item.Value[2]})");
                                            podatak_izbor = Console.ReadLine();
                                            if (podatak_izbor == "")
                                            {
                                                Console.Clear();
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (flag)
                                            break;
                                        string ured_potvrda;
                                        switch (podatak_izbor)
                                        {
                                            case "k":
                                                Console.Clear();
                                                Console.WriteLine("> Artikli > Uredivanje artikla > Pojedinacno > Kolicina");
                                                Console.WriteLine("");
                                                Console.WriteLine($"Trenutna kolicina artikla {item.Key} je {item.Value[0]}. Unesite novu kolicinu artikla (za vratiti se na glavni meni, ostavite prazno):");
                                                var snova_kolicina = Console.ReadLine();
                                                if (snova_kolicina == "")
                                                {
                                                    Console.Clear();
                                                    flag = true;
                                                    break;
                                                }
                                                var nova_kolicina = -1;
                                                int.TryParse(snova_kolicina, out nova_kolicina);
                                                while (nova_kolicina < 0)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("> Artikli > Uredivanje artikla > Pojedinacno > Kolicina");
                                                    Console.WriteLine("");
                                                    Console.WriteLine("Nepravilan unos, pokusajte ponovo");
                                                    Console.WriteLine("");
                                                    Console.WriteLine($"Trenutna kolicina artikla {item.Key} je {item.Value[0]}. Unesite novu kolicinu artikla (za vratiti se na glavni meni, ostavite prazno):");
                                                    snova_kolicina = Console.ReadLine();
                                                    if (snova_kolicina == "")
                                                    {
                                                        Console.Clear();
                                                        flag = true;
                                                        break;
                                                    }
                                                    int.TryParse(snova_kolicina, out nova_kolicina);
                                                }
                                                if (flag)
                                                    break;

                                                Console.Clear();
                                                Console.WriteLine("> Artikli > Uredivanje artikla > Pojedinacno > Kolicina");
                                                Console.WriteLine("");
                                                Console.WriteLine($"Jeste li sigurni da artiklu {item.Key} zelite promijeniti kolicinu s {item.Value[0]} na {snova_kolicina}?");
                                                Console.WriteLine("1 - Da");
                                                Console.WriteLine("0 - Ne");
                                                potvrda = Console.ReadLine();
                                                while (potvrda != "1" && potvrda != "0")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("> Artikli > Uredivanje artikla > Pojedinacno > Kolicina");
                                                    Console.WriteLine("");
                                                    Console.WriteLine("Nepravilan unos, pokusajte ponovo");
                                                    Console.WriteLine($"Jeste li sigurni da artiklu {item.Key} zelite promijeniti kolicinu s {item.Value[0]} na {snova_kolicina}?");
                                                    Console.WriteLine("1 - Da");
                                                    Console.WriteLine("0 - Ne");
                                                    potvrda = Console.ReadLine();
                                                }
                                                switch (potvrda)
                                                {
                                                    case "1":
                                                        artikli[item.Key][0] = snova_kolicina;
                                                        Console.Clear();
                                                        Console.WriteLine("Artikl uspjesno ureden!");
                                                        Console.WriteLine("");
                                                        flag = true;
                                                        break;
                                                    case "0":
                                                        Console.Clear();
                                                        Console.WriteLine("Artikl nije ureden");
                                                        Console.WriteLine("");
                                                        flag = true;
                                                        break;
                                                }

                                                break;

                                            case "c":
                                                Console.Clear();
                                                Console.WriteLine("> Artikli > Uredivanje artikla > Pojedinacno > Cijena");
                                                Console.WriteLine("");
                                                Console.WriteLine($"Trenutna cijena artikla {item.Key} je {item.Value[1]}. Unesite novu cijenu artikla (za vratiti se na glavni meni, ostavite prazno):");
                                                var snova_cijena = Console.ReadLine();
                                                if (snova_cijena == "")
                                                {
                                                    Console.Clear();
                                                    flag = true;
                                                    break;
                                                }
                                                var nova_cijena = -1.0f;
                                                float.TryParse(snova_cijena, out nova_cijena);
                                                while (nova_cijena < 0)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("> Artikli > Uredivanje artikla > Pojedinacno > Cijena");
                                                    Console.WriteLine("");
                                                    Console.WriteLine("Nepravilan unos, pokusajte ponovo");
                                                    Console.WriteLine($"Trenutna cijena artikla {item.Key} je {item.Value[1]}. Unesite novu cijenu artikla (za vratiti se na glavni meni, ostavite prazno):");
                                                    snova_cijena = Console.ReadLine();
                                                    if (snova_cijena == "")
                                                    {
                                                        Console.Clear();
                                                        flag = true;
                                                        break;
                                                    }
                                                    float.TryParse(snova_cijena, out nova_cijena);
                                                }
                                                if (flag)
                                                    break;

                                                Console.Clear();
                                                Console.WriteLine("> Artikli > Uredivanje artikla > Pojedinacno > Cijena");
                                                Console.WriteLine("");
                                                Console.WriteLine($"Jeste li sigurni da artiklu {item.Key} zelite promijeniti kolicinu s {item.Value[1]} na {snova_cijena}?");
                                                Console.WriteLine("1 - Da");
                                                Console.WriteLine("0 - Ne");
                                                potvrda = Console.ReadLine();
                                                while (potvrda != "1" && potvrda != "0")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("> Artikli > Uredivanje artikla > Pojedinacno > Cijena");
                                                    Console.WriteLine("");
                                                    Console.WriteLine("Nepravilan unos, pokusajte ponovo");
                                                    Console.WriteLine($"Jeste li sigurni da artiklu {item.Key} zelite promijeniti kolicinu s {item.Value[1]} na {snova_cijena}?");
                                                    Console.WriteLine("1 - Da");
                                                    Console.WriteLine("0 - Ne");
                                                    potvrda = Console.ReadLine();
                                                }
                                                switch (potvrda)
                                                {
                                                    case "1":
                                                        artikli[item.Key][1] = snova_cijena;
                                                        Console.Clear();
                                                        Console.WriteLine("Artikl uspjesno ureden!");
                                                        Console.WriteLine("");
                                                        flag = true;
                                                        break;
                                                    case "0":
                                                        Console.Clear();
                                                        Console.WriteLine("Artikl nije ureden");
                                                        Console.WriteLine("");
                                                        flag = true;
                                                        break;
                                                }

                                                break;

                                            case "d":
                                                Console.Clear();
                                                Console.WriteLine("> Artikli > Uredivanje artikla > Pojedinacno > Datum isteka");
                                                Console.WriteLine("");
                                                Console.WriteLine($"Trenutni datum isteka artikla {item.Key} je {item.Value[2]}. Unesite novi datum isteka (format: 'godina/mjesec/dan') (za vratiti se na glavni meni, ostavite prazno):");
                                                var snovi_datum = Console.ReadLine();
                                                if (snovi_datum == "")
                                                {
                                                    Console.Clear();
                                                    flag = true;
                                                    break;
                                                }
                                                DateTime novi_datum;
                                                while (!(DateTime.TryParse(snovi_datum, out novi_datum)))
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("> Artikli > Uredivanje artikla > Pojedinacno > Datum isteka");
                                                    Console.WriteLine("");
                                                    Console.WriteLine("Nepravilan unos, pokusajte ponovo");
                                                    Console.WriteLine("");
                                                    Console.WriteLine($"Trenutni datum isteka artikla {item.Key} je {item.Value[2]}. Unesite novi datum isteka (format: 'godina/mjesec/dan') (za vratiti se na glavni meni, ostavite prazno):");

                                                    snovi_datum = Console.ReadLine();
                                                    if (snovi_datum == "")
                                                    {
                                                        Console.Clear();
                                                        flag = true;
                                                        break;
                                                    }                                                    
                                                }
                                                Console.Clear();
                                                Console.WriteLine("> Artikli > Uredivanje artikla > Pojedinacno > Datum isteka");
                                                Console.WriteLine("");
                                                Console.WriteLine($"Jeste li sigurni da artiklu {item.Key} zelite promijeniti datum isteka s {item.Value[2]} na {snovi_datum}?");
                                                Console.WriteLine("1 - Da");
                                                Console.WriteLine("0 - Ne");
                                                potvrda = Console.ReadLine();
                                                while (potvrda != "1" && potvrda != "0")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("> Artikli > Uredivanje artikla > Pojedinacno > Datum isteka");
                                                    Console.WriteLine("");
                                                    Console.WriteLine("Nepravilan unos, pokusajte ponovo");
                                                    Console.WriteLine($"Jeste li sigurni da artiklu {item.Key} zelite promijeniti kolicinu s {item.Value[2]} na {snovi_datum}?");
                                                    Console.WriteLine("1 - Da");
                                                    Console.WriteLine("0 - Ne");
                                                    potvrda = Console.ReadLine();
                                                }
                                                switch (potvrda)
                                                {
                                                    case "1":
                                                        artikli[item.Key][2] = snovi_datum;
                                                        Console.Clear();
                                                        Console.WriteLine("Artikl uspjesno ureden!");
                                                        Console.WriteLine("");
                                                        flag = true;
                                                        break;
                                                    case "0":
                                                        Console.Clear();
                                                        Console.WriteLine("Artikl nije ureden");
                                                        Console.WriteLine("");
                                                        flag = true;
                                                        break;
                                                }

                                                break;
                                        }
                                        if (flag)
                                            break;
                                    }


                                }
                            }
                            if (flag)
                                continue;
                            break;

                        case "2":
                            var spromjena = "";
                            if (spromjena == "")
                            {
                                Console.Clear();
                                continue;
                            }
                            float promjena;
                            float.TryParse(spromjena, out promjena);
                            prviput = true;
                            while (promjena < -100)
                            {
                                Console.Clear();
                                Console.WriteLine("> Artikli > Uredivanje artikla > Svi");
                                Console.WriteLine("");
                                PrviPut(prviput);
                                prviput = false;
                                Console.WriteLine("Unesite postotak za koji se mijenja cijena svakog prizvoda. (za vratiti se na glavni meni, ostavite prazno)");
                                Console.WriteLine("npr. ako zelite 25% popusta, unesite '-20':");
                                
                                
                                spromjena = Console.ReadLine();
                                if (spromjena == "")
                                {
                                    Console.Clear();
                                    flag = true;
                                    break;
                                }
                                float.TryParse(spromjena, out promjena);
                            }

                            potvrda = "";
                            while ((potvrda != "1") && (potvrda != "0"))
                            {
                                Console.Clear();
                                PrviPut(prviput);
                                prviput = false;
                                Console.WriteLine($"Jeste li sigurni da zelite promijeniti cijene svih artikala za {promjena}%?");
                                Console.WriteLine("1 - Da");
                                Console.WriteLine("0 - Ne");
                                potvrda = Console.ReadLine();
                            }
                            if(potvrda == "1")
                            {
                                foreach (var item in artikli)
                                {
                                    var prva_cijena = float.Parse(artikli[item.Key][2]);

                                    artikli[item.Key][2] = Convert.ToString(prva_cijena + prva_cijena * promjena);
                                }
                                Console.Clear();
                                Console.WriteLine("Uspjesno promijenjene cijene svih artikala!");
                                Console.WriteLine("");
                                continue;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Cijene svih artikala nisu promijenjene");
                                Console.WriteLine("");
                                continue;
                            }
                          

                        case "0":
                            Console.Clear();
                            continue;
                            
                    }
                    break;

                case "4":
                    
                    flag = false;
                    prviput = true;
                    var ispis_izbor = "";

                    while (ispis_izbor!="1" && ispis_izbor != "2" && ispis_izbor != "3" && ispis_izbor != "4" && ispis_izbor != "5" && ispis_izbor != "6" && ispis_izbor != "7")
                    {
                        Console.Clear();
                        Console.WriteLine("> Artikli > Ispis");
                        Console.WriteLine("");
                        PrviPut(prviput);
                        prviput = false;
                        Console.WriteLine("1 - Svi artikli");
                        Console.WriteLine("2 - Po imenu");
                        Console.WriteLine("3 - Po datumu isteka (silazno)");
                        Console.WriteLine("4 - Po datumu isteka (uzlazno)");
                        Console.WriteLine("5 - Po kolicini");
                        Console.WriteLine("6 - Najprodavaniji artikl");
                        Console.WriteLine("7 - Najmanje prodavan artikl");

                        ispis_izbor = Console.ReadLine();
                    }

                    var cekanje = "";

                    List<string> svi_datumi = new List<string>();
                    foreach (var item in artikli)
                    {
                        svi_datumi.Add(artikli[item.Key][2]);
                    }
                    svi_datumi.Sort();

                    switch (ispis_izbor)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("> Artikli > Ispis > Svi artikli");
                            Console.WriteLine("");
                            foreach (var item in artikli)
                            {
                                var razlika = DateTime.Parse(item.Value[2]) - DateTime.Now;
                                var dani = (int)razlika.TotalDays;
                                Console.WriteLine($"{item.Key}({item.Value[0]}) - {item.Value[1]} - {dani}");
                            }
                            Console.WriteLine("");
                            Console.WriteLine("Za vratiti se na glavni meni, unesite bilo sto:");
                            cekanje = Console.ReadLine();
                            Console.Clear();
                            continue;

                        case "2":
                            Console.Clear();
                            Console.WriteLine("> Artikli > Ispis > Svi artikli");
                            Console.WriteLine("");
                            List<string> sva_imena = new List<string>();
                            foreach (var item in artikli)
                            {
                                sva_imena.Add(item.Key);
                            }
                            sva_imena.Sort();
                            foreach (var item in sva_imena)
                            {
                                Console.WriteLine(item);
                            }

                            Console.WriteLine("");
                            Console.WriteLine("Za vratiti se na glavni meni, unesite bilo sto:");
                            cekanje = Console.ReadLine();
                            Console.Clear();
                            continue;

                        case "3":
                            Console.Clear();
                            Console.WriteLine("> Artikli > Ispis > Po datumu isteka (silazno)");
                            Console.WriteLine("");

                            svi_datumi.Reverse();
                            foreach (var item in svi_datumi)
                            {
                                foreach (var artikl in artikli)
                                {
                                    if (artikli[artikl.Key][2] == item)
                                    {
                                        Console.WriteLine($"{artikl.Key} - {item}");
                                        break;
                                    }
                                }
                                
                            }

                            Console.WriteLine("");
                            Console.WriteLine("Za vratiti se na glavni meni, unesite bilo sto:");
                            cekanje = Console.ReadLine();
                            Console.Clear();
                            continue;

                        case "4":
                            Console.Clear();
                            Console.WriteLine("> Artikli > Ispis > Po datumu isteka (uzlazno)");
                            Console.WriteLine("");

                            foreach (var item in svi_datumi)
                            {
                                foreach (var artikl in artikli)
                                {
                                    if (artikli[artikl.Key][2] == item)
                                    {
                                        Console.WriteLine($"{artikl.Key} - {item}");
                                        break;
                                    }
                                }
                            }

                            Console.WriteLine("");
                            Console.WriteLine("Za vratiti se na glavni meni, unesite bilo sto:");
                            cekanje = Console.ReadLine();
                            Console.Clear();
                            continue;

                        case "5":
                            Console.Clear();
                            Console.WriteLine("> Artikli > Ispis > Po kolicini");
                            Console.WriteLine("");

                            List<int> sve_kolicine = new List<int>();
                            foreach (var item in artikli)
                            {
                                sve_kolicine.Add(int.Parse(artikli[item.Key][0]));
                            }
                            sve_kolicine.Sort();

                            foreach (var item in sve_kolicine)
                            {
                                foreach (var artikl in artikli)
                                {
                                    if (int.Parse(artikli[artikl.Key][0]) == item)
                                    {
                                        Console.WriteLine($"{artikl.Key} - {item}");
                                        break;
                                    }
                                }
                            }


                            Console.WriteLine("");
                            Console.WriteLine("Za vratiti se na glavni meni, unesite bilo sto:");
                            cekanje = Console.ReadLine();
                            Console.Clear();
                            continue;

                        case "6":
                            Console.Clear();
                            Console.WriteLine("> Artikli > Ispis > Najprodavaniji");
                            Console.WriteLine("");

                            Console.WriteLine("");
                            Console.WriteLine("Za vratiti se na glavni meni, unesite bilo sto:");
                            cekanje = Console.ReadLine();
                            Console.Clear();
                            continue;

                        case "7":
                            Console.Clear();
                            Console.WriteLine("> Artikli > Ispis > Najmanje prodavan");
                            Console.WriteLine("");

                            Console.WriteLine("");
                            Console.WriteLine("Za vratiti se na glavni meni, unesite bilo sto:");
                            cekanje = Console.ReadLine();
                            Console.Clear();
                            continue;
                    }
                    continue;
                    

                case "0":
                    Console.Clear();
                    continue;
            }

            break;
        
        case "2":
            string radnici_izbor = "";
            while (prviput || flag == false)
            {
                Console.Clear();
                Console.WriteLine("> Radnici");
                Console.WriteLine("");
                PrviPut(prviput);
                prviput = false;
                Console.WriteLine("1 - Unos radnika");
                Console.WriteLine("2 - Brisanje radnika");
                Console.WriteLine("3 - Uredivanje radnika");
                Console.WriteLine("4 - Ispis");
                Console.WriteLine("0 - Glavni meni");
                radnici_izbor = Console.ReadLine();
                if (radnici_izbor == "0" || radnici_izbor == "1" || radnici_izbor == "2" || radnici_izbor == "3" || radnici_izbor == "4")
                    flag = true;
            }
            switch (radnici_izbor)
            {
                case "1":

                    var ime = "";
                    var ime_flag = false;
                    prviput = true;
                    flag = false;
                    while (prviput || ime_flag == false)
                    {
                        Console.Clear();
                        Console.WriteLine("> Radnici > Unos radnika");
                        Console.WriteLine("");
                        PrviPut(prviput);
                        prviput = false;
                        Console.WriteLine("Unesite ime i prezime radnika (za vratiti se na glavni meni, ostavite prazno): ");
                        ime = Console.ReadLine();
                        if (ime == "")
                        {
                            Console.Clear();
                            flag = true;
                            break;
                        }
                        ime_flag = true;
                        foreach (var item in radnici)
                        {
                            if (item.Key == ime)
                            {
                                ime_flag = false;
                                break;
                            }
                        }
                    }
                    if (flag)
                        continue;

                    DateTime datum;
                    string sdatum = "0";
                    prviput = true;
                    while (!(DateTime.TryParse(sdatum, out datum)))
                    {
                        Console.Clear();
                        Console.WriteLine("> Radnici > Unos radnika");
                        Console.WriteLine("");
                        PrviPut(prviput);
                        prviput = false;
                        Console.WriteLine("Unesite datum rodenja radnika (format: 'godina/mjesec/dan') (za vratiti se na glavni meni, ostavite prazno): ");
                        sdatum = Console.ReadLine();
                        if (sdatum == "")
                        {
                            Console.Clear();
                            flag = true;
                            break;
                        }

                    }
                    if (flag)
                        continue;


                    potvrda = "";
                    prviput = true;
                    while ((potvrda != "1") && (potvrda != "0"))
                    {
                        Console.Clear();
                        PrviPut(prviput);
                        prviput = false;
                        Console.WriteLine($"Jeste li sigurni da želite unijeti radnika {ime} - {sdatum}?");
                        Console.WriteLine("1 - Da");
                        Console.WriteLine("0 - Ne");
                        potvrda = Console.ReadLine();
                    }

                    if (potvrda == "1")
                    {
                        
                        radnici.Add(ime, sdatum);
                        Console.Clear();
                        Console.WriteLine("Radnik uspjesno unesen!");
                        Console.WriteLine("");
                        continue;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Radnik nije unesen");
                        Console.WriteLine("");
                        continue;
                    }

                case "2":

                    string bris_izbor = "";
                    flag = false;
                    prviput = true;
                    while (bris_izbor != "0" && bris_izbor != "1" && bris_izbor != "2")
                    {
                        Console.Clear();
                        Console.WriteLine(">Radnici > Brisanje radnika");
                        Console.WriteLine("");
                        PrviPut(prviput);
                        prviput = false;
                        Console.WriteLine("1 - Po imenu radnika");
                        Console.WriteLine("2 - Svi radnici stariji od 65 godina");
                        Console.WriteLine("0 - Glavni meni");
                        bris_izbor = Console.ReadLine();
                    }
                    switch (bris_izbor)
                    {
                        case "1":
                            prviput = true;
                            flag = false;
                            string bris_ime;
                            while (prviput == true || flag == false)
                            {
                                Console.Clear();
                                Console.WriteLine("> Radnici > Brisanje radnika > Po imenu radnika");
                                Console.WriteLine("");
                                if (!prviput)
                                {
                                    Console.WriteLine("Radnik nije pronaden, pokusajte ponovo");
                                    Console.WriteLine("");
                                }
                                prviput = false;

                                Console.WriteLine("Unesite ime i prezime radnika kojeg zelite izbrisati (za vratiti se na glavni meni, ostavite prazno)");
                                foreach (var item in radnici)
                                {
                                    Console.WriteLine($"    - {item.Key}");
                                }
                                bris_ime = Console.ReadLine();
                                if (bris_ime == "")
                                {
                                    Console.Clear();
                                    break;
                                }
                                foreach (var item in radnici)
                                {
                                    if (bris_ime == item.Key)
                                    {
                                        potvrda = "";
                                        prviput = true;
                                        while ((potvrda != "1") && (potvrda != "0"))
                                        {
                                            Console.Clear();
                                            Console.WriteLine("> Radnici > Brisanje radnika > Po imenu radnika");
                                            Console.WriteLine("");
                                            PrviPut(prviput);
                                            prviput = false;
                                            Console.WriteLine($"Jeste li sigurni da zelite izbrisati radnika {bris_ime}?");
                                            Console.WriteLine("1 - Da");
                                            Console.WriteLine("0 - Ne");
                                            potvrda = Console.ReadLine();
                                        }
                                        if (potvrda == "1")
                                        {
                                            radnici.Remove(bris_ime);
                                            Console.Clear();
                                            Console.WriteLine("Radnik uspjesno izbrisan!");
                                            Console.WriteLine("");
                                            flag = true;
                                            break;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Radnik nije izbrisan");
                                            Console.WriteLine("");
                                            flag = true;
                                            break;
                                        }

                                    }
                                }

                            }
                            break;

                        case "2":
                            prviput = true;
                            potvrda = "";
                            while ((potvrda != "1") && (potvrda != "0"))
                            {
                                Console.Clear();
                                PrviPut(prviput);
                                prviput = false;
                                Console.WriteLine("Jeste li sigurni da zelite izbrisati sve radnika starije od 65 godina?");
                                Console.WriteLine("1 - Da");
                                Console.WriteLine("0 - Ne");
                                potvrda = Console.ReadLine();
                            }
                            if (potvrda == "1")
                            {
                                foreach (var item in radnici)
                                {
                                    DateTime sad = DateTime.Now;
                                    DateTime roden = Convert.ToDateTime(item.Value[2]);
                                    
                                    if (roden.AddYears(65) < sad)
                                        radnici.Remove(item.Key);

                                }
                                Console.Clear();
                                Console.WriteLine("Radnici uspjesno izbrisani!");
                                Console.WriteLine("");
                                continue;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Radnici nisu izbrisani");
                                Console.WriteLine("");
                                continue;
                            }
                            

                        case "0":
                            Console.Clear();
                            continue;

                    }
                    break;

                case "3":
                    prviput = true;
                    flag = false;
                    string ured_ime;
                    while ((prviput == true) || (flag == false))
                    {
                        Console.Clear();
                        Console.WriteLine("> Radnici > Uredivanje radnika");
                        Console.WriteLine("");
                        if(!prviput)
                        {
                            Console.WriteLine("Radnik nije pronaden");
                            Console.WriteLine("");
                        }
                        prviput = false;

                        Console.WriteLine("Unesite ime radnika cije podatke zelite urediti (za vratiti se na glavni meni, ostavite prazno): ");
                        foreach (var item in radnici)
                        {
                            Console.WriteLine($"    - {item.Key}");
                        }
                        ured_ime = Console.ReadLine();
                        if (ured_ime == "")
                        {
                            Console.Clear();
                            break;
                        }
                        foreach (var item in radnici)
                        {

                            if (ured_ime == item.Key)
                            {
                                prviput = true;
                                flag = false;
                                string novo_ime = "";
                                while ((prviput == true) || (flag == false))
                                {
                                    Console.Clear();
                                    Console.WriteLine("> Radnici > Uredivanje radnika");
                                    Console.WriteLine("");
                                    if(!prviput)
                                    {
                                        Console.WriteLine("Ne mozete unijeti ime i prezime postojeceg radnika, pokusajte ponovo");
                                        Console.WriteLine("");
                                    }
                                    Console.WriteLine($"Unesite novo ime i prezime radniku {item.Key} (za vratiti se na glavni meni, ostavite prazno);");
                                    novo_ime = Console.ReadLine();
                                    if(novo_ime == "")
                                    {
                                        flag = true;
                                        break;
                                    }
                                }
                                if (flag)
                                    break;
                            }


                        }
                        if (flag)
                            break;
                    }
                    continue;

                case "4":

                    flag = false;
                    prviput = true;
                    var ispis_izbor = "";

                    while (ispis_izbor != "1" && ispis_izbor != "2")
                    {
                        Console.Clear();
                        Console.WriteLine("> Radnici > Ispis");
                        Console.WriteLine("");
                        PrviPut(prviput);
                        prviput = false;
                        Console.WriteLine("1 - Svi radnici");
                        Console.WriteLine("2 - Svi radnici kojima je rodendan u tekucem mjesecu");
                        
                        ispis_izbor = Console.ReadLine();
                    }

                    var cekanje = "";

                    switch(ispis_izbor)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("> Radnici > Ispis > Svi");
                            Console.WriteLine("");
                            var iznimka = 0;
                            foreach (var item in radnici)
                            {
                                var sad = DateTime.Now;
                                var roden = DateTime.Parse(item.Value);
                                if (sad.Month < roden.Month)
                                    iznimka = 1;
                                else if (sad.Day <= roden.Day)
                                    iznimka = 1;

                                Console.WriteLine($"{item.Key} - {sad.Year - roden.Year + iznimka}");
                            }
                            Console.WriteLine("");
                            Console.WriteLine("Za vratiti se na glavni meni, unesite bilo sto:");
                            cekanje = Console.ReadLine();
                            Console.Clear();
                            break;
                        
                        case "2":
                            Console.Clear();
                            Console.WriteLine("> Radnici > Ispis > Rodendan");
                            Console.WriteLine("");
                            foreach (var item in radnici)
                            {
                                var sad = DateTime.Now;
                                var roden = DateTime.Parse(item.Value);
                                if (sad.Month == roden.Month)
                                    Console.WriteLine(item.Key);
                            }
                            Console.WriteLine("");
                            Console.WriteLine("Za vratiti se na glavni meni, unesite bilo sto:");
                            cekanje = Console.ReadLine();
                            Console.Clear();
                            break;
                    }
                    
                    continue;

                case "0":
                    Console.Clear();
                    continue;
            }

            break;

        case "3":
            flag = false;
            prviput = true;
            string racuni_izbor = "";
            while(racuni_izbor != "1" && racuni_izbor != "2" && racuni_izbor != "0")
            {
                Console.Clear();
                Console.WriteLine("> Racuni");
                Console.WriteLine("");
                PrviPut(prviput);
                prviput = false;
                Console.WriteLine("1 - Unos novog racuna");
                Console.WriteLine("2 - Ispis");
                Console.WriteLine("0 - Glavni meni");
                racuni_izbor = Console.ReadLine();
            }

            switch (racuni_izbor)
            {
                case "1":
                    var flag1 = false;
                    var flag2 = false;
                    prviput = true;
                    var gotov = false;
                    var proizvod = "";
                    var kup_kolicina = -1;
                    string skup_kolicina = "";
                    float uk_cijena = 0.0f;
                    List<List<string>> tren_proizvodi = new List<List<string>>();
                    tren_proizvodi.Add(new List<string>());
                    tren_proizvodi.Add(new List<string>());

                    while (gotov == false)
                    {
                        Console.Clear();
                        Console.WriteLine("> Racuni > Unos");
                        Console.WriteLine("");
                        if(flag1)
                        {
                            Console.WriteLine("Nepravilan unos, pokusajte ponovo");
                            Console.WriteLine("");
                            flag1 = false;
                        }
                        if(flag2)
                        {
                            Console.WriteLine("Artikl vec dodan, pokusajte ponovo");
                            Console.WriteLine("");
                            flag2 = false;
                        }
                        Console.WriteLine("Svi dostupni artikli:");
                        foreach (var item in artikli)
                        {
                            Console.WriteLine($"    -{item.Key}");
                        }
                        Console.WriteLine("");
                        Console.WriteLine("Unesite neki artikl s liste (za zavrsiti kupovinu ili vratiti se na glavni meni, ostavite prazno)");
                   
                        proizvod = Console.ReadLine();
                        if (tren_proizvodi[0].Contains(proizvod))
                        {
                            flag2 = true;
                            continue;
                        }
                        if (proizvod == "")
                        {
                            potvrda = "";
                            prviput = true;
                            while(potvrda != "1" && potvrda != "0")
                            {
                                Console.Clear();
                                Console.WriteLine("> Racuni > Unos");
                                Console.WriteLine("");
                                PrviPut(prviput);
                                prviput = false;
                                Console.WriteLine("1 - Zavrsetak kupovine");
                                Console.WriteLine("0 - Povratak na glavni meni");
                                potvrda = Console.ReadLine();
                            }
                            switch(potvrda)
                            {
                                case "1":
                                    int najveci_id = 0;
                                    foreach (var item in racuni)
                                    {
                                        if (item.Key.Item1 > najveci_id)
                                            najveci_id = item.Key.Item1;
                                    }
                                    string sad = Convert.ToString(DateTime.Now);
                                    Tuple<int, string, float> kljuc = new Tuple<int, string, float>(najveci_id + 1, sad, uk_cijena);
                                    Tuple<List<string>, List<string>> vrij = new Tuple<List<string>, List<string>>(tren_proizvodi[0], tren_proizvodi[1]);
                                                         
                                   


                                    racuni.Add(kljuc, vrij);
                                    
                                   
                                    for (int i = 0; i < tren_proizvodi[0].Count; i++)
                                    {
                                        artikli[tren_proizvodi[0][i]][0] = Convert.ToString(int.Parse(artikli[tren_proizvodi[0][i]][0]) - int.Parse(tren_proizvodi[1][i]));
                                    }

                                    Console.Clear();
                                    Console.WriteLine("Racun uspjesno unesen!");
                                    Console.WriteLine($"Id i vrijeme izdavanja: {najveci_id + 1} - {sad}");
                                    for (int i = 0; i < tren_proizvodi[0].Count; i++)
                                    {
                                        Console.WriteLine($"{tren_proizvodi[0][i]} - {tren_proizvodi[1][i]}");
                                    }
                                    Console.WriteLine($"Ukupna cijena: {uk_cijena}");
                                    Console.WriteLine("");
                                    Console.WriteLine("Za vratiti se na glavni meni, unesite bilo sto:");
                                    string cekanje = Console.ReadLine();
                                    
                                    Console.Clear();
                                    
                                    gotov = true;
                                    continue;
                                case "0":
                                    Console.WriteLine("");
                                    Console.Clear();
                                    flag = true;
                                    break;
                            }
                            if (flag)
                                break;
                            
                        }

                        if (!artikli.ContainsKey(proizvod))
                        {
                            flag1 = true;
                            continue;
                        }
                        prviput = true;
                        kup_kolicina = 0;
                        while(kup_kolicina < 1 || kup_kolicina > int.Parse(artikli[proizvod][0]))
                        {
                            Console.Clear();
                            Console.WriteLine("> Racuni > Unos");
                            Console.WriteLine("");
                            if(kup_kolicina < 1 && !prviput)
                            {
                                Console.WriteLine("Nepravilan unos, pokusajte ponovo");
                                Console.WriteLine("");
                            }
                            prviput = false;
                            if(kup_kolicina > int.Parse(artikli[proizvod][0]))
                            {
                                Console.WriteLine($"Prevelika kolicina, unesite manji broj (dostupna kolicina je {int.Parse(artikli[proizvod][0])})");
                            }
                            
                            Console.WriteLine($"Unesite kolicinu artikla {proizvod} koji unosite na racun: ");
                            skup_kolicina = Console.ReadLine();

                            int.TryParse(skup_kolicina, out kup_kolicina);
                            

                        }
                        

                        potvrda = "";
                        prviput = true;
                        while (potvrda != "1" && potvrda != "0")
                        {
                            Console.Clear();
                            Console.WriteLine("> Racuni > Unos");
                            Console.WriteLine("");
                            PrviPut(prviput);
                            prviput = false;
                            Console.WriteLine($"Jeste li sigurni da na racun zelite dodati artikl {proizvod}, kolicina {kup_kolicina}?");
                            Console.WriteLine("1 - Da");
                            Console.WriteLine("0 - Ne");
                            potvrda = Console.ReadLine();
                        }
                        switch(potvrda)
                        {
                            case "1":                                                            
                                tren_proizvodi[0].Add(proizvod);
                                tren_proizvodi[1].Add(skup_kolicina);
                                uk_cijena += float.Parse(artikli[proizvod][1]) * kup_kolicina;
                                break;
                            case "0":
                                continue;
                                
                        }



                    }

                    continue;

                case "2":
                    var ispis_izbor = "";
                    flag = false;
                    prviput = true;
                    while(ispis_izbor != "2" && ispis_izbor != "1" && ispis_izbor !="0")
                    {
                        Console.Clear();
                        Console.WriteLine("> Racuni > Ispis");
                        Console.WriteLine("");
                        PrviPut(prviput);
                        prviput = false;
                        Console.WriteLine("1 - Svi racuni");
                        Console.WriteLine("2 - Po id-u");
                        Console.WriteLine("0 - Glavni meni");
                        ispis_izbor = Console.ReadLine();
                    }

                    switch(ispis_izbor)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("> Racuni > Ispis > Svi");
                            Console.WriteLine("");
                            foreach (var item in racuni)
                            {
                                
                                
                                Console.WriteLine($"{item.Key.Item1} - {item.Key.Item2} - {item.Value.Item2[0]}");
                                Console.WriteLine("");
                                Console.WriteLine("Za vratiti se na glavni meni, unesite bilo sto:");
                                var cek = Console.ReadLine();
                                Console.Clear();

                            }
                            continue;
                        
                        case "2":
                            Console.Clear();
                            Console.WriteLine("> Racuni > Ispis > Po id-u");
                            Console.WriteLine("");

                            prviput = true;
                            flag = false;
                            string unos_id;
                            while (prviput == true || flag == false)
                            {
                                Console.Clear();
                                Console.WriteLine("> Racuni > Ispis > Po id-u");
                                Console.WriteLine("");
                                if (!prviput)
                                {
                                    Console.WriteLine("Id nije pronaden, pokusajte ponovo");
                                    Console.WriteLine("");
                                }
                                prviput = false;

                                Console.WriteLine("Unesite id racuna kojeg zelite ispisati (za vratiti se na glavni meni, ostavite prazno)");
                                foreach (var item in racuni)
                                {
                                    Console.WriteLine($"    - {item.Key.Item1}");
                                }
                                unos_id = Console.ReadLine();
                                if (unos_id == "")
                                {
                                    Console.Clear();
                                    break;
                                }
                                foreach (var item in racuni)
                                {
                                    if (unos_id == Convert.ToString(item.Key.Item1))
                                    {
                                        Console.Clear();
                                        
                                        Console.WriteLine($"{item.Key.Item1} - {item.Key.Item2}");
                                        for (int i = 0; i < item.Value.Item1.Count; i++)
                                        {
                                            Console.WriteLine($"{item.Value.Item1[i]} - {item.Value.Item2[i]}");
                                        }

                                        Console.WriteLine("");
                                        Console.WriteLine("Za vratiti se na glavni meni, unesite bilo sto:");
                                        var cek = Console.ReadLine();
                                        Console.Clear();

                                    }
                                }

                            }
                            break;

                            
                        
                        case "0":
                            Console.Clear();
                            continue;
                    }

                    continue;

                case "0":
                    Console.Clear();
                    continue;

            }

            break;
        case "4":
            Console.Clear();
            flag = false;
            prviput = true;
            string statistika_izbor = "";
            while (statistika_izbor != "1" && statistika_izbor != "2" && statistika_izbor != "0" && statistika_izbor != "3" && statistika_izbor != "4")
            {
                Console.Clear();
                Console.WriteLine("> Statistika");
                Console.WriteLine("");
                PrviPut(prviput);
                prviput = false;
                Console.WriteLine("1 - Ukupan broj artikala");
                Console.WriteLine("2 - Vrijednost neprodanih artikala");
                Console.WriteLine("3 - Vrijednost prodanih artikala");
                Console.WriteLine("4 - Stanje po mjesecima");

                Console.WriteLine("0 - Glavni meni");
                statistika_izbor = Console.ReadLine();
            }
            switch(statistika_izbor)
            {
                case "1":
                    Console.Clear();
                    var suma = 0;
                    foreach (var item in artikli)
                    {
                        suma += int.Parse(item.Value[0]);
                    }
                    Console.WriteLine($"Ukupan broj artikala je {suma}");
                    break;

                case "2":
                    Console.Clear();
                    var vrijednost = 0.0f;
                    foreach (var item in artikli)
                    {
                        vrijednost += int.Parse(item.Value[0]) * float.Parse(item.Value[1]);
                    }
                    Console.WriteLine($"Ukupna vrijednost neprodanig artikala je {vrijednost}");
                    break;
                    

                case "3":
                    break;

                case "4":
                    var sgod = "";
                    var god = -1;
                    prviput = true;
                    while (god < 0)
                    {
                        Console.Clear();
                        PrviPut(prviput);
                        prviput = false;
                        Console.WriteLine("Unesite godinu (za vratiti se na glavni meni, ostavite prazno): ");

                        sgod = Console.ReadLine();
                        if (sgod == "")
                        {
                            Console.Clear();
                            flag = true;
                            break;
                        }
                        int.TryParse(sgod, out god);
                    }

                    var mjesec = -1;
                    var smjesec = "";
                    prviput = true;
                    while (mjesec < 0 || mjesec > 12)
                    {
                        Console.Clear();
                        PrviPut(prviput);
                        prviput = false;
                        Console.WriteLine("Unesite mjesec (za vratiti se na glavni meni, ostavite prazno): ");

                        smjesec = Console.ReadLine();
                        if (smjesec == "")
                        {
                            Console.Clear();
                            flag = true;
                            break;
                        }
                        int.TryParse(smjesec, out mjesec);
                    }

                    var splaca = "";
                    var placa = -1.0f;
                    prviput = true;
                    while (placa < 0)
                    {
                        Console.Clear();
                        PrviPut(prviput);
                        prviput = false;
                        Console.WriteLine("Unesite iznos placa radnika (za vratiti se na glavni meni, ostavite prazno): ");

                        splaca = Console.ReadLine();
                        if (splaca == "")
                        {
                            Console.Clear();
                            flag = true;
                            break;
                        }
                        float.TryParse(splaca, out placa);
                    }
                    var stros = "";
                    var tros = -1.0f;
                    prviput = true;
                    while (tros < 0)
                    {
                        Console.Clear();
                        PrviPut(prviput);
                        prviput = false;
                        Console.WriteLine("Unesite iznos ostalih troskova (za vratiti se na glavni meni, ostavite prazno): ");

                        stros = Console.ReadLine();
                        if (stros == "")
                        {
                            Console.Clear();
                            flag = true;
                            break;
                        }
                        float.TryParse(stros, out tros);
                    }
                    var zarada = 0.0f;
                    foreach (var item in racuni)
                    {

                        if (DateTime.Parse(item.Key.Item2).Year == god && DateTime.Parse(item.Key.Item2).Month == mjesec)
                            zarada += Zbroj(item.Value.Item1, item.Value.Item2, artikli);
                                
                    }
                    var profit = zarada * 1.0f / 3 - placa - tros;
                    Console.WriteLine($"Ukupan profit za godinu {god}, mjesec {mjesec} je {profit}");


                    break;

                case "0":
                    Console.Clear();
                    continue;
                    


            }

            break;
        
        default:
            Console.Clear();
            Console.WriteLine("Nepravilan unos, pokusajte ponovo");
            Console.WriteLine("");
            break;
    }
}






