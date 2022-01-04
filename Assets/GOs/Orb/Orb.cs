using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public float StartY = 6.0f;
    public float StartX = 0f;
    public float Angle = 45f;
    public float Force = 1000f;

    public float OrbLife = 10.0f;
    public Sprite RedOrb;
    public Sprite GreenOrb;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(Force * Mathf.Cos(Angle * Mathf.Deg2Rad), Force * Mathf.Sin(Angle * Mathf.Deg2Rad), 0f));
        Destroy(gameObject, OrbLife);
    }

    // Update is called once per frame
    void Update()
    {
    }


}
