using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]

public class JumpMove : MonoBehaviour
{

    private Rigidbody rb;

    [SerializeField] private float jumpPower;  //ジャンプの値を格納

    private float distance;  //Rayを出す距離を格納

    private bool jump;  //Keyを押したかの判定

    private void Start()
    {

        rb = GetComponent<Rigidbody>();
        distance = 1.0f;

    }

    //ジャンプの値を計算し格納
    private void JumpAction()
    {

        rb.AddForce(transform.up * jumpPower);

    }

    void Update()
    {

        //Rayの出力ポシション、出す方向、Rayと地面との距離判定
        Vector3 rayPosition = transform.position + new Vector3(0.0f, 0.6f, 0.0f);
        Ray ray = new Ray(rayPosition, Vector3.down);
        bool isGround = Physics.Raycast(ray, distance);

        //Keyが押されたかを判定
        jump = Keyboard.current.spaceKey.wasPressedThisFrame;

        if (jump)
        {

            if (isGround)
            {

                JumpAction();

            }
            
        }

        //ジャンプ時に前後左右に傾くのを補正して倒れなくする
        transform.rotation = Quaternion.Euler(new Vector3(0f, transform.eulerAngles.y, 0f));

    }

}
