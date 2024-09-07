using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseClick : SignBoard
{

    [SerializeField] private GameObject BoardPanel;  //コメント表示用
    [SerializeField] private GameObject SignBoard;   //看板用

    private void Start()
    {

    }

    private void MouseClickEvent()
    {

        // クリック位置のレイを取得
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 20))
        {
            // コライダーとレイとの当たり判定
            if (hit.collider != null)
            {

                if (hit.collider.gameObject == SignBoard)
                {

                    Debug.Log("看板がクリックされた！");

                    //看板の内容を画面表示
                    BoardPanel.SetActive(true);

                }
                else
                {

                    Debug.Log("看板以外だよ");

                    //看板以外にヒットした場合、看板の表示を閉じる
                    BoardPanel.SetActive(false);

                }

            }

        }

    }    

    private void Update()
    {

        // マウスが左クリックされたら
        if (Input.GetMouseButtonDown(0))
        {

            MouseClickEvent();

        }

    }

}