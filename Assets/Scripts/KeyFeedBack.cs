using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFeedBack : MonoBehaviour
{
    public bool KeyHit = false;
    public bool KeyCanBeHitAgain = false;

    private float originalYPosition;
    private SoundHandler soundHandler;

    // Start is called before the first frame update
    void Start()
    {
        soundHandler = GameObject.FindGameObjectWithTag("SoundHandler").GetComponent<SoundHandler>();
        originalYPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (KeyHit)
        {
            soundHandler.PlayOnClick();
            KeyHit = false;
            KeyCanBeHitAgain = false;

            transform.position += new Vector3(0, -0.02f, 0);
        }
        if (transform.position.y < originalYPosition)
        {
            transform.position += new Vector3(0, 0.005f, 0);
        }
        else
        {
            KeyCanBeHitAgain = true;
        }

    }

    public void KeyHited()
    {
        KeyHit = true;
    }
}
