using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour
{

    [SerializeField] private Text ResultText;  //コイン獲得枚数の表示

    private int Score;  //コイン格納用
    
    private void Start()
    {

        //コイン枚数を返してもらう
        Score = CoinCollect.getCoin();

        Debug.Log(Score);

        //枚数をスコアとして表示
        ResultText.text = string.Format("Score : {0}", Score);
        
    }

}
