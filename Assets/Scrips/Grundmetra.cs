using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grundmetra : MonoBehaviour
{
    public GameObject bulletprefab;
    public GameObject John;
    private float LastShoot;
    private int Health = 5;

    private void Update()
    {
        if (John == null) return;

        Vector3 direction = John.transform.position - transform.position;
        if (direction.x >= -0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        float distance = Mathf.Abs(John.transform.position.x - transform.position.x);

        if(distance < 1.0f && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        {
        Vector3 direction;
        if (transform.localScale.x == -1.0f) direction = Vector2.right;
        else direction = Vector2.left;

        GameObject bullet = Instantiate(bulletprefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<bulletscript>().SetDirection(direction);
        }
    }

    public void hit()
    {
        Health = Health - 1;
        if (Health == 0) Destroy(gameObject);
    }

    
}
