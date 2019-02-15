using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using common;

public class CreatePanel : BasePanel
{
    public InputField accountName;
    private CreateRequest createReqest;

    void Awake()
    {
        createReqest = GetComponent<CreateRequest>();
    }
    public void OnClickCreateButton()
    {
        string msg = "";
        if (string.IsNullOrEmpty(accountName.text))
        {
            Debug.Log("角色名不能为空");
        }
        createReqest.sendRequest(accountName.text);
    }
    public void OnCreateResponse(ReturnCode returnCode)
    {
        //如果登录成功，判断是否有账户信息

        if (returnCode == ReturnCode.Success)
        {
            GameFacade.Instance.isLogin = true;
            //登陆成功之后获取数据
            string str = string.Format("{0},{1}", (int)PhotoBuf.LOADDATA, GameFacade.Instance.username);
            GameFacade.Instance.dataManager.LoadDate(str);
           GameFacade.Instance.uiMng.PushPanelSync(UIPanelType.Practice);
        }
    }
}
