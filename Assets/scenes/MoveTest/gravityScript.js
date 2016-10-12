#pragma strict

public var gravityStrength :float = 2;

function Start () {
	var rb = GetComponent(Rigidbody2D); 
}

function Update () {
	var rb = GetComponent(Rigidbody2D); 

	var i :int;
	var gravityList = GameObject.FindGameObjectsWithTag("Gravity");
	var gravity :Vector2;
	var difference :Vector2;
	var angle :float;
	for (i = 0; i < gravityList.length; i++) {
		gravity = Vector2(1, 0);
		difference = gravityList[i].GetComponent(Rigidbody2D).position - rb.position;
		
		if (difference.magnitude != 0) {
			gravity.x /= Mathf.Pow(difference.magnitude, 2);
			gravity.x *= gravityList[i].GetComponent(Rigidbody2D).mass;
			gravity.x *= gravityStrength * Time.deltaTime * rb.mass;
	
			angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
	
			gravity = Quaternion.Euler(0, 0, angle) * gravity;
	
			rb.AddForce(gravity);
		}
	}
}