using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    /// <summary>移動する時にかける力</summary>
    [SerializeField] float m_movePower = 3f;
    /// <summary>ジャンプする力</summary>
    [SerializeField] float m_jumpPower = 15f;
    Rigidbody2D m_rb = default;
    /// <summary>接地フラグ</summary>
    bool m_isGrounded = false;

    Vector3 m_initialPosition = default;
   Animator m_anim = default;
    SpriteRenderer m_sprite = default;
    float m_h = 0;
    int JumpCount = 0;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();
        m_sprite = GetComponent<SpriteRenderer>();
        m_initialPosition = this.transform.position;
    }

    void Update()
    {
        m_h = Input.GetAxis("Horizontal");
       

        // ジャンプ処理
        if (JumpCount < 2 && Input.GetButtonDown("Jump")) // m_isGrounded
        {
            // m_isGrounded = false;
            
            m_rb.AddForce(Vector2.up * m_jumpPower, ForceMode2D.Impulse);
            JumpCount++;
            
        }
    


        //画面外に落ちたら初期位置に戻す
        if (this.transform.position.y < -15)
        {
            this.transform.position = m_initialPosition;
        }
    }

    void FixedUpdate()
    {
        m_rb.AddForce(m_h * m_movePower * Vector2.right);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            JumpCount = 0;
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    m_isGrounded = true;
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    m_isGrounded = false;
    //}

    private void LateUpdate()
    {
        // キャラクターの左右の向きを制御する
        if (m_h != 0)
        {
            m_sprite.flipX = (m_h < 0);
        }

        //if (m_sprite.flipX == true)
        //{
        //    m_sprite.sprite = m_leftSprite;
        //}
        //else
        //{
        //    m_sprite.sprite = m_rightSprite;
        //}

        // アニメーションを制御する
        if (m_anim)
        {
            m_anim.SetFloat("SpeedX", Mathf.Abs(m_rb.velocity.x));
            m_anim.SetFloat("SpeedY", m_rb.velocity.y);
            //m_anim.SetBool("IsGrounded", m_isGrounded);
        }
    }
}
