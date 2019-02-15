using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenuPanel : BasePanel {

    public Text nicheng;
    public Text qianneng;
    public Text jinbi;
    public Text lingshi;
    public Text yuanbao;
    private void Start()
    {
        
    }
    void Update()
    {
        if (PlayerManager.Instance.playerCoin.lingshi != null)
        {
            nicheng.text = PlayerManager.Instance.playerCoin.nicheng;
            qianneng.text = PlayerManager.Instance.playerCoin.qianneng.ToString();
            jinbi.text = PlayerManager.Instance.playerCoin.jinbi.ToString();
            lingshi.text = PlayerManager.Instance.playerCoin.lingshi.ToString();
            yuanbao.text = PlayerManager.Instance.playerCoin.yuanbao.ToString();
        }
    }
   
    public void OnPushPanel(string panelTypeString)
    {
        UIPanelType panelType = (UIPanelType)System.Enum.Parse(typeof(UIPanelType), panelTypeString);
        GameFacade.Instance.uiMng.PushPanelSync(panelType);
    }
 
}
