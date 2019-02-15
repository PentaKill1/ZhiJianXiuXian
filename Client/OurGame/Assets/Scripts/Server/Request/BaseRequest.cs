using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using common;
public class BaseRequest : MonoBehaviour
{
    protected RequestCode requestCode = RequestCode.None;
    protected ActionCode actionCode = ActionCode.None;
    protected GameFacade _facade;

    protected GameFacade facade
    {
        get
        {
            if (_facade == null)
                _facade = GameFacade.Instance;
            return _facade;
        }
    }
    // Use this for initialization
    public virtual void Awake()
    {
        Debug.Log(actionCode);
        facade.AddRequest(actionCode, this);
    }

    protected void SendRequest(string data)
    {
        facade.SendRequest(requestCode, actionCode, data);
    }

    public virtual void SendRequest() { }
    public virtual void OnResponse(string data) { }

    public virtual void OnDestroy()
    {
        if (facade != null)
            facade.RemoveRequest(actionCode);
    }
}
