
using UnityEngine;

public class InputManager
{
    public float Horizontal;
    public float Jump;

    private ConstanceName _constanteName = new ConstanceName();

    public void Execute()
    {
        Horizontal = Input.GetAxis(_constanteName.Horizontal);
        Jump = Input.GetAxis(_constanteName.Jump);
    }
}

