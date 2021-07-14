using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBg : MonoBehaviour
{
    
    private MeshRenderer meshRenderer;

    public float speed = -0.001f;

    [HideInInspector]
    public bool canScroll;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    
    void Update()
    {
        if(canScroll && PlayAnimation.instance.playerDied == false){
        meshRenderer.material.mainTextureOffset -= new Vector2(speed * Time.deltaTime, 0);
        }
    }
}
