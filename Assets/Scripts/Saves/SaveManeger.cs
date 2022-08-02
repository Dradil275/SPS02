using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveManeger
{ 

    public static void SaveGameState(SaveData saveData)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file;
        file = File.Create(Application.persistentDataPath + "/SaveData.save");
        binaryFormatter.Serialize(file, saveData);
        file.Close();
    }

    public static SaveData LoadGameState()
    {
        string path = Application.persistentDataPath + "/SaveData.save";
        if(File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            SaveData saveData = (SaveData)binaryFormatter.Deserialize(file);
            file.Close();
            return saveData;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }

    }

}
