using UnityEngine;


public sealed class PlayerKeyBindings {
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode attack = KeyCode.Mouse0;
    private static PlayerKeyBindings _instance;

    public static PlayerKeyBindings GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PlayerKeyBindings ();
            }
            return _instance;
        }

    public Vector3 getControllerPosition()
    {
        return Input.mousePosition;
    }
}