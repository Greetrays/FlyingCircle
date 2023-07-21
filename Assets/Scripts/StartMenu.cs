using UnityEngine;

public class StartMenu : MonoBehaviour
{
    private void Start() => Time.timeScale = 0;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }
    }
}
