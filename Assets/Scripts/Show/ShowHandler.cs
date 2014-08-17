using UnityEngine;
using System.Collections;

public class ShowHandler : MonoBehaviour
{
	private static string _topic;
	private static string _mud;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel("MudSelectionScene");
		}
	}
	static public string Mud
	{
		set
		{
			_mud = value;
		}

		get
		{
			return _mud;
		}
	}

	static public string Topic
	{
		set
		{
			_topic = value;
		}
		
		get
		{
			return _topic;
		}
	}
}
