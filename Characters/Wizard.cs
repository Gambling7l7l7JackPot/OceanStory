namespace OceanStory.Characters
{
    internal class Wizard : Character
    {
        public Wizard(string name, string job, float atk, float def, int hp, int maxHp, int mp, int maxMp) : base(name, job, atk, def, hp, maxHp, mp, maxMp)
        {
            Job = "마법사";
        }
    }
}
