using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFade : MonoBehaviour
{
	
	[SerializeField] TextMeshProUGUI TMP;  //Textを格納

	[SerializeField] [Range(0.1f, 10.0f)] float duration = 1.0f;  //一ループの長さ(秒数)

	[SerializeField] Color32 startColor = new Color32(255, 255, 255, 255);  //初期カラー
	[SerializeField] Color32 endColor = new Color32(255, 255, 255, 64);     //変更後のカラー

	void Awake()
	{

		if (TMP == null)
			TMP = GetComponent<TextMeshProUGUI>();

	}

	void Update()
	{

		//1秒周期でゆっくりとカラーを変更
		TMP.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time / duration, 1.0f));

	}

}
