namespace Game
{
    using UnityEngine;

    public class InputManager
    {
        public float Horizontal { get; private set; }
        public float Jump { get; private set; }


        public void Execute()
        {
            Horizontal = Input.GetAxis(InputName.Horizontal);
            Jump = Input.GetAxis(InputName.Jump);
        }
    }
}