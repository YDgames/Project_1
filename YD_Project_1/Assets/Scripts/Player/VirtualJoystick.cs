using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler  {

	private Image bgImg, joystickImg;
	private Vector3 inputVector;
	private CanvasGroup canvasGroup;

	private void Start(){
		canvasGroup = GetComponent<CanvasGroup> ();
		bgImg = transform.GetChild(0).GetComponent<Image> ();	
		joystickImg = transform.GetChild (0).GetChild(0).GetComponent<Image> ();
		setVisible (false);
	}

	public virtual void OnPointerDown(PointerEventData eventData){
		transform.GetChild(0).position = new Vector3(eventData.pressPosition.x, eventData.pressPosition.y);
		setVisible (true);
		OnDrag (eventData);
	}

	public virtual void OnPointerUp(PointerEventData eventData){
		setVisible (false);
		inputVector = Vector3.zero;
		joystickImg.rectTransform.anchoredPosition = inputVector;
	}

	public virtual void OnDrag(PointerEventData eventData){
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (bgImg.rectTransform, eventData.position, eventData.pressEventCamera, out pos)) {
			pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
			pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

			inputVector = new Vector3 (pos.x * 2, 0, pos.y * 2);
			inputVector = inputVector.magnitude > 1.0f ? inputVector.normalized : inputVector;

			// Joystick Image move
			joystickImg.rectTransform.anchoredPosition = new Vector3(inputVector.x *(bgImg.rectTransform.sizeDelta.x/2)
																	, inputVector.z *(bgImg.rectTransform.sizeDelta.y/2));
		}
	}

	public float Horizontal(){
		if (inputVector.x != 0)
			return inputVector.x;
		else
			return Input.GetAxis ("Horizontal");
	}

	public float Vertical(){
		if (inputVector.z != 0)
			return inputVector.z;
		else
			return Input.GetAxis ("Vertical");
	}

	public void setVisible(bool enable){
		canvasGroup.alpha = enable ? 1f : 0f;
	}
}
