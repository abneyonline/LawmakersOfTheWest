using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveHand : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {

    }

    private float startX = 0;
    private float startY = 0;

    private float endX = 2.55f;

    private float posX = 0;

    private int direction = 1;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increment(float x)
    {
        if(posX < startX)
        {
            direction *= -1;
            posX = startX;
        }
        if(posX > endX)
        {
            direction *= -1;
            posX = endX;
        }

        posX += x * direction * 0.01f;

        transform.position = new Vector3(posX, startY, -1);
    }
}
