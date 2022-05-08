using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance { get; private set; }

    //<summary>現在のカメラの位置名</summary>
    public string CurrentPositionName { get; private set; }

    private bool isStart = false;

    //矢印ボタンオブジェクト
    public GameObject ButtonLeft;
    public GameObject ButtonRight;
    public GameObject ButtonBack;
    //非表示オブジェクトの配列
    public GameObject[] hideObjects;

    //<summary>
    //カメラの位置情報クラス
    //</summary>
    private class CameraPositionInfo
    {
        //<summary>カメラの位置</summary>
        public Vector3 Position { get; set; }
        //<summary>カメラの角度</summary>
        public Vector3 Rotate { get; set; }
        //<summary>ボタンの移動先</summary>
        public MoveNames MoveNames { get; set; }
        //<summary>非表示にするオブジェクト名</summary>
        public string[] hideObjectsName  { get; set; }
    }

    //<summary>
    //ボタンの移動先クラス
    //</summary>
    private class MoveNames
    {
        public string Left { get; set; }
        public string Right { get; set; }
        public string Back { get; set; }
    }

    //<summary>
    //全カメラ位置情報
    //</summary>
    private Dictionary<string, CameraPositionInfo> CameraPositionInfoes = new Dictionary<string, CameraPositionInfo>
    {
        {
            "RoomFlont",//トイレ正面
            new CameraPositionInfo
            {
                Position=new Vector3(0,7.82f,-9.94f),
                Rotate =new Vector3(12.7f,0,0),
                MoveNames=new MoveNames
                {
                    Left="RoomLeft",
                    Right="RoomRight",
                },
                hideObjectsName = new string[]{"Door","tearai"}
            }
        },
        {
            "RoomLeft",//左壁方向
            new CameraPositionInfo
            {
                Position=new Vector3(3.7f,5.7f,-4),
                Rotate =new Vector3(0,-90,0),
                MoveNames=new MoveNames
                {
                    Left="RoomDoor",
                    Right="RoomFlont",
                },
                hideObjectsName = new string[]{"nazo3","tearai"}
            }
        },
        {
            "RoomRight",//右壁方向
            new CameraPositionInfo
            {
                Position=new Vector3(-4.94f,6.62f,-4),
                Rotate =new Vector3(18,90,0),
                MoveNames=new MoveNames
                {
                    Left="RoomFlont",
                    Right="RoomDoor",
                },
                hideObjectsName = new string[]{"calendar","unchi"}
            }
        },
        {
            "RoomDoor",//扉方向
            new CameraPositionInfo
            {
                Position=new Vector3(0,7.3f,2.7f),
                Rotate =new Vector3(5,180,0),
                MoveNames=new MoveNames
                {
                    Left="RoomRight",
                    Right="RoomLeft",
                },
                hideObjectsName = new string[]{"tearai","Benki"}
            }
        },
        {
            "RoomDoor_AfterClear",//扉方向(脱出時)
            new CameraPositionInfo
            {
                Position=new Vector3(0,7.2f,2.3f),
                Rotate =new Vector3(5,180,0),
                MoveNames=new MoveNames
                {
                },
                hideObjectsName = new string[]{"tearai"}
            }
        },
        {
            "Holder_WashPanel",//ホルダーとウォシュレットパネル
            new CameraPositionInfo
            {
                Position=new Vector3(-0.8f,6.8f,-2.5f),
                Rotate =new Vector3(20,50,0),
                MoveNames=new MoveNames
                {
                    Back="RoomFlont",
                }
            }
        },
        {
            "WashPanel",//ウォシュレットパネル
            new CameraPositionInfo
            {
                Position=new Vector3(0.07f,5.2f,1.37f),
                Rotate =new Vector3(16.3f,90,0),
                MoveNames=new MoveNames
                {
                    Back="Holder_WashPanel",
                },
                hideObjectsName = new string[]{"Benki"}
            }
        },
        {
            "WashPanel2",//ウォシュレットパネル
            new CameraPositionInfo
            {
                Position=new Vector3(0.16f,5.5f,1.37f),
                Rotate =new Vector3(16.3f,90,0),
                MoveNames=new MoveNames
                {
                    Back="Holder_WashPanel",
                }
            }
        },
        {
            "Tearai_Upper",//手洗い上部分
            new CameraPositionInfo
            {
                Position=new Vector3(-1.2f,6.9f,-4),
                Rotate =new Vector3(20,90,0),
                MoveNames=new MoveNames
                {
                    Back="RoomRight",
                }
            }
        },
        {
            "Tearai_Under",//手洗い下の棚
            new CameraPositionInfo
            {
                Position=new Vector3(-1.74f,2.1f,-4),
                Rotate =new Vector3(0,90,0),
                MoveNames=new MoveNames
                {
                    Back="RoomRight",
                }
            }
        },
        {
            "Haimendana_Left",//背面棚の左
            new CameraPositionInfo
            {
                Position=new Vector3(-1.5f,8,-1.1f),
                Rotate =new Vector3(0,0,0),
                MoveNames=new MoveNames
                {
                    Back="RoomFlont",
                }
            }
        },
        {
            "Haimendana_Right",//背面棚の右
            new CameraPositionInfo
            {
                Position=new Vector3(0.55f,8,-1.5f),
                Rotate =new Vector3(0,9.6f,0),
                MoveNames=new MoveNames
                {
                    Right = "Haimendana_Right_R",
                    Back="RoomFlont",
                }
            }
        },
        {
            "Haimendana_Right_R",//背面棚の右の右
            new CameraPositionInfo
            {
                Position=new Vector3(-0.7f,8,-0.65f),
                Rotate =new Vector3(0,53,0),
                MoveNames=new MoveNames
                {
                    Left="Haimendana_Right",
                }
            }
        },
        {
            "Blue_Box",//青箱
            new CameraPositionInfo
            {
                Position=new Vector3(-1.51f,7.4f,2),
                Rotate =new Vector3(0,0,0),
                MoveNames=new MoveNames
                {
                    Back="Haimendana_Left",
                }
            }
        },
        {
            "Calendar",//カレンダー
            new CameraPositionInfo
            {
                Position=new Vector3(0.9f,6,-4.7f),
                Rotate =new Vector3(0,-90,0),
                MoveNames=new MoveNames
                {
                    Back="RoomLeft",
                }
            }
        },
        {
            "Unchikun",//うんちくん
            new CameraPositionInfo
            {
                Position=new Vector3(0.04f,6,-3f),
                Rotate =new Vector3(0,-90,0),
                MoveNames=new MoveNames
                {
                    Back="RoomLeft",
                }
            }
        },
        {
            "Gabyo",//画鋲
            new CameraPositionInfo
            {
                Position=new Vector3(-1.9f,6.5f,-2.6f),
                Rotate =new Vector3(0,-105,0),
                MoveNames=new MoveNames
                {
                    Back="Unchikun",
                }
            }
        },
        {
            "Hole",//穴を覗く
            new CameraPositionInfo
            {
                Position=new Vector3(-1.99f,5.7f,-3),
                Rotate =new Vector3(0,-90,0),
                MoveNames=new MoveNames
                {
                    Back="Unchikun",
                }
            }
        },
        {
            "Tunk",//トイレのタンク
            new CameraPositionInfo
            {
                Position=new Vector3(2.92f,7.56f,1.27f),
                Rotate =new Vector3(29,-50,0),
                MoveNames=new MoveNames
                {
                    Back="RoomFlont",
                }
            }
        },
        {
            "Benki",//便器の中
            new CameraPositionInfo
            {
                Position=new Vector3(0,6.8f,-0.5f),
                Rotate =new Vector3(63,0,0),
                MoveNames=new MoveNames
                {
                    Back="RoomFlont",
                }
            }
        },
        {
            "Door_ClearPanel",//扉のクリアパネル
            new CameraPositionInfo
            {
                Position=new Vector3(-0.02f,6.5f,-4.6f),
                Rotate =new Vector3(0,180,0),
                MoveNames=new MoveNames
                {
                    Back="RoomDoor",
                }
            }
        },
        {
            "Door_Key",//扉のキー
            new CameraPositionInfo
            {
                Position=new Vector3(1.5f,4.9f,-6.8f),
                Rotate =new Vector3(0,180,0),
                MoveNames=new MoveNames
                {
                    Back="RoomDoor",
                }
            }
        },
    };

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        ChangeCameraPosition("RoomFlont");

        ButtonLeft.GetComponent<Button>().onClick.AddListener(() =>
        {
            AudioManager.Instance.SoundSE("TapUIBtn");
            ChangeCameraPosition(CameraPositionInfoes[CurrentPositionName].MoveNames.Left);
        });
        ButtonRight.GetComponent<Button>().onClick.AddListener(() =>
        {
            AudioManager.Instance.SoundSE("TapUIBtn");
            ChangeCameraPosition(CameraPositionInfoes[CurrentPositionName].MoveNames.Right);
        });
        ButtonBack.GetComponent<Button>().onClick.AddListener(() =>
        {
            AudioManager.Instance.SoundSE("TapUIBtn");
            ChangeCameraPosition(CameraPositionInfoes[CurrentPositionName].MoveNames.Back);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    //<summary>
    //カメラ移動
    //</summary>
    //<param>位置名</param>
    public void ChangeCameraPosition(string positionName)
    {
        if(isStart)
        {
          //アイテム拡大画面表示時
          if(ItemManager.Instance.ItemPanel.activeSelf)
          {
            ItemManager.Instance.ItemPanel.SetActive(false);
            positionName = CurrentPositionName;
          }
        }
        isStart = true;

        if (positionName == null) return;

        CurrentPositionName = positionName;

        GetComponent<Camera>().transform.position = CameraPositionInfoes[CurrentPositionName].Position;
        GetComponent<Camera>().transform.rotation = Quaternion.Euler(CameraPositionInfoes[CurrentPositionName].Rotate);

        //iPad対策
        if(positionName == "RoomRight" && Screen.width > 1300)
        {
          GetComponent<Camera>().transform.position = new Vector3(-4.17f,6.47f,-4);
          GetComponent<Camera>().transform.rotation = Quaternion.Euler(new Vector3(18,90,0));
        }
        if(positionName == "RoomDoor" && Screen.width > 1300)
        {
          GetComponent<Camera>().transform.position = new Vector3(0,7.14f,0.87f);
          GetComponent<Camera>().transform.rotation = Quaternion.Euler(new Vector3(5,-180,0));
        }


        //ボタン表示・非表示
        UpdateButtonActive();
        //特定オブジェクトを非表示
        UpdateObjectActive();
    }

    //<summary>
    //ボタン表示非表示の切替
    //</summary>
    private void UpdateButtonActive()
    {
        //左ボタンの表示非表示を切替
        if (CameraPositionInfoes[CurrentPositionName].MoveNames.Left == null)
            ButtonLeft.SetActive(false);
        else ButtonLeft.SetActive(true);
        //右ボタンの表示非表示を切替
        if (CameraPositionInfoes[CurrentPositionName].MoveNames.Right == null)
            ButtonRight.SetActive(false);
        else ButtonRight.SetActive(true);
        //バックボタンの表示非表示を切替
        if (CameraPositionInfoes[CurrentPositionName].MoveNames.Back == null)
            ButtonBack.SetActive(false);
        else ButtonBack.SetActive(true);
    }

    //<summary>
    //特定オブジェクトを非表示
    //</summary>
    private void UpdateObjectActive()
    {
      //既に非表示のオブジェクトを表示する
      foreach (GameObject obj in hideObjects )
      {
        obj.SetActive(true);
      }
      hideObjects = new GameObject[0];

      if (CameraPositionInfoes[CurrentPositionName].hideObjectsName == null)
        return;
      //新たな方向でのオブジェクトを非表示にする
      foreach(string objName in CameraPositionInfoes[CurrentPositionName].hideObjectsName)
      {
        Array.Resize(ref hideObjects, hideObjects.Length + 1);
        hideObjects[hideObjects.Length  - 1] = GameObject.Find(objName);
        GameObject.Find(objName).SetActive(false);
      }
    }
}
