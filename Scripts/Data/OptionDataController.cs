using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class OptionDataController : MonoBehaviour
{

    public static string mouseSen;

    private void Awake()
    {
        _save();
        TitleOption.mouseSensivity = float.Parse(mouseSen);
        _load();
    }

    public static void _save()
    {
        mouseSen = JsonConvert.SerializeObject(TitleOption.mouseSensivity);
        File.WriteAllText(Application.dataPath + "/GorgwangminOption.json",mouseSen);
    }

    public static void _load()
    {
        mouseSen = File.ReadAllText(Application.dataPath + "/GorgwangminOption.json");
        if (mouseSen.Equals(""))
            TitleOption.mouseSensivity = 2;
        else
            TitleOption.mouseSensivity = float.Parse(mouseSen);
    }




}
