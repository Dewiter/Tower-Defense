using UnityEngine;

public class CameraController : MonoBehaviour {

	public float panSpeed		= 30f;
	public float panBorder		= 10;
	public float scrollSpeed	= 10f;

	private float minY			= 10f;
	private float maxY			= 80f;
	
	private bool moving = true;
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			moving = !moving;
		if (!moving)
			return ;
		if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorder)
			transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
		if (Input.GetKey("s") || Input.mousePosition.y <= panBorder)
			transform.Translate(-Vector3.forward * panSpeed * Time.deltaTime, Space.World);
		if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorder)
			transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
		if (Input.GetKey("a") || Input.mousePosition.x <= panBorder)
			transform.Translate(-Vector3.right * panSpeed * Time.deltaTime, Space.World);

		float scroll	= Input.GetAxis("Mouse ScrollWheel");
		Vector3 pos		= transform.position;

		pos.y -= scroll * scrollSpeed * Time.deltaTime * 1000;
		pos.y = Mathf.Clamp(pos.y, minY, maxY);
		transform.position = pos;
	}
}
