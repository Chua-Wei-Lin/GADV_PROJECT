using System;
using UnityEngine;

public class ItemDestruction : MonoBehaviour
{
    public static event Action BoostCollect;
    public static event Action PowerCollect;
    public static event Action<Collider2D> LetterCollect;
    public static event Action LetterScore;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Booster"))
        {
            BoostCollect?.Invoke();
            Destroy(collision.gameObject);// Destroys the object this collided with
        }
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            PowerCollect?.Invoke();
            Destroy(collision.gameObject);// Destroys the object this collided with
        }
        if (collision.gameObject.CompareTag("Letter"))
        {
            LetterCollect?.Invoke(collision.collider);
            Destroy(collision.gameObject);// Destroys the object this collided with
        }
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            LetterScore?.Invoke();
            Destroy(collision.gameObject);// Destroys the object this collided with
        }
    }
}
    

