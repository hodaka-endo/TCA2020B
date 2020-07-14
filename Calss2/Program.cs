using System;

namespace Calss2
{
    class Program
    {
        static double BMI(double a, double b) {
            a /= 100;
            double BMIti = b / (a * a);

            return BMIti;

        }

        static double nyuuryoku(int p) {
            string sintai = "";
            double sintai2 = 0;
            bool TorF = true;
            do
            {
                if (p == 1) { Console.WriteLine("身長(cm)"); } else { Console.WriteLine("体重(kg)"); }
                sintai = Console.ReadLine();
                TorF = double.TryParse(sintai, out sintai2);
                if (TorF == false)
                {
                    Console.WriteLine("再度入力してください。");
                }
            } while (TorF == false);
            return sintai2;
        }

        static void BMIhyouka(double c) {
            int h = 0;
            double[] kizyunn = new double[] { 0, 16.00, 17.00, 18.50, 25.00, 30.00, 35.00, 40.00, 999999 };
            for (int i = 0; i < 8; i++)
            {
                if (kizyunn[i] <= c && c < kizyunn[i + 1]) {
                    h = i;
                    break;
                }
            }
            switch (h) {
                case 0:
                    Console.WriteLine("痩せすぎ（重度の痩せ）です。");
                    break;
                case 1:
                    Console.WriteLine("痩せ（中度の痩せ）です。");
                    break;
                case 2:
                    Console.WriteLine("痩せぎみ（軽度の痩せ）です。");
                    break;
                case 3:
                    Console.WriteLine("普通体重です。");
                    break;
                case 4:
                    Console.WriteLine("過体重（前肥満）です。");
                    break;
                case 5:
                    Console.WriteLine("肥満（1度）です。");
                    break;
                case 6:
                    Console.WriteLine("肥満（2度）です。");
                    break;
                case 7:
                    Console.WriteLine("肥満（3度）です。");
                    break;
            }
        }

        static double senkou(string a) {
            bool TorF = true;
            double tallweight;
            TorF = double.TryParse(a, out tallweight);
            if (TorF == false)
            {
                Console.WriteLine("エラー。打ち直してください。");
            }
                return tallweight;
        }

        static int SenkouHyouka(string[] args) {
            bool TorF = false;
            int c = 0;
            double tall;
            double weight;
            if (args.Length >= 0) {
                TorF = double.TryParse(args[0], out tall); 
                if (TorF == false)
                {
                    c += 1;
                }
                if (args.Length > 1)
                {
                    TorF = double.TryParse(args[1], out weight);
                    if (TorF == false)
                    {
                        c += 2;
                    }
                }
                else { c += 2; }
                
            }
            else { c += 3; }
            return c;
        }

        static void nyuuryokubunnki(int c,ref double tall, ref double weight,string[] args) { 
            switch (c) {
                case 0:
                    tall = senkou(args[0]);
                    weight = senkou(args[1]);
                    break;
                case 1:
                    tall = nyuuryoku(1);
                    weight = senkou(args[1]);
                    break;
                case 2:
                    tall = senkou(args[0]);
                    weight = nyuuryoku(0);
                    break;
                case 3:
                    for (int p = 1; p >= 0; p--)
                    {
                        if (p == 1) {
                            tall = nyuuryoku(p);
                        }else{
                            weight = nyuuryoku(p);
                        }
                    }
                    break;
            }
        }

        static void Main(string[] args)
        {     
            double sin3 = 0;
            double tai3 = 0;
            nyuuryokubunnki(SenkouHyouka(args),ref sin3,ref tai3,args);

            Console.WriteLine("BMIは"+BMI(sin3,tai3).ToString("F2")+"です。");
            BMIhyouka(BMI(sin3,tai3));
            
        }
    }
}
