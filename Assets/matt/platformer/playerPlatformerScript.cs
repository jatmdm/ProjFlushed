using UnityEngine;
using System.Collections;

public class playerPlatformerScript : MonoBehaviour {
	Vector2 colliderExtents;

	// Use this for initialization
	void Start () {
		colliderExtents = GetComponent<BoxCollider2D> ().bounds.extents;
	}

	public bool isGrounded() {
		float halfHeight = colliderExtents.y;
		Vector2 boxSize = new Vector2 (colliderExtents.x, .1f);

		RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxSize, 0, Vector2.down,halfHeight + 0.1f);

		if (hit.collider && hit.collider.gameObject.tag == "Solid") {
			return true;
		} else {
			return false;
		}
	}

	public Vector2 isTouchingSolid() {
		return Vector2.zero;
	}
}
