using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour
{
    public Rigidbody ball;
    public Vector3 pos;
    public Vector3 forceDirection;
    public int force;

    public Color c1 = Color.yellow;
    public Color c2 = Color.red;
    public int lengthOfLineRenderer = 500;

    // Start is called before the first frame update
    void Start()
    {
        force = 0;
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 0.2f;
        lineRenderer.positionCount = lengthOfLineRenderer;

        // A simple 2 color gradient with a fixed alpha of 1.0f.
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        lineRenderer.colorGradient = gradient;

        forceDirection = ball.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        var t = Time.time;

        if (Input.GetKey("a"))
            pos.x = pos.x-(10*Time.deltaTime);

        if (Input.GetKey("d"))
            pos.x = pos.x+(10 * Time.deltaTime);

        if (Input.GetKey("w"))
           force = force+10;

        if (Input.GetKey("s"))
            force = force - 10;

        if (Input.GetKey("l"))

            ball.AddForce(0, 0, force);
        transform.position = pos;

      
        if (Input.GetKey("z"))
        {
            forceDirection.x = forceDirection.x + (10 * Time.deltaTime);
            //lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, new Vector3(forceDirection.x*force, forceDirection.y*force, forceDirection.z*force));
        }

        if (Input.GetKey("c"))
        {
            forceDirection.x = forceDirection.x - (10 * Time.deltaTime);
            //lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, new Vector3(forceDirection.x * force, forceDirection.y * force, forceDirection.z * force));
        }
    }
}
