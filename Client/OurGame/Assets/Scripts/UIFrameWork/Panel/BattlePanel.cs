using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattlePanel : BasePanel{

    public GameObject monsterList;
    public GameObject monster;
    public GameObject messagePawn;//信息管理
    public GameObject messageTip;
    private bool isNeedUpdate = false;
    public Text playerName;
    public Text hp;
    public Text numIndex;//回合数
    public Slider slider;
    private void Start()
    {
        for (int i = 0; i < BattleManager.Instance.battleMonsterList.Count;i++)
        {
            GameObject go = GameObject.Instantiate(monster);
            go.transform.GetComponent<monsterUI>().id = i;
            go.gameObject.transform.SetParent(monsterList.transform);
        }
        slider.maxValue = PlayerManager.Instance.playerAttribute.shengming;
    }
    void Update()
    {
        //状态管理
        if(BattleManager.Instance.battleState==BattleState.END)
        {
            for(int i=0;i<monsterList.transform.childCount;i++)
            {
                Destroy(monsterList.transform.GetChild(i).gameObject);
            }
        }
        if(BattleManager.Instance.isRefreshMonster)
        {
            Start();
            BattleManager.Instance.isRefreshMonster = false;
        }
        //战斗信息更新
        if (BattleManager.Instance.battleMesssage.Count != 0)
        {
            for (int i = 0; i < BattleManager.Instance.battleMesssage.Count; i++)
           {
               GameObject go = Instantiate(messageTip);
               go.GetComponent<Text>().text = BattleManager.Instance.battleMesssage[i];
               go.transform.SetParent(messagePawn.transform);
               BattleManager.Instance.battleMesssage.RemoveAt(i);

            if (messagePawn.transform.childCount>10)
             {
                Destroy(messagePawn.transform.GetChild(0).gameObject);
              }
           }
        }


            //主角更新
        playerName.text = PlayerManager.Instance.playerCoin.nicheng;
        slider.value = BattleManager.Instance.player.shengming;
        hp.text = BattleManager.Instance.player.shengming + "/" + slider.maxValue;
        numIndex.text = BattleManager.Instance.currBattleNumIndex + "/" + BattleManager.Instance.battleNumIndex;
        
    }
}
