namespace OceanStory
{
    // 콘솔 글씨 색 출력 매니저
    internal class ColorManager
    {
        public void ColorText(int num)
        {
            ConsoleColor[] color = { ConsoleColor.White, ConsoleColor.Red, ConsoleColor.DarkRed, ConsoleColor.DarkCyan, ConsoleColor.DarkRed, ConsoleColor.Magenta, ConsoleColor.Yellow, ConsoleColor.DarkGreen };
            Console.ForegroundColor = color[num]; // 0번 흰색, 1번 빨강, 2번 진한빨강, 3번 진한하늘?, 4번 보라?자주, 5번 노랑, 6번 진한녹색 
        }
        public void CheckName(int i) // 몬스터에 맞게 색깔 조정
        {
            if (Program.BattleManager.monsters[i].Name == "魔王 [Boss]디아블로")
            {
                ColorText(1);
            }
            else if (Program.BattleManager.monsters[i].Name == "와이번")
            {
                ColorText(2);
            }
            else if (Program.BattleManager.monsters[i].Name == "블루골렘")
            {
                ColorText(3);
            }
            else if (Program.BattleManager.monsters[i].Name == "레드골렘")
            {
                ColorText(4);
            }
            else if (Program.BattleManager.monsters[i].Name == "공허충")
            {
                ColorText(5);
            }
            else if (Program.BattleManager.monsters[i].Name == "대포미니언")
            {
                ColorText(6);
            }
            else
            {
                ColorText(7);
            }
        }
    }
}