using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint2_palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            //kullanıcının ekrandan gireceği tam sayının bir palindrom olup olmadığını yazdıran programı yazınız
            //girilen ifadenin doğru bir tamsayı olup olmadıgı kontrol edilmelidir.
            //Eğer ki kullanıcının girş yaptığı değer bir tam sayı değilse,kullanıcıdan dogru formatta bir sayı istenmelidir.
            //ayrıca yapılacak işlemler kesinlikle tamsayı tipindeki değişkenler kullanılarak yapılmalıdır.
            //bu örnekte string metotları kullanılmayacaktır.
            //programı sonlandırmak için exit yazılması gereklidir.

            palindromeSayısı();
            Bekle();

        }

        static void palindromeSayısı()

        {
            EkranaYaz("Bir tamsayı giriniz: ");
            string input = EkrandanOku();
            int sayi;

            bool donustuMu = int.TryParse(input, out sayi);

            if (!donustuMu)
            {
                EkranaYaz("Lütfen doğru formatta bir sayı yazınız.");
            }
            else
            {
                string revs = "";
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    revs += input[i].ToString();
                }
                if (revs == input)
                {
                    EkranaYaz("Girdiğiniz sayı bir palindromdur.");
                }
                else
                {
                    EkranaYaz("Girdiğiniz sayı bir palindrom değildir.");
                }
            }

            if (input == "exit")
            {
                Environment.Exit(0);
            }

        }


        #region Framework
        private static void EkraniTemizle()
        {
            Console.Clear();
        }

        static bool BoolSorusu(string soruMetni, string trueSecici, string falseSecici)
        {
            EkranaYaz(soruMetni + "(" + trueSecici + "/" + falseSecici + ")....");
            string input = EkrandanOku();
            if (input == trueSecici)
            {
                return true;
            }
            else if (input == falseSecici)
            {
                return false;
            }
            else
            {
                EkranaYaz("Hatalı bir giriş yaptınız.");
                SatirBasiYap();
                return BoolSorusu(soruMetni, trueSecici, falseSecici);
            }
        }

        static int RastgeleSayiSec(int[] sayilar)
        {
            Random random = new Random();
            int indis = random.Next(0, sayilar.Length);
            return sayilar[indis];
        }

        static void Bekle()
        {
            Console.ReadKey();
        }

        static void EkranaYaz(int sayi)
        {
            EkranaYaz(sayi.ToString());
        }

        static void EkranaYaz(string metin)
        {
            Console.Write(metin);
        }

        static int OrtalamaHesapla(int[] sayilar)
        {
            int toplam = Topla(sayilar);
            return toplam / sayilar.Length;
        }

        static int Topla(int[] sayilar)
        {
            int toplam = 0;
            for (int i = 0; i < sayilar.Length; i++)
            {
                toplam += sayilar[i];
            }
            return toplam;
        }

        static void EkranaYaz(int[] sayilar)
        {
            for (int i = 0; i < sayilar.Length; i++)
            {
                EkranaYaz(sayilar[i] + " ");
            }
        }

        static int[] RastgeleSayiUret(int sayiAdeti, int sayiAltSiniri, int sayiUstSiniri)
        {
            Random random = new Random();
            int[] sayilar = new int[sayiAdeti];
            for (int i = 0; i < sayiAdeti; i++)
            {
                sayilar[i] = random.Next(sayiAltSiniri, sayiUstSiniri);
            }
            return sayilar;
        }

        static int KontrolluSayiAl(string istekMesaji, string hataMesaji)
        {
            EkranaYaz(istekMesaji);
            string input = EkrandanOku();
            int sayi;
            bool donustuMu = int.TryParse(input, out sayi);
            if (donustuMu)
            {
                return sayi;
            }
            EkranaYaz(hataMesaji);
            SatirBasiYap();
            return KontrolluSayiAl(istekMesaji, hataMesaji);
        }

        static void SatirBasiYap()
        {
            Console.WriteLine();
        }

        static string EkrandanOku()
        {
            return Console.ReadLine();
        }

        static void KarsilamaYap()
        {
            EkranaYaz("Rastgele Sayi Uygulamasına Hoş Geldiniz.");
            SatirBasiYap();
        }
        #endregion
    }
}
