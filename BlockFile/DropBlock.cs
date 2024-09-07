using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBlock : MonoBehaviour
{

    public GameObject[] Blocks = new GameObject[3];  //3種類のブロックを格納

    Vector3 BlockPosition = new Vector3(0.0f, 0.0f, 0.0f);  //BlockのPositioの初期化

    float BlockRotationX;  //X回転の格納用
    float BlockRotationY;  //Y回転の格納用
    float BlockRotationZ;  //Z回転の格納用

    int RandNumber = 0;  //ランダムな数字を格納

    [SerializeField] [Range(0.1f, 1.0f)] float Delay = 0.2f;  //ブロックが降ってくる間隔

    private void Start()
    {

        //コルーチンによってブロックの降らせる間隔を制御
        StartCoroutine("InstantiateBlocks");

    }

    private IEnumerator InstantiateBlocks()
    {

        //ゲームが終わるまで無限にブロックを降らせるため、while文でループ処理
        while (true)
        {

            BlockPosition = new Vector3(Random.Range(435.0f, 565.0f), 130.0f, Random.Range(510.0f, 640.0f));  //ステージ内のランダムな場所を格納

            //x,y,z軸のランダムのな角度を格納
            BlockRotationX = Random.Range(0.0f, 360.0f);
            BlockRotationY = Random.Range(0.0f, 360.0f);
            BlockRotationZ = Random.Range(0.0f, 360.0f);

            //ランダムに数字を選出し、降らせるブロックの種類を変更
            RandNumber = Random.Range(0, 3);

            //ブロックの種類、場所、角度を変更したことにより、生成で満遍なく降らせる
            Instantiate(Blocks[RandNumber], BlockPosition, Quaternion.Euler(BlockRotationX, BlockRotationY, BlockRotationZ));

            //設定した時間を待って、降らせる間隔を変更
            yield return new WaitForSeconds(Delay);

        }

    }

}
