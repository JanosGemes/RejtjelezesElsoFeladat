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

        // Kiirja a megadott szoveg karaktereinek kodjait
        static void KodokatKiir(string cimke, string szoveg)
        {
            Console.Write($"{cimke}: ");
            foreach (char betu in szoveg)
            {
                int kod = KarakterKodda(betu);
                if (kod != -1) Console.Write(kod + " ");
            }
            Console.WriteLine();
        }

        static char KodbolKarakter(int kod)
        {
            if (kod == 26) return ' ';
            if (kod >= 0 && kod <= 25) return (char)('a' + kod);
            return '?';
        }

        static void OsszeadottKodokatKiir(string uzenet, string kulcs)
        {
            Console.Write("Osszeadott kodok: ");
            int hossz = Math.Min(uzenet.Length, kulcs.Length);
            for (int i = 0; i < hossz; i++)
            {
                int uzenetKod = KarakterKodda(uzenet[i]);
                int kulcsKod = KarakterKodda(kulcs[i]);
                if (uzenetKod != -1 && kulcsKod != -1)
                    Console.Write((uzenetKod + kulcsKod) + " ");
            }
            Console.WriteLine();
        }

        static void ModKodokatKiir(string uzenet, string kulcs)
        {
            Console.Write("Mod 27 kodok: ");
            int hossz = Math.Min(uzenet.Length, kulcs.Length);
            for (int i = 0; i < hossz; i++)
            {
                int uzenetKod = KarakterKodda(uzenet[i]);
                int kulcsKod = KarakterKodda(kulcs[i]);
                if (uzenetKod != -1 && kulcsKod != -1)
                    Console.Write((uzenetKod + kulcsKod) % 27 + " ");
            }
            Console.WriteLine();
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
            Console.Write("Rejtjelezendő szöveg: ");
            string uzenet = Console.ReadLine();

            Console.Write("Kulcs: ");
            string kulcs = Console.ReadLine();

            if (uzenet.Length > kulcs.Length)
            {
                Console.WriteLine("Hiba: A rejtjelezendő szöveg hosszabb, mint a kulcs!");
                return;
            }

            KodokatKiir("Üzenet kódok", uzenet);
            KodokatKiir("Kulcs  kódok", kulcs);
            OsszeadottKodokatKiir(uzenet, kulcs);
            ModKodokatKiir(uzenet, kulcs);
            string titkositott = Titkosit(uzenet, kulcs);
            Console.WriteLine("Visszafejtett üzenet: " + Visszafejt(titkositott, kulcs));


        }
    }

}