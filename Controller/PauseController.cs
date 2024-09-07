using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{

    [SerializeField] private GameObject pauseUIPrefab;  //Pause画面の格納

    private void Start()
    {

    }

    private void Update()
    {

        //Escapeボタンの判定
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            onClick();

        }

    }

    public void onClick()
    {

        //現在の表示状況によって分岐
        if (pauseUIPrefab.activeSelf == false)
        {

            PauseGame();

        }
        else
        {
    
            ResumeGame();

        }

    }

    //Pause画面の表示を行い、他のメソッドの停止
    public void PauseGame()
    {

        pauseUIPrefab.SetActive(true);

        Time.timeScale = 0;

    }

    //Pause画面を閉じ、他のメソッドの実行再開
    public void ResumeGame()
    {

        Time.timeScale = 1;

        pauseUIPrefab.SetActive(false);

    }

}
