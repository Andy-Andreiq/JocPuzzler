//foloseste engine-ul creat de unity special pentru audio
using UnityEngine.Audio;
using System;
using UnityEngine;
//nume script ,Manager Audio
public class AudioManager : MonoBehaviour
{
    
    private bool soundplay = false;
    //variabila de tip Sound[](comanda predefinita pentru activarea sunetului)
    public Sound[] sounds;
    //referinta la Un Grup de audiomixere, pentru ajustarea sunetului(comanda predefinita)
    public AudioMixerGroup audioMixer;
    //variabila de tip AudioManager care verifica existenta acestuia
    public static AudioManager instance;
    //subprogram predefinit activat cand este cerut
    void Awake()
    {//verificarea daca nu exista vreun AudioManager si creaza altul.
        //altfel daca exista , cel nou este distrus , si actiunea se repeta
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        //comanda predefinita , pentru fiecare s(variabila in Comanda Sound(Comanda predefinita unity))
        //in variabila sounds, creaza campurile care adauga o sursa audio, inregistreaza clipul de pe sursa
        //inregistreaza volumul, pitchul(viteza),daca vrem sa il facem in continuu si care inregistreaza mixerulaudio
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = audioMixer;

        }
    }
    //subprogram predefinit, care se activeaza o data cu startul scenei
    void Start()
    {
        //Foloseste comanda Play ,pentru a incepe muzica, imediat cu incarcarea scenei
        Play("padure");
        Play("Meniu");
        Play("Desert");
        Play("vulcan");
        Play("Iarna");
        Play("Meniustart");
        Play("Labirint")
;    }
    //subprogram pentru activarea sunetului, care cere numele sunetului respectiv
    public void Play(string name)
    {//variabila s, cauta in aria de sunete ,sunetul cu numele introdus , si activeaza comanda foreach
        Sound s = Array.Find(sounds, sound => sound.name == name);
        //daca nu il gaseste, s se intoarce si repeta procesul
        if (s == null)
            return;
        //daca in sciptul pauza ,pauz este adevarat , atunci sunetul incepe din nou.
        if (pauza.pauz)
        {
            s.source.pitch = 1f;
        }
        //din s , cauta sursa si activeaza subprogramul
        s.source.Play();
    }
    //subprogram folosit pentru oprirea unui sunet
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;

        if (pauza.pauz)
        {
            s.source.pitch = 1f;
        }

        s.source.Stop();
    }
}

