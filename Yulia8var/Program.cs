using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yulia8var
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите код:");
            string kod = Console.ReadLine();
            if (kod.Length == 13)
            {
                char[] Vyvod = kod.ToCharArray();
                Console.WriteLine(Validaciya(Vyvod));
                Console.WriteLine(Sum(Vyvod));
                Console.WriteLine(Type(Vyvod));
            }
            else
            {
                Console.WriteLine("Код неверный");
            }
            Console.ReadLine();
        }

        static string Validaciya(char[] kod)
        {
            bool flag = ((kod[0] == 'R' || kod[0] == 'L' || kod[0] == 'V' || kod[0] == 'C' ||
            kod[0] == 'E' || kod[0] == 'U' || kod[0] == 'Z') && (kod[1] >= 'A' && kod[1] <= 'Z')) ? true : false;
            if (flag)
            {
                for (int i = 2; i < 11; i++)
                {
                    if (!Char.IsDigit(kod[i])) flag = false;
                }
            }
            if (flag)
            {
                flag = ((kod[11] >= 'A' && kod[11] <= 'Z') && (kod[12] >= 'A' && kod[12] <= 'Z')) ? true : false;
            }
            return flag ? "Код верный" : "Код неверный";
        }

        static string Sum(char[] kod)
        {
            int N = (Convert.ToInt32(kod[2]) * 8 + Convert.ToInt32(kod[3]) * 6 + Convert.ToInt32(kod[4]) * 4 + Convert.ToInt32(kod[5]) * 2 + Convert.ToInt32(kod[6]) * 3 +
                Convert.ToInt32(kod[7]) * 5 + Convert.ToInt32(kod[8]) * 9 + Convert.ToInt32(kod[9]) * 7) % 11;
            int V = 11 - N;

            return (V == kod[10]) ? "Сумма совпадает" : "Сумма не совпадает";

        }

        static string Type(char[] kod)
        {

            var tipPisma = new Dictionary<char, string>()
            {
            {'R', "Регистрируемое отправление письменной корреспонденции (заказная карточка, письмо, бандероль, мелкий пакет(до 2 кг), заказной мешок «М» — международное отправление с большим объемом печатной продукции: бумагами,книгами, журналами)" },
            {'L', "Отслеживаемое письмо, несколько подтипов; использование LZ требует двустороннего соглашения" },
            { 'V', "Письмо с объявленной ценностью" },
            { 'C', "Международная посылка (более 2 кг)" },
            { 'E', "Экспресс-отправления (EMS от Express Mail Service)" },
            { 'U', "Нерегистрируемые и неотслеживаемые отправления, которые обязаны проходить таможенные процедуры" },
            { 'Z', "SRM-отправление (от simplified registered mail), простой регистрируемый пакет" }
            };
            char key = kod[0];
            return tipPisma[key];
        }
    }
}
