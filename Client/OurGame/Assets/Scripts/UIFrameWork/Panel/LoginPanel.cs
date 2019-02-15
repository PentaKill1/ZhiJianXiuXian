using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using common;
public class LoginPanel : BasePanel
{

    public InputField usernameIF;
    public InputField passwordIF;
    private LoginRequest loginRequest;
    public GameObject errorTip;

    bool isShowErrorTip = false;
    //private Button loginButton;
    //private Button registerButton;
    void Awake()
    {
        loginRequest = GetComponent<LoginRequest>();
    }
    private void Update()
    {
        if(isShowErrorTip)
            errorTip.SetActive(true);
    }
    public void OnClickLoginBut()
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
        loginRequest.sendRequest(usernameIF.text, passwordIF.text);
    }
    public void OnClickRegister()
    {
        GameFacade.Instance.uiMng.PushPanelSync(UIPanelType.Register);
    }
    public void OnLoginResponse(ReturnCode returnCode,ReturnCode hasAccount)
    {
        //如果登录成功，判断是否有账户信息

        if (returnCode == ReturnCode.Success)
        {
            if (hasAccount == ReturnCode.Success)
            {
                GameFacade.Instance.isLogin = true;
                GameFacade.Instance.uiMng.PushPanelSync(UIPanelType.Practice);
                //登陆成功之后获取数据 
                string str = string.Format("{0},{1}", (int)PhotoBuf.LOADDATA, GameFacade.Instance.username);
                GameFacade.Instance.dataManager.LoadDate(str);
            }
            else
            {
                GameFacade.Instance.uiMng.PushPanelSync(UIPanelType.Create);
            }
        }
        else
        {
            isShowErrorTip = true;
        }
    }
    public override void OnEnter()
    {
        this.gameObject.SetActive(true);
    }
    public virtual void OnExit()
    {
        Debug.Log("界面隐藏了");
        this.gameObject.SetActive(false);
    }


}
