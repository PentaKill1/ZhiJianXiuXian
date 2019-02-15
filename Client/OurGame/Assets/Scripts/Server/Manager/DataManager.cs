using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using common;
//这个类书负责数据通讯的类
public class DataManager : MonoBehaviour {
    private static DataManager _instance;
    public static DataManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("GameFacade").GetComponent<DataManager>();
            }
            return _instance;
        }
    }
    public DataRequest daterequest;
    void Awake()
    {
        daterequest = GetComponent<DataRequest>();
    }
    public void LoadDate(string str)
    {
        //string str = string.Format("{0},{1}", (int)type, name);
        daterequest.sendRequest(str);
    }

}
