using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using common;
public class RegisterRequest : BaseRequest
{

    private RegisterPanel registerPanel;
    public override void Awake()
    {
        requestCode = RequestCode.User;
        actionCode = ActionCode.Register;
        registerPanel = GetComponent<RegisterPanel>();
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
        ReturnCode returnCode = (ReturnCode)int.Parse(strs[0]);
        registerPanel.OnRegisterResponse(returnCode);
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
