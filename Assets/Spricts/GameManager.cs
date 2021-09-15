using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]public int ItemCount = 0;

    void Update()
    {
        if(ItemCount == 13)
        {
            Debug.Log("1FHouseにシーン切替");
            SceneManager.LoadScene("2F");
        }
    }

}
