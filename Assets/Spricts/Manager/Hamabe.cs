using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hamabe : MonoBehaviour
{
    /// <summary>浜辺Image</summary>
    [SerializeField] Image m_hamabeImage = default;
    /// <summary>フェード用 Image</summary>
    [SerializeField] Image m_fadeImage = default;
    /// <summary>説明Image１</summary>
    [SerializeField] GameObject m_Guide1 = default;
    /// <summary>説明Image２</summary>
    [SerializeField] GameObject m_Guide2 = default;
    /// <summary>プレイヤー顔１</summary>
    [SerializeField] Image m_faceImage1 = default;
    /// <summary>プレイヤー顔２</summary>
    [SerializeField] Image m_faceImage2 = default;
    //フェードイン処理の開始、完了を管理するフラグ
    private bool isFadeIn = false;
    /// <summary>フェードアウト完了までにかかる時間（秒）/summary>
    float m_fadeTime = 5f;
    float m_timer = 0f;
    void Start()
    {
        StartCoroutine("GirlComment");
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
        isFadeIn = true;

    }

    IEnumerator StartFadeOut()
    {
        m_fadeImage.gameObject.SetActive(true); // 画像をアクティブにする
        while (true)
        {
            m_timer += Time.deltaTime;
            Color c = m_fadeImage.color;
            c.a = m_timer / m_fadeTime;
            m_fadeImage.color = c;
            yield return new WaitForEndOfFrame();   // Update() の処理が終わるまで待
            if (m_timer > m_fadeTime)
            {
                OnFadeOutFinished();
                break;
            }
        }

    }
    void OnFadeOutFinished()
    {
        Debug.Log("Fade 完了");
        isFadeIn =  false;
    }

    IEnumerator GirlComment()
    {
        yield return new WaitForSeconds(3f);
        TextController.Instance.DisplayText("、、、、、、");
        yield return new WaitForSeconds(3f);
        TextController.Instance.DisplayText("長い間寝ていた気がする");
        yield return new WaitForSeconds(5f);
        yield return StartCoroutine("StartFadeIn");
        yield return new WaitForSeconds(3f);
        m_faceImage1.gameObject.SetActive(false); // 画像を非アクティブにする
        m_faceImage2.gameObject.SetActive(true); // 画像をアクティブにする
        TextController.Instance.DisplayText("ここは、、、どこ？");
        yield return new WaitForSeconds(5f);
        TextController.Instance.DisplayText("海に浜辺");
        yield return new WaitForSeconds(5f);
        TextController.Instance.DisplayText("どこかの島だろうか？");
        yield return new WaitForSeconds(5f);
        TextController.Instance.DisplayText("とりあえずあたりを探索してみよう");
        yield return new WaitForSeconds(3f);
        TextController.Instance.DisplayText("家に帰る手がかりを見つけなきゃ");
        yield return new WaitForSeconds(3f);
        m_hamabeImage.gameObject.SetActive(false); // 画像を非アクティブにする
        StartCoroutine("GirlComment2");
    }
    IEnumerator GirlComment2() 
    {
        yield return new WaitForSeconds(3f);
        m_Guide1.gameObject.SetActive(true); // 画像をアクティブにする
        yield return new WaitForSeconds(5f);
        m_Guide2.gameObject.SetActive(true); // 画像をアクティブにする
        yield return new WaitForSeconds(3f);
        TextController.Instance.DisplayText("あっちの方に家が見える");
        yield return new WaitForSeconds(3f);
        TextController.Instance.DisplayText("いってみよう");
        yield return new WaitForSeconds(3f);
        m_Guide1.gameObject.SetActive(false); // 画像を非アクティブにする
        m_Guide2.gameObject.SetActive(false); // 画像を非アクティブにする
        yield return StartCoroutine("StartFadeOut");
        SceneManager.LoadScene("1F-1");
    }

}
