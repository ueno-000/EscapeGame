using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton1 : MonoBehaviour
{

    public void Scene1FHouse()
    {
        Debug.Log("1FHouseにシーン切替");
        //SceneManager.LoadScene("");
    }
    public void Scene1FGameCver()
    {
        Debug.Log("GameOverにシーン切替");
        //SceneManager.LoadScene("game");
    }

}