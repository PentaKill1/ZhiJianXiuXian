using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class uiMainView : MonoBehaviour {


    public Text playerNameText;
    public Text expText;
    public Text levNameText;
    public Slider extSlider;
    private void Awake()
    {
    }
    public void UpdateExpText(string name,string name2,string name3)
    {

        expText.text = name + "/" + name2;
        levNameText.text = name3;
    }
    /****经验滑动条，，投机取巧***/
    private float timer = 0;
    private void Update()
    {
        timer += Time.deltaTime;
        extSlider.value = timer / 5;
        if (extSlider.value >= 1)
        {
            extSlider.value = 0;    
            timer = 0;
        }
    }
}
