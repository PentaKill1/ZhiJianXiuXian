using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using common;
public class CreateRequest : BaseRequest
{

    private CreatePanel createPanel;
    public override void Awake()
    {
        requestCode = RequestCode.User;
        actionCode = ActionCode.Create;
        createPanel = GetComponent<CreatePanel>();
        base.Awake();
    }
    public void sendRequest(string username)
    {
        string data = username;
        base.SendRequest(data);
    }
    public override void OnResponse(string data)
    {
        string[] strs = data.Split(',');
        Debug.Log("进入成功");
        ReturnCode returnCode = (ReturnCode)int.Parse(strs[0]);
        createPanel.OnCreateResponse(returnCode);
    }
}
