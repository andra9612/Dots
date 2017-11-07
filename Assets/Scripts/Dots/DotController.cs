using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotController : MonoBehaviour {

	ArrayList dotArray;

	void Start(){
		dotArray = new ArrayList ();
	}


	public void AddToArray(GameObject dot){
		dotArray.Add (dot);
		dot.GetComponent<SpriteRenderer> ().color = Color.black;
		Debug.Log ("rrrr");
	}
}
