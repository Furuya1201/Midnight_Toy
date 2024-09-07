　　using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarLight : MonoBehaviour
{

    [SerializeField] private GameObject _CarLight;  //制御するライトの取得

    private int count = 0;  //現在の状態を0, 1で格納
    private bool Light;  //Keyが押されたかの判定
    private bool countCheck;  //現在の状態を判定

    void Start()
    {

    }

    void Update()
    {

        //Keyが押されたかの判定
        //現在の状態を判定
        Light = Keyboard.current.lKey.wasPressedThisFrame;
        countCheck = count % 2 == 0;

        //判定結果によってLightの点灯、消灯を切り替える
        if (Light)
        {

            if (countCheck)
            {

                _CarLight.SetActive(false);
                count += 1;

            }

            if (!countCheck)
            {

                _CarLight.SetActive(true);
                count -= 1;

            }

        }

    }

}
