using System.Collections.Generic;
using UnityEngine;

public class SetUpSprites : MonoBehaviour
{
    [SerializeField]
    GameObject[] prefabs;

    readonly List<GameObject> choices = new(4);
    readonly Vector2[] positions = new Vector2[4];

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            positions[i] = transform.GetChild(i).position;
            choices.Add(Instantiate(ChooseNextPrefab));
        }
    }

    void Update()
    {
        Draw();
        Next();
    }

    void Next()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            choices[0].GetComponent<Rigidbody2D>().gravityScale = 1;
            choices.RemoveAt(0);
            choices.Add(Instantiate(ChooseNextPrefab));
        }
    }

    void Draw()
    {
        for (int i = 0; i < choices.Count; i++)
        {
            choices[i].transform.position = positions[i];
        }
    }

    GameObject ChooseNextPrefab => prefabs[Random.Range(0, prefabs.Length)];
}
