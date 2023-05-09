using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Camera myCamera;
    public Transform Camera1;
    public Transform Camera2;
    public Transform Camera3;
    public float CameraSpeed;
    public bool isActivated;

    public GameObject Dialog;

    private float t = 0f;
    
    void Start()
    {
        isActivated = false;
        
    }
    void Update()
    {

        // �� ī�޶� ������ �Ÿ� ���
        if (isActivated)
        {
            float distance = Vector3.Distance(Camera1.position, Camera2.position);

            // ���� ��ġ���� ��ǥ ��ġ���� ������ ���� ����
            t = Mathf.Clamp01(t + Time.deltaTime / CameraSpeed);
            transform.position = Vector3.Lerp(Camera1.position, Camera2.position, t);
            transform.rotation = Quaternion.Lerp(Camera1.rotation, Camera2.rotation, t);

            // ī�޶� ũ�⵵ ����
            Camera.main.orthographicSize = Mathf.Lerp(Camera1.GetComponent<Camera>().orthographicSize,
                                                      Camera2.GetComponent<Camera>().orthographicSize, t);
        }

    }

    //��������� �Ѿ��
    public void MoveCupScene()
    {
        // �̵��� ��ġ�� Ȯ���ϰ� �غ� �Ǹ� ī�޶� �̵�
        myCamera.transform.position = Camera3.position;
        myCamera.transform.rotation = Camera3.rotation;
        myCamera.orthographicSize = Camera3.GetComponent<Camera>().orthographicSize;
        isActivated = false; // ���� ��� ����
        Dialog.SetActive(false);
    }
}