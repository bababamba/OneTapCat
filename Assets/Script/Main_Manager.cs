using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Main_Manager : MonoBehaviour
{
    public static Main_Manager instance;
    void Awake()
    {
        instance = this;
    }
    [SerializeField] Video_Ad VAds;

    [SerializeField] int energy;
    [SerializeField] int energy_time;
    [SerializeField] Sprite[] Backgrounds; 

    [SerializeField] Image Main_Image;
    [SerializeField] Image Right_Image;
    [SerializeField] Image Left_Image;
    [SerializeField] Image BackImage;

    [SerializeField] public Sprite[] Main_Sprite;
    [SerializeField] Sprite[] Right_Sprite;
    [SerializeField] Sprite[] Left_Sprite;
    [SerializeField] public Sprite[] Ending_Sprite;
    [SerializeField] public Sprite[] Fail_Sprite;
    
    [SerializeField] public Sprite[] extra_Main_Sprite;
    [SerializeField] Sprite[] extra_Right_Sprite;
    [SerializeField] Sprite[] extra_Left_Sprite;

    [SerializeField] GameObject Pre_Ending;
    [SerializeField] EndingFx Pre_EndingFX;

    [SerializeField] TMP_Text UpperMessage;
    [SerializeField] GameObject Endcard;
    [SerializeField] TMP_Text EndMessage;
    [SerializeField] GameObject Failcard;
    [SerializeField] TMP_Text FailMessage;
    [SerializeField] GameObject MainGame;
    [SerializeField] GameObject SelectScreen;
    [SerializeField] GameObject[] StageSelect;
    [SerializeField] StaminaManager stamina;

    [SerializeField] GameObject Album;
    [SerializeField] Album_Manager AlManager;
    [SerializeField] GameObject Shop;

    [SerializeField] GameObject HavePopUp;
    [SerializeField] TMP_Text HaveText;
    [SerializeField] TMP_Text HaveCost;
    [SerializeField] GameObject DonHavePopUp;
    [SerializeField] GameObject ReallyGoPopUp;
    [SerializeField] GameObject ReallyQuitPopUp;

    [SerializeField] Image[]    StageImages;
    [SerializeField] Sprite[]   StageSprites;
    [SerializeField] RectTransform content;

    [SerializeField] GameObject UpperUI;

    [SerializeField] Image Cursor;

    public bool NoAds = false;
    int selectGo = 0;
    public bool[] cleared =  {  
        false, false, false, false, false, false,
        false, false, false, false, false, false,
        false, false, false, false, false, false,
        false, false, false, false, false, false,
        false, false, false, false, false, false,
        false, false, false, false, false, false 
    } ;

    public int stage = 0;
    int progressEnd = 4;
    int progress = 0;
    int EndA = 0;
    int EndB = 0;
    int[] cost = { 30, 35, 40, 45, 50, 55, 60 };
    int[] data1 = {
        0,5, 1,2, 3,4, 6,0,
        1,2, 5,0, 3,4, 6,0,
        1,2, 0,5, 6,0, 3,4,
        1,2, 5,0, 6,0, 3,4,
        0,5, 0,0, 6,0, 0,7
    };
    int[] extra_Data =
    {   8,0, 1,9

    };
    string[] script1 = { 
        "\"냐아앙..\" \n지각해서 혼났다. 5분만 더 잔다는 게 30분이나 자버렸다니…", //stage1
        "\"나 좀 도와조라냥..\" \n움직일수록 더 꼬여! 실을 가지고 놀다 몸에 엉켜버렸다.",
        "\"가지고 있는 생선 다 내놔!!\" \n불량식품을 즐겨먹다가 불량 냥이가 되어버렸다. ",
        "\"저.. 저기..\" \n친구를 사귀고 싶지만, 말 걸기는 무서워… 귀여운 부끄 냥이가 됐다!",
        "\"여기 여기 모여라! 나랑 놀자냥!\" \n모두가 좋아하는 인싸 냥이가 됐다! ",
        "\"모르는 게 없다냥\" \n공부도 체육도 1등! 못하는 게 없는 전교 1등 냥이가 됐다!",

        "\"앗! 저는 루돌프가 아니라구요!\"\n 분장을 너무 잘한 나머지 진짜 산타가 끌고 갔다.",//stage2
        "\"땡!\"\n 편집 공부하다 '냥냥 지구오락실'의 냥피디가 됐다! 새로운 꿈을 찾았다.",
        "\"냥이냥지TV~ 예스잼!\"\n 귀여운 외모로 사랑받고 있는 쌍둥이 냥튜버가 됐다!",
        "\"궁금한 건 못 참아! 오늘의 실험은?\"\n 구독냥이들의 궁금증을 해소시켜줄 냥팝이 됐다!",
        "\"사장님 더 주세요!\"\n 벌써 생선 100마리째.. 많이 먹고 많이 귀여운 쯔냥이 됐다.",
        "\"냥언니 입니따앗! 아핫!\"\n 귀여운데 웃기기까지.. 초등학생들에게 사랑받는 냥언니가 됐다!",

        "\"냐앙.. 그믄흐르..(그만해라..)\"\n 눈싸움을 하다 눈을 너무 많이 맞아서 눈사람이 됐다…",//stage3
        "\"우앙.. 배부르다 냐앙..\"\n 고구마를 많이 먹었더니 말랑말랑 뱃살이 생겼다.",
        "\"역시 집이 최고! 오늘은 뭐 보냥..\"\n 방학 동안 집에서 냥플릭스만 보며 빈둥거리고 있다.",
        "\"일곱시에 일어나서@#$%\" 1분 1초가 아까운 계획적인 냥이! 겨울방학도 알차게 보냈다.",
        "\"드르렁 푸우\"\n 집에서 잠만 자는 잠꾸러기 냥이가 됐다! 눈 떠보니 벌써 겨울 방학이 끝났다...",
        "\"나랑 오늘 놀자냥!\"\n 하루 종일 만든 눈오리만 백 마리! 노는 게 좋은 냥이가 됐다.  ",

        "\"여기.. 맞아?\"\n 가짜 명함을 받았다. 사기를 당해 돈도 희망도 잃었다…",//stage4
        "\"냐..앙..\"\n 굶었더니 말할 힘도 없어졌다. 체력이 안 좋아진 냥이는 결국 데뷔를 하지 못했다.",
        "\"나를 안 좋아할 수 없을 거다냥!\"\n 타고난 외모와 춤 실력으로 사랑받는 원냥이가 됐다!",
        "\"냥이는 생선이 좋은 거얼~\"\n 못하는 게 없는 아이돌의 아이돌 냥이유가 됐다!",
        "\"츄르는 없어! 배고파도~\"\n 엉뚱함이 매력인 뉴냥스의 해냥이가 됐다!",
        "\"어떻게 집사까지 사랑하겠어~\"\n 작곡도 목소리도 좋은 실력파 남매 냥냥뮤지션이 됐다!",

        "\"갑자기.. 약속이 생겨서..\"\n 썸남이 약속이 생겼다며 도망갔다.\n 예쁘게 입을 걸 그랬나?",
        "\"할짝.. 할 수 있을 거 같아..\"\n 우산 모양을 뽑은 냥이\n 갑자기 분위기 오징어 게임!",
        "\"또.. 또..! 또!!! 꽝?!!!!!\"\n 우주최강 똥손 냥이가 됐다.\n 이러다 거지가 되겠어..",
        "\"냐앙.. 옷이 터질 거 같아..\"\n 타코야끼를 너무 많이 먹었더니\n 배가 빵빵한 냥이가 됐다!",
        "\"냥플릭스 나는 솔로냥입니다.\"\n 결국 친구 사이로 남게 된 우리.\n 나는 솔로냥에서 전화 왔다.",
        "\"내 생선 다 줄 수 있다 냐앙~\"\n 썸 청산 연애 시작!\n 사랑에 빠진 냥이 됐다.",
        ""
    };
    public string[] quest1 = { 
        "아침이다.. 너무 피곤한데 어떡하지?",//stage1
        "학교 가기 전 문방구에서 뭐 사지?",
        "드디어 쉬는 시간이다! 나는 뭘 할까?",
        "체육 시간에 어떤 운동을 할까?",
        "지각한 냥이","실에 걸린 냥이",
        "골목대장 냥아치","소심한 부끄 냥이","인기 스타 인싸 냥이","전교 1등 모범 냥이",
        "냥튜버에 도전! 어떤 영상을 올리지?",
        "크리스마스엔 어떤 분장을 할까?",
        "구독자를 늘리기 위해서 나는?",
        "영상 편집은 어떻게 할까?",
        "루돌프가 된 냥이","방송국 냥피디",
        "귀여운 키즈 냥튜버","실험하는 냥팝","먹방 냥튜버 쯔냥","예쁘고 웃긴 냥언니",
        "겨울 방학 시작! 방학에 뭐부터 할까?",//stage3
        "친구들이 놀자고 한다. 뭐 하고 놀지?",
        "겨울에는 이거지! 내가 좋아하는 음식은?",
        "12월 31일이다! 연말을 어떻게 보낼까?",
        "눈사람이 된 냥이","살이 찐 돼냥이",
        "집순이 냥이","1초도 아까운 냥이","겨울잠 자는 냥이","노는 게 좋은 냥이",
        "내 꿈은 아이돌! 어떤 노력을 해야 할까?",//stage4
        "길을 걷다 명함을 받았다. 어떻게 할까?",
        "연습생이 됐다. 체중 관리는 어떡하지?",
        "아이돌이 된 나는 어떤 무대에 서게 될까?",
        "사기 당한 냥이","힘이 없는 냥이",
        "냥이브의 원냥이","국힙원탑 냥이유","뉴냥스의 해냥이","갓벽한 냥냥뮤지션",
        "여름 축제에 뭘 입고 갈까?",//stage5
        "축제는 누구랑 같이 갈까?",
        "과자 뽑기 도전! 무슨 모양을 뽑을까?",
        "줄 당기기 게임! 어떤 줄을 고를까?",
         "꼬질꼬질 냥이","오징어 게임 냥이",
        "우주최강 똥손 냥이","배가 빵빵한 냥이","빛이 나는 솔로 냥이","사랑에 빠진 냥이",
        "",
        "",
        "",
        "",
        "","",
        "","","",""
       };
    public string[] extraQuest = {
        "좋아하는 타코야끼를 샀다. 어떻게 할까?",//for stage5
        "불꽃놀이가 시작됐다. 손을 잡을까?"



    };
    public string[] stageName =
    {
        "학교 가는 길",

        "냥튜버 키우기",

        "겨울 방학 보내기",

        "아이돌냥 키우기",

        "여름 축제에서",

        "학교 가는 길",

    };


    // Start is called before the first frame update
    void Start()
    {
        stage = 1;progress = 0;// 임시
        Audio_Manager.Instance.BGM_Title();
        //StartCoroutine(CascadeBugFix());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Audio_Manager.Instance.SFX_Click();
            Cursor.gameObject.transform.position = Input.mousePosition;
            Fx_Manager.instance.FadeOut(Cursor);

        }
        #if UNITY_ANDROID
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (MainGame.activeSelf)
                InGameOpenStagesSelectScreen();
            else
                ReallyQuit();
            
            
        }
        #endif
    }
    
        public void UpdateScreen(int progressNumber) {
        UpperUI.SetActive(true);
        //Debug.Log(progress);
        if (stage > 4)
            progressEnd = 6;
        BackImage.sprite = Backgrounds[0];
        if (progress <= 3)
        {
            UpperMessage.text = quest1[(stage - 1) * 10 + progress];

            Main_Image.sprite = Main_Sprite[(stage - 1) * 4 + progressNumber];
            Right_Image.sprite = Right_Sprite[(stage - 1) * 4 + progressNumber];
            Left_Image.sprite = Left_Sprite[(stage - 1) * 4 + progressNumber];
        }
        else
        {
            UpperMessage.text = extraQuest[(stage - 5) * 2 + progress-4];

            Main_Image.sprite = extra_Main_Sprite[(stage - 5) * 2 + progressNumber-4];
            Right_Image.sprite = extra_Right_Sprite[(stage - 5) * 2 + progressNumber-4];
            Left_Image.sprite = extra_Left_Sprite[(stage - 5) * 2 + progressNumber-4];
        }

            /*
        Fx_Manager.instance.Ddoing(Main_Image.GetComponent<RectTransform>());
        Fx_Manager.instance.Ddoing(Right_Image.GetComponent<RectTransform>());
        Fx_Manager.instance.Ddoing(Left_Image.GetComponent<RectTransform>());
        */
    }
    public void FailScreen(int endNumber)
    {
        Audio_Manager.Instance.SFX_Fail();
        UpperUI.SetActive(false);
        Fx_Manager.instance.Ddoing(Main_Image.GetComponent<RectTransform>());
        if (stage <= 4)
        {

            Main_Image.sprite = Fail_Sprite[(stage - 1) * 2 + endNumber - 1];
            cleared[(stage - 1) * 6 + endNumber - 1] = true;
            Failcard.SetActive(true);
            UpperMessage.text = quest1[(stage - 1) * 10 + 3 + endNumber];
            FailMessage.text = script1[(stage - 1) * 6 + endNumber - 1];
            BackImage.sprite = Backgrounds[1];
        }
        else if(endNumber<3)
        {
            Main_Image.sprite = Fail_Sprite[(stage - 1) * 2 + endNumber - 1];
            cleared[(stage - 1) * 6 + endNumber - 1] = true;
            Failcard.SetActive(true);
            UpperMessage.text = quest1[(stage - 1) * 10 + 3 + endNumber];
            FailMessage.text = script1[(stage - 1) * 6 + endNumber - 1];
            BackImage.sprite = Backgrounds[1];
        }
        else
        {
            Main_Image.sprite = Ending_Sprite[(stage - 1) * 4 + endNumber - 3];
            cleared[(stage - 1) * 6 + endNumber - 1] = true;
            Failcard.SetActive(true);
            UpperMessage.text = quest1[(stage - 1) * 10 + 3 + endNumber];
            FailMessage.text = script1[(stage - 1) * 6 + endNumber - 1];
            BackImage.sprite = Backgrounds[1];
        }
        
       
        

    }
    int Ending()
    {
        int temp = 0;
        if (EndA == 1)
        {
            if (EndB == 1)
                temp = 1;
            else
                temp = 2;
        }
        else
        {
            if (EndB == 1)
                temp = 3;
            else
                temp = 4;
        }


        return temp;
    }
    public void EndingScreen(int endNumber)
    {
        Audio_Manager.Instance.SFX_Ending();
        //if(!NoAds)VAds.ShowAd();
        UpperUI.SetActive(false);
        Pre_Ending.SetActive(true);
        Pre_EndingFX.RunEffect();
        Main_Image.sprite = Ending_Sprite[(stage - 1) * 4 + endNumber-1];
        EndMessage.text = script1[(stage-1)*6 + endNumber + 1];
        UpperMessage.text = quest1[(stage - 1) * 10 +5 + endNumber];
        Endcard.SetActive(true);
        cleared[(stage - 1) * 6 + endNumber+1] = true;
        BackImage.sprite = Backgrounds[2];


    }
    public void Retry()
    {
        if (!NoAds)
            VAds.ShowAd();
        //progress--;
        UpperUI.SetActive(true);
        Failcard.SetActive(false);
        UpdateScreen(progress);
    }
    public void ButtonLeft()
    {
        Fx_Manager.instance.Ddoing2(Left_Image.GetComponent<RectTransform>());
        //Debug.Log((stage - 1) * 8 + (progress * 2) + " " + data1[(stage - 1) * 8 + (progress * 2)]);
        if (progress <= 3)
        {
            switch (data1[(stage - 1) * 8 + (progress * 2)])
            {
                case 0:
                    progress++;
                    if (progress == progressEnd)
                        EndingScreen(Ending());
                    else
                        UpdateScreen(progress);
                    break;
                case 1:
                    if (progress <= 3)
                    {
                        EndA = 1;
                        progress++;
                        if (progress == progressEnd)
                            EndingScreen(Ending());
                        else
                            UpdateScreen(progress);
                    }
                    else
                        EndingScreen(4);
                    break;
                case 3:
                    EndB = 1;
                    progress++;
                    if (progress == progressEnd)
                        EndingScreen(Ending());
                    else
                        UpdateScreen(progress);
                    break;
                case 5: FailScreen(1); break;
                case 6: FailScreen(2); break;
                case 7: FailScreen(3); break;
                case 8: FailScreen(4); break;
                case 9: FailScreen(5); break;

            }
        }
        else
        {
            switch (extra_Data[(stage-5)*4+((progress-4)*2)])
            {
                case 0:
                    progress++;
                    if (progress == progressEnd)
                        EndingScreen(Ending());
                    else
                        UpdateScreen(progress);
                    break;
                case 1:
                    if (progress <= 4)
                    {
                        EndA = 1;
                        progress++;
                        if (progress == progressEnd)
                            EndingScreen(Ending());
                        else
                            UpdateScreen(progress);
                    }
                    else
                        EndingScreen(4);
                    break;
                case 3:
                    EndB = 1;
                    progress++;
                    if (progress == progressEnd)
                        EndingScreen(Ending());
                    else
                        UpdateScreen(progress);
                    break;
                case 5: FailScreen(1); break;
                case 6: FailScreen(2); break;
                case 7: FailScreen(3); break;
                case 8: FailScreen(4); break;
                case 9: FailScreen(5); break;

            }
        }
        
        
    }
    public void ButtonRight()
    {
        Fx_Manager.instance.Ddoing2(Right_Image.GetComponent<RectTransform>());
        //Debug.Log( +" "+data1[(stage - 1) * 8 + (progress * 2)] + 1);
        if (progress <= 3)
        {

            switch (data1[(stage - 1) * 8 + (progress * 2 + 1)])
            {
                case 0:
                    progress++;
                    if (progress == progressEnd)
                        EndingScreen(Ending());
                    else
                        UpdateScreen(progress);
                    break;
                case 2:
                    EndA = 2;
                    progress++;
                    if (progress == progressEnd)
                        EndingScreen(Ending());
                    else
                        UpdateScreen(progress);
                    break;
                case 4:
                    EndB = 2;
                    progress++;
                    if (progress == progressEnd)
                        EndingScreen(Ending());
                    else
                        UpdateScreen(progress);
                    break;
                case 5: FailScreen(1); break;
                case 6: FailScreen(2); break;
                case 7: FailScreen(3); break;
                case 8: FailScreen(4); break;
                case 9: FailScreen(5); break;

            }
        }
        else
        {
            switch (extra_Data[(stage - 5) * 4 + ((progress - 4) * 2) + 1])
            {
                case 0:
                    progress++;
                    if (progress == progressEnd)
                        EndingScreen(Ending());
                    else
                        UpdateScreen(progress);
                    break;
                case 2:
                    EndA = 2;
                    progress++;
                    if (progress == progressEnd)
                        EndingScreen(Ending());
                    else
                        UpdateScreen(progress);
                    break;
                case 4:
                    EndB = 2;
                    progress++;
                    if (progress == progressEnd)
                        EndingScreen(Ending());
                    else
                        UpdateScreen(progress);
                    break;
                case 5: FailScreen(1); break;
                case 6: FailScreen(2); break;
                case 7: FailScreen(3); break;
                case 8: FailScreen(4); break;
                case 9: FailScreen(5); break;
            }
        }
               

    }

    public void CloseAll()
    {
        UpperUI.SetActive(true);
        SelectScreen.SetActive(false);
        Failcard.SetActive(false);
        Endcard.SetActive(false);
        MainGame.SetActive(false);
        Shop.SetActive(false);
        Album.SetActive(false);
        HavePopUp.SetActive(false);
        DonHavePopUp.SetActive(false);
        BackImage.sprite = Backgrounds[0];
        
    }
    public void OpenMainGame()
    {
        CloseAll();

        
        MainGame.SetActive(true);
    }
    public void OpenStageSelect(int select)
    {
        bool check = false;
        check = StaminaManager.instance.StaminaCheck(cost[select-1]);
        if (check)
        {
            stage = select;
            HavePopUpOn();
        }
        else
            DonHavePopUpOn();


    }
    public void StartGame()
    {
        StaminaManager.instance.StaminaDown(cost[stage - 1]);
        StageImages[stage - 1].sprite = StageSprites[stage - 1];
        CloseAll();
        MainGame.SetActive(true);
        UpdateScreen(0);
        Audio_Manager.Instance.BGM_InGame();

        Audio_Manager.Instance.SFX_Start();
    }
    public void OpenStagesSelectScreen()
    {
        Audio_Manager.Instance.BGM_Title();
        CloseAll();
        progress = 0;
        UpdateScreen(0);
        
        foreach (GameObject Select in StageSelect)
        {
            Select.SetActive(false);
           
        }
        
        StartCoroutine(CascadeEffectStageSelect());
    }
    public void OpenShop()
    {
        CloseAll();

        Shop.SetActive(true);
    }
    public void OpenAlbum()
    {
        CloseAll();
        Audio_Manager.Instance.BGM_Title();
        Album.SetActive(true);
        Debug.Log(stage);
        AlManager.ChangeStage(stage);
        AlManager.OpenAlbum();
    }
    public void HavePopUpOn()
    {
        HavePopUp.SetActive(true);
        Fx_Manager.instance.Ddoing(HavePopUp.GetComponent<RectTransform>());
        switch (stage)
        {
            case 1:
                HaveText.text = "학교 가는 길"; break;
            case 2:
                HaveText.text = "냥튜버 키우기"; break;
            case 3:
                HaveText.text = "겨울 방학 보내기"; break;
            case 4:
                HaveText.text = "아이돌냥 키우기"; break;
            case 5:
                HaveText.text = "여름 축제에서"; break;
        }
        HaveCost.text = "X " + cost[stage - 1].ToString();
        
        
       
    }
    public void DonHavePopUpOn()
    {
        DonHavePopUp.SetActive(true);
        Fx_Manager.instance.Ddoing(DonHavePopUp.GetComponent<RectTransform>());
    }
    public void NoAdsPuchased()
    {
        NoAds = true;
    }
    public void InGameOpenStagesSelectScreen()
    {
        selectGo = 1;
        ReallyGoPopUp.SetActive(true);
        Fx_Manager.instance.Ddoing(ReallyGoPopUp.GetComponent<RectTransform>());

    }
    public void InGameOpenShop()
    {
        selectGo = 2;
        ReallyGoPopUp.SetActive(true);
        Fx_Manager.instance.Ddoing(ReallyGoPopUp.GetComponent<RectTransform>());
    }
    public void InGameOpenAlbum()
    {
        selectGo = 3;
        ReallyGoPopUp.SetActive(true);
        Fx_Manager.instance.Ddoing(ReallyGoPopUp.GetComponent<RectTransform>());
    }
    public void ReallyGo()
    {
        switch (selectGo)
        {
            case 1: OpenStagesSelectScreen(); break;
            case 2: OpenShop(); break;
            case 3: OpenAlbum(); break;
        }
        Audio_Manager.Instance.BGM_Title();
    }
    public void ReallyQuit()
    {
        ReallyQuitPopUp.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }


    IEnumerator CascadeEffectStageSelect()
    {
        SelectScreen.SetActive(true);
        content.position = new Vector3(content.position.x, 0f,content.position.z);
        yield return null;
       // content.position = new Vector3(content.position.x, 0f, content.position.z);
        yield return null;
        foreach (GameObject Select in StageSelect)
        {
            Select.SetActive(true);
            Select.GetComponent<FadeFx>().resetAnim();
            
            yield return new WaitForSeconds(0.1f);
            

        }
    }
    IEnumerator CascadeBugFix()
    {
        SelectScreen.SetActive(true);
        yield return null;
        SelectScreen.SetActive(false) ;
    }
}
