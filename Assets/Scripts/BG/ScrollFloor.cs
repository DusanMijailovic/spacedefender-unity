using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollFloor : MonoBehaviour
{
    
    private new Renderer renderer;

    public float groundSpeed = 1f;

    private Vector2 offset;
     
    [HideInInspector]
    public bool groundScroll;
    void Start()
    {
        renderer = GetComponent<Renderer>();   
    }

    
    void Update()
    {
        if(groundScroll && PlayAnimation.instance.playerDied == false)
        {
            offset = new Vector2(Time.time * groundSpeed, 0);
            renderer.material.mainTextureOffset = offset;
        }
        
    }
}
