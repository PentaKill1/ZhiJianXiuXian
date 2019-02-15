using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using common;
public class PracticePanel : BasePanel {

    private CanvasGroup canvasGroup;
    public Text expTxt;
    public Text levNameTxt;
    public Text timeTxt;
    public string expStr;
    public string levStr;
    public int currExp;//当前经验
    public int currLev;//当前等级
    public string sliderText = "";
    public float sliderValue =0;
    public Slider expSlider;
    public float timer = 0;
    private void Start()
    {
      if(canvasGroup==null) canvasGroup = GetComponent<CanvasGroup>();
      Debug.LogError("进入了");
    }
    void Update()
    {
        if(GameFacade.Instance.isLoad)
        {
            UpdateUI();//更新经验;
        }
    }
    public void UpdateUI()
    {
        currLev = PlayerManager.Instance.playerCoin.lev;
        expStr = PlayerManager.Instance.playerCoin.exp + "/" + ReadCsvManager.Instance.levdata[currLev].targetExp;
        expTxt.text = expStr;
        levStr = ReadCsvManager.Instance.levdata[currLev].currName + ":";
        levNameTxt.text = levStr;
        sliderValue = PlayerManager.Instance.sliderValue;
        expSlider.value = sliderValue;
        int temp = 10 - (int)sliderValue;
        if (temp > 9)
        {
            timeTxt.text = "00:" + temp;
        }
        else
        {
            timeTxt.text = "00:0" + temp;
        }
    }
    public void AddLecButClick()
    {
        PlayerManager.Instance.AddLev();
    }
    public void OnPushPanel(string panelTypeString)
    {
        UIPanelType panelType = (UIPanelType)System.Enum.Parse(typeof(UIPanelType), panelTypeString);
        GameFacade.Instance.uiMng.PushPanelSync(panelType);
    }

}
