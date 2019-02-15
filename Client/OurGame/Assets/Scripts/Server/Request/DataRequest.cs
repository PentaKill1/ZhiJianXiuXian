using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using common;
public class DataRequest : BaseRequest
{
    public override void Awake()
    {
    }
    public  void RegisterAction()
    {
        requestCode = RequestCode.User;
        actionCode = ActionCode.GetPlayInspecture;
        base.Awake();
    }
    public void sendRequest(string username)
    {
        string data = username;
        base.SendRequest(data);
    }
    public override void OnResponse(string data)
    {
        resertPlayerIns(data);
        GameFacade.Instance.isLoad = true;
    }
    //初始化角色货币
    public void resertPlayerIns(string data)
    {
        //初始化角色货币
        string[] strs = data.Split(',');
        Debug.Log("加载角色数据成功"+strs.Length);

        ReturnCode returnCode = (ReturnCode)int.Parse(strs[0]);
        PlayerManager.Instance.playerCoin.nicheng = strs[1];
        PlayerManager.Instance.playerCoin.qianneng = int.Parse(strs[2]);
        PlayerManager.Instance.playerCoin.jinbi = int.Parse(strs[3]);
        PlayerManager.Instance.playerCoin.yuanbao = int.Parse(strs[4]);
        PlayerManager.Instance.playerCoin.lingshi = int.Parse(strs[5]);
        PlayerManager.Instance.playerCoin.exp = int.Parse(strs[6]);
        PlayerManager.Instance.playerCoin.lev = int.Parse(strs[7]);
        //初始化角色属性
        PlayerManager.Instance.playerAttribute.shengming = int.Parse(strs[9]);
        PlayerManager.Instance.playerAttribute.fangyu = int.Parse(strs[10]);
        PlayerManager.Instance.playerAttribute.gongji = int.Parse(strs[11]);
        PlayerManager.Instance.playerAttribute.shanbi = int.Parse(strs[12]);
        PlayerManager.Instance.playerAttribute.baoji = int.Parse(strs[13]);
        PlayerManager.Instance.playerAttribute.tili = int.Parse(strs[14]);
        PlayerManager.Instance.playerAttribute.liliang = int.Parse(strs[15]);
        PlayerManager.Instance.playerAttribute.shenfa = int.Parse(strs[16]);
        PlayerManager.Instance.playerAttribute.naili = int.Parse(strs[17]);

        Debug.Log("角色生命值位" + int.Parse(strs[9]));
        if (returnCode == ReturnCode.Success)
        {

            Debug.Log("获取角色数据成功");
        }
    }
}
