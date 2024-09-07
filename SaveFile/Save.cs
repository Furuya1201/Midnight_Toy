using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class Save : MonoBehaviour
{

    SaveManager saveManager = new SaveManager();

    string SaveDirPath;

    private void Start()
    {

    }

    private void Awake()
    {

        SaveDirPath = Application.persistentDataPath;

    }

    public void SavePosition()
    {
        SaveData sdata = saveManager.CreateSaveData(this.transform.position);
        saveManager.DataSave(sdata, SaveDirPath, "test.sv");

    }

    public void LoadPosition()
    {
        Debug.Log("Load完了！！");

        SaveData sdata = saveManager.DataLoad(SaveDirPath, "test.sv");
        Vector3 pos = new Vector3(sdata.x, sdata.y, sdata.z);
        this.transform.position = pos;

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "SavePoint")
        {

            SavePosition();
            
        }

    }

}
