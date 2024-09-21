using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BridgeDestruction : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem bridgeParticles;

    [SerializeField]
    private GameObject particlePosition;

    [SerializeField]
    private GameObject ball;

    private bool destroyed;
    private ParticleSystem bridgeSystem;

    [SerializeField]
    private Color32[] colors;
    [SerializeField]
    private Color32[] bridgeColors;
    [SerializeField]
    private Color32[] waterColors;

    private float x;
    private float y;
    private float z;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(-1.25f, 1.25f);
        y = transform.position.y;
        z = transform.position.z;
        pos = new Vector3(x, y, z);
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        Cursor.visible = false;
    }

    private void LateUpdate() 
    {
        if(destroyed)
        {
            ParticleSystem.Particle[] particles = new ParticleSystem.Particle[bridgeSystem.main.maxParticles];
            int numOfParticlesAlive = bridgeSystem.GetParticles(particles);
            for (int i = 0; i < numOfParticlesAlive; i++)
            {
                particles[i].startColor = colors[Random.Range(0, colors.Length)];
            }
            bridgeSystem.SetParticles(particles, numOfParticlesAlive);
            destroyed = false;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        destroyed = true;
        if(other.tag == "BridgeSupport")
        {
            other.gameObject.SetActive(false);
            bridgeSystem = Instantiate(bridgeParticles, particlePosition.transform.position, Quaternion.identity);
            colors = bridgeColors;
        }
        if(other.tag == "Water")
        {
            bridgeSystem = Instantiate(bridgeParticles, particlePosition.transform.position, Quaternion.identity);
            colors = waterColors;
        }
    }
}
