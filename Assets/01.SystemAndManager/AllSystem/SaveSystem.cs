using System.IO;
using UnityEngine;

public class SaveSystem : MonoSingleton<SaveSystem>
{
    public void Save()
    {
        string json = JsonUtility.ToJson(RankingSystem.Instance.rankDataList);
        File.WriteAllText(GetPath(), json);
    }

    public RankDataList LoadData()
    {
        File.ReadAllText(GetPath());
        return JsonUtility.FromJson<RankDataList>(File.ReadAllText(GetPath()));
    }

    private string GetPath()
    {
        return Path.Combine(Application.dataPath, "saveData.json");
    }
}