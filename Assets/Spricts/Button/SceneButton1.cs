using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton1 : MonoBehaviour
{
    [SerializeField] GameObject m_GameOverPanel;


    public void OnClickRetryScene()
    {
        Debug.Log("1Fにシーン切替");
        SceneManager.LoadScene("1F-1");
    }
    public void OnClickTitleScene()
    {
        Debug.Log("Titleにシーン切替");
        SceneManager.LoadScene("Title");
    }
    public void OnClickHouseScene()
    {
        Debug.Log("1FHouseにシーン切替");
        SceneManager.LoadScene("1F-House");
    }

    public void OnPanel()
    {
        m_GameOverPanel.SetActive(true);
        TextController.Instance.DisplayText("家の扉が開かず、力尽きてしまった…");
    }
    public void GirlComment()
    {
        TextController.Instance.DisplayText("他の家を見た方がいいかもな");
    }
    public void GuideComment()
    {
        TextController.Instance.DisplayText("案内板だ。ふむふむ…\r\n灯台を目指すか");
    }
}