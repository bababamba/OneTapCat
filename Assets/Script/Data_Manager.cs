using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SaveData
{
    public int AdCount;
    public int AdDays;
    public bool NoAds;

    public int Fish;
    public int FishTime;

    public List<bool> StageEnterd = new List<bool>();
    public List<bool> Cleared = new List<bool>();
    public List<bool> FishCollect = new List<bool>();

    public bool BGM;
    public bool SFX;
}
public class Data_Manager : MonoBehaviour
{
    public static Data_Manager instance;
    string path;
    [SerializeField] GoogleMoblieAdsDemoScript Ads;
    [SerializeField] Album_Manager album;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //path = Path.Combine(Application.dataPath, "database.json");//PC
        path = Path.Combine(Application.persistentDataPath, "database.json");//Android
        JsonLoad();
    }

    public void JsonLoad()
    {
        SaveData saveData = new SaveData();

        if (!File.Exists(path))
        {
            JsonSave();
        }
        else
        {
            string loadJson = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);
            if (saveData != null)
            {
                string a = DateTime.Now.ToString("yyyyMMdd");
                if (saveData.AdDays < int.Parse(a))
                    Ads.CurAdCount = 5;
                else
                    Ads.CurAdCount = saveData.AdCount;

                Main_Manager.instance.NoAds = saveData.NoAds;

                StaminaManager.instance.SetStamina(saveData.Fish);
                StaminaManager.instance.SetStaminaTime(saveData.FishTime);

                for (int i = 0; i < Main_Manager.instance.stage_Entered.Length; i++)
                {
                    if (saveData.StageEnterd[i])
                        Main_Manager.instance.StageEnterd(i);
                }
                for (int i = 0; i < Main_Manager.instance.cleared.Length; i++)
                {
                    Main_Manager.instance.cleared[i] = saveData.Cleared[i];
                }
                for (int i = 0; i < album.CheckedReward.Length; i++)
                {
                    album.CheckedReward[i] = saveData.FishCollect[i];

                }
                if (!saveData.BGM)
                    Audio_Manager.Instance.SoundOff();

                if (!saveData.SFX)
                    Audio_Manager.Instance.SetLanguage(1);
            }
        }
    }
    public void JsonSave()
    {
        SaveData saveData = new SaveData();
        
        saveData.AdCount = Ads.CurAdCount;
        string a = DateTime.Now.ToString("yyyyMMdd");
        saveData.AdDays = (int.Parse(a));
        saveData.NoAds = Main_Manager.instance.NoAds;

        saveData.Fish = StaminaManager.instance.GetStamina();
        saveData.FishTime = (int)StaminaManager.instance.GetStaminaTime();

        for (int i = 0; i < Main_Manager.instance.stage_Entered.Length; i++)
        {
            saveData.StageEnterd.Add(Main_Manager.instance.stage_Entered[i]);
        }
        for (int i = 0; i < Main_Manager.instance.cleared.Length; i++)
        {
            saveData.Cleared.Add(Main_Manager.instance.cleared[i]);
        }
        for (int i = 0; i < album.CheckedReward.Length; i++)
        {
            saveData.FishCollect.Add(album.CheckedReward[i]);
        }

        saveData.BGM = Audio_Manager.Instance.CheckOn[0].activeSelf;
        saveData.SFX = Audio_Manager.Instance.CheckOn[2].activeSelf;

        string json = JsonUtility.ToJson(saveData, true);

        File.WriteAllText(path, json);
    }
}






     