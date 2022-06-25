using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class BackGround : MonoBehaviour
{
    //スクロールスピード
    [SerializeField] float speed = 1;

    void Update()
    {
        //左方向にスクロール
        transform.position -= new Vector3(Time.deltaTime * speed,0);

        //Xが-11まで来れば、21.33まで移動する
        if (transform.position.x <= -15f)
        {
            transform.position = new Vector3(30,0,0);
        }
    }
}