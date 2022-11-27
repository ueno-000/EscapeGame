using UnityEngine;
using UnityEngine.UI;

public class MessageController : MonoBehaviour
{
    [SerializeField] private Text _messageTextBox;
    [SerializeField] private string[] _massages;
    [SerializeField] private float _textDuration;

    private int i;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        _messageTextBox = _messageTextBox.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_massages.Length <= i){ return;}

        time += Time.deltaTime;

        if (time >= _textDuration)
        {
            _messageTextBox.text = _massages[i].ToString();
            time = 0f;
            i++;
        }
    }
}
