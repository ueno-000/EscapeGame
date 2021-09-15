using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton1 : MonoBehaviour
{
    [SerializeField] GameObject m_GameOverPanel;


    public void RetryScene()
    {
        Debug.Log("1FHouseにシーン切替");
        SceneManager.LoadScene("1F-1");
    }

    public void OnPanel()
    {
        m_GameOverPanel.SetActive(true);
    }
}