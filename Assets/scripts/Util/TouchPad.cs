using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class TouchPad : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler {
	//PointerEventData touch;
	bool bTouch;
	Vector2 dir;
	int pointerID;
	Vector2 origin;

	public void OnPointerDown(PointerEventData _touch){
		//Debug.Log ("OnPointerDown");
		if (!bTouch) {
			bTouch = true;
			dir = Vector2.zero;

			pointerID = _touch.pointerId;
			origin = _touch.position;
		}
	}


	public void OnDrag(PointerEventData _touch){
		//Debug.Log ("OnDrag");
		if (bTouch && pointerID == _touch.pointerId) {
			dir = (_touch.position - origin).normalized;
			//Debug.Log ("OnDrag" + dir);
		}
	}

	public void OnPointerUp(PointerEventData _touch){
		//Debug.Log ("OnPointerUp");
		if (bTouch) {
			bTouch = false;
			dir = Vector2.zero;
		}
	}

	public Vector2 GetDirection(){
		return dir;
	}

}
