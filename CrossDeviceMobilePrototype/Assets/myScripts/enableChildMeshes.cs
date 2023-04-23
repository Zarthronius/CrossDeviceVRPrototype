using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach script to parent object to enable renderers of children

public class enableChildMeshes : MonoBehaviour
{
    // Enables any nested child renderer using generics (e.g. Mesh and Sprite)
    public void ToggleChildRenderers<T>(bool state) where T : Renderer
    {
        T[] renderers = GetComponentsInChildren<T>();
        // Only occurs if nested objects found
        if (renderers.Length > 0)
        {
            foreach (T renderer in renderers)
            {
                // If object has a renderer, switch to state
                try
                {
                    renderer.enabled = state;
                }
                catch (MissingComponentException e)
                {
                    Debug.LogWarning("No renderer component found for "+renderer.gameObject.name+".");
                }
            }
        }
    }

    // Toggles Sprite and Mesh renderers to provided value
    public void toggleSpriteMeshRenderers(bool state)
    {
        ToggleChildRenderers<SpriteRenderer>(state);
        ToggleChildRenderers<MeshRenderer>(state);
    }
}
