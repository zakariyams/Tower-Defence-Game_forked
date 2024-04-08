using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MultipleBarrels : Towers
{
    [SerializeField] protected float range;
    [SerializeField] protected AudioSource GunShot;
    [SerializeField] protected float bulletspeed;
    [SerializeField] protected float bps;
    [SerializeField] protected GameObject[] bulletspawn;
    [SerializeField] protected GameObject bullet;
    protected GameObject target;
    public override IEnumerator Fire()
    {
        GameObject Firebullet = Instantiate(bullet, bulletspawn[0].transform.position, Quaternion.identity);
        BulletAngle(Firebullet, Target);
        GunShot.Play();

        GameObject Firebullet2 = Instantiate(bullet, bulletspawn[1].transform.position, Quaternion.identity);
        BulletAngle(Firebullet2, Target);
        GunShot.Play();
        
        Vector2 direction = (Target.transform.position - transform.position).normalized;
        Firebullet.GetComponent<Rigidbody2D>().velocity = Bulletspeed * direction;
        Firebullet2.GetComponent<Rigidbody2D>().velocity = Bulletspeed * direction;
        
        yield return new WaitForSeconds(1f);
        Destroy(Firebullet);
        Destroy(Firebullet2);
    }

    // Start is called before the first frame update
    private void Awake()
    {
        Range = range;
        Bulletspeed = bulletspeed;
        Bps = bps;
        Target = target;
    }

    // Update is called once per frame
    protected override void Update()
    {
        GunUpdate();
    }

    public void OnDrawGizmosSelected()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, transform.forward, range);
    }


}
