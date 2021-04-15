public class Skills
{
   public enum SkillType
    {
        TargetChar,
        TargetParty,
    }
    public enum SkillSpeed
    {
        Fast,
        Normal,
        Slow
    }
    public enum SelectType
    {
        SelectFriend,
        SelectEnemy,
        RandomEnemy,
        RandomFriend,
        None
    }
    public SkillType type;
    public SkillSpeed speed;
    public SelectType selectType;
    //public string[] stats;
    //public string[][] amounts;//if number use number, if stat get stat from character, second row is self or enemy
    public string[,] statsAffect;//0:who 1:stat
    public string[,] statsBasedOn;//0:who 1:stat 2:stat(gets diff if exists)
    public string[] equation;

    public int spCost;
    public int statusEffectChance;
    public string[] statusEffect;
    public int[] statusEffectAmt;
    public string target;
    public bool usable;

    public string name;
    public string description;
}