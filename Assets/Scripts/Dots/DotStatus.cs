using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotStatus : MonoBehaviour {

	public bool isStand = false;
	public bool isAdded = false;

	public void ChangeStatus(){
		if(isStand == false)
			isStand =  true;

		Debug.Log (isStand);
	}
}
