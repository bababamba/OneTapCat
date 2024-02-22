using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio_Manager : MonoBehaviour
{
    public static Audio_Manager Instance;
    public AudioSource bgm;
    public AudioSource sfx;

    //[SerializeField] GameObject a;
    //[SerializeField] GameObject b;


    public AudioClip Title;

    public AudioClip Click;

    [SerializeField] GameObject[] CheckOn;

    void Awake()
    {
        Instance = this;
       // bgm = a.GetComponent<AudioSource>();
        //sfx = b.GetComponent<AudioSource>();
        Debug.Log(bgm);
    }

    void Update()
    {
        
    }
    public void SoundOn()
    {
        if (!CheckOn[1].activeSelf)
        {
            CheckOn[1].SetActive(true);
            CheckOn[0].SetActive(false);
            SetBGMVolume(1);
            SetSFXVolume(1);
        }
    }
    public void SoundOff()
    {
        if (CheckOn[1].activeSelf)
        {
            CheckOn[0].SetActive(true);
            CheckOn[1].SetActive(false);
          SetBGMVolume(0);
          SetSFXVolume(0);
        }
    }
       public void SetLanguage(int nation)
    {
        switch (nation) {
            case 0:
                if (!CheckOn[2].activeSelf)
                {
                    CheckOn[2].SetActive(true);
                    CheckOn[3].SetActive(false);
                    CheckOn[4].SetActive(false);
                    //언어 바꾸기
                }
                break;
            case 1:
                if (!CheckOn[3].activeSelf)
                {
                    CheckOn[3].SetActive(true);
                    CheckOn[2].SetActive(false);
                    CheckOn[4].SetActive(false);
                    //언어 바꾸기
                }
                break;
            case 2:
                if (!CheckOn[4].activeSelf)
                {
                    CheckOn[4].SetActive(true);
                    CheckOn[3].SetActive(false);
                    CheckOn[2].SetActive(false);
                    //언어 바꾸기
                }
                break;

        }





    }




    float BGMVolume;
    float SFXVolume;

    public void SetBGMVolume(float volume)
    {
        bgm.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfx.volume = volume;
    }
    public void BGM_Title()
    {
        Debug.Log(bgm);
        bgm.clip = Title;
        bgm.Play();
    }
    public void SFX_Click()
    {
        sfx.PlayOneShot(Click);
    }


}
