using SimpleJSON;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataManager
{
	private Hashtable _soundData;

	public DataManager()
	{
		_soundData = new Hashtable();
		ReadData();
	}

	public DataPrototype GetDataPrototype (string topic)
	{
		return null;
	}

	private void ReadData()
	{
		TextAsset jsonData = Resources.Load("data", typeof(TextAsset)) as TextAsset;
		if (jsonData != null)
		{
			JSONNode dataNode = JSON.Parse(jsonData.text);
			ParseData(dataNode);
		}
		else
		{
			Debug.Log("No json data!");
		}
	}

	private void ParseData(JSONNode dataNode)
	{
		foreach( var key in dataNode.Keys )
		{
			Debug.Log(key);
			JSONNode value = dataNode[key];

			DataPrototype dataPrototype = new DataPrototype();

			dataPrototype._prototypeName = key;//topic name

			dataPrototype._positiveInit = value["positiveInit"];//initial phase for positive
			dataPrototype._negativeInit = value["negativeInit"];//initial phase for negative

			//array for positive
			JSONArray positiveArray = value["sfxPositive"] as JSONArray;
			foreach(JSONNode node in positiveArray)
			{
				dataPrototype._sfxPositive.Add(node);
			}

			//array for negative
			JSONArray negativeArray = value["sfxNegative"] as JSONArray;
			foreach(JSONNode node in negativeArray)
			{
				dataPrototype._sfxNegative.Add(node);
			}

			//store whole prototype
			_soundData.Add(key, dataPrototype);
		}
	}
}