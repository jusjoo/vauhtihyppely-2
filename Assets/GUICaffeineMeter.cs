using UnityEngine;
using System.Collections;

public class GUICaffeineMeter : MonoBehaviour
{

    public Texture2D bgCaffeineImage;
    public Texture2D fgCaffeineImage;

    void OnGUI()
    {


        // Create one Group to contain both images
        // Adjust the first 2 coordinates to place it somewhere else on-screen
        GUI.BeginGroup(new Rect(200, 0, Screen.width, 32));

        // Draw the background image
        GUI.Box(new Rect(200, 0, 200, 32), bgCaffeineImage);

            // Create a second Group which will be clipped
            // We want to clip the image and not scale it, which is why we need the second Group
            GUI.BeginGroup(new Rect(0, 0, Screen.width, 32));

            // Draw the foreground image
            GUI.Box(new Rect(200, 0, 200, 32), fgCaffeineImage);

            // End both Groups
            GUI.EndGroup();

        GUI.EndGroup();
    }
}