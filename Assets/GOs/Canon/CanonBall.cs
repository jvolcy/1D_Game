using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBall : MonoBehaviour
{
    public GameObject OrbPrefab;
    public Sprite[] OrbSprites;
    public float MinFiringForce = 500f;
    public float MaxFiringForce = 1100f;
    public float CanonBallLife = 10f;
    public float CanonAngle = 145f;
    public float FiringPeriod = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 100 == 0)
        {
            GameObject orb;

            orb = Instantiate(OrbPrefab, transform.position, new Quaternion());
            Orb orbScript = orb.GetComponent<Orb>();

            orbScript.Force = Random.Range(MinFiringForce, MaxFiringForce);
            orbScript.Angle = CanonAngle;
            orbScript.OrbLife = CanonBallLife;

            SpriteRenderer spriteRenderer = orb.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = OrbSprites[Random.Range(0, OrbSprites.Length)];
        }
        
    }
}
