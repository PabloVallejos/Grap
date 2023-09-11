using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public Camera cam;
    public GameObject obj;
    public AudioClip clip;
    public float climbSpeed;
    public float camLimit;
    LineRenderer line;
    DistanceJoint2D jnt;
    Animator anima;
    //HingeJoint2D hng;
    public int maxD;
    float distL;
    float dist;
    private bool coll;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        jnt = GetComponent<DistanceJoint2D>();
        anima = GetComponent<Animator>();
        //hng = GetComponent<HingeJoint2D>();
        cam = GameObject.FindObjectOfType<Camera>();
        jnt.enabled = false;
        line.enabled = false;
    }

    private void Update()
    {
        if (transform.position.x >= 0 && transform.position.x <= camLimit)
        {
            cam.transform.position = new Vector3(transform.position.x, 0, -10);
        }
        distL = Vector3.Distance(line.GetPosition(0), line.GetPosition(1));
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GetComponent<AudioSource>().clip = clip;
            GetComponent<AudioSource>().Play();
            Vector2 mous = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
            dist = Vector3.Distance(transform.position, mous);
            anima.SetBool("Tongue", true);
            /*line.enabled = true;
            line.SetPosition(0, mous);
            line.SetPosition(1, transform.position);*/
            if (obj.tag == "Grappable" && dist <= maxD)
            {
                Debug.Log("Grabbed");
                anima.SetBool("Tongue", false);
                anima.SetBool("Hang", true);
                jnt.enabled = true;
                line.enabled = true;
                //hng.enabled = true;
                line.SetPosition(0, mous);
                line.SetPosition(1, transform.position);
                jnt.connectedAnchor = mous;
                //hng.connectedAnchor = mous;
            }
            /*if (obj.tag != "Grappable" || obj == null || dist > maxD)
            {
                jnt.enabled = true;
                /*line.enabled = true;
                //hng.enabled = true;
                line.SetPosition(1, mous);
                line.SetPosition(0, transform.position);
                jnt.connectedAnchor = mous;
                //hng.connectedAnchor = mous;
                jnt.distance = Mathf.Lerp(0, maxD, Time.deltaTime);
            }*/
        }// else if (Input.GetKeyUp(KeyCode.Mouse0)) { jnt.enabled = false; line.enabled = false; anima.SetBool("Tongue", false); anima.SetBool("Hang", false); }
        if (Input.GetKeyUp(KeyCode.Mouse0)) { jnt.enabled = false; line.enabled = false; anima.SetBool("Tongue", false); anima.SetBool("Hang", false); }

        if (jnt.enabled)
        {
            line.SetPosition(1, transform.position);
        }

        HandleRopeLength();
    }
    private void HandleRopeLength()
    {
        if (jnt.distance <= maxD)
        {
            if (Input.GetAxis("Vertical") >= 0.1f && jnt.enabled/* && !coll*/)
            {
                jnt.distance -= Time.deltaTime * climbSpeed;
            }
            else if (Input.GetAxis("Vertical") < 0f && jnt.enabled && !coll)
            {
                jnt.distance += Time.deltaTime * climbSpeed;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        coll = true;
        anima.SetBool("Grounded", true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        coll = false;
        anima.SetBool("Grounded", false);
    }
}
