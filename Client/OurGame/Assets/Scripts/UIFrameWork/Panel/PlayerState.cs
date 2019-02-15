using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerState : BasePanel {

    private CanvasGroup canvasGroup;
    public Text nicheng;
    public Text jingjie;
    public Text shengming;
    public Text gongji;
    public Text fangyu;
    public Text shanbi;
    public Text tili;
    public Text naili;
    public Text liliang;
    public Text baoji;
    public Text shenfa;
    private void Start()
    {
        if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();

    }
    public override void OnEnter()
    {
        if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }
    public override void OnExit()
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }
    void Update()
    {
        if (GameFacade.Instance.isLoad)
        {
            UpdateUI();//更新经验;
        }
    }
    public void UpdateUI()
    {
        nicheng.text = PlayerManager.Instance.playerCoin.nicheng;
        int temp = PlayerManager.Instance.playerCoin.lev;
        jingjie.text = ReadCsvManager.Instance.levdata[temp].currName;
        shengming.text = PlayerManager.Instance.playerAttribute.shengming.ToString();
        gongji.text = PlayerManager.Instance.playerAttribute.gongji.ToString();
        fangyu.text = PlayerManager.Instance.playerAttribute.fangyu.ToString();
        shanbi.text = PlayerManager.Instance.playerAttribute.shanbi.ToString(); ;
        tili.text = PlayerManager.Instance.playerAttribute.tili.ToString();
        naili.text = PlayerManager.Instance.playerAttribute.naili.ToString();
        liliang.text = PlayerManager.Instance.playerAttribute.liliang.ToString();
        baoji.text = PlayerManager.Instance.playerAttribute.baoji.ToString();
        shenfa.text = PlayerManager.Instance.playerAttribute.shenfa.ToString();
    }
}
