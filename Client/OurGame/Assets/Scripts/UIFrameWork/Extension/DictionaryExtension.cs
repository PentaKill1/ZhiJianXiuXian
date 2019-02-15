using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 对Dictionary 的扩展
/// </summary>
public static class DictionaryExtension {

    /// <summary>
    /// 尝试根据Key得到value,得到了就返回value,得不到就返回null
    /// this Dictionary<Tkey,Tvalue> dict 这个字典表示我们要获取值的字典
    /// </summary>
   
    public static Tvalue TryGet<Tkey,Tvalue>(this Dictionary<Tkey,Tvalue> dict ,Tkey key)
    {
        Tvalue value;
        dict.TryGetValue(key, out value);
        return value;
    }
	
}
