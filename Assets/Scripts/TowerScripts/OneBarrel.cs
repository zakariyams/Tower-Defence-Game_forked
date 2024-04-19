using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class OneBarrel : Towers
{
    [SerializeField] private float range = 5f;
    [SerializeField] private float bulletspeed = 20f;
    [SerializeField] private float bps = 1f;
    private GameObject target;
    [SerializeField] private GameObject bulletspawn;
    [SerializeField] private GameObject bullet;
    [SerializeField] protected AudioSource GunShot;




    private void Awake()
    {
        Range = range;
        Bulletspeed = bulletspeed;
        Bps = bps;
        Target = target;
    }

    public override IEnumerator Fire()
    {
        GameObject Firebullet = Instantiate(bullet, bulletspawn.transform.position, Quaternion.identity);
        Vector2 direction = (Target.transform.position - transform.position).normalized;
        Firebullet.GetComponent<Rigidbody2D>().velocity = Bulletspeed * direction;
        BulletAngle(Firebullet, Target);
        GunShot.Play();

        yield return new WaitForSeconds(1f);
        Destroy(Firebullet);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, transform.forward, range);
    }
#endif


    protected override void Update()
    {
       GunUpdate();
    }

    

}
