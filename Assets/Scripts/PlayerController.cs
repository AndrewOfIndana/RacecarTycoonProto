using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public float angularVelocityFloat;
    public float dragVisual;
    public float AdragVisual;

    public int speedLevel = 1;
    public int AVlevel = 1;
    public int dragLevel = 1;
    public int AdragLevel = 1;

    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
        dragVisual = rb.drag;
        AdragVisual = rb.angularDrag;
    }

    void FixedUpdate()
    {
        Vector3 moveDir = new Vector3();

        float impulse = Input.GetAxis("Vertical");
        float twist = Input.GetAxis("Horizontal");

        rb.AddTorque(new Vector3(0f, twist * 2f, 0f));
        rb.angularVelocity = new Vector3(0f, twist * angularVelocityFloat, 0f);
        
        moveDir = this.transform.forward * impulse * speed;

        rb.AddForce(moveDir);
    }

    public void UpdateSpeed()
    {
        speed = (float)(15 + (5 * speedLevel));
    }
    public void UpdateAV()
    {
        angularVelocityFloat = (float)(1 * AVlevel);
    }
    public void UpdateDrag()
    {
        rb.drag = (float)(.15 * dragLevel);
        dragVisual = rb.drag;
    }
    public void UpdateADrag()
    {
        rb.angularDrag = (float)(.01 * dragLevel);
        AdragVisual = rb.angularDrag;
    }
    public void DefaultRestore()
    {
        speed = 20;
        angularVelocityFloat = 1;
        rb.drag = .15f;
        rb.angularDrag = .01f;
    }
}