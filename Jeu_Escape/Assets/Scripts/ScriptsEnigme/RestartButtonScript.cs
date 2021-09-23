using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonScript : MonoBehaviour {

	[SerializeField]
	GameObject Panel;

	void Start()
	{
		Panel.SetActive(false);
	}

	public void PanelAppear()
    {
		Panel.SetActive(true);
    }

	public void Paneldisappear()
	{
		Panel.SetActive(false);
	}

//	public void Paneldisappear()
//	{
//		Panel.SetActive(false);
//	}
}
