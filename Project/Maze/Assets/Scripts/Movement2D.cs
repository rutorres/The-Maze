using System.Collections;
using UnityEngine;

public class Movement2D : MonoBehaviour
{

	public enum ShapeMode { Circle, Box }

	public LayerMask layerMask = -1;

	public ShapeMode shapeMode;

	public float radius = 0.5f; 

	public Vector2 size = Vector2.one;

	public Vector2 offsetFromPivot;

	public bool isMovingUsingSmoothMove
	{
		get
		{
			return isMoving;
		}
	}

	private RaycastHit2D[] hits; 
	private Transform myTransform;
	private Rigidbody2D myRigidbody2D;
	private Vector2 motion; 
	private Vector2 targetCell; 
	private Vector2 motionInGrid; 
	private bool isMoving = false;
	private Vector2 safeMotion;

	private void Awake()
	{
		myTransform = transform;
		motion = Vector2.zero; 
		safeMotion = Vector2.zero;
	}
		
	public void SetMovementPropertiesFromCollider()
	{
		CircleCollider2D cc = GetComponent<CircleCollider2D>();
		if (cc != null)
		{
			radius = cc.radius * Mathf.Max(myTransform.localScale.x, myTransform.localScale.y);
			shapeMode = ShapeMode.Circle;
		}

		BoxCollider2D box = GetComponent<BoxCollider2D>();
		if (box != null)
		{
			shapeMode = ShapeMode.Box;
			size = box.size;
		}
	}
		
	public bool MoveAlongX(float distance)
	{
		motion = Vector3.zero;
		motion.x = distance;
		return Move(myTransform.TransformPoint(motion) - myTransform.position);
	}
		
	public bool MoveAlongY(float distance)
	{
		motion = Vector3.zero;
		motion.y = distance;
		return Move(myTransform.TransformPoint(motion) - myTransform.position);
	}

	public Vector2 TryMove(Vector2 motion)
	{
		if (CanMoveTo(motion, ref safeMotion))
		{
			MoveGameObjectToPosition(motion);
		}
		else
		{
			MoveGameObjectToPosition(safeMotion);
		}
		return safeMotion;
	}
		
	public Vector2 TryMove(float x, float y, float z)
	{
		motion.x = x;
		motion.y = y;

		return TryMove(motion);
	}

	public bool Move(float x, float y)
	{
		motion.x = x;
		motion.y = y;

		return Move(motion);
	}

	public bool Move(Vector2 motion)
	{
		if (CanMoveTo(motion))
		{
			MoveGameObjectToPosition(motion);
			return true;
		}
		return false;
	}

	private void MoveGameObjectToPosition(Vector2 motion)
	{
		if (myRigidbody2D)
		{
			myRigidbody2D.MovePosition(myRigidbody2D.position + motion);
		}
		else
		{
			myTransform.position += new Vector3(motion.x, motion.y, 0.0f);
		}
	}

	private void SetGameObjectPosition(Vector3 position)
	{
		if (myRigidbody2D)
		{
			myRigidbody2D.MovePosition(position);
		}
		else
		{
			myTransform.position = position;
		}
	}

	public bool CanMoveTo(Vector2 motion, ref RaycastHit2D[] hits)
	{
		if (shapeMode == ShapeMode.Circle)
			hits = Physics2D.CircleCastAll(myTransform.position + (Vector3)offsetFromPivot, radius, motion, motion.magnitude, layerMask);
		else if (shapeMode == ShapeMode.Box)
			hits = Physics2D.BoxCastAll(transform.position + (Vector3)offsetFromPivot, (Vector3)size, 0.0f, motion, motion.magnitude, layerMask);
		foreach (RaycastHit2D hit in hits)
		{
			if (hit.transform.GetInstanceID() != myTransform.GetInstanceID())
			{
				return false;
			}
		}
		return true;
	}

	public bool CanMoveTo(Vector2 motion)
	{
		return CanMoveTo(motion, ref hits);
	}
	public bool CanMoveTo(float x, float y)
	{
		motion.x = x;
		motion.y = y;

		return CanMoveTo(motion);
	}

	public bool CanMoveTo(float x, float y, float z, ref Vector2 safeMotion)
	{
		motion.x = x;
		motion.y = y;
		return CanMoveTo(motion, ref safeMotion);
	}

	public bool CanMoveTo(Vector2 motion, ref Vector2 safeMotion, ref RaycastHit2D[] hits)
	{
		if (shapeMode == ShapeMode.Circle)
			hits = Physics2D.CircleCastAll(myTransform.position + new Vector3(offsetFromPivot.x, offsetFromPivot.y, 0.0f), radius, motion, motion.magnitude, layerMask);
		else if (shapeMode == ShapeMode.Box)
			hits = Physics2D.BoxCastAll(transform.position + new Vector3(offsetFromPivot.x, offsetFromPivot.y, 0.0f), new Vector3(size.x, size.y, 0.0f), 0.0f, motion, motion.magnitude, layerMask);
		foreach (RaycastHit2D hit in hits)
		{
			if (hit.transform.GetInstanceID() != myTransform.GetInstanceID())
			{
				safeMotion = ((myTransform.position - (Vector3)hit.point).magnitude - ((shapeMode == ShapeMode.Circle) ? radius : Mathf.Max(size.x, size.y))) * motion.normalized;
				return false;
			}
		}
		return true;
	}

	public bool CanMoveTo(Vector2 motion, ref Vector2 safeMotion)
	{
		return CanMoveTo(motion, ref safeMotion, ref hits);
	}
		
	public IEnumerator SmoothGridMoveCoroutine(Vector2 motion, float speed, bool checkCollision)
	{
		if (checkCollision)
		{
			if (!CanMoveTo(motion)) yield break;
		}
		targetCell = myTransform.position + (Vector3)motion;
		var distance = Vector3.Distance(myTransform.position, targetCell);
		var initialPosition = myTransform.position;
		isMoving = true;
		float weight = 0;
		while (weight < 1)
		{
			weight += Time.deltaTime * speed / distance;
			SetGameObjectPosition(Vector2.Lerp(initialPosition, targetCell, weight));
			yield return null;
		}
		myTransform.position = targetCell;
		isMoving = false;
	}
	public void SmoothGridMove(Vector2 motion, float speed, bool checkColision)
	{
		StartCoroutine(SmoothGridMoveCoroutine(motion, speed, checkColision));
	}

	public void SmoothGridMove(float x, float y, float speed, bool checkColision)
	{
		Vector2 motion = new Vector3(x, y);
		StartCoroutine(SmoothGridMoveCoroutine(motion, speed, checkColision));
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.cyan;
		if (shapeMode == ShapeMode.Circle)
			Gizmos.DrawWireSphere(transform.position + new Vector3(offsetFromPivot.x, offsetFromPivot.y, 0.0f), radius);
		else if (shapeMode == ShapeMode.Box)
		{
			Gizmos.DrawWireCube(transform.position + new Vector3(offsetFromPivot.x, offsetFromPivot.y, 0.0f), new Vector3(size.x, size.y, 0.0f));
		}
	}
}