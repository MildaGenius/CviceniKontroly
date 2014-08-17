using UnityEngine;
using System.Collections;

public class ShowHandler : MonoBehaviour
{
	private static string _topic = "LoveTopic";
	private static string _mud = "positive";

	// Use this for initialization
	void Start () 
	{
		Debug.Log ("ShowHandler start with:" + _topic + " mud:" + _mud);
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

	public void SendMessage(GameObject gameObject)
	{
		Debug.Log ("SendMessage:" + gameObject.name + " topic:" + _topic);
		Application.OpenURL ("mailto:?subject=Confidence message&body=Hello, check my confidence message: file:///C:/Unity/CviceniKontroly/Web/Web.html?t=" + _topic + "-" + _mud);
	}
}
