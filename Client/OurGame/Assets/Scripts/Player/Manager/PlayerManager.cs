using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using common;
//游戏每个模块的数据管理类
public class PlayerManager : MonoBehaviour
{
    private static PlayerManager _instance;
    public static PlayerManager Instance
    {
        get
        {
            return _instance;
        }
    }
    public PlayCoin playerCoin;//角色货币
    public PlayAttribute playerAttribute;//角色属性
    private float timer = 0;
    public float sliderValue = 0;
    void Awake()
    {
        _instance = GameObject.Find("Manager").GetComponent<PlayerManager>();
    }
    void Update()
    {
        if (GameFacade.Instance.isLoad)
        {
            AddExp();
        }
    }
    //增加经验
    void AddExp()
    {
        sliderValue += Time.deltaTime;
        if (sliderValue > 10)
        {
            sliderValue = 0;
            Debug.Log("获取经验");
            string str = string.Format("{0},{1},{2}", (int)PhotoBuf.ADDEXP, name, ReadCsvManager.Instance.levdata[playerCoin.lev].currExpRate);
            GameFacade.Instance.dataManager.LoadDate(str);
        }
    }
    //升级
    public void AddLev()
    {
        if(playerCoin.exp>=ReadCsvManager.Instance.levdata[playerCoin.lev].targetExp)
        {
            //减去目标经验
            playerCoin.exp -= ReadCsvManager.Instance.levdata[playerCoin.lev].targetExp;
            string str = string.Format("{0},{1},{2}", (int)PhotoBuf.ADDLEV, name, playerCoin.exp);
            GameFacade.Instance.dataManager.LoadDate(str);
        }
        else
        {
            Debug.LogError("经验不足，升级失败");
        }
    }
}
