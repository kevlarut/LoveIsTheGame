using Assets.Scripts.NPCs;
using UnityEngine;
using System.Collections;
using UnityEventAggregator;

public class Conversation : MonoBehaviour, IListener<InitiateConversationDialogMessage> {
    
	// Use this for initialization
	void Start () {
        this.Register<InitiateConversationDialogMessage>();
	    SetVisibilityOfChildRenderers(false);
	}

    void OnDestroy()
    {
        this.UnRegister<InitiateConversationDialogMessage>();
    }
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetVisibilityOfChildRenderers(false);
        }
	}

    public void Handle(InitiateConversationDialogMessage message)
    {
        Debug.Log("InitiateConversationDialogMessage recieved.");
        SetVisibilityOfChildRenderers(true);
    }

    private void SetVisibilityOfChildRenderers(bool visible)
    {
        var renderers = gameObject.GetComponentsInChildren<Renderer>();
        Debug.Log("I'm setting visibility to " + visible + ".  Renderers = " + renderers.Length);
        foreach (var r in renderers)
        {
            r.enabled = visible;
        }
    }
}
