using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// カニが倒された回数を表示する処理
/// </summary>
public class KaniText : MonoBehaviour
{
    /// <summary>カニが倒された回数を表示するテキスト </summary>
    Text CountText;
    /// <summary>カニが倒された回数のカウント</summary>
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        CountText = GameObject.Find("CountText").GetComponent<Text>();
    }

    void Update()
    {
        CountText.text = count.ToString() + "/20";
    }
}
