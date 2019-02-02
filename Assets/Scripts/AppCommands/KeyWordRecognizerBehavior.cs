using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using System;
using System.Text;
using UnityEngine.Windows.Speech;

struct VoiceCommands
{
    public string REMOVEMODEL
    {
        get
        {
            return "remove model";
        }
    }
    public string FULLMODEL
    {
        get
        {
            return "show full model";
        }
    }
    public string SHOWTIBIAIMPLANT
    {
        get
        {
            return "show tibia implant";
        }
    }
    public string SHOWTIBIAPLATEIMPLANT
    {
        get
        {
            return "show tibia plate implant";
        }

    }
    public string SHOWFEMURIMPLANT
    {
        get
        {
            return "show femur implant";
        }
    }
    public string SHOWVEIN
    {
        get
        {
            return "show veins";
        }
    }
    public string SHOWARTERIE
    {
        get
        {
            return "show arteries";
        }
    }
    public string SHOWMUSCLE
    {
        get
        {
            return "show muscles";
        }
    }
    public string REMOVEIMPLANT
    {
        get
        {
            return "remove implant";
        }
    }
    public string REMOVEMUSCLE
    {
        get
        {
            return "remove muscle";
        }
    }
    public string REMOVEVEIN
    {
        get
        {
            return "remove veins";
        }
    }
    public string REMOVEARTERIE
    {
        get
        {
            return "remove arteries";
        }
    }

    public string REMOVETIBIAIMPLANT
    {
        get
        {
            return "remove tibia implant";
        }
    }

    public string REMOVEFEMURIMPLANT
    {
        get
        {
            return "remove femur implant";
        }
    }
    public string REMOVETIBIAPLATEIMPLANT
    {
        get
        {
            return "remove tibia plate implant";
        }
    }
    
};

[RequireComponent(typeof(KneePartManager))]
public class KeyWordRecognizerBehavior : MonoBehaviour {

    private string[] Keywords_array;

    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    private readonly ConfidenceLevel msgConf = ConfidenceLevel.Medium;
    private VoiceCommands vc;
    KeywordRecognizer myPhrase;
    KneePartManager manager;

    private void SetUpVoiceCommands()
    {
        keywords.Add(vc.REMOVEMODEL, () =>
        {
            // Call the OnReset method on every descendant object.
            manager.ShowFullKnee(false);
        });
        keywords.Add(vc.FULLMODEL, () =>
        {
            manager.ShowFullKnee(true);
        });

        keywords.Add(vc.SHOWTIBIAIMPLANT, () =>
        {
            // Call the OnReset method on every descendant object.
            manager.tibiaImplant.SetActive(true);
        });
        keywords.Add(vc.SHOWTIBIAPLATEIMPLANT, () =>
        {
            // Call the OnReset method on every descendant object.
            manager.tibiaPlateImplant.SetActive(true);

        });
        keywords.Add(vc.SHOWFEMURIMPLANT, () =>
        {
            // Call the OnReset method on every descendant object.
            manager.femurImplant.SetActive(true);

        });

        keywords.Add(vc.SHOWMUSCLE, () =>
        {
            // Call the OnReset method on every descendant object.
            manager.muscleLayer.SetActive(true);
        });
        keywords.Add(vc.SHOWVEIN, () =>
        {
            // Call the OnReset method on every descendant object.
            manager.veins.SetActive(true);
        });
        keywords.Add(vc.SHOWARTERIE, () =>
        {
            // Call the OnReset method on every descendant object.
            manager.arteries.SetActive(true);
        });

        keywords.Add(vc.REMOVETIBIAIMPLANT, () =>
        {
            // Call the OnReset method on every descendant object.
            manager.tibiaImplant.SetActive(false);
        });
        keywords.Add(vc.REMOVEFEMURIMPLANT, () =>
        {
            // Call the OnReset method on every descendant object.
            manager.femurImplant.SetActive(false);
        });
        keywords.Add(vc.REMOVETIBIAPLATEIMPLANT, () =>
        {
            // Call the OnReset method on every descendant object.
            manager.tibiaPlateImplant.SetActive(false);
        });

        keywords.Add(vc.REMOVEMUSCLE, () =>
        {
            // Call the OnReset method on every descendant object.
            manager.muscleLayer.SetActive(false);
        });
        keywords.Add(vc.REMOVEVEIN, () =>
        {
            // Call the OnReset method on every descendant object.
            manager.veins.SetActive(false);
        });
        keywords.Add(vc.REMOVEARTERIE, () =>
        {
            // Call the OnReset method on every descendant object.
            manager.arteries.SetActive(false);
        });

    }
    // Use this for initialization
    void Start()
    {
        manager = gameObject.GetComponent<KneePartManager>();

        SetUpVoiceCommands();
       

        // instantiate keyword recognizer, pass keyword array in the constructor
        myPhrase = new KeywordRecognizer(keywords.Keys.ToArray());
        myPhrase.OnPhraseRecognized += OnKeywordsRecognized;
        // start keyword recognizer
        myPhrase.Start();
               
    }

    void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Keyword: " + args.text + "; Confidence: " + args.confidence + "; " +
         "Start Time: " + args.phraseStartTime + "; Duration: " + args.phraseDuration);

        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
