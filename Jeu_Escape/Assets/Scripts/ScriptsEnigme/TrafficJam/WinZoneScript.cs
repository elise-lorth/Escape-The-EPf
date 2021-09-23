using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinZoneScript : MonoBehaviour {

	[SerializeField]
	GameObject Victory,Panel, Button, palier, Result;

	void Start()
	{
		Victory.SetActive(false);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		Victory.SetActive(true);
		Panel.SetActive(false);
		Button.SetActive(false);
		palier.SetActive(true);
		Result.SetActive(true);
	}
}
