using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapSprites : MonoBehaviour
{
    public Sprite[] playerSprites;
    private int currentSpriteIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SwapSprite();
        }
        
    }
    void SwapSprite()
    {
        currentSpriteIndex++;

        if (currentSpriteIndex >= playerSprites.Length)
        {
            currentSpriteIndex = 0;
        }

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null )
        {
            spriteRenderer.sprite = playerSprites[currentSpriteIndex];
        }
        Debug.Log("Sprite");

    }

}
