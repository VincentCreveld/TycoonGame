using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
	[SerializeField]
	private BigNumberHandler bigNumberHandler;
	private double totalResources = 500;

	public Text resourceDisplay, resourceDisplayLong;

	public void Update()
	{
		resourceDisplay.text = bigNumberHandler.GetResourceString(totalResources, false);
		resourceDisplayLong.text = bigNumberHandler.GetResourceString(totalResources, true);
		if(Input.GetKeyDown(KeyCode.Space))
		{
			totalResources *= 2;
		}
	}
}
