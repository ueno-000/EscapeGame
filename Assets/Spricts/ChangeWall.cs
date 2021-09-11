using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum LookState
{
    NorthWall,
    EastWall,
    SouthWall,
    WestWall
}

public class ChangeWall : MonoBehaviour
{

    [SerializeField] GameObject[] m_walls;

    [SerializeField] AudioClip[] m_changeSounds;

    [SerializeField] LookState m_lookState;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < m_walls.Length; i++)
        {
            if (i == 0) continue;

            m_walls[i].SetActive(false);

        }

        m_lookState = LookState.NorthWall;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TurnRight()
    {

        if ((int)m_lookState + 1 >= m_walls.Length)
        {
            ChangeState(0);
        }
        else
        {
            ChangeState((int)m_lookState + 1);
        }

    }

    public void TurnLeft()
    {

        if ((int)m_lookState - 1 < 0)
        {
            ChangeState(m_walls.Length - 1);
        }
        else
        {
            ChangeState((int)m_lookState - 1);
        }

    }

    void ChangeState(int index)
    {

        m_lookState = (LookState)index;
        

        for (int i = 0; i < m_walls.Length; i++)
        {
            if (i == index)
            {
                m_walls[i].SetActive(true);
            }
            else
            {
                m_walls[i].SetActive(false);
            }
        }
        //AudioClip pickup = m_changeSounds[Random.Range(0, m_changeSounds.Length)];
        //SoundManager.Instance.OnPlayVoice(pickup);

    }

}
