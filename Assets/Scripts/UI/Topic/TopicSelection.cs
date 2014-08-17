using UnityEngine;
using System.Collections;

public class TopicSelection : MonoBehaviour
{
	/*void OnPress (bool isPressed)
	{
		if (isPressed)
		{
			Debug.Log("Topic selection");
		}
	}*/

	void OnClickMessage(GameObject gameObject)
	{
		Debug.Log("Topic selection:" + gameObject.name);

		ShowHandler.Topic = gameObject.name;

		Application.LoadLevel("MudSelectionScene");
	}
}
