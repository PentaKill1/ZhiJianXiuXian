using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using common;
public class LiLianPanel : BasePanel
{

    void Awake()
    {
    }
    public void OnClickMapOne()
    {
        //判断是否在战斗
        if (BattleManager.Instance.battleState == BattleState.NONE)
        {
            BattleManager.Instance.ReadyBattle(0);
        }
        GameFacade.Instance.uiMng.PushPanelSync(UIPanelType.Battle);
    }
    public void OnClickMapTwo()
    {
        Debug.Log("加载地图2");
    }
}
