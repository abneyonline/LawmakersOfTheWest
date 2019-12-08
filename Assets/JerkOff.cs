using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JerkOff : MonoBehaviour
{
    // I know this is horrible but I couldn't find an easy way to relate a key to it's position on the keyboard, nor a way to support international keyboards.

    private KeyCode[] topRow = new KeyCode[] { KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R, KeyCode.T, KeyCode.Y, KeyCode.U, KeyCode.I, KeyCode.O, KeyCode.P};
    private KeyCode[] middleRow = new KeyCode[] { KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.J, KeyCode.K, KeyCode.L};
    private KeyCode[] bottomRow = new KeyCode[] { KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.V, KeyCode.B, KeyCode.N, KeyCode.M };

    private moveHand hand;

    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.Find("hand");
        hand = go.GetComponent<moveHand>();
    }

    private int lastX = 0, lastY = 0;

    private float penisPowerTotal = 0f;

    public GameObject deathEyes;
    public AudioSource audio;
    public AudioSource backgroundMusic;

    private bool finished = false;

    void Update()
    {

        float penisPower = 0f;

        bool incremented = false;

        // Using the geometric distance formula, add to penisPower the reciprocal of the distance between the held key and the previous key's location.
        // This is supposed to simulate going along the shaft rather than alternating pressing the farthest keys on the keyboard.
        // If I wanted to disallow a person to just hold two keys down to increment penisPower I would need to add each pressed
        // key to a list and wait for it be unheld to remove it from the list. As it is, my fear is that without this exploit,
        // the game won't hold people's attentions long enough for them to finish.

        for(int a = 0; a < topRow.Length; a++)
        {
            if(Input.GetKey(topRow[a]))
            {
                float distance = Mathf.Sqrt(Mathf.Pow(lastX - a, 2) + Mathf.Pow(lastY - 0, 2));

                if(!(distance < 0.01f))
                {
                    penisPower += 1 / distance;
                }


                lastX = a;
                lastY = 0;
                incremented = true;
            }
        }

        for (int a = 0; a < middleRow.Length; a++)
        {
            if (Input.GetKey(middleRow[a]))
            {
                float distance = Mathf.Sqrt(Mathf.Pow(lastX - a, 2) + Mathf.Pow(lastY - 1, 2));

                if (!(distance < 0.01f))
                {
                    penisPower += 1 / distance;
                }

                lastX = a;
                lastY = 1;
                incremented = true;
            }
        }

        for (int a = 0; a < bottomRow.Length; a++)
        {
            if (Input.GetKey(bottomRow[a]))
            {
                float distance = Mathf.Sqrt(Mathf.Pow(lastX - a, 2) + Mathf.Pow(lastY - 2, 2));

                if (!(distance < 0.01f))
                {
                    penisPower += 1 / distance;
                }

                lastX = a;
                lastY = 2;
                incremented = true;
            }
        }

        if (incremented)
        {
            Text lmao = GetComponentInParent<Text>();

            penisPowerTotal += penisPower * 10;

            lmao.text = "Penis Power: " +  penisPowerTotal + " of 10000";

            hand.increment(penisPower * 10);
        }

        if(penisPowerTotal >= 10000 && !finished)
        {
            finished = true;

            deathEyes.SetActive(true);

            audio.Play();

            backgroundMusic.Stop();
        }
    }
}
