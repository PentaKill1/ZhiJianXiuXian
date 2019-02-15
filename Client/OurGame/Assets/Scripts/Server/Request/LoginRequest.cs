using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using common;

public class LoginRequest : BaseRequest
{
    private LoginPanel loginPanel;
    // Use this for initialization
    public override void Awake()
    {
        requestCode = RequestCode.User;
        actionCode = ActionCode.Login;
        loginPanel = GetComponent<LoginPanel>();
        base.Awake();
    }
    public void sendRequest(string username, string password)
    {
        string data = username + "," + password;
        base.SendRequest(data);
    }
    public override void OnResponse(string data)
    {
        string[] strs = data.Split(',');
        Debug.Log("进入成功");
        ReturnCode returnCode = (ReturnCode)int.Parse(strs[0]);
        ReturnCode hasAccount = (ReturnCode)int.Parse(strs[1]);
        GameFacade.Instance.username = strs[2];
        loginPanel.OnLoginResponse(returnCode,hasAccount);
        if (returnCode == ReturnCode.Success)
        {
   
           // UIManager.Instance.PushPanel(UIPanelType.MainMenu);
            //string username = strs[1];
            //int totalCount = int.Parse(strs[2]);
            //int winCount = int.Parse(strs[3]);
            //UserData ud = new UserData(username, totalCount, winCount);
            //facade.SetUserData(ud);
        }
    }

}
