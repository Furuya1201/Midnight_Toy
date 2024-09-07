using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

    [SerializeField] private GameObject DestroyCoin;  //Scriptの添付先
    [SerializeField] private float CRotate;           //コインの回転

    private CoinCollect coinCollect;

    void Start()
    {
         
        coinCollect = DestroyCoin.GetComponent<CoinCollect>();

    }
    
    private void Update()
    {

        //時間経過でコインを回転させる
        transform.Rotate(new Vector3(0, 0, CRotate) * Time.deltaTime);

    }

    //Playerにぶつかったらコインを獲得する
    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {

            Destroy(gameObject);

            coinCollect.CoinCounter();

        }

    }

}
