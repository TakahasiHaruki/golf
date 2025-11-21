using UnityEngine;

public class ShowLegacyTextOnHit : MonoBehaviour
{
    private bool showMessage = false;
    public string message = "ぶつかった！（レガシーUI）";

    void OnCollisionEnter(Collision collision)
    {
        showMessage = true;
    }

    void OnGUI()
    {
        if (showMessage)
        {
            GUI.Label(new Rect(10, 10, 300, 30), message);
        }
    }
}
