using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]public int ItemCount = 0;
    /// <summary>フェード用 Image</summary>
    [SerializeField] Image m_fadeImage = default;
    /// <summary>フェードアウト完了までにかかる時間（秒）/summary>
    float m_fadeTime = 20f;
    float m_timer = 0f;
    /// <summary>実行中のコルーチン（実行していない時は null）</summary>
    Coroutine m_coroutine = null;

    void Update()
    {
        if(ItemCount == 13)
        {
            Debug.Log("1FHouseにシーン切替");
            StartCoroutine("FinTansaku");
        }
    }
    IEnumerator FinTansaku()
    {
        yield return new WaitForSeconds(3f);
        TextController.Instance.DisplayText("もう調べるところもないし、朝になるまで休もう");
        StartCoroutine("StartWorkingRoutine");
    }
  
    IEnumerator StartWorkingRoutine()
    {
        while (true)
        {
            m_timer += Time.deltaTime;
            Color c = m_fadeImage.color;
            c.a = m_timer / m_fadeTime;
            m_fadeImage.color = c;
            yield return new WaitForEndOfFrame();   // Update() の処理が終わるまで待
            if (m_timer > m_fadeTime)
            {
                OnFadeFinished();
                break;
            }
        }
        
    }
    void OnFadeFinished()
    {
        Debug.Log("Fade 完了");
        SceneManager.LoadScene("2F");
    }

}
