using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Observer : MonoBehaviour
{

    static public void SendEvent(Events EventType)
    {
        DataController.eventOperated += (int)EventType;
    }

    static public void SendItemNum(int item)
    {
        DataController.itemNumber = item;
    }

    static public void SendItemHaving(List<string> itemList)
    {
        DataController.itemHaving = itemList;
    }
    static public void SendSpawnPos(int pos)
    {
        DataController.spawnPos = pos;
    }

    static public void SendStage(int stage)
    {
        DataController.stage = stage;
    }


    


    static public int GetEventOp()
    {
        return int.Parse(DataController._jEventHappened);
    }

    static public int GetItemNum()
    {
        return int.Parse(DataController._jItem);
    }
    static public List<string> GetItemHaving()
    {
        Debug.Log(DataController._jItemList);
        return DataController._jItemList;

    }

    static public int GetStage()
    {
        return int.Parse(DataController._jStage);
    }

    static public int GetSpawnPos()
    {
        return int.Parse(DataController._jSpawnPos);
    }

}
