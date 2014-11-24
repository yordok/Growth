//1. Make new scene
//2. Use logo as the background (you can find it on GDrive)
//3. Go to Scripts folder, create new MenuScripts, attach to it a new empty Game object
//4. Use code in the attached Word file
//5. Go to File --> Build Settings
//6. Drag all the scenes we want into the package in the correct order


using UnityEngine;

public class MenuScript : MonoBehaviour
{
	void OnGUI()
	{
		const int buttonWidth = 84;
		const int buttonHeight = 60;
		
		// Determine the button's place on screen
		// Center in X, 2/3 of the height in Y
		Rect buttonRect = new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(2 * Screen.height / 3) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			);
		
		// Draw a button to start the game
		if(GUI.Button(buttonRect,"Start!"))
		{
			// On Click, load the first level.
			// "Stage1" is the name of the first scene we created.
			Application.LoadLevel("Untitled");
		}
	}
}
