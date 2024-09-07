using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDropBlock : MonoBehaviour
{

    private float CountDown = 15.0f;  //ブロック消滅までの時間

    void Start()
    {

    }


    private void FixedUpdate()
    {

        //カウントダウン
        CountDown -= Time.deltaTime;

        //時間切れになった場合、自身を削除
        if (CountDown <= 0.0f)
        {

            Destroy(this.gameObject);

        }

    }

}
