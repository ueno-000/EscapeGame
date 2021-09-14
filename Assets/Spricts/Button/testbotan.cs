using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class testbotan : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private ClickEvent clickHandler;
    [SerializeField]
    private int activeCount = 20;
    [SerializeField]
    private float clickInterval = 0.75f;
    [SerializeField]
    private int clickCount = 0;

    private float lastTimeClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        clickCount++;
        float currentTimeClick = eventData.clickTime;
        if (Mathf.Abs(currentTimeClick - lastTimeClick) >= clickInterval)
        {
            clickCount = 1;
        }
        lastTimeClick = currentTimeClick;

        // activeCount回連続クリックした時
        if (clickCount >= activeCount)
        {
            Debug.Log("シーン切替");
        }
    }

    public void AddClickHandler(UnityAction<GameObject> handler)
    {
        this.clickHandler.AddListener(handler);
    }

   // [Serializable]
    public class ClickEvent : UnityEvent<GameObject> { 
    
    }


}