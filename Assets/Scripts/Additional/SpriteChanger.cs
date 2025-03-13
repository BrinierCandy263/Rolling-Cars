using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    public Sprite oldSprite;
    public Sprite newSprite; // The new sprite to assign

    [ContextMenu("Change Sprites Automatically")]
    public void ChangeSprites()
    {
        // Find all objects with a SpriteRenderer component in the scene
        SpriteRenderer[] spriteRenderers = FindObjectsOfType<SpriteRenderer>();
        List<GameObject> gameObjects = new  List<GameObject>();

        foreach (SpriteRenderer renderer in spriteRenderers)
        {
            if(renderer.sprite == oldSprite)  gameObjects.Add(renderer.gameObject);
        }

        foreach (GameObject gameObject in gameObjects)
        {
            Vector3 currentScale = gameObject.transform.localScale;
            gameObject.transform.localScale = new Vector3(currentScale.x * 1.3f , currentScale.y * 1.3f , 1 );
        }

        Debug.Log($"Changed {gameObjects.Count} sprites.");
    }
}

