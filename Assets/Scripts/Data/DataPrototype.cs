using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataPrototype
{
	public string _prototypeName;

	public string _positiveInit;
	public string _negativeInit;

	public List<string> _sfxPositive;
	public List<string> _sfxNegative;

	public DataPrototype()
	{
		_sfxPositive = new List<string>();
		_sfxNegative = new List<string>();
	}
}
