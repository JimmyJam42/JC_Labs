using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : MonoBehaviour
{
	private Renderer ren;

	public float r, b, g, a;
	// Use this for initialization
	void Start()
	{
		
		r = Random.Range(0.0f, 1.0f);
		b = Random.Range(0.0f, 1.0f);
		g = Random.Range(0.0f, 1.0f);
		a = Random.Range(0.0f, 1.0f);

		ren = GetComponent<Renderer>();
		ren.material.color = new Color(r,g,b,a);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.W))
		{
			transform.Translate(Vector3.up);
		}
	}
}
