/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class Window_QuestPointer : MonoBehaviour
{

    [SerializeField] private Camera uiCamera;
    [SerializeField] private Sprite arrowSprite;
    [SerializeField] private Sprite crossSprite;



    private List<QuestPointer> questPointerList;

    private void Awake()
    {
        questPointerList = new List<QuestPointer>();
    }

    private void Update()
    {
        foreach (QuestPointer questPointer in questPointerList)
        {
            questPointer.Update();
            questPointer.LateUpdate();
        }
    }

    public QuestPointer CreatePointer(Vector3 targetPosition, Planet planetPointer)
    {
        GameObject pointerGameObject = Instantiate(transform.Find("pointerTemplate").gameObject);
        pointerGameObject.SetActive(true);
        pointerGameObject.transform.SetParent(transform, false);
        QuestPointer questPointer = new QuestPointer(targetPosition, pointerGameObject, uiCamera, arrowSprite, crossSprite, planetPointer);
        questPointerList.Add(questPointer);
        return questPointer;
    }

    public void DestroyPointer(QuestPointer questPointer)
    {
        questPointerList.Remove(questPointer);
        questPointer.DestroySelf();
    }

    public class QuestPointer
    {
        [SerializeField]
        public GameObject player;
        private Vector3 targetPosition;
        private GameObject pointerGameObject;
        private Sprite arrowSprite;
        private Sprite crossSprite;
        private Camera uiCamera;
        private RectTransform pointerRectTransform;
        private Image pointerImage;
        private Planet planet;
        Vector2 ViewportPos;

        public QuestPointer(Vector3 targetPosition, GameObject pointerGameObject, Camera uiCamera, Sprite arrowSprite, Sprite crossSprite, Planet planet)
        {
            this.targetPosition = targetPosition;
            this.pointerGameObject = pointerGameObject;
            this.uiCamera = uiCamera;
            this.arrowSprite = arrowSprite;
            this.crossSprite = crossSprite;
            this.planet = planet;

            pointerRectTransform = pointerGameObject.GetComponent<RectTransform>();
            pointerImage = pointerGameObject.GetComponent<Image>();

            player = GameObject.FindGameObjectWithTag("Player");
        }

        
        public void Update()
        {
            float borderSize = 100f;
            Vector3 targetPositionScreenPoint = Camera.main.WorldToScreenPoint(targetPosition);
            bool isOffScreen = targetPositionScreenPoint.x <= borderSize || targetPositionScreenPoint.x >= Screen.width - borderSize || targetPositionScreenPoint.y <= borderSize || targetPositionScreenPoint.y >= Screen.height - borderSize;

            RotatePointerTowardsTargetPosition();
            //pointerRectTransform.position = new Vector3(uiCamera.pixelWidth / 2, uiCamera.pixelHeight / 2);
            //Debug.Log(uiCamera.WorldToViewportPoint(player.transform.position, uiCamera.stereoActiveEye));
            //pointerRectTransform.position = uiCamera.WorldToScreenPoint(player.transform.position);

            ViewportPos = Camera.main.WorldToViewportPoint(player.transform.position);
            //pointerRectTransform.position = new Vector2(Screen.width * ViewportPos.x, Screen.height * ViewportPos.y);

            if (planet.isPlanted())
            {
                this.pointerGameObject.GetComponent<Image>().color = Color.green;
            }
            if(Vector3.Distance(player.transform.position, targetPosition) > 45f)
            {
                this.pointerGameObject.SetActive(false);
            }
            else
            {
                this.pointerGameObject.SetActive(true);
            }

            /*
            if (isOffScreen)
            {
                RotatePointerTowardsTargetPosition();

                pointerImage.sprite = arrowSprite;
                Vector3 cappedTargetScreenPosition = targetPositionScreenPoint;
                cappedTargetScreenPosition.x = Mathf.Clamp(cappedTargetScreenPosition.x, borderSize, Screen.width - borderSize);
                cappedTargetScreenPosition.y = Mathf.Clamp(cappedTargetScreenPosition.y, borderSize, Screen.height - borderSize);

                Vector3 pointerWorldPosition = uiCamera.ScreenToWorldPoint(cappedTargetScreenPosition);
                pointerRectTransform.position = pointerWorldPosition;
                pointerRectTransform.localPosition = new Vector3(pointerRectTransform.localPosition.x, pointerRectTransform.localPosition.y, 0f);
            }
            else
            {
                pointerImage.sprite = crossSprite;
                Vector3 pointerWorldPosition = uiCamera.ScreenToWorldPoint(targetPositionScreenPoint);
                pointerRectTransform.position = pointerWorldPosition;
                pointerRectTransform.localPosition = new Vector3(pointerRectTransform.localPosition.x, pointerRectTransform.localPosition.y, 0f);

                pointerRectTransform.localEulerAngles = Vector3.zero;
            }
            */
        }

        public void LateUpdate()
        {
            pointerRectTransform.position = new Vector2(Screen.width * ViewportPos.x, Screen.height * ViewportPos.y);
        }

        private void RotatePointerTowardsTargetPosition()
        {
            Vector3 toPosition = targetPosition;
            Vector3 fromPosition = Camera.main.transform.position;
            fromPosition.z = 0f;
            Vector3 dir = (toPosition - fromPosition).normalized;
            float angle = UtilsClass.GetAngleFromVectorFloat(dir);
            pointerRectTransform.localEulerAngles = new Vector3(0, 0, angle);
        }

        public void DestroySelf()
        {
            Destroy(pointerGameObject);
        }

    }
}
