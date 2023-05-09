using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickCharacter : MonoBehaviour
{
    [Header("ClickObject")]
    [Tooltip("캐릭터 클릭하면 함수 발생하게 Raycast의 대상이 됩니다.")]
    public GameObject targetObject;

    [Header("Dialog")]
    public GameObject Dialog; 
   // public Text dialogText;


    [Header("DialogUI")]
    public Image DialogUI;
    public int ActiveUITime;
    
    [Header("Script")]
    public SmoothCamera smoothCamera;
    public DialogManager dialogManager;

   
    private bool canClick = false;

   

    void Start()
    {
        
        smoothCamera.isActivated = false;
        dialogManager.isRunning = false;

        Invoke("ActiveUI", ActiveUITime);
        canClick = false;

        DialogUI.transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            


            // Ray가 특정 오브젝트와 충돌했는지 검사합니다.
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == targetObject )
            {
                // 특정 오브젝트가 클릭되었을 때의 동작을 작성합니다.
                if (DialogUI.gameObject.activeSelf)
                {
                    smoothCamera.isActivated = true;
                   
                    canClick = true;
                    Invoke("DialogPlay", 2);
                    DialogUI.gameObject.SetActive(false);
                    Debug.Log("나비클릭");
                }
               
            }

        }


    }



    void DialogPlay()
    {
        Dialog.SetActive(true);
        dialogManager.isRunning = true;
    }


    private void ActiveUI()
    {
        DialogUI.gameObject.SetActive(true);
        DialogUI.transform.localScale = new Vector3(1, 1, 1);
    }

}