using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using common;
public class GameFacade : MonoBehaviour
{

    private static GameFacade _instance;
    public static GameFacade Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("GameFacade").GetComponent<GameFacade>();
            }
            return _instance;
        }
    }
    /// <summary>
    ///  管理类
    /// </summary>

    public UIManager uiMng;
    public DataManager dataManager;
    private RequestManager requestMng;
    private ClientManager clientMng;

    /// <summary>
    /// 状态管理
    /// </summary>
    public GameObject mainPancel;
    public bool isLogin = false;
    public bool isLoad = false;
    public string username;
    private void Awake()
    {
        uiMng = UIManager.Instance;
        dataManager = DataManager.Instance;
    }

    // Use this for initialization
    void Start()
    {
        InitManager();
    }

    // Update is called once per frame
    void Update()
    {
        if (isLogin)
            mainPancel.SetActive(true);
        UpdateManager();
    }

    private void OnDestroy()
    {
        DestroyManager();
    }

    private void InitManager()
    {
        requestMng = new RequestManager(this);
        clientMng = new ClientManager(this);
        requestMng.OnInit();
        clientMng.OnInit();
        uiMng.OnInit();
        dataManager.daterequest.RegisterAction();
    }
    private void DestroyManager()
    {
        requestMng.OnDestroy();
        clientMng.OnDestroy();
    }
    private void UpdateManager()
    {
        requestMng.Update();
        clientMng.Update();
        uiMng.Update();
    }

    public void AddRequest(ActionCode actionCode, BaseRequest request)
    {
        requestMng.AddRequest(actionCode, request);
    }

    public void RemoveRequest(ActionCode actionCode)
    {
        requestMng.RemoveRequest(actionCode);
    }
    public void HandleReponse(ActionCode actionCode, string data)
    {
        requestMng.HandleReponse(actionCode, data);
    }
    public void SendRequest(RequestCode requestCode, ActionCode actionCode, string data)
    {
        clientMng.SendRequest(requestCode, actionCode, data);
    }

}
