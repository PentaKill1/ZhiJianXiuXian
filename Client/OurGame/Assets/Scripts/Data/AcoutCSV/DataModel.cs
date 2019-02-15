//等级相关
public struct LevData
{
   public string currName;
   public int targetExp;
   public int currExpRate;
}
//地图相关
public struct mapData
{
    public int ID;
    public string mapName;
    public int mixLev;
    public int mixMonsterID;
    public int maxMonsterID;
}
//怪物相关
public class monsterData
{
    public int ID;
    public string monsterName;
    public int lev;
    public int shengming;
    public int gongji;
    public int fangyu;
}
//主角相关
public class PlayIns
{
    public float baoji;
    public int fangyu;
    public int gongji;
    public int liliang;
    public int naili;
    public float shanbi;
    public int shenfa;
    public int shengming;
    public int tili;
}
//战斗状态
public enum BattleState
{
    NONE,
    READY,//准备
    FIND,
    ATTACK,//正在打架
    ENDING,//战斗结束
    END,
}
//装备类型
public enum EquipmentType
{
    NONE,
    WEAPON,
    FANGU,
}
//装备相关
public class Equipment
{
    public int ID;
    public string name;
    public int zhiliang;
    public string description;
    public int type;
    public int lev;
    public int sell;
    public int gongji;
    public int fangyu;
    public int shengming;
    public int shanbi;
    public int baoji;
    public int tili;
    public int liliang;

}
