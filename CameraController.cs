using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 target;
    float targetZoom = 0f;

    CameraShot defaultCam;

    [SerializeField]
    CameraShot playerAction;

    [SerializeField]
    CameraShot enemyAction;

    Camera c = null;

    [SerializeField]
    GameObject[] scaleWith;

    private void Awake()
    {
        c = GetComponent<Camera>();

        target = transform.position;
        targetZoom = c.orthographicSize;

        defaultCam = new CameraShot(target, targetZoom);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * 10f);
        c.orthographicSize = Mathf.Lerp(c.orthographicSize, targetZoom, Time.deltaTime * 10f);

        Vector3 tg = new Vector3((1.0f / 5.0f) * targetZoom * 0.8f, (1.0f / 5.0f) * targetZoom * 0.8f, 1f);
        
        foreach (GameObject o in scaleWith)
        {
            o.transform.localScale = Vector3.Lerp(o.transform.localScale, tg, Time.deltaTime * 10f);
        }
    }

    public void PlayerActionShot()
    {
        target = playerAction.GetPosition();
        targetZoom = playerAction.GetZoom();
    }

    public void EnemyActionShot()
    {
        target = enemyAction.GetPosition();
        targetZoom = enemyAction.GetZoom();
    }

    public void DefaultShot()
    {
        target = defaultCam.GetPosition();
        targetZoom = defaultCam.GetZoom();
    }
}

[System.Serializable]
public class CameraShot
{
    [SerializeField]
    Vector2 position;
    [SerializeField]
    float zoom;

    public Vector3 GetPosition()
    {
        return new Vector3(position.x, position.y, -10f);
    }

    public float GetZoom()
    {
        return zoom;
    }

    public CameraShot(Vector2 position, float zoom)
    {
        this.position = position;
        this.zoom = zoom;
    }

    public CameraShot()
    {

    }
}