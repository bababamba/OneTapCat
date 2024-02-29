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
        "\"�ľƾ�..\" \n�����ؼ� ȥ����. 5�и� �� �ܴٴ� �� 30���̳� �ڹ��ȴٴϡ�", //stage1
        "\"�� �� ���������..\" \n�����ϼ��� �� ����! ���� ������ ��� ���� ���ѹ��ȴ�.",
        "\"������ �ִ� ���� �� ����!!\" \n�ҷ���ǰ�� ��ܸԴٰ� �ҷ� ���̰� �Ǿ���ȴ�. ",
        "\"��.. ����..\" \nģ���� ��Ͱ� ������, �� �ɱ�� �������� �Ϳ��� �β� ���̰� �ƴ�!",
        "\"���� ���� �𿩶�! ���� ���ڳ�!\" \n��ΰ� �����ϴ� �ν� ���̰� �ƴ�! ",
        "\"�𸣴� �� ���ٳ�\" \n���ε� ü���� 1��! ���ϴ� �� ���� ���� 1�� ���̰� �ƴ�!",

        "\"��! ���� �絹���� �ƴ϶󱸿�!\"\n ������ �ʹ� ���� ������ ��¥ ��Ÿ�� ���� ����.",//stage2
        "\"��!\"\n ���� �����ϴ� '�ɳ� ����������'�� ���ǵ� �ƴ�! ���ο� ���� ã�Ҵ�.",
        "\"���̳���TV~ ������!\"\n �Ϳ��� �ܸ�� ����ް� �ִ� �ֵ��� ��Ʃ���� �ƴ�!",
        "\"�ñ��� �� �� ����! ������ ������?\"\n �������̵��� �ñ����� �ؼҽ����� ������ �ƴ�!",
        "\"����� �� �ּ���!\"\n ���� ���� 100����°.. ���� �԰� ���� �Ϳ��� ����� �ƴ�.",
        "\"�ɾ�� �Դϵ���! ����!\"\n �Ϳ�� ��������.. �ʵ��л��鿡�� ����޴� �ɾ�ϰ� �ƴ�!",

        "\"�ľ�.. �׹��帣..(�׸��ض�..)\"\n ���ο��� �ϴ� ���� �ʹ� ���� �¾Ƽ� ������� �ƴ١�",//stage3
        "\"���.. ��θ��� �ľ�..\"\n ������ ���� �Ծ����� �������� ����� �����.",
        "\"���� ���� �ְ�! ������ �� ����..\"\n ���� ���� ������ ���ø����� ���� ��հŸ��� �ִ�.",
        "\"�ϰ��ÿ� �Ͼ��@#$%\" 1�� 1�ʰ� �Ʊ�� ��ȹ���� ����! �ܿ���е� ������ ���´�.",
        "\"�帣�� Ǫ��\"\n ������ �Ḹ �ڴ� ��ٷ��� ���̰� �ƴ�! �� ������ ���� �ܿ� ������ ������...",
        "\"���� ���� ���ڳ�!\"\n �Ϸ� ���� ���� �������� �� ����! ��� �� ���� ���̰� �ƴ�.  ",

        "\"����.. �¾�?\"\n ��¥ ������ �޾Ҵ�. ��⸦ ���� ���� ����� �Ҿ��١�",//stage4
        "\"��..��..\"\n �������� ���� ���� ��������. ü���� �� ������ ���̴� �ᱹ ���߸� ���� ���ߴ�.",
        "\"���� �� ������ �� ���� �Ŵٳ�!\"\n Ÿ�� �ܸ�� �� �Ƿ����� ����޴� �����̰� �ƴ�!",
        "\"���̴� ������ ���� �ž�~\"\n ���ϴ� �� ���� ���̵��� ���̵� �������� �ƴ�!",
        "\"�򸣴� ����! ����ĵ�~\"\n �������� �ŷ��� ���ɽ��� �س��̰� �ƴ�!",
        "\"��� ������� ����ϰھ�~\"\n �۰ ��Ҹ��� ���� �Ƿ��� ���� �ɳɹ������� �ƴ�!",

        "\"���ڱ�.. ����� ���ܼ�..\"\n �泲�� ����� ����ٸ� ��������.\n ���ڰ� ���� �� �׷���?",
        "\"��¦.. �� �� ���� �� ����..\"\n ��� ����� ���� ����\n ���ڱ� ������ ��¡�� ����!",
        "\"��.. ��..! ��!!! ��?!!!!!\"\n �����ְ� �˼� ���̰� �ƴ�.\n �̷��� ������ �ǰھ�..",
        "\"�ľ�.. ���� ���� �� ����..\"\n Ÿ�ھ߳��� �ʹ� ���� �Ծ�����\n �谡 ������ ���̰� �ƴ�!",
        "\"���ø��� ���� �ַγ��Դϴ�.\"\n �ᱹ ģ�� ���̷� ���� �� �츮.\n ���� �ַγɿ��� ��ȭ �Դ�.",
        "\"�� ���� �� �� �� �ִ� �ľ�~\"\n �� û�� ���� ����!\n ����� ���� ���� �ƴ�.",
        ""
    };
    public string[] quest1 = { 
        "��ħ�̴�.. �ʹ� �ǰ��ѵ� �����?",//stage1
        "�б� ���� �� ���汸���� �� ����?",
        "���� ���� �ð��̴�! ���� �� �ұ�?",
        "ü�� �ð��� � ��� �ұ�?",
        "������ ����","�ǿ� �ɸ� ����",
        "������ �ɾ�ġ","�ҽ��� �β� ����","�α� ��Ÿ �ν� ����","���� 1�� ��� ����",
        "��Ʃ���� ����! � ������ �ø���?",
        "ũ���������� � ������ �ұ�?",
        "�����ڸ� �ø��� ���ؼ� ����?",
        "���� ������ ��� �ұ�?",
        "�絹���� �� ����","��۱� ���ǵ�",
        "�Ϳ��� Ű�� ��Ʃ��","�����ϴ� ����","�Թ� ��Ʃ�� ���","���ڰ� ���� �ɾ��",
        "�ܿ� ���� ����! ���п� ������ �ұ�?",//stage3
        "ģ������ ���ڰ� �Ѵ�. �� �ϰ� ����?",
        "�ܿ￡�� �̰���! ���� �����ϴ� ������?",
        "12�� 31���̴�! ������ ��� ������?",
        "������� �� ����","���� �� �ų���",
        "������ ����","1�ʵ� �Ʊ�� ����","�ܿ��� �ڴ� ����","��� �� ���� ����",
        "�� ���� ���̵�! � ����� �ؾ� �ұ�?",//stage4
        "���� �ȴ� ������ �޾Ҵ�. ��� �ұ�?",
        "�������� �ƴ�. ü�� ������ �����?",
        "���̵��� �� ���� � ���뿡 ���� �ɱ�?",
        "��� ���� ����","���� ���� ����",
        "���̺��� ������","������ž ������","���ɽ��� �س���","������ �ɳɹ�����",
        "���� ������ �� �԰� ����?",//stage5
        "������ ������ ���� ����?",
        "���� �̱� ����! ���� ����� ������?",
        "�� ���� ����! � ���� ����?",
         "�������� ����","��¡�� ���� ����",
        "�����ְ� �˼� ����","�谡 ������ ����","���� ���� �ַ� ����","����� ���� ����",
        "",
        "",
        "",
        "",
        "","",
        "","","",""
       };
    public string[] extraQuest = {
        "�����ϴ� Ÿ�ھ߳��� ���. ��� �ұ�?",//for stage5
        "�Ҳɳ��̰� ���۵ƴ�. ���� ������?"



    };
    public string[] stageName =
    {
        "�б� ���� ��",

        "��Ʃ�� Ű���",

        "�ܿ� ���� ������",

        "���̵��� Ű���",

        "���� ��������",

        "�б� ���� ��",

    };


    // Start is called before the first frame update
    void Start()
    {
        stage = 1;progress = 0;// �ӽ�
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
                HaveText.text = "�б� ���� ��"; break;
            case 2:
                HaveText.text = "��Ʃ�� Ű���"; break;
            case 3:
                HaveText.text = "�ܿ� ���� ������"; break;
            case 4:
                HaveText.text = "���̵��� Ű���"; break;
            case 5:
                HaveText.text = "���� ��������"; break;
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
