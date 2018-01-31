using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public Vector3 target;
    public float rotation = 0.5f;
    public bool aggro = false;
    public float period;
    float counter = 0;
    public GameObject bullet;
    public GameObject Player;
    public bool smart;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (aggro)
        {
            Vector3 vectorToTarget = target - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            //float str = Mathf.Min(rotation * Time.deltaTime, 1);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, rotation * Time.deltaTime);

            counter += Time.deltaTime;
            if(counter > period)
            {
                counter = 0;
                //fire lasar
                GameObject laser = Instantiate(bullet, transform.position, transform.rotation);
                laser.GetComponent<Laser>().dir = Vector3.Normalize(target - transform.position);
                laser.GetComponent<Laser>().Player = Player;

            }
        }
    }
    
    public void signal(Vector3 inPos)
    {
        aggro = true;
        target = smart ? Player.GetComponent<Transform>().position: inPos;
    }
}
