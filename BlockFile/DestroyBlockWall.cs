using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{

    [SerializeField] private GameObject BreakBlock;  //壊れるブロック

    private void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        //Playerにぶつかった場合、3秒経過後のブロックを削除
        if (collision.gameObject.tag == "Player")
        {

            Invoke("OnDestroy", 3.0f);

        }

    }

    //ブロック削除
    private void OnDestroy()
    {

        Destroy(BreakBlock);
        
    }

}
