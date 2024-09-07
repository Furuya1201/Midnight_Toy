using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class Drag : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] GameObject Start_1;   //スタート画面一枚目
    [SerializeField] GameObject Start_2;   //スタート画面二枚目
    [SerializeField] TextMeshProUGUI TMP;  //Textの格納
    [SerializeField] private AudioSource audioSource;  //Click時の音を鳴らす

    [SerializeField] Color32 startColor = new Color32(255, 255, 255, 255);  //初期カラー
    [SerializeField] Color32 endColor = new Color32(255, 255, 255, 64);     //変更後カラー

    private string TextName;     //Text名を格納する
    private bool Mouse = false;  //Mouseが重なっているかの判定

    void Awake()
    {

        if (TMP == null)
            TMP = GetComponent<TextMeshProUGUI>();

    }

    void Update()
    {

        //格納されている名前によって画面及びシーンの変更
        if (Input.GetMouseButtonDown(0) && Mouse)
        {

            if (TextName.Equals("StartTap"))
            {

                //Click音
                audioSource.Play();

                Start_1.SetActive(false);
                Start_2.SetActive(true);

            }
            else if (TextName.Equals("Tutorial"))
            {

                //Click音
                audioSource.Play();

                SceneManager.LoadScene("Tutorial Scene");

            }
            else if (TextName.Equals("StageStart"))
            {

                //Click音
                audioSource.Play();

                SceneManager.LoadScene("Main Scene");

            }
            

            Debug.Log("マウスが押されたよ！！");

        }

    }

    //Mouseが被っている時、Textの色を変えてそのTextの名前を格納
    public void OnPointerEnter(PointerEventData eventData)
    {

        Debug.Log("マウスが" + gameObject.name + "に触れた");

        TMP.color = endColor;

        TextName = gameObject.name;

        //Mouseのクリックを可能にする
        Mouse = true;

    }

    //Mouseが離れたら、Textの色を戻してMouseのクリックを出来なくする
    public void OnPointerExit(PointerEventData eventData)
    {

        Debug.Log("マウスが" + gameObject.name + "から離れた");

        TMP.color = startColor;

        TextName = "";

        Mouse = false;

    }

}