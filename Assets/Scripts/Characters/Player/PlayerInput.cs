using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    string moveVerAxis = "Vertical";
    string moveHorAxis = "Horizontal";
    string jumpButton = "Jump";
    string interactionButton = "Interaction";
    string attackButton = "Fire1";
    string defenseButton = "Fire2";

    public float moveVertical { get; private set; }
    public float moveHorizontal { get; private set; }
    public bool jump { get; private set; }
    public bool interaction { get; private set; }
    public bool attack { get; private set; }
    public bool defense { get; private set; }

    void Update()
    {
        moveVertical = Input.GetAxisRaw(moveVerAxis);
        moveHorizontal = Input.GetAxisRaw(moveHorAxis);
        jump = Input.GetButtonDown(jumpButton);

        interaction = Input.GetButtonDown(interactionButton);

        attack = Input.GetButtonDown(attackButton);
        defense = Input.GetButton(defenseButton);
    }
}
