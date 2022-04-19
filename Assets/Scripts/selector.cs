using UnityEngine;

public class selector : MonoBehaviour {
    bool selected = false;
    [SerializeField]
    GameObject selectedEffect;

    private void OnMouseDown() {
        GameObject[] allSpawnPoints = GameObject.Find("GameController").GetComponent<GameController>().GetAllSpawnPoints();
        foreach(GameObject item in allSpawnPoints) {
            item.GetComponent<selector>().RemoveSelection();
        }
        selected = true;
        selectedEffect.SetActive(true);
        Debug.Log("selected"+gameObject.name);
    }
    public void RemoveSelection() {
        selected=false;
        Debug.Log("not selected"+gameObject.name);
        selectedEffect.SetActive(false);
    }
    public bool IsSelected() {
        return selected;
    }
}
