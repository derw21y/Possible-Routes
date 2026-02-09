public class Routes
{
    public int CountRoutes(int[] locations, int start, int finish, int fuel) 
    {
        int mod = 1000000007; // в задании нужен ответ по модулю
        int loc_length = locations.Length;
        int[,] ways = new int[fuel + 1, loc_length]; //двумерный массив (табличка)

        ways[fuel, start] = 1; // изначально способ только один (оказаться в городе "старт")

        for (int f = fuel; f >= 0; f--) // разные варианты траты топлива
        {
            for (int city = 0; city < loc_length; city++) // выбираем следующий город
            {
                if (ways[f, city] == 0) continue;

                for (int next = 0; next < loc_length; next++) //  доступные следующие города
                {
                    if (next == city) continue; // не едем в город, в котором уже находимся

                    int cost = Math.Abs(locations[city] - locations[next]); // траты бензина ( модуль разности)
                    if (f >= cost) // если бензин есть (на эту поездку)
                    {
                        
                        ways[f - cost, next] = (ways[f - cost, next] + ways[f, city]) % mod;
                    }
                }
            }
        }

        int answ = 0;
        for (int f = 0; f <= fuel; f++)
            answ = (answ + ways[f, finish]) % mod; // сумма всех вариантов

        return answ;
    }
}