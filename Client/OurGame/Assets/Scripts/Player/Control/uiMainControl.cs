using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiMainControl : MonoBehaviour {

    private float timer = 0;
    private uiMainModel m_MainModel;
    private void Awake()
    {
        m_MainModel = this.GetComponent<uiMainModel>();
    }

    private void Update()
    {
        UpdateEXPT();
    }
    private void UpdateEXPT()
    {
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            timer = 0;
            m_MainModel.UpdateEXPT();
        }
    }
    public void UpdateLevClick()
    {
        m_MainModel.UpdateLev();
    }

}
