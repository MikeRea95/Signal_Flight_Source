using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthRing : MonoBehaviour
{

    public float speed;
    public float range;
    public GameObject Player;
    public GameObject meSprite;

    // Use this for initialization
    void Start()
    {

        meSprite.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
        if (transform.localScale.y > range)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == Player)
        {
            //show ship
            meSprite.SetActive(true);
            meSprite.GetComponent<ShipMarker>().birthday = Time.time;
            //print("entered");
        }
    }


}
