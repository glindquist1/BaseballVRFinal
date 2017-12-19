using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mover : MonoBehaviour {

    private bool slow = false;
    private Rigidbody rb;
    public float speed;
    public AudioClip hit;
    public bool hit_bat;

    private AudioSource src;
    
    // Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        //rb.velocity = new Vector3(1 * speed, -6, -1 * speed);
        rb.velocity = rb.transform.forward * speed;
        Debug.Log("pitched");
        hit_bat = false;
        src = GetComponent<AudioSource>();



    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bat")
        {
            Debug.Log("hit bat");
            
            hit_bat = true;
            rb.velocity = new Vector3(0, 0, 0);
            Physics.IgnoreCollision(collision.gameObject.GetComponent<CapsuleCollider>(), gameObject.GetComponent<SphereCollider>());

            float force = getBatForce(collision.gameObject.GetComponent<Rigidbody>(), collision);


            Debug.Log(force);
            Vector3 dir = (transform.position - collision.contacts[0].point).normalized;

            rb.AddForce(force * dir, ForceMode.Impulse);
            rb.useGravity = true;

            src.Stop();
            src.PlayOneShot(hit);

            Destroy(gameObject, 2f);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "slow zone")
        {
            rb.velocity *= 0.35f;
            src.Play();
            //Time.timeScale = 0.25f;
            //StartCoroutine(NormalTime());

        }
        if (other.gameObject.tag == "back stop")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "foul plane")
        {
            Debug.Log("foul ball collision detected");
            Destroy(gameObject);

        }
        if (other.gameObject.tag == "home run")
        {
            Debug.Log("home runs collision detected");

                Destroy(gameObject);

        }
    }

    //IEnumerator NormalTime()
    //{
    //    yield return new WaitForSecondsRealtime(2f);
    //    Time.timeScale = 1f;
    //}

    private float getBatForce(Rigidbody batRB, Collision collision)
    {
        float ang_vel = OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.RTouch).magnitude;
        float distance = (collision.contacts[0].point - OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch)).magnitude;

        //Vector3 normal = collision.contacts[0].normal;

        //return ang_vel * distance / 200f * 30f;
        return ang_vel * distance / 200f * 5f;
        //BatSpeed bs = (BatSpeed)batRB.GetComponent(typeof(BatSpeed));
        //return bs.getVelocity().magnitude /200f * 30f;
        //return batRB.velocity.magnitude / 200f * 30f;
    }


}
