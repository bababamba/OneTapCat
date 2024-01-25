using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio_Manager : MonoBehaviour
{
    public static Audio_Manager Instance;
    
    [SerializeField] GameObject[] CheckOn;

    void Awake()
    {
        Instance = this;
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
            //SetBGMVolume(1);
           // SetSFXVolume(1);
        }
    }
    public void SoundOff()
    {
        if (CheckOn[1].activeSelf)
        {
            CheckOn[0].SetActive(true);
            CheckOn[1].SetActive(false);
           // SetBGMVolume(0);
           // SetSFXVolume(0);
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

    public AudioSource bgmSource;
    public AudioSource sfxSource;

    public AudioClip Title;
    public AudioClip Merge;
    public AudioClip Tutorial;
    public AudioClip Boss;

    public AudioClip ClickBucket;
    public AudioClip PushItem;
    public AudioClip ItemMerge;
    public AudioClip QuestDone;
    public AudioClip WrongItem;
    public AudioClip ButtonClick;
    public AudioClip MapFull;
    public AudioClip BossNoTime;
    public AudioClip BossWinGetItem;
    public AudioClip GameOver;
    public AudioClip BuyItem;
    public AudioClip paperRip;

    public AudioClip buildSound1;
    public AudioClip buildSound2;

    public void SFX_BuildSound1()
    {
        sfxSource.PlayOneShot(buildSound1);
    }

    public void SFX_BuildSound2()
    {
        sfxSource.PlayOneShot(buildSound2);
    }

    public void BGM_Title()
    {
        bgmSource.clip = Title;
        bgmSource.Play();
    }
    public void BGM_Merge()
    {
        bgmSource.clip = Merge;
        bgmSource.Play();
    }
    public void BGM_Tutorial()
    {
        bgmSource.clip = Tutorial;
        bgmSource.Play();
    }
    public void BGM_Boss()
    {
        bgmSource.clip = Boss;
        bgmSource.Play();
    }

    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = volume;
        PlayerPrefs.SetFloat("BGMVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void SFX_ClickBucket()
    {
        sfxSource.PlayOneShot(ClickBucket);
    }

    public void SFX_PaperRip()
    {
        sfxSource.PlayOneShot(paperRip);
    }
    public void SFX_PushItem()
    {
        sfxSource.PlayOneShot(PushItem);
    }
    public void SFX_ItemMerge()
    {
        sfxSource.PlayOneShot(ItemMerge);
    }
    public void SFX_QuestDone()
    {
        sfxSource.PlayOneShot(QuestDone);
    }
    public void SFX_WrongItem()
    {
        sfxSource.PlayOneShot(WrongItem);
    }
    public void SFX_ButtonClick()
    {
        sfxSource.PlayOneShot(ButtonClick);
    }
    public void SFX_MapFull()
    {
        sfxSource.PlayOneShot(MapFull);
    }
    public void SFX_BossNoTime()
    {
        sfxSource.PlayOneShot(BossNoTime);
    }
    public void SFX_BossWinGetItem()
    {
        sfxSource.PlayOneShot(BossWinGetItem);
    }
    public void SFX_GameOver()
    {
        sfxSource.PlayOneShot(GameOver);
    }
    public void SFX_BuyItem()
    {
        sfxSource.PlayOneShot(BuyItem);
    }
}
