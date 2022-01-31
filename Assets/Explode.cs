using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public Camera camera;
    public Object explosion;
    private bool isClicked = false;
    private Color myColor;

    private bool didExplode = false;
    // Start is called before the first frame update
    void Start()
    {
        this.myColor = this.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (isClicked && this.myColor.a != 0)
        {
            StartCoroutine(reduceAlpha());
        }
        else
        {
            if (this.myColor.a == 0)
            {
                //Hide the object
                this.GetComponent<Renderer>().enabled = false;
                //Create explosion
                if (!didExplode)
                {
                    Instantiate(explosion, this.transform);
                    didExplode = true;
                }
            }

            StopAllCoroutines();
        }
    }

    void OnMouseDown()
    {
        this.isClicked = true;
    }

    IEnumerator reduceAlpha()
    {
        if (this.myColor.a > 0.1)
        {
            this.myColor.a = this.myColor.a - 0.1f;
            
        }
        else
        {
            this.myColor.a = 0;
        }

        yield return null;
    }
}
