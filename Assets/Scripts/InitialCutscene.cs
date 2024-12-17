using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InitialCutscene : MonoBehaviour
{
    [SerializeField] GameObject menuUI;

    [SerializeField] GameObject cutsceneCamera;
    [SerializeField] GameObject van;
    [SerializeField] GameObject chopaki;

    private bool moveCamera = false;
    private bool moveVan = false;
    public void StartCutscene()
    {
        chopaki.SetActive(false);
        menuUI.SetActive(false);
        moveCamera = true;
    }
    private void Update()
    {
        if (moveCamera)
        {
            cutsceneCamera.transform.position = Vector3.MoveTowards(cutsceneCamera.transform.position, new Vector3(0, -1.05f, -10), 7*Time.deltaTime);
            if (cutsceneCamera.transform.position == new Vector3(0, -1.05f, -10))
            {
                moveVan = true;
            }
        }

        if (moveVan)
        {
            van.transform.position = Vector3.MoveTowards(van.transform.position, new Vector3(6.51f, -3.76f, 0), 10*Time.deltaTime);
            if (van.transform.position == new Vector3(6.51f, -3.76f, 0))
            {
                StartCoroutine(VanIn());
            }
        }
    }

    private IEnumerator VanIn()
    {
        van.GetComponent<Animator>().Play("van_stopping");
        yield return new WaitForSeconds(0.83f);

        chopaki.SetActive(true);
        yield return new WaitForSeconds(2f);

        Time.timeScale = 0;
        SceneManager.LoadScene("Level1");
    }
}
