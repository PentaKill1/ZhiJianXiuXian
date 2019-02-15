using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour {
    //游戏启动器 
	void Start () {
        //启动主界面
      GameFacade.Instance.uiMng.PushPanelSync(UIPanelType.Login);
    }
	
}
