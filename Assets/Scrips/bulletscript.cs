using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour
{
    public AudioClip Sound;
    public float Speed;

    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }
    
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        johnmov john = collider.GetComponent<johnmov>();
        Grund grund = collider.GetComponent<Grund>();
        Grundmetra Grundmetra = collider.GetComponent<Grundmetra>();
        if (john != null)
        {
            john.hit();
        }
        if (grund != null)
        {
            grund.hit();
        }
        if (Grundmetra != null)
        {
            Grundmetra.hit();
        }
        DestroyBullet();
    }
}
