using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _FinalTestPlat : MonoBehaviour
{
    public bool up = true;
    public bool down = false;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        floating();
    }

    public void floating()
    {
        if(timer >= 0.5f && up == true)
        {
            up = false;
            down = true;
            timer = 0;
        }
        if (timer >= 0.5f && down == true)
        {
            up = true;
            down = false;
            timer = 0;
        }
        if (up == true)
        {
            this.transform.Translate(Vector2.up * 0.5f * Time.deltaTime);
            timer += 1.0f * Time.deltaTime;
        }
        if (down == true)
        {
            this.transform.Translate(Vector2.up * -0.5f * Time.deltaTime);
            timer += 1.0f * Time.deltaTime;
        }
    }
}
