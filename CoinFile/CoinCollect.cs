using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CoinCollect : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI TMP;
    [SerializeField] private TextMeshProUGUI CoinText;  //Coinの枚数表示
    [SerializeField] private GameObject Disp;           //GoalDisplay用のキャンバス
    [SerializeField] private AudioSource Finish;        //集め切った時に音を鳴らす
    [SerializeField] private AudioClip FinishSound;     //鳴らす音源

    private float countdown = 5.0f;  //カウントダウン
    public int CoinCount = 0;        //コインの獲得枚数用
    public static int Coins = 0;     //Resultで表示するために格納

    private void Awake()
    {

        if (TMP == null)
            TMP = GetComponent<TextMeshProUGUI>();

    }

    private void Update()
    {

        //枚数表示
        CoinText.text = CoinCount + " / 22";

        //時間内に全て集め終えたら、その時点でResultへ移動
        if (CoinCount == 22)
        {

            //Text表示をして、音を鳴らす
            Disp.SetActive(true);
            TMP.text = "Finish!";
            Finish.Play();

            Time.timeScale = 0;

            //シーン移動までのカウント
            countdown -= Time.unscaledDeltaTime;

            Debug.Log(countdown);

            if (countdown <= 0.0f)
            {

                //シーンの再開
                Time.timeScale = 1;

                SceneReStart();

            }

        }

    }

    //シーンの移動用
    private void SceneReStart()
    {

        SceneManager.LoadScene("Result Scene");

    }

    //コインのカウント及び汎用できるように格納
    public void CoinCounter()
    {

        CoinCount += 1;

        Coins = CoinCount;

        Debug.Log(Coins);

    }

    //コイン枚数を返す　
    public static int getCoin()
    {

        return Coins;

    }

}
