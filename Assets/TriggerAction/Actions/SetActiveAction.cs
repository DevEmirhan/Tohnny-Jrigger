using UnityEngine;
using System.Collections;

public class SetActiveAction : ActionBase {
    public GameObject GameObject;
    public bool Value;

    public override void Act() {
        GameObject.SetActive(Value);
    }
}
