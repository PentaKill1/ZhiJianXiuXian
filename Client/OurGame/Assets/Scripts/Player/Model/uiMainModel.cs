using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiMainModel : MonoBehaviour {

    //******测试数据******
    private int currLev=1;
    //******************** 
    private uiMainView m_MainView;

    private List<LevData> levData;
    private LevData currLevData; //当前境界的数据
    private int currlev=0;//记录当前等级的位置
    private int playerEXP = 1;//当前角色的经验

    void Awake() {
        levData = ReadCsvManager.Instance.ReadLexData();
        currLevData = levData[currlev];
        m_MainView = this.GetComponent<uiMainView>();
    }
    private void Start()
    {
        UpdateEXPT();
    }
    public void UpdateEXPT()
    {
        playerEXP += currLevData.currExpRate;
        m_MainView.UpdateExpText(playerEXP.ToString(), currLevData.targetExp.ToString(),currLevData.currName);
    }
    public void UpdateLev()
    {
        if(playerEXP>=currLevData.targetExp)
        {
            playerEXP -= currLevData.targetExp;
            currlev++;
            currLevData = levData[currlev];
            m_MainView.UpdateExpText(playerEXP.ToString(), currLevData.targetExp.ToString(), currLevData.currName);
        }
    }
}
