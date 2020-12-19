using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _FinalTestPlat : MonoBehaviour
{
    public bool up = true;
    public bool down = false;
    public bool expanding = true;

    public float timer;


    public AudioSource[] audio;
    public AudioSource shrinkSound;
    public AudioSource expandSound;

    

    // Start is called before the first frame update
    void Start()
    {
        shrinkSound = audio[0];
        expandSound = audio[1];
    }

    // Update is called once per frame
    void Update()
    {
        floating();
        expand();
    }

    public void floating()
    {
        if(timer >= 0.5f && up == true)
        {
            up = false;

            timer = 0;
          
        }
        if (timer >= 0.5f && up == false)
        {
            up = true;

            timer = 0;
        }
        if (up == true)
        {
            this.transform.Translate(Vector2.up * 0.5f * Time.deltaTime);
            timer += 1.0f * Time.deltaTime;
        }
        if (up == false)
        {
            this.transform.Translate(Vector2.up * -0.5f * Time.deltaTime);
            timer += 1.0f * Time.deltaTime;
        }
    }

    public void expand()
    {
        if (expanding == true && this.gameObject.transform.localScale.x <= 4)
        {
            scaleChange = new Vector3(0.05f, 0, 0);
            this.gameObject.transform.localScale += scaleChange;
        }
    }

    public Vector3 scaleChange;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            scaleChange = new Vector3(-0.05f, 0,0);
            this.gameObject.transform.localScale += scaleChange;
            expanding = false;

        };

        if (!shrinkSound.isPlaying)
        {
            shrinkSound.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            expanding = true;
            if (!expandSound.isPlaying)
            {
                expandSound.Play();
            }
        }
        
    }



}
