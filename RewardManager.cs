using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory
{
    internal class RewardManager
    {
        public void CharacterLevelUp()
        {
            Program.Character.MaxHp += 5;
            Program.Character.Atk += 0.5f;
            Program.Character.Def += 1;
            Program.Character.Level += 1;
        }
        public int CharacterExpUp()
        {
            int beforeExp = Program.Character.Exp;
            foreach(var monster in Program.BattleManager.monsters)
            {
                Program.Character.Exp += monster.Exp;
            }
            return beforeExp;
        }
        public int CharacterLevelUpCheck()
        {
            int beforeLevel = Program.Character.Level;
            int[] RequiredExp = { 10, 35, 65, 100 };
            while (RequiredExp[Program.Character.Level - 1] <= Program.Character.Exp)
            {
                Program.Character.Exp -= RequiredExp[Program.Character.Level - 1];
                CharacterLevelUp();
            }
            return beforeLevel;
        }
    }
}
