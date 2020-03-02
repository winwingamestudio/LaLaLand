//using System;
//using UnityEngine;
//using UnityEngine.UI;
//using Random = System.Random;
//
//public class MouseController : MonoBehaviour
//{
//	public Text debugText;
//	
//	public string cloudTag = "clouds";
//
//	public DragDetector dragDetector;
//
//	public float DragValue = 20f;
//
//	
//	internal bool IsCloud;
//	private Vector3 firstPosition;
//
//	private Vector3 lastPosition;
//
//	private Vector2 touchedPosition;
//
//	private RaycastHit2D rayInfo;
//
//
//
//	public SwipeState SwipeState  { get; set; }
//	// Use this for initialization
//	void Awake ()
//	{
//		SwipeState = SwipeState.NotSwipe;
//		DragValue = 20f;
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//		if (true)
//		{
//			var toch = Input.GetTouch(0);
//
//			if (Input.GetMouseButton(0))
//			{
//				firstPosition = Input.mousePosition;
//				lastPosition = Input.mousePosition;
//				touchedPosition = Camera.main.ScreenToWorldPoint(firstPosition);
//
//				debugText.text = "touch begin";
////				Vector2 touchPosWorld2D = new Vector2(touchedPosition.x, touchedPosition.y);
//// 
////				//We now raycast with this information. If we have hit something we can process it.
////				rayInfo  = Physics2D.Raycast(touchedPosition, Camera.main.transform.forward);
//
//				RaycastHit2D hit;
//				Ray ray = Camera.main.ScreenPointToRay(firstPosition);
//				rayInfo = Physics2D.Raycast(firstPosition, Camera.main.transform.forward);	
//
//
//			} else if (toch.phase == TouchPhase.Moved)
//			{
//				lastPosition = Input.mousePosition;
//				
//			} else if (toch.phase == TouchPhase.Ended)
//			{
//				lastPosition = toch.position;
//
//				if (Mathf.Abs(lastPosition.x - firstPosition.x) > DragValue ||
//				    Mathf.Abs(lastPosition.y - firstPosition.y) > DragValue)
//				{
//					if (Mathf.Abs(lastPosition.x - firstPosition.x) > Mathf.Abs(lastPosition.y - firstPosition.y))
//					{
//
//
//						if (lastPosition.x > firstPosition.x)
//						{
//							// right
//							SwipeState = SwipeState.SwipeRight;
//							var GObj = DetectObject();
//							dragDetector.DetectDrag(SwipeState, GObj);
//							
//						}
//						else
//						{
//							// left
//							SwipeState = SwipeState.SwipeLeft;
//							var GObj = DetectObject();
//							dragDetector.DetectDrag(SwipeState, GObj);
//							//inActivate();
//						}
//					}
//					else 
//					{
//						if (lastPosition.y > firstPosition.y)
//						{
//							// up
//
//							SwipeState = SwipeState.SwipeUp;
//							//inActivate();
//						}
//						else
//						{
//							// down
//							SwipeState = SwipeState.SwipeDown;
//							//inActivate();
//						}
//					}
//				}
//			
//
//			}
//		}
//		else
//		{
//			SwipeState = SwipeState.NotSwipe;
//		}
//
//	}
//
//	private GameObject DetectObject()
//	{
//		var obj = rayInfo.rigidbody.gameObject;
//		var rigid = rayInfo.rigidbody;
//		if ( rayInfo.collider.CompareTag(cloudTag))
//		{
//			debugText.text = "touched";
//			IsCloud = true;
//			obj.GetComponent<SpriteRenderer>().color = new Color(UnityEngine.Random.Range(100, 122),UnityEngine.Random.Range(100, 122),UnityEngine.Random.Range(100, 122));
//			return obj;
//		}
//		
//		throw new Exception("not cloud");
//	}
//
//}
