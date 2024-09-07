using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowScript : MonoBehaviour
{

    [SerializeField] private GameObject Pause_1;  //Pause画面一枚目
    [SerializeField] private GameObject Pause_2;  //Pause画面二枚目

    [SerializeField] private Image Right_image;  //右矢印
    [SerializeField] private Image Left_image;   //左矢印

    [SerializeField] Color32 Color_1 = new Color32(255, 255, 255, 255);  //ページの状態による色変更
    [SerializeField] Color32 Color_2 = new Color32(255, 255, 255, 150);  //ページの状態による色変更

    public void Start()
    {

        //初期状態の色の状態
        Right_image.color = Color_1;
        Left_image.color = Color_2;

    }

    //Pauseの状態によって表示する画面と矢印の色の変更(*1, *2)
    //右矢印が押された時の処理 *1
    public void RightButtonPush()
    {

        
        if (Pause_1 == true)
        {

            Pause_1.SetActive(false);
            Pause_2.SetActive(true);

            Right_image.color = Color_2;
            Left_image.color = Color_1;
            
        }

    }

    //左矢印が押された時の処理 *2
    public void LeftButtonPush()
    {

        if (Pause_2 == true)
        {

            Pause_1.SetActive(true);
            Pause_2.SetActive(false);

            Right_image.color = Color_1;
            Left_image.color = Color_2;
        }

    }

}
