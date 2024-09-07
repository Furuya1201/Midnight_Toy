using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private GameObject mainCamera;      //メインカメラ格納用
    [SerializeField] private GameObject subCamera;       //サブカメラ格納用
    [SerializeField] private GameObject ScoreDisplay;    //スコア表示変更用
    [SerializeField] private GameObject StaminaDisplay;  //スタミナ表示変更用

    public float Times = 10.0f;  //カメラ変更までの時間格納用

    private void Start()
    {

        //サブカメラをアクティブにする
        subCamera.SetActive(true);
        mainCamera.SetActive(false);
        ScoreDisplay.SetActive(false);
        StaminaDisplay.SetActive(false);

        Time.timeScale = 0;

    }

    private void Update()
    {

        //カメラ変更までのカウント
        Times -= Time.unscaledDeltaTime;

        if (Times <= 0.0f)
        {

            //メインカメラへの変更
            Time.timeScale = 1;

            Main();

        }

    }
    public void Main()
    {

        //メインカメラをアクティブに設定
        subCamera.SetActive(false);
        mainCamera.SetActive(true);
        ScoreDisplay.SetActive(true);
        StaminaDisplay.SetActive(true);

        this.GetComponent<CameraController>().enabled = false;

    }

}
