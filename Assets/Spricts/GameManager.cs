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
    //フェードイン処理の開始、完了を管理するフラグ
    private bool isFadeIn = true;
    /// <summary>フェードアウト完了までにかかる時間（秒）/summary>
    float m_fadeTime = 20f;
    float m_timer = 0f;
    /// <summary>実行中のコルーチン（実行していない時は null）</summary>
    //Coroutine m_coroutine = null;

    void Start()
    {
        StartCoroutine("StartFadeIn");
    }


    IEnumerator StartFadeIn()
    {
        m_fadeImage.gameObject.SetActive(true); // 画像をアクティブにする

        Color c = m_fadeImage.color;
        c.a = 1f;
        m_fadeImage.color = c; // 画像の不透明度を1にする

        while (true)
        {
            yield return new WaitForSeconds(0.1f); 
            c.a -= 0.02f;
            m_fadeImage.color = c; // 画像の不透明度を下げる
            if (c.a <= 0f) // 不透明度が0以下のとき
            {
                c.a = 0f;
                m_fadeImage.color = c; // 不透明度を0
                OnFadeInFinished();
                break; // 繰り返し終了
            }
        }
        m_fadeImage.gameObject.SetActive(false); // 画像を非アクティブにする
    }
    void OnFadeInFinished()
    {
        Debug.Log("Fade 完了");
        StartCoroutine("StartTansaku");

    }
    IEnumerator StartTansaku()
    {
        yield return new WaitForSeconds(1f);
        TextController.Instance.DisplayText("家の中に入れた\r\nもう外は暗いし、朝になるまでこの家に居よう");
    }
 
    void Update()
    {
        if (ItemCount == 13)
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
