using UnityEngine;

public class Chain : MonoBehaviour
{
    public Rigidbody2D hook;

    public GameObject linkPrefab;
    public GameObject lastPrefab;

    public int links = 7;

    // Start is called before the first frame update
    void Start()
    {
        GenerateChain();
    }
    
    void GenerateChain()
    {
        Rigidbody2D previousRb = hook;
        for(int i = 0; i < links; i++)
        {
            GameObject link = Instantiate(linkPrefab, transform);
            HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
            joint.connectedBody = previousRb;

            previousRb = link.GetComponent<Rigidbody2D>();
        }
        GameObject end = Instantiate(lastPrefab, transform);
        HingeJoint2D lastJoint = end.GetComponent<HingeJoint2D>();
        lastJoint.connectedBody = previousRb;
    }
}
