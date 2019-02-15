using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using common;
public class RegisterPanel : BasePanel
{

    public InputField usernameIF;
    public InputField passwordIF;
    public InputField mailIF;
    private RegisterRequest registerRequest;
    void Awake()
    {
        registerRequest = GetComponent<RegisterRequest>();
    }
    public void OnClickRegisterBut()
    {
        string msg = "";
        if (string.IsNullOrEmpty(usernameIF.text))
        {
            msg += "用户名不能为空 ";
        }
        if (string.IsNullOrEmpty(passwordIF.text))
        {
            msg += "密码不能为空 ";
        }
        Debug.Log("按钮点击成功");
        registerRequest.sendRequest(usernameIF.text, passwordIF.text);
    }
    public void OnRegisterResponse(ReturnCode returnCode)
    {
      
        if (returnCode == ReturnCode.Success)
        {
            GameFacade.Instance.uiMng.PushPanelSync(UIPanelType.Login);
        }
    }
    public override void OnEnter()
    {
        this.gameObject.SetActive(true);
    }
    public override void OnExit()
    {
        Debug.Log("界面隐藏了");
        this.gameObject.SetActive(false);
    }

    public void OnClickReturn()
    {
        GameFacade.Instance.uiMng.PushPanelSync(UIPanelType.Login);
    }
}
