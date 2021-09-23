using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    [SerializeField]public int KeyCount = 0;

    bool isCount1 = false;
    void Update()
    {
        if (KeyCount == 1 && !isCount1)
        {
            isCount1 = true;
            StartCoroutine("Key1");
          
        }
    }
    IEnumerator Key1()
    {
        yield return new WaitForSeconds(1f);
        TextController.Instance.DisplayText("鍵が手に入った\r\nあと４つ集める必要があるようだ");
    }
    
}
