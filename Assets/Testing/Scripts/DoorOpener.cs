using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public GameManager manager;

    private void Start()
    {
        Debug.Log("Door init");
        manager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("step into door");
        if (collision.CompareTag("Player"))
        {
            manager.loadNextLevel();

        }
    }
}
