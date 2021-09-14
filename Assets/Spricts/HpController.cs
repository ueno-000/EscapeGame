using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HpController : MonoBehaviour
{
    [SerializeField] float maxHp = 5f;
    Slider hpSlider;

    // Use this for initialization
    void Start()
    {
        hpSlider = GetComponent<Slider>();
        //スライダーの最大値の設定
        hpSlider.maxValue = maxHp;
    }


    public void UpdateSlider(int hp)
    {
        hpSlider.value = hp;
    }


}