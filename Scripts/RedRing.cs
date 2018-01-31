using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedRing : MonoBehaviour {

    public float speed;
    public float range;
    public float birthday;
    public Vector3 target;
    public SpriteRenderer sprite;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
        sprite.color -= new Color(0, 0, 0, Time.deltaTime/2);
        if (transform.localScale.y > range)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Chaser")
        {
            other.gameObject.GetComponent<Alien>().signal(target, birthday);
        }
        if (other.gameObject.tag == "Scout")
        {
            other.gameObject.GetComponent<Scout>().signal(target, birthday);
        }
        if (other.gameObject.tag == "Turret")
        {
            other.gameObject.GetComponent<Turret>().signal(transform.position);
        }
    }
}
