using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	Camera camera;

	Vector2 deltaMoving;

	public GameObject dot;

	Vector2 size;
	int countOfSquares = 0;

	public float moveSpeed = 10f;

	float maxY = 0, maxX = 0;

	// Use this for initialization
	void Start () {
		camera = Camera.main;
		size = GameObject.Find ("AllFields").GetComponent<LevelGenerator>().square.GetComponent<SpriteRenderer>().size;
		countOfSquares = GameObject.Find ("AllFields").GetComponent<LevelGenerator> ().countOfSqueres;

		maxX = size.x * countOfSquares;
		maxY = size.y * countOfSquares;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.mousePosition.y > Screen.height-10  && camera.transform.position.y  < maxY) {
			camera.transform.Translate (0, moveSpeed  * Time.deltaTime, 0 );

		}
		if (Input.mousePosition.y < 10 && camera.transform.position.y > 0) {
			camera.transform.Translate (0, -moveSpeed  * Time.deltaTime, 0 );
		}

		if (Input.mousePosition.x > Screen.width-10  && camera.transform.position.x  < maxX ) {
			camera.transform.Translate (  moveSpeed  * Time.deltaTime,0, 0 );
		}
		if (Input.mousePosition.x <10 && camera.transform.position.x  > 0 ) {
			camera.transform.Translate (  -moveSpeed  * Time.deltaTime,0, 0 );
		}

		if (Input.GetMouseButtonUp(0)) {
			
			Ray ray = camera.ScreenPointToRay (Input.mousePosition);

			RaycastHit hit = new RaycastHit ();

			if (Physics.Raycast(ray, out hit)) {
				Debug.Log ("hit");

				if (hit.collider.tag.Contains("Dot")) {
					Instantiate (dot, hit.transform.position, Quaternion.identity, hit.transform);
					Debug.Log ("dot");
				}
			}
		}
	
	}
}
