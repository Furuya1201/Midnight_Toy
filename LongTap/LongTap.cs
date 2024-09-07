using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LongTap : MonoBehaviour
{

    [SerializeField] private GameObject Car;     //Script呼び出し用
    [SerializeField] private GameObject Canvas;  //画面表示用
    [SerializeField] private GameObject front;   //割合増加の可視化用
    [SerializeField] private float th = 3.0f;    //事前に設定した移動までの時間

    private float left_time;    //経過時間
    private float time_circle;  //経過による割合
     
    private float _startTime = 0f;  //押した瞬間の時間
    private bool TopTime = true;    //重複回避用の判定
    private bool ButtonTapping;     //Buttonが押されたかの判定

    private void Start()
    {

        //初めは非表示
        Canvas.SetActive(false);

    }

    //ボタンが押された時に時間を格納する
    public void PointEnter()
    {

        //押された瞬間時間を確保
        //重複しない為の制御
        _startTime = Time.time;

        TopTime = false;

    }

    public void FixedUpdate()
    {

        //ボタンが押されたかどうかの判定
        ButtonTapping = Input.GetKey(KeyCode.RightShift);

        //押されていたら
        if (ButtonTapping)
        {

            if (TopTime)
            {

                PointEnter();

            }

            //現在の時間から押した瞬間の時間を引いて、経過時間を計測
            left_time = th - (Time.time - _startTime);

            //経過時間により割合を増加させる
            time_circle = (Time.time - _startTime) / th;

            Canvas.SetActive(true);

            //割合に合わせた可視化
            front.GetComponent<Image>().fillAmount = time_circle;

            //制限時間になったら、非表示にしSave地点に移動
            if (left_time <= 0)
            {

                Canvas.SetActive(false);

                Car.GetComponent<Save>().LoadPosition();

            }

        }

        //文字途中でボタンが離されたら、初期化を行う
        if (!ButtonTapping)
        {

            Canvas.SetActive(false);
            _startTime = 0f;
            front.GetComponent<Image>().fillAmount = 0f;
            TopTime = true;

        }

    }

}