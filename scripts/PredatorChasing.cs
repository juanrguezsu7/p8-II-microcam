using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorChasing : MonoBehaviour
{
    public float speed = 1.0f;
    private GameObject[] victims;
    public AudioClip eatSound;
    public float volume = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        victims = GameObject.FindGameObjectsWithTag("Victim");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float minDistance = float.MaxValue;
        GameObject closestVictim = null;
        foreach (GameObject victim in victims)
        {
            float distance = Vector3.Distance(victim.transform.position, transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestVictim = victim;
            }
        }
        if (closestVictim != null)
        {
            GetComponent<Rigidbody>().MovePosition(Vector3.MoveTowards(transform.position, closestVictim.transform.position, speed * Time.fixedDeltaTime));
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Victim")
        {
            Destroy(collision.gameObject);
            collision.gameObject.tag = "Untagged";
            victims = GameObject.FindGameObjectsWithTag("Victim");
            AudioSource.PlayClipAtPoint(eatSound, transform.position, volume);
        }
    }
}
