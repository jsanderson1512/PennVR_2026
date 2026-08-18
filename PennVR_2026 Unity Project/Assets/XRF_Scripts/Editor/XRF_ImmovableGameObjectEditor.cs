using UnityEditor;
using UnityEngine;


[CanEditMultipleObjects]
[CustomEditor(typeof(XRF_ImmovableGameObject))]
public class XRF_ImmovableGameObjectEditor : Editor
{
    private Tool lastTool = Tool.None;

    private void OnEnable()
    {
        // Store the currently active tool
        lastTool = Tools.current;
        // Disable the transform tools
        Tools.current = Tool.None;
        Tools.hidden = true; // Hide the tools handles

        //find a way to make sure it stays at its original location... (0,0,0) or (0,1.5,0)

    }

    private void OnDisable()
    {
        // Restore the previously active tool when the object is deselected
        Tools.current = lastTool;
        Tools.hidden = false; // Show the tools handles again
    }
}
