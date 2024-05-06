using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory.Scenes
{
    internal class SkillScene : Scene
    {
        public override void RunScene() 
        {
            while (true) // 스킬 사용 출력 씬
            {
                Console.Clear();
                Console.WriteLine("Battle!!");
                Console.WriteLine("\n{0}의 {1}!!", Program.Character.Name, Program.BattleManager.skillName);

                if (Program.BattleManager.TargetIndex == 100) // 지정값 체력회복은 타겟의 입력값을 100으로 설정하여 if문을 탐
                {
                    Console.WriteLine($"\n플레이어의 체력이 회복되었습니다. 현재 체력 : {Program.Character.Hp}");
                    Console.WriteLine("\n0. 다음");
                    int getOut = Program.SceneManager.GetUserInput(0);
                    if (getOut == 0)
                    {
                        Program.BattleManager.EnemyAttack();
                        break;
                    }
                }
                if (Program.BattleManager.SoloTarget == 1) // 타겟이 한 마리일때
                {
                    Program.ColorManager.CheckName(Program.BattleManager.TargetIndex);
                    Console.WriteLine("Lv.{0} {1} 을(를) 맞췄습니다. [데미지 :{2}]",
                        Program.BattleManager.monsters[Program.BattleManager.TargetIndex].Level,
                        Program.BattleManager.monsters[Program.BattleManager.TargetIndex].Name,
                        Program.BattleManager.TargetDamage);
                    Program.ColorManager.ColorText(0);
                    Console.WriteLine("\nLv.{0} {1}",
                        Program.BattleManager.monsters[Program.BattleManager.TargetIndex].Level,
                        Program.BattleManager.monsters[Program.BattleManager.TargetIndex].Name);
                    Console.WriteLine("HP {0} -> {1}",
                        Program.BattleManager.TargetBeforeHp,
                        Program.BattleManager.monsters[Program.BattleManager.TargetIndex].MonsterDead ?
                        "Dead" : Program.BattleManager.monsters[Program.BattleManager.TargetIndex].Hp);
                }

                else if (Program.BattleManager.SoloTarget == 2) // 타겟이 두 마리일때
                {
                    for (int i = 0; i < Program.SkillManager.getMonster.Count; i++)
                    {
                        if (Program.BattleManager.monsters[Program. BattleManager.AttacktargetList[i]].MonsterDead)
                        {
                            continue;
                        }
                        Program.ColorManager.CheckName(Program.BattleManager.AttacktargetList[i]);
                        Console.WriteLine("\nLv.{0} {1} 을(를) 맞췄습니다. [데미지 :{2}]",
                        Program.BattleManager.monsters[Program.BattleManager.AttacktargetList[i]].Level,
                        Program.BattleManager.monsters[Program.BattleManager.AttacktargetList[i]].Name,
                        Program.BattleManager.TargetDamage);
                        Program.ColorManager.ColorText(0);
                        Console.WriteLine("HP {0} -> {1}\n",
                        Program.BattleManager.TwoTargetBeforeHp[i],
                        Program.BattleManager.monsters[Program.BattleManager.AttacktargetList[i]].Hp <= 0 ?
                        "Dead" : Program.BattleManager.monsters[Program.BattleManager.AttacktargetList[i]].Hp);
                        if (Program.BattleManager.monsters[Program.BattleManager.AttacktargetList[i]].Hp <= 0)
                        {
                            Program.BattleManager.monsters[Program.BattleManager.AttacktargetList[i]].MonsterDead = true;
                            Program.QuestManager.ProgressQuest(0); // 몬스터 처치 퀘스트 진행도 증가
                        }

                    }
                }

                else if (Program.BattleManager.SoloTarget == 4) // 타겟이 전부일때
                {
                    for (int i = 0; i < Program.BattleManager.monsters.Count; i++)
                    {
                        if (Program.BattleManager.monsters[i].MonsterDead)
                        {
                            continue;
                        }
                        Program.ColorManager.CheckName(i);
                        Console.WriteLine("\nLv.{0} {1} 을(를) 맞췄습니다. [데미지 :{2}]",
                        Program.BattleManager.monsters[i].Level,
                        Program.BattleManager.monsters[i].Name,
                        Program.BattleManager.TargetDamage);
                        Program.ColorManager.ColorText(0);
                        Console.WriteLine("HP {0} -> {1}\n",
                        Program.BattleManager.BothTargetBeforeHp[i],
                        Program.BattleManager.monsters[i].Hp <= 0?
                        "Dead" : Program.BattleManager.monsters[i].Hp);
                        if (Program.BattleManager.monsters[i].Hp <= 0)
                        {
                            Program.BattleManager.monsters[i].MonsterDead = true;
                            Program.QuestManager.ProgressQuest(0); // 몬스터 처치 퀘스트 진행도 증가
                        }

                    }
                }

                Console.WriteLine("\n0. 다음");
                int input = Program.SceneManager.GetUserInput(0);
                if (input == 0)
                {
                    Program.BattleManager.EnemyAttack();
                    break;
                }
            }
        }
    }
}
