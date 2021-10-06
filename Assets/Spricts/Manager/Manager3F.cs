using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager3F : MonoBehaviour
{
    /// <summary>フェード用 Image</summary>
    [SerializeField] Image m_fadeImage = default;
    /// <summary>ホワイトフェード用 Image</summary>
    [SerializeField] Image m_whiteImage = default;
    //フェードイン処理の開始、完了を管理するフラグ
    private bool isFadeIn = false;
    /// <summary>フェードアウト完了までにかかる時間（秒）/summary>
    float m_fadeTime = 5f;
    float m_timer = 0f;

    public AudioSource m_soundRain;
    public AudioSource m_soundKaze;
    public AudioSource m_soundKey;
    public AudioSource m_soundDoor;


    void Start()
    {
        StartCoroutine("GirlComment");
        m_soundRain = GetComponent<AudioSource>();
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
        m_whiteImage.gameObject.SetActive(true); // 画像をアクティブにする
        while (true)
        {
            m_timer += Time.deltaTime;
            Color c = m_whiteImage.color;
            c.a = m_timer / m_fadeTime;
            m_whiteImage.color = c;
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
        isFadeIn = false;
    }

    IEnumerator GirlComment()
    {
        yield return new WaitForSeconds(2f);
        TextController.Instance.DisplayText("灯台が見えてきた");
        yield return new WaitForSeconds(3f);
        yield return StartCoroutine("VolumeDown");
        yield return StartCoroutine("StartFadeIn");
        m_soundKaze.PlayOneShot(m_soundKaze.clip);
        yield return new WaitForSeconds(3f);
        TextController.Instance.DisplayText("きっと助けを呼べるものがあるはず");
        yield return new WaitForSeconds(5f);
        m_soundKey.PlayOneShot(m_soundKey.clip);
        TextController.Instance.DisplayText("ーー灯台の扉を開けたーー");
        yield return new WaitForSeconds(2f);
        m_soundKey.PlayOneShot(m_soundDoor.clip);
        yield return new WaitForSeconds(5f);
        yield return StartCoroutine("StartFadeOut");
        SceneManager.LoadScene("TrueClearScene");
    }
    IEnumerator VolumeDown()
    {
        while (m_soundRain.volume > 0)
        {
            m_soundRain.volume -= 0.01f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}