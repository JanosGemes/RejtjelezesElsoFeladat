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

        static void Main()
        {
            Console.Write("Rejtjelezendő szöveg: ");
            string uzenet = Console.ReadLine();

            Console.Write("Kulcs: ");
            string kulcs = Console.ReadLine();

            KodokatKiir("Üzenet kódok", uzenet);
            KodokatKiir("Kulcs  kódok", kulcs);
        }
    }
}
