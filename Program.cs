public static class Utility
{
    public static bool isPrintEvent = true;

    public static void InitConsole()
    {
        Console.Title = "Probability";
    }

    public static void WrongInput()
    {
        Console.Clear();
        Console.WriteLine(@"
잘못된 입력입니다.");
        Console.ReadKey(true);
    }

    public static void ConsoleSetting()
    {
        Console.Clear();
        Console.WriteLine(@"
================================
           콘솔 설정
================================");
        
        if (isPrintEvent)
        {
            Console.WriteLine(@"
[0] 뒤로가기
[1] 사건 값 출력하지 않기 (속도가 빨라집니다!)
");
        }
        else
        {
            Console.WriteLine(@"
[0] 뒤로가기
[1] 사건 값 출력하기 (속도가 매우 느려질 수 있습니다!)
");
        }
        
        ConsoleKeyInfo userInput = Console.ReadKey(true);

        if (userInput.Key == ConsoleKey.D0)
        {
            return;
        }
        else if (userInput.Key == ConsoleKey.D1)
        {
            if (isPrintEvent)
            {
                isPrintEvent = false;

                Console.Clear();
                Console.WriteLine(@"
이제 사건 값을 출력하지 않습니다!");
                Console.ReadKey();
            }
            else
            {
                isPrintEvent = true;

                Console.Clear();
                Console.WriteLine(@"
이제 사건 값을 출력합니다!");
                Console.ReadKey();
            }
        }
        else
        {
            WrongInput();
            ConsoleSetting();
        }
    }
}

public class Trial
{
    public void CoinEvent()
    {
        Random rand = new Random();

        int loopTime;
        int count0 = default; // 앞면
        int count1 = default; // 뒷면

        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("실행할 횟수를 입력해주세요.");
        bool isInt = int.TryParse(Console.ReadLine(), out loopTime);
        int[] result = new int[loopTime];

        if (isInt)
        {
            for (int i = 0; i < loopTime; i++)
            {
                result[i] = rand.Next(2);

                if (Utility.isPrintEvent)
                {
                    Console.Write(result[i]);
                }
            }

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == 0)
                {
                    count0++;
                }
                else if (result[i] == 1)
                {
                    count1++;
                }
            }

            Console.WriteLine(@"

[ 경우의 수 ]
앞면 : {0}
뒷면 : {1}

[ 확률 ]
앞면 : {2}
뒷면 : {3}", count0, count1, (float)count0 / loopTime, (float)count1 / loopTime);
            Console.ReadKey();
        }
        else
        {
            Utility.WrongInput();
            CoinEvent();
        }
    }

    public void DiceEvent()
    {
        Random rand = new Random();

        int loopTime;
        int count1 = default;
        int count2 = default;
        int count3 = default;
        int count4 = default;
        int count5 = default;
        int count6 = default;

        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("실행할 횟수를 입력해주세요.");
        bool isInt = int.TryParse(Console.ReadLine(), out loopTime);
        int[] result = new int[loopTime];

        if (isInt)
        {
            for (int i = 0; i < loopTime; i++)
            {
                result[i] = rand.Next(1, 7);

                if (Utility.isPrintEvent)
                {
                    Console.Write(result[i]);
                }
            }

            for (int i = 0; i < result.Length; i++)
            {
                switch (result[i])
                {
                    case 1:
                        count1++;
                        break;
                    case 2:
                        count2++;
                        break;
                    case 3:
                        count3++;
                        break;
                    case 4:
                        count4++;
                        break;
                    case 5:
                        count5++;
                        break;
                    case 6:
                        count6++;
                        break;
                }
            }

            Console.WriteLine(@"

[ 경우의 수 ]
1 : {0}
2 : {1}
3 : {2}
4 : {3}
5 : {4}
6 : {5}

[ 확률 ]
1 : {6}
2 : {7}
3 : {8}
4 : {9}
5 : {10}
6 : {11}", count1, count2, count3, count4, count5, count6,
(float)count1 / loopTime, (float)count2 / loopTime, (float)count3 / loopTime, (float)count4 / loopTime, (float)count5 / loopTime, (float)count6 / loopTime);
            Console.ReadKey();
        }
        else
        {
            Utility.WrongInput();
            DiceEvent();
        }
    }

    public void YutEvent()
    {
        Random rand = new Random();

        int loopTime;
        int count0 = default; // 앞면의 수 (평평한 면이 위로 간 것)
        int countDo = default;
        int countGae = default;
        int countGeol = default;
        int countYut = default;
        int countMo = default;

        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("실행할 횟수를 입력해주세요.");
        bool isInt = int.TryParse(Console.ReadLine(), out loopTime);

        if (isInt)
        {
            for (int i = 0; i < loopTime; i++)
            {
                int[] yutArray = new int[4];
                for (int j = 0; j < yutArray.Length; j++)
                {
                    yutArray[j] = rand.Next(2);
                }

                for (int k = 0; k < yutArray.Length; k++)
                {
                    if (yutArray[k] == 0)
                    {
                        count0++;
                    }
                }

                if (Utility.isPrintEvent)
                {
                    Console.Write(yutArray[0]);
                    Console.Write(yutArray[1]);
                    Console.Write(yutArray[2]);
                    Console.Write(yutArray[3]);
                    Console.WriteLine();
                }

                switch (count0)
                {
                    case 0: // 모
                        countMo++;
                        count0 = default;
                        break;
                    case 1: // 도
                        countDo++;
                        count0 = default;
                        break;
                    case 2: // 개
                        countGae++;
                        count0 = default;
                        break;
                    case 3: // 걸
                        countGeol++;
                        count0 = default;
                        break;
                    case 4: // 윷
                        countYut++;
                        count0 = default;
                        break;
                }
            }

            Console.WriteLine(@"

[ 경우의 수 ]
도 : {0}
개 : {1}
걸 : {2}
윷 : {3}
모 : {4}

[ 확률 ]
도 : {5}
개 : {6}
걸 : {7}
윷 : {8}
모 : {9}", countDo, countGae, countGeol, countYut, countMo,
(float)countDo / loopTime, (float)countGae / loopTime, (float)countGeol / loopTime, (float)countYut / loopTime, (float)countMo / loopTime);
            Console.ReadKey();
        }
        else
        {
            Utility.WrongInput();
            YutEvent();
        }
    }
}

namespace Probability
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isEnd = false;
            Trial trial = new Trial();

            Utility.InitConsole(); // Console Setting

            // Main Loop
            while (!isEnd)
            {
                Console.Clear();
                Console.WriteLine(@"
================================
 통계적 확률과 수학적 확률 탐구
================================

[0] 종료하기
[1] 동전 던지기
[2] 주사위 굴리기
[3] 윷 던지기
[4] 설정

v1.0.2
Made By TaeHwan
");
                ConsoleKeyInfo userInput = Console.ReadKey(true);

                switch (userInput.Key)
                {
                    case ConsoleKey.D0:
                        isEnd = true;
                        break;
                    case ConsoleKey.D1:
                        trial.CoinEvent();
                        break;
                    case ConsoleKey.D2:
                        trial.DiceEvent();
                        break;
                    case ConsoleKey.D3:
                        trial.YutEvent();
                        break;
                    case ConsoleKey.D4:
                        Utility.ConsoleSetting();
                        break;
                    default:
                        Utility.WrongInput();
                        break;
                }
            }
        }
    }
}