using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class Retry : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] TextMeshProUGUI TMP;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] [Range(0.1f, 10.0f)] float duration = 1.0f;  //一ループの長さ(秒数)

    [SerializeField] Color32 startColor = new Color32(255, 255, 255, 255);  //初期カラー
    [SerializeField] Color32 endColor = new Color32(255, 255, 255, 64);     //変更後のカラー

    private string TextName;     //Textの名前を格納

    private bool Mouse = false;  //マウスの可否判定

    void Awake()
    {

        if (TMP == null)
            TMP = GetComponent<TextMeshProUGUI>();

    }

    void Update()
    {

        //1秒周期でカラーをゆっくりと変更する
        TMP.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time / duration, 1.0f));

        //Textの名前で処理を分岐
        if (Input.GetMouseButtonDown(0) && Mouse)
        {

            //取得済みのコイン枚数を初期化してTitleへ移動
            if (TextName.Equals("Result_1"))
            {

                //Click音
                audioSource.Play();

                Time.timeScale = 1;
                
                CoinCollect.Coins = 0;

                SceneManager.LoadScene("Title Scene");

            }

        }

    }

    //Mouseが被っている時、Textの色を変えてそのTextの名前を格納
    public void OnPointerEnter(PointerEventData eventData)
    {

        Debug.Log("マウスが" + gameObject.name + "に触れた");

        TextName = gameObject.name;

        Mouse = true;

    }

    //Mouseが離れたら、Textの色を戻してMouseのクリックを出来なくする
    public void OnPointerExit(PointerEventData eventData)
    {

        Debug.Log("マウスが" + gameObject.name + "から離れた");

        TextName = "";

        Mouse = false;

    }

}
