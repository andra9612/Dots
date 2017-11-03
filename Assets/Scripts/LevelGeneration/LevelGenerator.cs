using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	public GameObject square;
	public Transform parent;

	public int countOfSqueres = 10;

	private Vector2 size;

	void Start () {
		size = square.GetComponent<SpriteRenderer> ().size;

		GenerateField ();
	}

	void GenerateField(){

		GameObject variableSquare;

		Vector3 deltaPosition = new Vector3 (size.x, size.y, 0);

		for (int i = 0; i <= countOfSqueres; i++) {
			for (int j = 0; j <= countOfSqueres; j++) {
				deltaPosition.Set (size.x *j, size.y * i, 0);
				variableSquare = Instantiate (square, deltaPosition, Quaternion.identity, parent );

				if (i == countOfSqueres)
					variableSquare.transform.GetChild (0).gameObject.SetActive (true);
			}

		}

	}
	

}
