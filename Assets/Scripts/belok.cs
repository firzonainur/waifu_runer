using UnityEngine;

public class belok : MonoBehaviour
{
    public float belokSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            float degrees = 90;
            Vector3 to = new Vector3(0, degrees, 0);

            Camera.main.transform.eulerAngles = to;
            other.gameObject.transform.eulerAngles = to;
            other.gameObject.GetComponent<player>().offset = new Vector3(-9, 5, 0.3f);
        }
    }
}
