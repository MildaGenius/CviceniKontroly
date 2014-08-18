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
				if (Application.srcValue != "Web.unity3d")
				{
					isPirated = true;
				}
				
				if (string.Compare(Application.absoluteURL, "http://aimobile.8u.cz/Web.unity3d", true) != 0)
				{
					isPirated = true;
				}
				
				if (isPirated)
				{
					print("Pirated web player:" + Application.srcValue);
				}
				else
				{
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
