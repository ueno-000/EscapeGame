using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class KeyController : MonoBehaviour
{
    [SerializeField]public int KeyCount = 0;
    ///// <summary>KeyKaniを生成する間隔の秒数</summary>
    //[SerializeField] int m_Interval = 0;
    [SerializeField] GameObject m_KeyPrefub;
    bool isCount1 = false;
    bool isCount3 = false;
    bool isCount5 = false;

    //void Start()
    //{
    //    StartCoroutine("KeyKaniCount");
    //}
    //IEnumerator KeyKaniCount()
    //{
    //    for (int count = 0; count < 20; count++)
    //    {
    //        //秒おきに生成する
    //        yield return new WaitForSeconds(m_interval);
    //        //カニをインスタンス化する(生成する)
    //        GameObject KeyKani = Instantiate(m_prefab);
    //        //生成した敵の位置をランダムに設定する
    //        KeyKani.transform.position = GetRandomPosition();
    //    }
    //}

    void Update()
    {
        if (KeyCount == 1 && !isCount1)
        {
            isCount1 = true;
            StartCoroutine("Key1");
        }

        if (KeyCount == 3 && !isCount3)
        {
            isCount3 = true;
            StartCoroutine("Key3");
        }

        if (KeyCount == 5 && !isCount5) 
        {
            isCount5 = true;
            StartCoroutine("Key5");
        }
    }

    IEnumerator Key1()
    {
        yield return new WaitForSeconds(1f);
        TextController.Instance.DisplayText("！、、灯台の鍵が手に入った\r\n全部で5つ必要みたいだ");
    }
    IEnumerator Key3()
    {
        yield return new WaitForSeconds(1f);
        TextController.Instance.DisplayText("残り2つ必要だ");
    }
    IEnumerator Key5()
    {
        yield return new WaitForSeconds(1f);
        TextController.Instance.DisplayText("全ての灯台の鍵が手に入った！");
        TextController.Instance.DisplayText("灯台へ向かおう");
        StartCoroutine("Scene3F");
    }
  
    IEnumerator Scene3F()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("3Fにシーン切替");
        SceneManager.LoadScene("3F");

    }
    //private Vector3 GetRandomPosition()
    //{
    //    //それぞれの座標をランダムに生成する
    //    float x = Random.Range(-40, -40);

    //    //Vector3型のPositionを返す
    //    return new Vector3(x, 5);
    //}
}
