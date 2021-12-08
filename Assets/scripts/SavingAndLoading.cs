using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SavingAndLoading
{

    public static void Save(GameObject player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = GetFilePath();
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData playerData = new PlayerData(player.transform.position);
        formatter.Serialize(stream, playerData);
        stream.Close();
    }

    private static string GetFilePath()
    {
        return Application.persistentDataPath + "/player.data";
    }

    public static PlayerData LoadPlayer()
    {
        string filePath = GetFilePath();
        if (File.Exists(filePath))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            PlayerData playerData = binaryFormatter.Deserialize(fileStream) as PlayerData;
            fileStream.Close();
            return playerData;
        }
        else
        {
            throw new System.Exception("Could not load player data");
        }
    }

}
