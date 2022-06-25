using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton1 : MonoBehaviour
{
    [SerializeField] GameObject m_GameOverPanel;
    public AudioSource m_sound1;
    public AudioSource m_sound2;
    public AudioSource m_sound3;


    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        //AudioSource[] audioSources = new AudioSource[3];
        //m_sound1 = audioSources[0];
        //m_sound2 = audioSources[1];
        //m_sound3 = audioSources[2];
    }
    public void OnClickRetryScene()
    {
        Debug.Log("1F-1にシーン切替");
        SceneManager.LoadScene("1F-1");
        m_sound1.PlayOneShot(m_sound1.clip);
    }

    public void OnClickTitleScene()
    {
        Debug.Log("Titleにシーン切替");
        SceneManager.LoadScene("Title");
        m_sound1.PlayOneShot(m_sound1.clip);
    }
    public void OnClickGameStart()
    {
        Debug.Log("浜辺にシーン切替");
        SceneManager.LoadScene("1F-Hamabe");
        m_sound1.PlayOneShot(m_sound1.clip);
    }
    public void OnClickHouseScene()
    {
        Debug.Log("1FHouseにシーン切替");
        m_sound2.PlayOneShot(m_sound2.clip);
        StartCoroutine("HouseScene");
    }
    public void OnClick2FScene()
    {
        Debug.Log("2Fにシーン切替");
        m_sound2.PlayOneShot(m_sound2.clip);
        SceneManager.LoadScene("2F");
    }

        IEnumerator HouseScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("1F-House");
    }
    public void OnPanel()
    {
        m_GameOverPanel.SetActive(true);
        TextController.Instance.DisplayText("家の扉が開かず、力尽きてしまった…", true);
        m_sound3.PlayOneShot(m_sound3.clip);
    }
    public void GirlComment()
    {
        TextController.Instance.DisplayText("他の家を見た方がいいかもな", true);
        m_sound2.PlayOneShot(m_sound2.clip);
    }
    public void GuideComment()
    {
        TextController.Instance.DisplayText("案内板だ。ふむふむ…\r\n灯台を目指すか", true);
        m_sound2.PlayOneShot(m_sound2.clip);
    }

   

}