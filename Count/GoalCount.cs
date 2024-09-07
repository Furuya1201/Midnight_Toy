using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(SphereCollider))]

public class GoalCount : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI TMP;      //カウントダウン表示用
    [SerializeField] private GameObject Canvas;        //範囲内に入った時の表示切り替え
    [SerializeField] private GameObject front;         //割合増加の見た目用
    [SerializeField] private GameObject CountDisplay;  //カウントダウン表示用
    [SerializeField] private GameObject ClearDisplay;  //クリア文字表示用

    private Image image;  //割合増加の可視化用

    private float left_time;        //経過時間の格納用
    private float time_circle;      //割合用
    private float _startTime = 0f;  //カウントスタート格納用
    public float th = 5.0f;         //カウントダウン

    private string countText;
    private bool TopTime = true;    //一度だけ格納するための判定;

    private void Start()
    {

        TMP =　CountDisplay.GetComponent<TextMeshProUGUI>();

        image = front.GetComponent<Image>();

        //初めは非表示設定
        Canvas.SetActive(false);
        ClearDisplay.SetActive(false);

    }

    //GoalPointに触れたタイミングの時間を格納
    public void PointEnter()
    {

        //カウント開始時のタイムを格納
        //重複して格納しないための制御
        _startTime = Time.time;

        TopTime = false;

    }

    public void GoalMeasure()
    {

        
        if (TopTime)
        {

            PointEnter();

        }

        //カウントダウン
        left_time = th - (Time.time - _startTime) + 1;

        //カウント時間によって表示する割合を変更
        time_circle = (Time.time - _startTime) / th;

        //表示するImageをtrueにして、計算した割合を代入
        //今回作成したものは1秒ごとにFillAmountをFullにする動作を繰り返す
        Canvas.SetActive(true);

        image.fillAmount = time_circle;

        //カウント時間をstring型に変更
        countText = Mathf.Floor(left_time).ToString();

        //Textにてカウントダウン表示
        TMP.text = countText;

        //設定したカウント以下でゴール処理
        if (left_time < 1.0f)
        {

            ClearDisplay.SetActive(true);
            Canvas.SetActive(false);

            //クリア表示後、3秒後にResultSceneへ移動
            ClearDisplay.SetActive(true);
            Invoke("SceneChange", 3.0f);

        }

    }

    //現在のシーンによって移動先を変更
    private void SceneChange()
    {

        if (SceneManager.GetActiveScene().name == "Tutorial Scene")
        {

            SceneManager.LoadScene("Title Scene");

        }
        else
        {

            SceneManager.LoadScene("Result Scene");

        }

    }

    //GoalPoint内にいるかの判別
    //内外でカウントの有無を制御
    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "GoalPoint")
        {

            Debug.Log("GoalCount中！");

            GoalMeasure();

        }

    }

    //カウント中に範囲内から出た場合
    //先ほどまでのカウントをリセットする
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "GoalPoint")
        {

            Canvas.SetActive(false);
            _startTime = 0f;
            front.GetComponent<Image>().fillAmount = 0f;
            TopTime = true;

        }

    }

}
