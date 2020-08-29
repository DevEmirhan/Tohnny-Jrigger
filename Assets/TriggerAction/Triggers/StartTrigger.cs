using UnityEngine;
using System.Collections;

public class StartTrigger : MonoBehaviour {
    public ActionBase Action;

    private void Start() {
        Action.Act();
    }
}
