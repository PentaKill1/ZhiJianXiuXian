using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class UIPanelInfo: ISerializationCallbackReceiver
{
    [NonSerialized]
    public UIPanelType panelType;

    public string panelTypeString;
    public string path;

    //反序列化 从文本信息转到 对象
    public void OnAfterDeserialize()
    {
        //Debug.Log(panelTypeString);
        UIPanelType type = (UIPanelType)System.Enum.Parse(typeof(UIPanelType), panelTypeString);
        panelType = type;
    }
    // 序列化前 调用  把枚举类型转变为文本
    public void OnBeforeSerialize()
    {

    }
}
