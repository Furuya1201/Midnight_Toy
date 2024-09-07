using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignBoard : MonoBehaviour
{

    private GameObject Panel;  //表示する看板の内容を格納

    //表示
    public void StayPanel()
    {

        Panel.SetActive(true);

    }

    //非表示
    public void ExitPanel()
    {

        Panel.SetActive(false);

    }

}