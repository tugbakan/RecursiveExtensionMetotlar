using System;

public class Program
{
    public static void Main(string[] args)
    {
        //Recursive  = Özyinelemeli Fonksiyonlar (Kendi kendini çağıran fonksiyonlar)

        //3^4=3*3*3*3 işlemini önce for döngüsüyle sonra recursive fonksiyonla yapalım.
        int result=1;

        for (int i = 1; i < 5; i++)
            result*=3;
        Console.WriteLine(result);

        Islemler instance= new();
        Console.WriteLine(instance.Expo(3,4));

        //Extension Metotlar

        //Verilen ifadenin içinde boşluk olup olmadığını bulan bir extension metot oluşturalım.
        string ifade = "Merhaba Dünya";
        bool sonuc=ifade.CheckSpaces();
        Console.WriteLine(sonuc);

        //Boşluk varsa silen bir extension metot daha oluşturalım.

        if (sonuc)
             Console.WriteLine(ifade.RemoveWhiteSpaces());

        //Boşluk varsa yıldızla değiştiren bir extension metot daha oluşturalım.

        if (sonuc)
             Console.WriteLine(ifade.BosluklariYildizlaDegistir());

        //Verilen string ifadeyi büyük harflere çeviren extension yazalım.
        Console.WriteLine(ifade.MakeUpperCase());

        //Verilen string ifadeyi küçük harflere çeviren extension yazalım.
        Console.WriteLine(ifade.MakeLowerCase());

        //integer bir diziyi sıralayan extension metot yazalım.

        int[] dizi= {9,3,6,5,2,1,0};
        dizi.SortArray();

        //integer bir diziyi ekrana yazdıran extension metot yazalım.
        dizi.EkranaYazdir();

        //Verilen bir sayının çift olup olmadığını kontrol eden bir extension metot yazalım.
        int sayi=5;
        Console.WriteLine( sayi.isEvenNumber());

        //Verilen bir stringin ilk karakterini kesip getiren bir extension metot yazalım.
        Console.WriteLine(ifade.GetFirstCharacter());
    }
}
public class Islemler

{
    public int Expo ( int sayi, int usdegeri)
    {
        if(usdegeri<2)
            return sayi;

        return Expo (sayi, usdegeri-1)* sayi;

        //Expo (3,4)
        //Expo (3,3) * 3;
        //Expo (3,2) * 3 * 3;
        //Expo (3,1) * 3 * 3 * 3;
        // 3 * 3 * 3 * 3;
    }
}

public static class Extension //Extension classlar statik olmalı
{
    public static bool CheckSpaces(this string param)
    {
       return param.Contains(" "); //Contains string kütüphanesinin bir metodudur.
    }

    public static string RemoveWhiteSpaces(this string param)
    {
        string[] dizi= param.Split(" "); // Bu stringleri boşluklara göre ayır ve diziye al.
        return string.Join("",dizi);
    }

    public static string BosluklariYildizlaDegistir(this string param)
    {
        string[] dizi= param.Split(" "); // Bu stringleri boşluklara göre ayır ve diziye al.
        return string.Join("*",dizi);
    }

    public static string MakeUpperCase(this string param)
    {
       return param.ToUpper();
    }

    public static string MakeLowerCase(this string param)
    {
       return param.ToLower();
    }

    public static int[] SortArray(this int[] param)
    {
        Array.Sort(param);
        return param;
    }

    public static void EkranaYazdir (this int[] param)
    {
        foreach (int item in param)
        {
            Console.WriteLine(item);
        }
    }
    
    public static bool isEvenNumber(this int param)
    {
        return param%2==0;
    }

    public static string GetFirstCharacter(this string param)
    {
        return param.Substring(0,1); //(Kaçıncı indexten başladığı ve uzunluğu)
    }
}