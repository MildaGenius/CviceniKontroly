using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour
{
	void OnPress (bool isPressed)
	{
		if (isPressed)
		{
			Debug.Log("I was pressed on!");
			Application.LoadLevel("TopicSelectionScene");
		}
	}
}
