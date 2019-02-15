using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using common;
public class BattleManager : MonoBehaviour {

    private static BattleManager instance;
    public List<string> battleMesssage=new List<string>();
    public static BattleManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.Find("Manager").GetComponent<BattleManager>();
            return instance;
        }
    }

    private float attackTime=0.5f;//攻击时间
    private float monsterAttackTime = 0;//怪物攻击时间
    private static int monsterAttackIndex = 0;//当前攻击怪物ID
    private float findTime = 1f;//查找时间
    private bool isPlayerAttack=true;//是否是玩家攻击
    public int battleNumIndex=3;//战斗回合总数
    public int currBattleNumIndex;//当前战斗数

    private int mapId = 0;//当前地图ID
    private int monsterMixID = 0;//怪物最小ID
    private int monsterMaxID = 0;//怪物最大ID

    public bool isRefreshMonster = false;//是否刷新了怪物
    
    private List<monsterData> monsterList=new List<monsterData>();//怪物列表
    public List<monsterData> battleMonsterList=new List<monsterData>();//当前战斗怪物列表
    public PlayIns player = new PlayIns();//



    public BattleState battleState = BattleState.NONE;

    private void  InitPlayer()
    {
        player.shengming = PlayerManager.Instance.playerAttribute.shengming;
        player.gongji = PlayerManager.Instance.playerAttribute.gongji;
    }
    void Update()
    {

        if (battleState == BattleState.FIND)
        {
            FindMonster();
        }
        else if (battleState == BattleState.ATTACK)
        {
            BattleIng();
        }
        else if (battleState == BattleState.ENDING)
        {

        }
        else if (battleState == BattleState.END)
        {
            BattleEnd();
        }
    }
    //准备战斗
    public void ReadyBattle(int id)
    {
        //重置主角
        InitPlayer();
        //设置怪物ID
        monsterMixID=ReadCsvManager.Instance.mapdata[id].mixMonsterID;
        monsterMaxID=ReadCsvManager.Instance.mapdata[id].maxMonsterID;
        //设置战斗回合数
        currBattleNumIndex = 1;
        //设置怪物列表
        mapId = id;
        Debug.LogError("当前怪物数量为" + ReadCsvManager.Instance.monsterdata.Count);
        for(int i=0;i<ReadCsvManager.Instance.monsterdata.Count;i++)
        {
            if(ReadCsvManager.Instance.monsterdata[i].ID>=monsterMixID&&ReadCsvManager.Instance.monsterdata[i].ID<monsterMaxID)
            {
                Debug.LogError("加入了怪物");
                monsterData temp = new monsterData();
                temp.monsterName=ReadCsvManager.Instance.monsterdata[i].monsterName;
                temp.gongji = ReadCsvManager.Instance.monsterdata[i].gongji;
                temp.shengming = ReadCsvManager.Instance.monsterdata[i].shengming;
                monsterList.Add(temp);
            }
        }
        battleState = BattleState.FIND;

    }
    //搜寻怪物
    private void FindMonster()
    {
        //重置角色信息
        InitPlayer();
        if(battleMonsterList.Count!=0)
        {
            battleMonsterList.Clear();
        }
        int num = Random.Range(1, 3);
        for(int i=0;i<num;i++)
        {
            int id = Random.Range(0, monsterList.Count);
            monsterData temp = new monsterData();
            temp.monsterName = monsterList[i].monsterName;
            temp.lev = monsterList[i].lev;
            temp.gongji = monsterList[i].gongji;
            temp.shengming = monsterList[i].shengming;
            temp.fangyu = monsterList[i].fangyu;
            battleMonsterList.Add(temp);
        }
        battleState = BattleState.ATTACK;

        Debug.LogError("搜寻到怪物数量：" + battleMonsterList.Count);
    }
    //战斗
    private void BattleIng()
    {
        //Debug.LogError("正在战斗");
        attackTime -= Time.deltaTime;
        if(attackTime<=0)
        {
            if(!isPlayerAttack)
            {
                Debug.LogError("主角发起攻击");
                PlayerAttack();
                isPlayerAttack = !isPlayerAttack;
                Debug.LogError("一轮战斗结束");
                attackTime = 1;
            }
            else
            {
                Debug.LogError("怪物发起攻击");
                MonsterAttack();     
            }

        }
    }
    private void PlayerAttack()
    {
        ////将当前存活的怪物ID存起来
        List<monsterData> tempMonster = new List<monsterData>();
        for (int i = 0; i < battleMonsterList.Count; i++)
        {
            if (battleMonsterList[i].shengming > 0)
            {
                tempMonster.Add(battleMonsterList[i]);
            }
        }
        Debug.LogError("当前怪物:" + battleMonsterList.Count + "存活数量为" + tempMonster.Count);
        //随即一个怪物造成攻击力的伤害
        int index = Random.Range(0, tempMonster.Count);
        int monsterHP = tempMonster[index].shengming;
        monsterHP -= player.gongji;
        battleMesssage.Add("你对" + tempMonster[index].monsterName + "造成" + player.gongji + "伤害");
        //修改生命值
        if (monsterHP <= 0)
        {
            monsterHP = 0;
        }
        tempMonster[index].shengming = monsterHP;
       //遍历所有的怪物
        for(int i=0;i<tempMonster.Count;i++)
        {
            if(tempMonster[i].shengming<=0)
                tempMonster.Remove(tempMonster[i]);
        }
        //判断是否有存活的怪物
        if(tempMonster.Count<=0)
        {
            battleState = BattleState.END;
        }
    }
    private void MonsterAttack()
    {
        monsterAttackTime += Time.deltaTime;

        //每个怪物向主角发起攻击
        for (; monsterAttackIndex < battleMonsterList.Count && monsterAttackTime > 1 * monsterAttackIndex; )
        {
            int playerHp = player.shengming;
            Debug.LogError("角色生命值位" + playerHp + "当前怪物数量为" + battleMonsterList.Count + "当前攻击怪物位" + monsterAttackIndex);
            playerHp -= battleMonsterList[monsterAttackIndex].gongji;
            //角色死亡
            if (playerHp <= 0)
            {
                Debug.LogError("角色死亡");
                battleState = BattleState.END;
            }
            else
            {
                player.shengming = playerHp;
            }
            battleMesssage.Add(battleMonsterList[monsterAttackIndex].monsterName + "对你造成" + player.gongji + "伤害");
            monsterAttackIndex++;
            if(monsterAttackIndex==battleMonsterList.Count)
            {
                monsterAttackIndex = 0;
                isPlayerAttack = !isPlayerAttack;
                Debug.LogError("一轮战斗结束");
                attackTime = 1;
                monsterAttackTime=0;
            }
        }
    }
    private void BattleEnd()
    {
        findTime += Time.deltaTime;
        //战斗结束之后判断是否结束回合
        if(currBattleNumIndex<=battleNumIndex)
        {
            Debug.LogError("正在寻找怪物");
            if(findTime>5)
            {
                FindMonster();
                currBattleNumIndex++;
                findTime =0;
                isRefreshMonster = true;
            }
        }
        else
        {
            battleState = BattleState.NONE;
            Debug.LogError("准备返回主界面");
            if(findTime>2)
            {
                GameFacade.Instance.uiMng.PushPanelSync(UIPanelType.Battle);
            }
        }
    }
}
