using UnityEngine;

/// <summary>
/// Sistema de persistencia de datos del jugador
/// </summary>
[System.Serializable]
public class PlayerSaveData
{
    public string playerName;
    public int level;
    public int score;
    public int gyaruLevel;
    public int playtime;
    public string[] unlockedCharacters;
}

public class SaveManager : MonoBehaviour
{
    private const string SAVE_KEY = "GyaruRPG_Save";

    public static void SaveGame(PlayerSaveData data)
    {
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(SAVE_KEY, json);
        PlayerPrefs.Save();
        Debug.Log("Juego guardado correctamente");
    }

    public static PlayerSaveData LoadGame()
    {
        if (PlayerPrefs.HasKey(SAVE_KEY))
        {
            string json = PlayerPrefs.GetString(SAVE_KEY);
            return JsonUtility.FromJson<PlayerSaveData>(json);
        }
        Debug.Log("No hay partida guardada");
        return null;
    }

    public static void DeleteSave()
    {
        PlayerPrefs.DeleteKey(SAVE_KEY);
        Debug.Log("Partida eliminada");
    }

    public static bool HasSave()
    {
        return PlayerPrefs.HasKey(SAVE_KEY);
    }
}