using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance { get; private set; }

    public GameObject[] getItemsArray;
    public GameObject ItemPanel;
    public GameObject BtnPaper;
    public GameObject BtnLight;
    public GameObject BtnLightIn;
    public GameObject BtnClearPanel1;
    public string selectItem;

    public bool isPaperChange = false;

    // Start is called before the first frame update
    void Start()
    {
      Instance = this;

        foreach(var obj in getItemsArray)
        {
          obj.gameObject.GetComponent<Button>().onClick.AddListener(() =>
          {
            AudioManager.Instance.SoundSE("TapUIBtn");
            onTapItemImage(obj);
          });
        }

        BtnPaper.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangePaper();
        });

        BtnLight.GetComponent<Button>().onClick.AddListener(() =>
        {
            OpenLightCover();
        });

        BtnLightIn.GetComponent<Button>().onClick.AddListener(() =>
        {
            IntoDenchi();
        });
        BtnClearPanel1.GetComponent<Button>().onClick.AddListener(() =>
        {
            getDecuchi();
        });
    }

    // Update is called once per frame
    void Update()
    {
    }

    //<summary>
    //アイテム取得
    //</summary>
    //<param>アイテム名</param>
    public void getItem(string itemName)
    {
      for(int i = 0; i < getItemsArray.Length; i++)
      {
        if(getItemsArray[i].gameObject.GetComponent<Image>().sprite == null)
        {
          getItemsArray[i].gameObject.GetComponent<Image>().sprite  = Resources.Load<Sprite>("Images/Items/" + itemName);
          getItemsArray[i].SetActive(true);
          break;
        }
      }

      switch(itemName)
      {
        case "Light":
          SaveLoadSystem.Instance.gameData.isGetKaicyudento = true;
          break;
        case "Penchi":
          SaveLoadSystem.Instance.gameData.isGetPenchi = true;
          break;
        case "Denchi":
          SaveLoadSystem.Instance.gameData.isGetDenchi = true;
          break;
        case "Bottle":
          SaveLoadSystem.Instance.gameData.isGetBottle = true;
          break;
        case "Totte":
          SaveLoadSystem.Instance.gameData.isGetTotte = true;
          break;
        default:
          break;
      }

      AudioManager.Instance.SoundSE("ItemGet");

      SaveLoadSystem.Instance.gameData.getItems += itemName + ";";
      SaveLoadSystem.Instance.Save();
    }

    //<summary>
    //取得アイテムのロード
    //</summary>
    //<param>アイテム名</param>
    public void loadItem(string itemName)
    {
      for(int i = 0; i < getItemsArray.Length; i++)
      {
        if(getItemsArray[i].gameObject.GetComponent<Image>().sprite == null)
        {
          getItemsArray[i].gameObject.GetComponent<Image>().sprite  = Resources.Load<Sprite>("Images/Items/" + itemName);
          getItemsArray[i].SetActive(true);
          break;
        }
      }
    }

    //<summary>
    //アイテム選択
    //</summary>
    //<param>アイテムオブジェクト</param>
    private void onTapItemImage(GameObject item)
    {
      //選択済みの場合
      if(item.gameObject.GetComponent<Outline>().enabled)
      {
        showItem(item);
        return;
      }

      //未選択の場合
      foreach(var obj in getItemsArray)
      {
        if(item == obj)
        {
          obj.gameObject.GetComponent<Outline>().enabled = true;
          selectItem = obj.gameObject.GetComponent<Image>().sprite.name;
        }
        else
        {
          obj.gameObject.GetComponent<Outline>().enabled = false;
        }
      }
    }

    //<summary>
    //アイテム拡大画面の表示
    //</summary>
    //<param>アイテムオブジェクト</param>
    private void showItem(GameObject item)
    {
      ItemPanel.SetActive(true);
      ItemPanel.transform.Find("ItemImage").gameObject.GetComponent<Image>().sprite = item.gameObject.GetComponent<Image>().sprite;
      CameraManager.Instance.ButtonLeft.SetActive(false);
      CameraManager.Instance.ButtonRight.SetActive(false);
      CameraManager.Instance.ButtonBack.SetActive(true);
      BtnPaper.SetActive(false);
      BtnLight.SetActive(false);
      BtnLightIn.SetActive(false);
      BtnClearPanel1.SetActive(false);


      //大ペーパーの場合に透明ボタン表示
      if(!isPaperChange && ItemPanel.transform.Find("ItemImage").gameObject.GetComponent<Image>().sprite.name == "Paper_big")
        BtnPaper.SetActive(true);
      //懐中電灯の場合に透明ボタン表示
      if(ItemPanel.transform.Find("ItemImage").gameObject.GetComponent<Image>().sprite.name == "Light")
        BtnLight.SetActive(true);
      //クリアパネル1(でぐち)の場合に透明ボタン表示
      if(ItemPanel.transform.Find("ItemImage").gameObject.GetComponent<Image>().sprite.name == "ClearPanel1_deguchi")
        BtnClearPanel1.SetActive(true);
    }

    //<summary>
    //アイテム使用時
    //</summary>
    //<param>アイテム名</param>
    public void useItem()
    {
      for(int i = 0; i < getItemsArray.Length; i++)
      {
        if(getItemsArray[i].gameObject.GetComponent<Image>().sprite.name == selectItem)
        {
          //枠線を非表示に
          getItemsArray[i].gameObject.GetComponent<Outline>().enabled = false;

          //持ち物数がMaの時
          if(i == getItemsArray.Length - 1)
          {
            getItemsArray[i].gameObject.GetComponent<Image>().sprite = null;
            getItemsArray[i].SetActive(false);
            break;
          }

          //それ以降のアイテム画像を左に詰める
          for(int j = i + 1; j < getItemsArray.Length; j++)
          {
            if(getItemsArray[j].gameObject.GetComponent<Image>().sprite == null)
            {
              getItemsArray[j - 1].gameObject.GetComponent<Image>().sprite = null;
              getItemsArray[j - 1].SetActive(false);
              break;
            }
            else if(j == getItemsArray.Length - 1)
            {
              getItemsArray[j - 1].gameObject.GetComponent<Image>().sprite = getItemsArray[j].gameObject.GetComponent<Image>().sprite;
              getItemsArray[j].gameObject.GetComponent<Image>().sprite = null;
              getItemsArray[j].SetActive(false);
              break;
            }
            else
            {
              getItemsArray[j - 1].gameObject.GetComponent<Image>().sprite = getItemsArray[j].gameObject.GetComponent<Image>().sprite;
            }
          }
          break;
        }
      }
      //セーブデータ
      if(selectItem == "Paper_big")
      {
        var re = new Regex("_big");
        SaveLoadSystem.Instance.gameData.getItems = re.Replace(SaveLoadSystem.Instance.gameData.getItems,"",1);
      }
      else
      {
        SaveLoadSystem.Instance.gameData.getItems = SaveLoadSystem.Instance.gameData.getItems.Replace(selectItem + ";","");
      }
      selectItem = "";
      SaveLoadSystem.Instance.Save();
    }

    //<summary>
    //大ペーパーを小ペーパーに替える
    //</summary>
    //<param></param>
    private void ChangePaper()
    {
      AudioManager.Instance.SoundSE("ItemGet");
      ItemPanel.transform.Find("ItemImage").gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Items/Paper_small");
      foreach(var obj in getItemsArray)
      {
        // if(obj.gameObject.GetComponent<Outline>().enabled)
          if(obj.gameObject.GetComponent<Image>().sprite.name == "Paper_big")
        {
          obj.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Items/Paper_small");
          isPaperChange = true;
          selectItem = "Paper_small";
          BtnPaper.SetActive(false);
          break;
        }
      }

      var re = new Regex("_big");
      SaveLoadSystem.Instance.gameData.getItems = re.Replace(SaveLoadSystem.Instance.gameData.getItems,"_small",1);
      SaveLoadSystem.Instance.gameData.isPaperChange = true;
      SaveLoadSystem.Instance.Save();
    }

    //<summary>
    //懐中電灯のカバーを開く
    //</summary>
    //<param></param>
    private void OpenLightCover()
    {
      AudioManager.Instance.SoundSE("OpenLightCover");
      ItemPanel.transform.Find("ItemImage").gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Items/Light_cover");
      BtnLightIn.SetActive(true);
      BtnLight.SetActive(false);
    }

    //<summary>
    //懐中電灯に電池入れる
    //</summary>
    //<param></param>
    private void IntoDenchi()
    {
      if(selectItem == "Denchi")
      {
        AudioManager.Instance.SoundSE("Clear");
        ItemPanel.transform.Find("ItemImage").gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Items/Light_denchi");
        SaveLoadSystem.Instance.gameData.getItems = SaveLoadSystem.Instance.gameData.getItems.Replace("Light","Light_in");
        useItem();
        selectItem = "";
        foreach(var obj in getItemsArray)
        {
          if(obj.gameObject.GetComponent<Image>().sprite.name == "Light")
          {
            obj.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Items/Light_in");
            break;
          }
        }
        BtnLightIn.SetActive(false);
      }
    }

    //<summary>
    //クリアパネル1から「で」をとる
    //</summary>
    //<param></param>
    private void getDecuchi()
    {
      ItemPanel.transform.Find("ItemImage").gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Items/ClearPanel1");
      foreach(var obj in getItemsArray)
      {
        if(obj.gameObject.GetComponent<Image>().sprite.name == "ClearPanel1_deguchi")
        {
          obj.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Items/ClearPanel1");
          break;
        }
      }
      SaveLoadSystem.Instance.gameData.getItems = SaveLoadSystem.Instance.gameData.getItems.Replace(selectItem,"ClearPanel1");
      selectItem = "ClearPanel1";
      getItem("De");
      BtnClearPanel1.SetActive(false);
    }

  }
