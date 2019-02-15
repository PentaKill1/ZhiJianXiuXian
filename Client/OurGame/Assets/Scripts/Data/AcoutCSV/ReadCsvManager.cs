using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadCsvManager : MonoBehaviour {
    private static ReadCsvManager instance;
    public int c = 10;
    public static ReadCsvManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.Find("GameFacade").GetComponent<ReadCsvManager>();
            return instance;
        }   
    }
   public List<LevData> levdata;//等级相关
   public List<mapData> mapdata;//地图相关
   public List<monsterData> monsterdata;//怪物相关;
   public List<Equipment> equipmentdata;//装备相关
    void Awake()
    {
        levdata = ReadLexData();
        monsterdata = ReadMonsterData();
        mapdata = ReadMapData();
        equipmentdata = ReadEquipmentData();
        Debug.Log(levdata[0].currName+"当前目标经验："+levdata[0].targetExp);
    }


   public List<LevData> ReadLexData()
    {
         levdata=new List<LevData>();
        //读取csv二进制文件
        TextAsset binAsset = Resources.Load("人物境界", typeof(TextAsset)) as TextAsset;
        //读取每一行的内容
        string[] lineArray = binAsset.text.Split("\r"[0]);

        for (int i = 1; i < lineArray.Length; i++)
        {
            string[] lineArray1 = lineArray[i].Split(","[0]);
            LevData tempData = new LevData();
            tempData.currName = lineArray1[0];
            tempData.targetExp = int.Parse(lineArray1[2]);
            tempData.currExpRate = int.Parse(lineArray1[1]);
            levdata.Add(tempData);
        }
        return levdata;
    }
   public List<monsterData> ReadMonsterData()
   {
       monsterdata = new List<monsterData>();
       //读取csv二进制文件
       TextAsset binAsset = Resources.Load("怪物", typeof(TextAsset)) as TextAsset;
       //读取每一行的内容
       string[] lineArray = binAsset.text.Split("\r"[0]);
       for (int i = 1; i < lineArray.Length-1; i++)
       {
           string[] lineArray1 = lineArray[i].Split(","[0]);
           monsterData tempData = new monsterData();
           tempData.ID = int.Parse(lineArray1[0]);
           tempData.monsterName = lineArray1[1];
           tempData.lev = int.Parse(lineArray1[2]);
           tempData.shengming = int.Parse(lineArray1[3]);
           tempData.gongji = int.Parse(lineArray1[4]);
           tempData.fangyu = int.Parse(lineArray1[5]);
           monsterdata.Add(tempData);
       }
       Debug.Log("怪物有" + monsterdata.Count);
       return monsterdata;
   }
   public List<mapData> ReadMapData()
   {
       mapdata = new List<mapData>();
       //读取csv二进制文件
       TextAsset binAsset = Resources.Load("地图", typeof(TextAsset)) as TextAsset;
       //读取每一行的内容
       string[] lineArray = binAsset.text.Split("\r"[0]);
       Debug.Log(lineArray.Length + "长度"); 
       for (int i = 1; i < lineArray.Length-1; i++)
       {
           string[] lineArray1 = lineArray[i].Split(","[0]);
           mapData tempData = new mapData();
           tempData.ID = int.Parse(lineArray1[0]);
           tempData.mapName = lineArray1[1];
           tempData.mixLev = int.Parse(lineArray1[2]);
           tempData.mixMonsterID = int.Parse(lineArray1[3]);
           tempData.maxMonsterID = int.Parse(lineArray1[4]);
           mapdata.Add(tempData);
       }
       return mapdata;
   }
   public List<Equipment> ReadEquipmentData()
   {
       equipmentdata = new List<Equipment>();
       //读取csv二进制文件
       TextAsset binAsset = Resources.Load("装备", typeof(TextAsset)) as TextAsset;
       //读取每一行的内容
       string[] lineArray = binAsset.text.Split("\r"[0]);
       Debug.Log(lineArray.Length + "长度");
       for (int i = 1; i < lineArray.Length - 1; i++)
       {
           string[] lineArray1 = lineArray[i].Split(","[0]);
           Equipment tempData = new Equipment();
           tempData.ID = int.Parse(lineArray1[0]);
           tempData.name = lineArray1[1];
           tempData.zhiliang = int.Parse(lineArray1[2]);
           tempData.description = lineArray1[3];
           tempData.type=int.Parse(lineArray1[4]);
           tempData.lev = int.Parse(lineArray1[5]);
           tempData.sell = int.Parse(lineArray1[6]);
           tempData.gongji = int.Parse(lineArray1[7]);
           tempData.fangyu = int.Parse(lineArray1[8]);
           tempData.shengming = int.Parse(lineArray1[9]);
           tempData.shanbi = int.Parse(lineArray1[10]);
           tempData.baoji = int.Parse(lineArray1[11]);
           tempData.tili = int.Parse(lineArray1[12]);
           tempData.liliang = int.Parse(lineArray1[13]);
           equipmentdata.Add(tempData);
       }
       Debug.LogError(equipmentdata.Count);
       return equipmentdata;
   }

}

