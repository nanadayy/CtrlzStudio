using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickCharacter : MonoBehaviour
{
    [Header("ClickObject")]
    [Tooltip("ĳ���� Ŭ���ϸ� �Լ� �߻��ϰ� Raycast�� ����� �˴ϴ�.")]
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
            


            // Ray�� Ư�� ������Ʈ�� �浹�ߴ��� �˻��մϴ�.
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == targetObject )
            {
                // Ư�� ������Ʈ�� Ŭ���Ǿ��� ���� ������ �ۼ��մϴ�.
                if (DialogUI.gameObject.activeSelf)
                {
                    smoothCamera.isActivated = true;
                   
                    canClick = true;
                    Invoke("DialogPlay", 2);
                    DialogUI.gameObject.SetActive(false);
                    Debug.Log("����Ŭ��");
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