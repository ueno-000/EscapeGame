using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class House2FManager : MonoBehaviour
{
    /// <summary>フェード用 Image</summary>
    [SerializeField] Image m_fadeImage = default;
    /// <summary>フェードアウト完了までにかかる時間（秒）/summary>
    float m_fadeTime = 5f;
    float m_timer = 0f;
    /// <summary>SE</summary>
    public AudioSource m_sound;
    //フェードイン処理の開始、完了を管理するフラグ
    private bool isFadeIn = false;
    void Start()
    {
        m_sound = GetComponent<AudioSource>();
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
        isFadeIn = false;
    }

    IEnumerator GirlComment()
    {
        yield return new WaitForSeconds(3f);
        TextController.Instance.DisplayText("朝になったようだ。家を出よう。", true);
        m_sound.PlayOneShot(m_sound.clip);
        yield return new WaitForSeconds(3f);
        yield return StartCoroutine("StartFadeIn");
        yield return new WaitForSeconds(3f);
        TextController.Instance.DisplayText("雨が降っている。",false);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;
        TextController.Instance.DisplayText("朝だというのに暗い、、、", false);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;
        TextController.Instance.DisplayText("懐中電灯を持ってきて良かった。", false);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;
        TextController.Instance.DisplayText("目的地は灯台だ、先を急ごう", false);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;
        yield return StartCoroutine("StartFadeOut");
        SceneManager.LoadScene("2F");
    }
}
