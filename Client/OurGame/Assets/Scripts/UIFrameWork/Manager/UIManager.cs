using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIManager:BaseManager
{
    #region 单例 1.定义一个静态对象 外界访问 内部构造 2. 构造方法私有化
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("新生成了一个对象");
                _instance = new UIManager();
            }
            return _instance;
        }
    }

    private UIManager()
    { 
        ParseUIPanelTypeJson();
    }
     public override void OnInit()
    {

    }
    #endregion 
    private Transform canvasTransform;
    private UIPanelType panelTypeToPush = UIPanelType.NONE;
    private Transform CanvasTransform
    {
        get
        {
            if(canvasTransform ==null)
            {
                canvasTransform = GameObject.Find("Canvas").transform;
            }
            return canvasTransform;
        }
    }
    private Dictionary<UIPanelType, string> panelPathDict;//存储面板prefab路径
    private Dictionary<UIPanelType, BasePanel> panelDict; //保存所有实例化面板的游戏物体身上的BasePanel组件
    private Stack<BasePanel> panelStack;

    /// <summary>
    /// 把某个页面入栈， 把某个页面显示在界面上 
    /// </summary>
    public void PushPanel(UIPanelType panelType)
    {
        if (panelStack == null) panelStack = new Stack<BasePanel>();
        //当界面上有页面的时候
        if(panelStack.Count>0)
        {
            BasePanel topPanel = panelStack.Peek();
            //topPanel.OnPause();
            topPanel.OnExit();
            panelStack.Pop();
        }
        BasePanel panel = GetPanel(panelType);
        panel.OnEnter();
        panelStack.Push(panel);
    }

    /// <summary>
    /// 出栈  把页面从界面上移除
    /// </summary>
    public void PopPanel()
    {
        if (panelStack == null) panelStack = new Stack<BasePanel>();

        if (panelStack.Count <= 0) return;
        //关闭栈顶页面显示
        BasePanel basePanel = panelStack.Pop();
        basePanel.OnExit();

        //继续界面显示
        if (panelStack.Count <= 0) return;
        BasePanel topPanel = panelStack.Peek();
        topPanel.OnResume();
    }
    public override void Update()
    {
        if (panelTypeToPush != UIPanelType.NONE)
        {
            PushPanel(panelTypeToPush);
            panelTypeToPush = UIPanelType.NONE;
        }
    }
    /// <summary>
    /// 根据面板类型，得到实例化面板
    /// </summary>
    private BasePanel GetPanel(UIPanelType panelType)
    {
        if(panelDict == null)
        {
            panelDict = new Dictionary<UIPanelType, BasePanel>();
        }

        BasePanel panel = panelDict.TryGet(panelType);

        if (panel == null)
        {
            //如果找不到，那么就找这个面板的prefab的路径，然后去根据prefab去实例化面板
            string path = panelPathDict.TryGet(panelType);
            GameObject instPanel = GameObject.Instantiate(Resources.Load(path)) as GameObject;
            instPanel.transform.SetParent(CanvasTransform,false);
            panelDict.Add(panelType, instPanel.GetComponent<BasePanel>());
            return instPanel.GetComponent<BasePanel>();
        }
        else
        {
            return panel;
        }
    }

    [Serializable]
    class UIPanelTypeJson
    {
        public List<UIPanelInfo> infoList;
    }

    private void ParseUIPanelTypeJson()
    {
        panelPathDict = new Dictionary<UIPanelType, string>();//初始化字典

        TextAsset ta =  Resources.Load<TextAsset>("UIPanelType");
        UIPanelTypeJson jsonObject = JsonUtility.FromJson<UIPanelTypeJson>(ta.text);

        foreach(UIPanelInfo info in jsonObject.infoList)
        {
            panelPathDict.Add(info.panelType, info.path);
        }
    }
    public void PushPanelSync(UIPanelType panelType)
    {
        Debug.Log("切换界面");
        panelTypeToPush = panelType;
    }
 
}
