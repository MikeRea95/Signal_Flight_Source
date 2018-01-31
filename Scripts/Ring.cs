using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public float speed;
    public float range;
    public float birthday;
    public SpriteRenderer sprite;
    Vector3 xy;
    public float fade = .6f;


    private void Start()
    {
        birthday = Time.time;
        xy = new Vector3(transform.position.x, transform.position.y, 0);
    }
    void Update()
    {
        transform.localScale += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
        sprite.color -= new Color(0, 0, 0, fade * Time.deltaTime);
        if (transform.localScale.y > range) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Chaser")
        {
            other.gameObject.GetComponent<Alien>().signal(xy, birthday);
        }
        if (other.gameObject.tag == "Planet")
        {
            other.gameObject.GetComponent<Planet>().signal(xy, birthday);
        }
        if (other.gameObject.tag == "Turret")
        {
            other.gameObject.GetComponent<Turret>().signal(xy);
        }
        if (other.gameObject.tag == "Scout")
        {
            other.gameObject.GetComponent<Scout>().signal(xy, birthday);
        }
    }
}
