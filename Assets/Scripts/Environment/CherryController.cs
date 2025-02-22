using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class CherryController : MonoBehaviour
{
    public SpriteRenderer GemRender;
    public float Distance = 1.5f;
    public float Distance2 = 1.5f;
    public float Speed = 1f;
    public Ease easing;


    // Start is called before the first frame update
    void Start()
    {
        GemMove();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void GemMove()
    {
        transform.DOLocalMoveX(Distance, Speed).SetEase(easing).OnComplete(() =>
        { 
            transform.DOLocalMoveX(Distance2, Speed).SetEase(easing).OnComplete(() =>
            {
                GemMove();
            });
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealthController hCtr = collision.gameObject.GetComponent<PlayerHealthController>();
        hCtr.Regenerate();

        Debug.Log(collision.name);

        Destroy(this.gameObject); // Destroy the whole object using this.
    }
}
