using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scout : MonoBehaviour
{

    public float birthday = 0;
    public bool alerted;
    public Vector3 target;
    public float period;
    float count;
    public GameObject redRing;
    public GameObject Player;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");
        count = period;
    }

    public void signal(Vector3 inPos, float inBirth)
    {
        if (inBirth > birthday)
        {
            birthday = inBirth;
            alerted = true;
            target = inPos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (alerted)
        {
            count += Time.deltaTime;
            if (count > period)
            {
                count = 0;
                //emit red ring
                GameObject newRing = Instantiate(redRing, transform.position, transform.rotation);
                newRing.GetComponent<RedRing>().target = this.target;
                newRing.GetComponent<RedRing>().birthday = this.birthday;

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player)
            collision.gameObject.GetComponent<Killable>().Die();
    }

}
