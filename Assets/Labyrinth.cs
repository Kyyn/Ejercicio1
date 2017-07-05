using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Labyrinth : MonoBehaviour {
    public enum TGameState
    {
        PLAYING=0,
        END_GAME
    }
    public float m_RotationalSpeed;
    public GameObject m_Ball;
    Vector3 m_StartPosition;
    public TGameState m_GameState;
	void Start ()
    {
        m_StartPosition = m_Ball.transform.position;
	}
	void Update ()
    {
        switch (m_GameState)
        {
            case TGameState.PLAYING:
                UpdatePlayingGameState();
                break;
              
        }		
	}
    void OnGUIEndGameState()
    {
        GUI.Label(new Rect(50, 50, 100, 100), "YOU WIN");
        if (GUI.Button(new Rect(50, 150, 100, 100), "Replay"))
            RestartGame();
    }

    void OnGUI()
    {
        switch(m_GameState)
        {
            case TGameState.END_GAME:
                OnGUIEndGameState();
                break;
        }
    }
    void UpdatePlayingGameState()
    {
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(new Vector3(0.0f, 0.0f, m_RotationalSpeed*Time.deltaTime));
        if(Input.GetKey(KeyCode.D))
            transform.Rotate(new Vector3(0.0f, 0.0f, -m_RotationalSpeed*Time.deltaTime));
        if(Input.GetKey(KeyCode.W))
            transform.Rotate(new Vector3(m_RotationalSpeed*Time.deltaTime, 0.0f, 0.0f));
        if(Input.GetKey(KeyCode.S))
            transform.Rotate(new Vector3(-m_RotationalSpeed*Time.deltaTime, 0.0f, 0.0f));
    }
    public void SetOnEndGameState()
    {
        Time.timeScale = 0.0f;
        m_GameState = TGameState.END_GAME;
    }
    void RestartGame()
    {
        Time.timeScale = 1.0f;
        m_Ball.transform.position = m_StartPosition;
        m_Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;


    }
}
