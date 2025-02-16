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

        foreach (SpriteRenderer renderer in spriteRenderers)
        {
            if(renderer.sprite == oldSprite) renderer.sprite = newSprite;
        }

        Debug.Log($"Changed {spriteRenderers.Length} sprites.");
    }
}

