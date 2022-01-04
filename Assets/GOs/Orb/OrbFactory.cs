using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbFactory : MonoBehaviour
{
    public GameObject OrbPrefab;
    public Sprite[] OrbSprites;

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
            //Transform orbTransform = new Transform();

            //orbTransform.position = new Vector3(0f, 6f, 0f);

            orb = Instantiate(OrbPrefab, null);
            orb.transform.position = new Vector3(Random.Range(-20f, 20f), 6f, 0f);

            SpriteRenderer spriteRenderer = orb.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = OrbSprites[Random.Range(0, OrbSprites.Length)];
        }
        
    }
}
