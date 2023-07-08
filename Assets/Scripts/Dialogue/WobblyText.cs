using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
// Credit to https://www.youtube.com/watch?v=FXMqUdP3XcE

public class WobblyText : MonoBehaviour
{
    public TMP_Text text;
    // Update is called once per frame
    void Update()
    {
        text.ForceMeshUpdate();
        var textInfo = text.textInfo;   // Get the info of the text
        for(int i = 0; i < textInfo.characterCount; ++i)    // Get the info of each character in the text
        {
            var charInfo = textInfo.characterInfo[i];
            if (!charInfo.isVisible)    
            {
                continue;
            }

            var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices; // Get the vertices of each character
            for(int j = 0; j < 4; ++j)  // One iteration for each vertex
            {
                var orig = verts[charInfo.vertexIndex + j];
                verts[charInfo.vertexIndex + j] = orig + new Vector3(0f, Mathf.Sin(Time.time * 6f + orig.x * 0.01f) * 2f, 0f); // Actually manipulate the vertices
            }
        }

        for(int i = 0; i < textInfo.meshInfo.Length; ++i)
        {
            var meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices; // There are two versions of meshInfo.vertices, we have to update them both
            text.UpdateGeometry(meshInfo.mesh, i);
        }
    }
}
