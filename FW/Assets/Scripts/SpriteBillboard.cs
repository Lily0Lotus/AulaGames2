using UnityEngine;

public class SpriteBillboard : MonoBehaviour
{
    [SerializeField]
    bool congelarAxisYZ = true;
    private void Update()
    {
        if (congelarAxisYZ)
        {
            transform.rotation = Quaternion.Euler(Camera.main.transform.rotation.eulerAngles.x, 0f, 0f);
        }
        else 
        {
            transform.rotation = Camera.main.transform.rotation;
        }
    }
}
