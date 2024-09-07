using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager
{

    private string SaveDirPath;

    public void DataSave(SaveData sdata, string fpath, string fname)
    {

        // バイナリで保存
        BinaryFormatter bf = new BinaryFormatter();
        string saveFilePath = System.IO.Path.Combine(fpath, fname);

        using (FileStream file = File.Create(saveFilePath))
        {

            bf.Serialize(file, sdata);

        }

    }

    public SaveData DataLoad(string fpath, string fname)
    {

        string loadFilePath = System.IO.Path.Combine(fpath, fname);

        if (!File.Exists(loadFilePath))
        {

            Debug.Log("No Load Data. " + loadFilePath);

            return null;

        }

        BinaryFormatter bf = new BinaryFormatter();
        SaveData sdata;

        using (FileStream file = File.Open(loadFilePath, FileMode.Open))
        {

            sdata = (SaveData)bf.Deserialize(file);

        }

        return sdata;

    }

    public SaveData CreateSaveData(Vector3 pos)
    {

        SaveData sdata = new SaveData();

        sdata.x = pos.x;
        sdata.y = pos.y + 1.0f;
        sdata.z = pos.z;

        return sdata;

    }

}


