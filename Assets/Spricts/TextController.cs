using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public static TextController Instance { get; private set; }
    [SerializeField] GameObject m_gameObject;
    [SerializeField] string m_text;
    public Text text_Object;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    private void Start()
    {
        //text = GetComponentInChildren<Text>();
    }
    public void DisplayText(string inputText)
    {
        m_gameObject.SetActive(true);

        if (inputText.Length > 10)
        {
            Debug.Log(inputText);
            text_Object.text = inputText.Substring(0,10) + "\r" + inputText.Substring(10, inputText.Length - 10);
        }
        else
        {
            text_Object.text = inputText;
        }
        StartCoroutine("FadePanel");
    }

    IEnumerator FadePanel()
    {
        yield return new WaitForSeconds(4f);
        m_gameObject.SetActive(false);
    }

    public void CloseText()
    {   
        //gameObject.SetActive(false);
    }
}
