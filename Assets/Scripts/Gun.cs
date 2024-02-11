using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float fireRate = 4f;
    public float lastFired = 0f;

    // Update is called once per frame
    void Update()
    {
        lastFired += Time.deltaTime;
        if (lastFired >= fireRate)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.transform.SetParent(transform);
        lastFired = 0f;
    }
}
