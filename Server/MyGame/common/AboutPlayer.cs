using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace common
{
    //角色货币
   public struct PlayCoin
   {
       public string nicheng;
       public int qianneng;
       public int jinbi;
       public int lingshi;
       public int yuanbao;
       public int exp;
       public int lev;
   }
    //角色属性
   public struct PlayAttribute
   {
       public int shengming;
       public int fangyu;
       public int gongji;
       public float shanbi;
       public float baoji;
       public int tili;
       public int liliang;
       public int shenfa;
       public int naili;
   }
    public enum PhotoBuf
    {
        LOADDATA,//初始化
        ADDLEV,//升级
        ADDEXP,//增加经验
    }
}
