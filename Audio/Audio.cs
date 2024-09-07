using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

    [SerializeField] private AudioSource PlayerAudio;  //Audioを再生する場所
    [SerializeField] private AudioClip[] audioClip = new AudioClip[2];    //Audioの種類

    private void Start()
    {

        PlayerAudio = GetComponent<AudioSource>();

    }

    //Coinの音を一度だけ流す
    public void CoinSoundEffect()
    {

        PlayerAudio.PlayOneShot(audioClip[0]);

    }

    //壁の衝突音
    public void WallCollideEffect()
    {

        PlayerAudio.PlayOneShot(audioClip[1]);

    }

    //Plyaerが衝突した時に、音を流す
    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Coin"))
        {

            CoinSoundEffect();

        }

        if (collision.gameObject.CompareTag("Wall"))
        {

            WallCollideEffect();

        }

    }

}
