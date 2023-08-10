using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorKeeper : MonoBehaviour
{
    [SerializeField]
    private GameObject door;
    [SerializeField]
    private TextMesh text;
    [SerializeField]
    private GameObject arrowSign;
    [SerializeField]
    private GameObject exitTrigger;

    public void LoadRandomLevel()
    {
        int nextLevel = Random.Range(0, SceneManager.sceneCountInBuildSettings -1);

        SceneManager.LoadScene(nextLevel);
    }

    public void RefreshLevelText()
    {
        text.text = GameManager.CurrentLevel.ToString();
    }

    public void OpenDoor()
    {
        door.SetActive(false);
        arrowSign.SetActive(true);
        exitTrigger.SetActive(true);

    }
}
