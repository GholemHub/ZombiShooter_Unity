using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SaveData
{

    public int score;
    public string toJson()
    {
        return JsonUtility.ToJson(this);
    }
    public void LoadFromJson(string json)
    {

        JsonUtility.FromJsonOverwrite(json, this);
    }


}
public interface ISaveable
{
    void PopulateSaveData(SaveData data);
    void LoadFromSaveData(SaveData data);
}
