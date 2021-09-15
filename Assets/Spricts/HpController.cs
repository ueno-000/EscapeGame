using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HpController : MonoBehaviour
{
    /// <summary> Playerの体力 </summary>
    [SerializeField] float maxHp = 5f;
    Slider hpSlider;
    void Start()
    {
        hpSlider = GetComponent<Slider>();
        //スライダーの最大値の設定
        hpSlider.maxValue = maxHp;
    }

    /// <summary>Hpをスライダーに表示させるメソッド</summary>
    public void UpdateSlider(int hp)
    {
        hpSlider.value = hp;
    }


}