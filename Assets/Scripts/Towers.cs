using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Towers : MonoBehaviour
{
     private GameObject target;
    [SerializeField] private float range = 1f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private LayerMask enemy;
    [SerializeField] private GameObject bulletspawn;
    [SerializeField] private float bulletspeed = 15f;
    [SerializeField] private float bps = 1f;
    private float timeUntilFire;


    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, transform.forward, range);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        if (target == null)
        {
            FindTarget();
            return;
        } 
        
        Vector2 direction = target.gameObject.transform.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        timeUntilFire += Time.deltaTime;
        
        if (!CheckInRange())
        {
            target = null;
        }

        else if (timeUntilFire >= 1f / bps && CheckInRange()) 
        {
            StartCoroutine(Fire());
            timeUntilFire = 0f;
        }
        
    }

    // Finds the closest enemy and places it as the next target. RayCAstHit2D[] is an array of all objects that goes in the circle
    private void FindTarget( )
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, range, (Vector2)transform.position, 0f, enemy);
        if (hits.Length > 0)
        {
            target = hits[0].transform.gameObject;
        }
    }

    private bool CheckInRange()
    {
        return Vector2.Distance(target.transform.position, transform.position) <= range;
    }

    // Fires the bullet 
    IEnumerator Fire()
    {
        GameObject Firebullet = Instantiate(bullet, bulletspawn.transform.position, Quaternion.identity);
        Vector2 direction = target.gameObject.transform.position - transform.position;
        Firebullet.GetComponent<Rigidbody2D>().velocity = bulletspeed * direction;
        BulletAngle(Firebullet);
        yield return new WaitForSeconds(1f);
        Destroy(Firebullet);
    }

    // Fixes the angle of the bullet when firing 
    private void BulletAngle(GameObject bullet)
    {
        Vector2 offset = target.transform.position - bullet.transform.position;
        bullet.transform.rotation = Quaternion.FromToRotation(Vector3.up, offset);
    }

}
