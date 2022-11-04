using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Core;
using Agate.MVC.Base;
using static Types;
using Newtonsoft.Json;

public class SaveLoadModel : BaseModel
{
    public Dictionary<Direction, KeyCode> LoadInputDictionary()
    {
        return JsonConvert.DeserializeObject<Dictionary<Direction, KeyCode>>(PlayerPrefs.GetString("InputsSetting"));
    }
    public void SaveInputDictionary(Dictionary<Direction, KeyCode> dictionary)
    {
        string saveData = JsonConvert.SerializeObject(dictionary);
        PlayerPrefs.SetString("InputsSetting", saveData);
        PlayerPrefs.Save();
    }
    public bool SaveHighScore(int score)
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        bool isHighScore = score > highScore;
        PlayerPrefs.SetInt("HighScore", Mathf.Max(score, highScore));
        PlayerPrefs.Save();
        return isHighScore;

    }
}
