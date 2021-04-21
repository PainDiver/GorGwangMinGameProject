using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class DataController : MonoBehaviour
{
    public static int itemNumber;
    public static int eventOperated;
    public static List<string> itemHaving = new List<string>();
    public static int spawnPos;
    public static int stage;



    public static string _jEventHappened;
    public static string _jItem;
    public static string _jItemHaving;
    public static string _jSpawnPos;
    public static string _jStage;
    public static List<string> templist;
    public static List<string> _jItemList;


    private void Awake()
    {
        if (!File.Exists(Application.dataPath + "/GorgwangminEvent.json"))
            _clear();
        _load(); 
    }

    public static void _save()
    {

        
           string itemNum = JsonConvert.SerializeObject(itemNumber);
           string itemGot = JsonConvert.SerializeObject(itemHaving);
           string eventbit = JsonConvert.SerializeObject(eventOperated);
           string spawnPosition = JsonConvert.SerializeObject(spawnPos);
           string stageIndex = JsonConvert.SerializeObject(stage);


           File.WriteAllText(Application.dataPath + "/GorgwangminEvent.json",eventbit);
           File.WriteAllText(Application.dataPath + "/GorgwangminItem.json", itemGot);
           File.WriteAllText(Application.dataPath + "/GorgwangminItemNumber.json", itemNum);
           File.WriteAllText(Application.dataPath + "/GorgwangminSpawnPos.json", spawnPosition);
           File.WriteAllText(Application.dataPath + "/GorgwangminStage.json", stageIndex);
       
    }

    public static void _clear()
    {
        File.WriteAllText(Application.dataPath + "/GorgwangminEvent.json", "0");
        File.WriteAllText(Application.dataPath + "/GorgwangminItem.json", "");
        File.WriteAllText(Application.dataPath + "/GorgwangminItemNumber.json", "0");
        File.WriteAllText(Application.dataPath + "/GorgwangminSpawnPos.json", "0");
        File.WriteAllText(Application.dataPath + "/GorgwangminStage.json", "0");
    }

    public static void _load()
    {
        _jEventHappened =File.ReadAllText(Application.dataPath + "/GorgwangminEvent.json");
        _jItem = File.ReadAllText(Application.dataPath + "/GorgwangminItemNumber.json");
        
        _jItemHaving = File.ReadAllText(Application.dataPath + "/GorgwangminItem.json");
        templist = JsonConvert.DeserializeObject<List<string>>(_jItemHaving);
        if (templist != null)
            _jItemList = new List<string>(templist);
        else
            _jItemList = new List<string>();

        _jSpawnPos = File.ReadAllText(Application.dataPath + "/GorgwangminSpawnPos.json");
        _jStage = File.ReadAllText(Application.dataPath + "/GorgwangminStage.json");
    }


  

}
