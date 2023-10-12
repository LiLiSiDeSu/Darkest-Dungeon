using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelGameArchiveChooseLevel : PanelBase
{
    public PanelGameArchiveCell Cell;

    private Transform ImgCurrentChoice;
    private Image ImgGameArchiveDecorateLevel;
    private Text TxtDescribes;

    string[] Describes =
    {
        "明耀战役 虽然仍有挑战性 但被调整为比普通模式更快 更宽松 推荐暗黑地牢的新玩家尝试 只有菜通才会玩 (挑衅~~~)",
        "普通战役是游戏的\"原始\"设置 虽然没有时间限制 但与明耀战役相比 战役会更长且更具有挑战性 (是男人就去玩血月无光)",
        "血月战役不适合胆小的人参加 不要寄希望于时间和宽恕 你必须在一定时间内并在英雄死亡数到达界限之前战胜邪恶 " +
        "(霍 还真敢来 劝你还是别血月无光了把 这样你可能连老路都过不了 就算是高光你也撑不过几周 赶紧卸载游戏吧 啊哈哈哈哈~~~)"
    };

    protected override void Start()
    {
        base.Start();

        ImgCurrentChoice = transform.FindSonSonSon("ImgCurrentChoice");
        ImgCurrentChoice.gameObject.SetActive(false);
        ImgGameArchiveDecorateLevel = transform.FindSonSonSon("ImgGameArchiveDecorateLevel").GetComponent<Image>();
        TxtDescribes = transform.FindSonSonSon("TxtDescribes").GetComponent<Text>();

        #region 添加光标进入离开事件        

        string[] controlnames = 
        {
            "BtnGameArchiveChooseLevelBright",
            "BtnGameArchiveChooseLevelDarkness",
            "BtnGameArchiveChooseLevelBloodmoon"
        };
        string[] decorate =
        {
            "Art/DecorateGameArchiveLevelBright",
            "Art/DecorateGameArchiveLevelDarkness",
            "Art/DecorateGameArchiveLevelBloodmoon",
            "Art/DecorateGameArchiveLevelNone"
        };
        int[] pos =
        {
          93,
          27,
         -43
        };
        for (int i = 0; i < 3; i++)
        {
            int tempi = i;
            MgrUI.GetInstance().AddCustomEventListener(transform.FindSonSonSon(controlnames[i]).gameObject,
            EventTriggerType.PointerEnter, (param) =>
            {
                ImgCurrentChoice.gameObject.SetActive(true);
                ImgCurrentChoice.localPosition = new Vector3(ImgCurrentChoice.localPosition.x, pos[tempi], 0);                
                ImgGameArchiveDecorateLevel.sprite = 
                                   MgrRes.GetInstance().Load<Sprite>(decorate[tempi]);
                TxtDescribes.text = Describes[tempi];
            });
            MgrUI.GetInstance().AddCustomEventListener(transform.FindSonSonSon(controlnames[i]).gameObject,
            EventTriggerType.PointerExit, (param) =>
            {
                ImgCurrentChoice.gameObject.SetActive(false);
                ImgGameArchiveDecorateLevel.sprite = MgrRes.GetInstance().Load<Sprite>(decorate[decorate.Length - 1]);
                TxtDescribes.text = "-------------\r\n-------------\r\n-------------\r\n-------------\r\n-------------\r\n-------------";
            });
        }

        #endregion        
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnGameArchiveChooseLevelBright":
                Cell.GameArchiveCellData.e_GameArchiveLevel = E_GameArchiveLevel.Bright;
                Cell.InitGameArchiveCellData(Cell.GameArchiveCellData);
                MgrXml.GetInstance().Save(StartDataAndMgr.GetInstance().ListGameArchiveDataCell, StartDataAndMgr.GetInstance().PathGameArchiveData);
                break;

            case "BtnGameArchiveChooseLevelDarkness":
                Cell.GameArchiveCellData.e_GameArchiveLevel = E_GameArchiveLevel.Darkness;
                Cell.InitGameArchiveCellData(Cell.GameArchiveCellData);
                MgrXml.GetInstance().Save(StartDataAndMgr.GetInstance().ListGameArchiveDataCell, StartDataAndMgr.GetInstance().PathGameArchiveData);
                break;

            case "BtnGameArchiveChooseLevelBloodmoon":
                Cell.GameArchiveCellData.e_GameArchiveLevel = E_GameArchiveLevel.Bloodmoon;
                Cell.InitGameArchiveCellData(Cell.GameArchiveCellData);
                MgrXml.GetInstance().Save(StartDataAndMgr.GetInstance().ListGameArchiveDataCell, StartDataAndMgr.GetInstance().PathGameArchiveData);
                break;

            case "BtnClose":
                MgrUI.GetInstance().HidePanel(false, gameObject, gameObject.name);
                break;
        }
    }    
}
