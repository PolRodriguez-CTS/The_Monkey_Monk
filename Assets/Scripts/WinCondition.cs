using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    public GameObject victoryCanvas;
    public bool hasWinned;

    void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        victoryCanvas.SetActive(false);
        hasWinned = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 8)
        {
            hasWinned = true;
            victoryCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }
    

}
