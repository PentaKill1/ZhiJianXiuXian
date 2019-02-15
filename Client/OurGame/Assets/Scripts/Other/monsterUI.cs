using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class monsterUI : MonoBehaviour {
    public int id;//当前怪物ID
    public Text name;
    public Text hp;
    public Text lev;
    public Slider slider;
    void Start()
    {
        slider.maxValue = ReadCsvManager.Instance.monsterdata[BattleManager.Instance.battleMonsterList[id].ID].shengming;
    }
    void Update()
    {
        if (BattleManager.Instance.battleMonsterList[id] != null)
        {
            slider.value = BattleManager.Instance.battleMonsterList[id].shengming;
            name.text = BattleManager.Instance.battleMonsterList[id].monsterName;
            hp.text = BattleManager.Instance.battleMonsterList[id].shengming + "/" + ReadCsvManager.Instance.monsterdata[BattleManager.Instance.battleMonsterList[id].ID].shengming;
            lev.text = "lv." + BattleManager.Instance.battleMonsterList[id].lev.ToString();
        }
    }
}
