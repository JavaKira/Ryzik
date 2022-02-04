using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Joystick
{
    public class Joystick : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerUpHandler
    {
        [SerializeField] private GameObject cursor;

        public GameObject Cursor => cursor;

        public void OnDrag(PointerEventData eventData)
        {
            var touchId = eventData.pointerId;
            while (touchId > Input.touchCount - 1)
            {
                touchId--;
                if (touchId <= 0) break;
            }
            
            var position = Input.GetTouch(touchId).position;
            var mousePosition =
                new Vector3(position.x, position.y) - Camera.main.WorldToScreenPoint(transform.position);

            SetCursorPosition(mousePosition.x,
                mousePosition.y);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            ClearCursor();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            ClearCursor();
        }

        private void ClearCursor()
        {
            ((RectTransform) cursor.transform).localPosition = new Vector3(0, 0, 0);
        }

        private void SetCursorPosition(float x, float y)
        {
            var rad = ((RectTransform) transform).sizeDelta.x / 2;
            float curX, curY;

            var dx = x;
            var dy = y;

            var lenght = Mathf.Sqrt(dx * dx + dy * dy);
            if (lenght < rad)
            {
                curX = dx;
                curY = dy;
            }
            else
            {
                var k = rad / lenght;
                curX = dx * k;
                curY = dy * k;
            }

            ((RectTransform) cursor.transform).localPosition = new Vector2(curX, curY);
        }

        public Vector2 GetNormalized()
        {
            return ((RectTransform) cursor.transform).anchoredPosition.normalized;
        }

        public Vector2 GetRelativeCursorPosition()
        {
            return cursor.transform.position - transform.position;
        }
    }
}