using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour
{
	void OnPress (bool isPressed)
	{
		if (isPressed)
		{
			Debug.Log("I was pressed on!");

			bool isPirated = false;
			if (Application.isWebPlayer)
			{
				//check application name
				if (!Application.srcValue.Contains("Web.unity3d"))
				{
					isPirated = true;
				}

				//check url on which is app running
				if (!Application.absoluteURL.Contains("http://aimobile.8u.cz/Web.unity3d"))
				{
					isPirated = true;
				}
				
				if (isPirated)
				{
					print("Pirated web player:" + Application.srcValue + " url:" + Application.absoluteURL);
				}
				else
				{
					//it looks ok, we can show message
					Application.LoadLevel("MainScene");
				}
			}
			else
			{
				Application.LoadLevel("TopicSelectionScene");
			}
		}
	}
}
