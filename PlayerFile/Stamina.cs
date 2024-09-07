using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{

    [SerializeField] private GameObject PlayerBody;   //Playerの制御用に確保
    [SerializeField] private GameObject StaminaDisp;  //script確保用

    public float stamina;  //最大スタミナ
    private float Repair = 1.0f;   //1tapあたりの回復量

    private bool Max;  //スタミナのMax状態か否か

    private void Start()
    {

        stamina = 30.0f;
        Max = true;

    }

    public void FixedUpdate()
    {

        //スタミナの状態によって増減できるかを切り替え
        if (Max == true)
        {

            StaminaDisp.GetComponent<StaminaDisplay>().StTextFalse();

            StaminaDecrease();

        }

        if (Max == false)
        {

            StaminaDisp.GetComponent<StaminaDisplay>().StTextTrue();

            StaminaIncrease();

        }

        //スタミナの状態によって分岐
        if (stamina <= 0.0f)
        {

            //車の操作を無効化するし、スタミナの減少を停止
            PlayerBody.GetComponent<CarScript>().enabled = false;
            Max = false;

        }

        StaminaDisp.GetComponent<StaminaDisplay>().Stdisp(stamina);

    }

    //スタミナの減少
    public void StaminaDecrease()
    {

        stamina -= Time.deltaTime;

    }

    //スタミナの増加
    public void StaminaIncrease()
    {

        if (Input.GetKeyDown(KeyCode.P) && Max == false)
        {

            stamina += Repair;

            //スタミナがFullならtrueに変更し、操作の有効化、スタミナの減少を再開
            if (stamina > 30.0f)
            {

                Max = true;

                PlayerBody.GetComponent<CarScript>().enabled = true;

            }

        }

    }

}
