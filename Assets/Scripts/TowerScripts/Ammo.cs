using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float damage;
    [SerializeField] private float blastRadius;

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, transform.forward, blastRadius);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag("Rocket"))
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 5f);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Enemies"))
                {
                    hitCollider.GetComponent<Enemies>().TakeDamage(damage);
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
