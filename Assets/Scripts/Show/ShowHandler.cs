﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShowHandler : MonoBehaviour
{
	public GameObject _sendButton;
	public SoundManager _soundManager;
	private DataManager _dataManager;

	private static string _topic = "LoveTopic";
	private static string _mud = "positive";

	// Use this for initialization
	void Start () 
	{
		Debug.Log ("ShowHandler start with:" + _topic + " mud:" + _mud);

		//for webplayer
		if (Application.isWebPlayer)
		{
			if (_sendButton)
			{
				//disable send button
				_sendButton.SetActive(false);
			}
		}

		//prepare data
		_dataManager = new DataManager();

		PrepareToPlay();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//back key dont work in webPlayer, there is possible only see show
		if (Input.GetKeyDown(KeyCode.Escape) && !Application.isWebPlayer)
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
		Application.OpenURL("mailto:?subject=Confidence message&body=Hello, check my confidence message: http://aimobile.8u.cz/CviceniKontroly.html?t=" + _topic + "-" + _mud);

		_soundManager.PlaySfx("UI.1");
	}

	private void PrepareToPlay()
	{
		DataPrototype actualTopicData = _dataManager.GetDataPrototype (_topic);
		Debug.Log ("data:" + actualTopicData);

		//if we have data, play it
		if (actualTopicData != null)
		{
			//acording to selected mud prepare playlist
			if (_mud == "positive")
			{
				_soundManager.AddToPlayList(actualTopicData._positiveInit, actualTopicData._sfxPositive, true);
			}
			else
			{
				_soundManager.AddToPlayList(actualTopicData._negativeInit, actualTopicData._sfxNegative, true);
			}
		}
		else
		{
			Debug.Log ("No data for:" + _topic);
		}
	}
}
