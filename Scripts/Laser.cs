using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public float speed;
    public Vector3 dir;
    public float range;
    public float age = 0;
    public GameObject Player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += speed * dir * Time.deltaTime;
        age += Time.deltaTime;
        if(age > range)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == Player)
        {
            Player.GetComponent<Killable>().Die();
        }
    }
}
