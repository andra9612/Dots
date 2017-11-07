using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

	Camera camera;

	public Text text;
	public Text counterOfSelected;
	int counter = 0;

	Vector2 deltaMoving;

	public GameObject dot;

	Vector2 size;
	int countOfSquares = 0;

	public float moveSpeed = 10f;

	float maxY = 0, maxX = 0;

	DotStatus dotStatus;
	DotController controller;

	// Use this for initialization
	void Start () {
		controller = GameObject.Find ("DotController").GetComponent<DotController> ();
		text.color = Color.green;
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

				dotStatus = hit.transform.GetComponent<DotStatus> ();
				if (hit.collider.tag.Contains("Point") && dotStatus.isStand == false) {
					dotStatus.ChangeStatus ();
					Instantiate (dot, hit.transform.position, Quaternion.identity, hit.transform);
					Debug.Log ("dot");
					counter++;
					text.text = counter.ToString ();
				}

				if(hit.collider.tag.Contains("Dot") && dotStatus.isAdded == false){
					dotStatus.isAdded = true;
					Debug.Log ("tyta");
					controller.AddToArray (hit.transform.gameObject);
				}
			}
		}
	
	}
}
