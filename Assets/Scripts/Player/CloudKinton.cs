using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudKinton : MonoBehaviour
{

    [SerializeField] private float _timer = 2f;
    [SerializeField] private float _timerDestroy = 4f;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider;
    

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {

        StartCoroutine(Finish());

    }

    IEnumerator Finish()
    {
        yield return new WaitForSeconds(_timer);
        _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.b, _spriteRenderer.color.g, _spriteRenderer.color.a - Time.deltaTime);
        _boxCollider.enabled = false;

        yield return new WaitForSeconds(_timerDestroy);
        Destroy(gameObject);

    }
}
