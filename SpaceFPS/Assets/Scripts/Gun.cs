using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Attributes")]
    public float damage = 10f;
    public float range = 100f;

    [Header("Unity Setup Fields")]
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private Transform target;

    private void Start()
    {
        GameObject emptyGO = new GameObject();
        target = emptyGO.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;

        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {

            target.position = hit.point;

            if (bullet != null)
            {
                bullet.Seek(target);
            }

            Debug.Log(hit.transform.name);

            Target targetTar = hit.transform.GetComponent<Target>();
            if(targetTar != null)
            {
                targetTar.TakeDamage(damage);
            }
        }
    }
}
