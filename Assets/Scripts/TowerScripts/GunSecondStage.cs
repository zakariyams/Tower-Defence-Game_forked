using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GunSecondStage : Towers
{
    [SerializeField] private float range;
    [SerializeField] private float bulletspeed;
    [SerializeField] private float bps;
    [SerializeField] private GameObject[] bulletspawn;
    [SerializeField] private GameObject bullet;
    private GameObject target;
    public override IEnumerator Fire()
    {
        GameObject Firebullet = Instantiate(bullet, bulletspawn[0].transform.position, Quaternion.identity);
        BulletAngle(Firebullet, Target);
        GameObject Firebullet2 = Instantiate(bullet, bulletspawn[1].transform.position, Quaternion.identity);
        BulletAngle(Firebullet2, Target);
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

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, transform.forward, range);
    }

}
