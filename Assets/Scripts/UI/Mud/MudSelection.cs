using UnityEngine;
using System.Collections;

public class MudSelection : MonoBehaviour
{
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel("TopicSelectionScene");
		}
	}
	
	void OnPress (bool isPressed)
	{
		if (isPressed)
		{
			Vector2 touchPosition = UICamera.lastTouchPosition;
			Debug.Log("I was pressed negative on position:" + touchPosition.ToString());
			
			if (isPositive(Vector2.zero, new Vector2(Screen.width, Screen.height), touchPosition))
			{
				Debug.Log("Positive");
				ShowHandler.Mud = "positive";
			}
			else
			{
				Debug.Log("Negative");
				ShowHandler.Mud = "negative";
			}

			//load main scene with selected topic and mud
			Application.LoadLevel("MainScene");
		}
	}

	public bool isPositive(Vector2 linePoint1, Vector2 linePoint2, Vector2 testPoint)
	{
		return ((linePoint2.x - linePoint1.x) * (testPoint.y - linePoint1.y) - (linePoint2.y - linePoint1.y) * (testPoint.x - linePoint1.x)) > 0;
	}
}
