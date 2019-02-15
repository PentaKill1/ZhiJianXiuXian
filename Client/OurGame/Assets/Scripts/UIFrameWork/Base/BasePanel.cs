using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel : MonoBehaviour {
    /// <summary>
    /// 界面被显示出来
    /// </summary>
	public virtual void OnEnter()
    {
        this.gameObject.SetActive(true);
    }

    /// <summary>
    /// 界面暂停
    /// </summary>
    public virtual void OnPause()
    {

    }
    
    /// <summary>
    /// 界面继续
    /// </summary>
    public virtual void OnResume()
    {

    }

    /// <summary>
    /// 界面退出 界面不显示 界面被关闭
    /// </summary>
    public virtual void OnExit()
    {
        this.gameObject.SetActive(false);
    }
}
