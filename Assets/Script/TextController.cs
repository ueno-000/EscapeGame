using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public static TextController Instance { get; private set; }
    [SerializeField] private GameObject _textPrefabObject;
    [SerializeField] private string _text;
    public Text text_Object;

    private void Awake()
    {
        Instance = this;
    }
    
    public void DisplayText(string inputText,bool isFade)
    {
        _textPrefabObject.SetActive(true);

        if (inputText.Length > 10)
        {
            Debug.Log(inputText);
            text_Object.text = inputText.Substring(0,10) + "\r" + inputText.Substring(10, inputText.Length - 10);
        }
        else
        {
            text_Object.text = inputText;
        }

        if (isFade)
            StartCoroutine("FadePanel");
    }

    IEnumerator FadePanel()
    {
        yield return new WaitForSeconds(4f);
        _textPrefabObject.SetActive(false);
    }
}
