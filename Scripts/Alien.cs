using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour {

    public Vector3 target;
    public bool chase = false;
    public float rotation = 0.5f;
    //public Rigidbody2D rb;
    public float thrust;
    public bool smart;
    public float targetBirthday;
    public GameObject Player;
    Vector3 dir;

    // Use this for initialization
    void Start () {
        if (transform.position.z != 0)
            transform.position = new Vector3(transform.position.x,transform.position.y,0);
        //rb = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (chase)
        {
            /*
            Quaternion targetRotation = Quaternion.LookRotation(target - transform.position, Vector3.forward);
            float str = Mathf.Min(rotation * Time.deltaTime, 1);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, str);
            */
            Vector3 vectorToTarget = target - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            //float str = Mathf.Min(rotation * Time.deltaTime, 1);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, rotation * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        if (chase)
        {
            transform.position += thrust * Vector3.Normalize(dir)* Time.deltaTime;
        }
    }

    public void signal(Vector3 xy, float birthday)
    {
        chase = true;
        if ((smart && birthday > targetBirthday) || !smart)
        {
            target = xy;
            dir = xy - transform.position;
            targetBirthday = birthday;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == Player)
            collision.gameObject.GetComponent<Killable>().Die();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(smart && collision.gameObject == Player)
        {
            chase = true;
            target = Player.GetComponent<Transform>().position;
            dir = Player.GetComponent<Transform>().position - transform.position;
        }
    }
}
