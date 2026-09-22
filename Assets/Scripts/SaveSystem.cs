using System;
using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private static readonly string SaveFileName = "save.json";
    private static string SavePath => Path.Combine(Application.persistentDataPath, SaveFileName);

    public static void Save(PlayerData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(SavePath, json);
        Debug.Log($"Data Saved: {SavePath}");
    }

    public static PlayerData Load()
    {
        if (!File.Exists(SavePath))
        {
            Debug.LogWarning("Save file not found. Returning default values.");
            return new PlayerData();
        }

        string json = File.ReadAllText(SavePath);
        if (string.IsNullOrWhiteSpace(json))
        {
            return null;
        }
        try
        {
            return JsonUtility.FromJson<PlayerData>(json);
        }
        catch (Exception ex)
        {
            var correlationId = Guid.NewGuid().ToString("N");
            Debug.LogError($"PlayerData JSON deserialization failed. CorrelationId: {correlationId}\n{ex}");
            throw new InvalidOperationException($"Failed to deserialize PlayerData. CorrelationId: {correlationId}", ex);
        }
    }

    public static bool SaveExists()
    {
        return File.Exists(SavePath);
    }
}
