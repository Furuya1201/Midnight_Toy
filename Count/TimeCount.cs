using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeCount : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI TMP;    //Text表示用
    [SerializeField] private AudioSource TimeUp;     //時間切れで鳴らす音源
    [SerializeField] private AudioClip TimeUpSound;  //鳴らす音源

    private float count = 180.0f;     //カウント
    private float countdown = 5.0f;   //カウントダウン
    public float timeLimit = 0.0f;    //タイムリミット
    public float SceneLimit = 10.0f;  //シーン用リミット

    private float quotient = 0.0f;   //時間を割った商を格納
    private float remainder = 0.0f;  //時間を割った余りを格納

    private float quotient_Floor = 0.0f;   //時間を割った商を切り捨て処理後の格納
    private float remainder_Floor = 0.0f;  //時間を割った余りを切り捨て処理後の格納

    void Awake()
    {

        if (TMP == null)
            TMP = GetComponent<TextMeshProUGUI>();

    }

    public void Update()
    {


        //時間のカウント
        TimeCounter();

        //時間を分で割る計算
        TimeCalculation();

        //時間を表示する
        TMP.text = quotient_Floor.ToString("00") + ":" + remainder_Floor.ToString("00");

        //時間切れになった時
        if (count <= timeLimit)
        {

            //文字表示をして、音を鳴らす
            TMP.text = "TimeUp!";
            TimeUp.Play();

            //シーンの停止
            Time.timeScale = 0;

            //シーン移動までのカウント
            countdown -= Time.unscaledDeltaTime;

            Debug.Log(countdown);

            //シーン移動までの時間切れになった時
            if (countdown <= 0.0f)
            {

                //シーンの再開
                Time.timeScale = 1;

                SceneReStart();

            }

        }

    }

    //タイムカウント
    public void TimeCounter()
    {

        count -= Time.deltaTime;
        Debug.Log(count);

    }

    //時間を割った商、余りを格納
    private void TimeCalculation()
    {

        //現在の残り時間を60秒で割る
        quotient = count / 60.0f;
        remainder = count % 60.0f;

        //切り捨て処理を行う
        quotient_Floor = Mathf.Floor(quotient);
        remainder_Floor = Mathf.Floor(remainder);

    }

    //シーンの移動用
    private void SceneReStart()
    {

        SceneManager.LoadScene("Result Scene");

    }

}
