using UnityEngine;

public class MultiDisplay : MonoBehaviour
{
    void Start()
    {
        Debug.Log("displays connected: " + Display.displays.Length);
        // Display.displays[0] is the primary, default display and is always ON.
        if (Display.displays.Length > 1)
            Display.displays[1].Activate();
    }
}