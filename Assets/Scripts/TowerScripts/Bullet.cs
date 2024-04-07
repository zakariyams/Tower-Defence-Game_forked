using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float damage;
    [SerializeField] private float blastradius;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag("Rocket"))
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, blastradius);
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Enemies"))
                {
                    collider.GetComponent<Enemies>().TakeDamage(damage);
                }
            }
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemies"))
        {
            collision.gameObject.GetComponent<Enemies>().TakeDamage(damage);
            Destroy(gameObject);

        }
    }


}
