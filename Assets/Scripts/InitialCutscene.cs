using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialCutscene : MonoBehaviour
{
    [SerializeField] GameObject cutsceneCamera;
    [SerializeField] GameObject van;

    private bool moveCamera = false;
    private bool moveVan = false;
    public void StartCutscene()
    {
        moveCamera = true;
    }
    private void Update()
    {
        if (moveCamera)
        {
            cutsceneCamera.transform.position = Vector3.MoveTowards(cutsceneCamera.transform.position, new Vector3(0, -1.05f, -10), Time.deltaTime);
        }

        if (moveVan)
        {
            van.transform.position = Vector3.MoveTowards(van.transform.position, new Vector3(6.51f, -3.76f, 0), Time.deltaTime);
        }
    }

    private IEnumerator VanIn()
    {
        moveVan = true;
        yield return new WaitForSeconds(5);

    }
}
