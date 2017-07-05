using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEndGame : MonoBehaviour
{
    public Labyrinth m_Labyrinth;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
    void OnTriggerEnter(Collider other)
    {
        m_Labyrinth.SetOnEndGameState();
    }
}
