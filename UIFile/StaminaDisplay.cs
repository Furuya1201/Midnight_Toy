using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StaminaDisplay : MonoBehaviour
{

    [SerializeField] private GameObject front;     //割合による増加の可視化用
    [SerializeField] private TextMeshProUGUI TMP;  //スタミナ切れ時表示

    private float MaxSt = 30.0f;  //Maxのスタミナ
    private float time_circle;    //割合の格納
    private float Floorst;        //切り捨てを行った現在の割合
    public float st;              //Stamina()で確保したスタミナを反映

    private void Start()
    {
        
    }

    //スタミナの残量を表示
    public void Stdisp(float st)
    {

        //スタミナ残量を確保して、切り捨てを行う
        Floorst = Mathf.Floor(st);

        time_circle = Floorst / MaxSt;

        //割合に合わせた可視化
        front.GetComponent<Image>().fillAmount = time_circle;

    }

    public void StTextTrue()
    {

        TMP.gameObject.SetActive(true);

    }

    public void StTextFalse()
    {

        TMP.gameObject.SetActive(false);

    }

}
