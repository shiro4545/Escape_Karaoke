using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartResetSystem : MonoBehaviour
{
  // //アイテムオブジェクト
  // public GameObject itemPaper1;
  // public GameObject itemPaper2;
  // public GameObject itemKaicyudento;
  // public GameObject itemPenchi;
  // public GameObject itemDenchi;
  // public GameObject itemBottle;
  // public GameObject itemTotte;
  //
  // //ゲーム内オブジェクト
  // public GameObject paperHolder;
  // public TapGetItem_CP3 itemCP3;
  // public putPaper paper_left;
  // public putPaper paper_right;
  // public TapPaper paper_center1;
  // public TapPaper paper_center2;
  // public Judge_paper Judge_paper;
  // public Judge_BlueBox BlueBox;
  // public Gabyo Gabyo;
  // public Judge_nazo4 Judge_nazo4;
  // public tunk_cover TunkCover;
  // public totte totte;
  // public TapItemGet_CP1 itemCP1;
  // public de_button DeButton;
  // public hole Hole;
  // public door_cp DoorCP;
  //
  // private GameData gameData;
  //
  // //<summary>
  // //タイトル画面の「はじめから」の時
  // //<summary>
  // public void GameStart()
  // {
  //   SaveLoadSystem.Instance.GameStart();
  // }
  //
  // //<summary>
  // //タイトル画面の「続きから」の時
  // //<summary>
  // public void GameContinue()
  // {
  //   SaveLoadSystem.Instance.Load();
  //   gameData = SaveLoadSystem.Instance.gameData;
  //
  //   //ウォッシュパネル1回目のクリア有無
  //   if(gameData.isClearWashPanel1)
  //     WashPanelController.Instance.firstIsClear = true;
  //
  //   //背面棚右の状態
  //   WashPanelController.Instance.HaimendanaRight.openStatus = gameData.statusHaimendanRight;
  //   switch(gameData.statusHaimendanRight )
  //   {
  //     case 1://
  //       WashPanelController.Instance.HaimendanaRight.gameObject.transform.Rotate(new Vector3(0,0,-88));
  //       break;
  //     case 2://
  //       WashPanelController.Instance.HaimendanaRight.gameObject.transform.Rotate(new Vector3(0,0,-5));
  //       break;
  //     case 3://
  //       WashPanelController.Instance.HaimendanaRight.gameObject.transform.Rotate(new Vector3(0,0,-33));
  //       break;
  //     default:
  //       break;
  //   }
  //   //背面棚左の状態
  //   WashPanelController.Instance.HaimendanaLeft.openStatus = gameData.statusHaimendanLeft;
  //   switch(gameData.statusHaimendanLeft )
  //   {
  //     case 1://
  //       WashPanelController.Instance.HaimendanaLeft.gameObject.transform.Rotate(new Vector3(0,0,88));
  //       break;
  //     case 2://
  //       WashPanelController.Instance.HaimendanaLeft.gameObject.transform.Rotate(new Vector3(0,0,5));
  //       break;
  //     case 3://
  //       WashPanelController.Instance.HaimendanaLeft.gameObject.transform.Rotate(new Vector3(0,0,33));
  //       break;
  //     default:
  //       break;
  //   }
  //   //便座の状態
  //   if(gameData.isOpenBenza)
  //   {
  //     WashPanelController.Instance.Benza.gameObject.transform.Rotate(new Vector3(-79,0,0));
  //     WashPanelController.Instance.BenzaIsOpen = true;
  //     WashPanelController.Instance.BenkiCollider.SetActive(true);
  //   }
  //   //便座カバー
  //   if(gameData.isOpenBenzaCover)
  //   {
  //     WashPanelController.Instance.Cover.gameObject.transform.Rotate(new Vector3(-90,0,0));
  //     WashPanelController.Instance.CoverIsOpen = true;
  //   }
  //
  //   //ペーパーホルダーのペーパー取得有無
  //   if(gameData.isGetPaper1)
  //   {
  //     itemPaper1.SetActive(false);
  //     paperHolder.gameObject.transform.Rotate(new Vector3(-30,0,0));
  //     WashPanelController.Instance.firstIsClear = true;
  //   }
  //   //ペーパー大→小の有無
  //   if(gameData.isPaperChange)
  //     ItemManager.Instance.isPaperChange = true;
  //
  //   //クリアパネル3の取得有無
  //   if(gameData.isGetCP3)
  //   {
  //     itemCP3.gameObject.SetActive(false);
  //     itemCP3.RPaper.gameObject.SetActive(true);
  //   }
  //
  //   //背面棚の左ペーパー状態
  //   paper_left.paperStatus =  gameData.statusPaperLeft;
  //   switch(gameData.statusPaperLeft)
  //   {
  //     case 1:
  //       paper_left.paperBig.SetActive(true);
  //       break;
  //     case 2:
  //       paper_left.paperSmall.SetActive(true);
  //       break;
  //     default:
  //       break;
  //   }
  //
  //   //背面棚の右ペーパー状態
  //   paper_right.paperStatus =  gameData.statusPaperRight;
  //   switch(gameData.statusPaperRight)
  //   {
  //     case 1:
  //       paper_right.paperBig.SetActive(true);
  //       break;
  //     case 2:
  //       paper_right.paperSmall.SetActive(true);
  //       break;
  //     default:
  //       break;
  //   }
  //
  //       //背面棚右の中央ペーパー1
  //   paper_center1.paperStatus = gameData.statusPaperCenter1;
  //   if (gameData.statusPaperCenter1 == 1)
  //     paper_center1.gameObject.transform.gameObject.transform.Rotate(new Vector3(-90,0,0));
  //   //背面棚右の中央ペーパー2
  //   paper_center2.paperStatus = gameData.statusPaperCenter2;
  //   if(gameData.statusPaperCenter2 == 1)
  //     paper_center2.gameObject.transform.gameObject.transform.Rotate(new Vector3(-90,0,0));
  //
  //   //背面棚右のペーパー置きのクリア有無
  //   if(gameData.isClearPaper)
  //     Judge_paper.isClear = true;
  //
  //   //背面棚左の懐中電灯取得有無
  //   if(gameData.isGetKaicyudento)
  //     itemKaicyudento.SetActive(false);
  //
  //   //青箱のうんちくん謎のクリア有無
  //   if(gameData.isClearBlueBox)
  //   {
  //     BlueBox.isClear = true;
  //     for(int i = 0;i < BlueBox.TapChanges.Length;i++)
  //     {
  //       BlueBox.TapChanges[i].enabled = false;
  //       BlueBox.TapChanges[i].gameObject.GetComponent<BoxCollider>().enabled = false;
  //       BlueBox.TapChanges[i].Objects[0].SetActive(false);
  //       BlueBox.TapChanges[i].Objects[BlueBox.AnswerIndexes[i]].SetActive(true);
  //     }
  //     BlueBox.DeBtnCollider.SetActive(true);
  //     BlueBox.under.gameObject.transform.Translate(new Vector3(-0.7f,0,0));
  //   }
  //
  //   //ペンチの取得有無
  //   if(gameData.isGetPenchi)
  //     itemPenchi.SetActive(false);
  //
  //   //電池の取得有無
  //   if(gameData.isGetDenchi)
  //     itemDenchi.SetActive(false);
  //
  //   //画鋲をペンチで抜いたか
  //   if(gameData.isPullGabyo)
  //   {
  //     Gabyo.isPullGabyo = true;
  //     Gabyo.GabyoCollider.SetActive(false);
  //     Gabyo.HoleCollider.SetActive(true);
  //     Gabyo.gameObject.transform.Translate(new Vector3(0,0,-2));
  //   }
  //
  //   //手洗い下の謎4クリア有無
  //   if(gameData.isClearNazo4)
  //   {
  //     Judge_nazo4.isClear = true;
  //     foreach(var TapChange in Judge_nazo4.TapChanges)
  //     {
  //       TapChange.enabled = false;
  //       TapChange.gameObject.GetComponent<BoxCollider>().enabled = false;
  //     }
  //     Judge_nazo4.gameObject.transform.Rotate(new Vector3(0,0,180));
  //   }
  //
  //   //手洗い下のペーパー取得有無
  //   if(gameData.isGetPaper2)
  //     itemPaper2.SetActive(false);
  //
  //   //手洗い下のPET取得有無
  //   if(gameData.isGetBottle)
  //     itemBottle.SetActive(false);
  //
  //   //手洗い上の謎3クリア有無
  //   if(gameData.isClearNazo3)
  //   {
  //     Judge_nazo3.Instance.isClear = true;
  //   }
  //
  //   //タンクカバーの開有無
  //   if(gameData.isOpenTunkCover)
  //   {
  //     TunkCover.isCoverOpen = true;
  //     TunkCover.TunkCover.SetActive(false);
  //   }
  //
  //   //クリアパネル2の取得有無
  //   if(gameData.isGetCP2)
  //     TunkCover.isGetClearPanel = true;
  //
  //   //タンク内の状態
  //   TunkCover.tunkStatus = gameData.statusTunk;
  //   switch(gameData.statusTunk)
  //   {
  //     case 1:
  //       TunkCover.Water1.SetActive(true);
  //       break;
  //     case 2:
  //       TunkCover.Water2.SetActive(true);
  //       if(!TunkCover.isGetClearPanel)
  //         TunkCover.ClearPanel2_2.SetActive(true);
  //         break;
  //     case 3:
  //       TunkCover.Water3.SetActive(true);
  //       if(!TunkCover.isGetClearPanel)
  //       {
  //         TunkCover.ClearPanel2_3.SetActive(true);
  //         TunkCover.TunkCoverCollider.SetActive(false);
  //       }
  //       break;
  //     default:
  //       break;
  //   }
  //
  //   //取っ手の装着有無
  //   if(gameData.isSetTotte)
  //   {
  //     totte.Totte.SetActive(true);
  //     totte.isSetTotte = true;
  //   }
  //
  //   //水流しの謎クリア有無
  //   if(gameData.isClearFlow)
  //   {
  //     totte.isClear = true;
  //     totte.Water.SetActive(false);
  //     foreach(var obj in totte.NumArray)
  //     {
  //       obj.SetActive(true);
  //     }
  //   }
  //
  //   //ウォシュレットパネル2回目の謎クリア有無
  //   if(gameData.isClearWashPanel2)
  //   {
  //     WashPanelController.Instance.SecondIsClear = true;
  //     WashPanelController.Instance.gameObject.SetActive(false);
  //     WashPanelController.Instance.WashPanel2.gameObject.SetActive(true);
  //     WashPanelController.Instance.ClearPanel1.gameObject.SetActive(true);
  //     WashPanelController.Instance.WashPanelCollider1.SetActive(false);
  //   }
  //
  //   //クリアパネル1(でぐち)の取得有無
  //   if(gameData.isGetCP1_deguchi)
  //   {
  //     itemCP1.gameObject.SetActive(false);
  //     itemCP1.WashPanelCollider2.SetActive(true);
  //   }
  //
  //   //「でんち」の謎クリア有無
  //   if(gameData.isClearDe)
  //   {
  //     DeButton.isClear = true;
  //     DeButton.LBtn.SetActive(false);
  //     DeButton.DeBtn.SetActive(true);
  //     DeButton.gameObject.SetActive(false);
  //     DeButton.BlueBoxUpper.gameObject.transform.Translate(new Vector3(-0.7f,0,0));
  //   }
  //
  //   //懐中電灯で穴を照らしたか
  //   if(gameData.isClearLight)
  //   {
  //     Hole.isClear = true;
  //     Hole.gameObject.SetActive(false);
  //   }
  //
  //   //取っ手の取得有無
  //   if(gameData.isGetTotte)
  //     itemTotte.SetActive(false);
  //
  //   //扉のクリアパネルのセット状態
  //   if(gameData.statusCPIndex0 != 0)
  //   {
  //       DoorCP.objArray0[gameData.statusCPIndex0 - 1].SetActive(true);
  //       DoorCP.CPArray[0] = gameData.statusCPIndex0;
  //   }
  //   if(gameData.statusCPIndex1 != 0)
  //   {
  //       DoorCP.objArray1[gameData.statusCPIndex1 - 1].SetActive(true);
  //       DoorCP.CPArray[1] = gameData.statusCPIndex1;
  //   }
  //   if(gameData.statusCPIndex2 != 0)
  //   {
  //       DoorCP.objArray2[gameData.statusCPIndex2 - 1].SetActive(true);
  //       DoorCP.CPArray[2] = gameData.statusCPIndex2;
  //   }
  //
  //   //扉のクリアパネルのセットクリア有無
  //   if(gameData.isClearCPSet)
  //     DoorCP.isClear = true;
  //
  //
  //
  //   //保有アイテム
  //   if(gameData.getItems == "")
  //     return;
  //   string[] arr = gameData.getItems.Split(';');
  //   foreach(var item in arr)
  //   {
  //     if(item != "")
  //       ItemManager.Instance.loadItem(item);
  //   }
  // }
  //
  //
  //   //<summary>
  //   //ゲーム進捗の算出
  //   //<summary>
  //   public int checkProgress()
  //   {
  //     int progress = 0;
  //
  //     if(!WashPanelController.Instance.firstIsClear)
  //       //ウォッシュパネル1回目のヒント
  //       progress = 0;
  //     else if (!Judge_nazo4.isClear)
  //       //手洗い下の星の謎
  //       progress = 1;
  //     else if (!Judge_paper.isClear)
  //       //背面棚右のペーパー置き謎
  //       progress = 2;
  //     else if(!BlueBox.isClear)
  //       //背面棚左の「ペンチ」謎
  //       progress = 3;
  //     else if(!Gabyo.isPullGabyo)
  //       //画鋲をとる
  //       progress = 4;
  //     else if(!WashPanelController.Instance.SecondIsClear)
  //       //ウォシュパネル2回目の謎(天気記号)
  //       progress = 5;
  //     else if(!DeButton.isClear)
  //       //「でんち」の謎
  //       progress = 6;
  //     else if(!Hole.isClear)
  //       //懐中電灯で穴を照らす
  //       progress = 7;
  //     else if(!Judge_nazo3.Instance.isClear)
  //       //手洗い上の水を出すための謎
  //       progress = 8;
  //     else if(!TunkCover.isGetClearPanel)
  //       //タンクに水を入れてクリアパネル2を取得
  //       progress = 9;
  //     else if(!DoorCP.isClear)
  //       //クリアパネル3枚の置き方
  //       progress = 10;
  //     else
  //       //トイレタンクの水の流し方
  //       progress = 11;
  //
  //     return progress;
  //   }

}
