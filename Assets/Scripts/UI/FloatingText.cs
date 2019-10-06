using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour 
{

	[SerializeField] private Animator animator;
    [SerializeField] private TMPro.TextMeshProUGUI m_Text = null;

    public string Text {
        get {
            return m_Text.text;
        }
        set {
            m_Text.SetText(value);
        }
    }

    public Color Color {
        get {
            return m_Text.color;
        }
        set {
            m_Text.color = value;
        }
    }

	void Start () 
	{
		AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo (0);

		Destroy (this.gameObject, clipInfo[0].clip.length);
	}
}
