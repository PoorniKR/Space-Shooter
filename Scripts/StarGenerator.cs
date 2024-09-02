using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    public GameObject Star;
    public int MaxStars;

    Color[] starColors = {
        new Color(0.5f, 0.5f, 1f),//blue
        new Color(0, 1f, 1f),//green
        new Color(1f, 1f, 0),//yellow
        new Color(1f, 0, 0),//red
    };
    // Start is called before the first frame update
    void Start()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1)); 

        for(int i = 0; i < MaxStars; ++i)
        {
            GameObject star = (GameObject)Instantiate(Star);
            star.GetComponent<SpriteRenderer>().color = starColors[i % starColors.Length];
            star.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
            star.GetComponent<Star>().speed = -(1f * Random.value + 0.5f);
            star.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
