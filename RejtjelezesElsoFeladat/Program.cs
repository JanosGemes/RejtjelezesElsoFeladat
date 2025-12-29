namespace RejtjelezesElsoFeladat
{

    class Program
    {
        // Karaktert alapertelmezett kodda alakitja:
        // 'a'..'z' -> 0..25, szokoz -> 26, minden mas -> -1
        static int KarakterKodda(char karakter)
        {
            if (karakter == ' ') return 26;
            if (karakter >= 'a' && karakter <= 'z') return karakter - 'a';
            return -1;
        }

        static char KodbolKarakter(int kod)
        {
            if (kod == 26) return ' ';
            if (kod >= 0 && kod <= 25) return (char)('a' + kod);
            return '?';
        }
        static string Titkosit(string uzenet, string kulcs)
        {
            string titkos = "";
            int hossz = Math.Min(uzenet.Length, kulcs.Length);
            for (int i = 0; i < hossz; i++)
            {
                int uzenetKod = KarakterKodda(uzenet[i]);
                int kulcsKod = KarakterKodda(kulcs[i]);
                if (uzenetKod != -1 && kulcsKod != -1)
                    titkos += KodbolKarakter((uzenetKod + kulcsKod) % 27);
            }
            return titkos;
        }

        static string Visszafejt(string titkos, string kulcs)
        {
            string eredeti = "";
            int hossz = Math.Min(titkos.Length, kulcs.Length);
            for (int i = 0; i < hossz; i++)
            {
                int titkosKod = KarakterKodda(titkos[i]);
                int kulcsKod = KarakterKodda(kulcs[i]);
                if (titkosKod != -1 && kulcsKod != -1)
                    eredeti += KodbolKarakter((titkosKod - kulcsKod + 27) % 27);
            }
            return eredeti;
        }

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Valassz muveletet:");
                Console.WriteLine("1 - Rejtjelezes");
                Console.WriteLine("2 - Visszafejtes");
                Console.Write("Valasztas: ");
                string valasztas = Console.ReadLine();

                if (valasztas == "1")
                {
                    string uzenet, kulcs;
                    while (true)
                    {
                        Console.Write("Rejtjelezendo szoveg: ");
                        uzenet = Console.ReadLine();
                        Console.Write("Kulcs: ");
                        kulcs = Console.ReadLine();

                        if (uzenet.Length > kulcs.Length)
                        {
                            Console.WriteLine("Hiba: A rejtjelezendo szoveg hosszabb, mint a kulcs! Add meg ujra.");
                        }
                        else
                        {
                            break;
                        }
                    }

                    string titkos = Titkosit(uzenet, kulcs);
                    Console.WriteLine("Rejtjelezett szoveg: " + titkos);
                }
                else if (valasztas == "2")
                {
                    string titkos, kulcs;
                    while (true)
                    {
                        Console.Write("Rejtjelezett szoveg: ");
                        titkos = Console.ReadLine();
                        Console.Write("Kulcs: ");
                        kulcs = Console.ReadLine();

                        if (titkos.Length > kulcs.Length)
                        {
                            Console.WriteLine("Hiba: A rejtjelezett szoveg hosszabb, mint a kulcs! Add meg ujra.");
                        }
                        else
                        {
                            break;
                        }
                    }

                    string visszafejtett = Visszafejt(titkos, kulcs);
                    Console.WriteLine("Visszafejtett szoveg: " + visszafejtett);
                }
                else
                {
                    Console.WriteLine("Ervenytelen valasztas. Probald ujra.");
                    continue;
                }

                break;
            }


        }
    }

}