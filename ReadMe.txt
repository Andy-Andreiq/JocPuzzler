//Script pentru Un Perete invisibil (face parte din secret)
//Script pentru activarea secretului 1
//Campurile predefinite ale unity-ului, in C#;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//numele scriptului si clasa;
public class activate : MonoBehaviour
{  //declarare variabile atribuite 
    public GameObject stop;
    private bool odata = false;
 //metoda predefinita folosita cand intri intr-un boxcollider 
//( BoxColliderul Obiectului pe care e scriptul). care inregistreaza trecerea
    private void OnTriggerEnter(Collider other)
    {//conditie pentru activarea obiectelor
if (odata == false)
        {//Comanda predefinita care cauta in AudioManager un anumit sunet.
            FindObjectOfType<AudioManager>().Play("bam");
//Comanda predefinita care seteaza un timer(delay) 
//dupa care se activeaza un subprogram declarat ( timer 8 secunde , subprogram "trece")
            Invoke("trece", 8);
//variabila care realiza conditia o singura data ( devine adevarata )
            odata = true;
        }
    }
//metoda predefinita folosita cand iesi dintr-un boxcollider 
//(BoxColliderul Obiectului pe care e scriptul). care inregistreaza iesirea
    private void OnTriggerExit(Collider other)
    {
//Activeaza obiectul in cauza
        stop.SetActive(true);
    }
    private void trece()
    {
//Face referinta la obiectul in cauza , cauta componenta de pe BoxCollider , si activeaza optiunea de trigger 
//(care permite trecerea inapoi prin el)(Puteam sa il dezactivez direct dar acum am vazut :p )
        stop.GetComponent<BoxCollider>().isTrigger = true;
        
    }
}

//Script pentru Usa, activare animatii sunete si diferite variabile
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class Animatiiusa : MonoBehaviour
{
    // declarare variabile atribuite
    public GameObject usa;
    // face referinta la o componenta dintr-un alt script al altui obiect
    public PickUp bS;
    public Transform player;
    public Transform usatr;
    private bool razwan = false;
    public GameObject can;
    public GameObject text;
    private bool cabum = false;
    //Metoda predefinita de Unity care Updateaza constant actiunea
    void Update()
    {//conditie pentru activarea mai multor componente , in cazul in care apesi "e"
        // variabilele bs.cheie care reprezinta o componenta a scriptului PickUp
        // care inregistreaza daca ai o cheie in mana
        //razwan care reprezinta variabila care inregistreaza daca te afli intr-un BoxCollider de tip trigger
        //si cabum care reprezinta stagiul usi (daca e sau nu deschisa)
        if (Input.GetKey("e") && bS.cheie == true && razwan == true && cabum == false)
        {//in obiectul usa , cauta componenta animatii si o activeaza(deschidere)
                usa.GetComponent<Animation>().Play("Door_Open");
            //cauta AudioManagerul(un obiect) si ii da comanda de Play(care activeaza sunetul cu numele respectiv)
            FindObjectOfType<AudioManager>().Play("open");
            //foloseste Comanda predefinita de delay pe subprogramele "canta" si "inchisa"atribuindu-le un timp
            Invoke("Canta", 3);
            Invoke("inchisa", 20);
            //activeaza cabum, variabila care arata ca e deschisa
            cabum = true;
            
        }
        //conditie care se activeaza in cazul in care cheia lipseste(cheie este falsa)
        if(Input.GetKey("e") && bS.cheie == false && razwan == true)
        {
            //in obiectul usa cauta componenta animatie si o activeaza(blocare)
            usa.GetComponent<Animation>().Play("Door_Jam");
            //cauta un obiect AudioManager si ii da comanda Play ( care activeaza sunetul cu numele respectiv)
            FindObjectOfType<AudioManager>().Play("gem");
            //activeaza obiectul, care in cazul nostru este un canvas(Element UI)
            can.SetActive(true);
            //Ia componenta animatie din obiectul text si o activeaza;
           text.GetComponent<Animation>().Play("carton");
            //foloseste comanda predefinita pentru delay pe subprogramul dispare(3 secunde)
            Invoke("dispare", 3);
        }
    }
    //Verificare daca playerul este in Collider, razwan devine adevarata daca esti in Collider falsa daca iesi.
    private void OnTriggerEnter(Collider other)
    {
        razwan = true;
    }
    private void OnTriggerExit(Collider other)
    {
        razwan = false;
    }
    //subprogram care activeaza in AudioManager sunetul Cu numele respectiv
    void Canta()
    {
        
        FindObjectOfType<AudioManager>().Play("comoara");
    }
    //subprogram care dezactiveaza obiectul (canvasul)
    void dispare()
    {
        can.SetActive(false);
    }
    // Subprogram care activeaza Componenta usii, animatie, care inchide usa
    void inchisa()
    {
        usa.GetComponent<Animation>().Play("Door_Close");
        Invoke("bam", 2);
    }
    //subprogram care activeaza din nou usa
    void bam()
    {
        cabum = false;
    }        
        
}

//Script pentru aparitia de nivele noi , trofee si secrete
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// numele scriptului
public class apare : MonoBehaviour
{//definirea mai multor obiecte cu scopul de a le activa
    public GameObject trofeu;
    public GameObject trofeu2;
    public GameObject trofeu3;
    public GameObject trofeu4;
    public GameObject trofeu5;
    public GameObject Carte;
    public GameObject Disc;
    public GameObject Disc2;
    public GameObject mexican;
    public GameObject ciuperca;
    public GameObject tablou2;
    public GameObject tablou3;
    public GameObject tablou4;
    public GameObject tablou5;
    //verificare pentru diferite aspecte
    public bool exista = false;
    public bool e = false;
    void Update()
    {//conditii care cer ca in componenta SaveManager (un alt script)(baza de date) Sa caute conditiile
        //pentru completarea mai multor actiuni(Activarea unor noi nivele(tablouri)si aparitia trofeelor
        //cat si activarea secretelor)
        if(SaveManager.instance.lvl1 == true)
        {
            trofeu.SetActive(true);
            tablou2.SetActive(true);
        }
        if(SaveManager.instance.lvl2 == true)
        {
            trofeu2.SetActive(true);
            tablou3.SetActive(true);
            
        }
        if (SaveManager.instance.lvl3 == true)
        {
            trofeu3.SetActive(true);
            tablou4.SetActive(true);
            
        }
        if (SaveManager.instance.lvl4 == true)
        {
            trofeu4.SetActive(true);
            tablou5.SetActive(true);
            
        }
        if(SaveManager.instance.lvl5 == true)
        {
            trofeu5.SetActive(true);
        }
        if (SaveManager.instance.secret1 == true)
        {
            Carte.SetActive(true);
        }
        if (SaveManager.instance.secret3 == true)
        {
            Disc.SetActive(true);
            exista = true;
        }
        if(SaveManager.instance.secret22 == true)
        {
            mexican.SetActive(true);
        }
        if (SaveManager.instance.secret4 == true)
        {
            Disc2.SetActive(true);
            e = true;
        }
        if (SaveManager.instance.secret5 == true)
        {
            ciuperca.SetActive(true);
        }
    }
}

//Script pentru aparitia unui text la inceputul nivelului 1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//numele scriptului
public class arata : MonoBehaviour
{//definirea unor obiecte (canvas si text) si variabilei aparut
    public GameObject pp;
    public GameObject txt;
    private bool aparut = false;
    //subprogram care activeaza canvasul si da Play la componenta animation de pe obiectul text
    void mana()
    {
        pp.SetActive(true);
        txt.GetComponent<Animation>().Play("chei");
    }
    //Udateaza scena continuu
    private void Update()
    {//conditie , daca variabila aparut este false sa realizeze actiunea 
        //"aparut"este folosita pentru realizarea actiunii doar o data
        if (aparut == false)
        {// foloseste comanda predefinita de delay pe subprogramele "mana" si "inchide"
            //avand delay de 2 secunde si 5 secunde
            Invoke("mana", 2);
            Invoke("inchide", 5);
            //variabila "aparut" devine adevarata , deoarece actiunea s-a realizat deja
            aparut = true;
        }
    }
    //subprogram pentru dezactivarea canvasului
    void inchide()
    {
        pp.SetActive(false);
    }
}


//Script pentru activarea sunetului la fiecare nivel

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class audiolistener : MonoBehaviour
{ //variabila care activeaza optiunea doar o singura data
    private bool odata = false;

    void Update()
    {//conditie pentru activare , actiunea sa nu fi avut loc deja in scena
        if (odata == false)
        {
            //variabila predefinita care seteaza volumul audiolistenerului(un obiect predefinit)
            //care inregistreaza sunetul la 1 (adica volumul maxim)
            AudioListener.volume = 1f;
            //variabila devine adevarata pentru a nu se repeta actiunea
            odata = true;
        }
    }
}

//Script folosit pe un obiect de tip AudioManager care activeaza sunetele dorite

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
    //metoda predefinita activata cand este ceruta
    void Awake()
    {//verificarea daca nu exista vreun AudioSource cu acelasi sunet si creaza altul.
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
    //metoda predefinita, care se activeaza o data cu startul scenei
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


//Script pentru setarea puterii sariturii
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class boostsaritura : MonoBehaviour
{//variabile care fac referinta la niste scripturi din alte obiecte
    public trage dat;
    public trage2 da;
    public trage3 d;

    private void Update()
    {//conditie ca variabilele din scripturile respective sa fie adevarate
        if(dat.edat == true && da.edat1 == true && d.edat2 == true)
        {
            //cauta componenta in scriptul Miscare , si seteaza saritura la putere 10
            GetComponent<Miscare>().saritura = 10f;
        }
    }
}

//Script pentru apasarea butonului

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class Buton : MonoBehaviour
{//variabile care verifica conditii
    private bool mere = false;
    public bool apasat = false;

    //metode care verifica trecerea printr-un collider , setat pe obiectul respectiv
    private void OnTriggerEnter(Collider other)
    {
        mere = true;
    }
    private void OnTriggerExit(Collider other)
    {
        mere = false;
    }
    void Update()
    {//conditie care verifica daca apesi 'e' si daca treci prin collider
        if(Input.GetKeyDown("e") && mere == true)
        {//activeaza componenta animation de pe obiect
            GetComponent<Animation>().Play("buton");
            //conditia este aplicata , variabila devine adevarata(nefolositoare)
            apasat = true;
            //comanda folosita pentru a da delay unui subprogram cu nume respectiv si cu timpul respectiv
            Invoke("distrugere", 1);
        }
    }
    //subprogram care este activat mai sus si care distruge obiectul resprectiv
    void distrugere()
    {
        Destroy(gameObject);
    }
}

//Script pentru activarea meteoritului

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class cade : MonoBehaviour
{//variabila care face referinta la un script si alte doua variabile de verificare
    public erupe da;
    private bool nuafost = true;
    public bool meteorit = false;
    //metoda predefinita pentru updatarea scenei
    private void Update()
    {//cautarea de conditii, daca in scriptul "erupe" cometa e adevarat 
        //si daca actiunea a mai fost realizata
        if (da.cometa == true && nuafost == true)
        {//cauta componenta animatie si o activeaza
            GetComponent<Animation>().Play("fly");
            //comanda predefinita pentru delay la subprogramul sunet ,de 1 secunda
            Invoke("sunet", 1);
            //variabila nuafost devine false pentru ca actiunea sa nu se repete,
            //meteorit devine adevarata ( folosita in alt script)
            nuafost = false;
            meteorit = true;
        }
    }
    //subprogram care cauta AudioManager-ul si activeaza sunetul 
    void sunet()
    {
        FindObjectOfType<AudioManager>().Play("picat");
    }
}

//Script care porneste muzica de pe discul 1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class canta : MonoBehaviour
{//variabile pentru verificare si care fac referinta la un alt script
    public bool insite = false;
    //variabila folosita pentru a astepra pana sa poti din nou sa il asculti
    private bool asteapta = true;
    public apare da;
    //metode care verifica daca Colliderul de pe obiect este atins de ceva
    private void OnTriggerEnter(Collider other)
    {
        insite = true;
    }
    private void OnTriggerExit(Collider other)
    {
        insite = false;
    }
    //Updatare scena 
    void Update()
    {//conditie daca se apasa 'e', te afli in colliderul obiectului,daca variabila asteapta este adevarata
        //si daca in scriptul apare , exista este adevarata
        if (Input.GetKeyDown("e") && insite == true && asteapta ==true && da.exista == true)
        {//variabila devine falsa
            asteapta = false;
            //opreste orice sunet posibil cautand obiectul AudioManger si Folosind comanda Stop
            FindObjectOfType<AudioManager>().Stop("Meniu");
            FindObjectOfType<AudioManager>().Stop("doom");
            //Cauta obiectu AudioManager si porneste sunetul cu numele respectiv
            FindObjectOfType<AudioManager>().Play("ultimate");
            //comanda pentru delay , pentru subprogramele iar si wait(150 de secunde)
            Invoke("iar", 150);
        }
    }
    //subprogram care activeaza din nou muzica de meniu si activeaza variabila asteapta
    void iar()
    {
        FindObjectOfType<AudioManager>().Play("Meniu");
        asteapta = true;
    }


}

//Script care porneste muzica de pe discul 2

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class cantadoom : MonoBehaviour
{//variabile pentru verificare , si alta care face referinta la un alt script
    private bool insite = false;
    public apare ba;
    private bool canta = true;
    //metoda predefinita care inregistreaza intrarea in Collider
    private void OnTriggerEnter(Collider other)
    {
        insite = true;
    }
    private void OnTriggerExit(Collider other)
    {
        insite = false;
    }
    void Update()
    {//Conditie pentru activare ( apasa'e', te afli in collider)
        //variabila 'canta'care asteapta pana se termina si variabila 'e' din scriptul 'apare' adevarata
        if (Input.GetKeyDown("e") && insite == true && canta == true && ba.e == true)
        {//variabila canta devine falsa , pentru ca deja o face
            canta = false;
            //opreste toate sunetele posibile din Audiomanager
            FindObjectOfType<AudioManager>().Stop("Meniu");
            FindObjectOfType<AudioManager>().Stop("ultimate");
            //Porneste muzica cu numele respectiv
            FindObjectOfType<AudioManager>().Play("doom");
            //foloseste comanda de delay pentru subprogramu respectiv pe durata de (480 de secunde)
            Invoke("iar", 480);
        }
    }
    //subprogram care activeaza muzica din meniu , si variabila pentru a putea fi refolosita muzica
    void iar()
    {
        FindObjectOfType<AudioManager>().Play("Meniu");
        canta = true;
    }
    
}

//Script pentru activarea povestii din carte

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume subprogram
public class Cartedeschisa : MonoBehaviour
{//variabile pentru verificare si definirea a 2 obiecte pentru canvas si pentru meniu pauza
    private bool ein = false;
    public GameObject Poveste;
    private bool eactiva = false;
    public GameObject pauza;
    //verificare daca playerul se afla in collider
    private void OnTriggerEnter(Collider other)
    {
        ein = true;
    }
    private void OnTriggerExit(Collider other)
    {
        ein = false;
    }
    
    private void Update()
    {//conditie daca apesi e si esti in collider
        if(Input.GetKeyDown("e") && ein == true )
        {//activeaza canvasul (element UI)
            Poveste.SetActive(true);
            //Opreste toate sunetele posibile
            FindObjectOfType<AudioManager>().Stop("Meniu");
            FindObjectOfType<AudioManager>().Stop("doom");
            FindObjectOfType<AudioManager>().Stop("ultimate");
            //Porneste sunetele "horor" si "voice"
            FindObjectOfType<AudioManager>().Play("horor");
            FindObjectOfType<AudioManager>().Play("voice");
            //dezactiveaza meniul de pauza
            pauza.SetActive(false);
            //daca conditia se aplica variabila devine adevarata
            eactiva = true;
}//conditie daca apesi "ESC" si variabila eactiva (care verifica conditia de mai sus) e adevarata
        if (Input.GetKeyDown(KeyCode.Escape) && eactiva == true)
        {//dezactiveaza canvasul
            Poveste.SetActive(false);
            //activeaza meniul de pauza
            pauza.SetActive(true);
            //porneste muzica de meniu si opreste sunetele folosite
            FindObjectOfType<AudioManager>().Play("Meniu");
            FindObjectOfType<AudioManager>().Stop("horor");
            FindObjectOfType<AudioManager>().Stop("voice");
            //variabila devine falsa pentru a putea repeta procesul
            eactiva = false;
        }


    }
}

//Script pentru activarea loading screenului la fiecare nivel si salvarea completarii nivelului (nivel 3)

//Folosirea Engine-ului de UI si Scene
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//nume script
public class chest3 : MonoBehaviour
{//variabile de verificare,variabile pentru obiecte din scena (canvas,etc.)
    //variabile pentru text si pentru slider;
    private bool iese3 = false;
    public GameObject obiect;
    public GameObject loadingscreen;
    public Text pro;
    public Slider loadin;
    //verificare daca te afli in collider
    private void OnTriggerEnter(Collider other)
    {
        iese3 = true;
    }
    private void OnTriggerExit(Collider other)
    {
        iese3 = false;
    }

    private void Update()
    {
        //conditie , daca apesi 'e' si esti in collider
        if (Input.GetKeyDown("e") && iese3 == true)
        {//se seteaza volumul la 0 al componentei audiolistener
            //(componenta predefinita pentru receptarea sunetului)
            AudioListener.volume = 0f;
            //activarea animatiei obiectului respectiv
            obiect.GetComponent<Animation>().Play("spin");
            //Salvare in SaveManager a variabilei lvl3(inregistrata in baza de date)
            SaveManager.instance.lvl3 = true;
            SaveManager.instance.Save();
            //inceperea unei actiuni a unui subprogram nou
            StartCoroutine(incarca());
        }
    }
    //subprogram care te lasa sa iteratezi prin lista de controale
    IEnumerator incarca()
    {
//comanda predefinita care creeaza o variabila ce face asincron operatiunea cu derularea jocului
//incarca actionand pe fundal
//operatiune folosita pentru schimbarea de scene 
//fiind setata la indexul din Built 
        AsyncOperation operatiune = SceneManager.LoadSceneAsync(1);
        //activeaza variabila de loading screen(canvas)
        loadingscreen.SetActive(true);
        //cat timp operatiunea nu este terminata 
        while (operatiune.isDone == false)
        {//creeaza o variabila progres care realizeaza calcule matematice, cu raspunsul intre 0 si 1
            //progresul actiunii fiin impartit la 0.9, pentru a da rezultate inclusiv cu 1
            float progres = Mathf.Clamp01(operatiune.progress / 0.9f);
            //sliderul ia valoarea progresului, schimbandu-se in functie de el
            loadin.value = progres;
            //textul realizeaza un calcul matematic , care rotunjeste progresul
            //il inmulteste cu 100 pentru ca progresul sa fie intre 0% si 100%
            //Transforma variabila in data de tip String si adauga semnul"%"
            pro.text = Mathf.Round(progres * 100f).ToString() + "%";

            //returneaza argumentul null
            yield return null;

        }

    }

}

//Script pentru activarea loading screenului la fiecare nivel si salvarea completarii nivelului (nivel 4)

//Acelasi proces ca la Sciptul pentru activarea loading screenului ,doar cu numele scriptului schimbat(nivel4) si
//Datele din SaveManager, inlocuind variabila 'lvl3' cu 'lvl4'
//variabilele realizeaza aceleasi actiuni , singura diferenta fiind variabila din SaveManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class chest4 : MonoBehaviour
{
    public bool iese4 = false;
    public GameObject obiect;
    public bool apare4 = false;
    public GameObject loadingscreen;
    public Text pro;
    public Slider loadin;
    private void OnTriggerEnter(Collider other)
    {
        iese4 = true;
    }
    private void OnTriggerExit(Collider other)
    {
        iese4 = false;
    }

    private void Update()
    {

        if (Input.GetKeyDown("e") && iese4 == true)
        {
            AudioListener.volume = 0f;
            obiect.GetComponent<Animation>().Play("spin");
            SaveManager.instance.lvl4 = true;
            SaveManager.instance.Save();
            StartCoroutine(incarca());
        }
    }

    IEnumerator incarca()
    {


        AsyncOperation operatiune = SceneManager.LoadSceneAsync(1);

        loadingscreen.SetActive(true);

        while (operatiune.isDone == false)
        {
            float progres = Mathf.Clamp01(operatiune.progress / 0.9f);

            loadin.value = progres;
            pro.text = Mathf.Round(progres * 100f).ToString() + "%";


            yield return null;

        }

    }
}

//Script pentru activarea loading screenului la fiecare nivel si salvarea completarii nivelului (nivel 5)


//Acelasi proces ca la Sciptul pentru activarea loading screenului de la (nivel 3)
//doar cu numele scriptului schimbat(nivel5) si
//Datele din SaveManager, inlocuind variabila 'lvl3' cu 'lvl5'
//variabilele realizeaza aceleasi actiuni , singura diferenta fiind variabila din SaveManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class chest5 : MonoBehaviour
{
    public bool iese5 = false;
    public GameObject obiect;
    public bool apare5 = false;
    public GameObject loadingscreen;
    public Text pro;
    public Slider loadin;
    private void OnTriggerEnter(Collider other)
    {
        iese5 = true;
    }
    private void OnTriggerExit(Collider other)
    {
        iese5 = false;
    }

    private void Update()
    {

        if (Input.GetKeyDown("e") && iese5 == true && apare5 == false)
        {
            AudioListener.volume = 0f;
            obiect.GetComponent<Animation>().Play("spin");
            SaveManager.instance.lvl5 = true;
            SaveManager.instance.Save();
            apare5 = true;
            StartCoroutine(incarca());
        }
    }
    IEnumerator incarca()
    {


        AsyncOperation operatiune = SceneManager.LoadSceneAsync(1);

        loadingscreen.SetActive(true);

        while (operatiune.isDone == false)
        {
            float progres = Mathf.Clamp01(operatiune.progress / 0.9f);

            loadin.value = progres;
            pro.text = Mathf.Round(progres * 100f).ToString() + "%";


            yield return null;

        }

    }
}

//Script pentru activarea loading screenului la fiecare nivel si salvarea completarii nivelului(Nivel 2)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//nume script
public class ChestDesert : MonoBehaviour
{// variabile pentru verificare, obiect pentru canvasul loadingscreenului
    //pentru text, pentru slider si pentru cufar
    public bool iese = false;
    public bool apare = false;
    private bool odata = false;
    public GameObject loadingscreen;
    public Text pro;
    public Slider loadin;
    public GameObject chest;
    //metide care verifica daca te afli in collider
    private void OnTriggerEnter(Collider other)
    {
        iese = true;
    }
    private void OnTriggerExit(Collider other)
    {
        iese = false;
    }

    private void Update()
    {//conditie care verifica in SaveManager daca variabilele placa1,2,3,4,5 sunt adevarata, variabile folosite
        //pentru activarea permanenta a chestului
        if (SaveManager.instance.placa1 == true && SaveManager.instance.placa2 == true && SaveManager.instance.placa3 == true && SaveManager.instance.placa4 == true && SaveManager.instance.placa5 == true && odata == false)
        {//activarea chestului si folosirea variabilei"odata" o singura data
            chest.SetActive(true);
            odata = true;
        }
        //conditie pentru apasarea tastei 'e' si dacate afli in collider
        if (Input.GetKeyDown("e") && iese == true)
        {//setarea volumul din audiolistener la 0 , componenta predefinita pentru inregistrare sunete
            AudioListener.volume = 0f;
            //salvarea completarii nivelului 2
            SaveManager.instance.lvl2 = true;
            SaveManager.instance.Save();
            //inceperea Corutinei incarca
            StartCoroutine(incarca());
        }
    }
    IEnumerator incarca()
    {
        //comanda predefinita care creeaza o variabila ce face asincron operatiunea cu derularea jocului
        //incarca actionand pe fundal
        //operatiune folosita pentru schimbarea de scene 
        //fiind setata la indexul din Built 
        AsyncOperation operatiune = SceneManager.LoadSceneAsync(1);
        //activeaza variabila de loading screen(canvas)
        loadingscreen.SetActive(true);
        //cat timp operatiunea nu este terminata 
        while (operatiune.isDone == false)
        {//creeaza o variabila progres care realizeaza calcule matematice, cu raspunsul intre 0 si 1
            //progresul actiunii fiin impartit la 0.9, pentru a da rezultate inclusiv cu 1
            float progres = Mathf.Clamp01(operatiune.progress / 0.9f);
            //sliderul ia valoarea progresului, schimbandu-se in functie de el
            loadin.value = progres;
            //textul realizeaza un calcul matematic , care rotunjeste progresul
            //il inmulteste cu 100 pentru ca progresul sa fie intre 0% si 100%
            //Transforma variabila in data de tip String si adauga semnul"%"
            pro.text = Mathf.Round(progres * 100f).ToString() + "%";

            //returneaza argumentul null
            yield return null;

        }

    }

}

//Script pentru activarea loading screenului la fiecare nivel si salvarea completarii nivelului(Nivel 1)

//Acelasi proces ca la Sciptul pentru activarea loading screenului de la (nivel 3)
//doar cu numele scriptului schimbat(chestsmech) si
//Datele din SaveManager, inlocuind variabila 'lvl3' cu 'lvl1'
//variabilele realizeaza aceleasi actiuni , singura diferenta fiind variabila din SaveManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class chestsmech : MonoBehaviour
{
    public bool iese1 = false;
    public GameObject obiect;
    public bool apare = false;
    public GameObject loadingscreen;
    public Text pro;
    public Slider loadin;
    private void OnTriggerEnter(Collider other)
    {
        iese1 = true;
    }
    private void OnTriggerExit(Collider other)
    {
        iese1 = false;
    }

    private void Update()
    {

        if (Input.GetKeyDown("e") && iese1 == true)
        {
            obiect.GetComponent<Animation>().Play("spin");
            AudioListener.volume = 0f;
            SaveManager.instance.lvl1 = true;
            SaveManager.instance.Save();
            StartCoroutine(incarca());
        }
    }
    IEnumerator incarca()
    {
       
        
            AsyncOperation operatiune = SceneManager.LoadSceneAsync(1);

            loadingscreen.SetActive(true);

            while (operatiune.isDone == false)
            {
                float progres = Mathf.Clamp01(operatiune.progress / 0.9f);

                loadin.value = progres;
            pro.text = Mathf.Round(progres * 100f).ToString() + "%";


            yield return null;

            }
        
    }

}


//Script pentru activarea loading screenului la fiecare nivel si salvarea completarii nivelului(Tutorial)


//Acelasi proces ca la Sciptul pentru activarea loading screenului de la (nivel 3)
//doar cu numele scriptului schimbat(chesttut) si
//Datele din SaveManager, inlocuind variabila 'lvl3' cu 'tut'
//variabilele realizeaza aceleasi actiuni , singurele diferenta fiind variabila din SaveManager
//si conditia ca in scriptul PickUp , cu variabila bs, cheie sa fie adevarata
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class chesttut : MonoBehaviour
{
    private bool iese1 = false;
    private bool odata = false;
    public GameObject obiect;
    public PickUp bs;
    public Text pro;
    public Slider loadin;
    public GameObject loadingscreen;
    private void OnTriggerEnter(Collider other)
    {
        iese1 = true;
    }
    private void OnTriggerExit(Collider other)
    {
        iese1 = false;
    }

    private void Update()
    {

        if (Input.GetKeyDown("e") && iese1 == true && bs.cheie == true && odata == false)
        {
            odata = true;
            AudioListener.volume = 0f;
            SaveManager.instance.tut = true;
            SaveManager.instance.Save();
            StartCoroutine(incarca());
        }
    }

    IEnumerator incarca()
    {
       
            AsyncOperation operatiune = SceneManager.LoadSceneAsync(1);

            loadingscreen.SetActive(true);

            while (operatiune.isDone == false)
            {
                float progres = Mathf.Clamp01(operatiune.progress / 0.9f);

                loadin.value = progres;
            pro.text = Mathf.Round(progres * 100f).ToString() + "%";


            yield return null;

            }
        
    }
}


//Scripturi pentru Distrugerea Unor Obiecte

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage3 : MonoBehaviour
{    //Am declarat niste parametri pentru viata, efectul de explozie si o variabila de tip bool 
    [Header("Stats")]
    public int health;
    public Transform explosionEffect;
    public bool distrus3 = false;
    public void TakeDamage(int damage)
    {
        health -= damage;  //Aici am denumit o variabila health, care reprezinta viata unui obiect si scade pe parcurs
        if (health <= 0)
        {//Daca viata obiectului este <= decat 0, atunci variabila distrus va deveni adevarata si obiectul se va distruge
            distrus3 = true;
            Destroy(gameObject);   
            Instantiate(explosionEffect, transform.position, transform.rotation);//Acesta este un efect de tip particle system, care va avea loc la obiectul distrus
            FindObjectOfType<AudioManager>().Play("OOF");   //Aici apelez functia Play() din AudioManager pentru a putea sa adaug un sunet la distrugerea obiectului

        }




    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage2 : MonoBehaviour
{//Scriptul acesta este exact ca si scriptul Damage3.cs, doar ca il aplic pe un alt obiect
    [Header("Stats")]
    public int health;
    public Transform explosionEffect;
    public bool distrus2 = false;
    public void TakeDamage(int damage)
    {
        health -= damage;  //Aici am denumit o variabila health, care reprezinta viata unui obiect si scade pe parcurs
        if (health <= 0)
        {//Daca viata obiectului este <= decat 0, atunci variabila distrus va deveni adevarata si obiectul se va distruge
            distrus2 = true;
            Destroy(gameObject);
            Instantiate(explosionEffect, transform.position, transform.rotation);//Acesta este un efect de tip particle system, care va avea loc la obiectul distrus
            FindObjectOfType<AudioManager>().Play("OOF");   //Aici apelez functia Play() din AudioManager pentru a putea sa adaug un sunet la distrugerea obiectului

        }




    }
}


//Acest script este exact ca si scripturile Damage2 si Damage3, doar ca se aplica altui obiect


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    [Header("Stats")]
    public int health;
    public Transform explosionEffect;
    public bool distrus = false;
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            distrus = true;
            Destroy(gameObject);
            Instantiate(explosionEffect, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("OOF");
            
        }
       



    }
}

<------------------------------------------>

//Script de Projectile Addon ->>Acest script este inspirat de la canalul de YouTube : Dave Game Development : https://www.youtube.com/channel/UCIWlCE2kt0RXCJLRp8HjhiQ

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAddon : MonoBehaviour
{
    private Rigidbody rb;
    private bool targetHit;
    public int damage;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {   //Aici proiectilul se va lipi de prima tinta
        if (targetHit)
            return;
        else
            targetHit = true;

        //check if u hit an enemy
        if (collision.gameObject.GetComponent<DamageScript>() != null)
        {
           DamageScript enemy = collision.gameObject.GetComponent<DamageScript>();  //Creez o variabila de tipul Scriptului DamageScript pentru a o putea apela aici


            enemy.TakeDamage(damage);
           

            Destroy(gameObject);


        }

        if(collision.gameObject.GetComponent<Damage2>() != null)
        {
            Damage2 inamic = collision.gameObject.GetComponent<Damage2>(); //Creez o variabila de tipul Scriptului Damage2 pentru a o putea apela aici

            inamic.TakeDamage(damage);

            Destroy(gameObject);

        }


        if (collision.gameObject.GetComponent<Damage3>() != null)
        {
            Damage3 mt = collision.gameObject.GetComponent<Damage3>(); //Creez o variabila de tipul Scriptului Damage3 pentru a o putea apela aici

            mt.TakeDamage(damage);

            Destroy(gameObject);

        }



        //Rigidbody Kinematic pentru a opri rotatia/miscarea

        rb.isKinematic = true;

        //Proiectilul tb sa se miste cu tot cu tinta adica grupez projectilul intr un parent 
        transform.SetParent(collision.transform);
    }
}

<---Script de aruncare a unor proiectile/obiecte ->>>
***Scriptul acesta este preluat de la canalul de youtube Dave Game Development :https://www.youtube.com/channel/UCIWlCE2kt0RXCJLRp8HjhiQ

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThrowDoi : MonoBehaviour
{
    [Header("References")]                      //Variabile de referinta pentru camera, locul unde vom ataca si obiectul cu care vom arunca
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;

    [Header("Settings")]
    public int totalThrows;            //Variabile pentru setari precum timpul de repaus dintre aruncari si aruncarile totale
    public float throwCooldown;

    [Header("Throwing")]                            //Variabile pentru fortele cu care aruncam si o variabila de referinta pentru butonul cu care vom arunca
    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;

    bool readyToThrow;
    
    
    private void Start()
    {
        readyToThrow = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0)
        {
            Throw();   //Cat timp mai avem proiectile si apasam tasta aleasa, putem arunca proiectile prin Throw()
           
            
            
        }
    }

    private void Throw()
    {
        readyToThrow = false;

        // Instantierea unui proiectil
        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

        //corp rigid
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        // calcularea directiei
        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;           ///<---raza

        if (Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }

        // adaugam forta
        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);
        
        totalThrows--;

        // timpul de repaus
        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }
 

}
<----Acestea au fost scripturile care au fost folosite doar la nivelele 3(Arctic) si 5(Labyrinth)----------->

    <----------SCRIPTURI FOLOSITE LA NIVELUL 2(Desert) ---------------------->

///Cum ideea nivelului este ca jucatorul sa puna 5 potiuni pe 5 placi, exista o ordine si anume :
/*  Placa 1 - Potiune Mov
      Placa 2 - Potiune Rosie
     Placa 3 - Potiune Verde
    Placa 4 - Potiune Albastra
   Placa 5 - Potiune Gri
*/   //Am facut 5 script uri pentru 5 placi, fiecare placa avand script ul sau caracteristic, in fiecare este prezentata si spawnarea potiunilor caracteristice pentru fiecare placa 
///Script - PLACA 1
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placa1 : MonoBehaviour
{
    public bool placaJ = false;
    public float pozX;
    public float pozZ;
    public float pozY;

    public Transform Potiune1;
    

    string nume = "Potiune_Mov";
    /// <------------------------------------> ANIMATIE PENTRU POTIUNEA MOV <-------------------------------> \\\
    private void Start()
    {
        RandomPoz();
        Potiune1.transform.position = new Vector3(pozX, pozY, pozZ);     
        transform.position = new Vector3(-7.38f, 0.55f, 18.5f);
    } 
  
        private void OnTriggerEnter(Collider other)
        {
        
        if (other.gameObject.name == nume)
        
        {
            FindObjectOfType<AudioManager>().Play("button");
            transform.position = new Vector3(-7.38f, 0.44f, 18.5f);
            SaveManager.instance.placa1 = true;//Aici se vor salva instantele pentru placa1
            SaveManager.instance.Save();     // <-->
            placaJ = true;
           
        }
        }
        private void OnTriggerExit(Collider other)
        {          //Atunci cand o potiune iese din collider, placa se va ridica iar cu 0.11 f pe oY
            if (other.gameObject.tag == "Potiune")
            {
            FindObjectOfType<AudioManager>().Stop("button");  
            transform.position = new Vector3(-7.38f, 0.55f, 18.5f);
            SaveManager.instance.placa1 = false ;   //Aici nu se vor salva instantele pentru placa1
            SaveManager.instance.Save();            // <-->

            placaJ = false;
            }
        }
   //Spawnul Random 
    public void RandomPoz()
    {
        int Rand = Random.Range(1, 3);
        if (Rand == 1)
        {
            pozX = -15.03f;
            pozY = 1.12f;
            pozZ = 15.9f;
        }
        else if (Rand == 2)
        {
            pozX = -20.4f;
            pozY = 0.92f;
            pozZ = -5.97f;
        }
        else if (Rand == 3)
        {
            pozX = 6.62f;
            pozY = 0.92f;
            pozZ = -7.49f;
        }

        
    }


}

//Script - PLACA 2

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placa2 : MonoBehaviour
{
    public float pozZ;
    public float pozX;
    public float pozY;

    public Transform Potiune2;

    public bool placaJ = false;
    string nume = "Potiune_Rosie";
    /// <------------------------------------> ANIMATIE PENTRU POTIUNEA ROSIE <-------------------------------> \\\
    private void Start()
    {
        RandomPoz();
        Potiune2.transform.position = new Vector3(pozX, pozY, pozZ);
        transform.position = new Vector3(-6.11f, 0.55f, 18.5f);
    }
    private void OnTriggerEnter(Collider other)
    {  //Atunci cand numele Obiectului este egal cu Potiune_Rosie, placa se va lasa in jos, iar SaveManager ul va salva instanta
        if (other.gameObject.name == nume)
        {
            FindObjectOfType<AudioManager>().Play("button");
            transform.position = new Vector3(-6.11f, 0.44f, 18.5f);
            SaveManager.instance.placa2 = true;
            SaveManager.instance.Save();

            placaJ = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {   //Daca tag ul obiectului e Potiune si nu este si numele Potiune Rosie, atunci placa se va ridica, iar instanta nu se va salva
        if (other.gameObject.tag == "Potiune")
        {
            FindObjectOfType<AudioManager>().Stop("button");
            transform.position = new Vector3(-6.11f, 0.55f, 18.5f);
            SaveManager.instance.placa2 = false;
            SaveManager.instance.Save();
            placaJ = false;
        }
    }


    public void RandomPoz()
    {
        int Rand = Random.Range(1, 3);
        if (Rand == 1)
        {
            pozX = -9.032f;
            pozY = 1.26f;
            pozZ = -9.48f;
        }
        else if (Rand == 2)
        {
            pozX = -9.17f;
            pozY = 10f; 
            pozZ = -22.82f;
        }
        else if (Rand == 3)
        {
            pozX = 6.38f;
            pozY = 1.26f;
            pozZ = -19.56f;
        }
        

    }

}

//Script Placa 3


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placa3 : MonoBehaviour
{

    public float pozZ;
    public float pozX;
    public float pozY;

    public Transform Potiune3;



    public bool placaJ = false;
    string nume = "Potiune_Verde";
    /// <------------------------------------> ANIMATIE PENTRU POTIUNEA VERDE <-------------------------------> \\\
    private void Start()
    {
        RandomPoz();
        Potiune3.transform.position = new Vector3(pozX, pozY, pozZ);
        transform.position = new Vector3(-4.577f, 0.55f, 18.5f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == nume)
        {//Atunci cand numele string ului e egal cu numele "Potiune_Verde" se va da play la sunetul "button", iar placa se va lasa in jos
            FindObjectOfType<AudioManager>().Play("button");
            transform.position = new Vector3(-4.577f, 0.44f, 18.5f);
            SaveManager.instance.placa3 = true;
            SaveManager.instance.Save();

            placaJ = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Potiune")
       {
            FindObjectOfType<AudioManager>().Stop("button");
            transform.position = new Vector3(-4.577f, 0.55f, 18.5f);
            SaveManager.instance.placa3 = false;
            SaveManager.instance.Save();
            placaJ = false;
        }
    }
 //Generare Random
    public void RandomPoz()
    {
        int Rand = Random.Range(1, 3);
        if (Rand == 1)
        {
            pozX = -7.322f;
            pozY = 1.061f;
            pozZ = 24.195f;
        }
        else if (Rand == 2)
        {
            pozX = -19.59f;
            pozY = 1.12f;
            pozZ = 15.19f;
        }
        else if (Rand == 3)
        {
            pozX = -12.883f;
            pozY = 0.966f;
            pozZ = 6.43f;
        }
 

    }

}

//Script - Placa 4

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placa4 : MonoBehaviour
{

    public float pozZ;
    public float pozX;
    public float pozY;

    public Transform Potiune4;


    public bool placaJ = false;


    private void Start()
    {
        RandomPoz();
        Potiune4.transform.position = new Vector3(pozX, pozY, pozZ);
        transform.position = new Vector3(-3.099f, 0.55f, 18.5f);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Potiune_Albastra")
        {
            FindObjectOfType<AudioManager>().Play("button");
            transform.position = new Vector3(-3.099f, 0.44f, 18.5f);
            SaveManager.instance.placa4 = true;
            SaveManager.instance.Save();

            placaJ = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Potiune")
        {
            FindObjectOfType<AudioManager>().Stop("button");
            transform.position = new Vector3(-3.099f, 0.55f, 18.5f);

            SaveManager.instance.placa4 = false;
            SaveManager.instance.Save();
            placaJ = false;
        }
    }

    public void RandomPoz()
    {
        int Rand = Random.Range(1, 3);
        if (Rand == 1)
        {
            pozX = -3.02f;
            pozY = 0.97f;
            pozZ = -8.15f;
        }
        else if (Rand == 2)
        {
            pozX = 12.55f;
            pozY = 0.97f;
            pozZ = -8.15f;
        }
        else if (Rand == 3)
        {
            pozX = 9.964f;
            pozY = 1.932f;
            pozZ = -19.415f;
        }


    }
}


//Script - PLACA 5

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placa5 : MonoBehaviour
{
    public bool placaJ = false;

    public float pozZ;
    public float pozX;
    public float pozY;

    public Transform Potiune5;



    string nume = "Potiune_Gri";
    private void Start()
    {
        RandomPoz();
        Potiune5.transform.position = new Vector3(pozX, pozY, pozZ);
        
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == nume)
        {
            FindObjectOfType<AudioManager>().Play("button");
            transform.position = new Vector3(-1.587f, 0.44f, 18.5f);
            SaveManager.instance.placa5 = true;
            SaveManager.instance.Save();

            placaJ = true;
        }
    }
//functie pentru iesirea dintr-un boxcollider/mesh collider
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Potiune")
        {
            FindObjectOfType<AudioManager>().Stop("button");

            transform.position = new Vector3(-1.587f, 0.55f, 18.5f);
            SaveManager.instance.placa5 = false;
            SaveManager.instance.Save();
            placaJ = false;
        }
    }
    public void RandomPoz()
    {
        int Rand = Random.Range(1, 3);
        if (Rand == 1)
        {
            pozX = 8.91f;
            pozY = 0.96f;
            pozZ = 20.014f;
        }
        else if (Rand == 2)
        {
            pozX = 7.363f;
            pozY = 2.95f;
            pozZ = 20.27f;
        }
        else if (Rand == 3)
        {
            pozX = -0.15f;
            pozY = 0.98f;
            pozZ = 25.87f;
        }
 

    }

}

//Script pentru activarea finalului sau mentiunii a ce trebuie sa faci

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//nume script
public class des : MonoBehaviour
{//definire variabila verificare , diferite obiecte (canvas, obiecte scena),transform player
    //folosit pentru transformarea pozitiei playerului
    public GameObject usa;
    public Transform player;
    private bool razwan = false;
    public GameObject req;
    public GameObject text;
    public GameObject sfarsit;
    public GameObject audem;
    public GameObject pauza;

    void Update()
    {//conditii, daca apesi 'e' si te afli in collider si nivelul 5 este completat
        if (Input.GetKey("e") && razwan == true && SaveManager.instance.lvl5 == true)
        {//dezactivare sistem pauza
            pauza.SetActive(false);
            //deschiderea usii folosing animatia
            usa.GetComponent<Animation>().Play("Door_Open");
            //oprirea tuturor sunetelor posibile
            audem.GetComponent<AudioManager>().Stop("Meniu");
            audem.GetComponent<AudioManager>().Stop("doom");
            audem.GetComponent<AudioManager>().Stop("ultiamte");
            //folosirea comenzii pentru delay cu , utilizand subprogramu hai ( in 1.5 secunde)
            Invoke("hai", 1.5f);
        }
        //conditie daca apesi e , si daca esti in collider , dar nivelul 5 nu e completat
        if (Input.GetKey("e") && razwan == true && SaveManager.instance.lvl5 == false)
        {//se activeaza animatia dupa cautarea componentei usa
            usa.GetComponent<Animation>().Play("Door_Jam");
            //se activeaza un canvas(element UI)
            req.SetActive(true);
            //se cauta componenta animatie in text si se activeaza
            text.GetComponent<Animation>().Play("dur");
            //se foloseste comanda de delay , pentru subprogramu 'gata'(3 secunde)
            Invoke("gata", 3);
        }
    }
    //metode predefinite care verifica statutul coliderului
    private void OnTriggerEnter(Collider other)
    {
        razwan = true;
    }
    private void OnTriggerExit(Collider other)
    {
        razwan = false;
    }
    //subprogram care dezactiveaza un canvas
    void gata()
    {
        req.SetActive(false);
    }
    //subprogram care activeaza canvasul de sfarsit,opreste timpul,deblocheaza si face vizibil cursorul
    //Ia componenta AudioManager si activeaza muzica de Sfarsit
void hai()
    {
        sfarsit.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        audem.GetComponent<AudioManager>().Play("sfarsit");
    }
}


//Script deschidere usa tutorial

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class deschide : MonoBehaviour
{//variabila de verificare
    private bool wait = false;
    private void Update()
    {//conditii, daca apesi 'e' si asteapta e false
        if (Input.GetKeyDown("e") && wait == false)
        {//se ia componenta animation si se activeaza, cu numele animatiei
            GetComponent<Animation>().Play("Door_Open");
            //asteapta devine adevarat deoarece conditia se verifica
            wait = true;
            //se foloseste comanda de delay , pentru subprogramele "inchisa" si "ast"(2 secunde si 4 secunde)
            Invoke("inchisa", 2);
            Invoke("ast", 4);
        }
    }
    //subprogram pentru asteptare folosit sa astepte 4 secunde inainte de repetarea actiunii
    void ast()
    {
        wait = false;
    }
    //subprogram care ia componenta animation si o activeaza , cu numele potrivit, pentru a inchide usa
    void inchisa()
    {
        GetComponent<Animation>().Play("Door_Close");
    }
}

//Script pentru activarea bucatii de secret

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class distrugere : MonoBehaviour
{ //variabile pentru verificare , pentru referinta la script extern is pentru obiecte
    public GameObject nasa;
    public GameObject perete;   
    private bool nic;
    public easter mm;
    private bool pietre;
    //metode pentru verificarea activitatii colliderului
    private void OnTriggerEnter(Collider other)
    {
        nic = true;
    }
    private void OnTriggerExit(Collider other)
    {
        nic = false;
    }

    void Update()
    {//conditie daca apesi 'f' si 'petre' este adevarat in scriptul extern si colliderul e adevarat
        if(Input.GetKeyDown("f") && mm.petre == true && nic ==true)
        {//in obiectul perete cauta animation cu numele de "New Animation"
            perete.GetComponent<Animation>().Play("New Animation");
            //variabila petre devine adevarata
            pietre = true;
            //cauta obiectul AudioManager si opreste muzica
                FindObjectOfType<AudioManager>().Stop("padure");
            //seteaza rotatia elementului care creeaza lumina , pentru a realiza un efect de noapte
            nasa.transform.rotation = Quaternion.Euler(-67.399f,620.278f,-408.156f);
        }
    }
}

//Script folosit pentru secret

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class easter : MonoBehaviour
{//creare variabile , folosita dupa si Transformarea , care ajuta la schimbarea pozitiei
    public bool petre = false;
    public Transform destin;
    //metoda care se activeaza cand dai click
    void OnMouseDown()
    {
        //variabila devine adevarata
        petre = true;
        //se cauta componenta din rigidbody si se dezactiveaza gravitatie 
        //se blocheaza rotatia si miscarea obiectului
        //iar colliderul , pentru mesh se dezactiveaza
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<MeshCollider>().enabled = false;
        GetComponent<Rigidbody>().freezeRotation = true;
        GetComponent<Rigidbody>().isKinematic = true;
        //se trimite obiectul pe care este scriptul in pozitia in care am setat destinatia
        this.transform.position = destin.position;
        //obiectul cu scriptul devine un 'Child' al Obiectului"Obiect"care ii devine "Parent"
        //"Parent" insemnand parinte, adica un obiect mai mare , din care face parte
        //spre exemplu daca bagi un text intr-un panou, acesta devine automat 'Child', Iar panoul 'Parent'
        this.transform.parent = GameObject.Find("Obiect").transform;

    }
    //metoda care se activeaza cand ridici clickul
    void OnMouseUp()
    {//variabila devine falsa
        petre = false;
        //obiectul isi pierde tagul de 'Child' 
        this.transform.parent = null;
        //Se activeaza gravitatia si colliderul la obiect
        //Se deblocheaza rotatia si miscarea obiectului
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<MeshCollider>().enabled = true;
        GetComponent<Rigidbody>().freezeRotation = false ;
        GetComponent<Rigidbody>().isKinematic = false ;
    }
}

//Script erupere vulcan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class erupe : MonoBehaviour
{//variabile pentru referinta la scriptul buton , obiect, si pentru verificare
    public Buton adv;
    private bool fost = false;
    public bool cometa = false;
    public GameObject sfera;
    void Update()
    {//conditii , daca in scriptul buton apasat este adevarat si fost e adevarat
        //fost fiind o variabila pentru verificarea si realizarea o singura data a actiunii
        if(adv.apasat == true && fost == false)
        {//comanda de delay pentru subprogramul 'erupere' (3 secunde)
            Invoke("erupere", 3);
            //variabila fost devine adevarata
            fost = true;
        }

    }
    //subprogram pentru eruperea vulcanului care activeaza variabila cometa folosita intru-un alt script
    //Se cauta componenta animation si se activeaza animatia cu numele corespunzator
    //se activeaza animatia obiectului 'sfera' prin gasirea componentei
    //se activeaza sunetul cu numele respectiv , prin gasirea obiectului AudioManager
    void erupere()
    {
        cometa = true;
        GetComponent<Animation>().Play("vulcan");
        sfera.GetComponent<Animation>().Play("nou");
        FindObjectOfType<AudioManager>().Play("explozie");
    }
}

//Script pentru inaintare placi vulcan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class inainte : MonoBehaviour
{//variabila , cu referinta dintr-un script exterior, si o variabila de verificare
    public trage dat;
    private bool gata = false;

    private void Update()
    {//conditii, daca din scriptul exterior variabila dorita e adevarata
        //si variabila de verificare este adevarata(folosita sa realizeze actiunea o singura data)
        if (dat.edat == true && gata == false)
        {
            //ea componenta animation a obiectului pe care este pus si o activeaza , pe numele respectiv
            GetComponent<Animation>().Play("inainte");
            //variabila care realizeaza actiunea o singura data devine adevarata
            gata = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class inainte2 : MonoBehaviour
{//variabila , cu referinta dintr-un script exterior, si o variabila de verificare
    public trage2 dat;
    private bool stop = false;

    private void Update()
    {//conditii, daca din scriptul exterior variabila dorita e adevarata
        //si variabila de verificare este adevarata(folosita sa realizeze actiunea o singura data)
        if (dat.edat1 == true && stop == false)
        {//ea componenta animation a obiectului pe care este pus si o activeaza , pe numele respectiv
            GetComponent<Animation>().Play("inainte2");
            //variabila care realizeaza actiunea o singura data devine adevarata
            stop = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class inainte3 : MonoBehaviour
{//variabila , cu referinta dintr-un script exterior, si o variabila de verificare
    public trage3 dat;
    private bool hop = false;

    private void Update()
    {//conditii, daca din scriptul exterior variabila dorita e adevarata
        //si variabila de verificare este adevarata(folosita sa realizeze actiunea o singura data)
        if (dat.edat2 == true && hop == false)
        {//ea componenta animation a obiectului pe care este pus si o activeaza , pe numele respectiv
            GetComponent<Animation>().Play("inainte3");
            //variabila care realizeaza actiunea o singura data devine adevarata
            hop = true;
        }
    }
}

//Script pentru Levere(Manete)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class Lever : MonoBehaviour
{ //referinta la script extern ,adaugare obiectelor(canvas,text,levere)
    //folosirea variabilelor pentru verificare
    public cade da;
    public GameObject Lever1;
    public bool l1 = false;
    public GameObject Lever2;
    public bool l2 = false;
    public GameObject Lever3;
    public bool l3 = false;
    public GameObject can;
    public GameObject txt;
    void Update()
    {//conditii, daca se apasa 'z' si daca referinta din scriptul extern e adevarata
        if (Input.GetKeyDown("z") && da.meteorit == true)
        {//folosirea comenzii de delay pentru subprograme
            Invoke("lvr1", 1);
            Invoke("lvr2", 3);
            Invoke("lvr3", 5);
            //activarea canvasului(element UI)
            can.SetActive(true);
            //activarea componentei animation , care activeaza animatia cu numele respectiv
            txt.GetComponent<Animation>().Play("anim");
            //folosirea comenzii de delay pentru subprogram
            Invoke("dispare", 3);
        }
    }
    //subrogram care activeaza leverul 1 si  ii seteaza variabila de verificare adevarata
    void lvr1()
    {
        Lever1.SetActive(true);
        l1 = true;
    }
    //subrogram care activeaza leverul 2 si ii seteaza variabila de verificare adevarata
    void lvr2()
    {
        Lever2.SetActive(true);
        l2 = true;
    }
    //subrogram care activeaza leverul 3 si ii seteaza variabila de verificare adevarata
    void lvr3()
    {
        Lever3.SetActive(true);
        l3 = true;
    }
    //subprogram dezactivare canvas
 void dispare()
    {
        can.SetActive(false);
    }
        
}

//Script pentru intrarea in Nivelul 1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//nume script
public class intralvl1 : MonoBehaviour
{//variabile de verificare , si setare obiecte pentru loadingscreen
    //setare text si setare slider
    private bool wai = false;
    public GameObject loadingscreen;
    public Text pro;
    public Slider loadin;
    //variabila verifica daca exista coliziune
    private void OnTriggerEnter(Collider other)
    {
        wai = true;
    }
    private void OnTriggerExit(Collider other)
    {
        wai = false;
    }

    private void Update()
    {//conditii, daca exista coliziune si apesi 'e'
        if (Input.GetKeyDown("e") && wai == true)
        {//volumul AudioListener-ului se seteaza la 0 si incepe corutina
            AudioListener.volume = 0f;
            StartCoroutine(incarca());
        }
    }
    IEnumerator incarca()
    {
        //comanda predefinita care creeaza o variabila ce face asincron operatiunea cu derularea jocului
        //incarca actionand pe fundal
        //operatiune folosita pentru schimbarea de scene 
        //fiind setata la indexul din Built 
        AsyncOperation operatiune = SceneManager.LoadSceneAsync(2);
        //activeaza variabila de loading screen(canvas)
        loadingscreen.SetActive(true);
        //cat timp operatiunea nu este terminata 
        while (operatiune.isDone == false)
        {//creeaza o variabila progres care realizeaza calcule matematice, cu raspunsul intre 0 si 1
            //progresul actiunii fiin impartit la 0.9, pentru a da rezultate inclusiv cu 1
            float progres = Mathf.Clamp01(operatiune.progress / 0.9f);
            //sliderul ia valoarea progresului, schimbandu-se in functie de el
            loadin.value = progres;
            //textul realizeaza un calcul matematic , care rotunjeste progresul
            //il inmulteste cu 100 pentru ca progresul sa fie intre 0% si 100%
            //Transforma variabila in data de tip String si adauga semnul"%"
            pro.text = Mathf.Round(progres * 100f).ToString() + "%";

            //returneaza argumentul null
            yield return null;

        }

    }
}


//Script pentru intrarea in Nivelul 2

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//nume script
public class Lvl2 : MonoBehaviour
{//variabile date pentru text, loading screen si slider si de verificare
    public GameObject loadingscreen;
    private bool wai = false;
    public Text pro;
    public Slider loadin;
    //metoda care verifica daca exista vreo coliziune 
    private void OnTriggerEnter(Collider other)
    {
        wai = true;
    }
    private void OnTriggerExit(Collider other)
    {
        wai = false;
    }

    private void Update()
    {//conditii, daca apesi 'e' si te afli in collider si nivelul 1 este completat
        if (Input.GetKeyDown("e") && wai == true && SaveManager.instance.lvl1 == true)
        {//volumul AudioListener-ului(componenta predefinita) este setat la 0 si incepe corutina
            AudioListener.volume = 0;
            StartCoroutine(incarca());
        }

    }
    IEnumerator incarca()
    {
        //comanda predefinita care creeaza o variabila ce face asincron operatiunea cu derularea jocului
        //incarca actionand pe fundal
        //operatiune folosita pentru schimbarea de scene 
        //fiind setata la indexul din Built 
        AsyncOperation operatiune = SceneManager.LoadSceneAsync(3);
        //activeaza variabila de loading screen(canvas)
        loadingscreen.SetActive(true);
        //cat timp operatiunea nu este terminata 
        while (operatiune.isDone == false)
        {//creeaza o variabila progres care realizeaza calcule matematice, cu raspunsul intre 0 si 1
            //progresul actiunii fiin impartit la 0.9, pentru a da rezultate inclusiv cu 1
            float progres = Mathf.Clamp01(operatiune.progress / 0.9f);
            //sliderul ia valoarea progresului, schimbandu-se in functie de el
            loadin.value = progres;
            //textul realizeaza un calcul matematic , care rotunjeste progresul
            //il inmulteste cu 100 pentru ca progresul sa fie intre 0% si 100%
            //Transforma variabila in data de tip String si adauga semnul"%"
            pro.text = Mathf.Round(progres * 100f).ToString() + "%";

            //returneaza argumentul null
            yield return null;

        }

    }
}

/Script intrare pentru Nivelul 3

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//nume script
public class Lvl3 : MonoBehaviour
{//variabile date pentru text, loading screen si slider si de verificare
    public GameObject loadingscreen;
    private bool wai = false;
    public Text pro;
    public Slider loadin;
    //metoda care verifica daca exista vreo coliziune 
    private void OnTriggerEnter(Collider other)
    {
        wai = true;
    }
    private void OnTriggerExit(Collider other)
    {
        wai = false;
    }

    private void Update()
    {//conditii, daca apesi 'e' si te afli in collider si nivelul 2 este completat
        if (Input.GetKeyDown("e") && wai == true && SaveManager.instance.lvl2 == true)
        {//volumul AudioListener-ului(componenta predefinita) este setat la 0 si incepe corutina
            AudioListener.volume = 0;
            StartCoroutine(incarca());
        }

    }
    IEnumerator incarca()
    {
        //comanda predefinita care creeaza o variabila ce face asincron operatiunea cu derularea jocului
        //incarca actionand pe fundal
        //operatiune folosita pentru schimbarea de scene 
        //fiind setata la indexul din Built 
        AsyncOperation operatiune = SceneManager.LoadSceneAsync(4);
        //activeaza variabila de loading screen(canvas)
        loadingscreen.SetActive(true);
        //cat timp operatiunea nu este terminata 
        while (operatiune.isDone == false)
        {//creeaza o variabila progres care realizeaza calcule matematice, cu raspunsul intre 0 si 1
            //progresul actiunii fiin impartit la 0.9, pentru a da rezultate inclusiv cu 1
            float progres = Mathf.Clamp01(operatiune.progress / 0.9f);
            //sliderul ia valoarea progresului, schimbandu-se in functie de el
            loadin.value = progres;
            //textul realizeaza un calcul matematic , care rotunjeste progresul
            //il inmulteste cu 100 pentru ca progresul sa fie intre 0% si 100%
            //Transforma variabila in data de tip String si adauga semnul"%"
            pro.text = Mathf.Round(progres * 100f).ToString() + "%";

            //returneaza argumentul null
            yield return null;

        }

    }
}

/Script intrare pentru Nivelul 4

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//nume script
public class Lvl4 : MonoBehaviour
{//variabile date pentru text, loading screen si slider si de verificare
    public GameObject loadingscreen;
    private bool wai = false;
    public Text pro;
    public Slider loadin;
    //metoda care verifica daca exista vreo coliziune 
    private void OnTriggerEnter(Collider other)
    {
        wai = true;
    }
    private void OnTriggerExit(Collider other)
    {
        wai = false;
    }

    private void Update()
    {//conditii, daca apesi 'e' si te afli in collider si nivelul 3 este completat
        if (Input.GetKeyDown("e") && wai == true && SaveManager.instance.lvl3 == true)
        {//volumul AudioListener-ului(componenta predefinita) este setat la 0 si incepe corutina
            AudioListener.volume = 0;
            StartCoroutine(incarca());
        }

    }
    IEnumerator incarca()
    {
        //comanda predefinita care creeaza o variabila ce face asincron operatiunea cu derularea jocului
        //incarca actionand pe fundal
        //operatiune folosita pentru schimbarea de scene 
        //fiind setata la indexul din Built 
        AsyncOperation operatiune = SceneManager.LoadSceneAsync(5);
        //activeaza variabila de loading screen(canvas)
        loadingscreen.SetActive(true);
        //cat timp operatiunea nu este terminata 
        while (operatiune.isDone == false)
        {//creeaza o variabila progres care realizeaza calcule matematice, cu raspunsul intre 0 si 1
            //progresul actiunii fiin impartit la 0.9, pentru a da rezultate inclusiv cu 1
            float progres = Mathf.Clamp01(operatiune.progress / 0.9f);
            //sliderul ia valoarea progresului, schimbandu-se in functie de el
            loadin.value = progres;
            //textul realizeaza un calcul matematic , care rotunjeste progresul
            //il inmulteste cu 100 pentru ca progresul sa fie intre 0% si 100%
            //Transforma variabila in data de tip String si adauga semnul"%"
            pro.text = Mathf.Round(progres * 100f).ToString() + "%";

            //returneaza argumentul null
            yield return null;

        }

    }
}

//Script intrare pentru Nivelul 5

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//nume script
public class Lvl5 : MonoBehaviour
{//variabile date pentru text, loading screen si slider si de verificare
    public GameObject loadingscreen;
    private bool wai = false;
    public Text pro;
    public Slider loadin;
    //metode care verifica daca exista vreo coliziune 
    private void OnTriggerEnter(Collider other)
    {
        wai = true;
    }
    private void OnTriggerExit(Collider other)
    {
        wai = false;
    }

    private void Update()
    {//conditii, daca apesi 'e' si te afli in collider si nivelul 4 este completat
        if (Input.GetKeyDown("e") && wai == true && SaveManager.instance.lvl4 == true)
        {//volumul AudioListener-ului(componenta predefinita) este setat la 0 si incepe corutina
            AudioListener.volume = 0;
            StartCoroutine(incarca());
        }

    }
    IEnumerator incarca()
    {
        //comanda predefinita care creeaza o variabila ce face asincron operatiunea cu derularea jocului
        //incarca actionand pe fundal
        //operatiune folosita pentru schimbarea de scene 
        //fiind setata la indexul din Built 
        AsyncOperation operatiune = SceneManager.LoadSceneAsync(6);
        //activeaza variabila de loading screen(canvas)
        loadingscreen.SetActive(true);
        //cat timp operatiunea nu este terminata 
        while (operatiune.isDone == false)
        {//creeaza o variabila progres care realizeaza calcule matematice, cu raspunsul intre 0 si 1
            //progresul actiunii fiin impartit la 0.9, pentru a da rezultate inclusiv cu 1
            float progres = Mathf.Clamp01(operatiune.progress / 0.9f);
            //sliderul ia valoarea progresului, schimbandu-se in functie de el
            loadin.value = progres;
            //textul realizeaza un calcul matematic , care rotunjeste progresul
            //il inmulteste cu 100 pentru ca progresul sa fie intre 0% si 100%
            //Transforma variabila in data de tip String si adauga semnul"%"
            pro.text = Mathf.Round(progres * 100f).ToString() + "%";

            //returneaza argumentul null
            yield return null;

        }

    }
}

//Script pentru Secretul Final din Meniu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class mega : MonoBehaviour
{//setare variabilelor de tip float cu roll de coordonate
    //setare variabilelor de tip obiecte pentru folosire
    //setarea variabilelor pentru verificare
    public GameObject podea;
    private bool es = false;
    public GameObject player;
    private float pozx = -0.48f;
    private float pozy = 4.98f;
    private float pozz = -46.35f;
    public GameObject audem;
    private bool odata = false;
    //metode care verifica coliziunea in Collider
    private void OnTriggerEnter(Collider other)
    {
        es = true;
    }
    private void OnTriggerExit(Collider other)
    {
        es = false;
    }
    private void Update()
    {//Conditii, daca apesi tasta 'e' si esti variabila de coliziune este adevarata si toate secretele au fost descoperite
        //si variabila odata (verifica si face actiune o singura data) este falsa
        if (Input.GetKeyDown("e") && es == true && odata == false && SaveManager.instance.secret22 == true && SaveManager.instance.secret3 == true && SaveManager.instance.secret4 == true && SaveManager.instance.secret5 == true)
        {//variabila devine adevarata,Se gaseste componenta BoxCollider al obiectului podea si devine trigger
       
            odata = true;
            podea.GetComponent<BoxCollider>().isTrigger = true;
            //se opresc toate sunetele posibile prin referinta la AudioManager
            audem.GetComponent<AudioManager>().Stop("Meniu");
            audem.GetComponent<AudioManager>().Stop("doom");
            audem.GetComponent<AudioManager>().Stop("ultimate");
            //Se activeaza Din Componenta Audiomanager Muzica cu numele respectiv
            audem.GetComponent<AudioManager>().Play("ricardo");
            //se foloseste comanda de delay pentru un subprogram separat
        }
        //Conditii, daca BoxColliderul obiectului podea este trigger si apesi tasta 'f'
        if (podea.GetComponent<BoxCollider>().isTrigger == true && Input.GetKeyDown("f"))
        {//BoxColliderul obiectului dezactiveaza triggerul si Playerul este transportat la coordonatele anterioare
            podea.GetComponent<BoxCollider>().isTrigger = false;
            player.transform.position = new Vector3(pozx, pozy, pozz);
            //Din Componenta AudioManager se opreste muzica respectiva , si se porneste muzica de meniu
            audem.GetComponent<AudioManager>().Stop("ricardo");
            audem.GetComponent<AudioManager>().Play("Meniu");
            //reactivarea variabilei pentru a putea reintra
            odata = false;
        }
    }

}

//Script pentru interactiunea cu butoanele din meniu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//nume script
public class Meniuint : MonoBehaviour
{//variabile de tip obiecte pentru butoane
    public GameObject continuarecanv;
    public GameObject canvnew;
    public GameObject start;
    private void Update()
    {//conditie, daca in save manager variabila second e adevarata(variabila care verifica daca butonul a mai fost apasat
        if (SaveManager.instance.second == true)
        {//activeaza butonul de continuare , cel de NewGame si dezactiveaza pe celalalt de NewGame
            continuarecanv.SetActive(true);
            canvnew.SetActive(true);
            start.SetActive(false);
        }
    }
    //subprogram care verifica daca e prima data cand intri in meniu
    public void firsttime()
    {
        AudioListener.volume = 0f;
        SaveManager.instance.second = true;
    }
} 

//Script pentru afisarea textului in meniu doar o data

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class MeniuS : MonoBehaviour
{//variabile pentru verificare si de tip obiecte
    public GameObject canvas;
    public GameObject txt;
    private bool afost = false;
    //subprogram separat folosit ulterior
    void arata()
    {//Conditii, daca in SaveManager aparut e false (aparut fiin o variabila care inregistreaza daca textul a mai fost afisat)
        //si a fost care reprezinta o variabila ce realizeaza actiunea o data
        if (SaveManager.instance.aparut == false && afost == false)
        {//obiectul de tip canvas devine activ
            canvas.SetActive(true);
            //se activeaza componenta animatie de la obiectul text
            txt.GetComponent<Animation>().Play("textmeniu");
            //SaveManagerul inregistreaza variabila aparut in baza de date
            //Acest text nu va mai fii afisat
            SaveManager.instance.aparut = true;
            SaveManager.instance.Save();
            //variabila devine adevarata pentru a nu reincepe procesu
            afost = true;

        }
    }
    //metoda predefinita de unity pentru Updatarea frame cu frame
    private void Update()
    {//comanda de delay este apelata pe subprogramele cu numele respective pe durata de (2 secunde si 4.8 secunde)
        Invoke("arata", 2);
        Invoke("pa", 4.8f);
    }
    //subprogram care inchide canvasul
    void pa()
    {
        canvas.SetActive(false);
    }
}

//Script Pentru resetarea bazei de data si a Jocului(New Game)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//nume subprogram
public class NewGame : MonoBehaviour
{//variabile de obiecte pentru loadingscreen,de text si de slider
    public GameObject loadingscreen;
    public Text pro;
    public Slider loadin;
    //subprogram care reseteaza baza de date in totalitate si care activeaza corutina
    public void New(int indexscene)
    {
        SaveManager.instance.lvl1 = false;
        SaveManager.instance.lvl5 = false;
        SaveManager.instance.lvl4 = false;
        SaveManager.instance.lvl3 = false;
        SaveManager.instance.lvl2 = false;
        SaveManager.instance.tut = false;
        SaveManager.instance.secret5 = false;
        SaveManager.instance.secret4 = false;
        SaveManager.instance.secret3 = false;
        SaveManager.instance.secret22 = false;
        SaveManager.instance.secret1 = false;
        SaveManager.instance.placa1 = false;
        SaveManager.instance.placa2 = false;
        SaveManager.instance.placa3 = false;
        SaveManager.instance.placa4 = false;
        SaveManager.instance.placa5 = false;
        SaveManager.instance.aparut = false;
        SaveManager.instance.Save();

        AudioListener.volume = 0f;
        StartCoroutine(incarca(indexscene));
    }
    //subprogramul foloseste indexscene deoarece se poate seta direct de pe buton Scena unde vrei sa fii trimis
    IEnumerator incarca(int indexscene)
    {
        //comanda predefinita care creeaza o variabila ce face asincron operatiunea cu derularea jocului
        //incarca actionand pe fundal
        //operatiune folosita pentru schimbarea de scene 
        //fiind setata la indexul din Built 
        AsyncOperation operatiune = SceneManager.LoadSceneAsync(indexscene);
        //activeaza variabila de loading screen(canvas)
        loadingscreen.SetActive(true);
        //cat timp operatiunea nu este terminata 
        while (operatiune.isDone == false)
        {//creeaza o variabila progres care realizeaza calcule matematice, cu raspunsul intre 0 si 1
            //progresul actiunii fiin impartit la 0.9, pentru a da rezultate inclusiv cu 1
            float progres = Mathf.Clamp01(operatiune.progress / 0.9f);
            //sliderul ia valoarea progresului, schimbandu-se in functie de el
            loadin.value = progres;
            //textul realizeaza un calcul matematic , care rotunjeste progresul
            //il inmulteste cu 100 pentru ca progresul sa fie intre 0% si 100%
            //Transforma variabila in data de tip String si adauga semnul"%"
            pro.text = Mathf.Round(progres * 100f).ToString() + "%";

            //returneaza argumentul null
            yield return null;

        }

    }
}

//Sript pentru Meniul De pauza

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//nume script
public class pauza : MonoBehaviour
{//variabile verificare, obiecte pentru meniul de pauza si loadingscreen
    //variabile pentru text si pentru slider
    public static bool pauz = false;

    public GameObject meniupauza;
    public GameObject loadingscreen;
    public Text pro;
    public Slider loadin;
    //metoda predefinita care updateaza frame cu frame
    void Update()
    {   //Conditie, daca variabila este falsa , cursorul devine blocat si invizibil
        //Daca variabila e adevarata , cursorul devine deblocat si vizibil
        if (pauz == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if (pauz == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
            
        //Conditie, daca tasta escape este apasata si variabila este adevarata 
        //Se apeleaza subprogramul Resume() si cursorul devine blocat si invizibil
        //Altfel se apeleaza subprogramul Pause() si cursorul devine vizibil si deblocat
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauz == true)
            {
                Resume();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false ;
            }
            else
            {
                Pause();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                
            }
        }
    }
    //subprogram care dezactiveaza meniul de pauza , seteaza timpul la normal
    //reseteaza variabila la fals;
    public void Resume()
    {
        meniupauza.SetActive(false);
        Time.timeScale = 1f;
        pauz = false;
    }
    //subprogram care activeaza meniul de pauza , blocheaza timpul 
    //seteaza variabila adevarata
    void Pause()
    {
        meniupauza.SetActive(true);
        Time.timeScale = 0f;
        pauz = true;
    }
    //subprogram folosit la butoane , pentru trimiterea inapoi in meniu
    //acesta seteaza timpul la normal, seteaza 0 volumul AudioListeneru-lui
    //AudioListener este o componenta predefinita care percepe sunetele 
    //incepe corutina care te trimite inapoi in meniu
    //subprogramul foloseste o variabila de tip int "indexscene" prin care
    //setezi direct din butoane la ce scena vrei sa te trimita
    public void Nivele(int indexscene)
    {
        Time.timeScale = 1f;
        AudioListener.volume = 0f;
        StartCoroutine(incarca(indexscene));
    }

    //subprogram care realizeaza aceeasi actiune ca cel de sus 
    //doar ca acesta te trimite in interfata meniului
    public void QuitGame(int indexscene)
    {
        Time.timeScale = 1f;
        AudioListener.volume = 0f;
        StartCoroutine(incarca(indexscene));
    }
    //foloseste variabila indexscene pentru a putea seta din interfata butoanelor scena
    IEnumerator incarca(int indexscene)
    {
        //comanda predefinita care creeaza o variabila ce face asincron operatiunea cu derularea jocului
        //incarca actionand pe fundal
        //operatiune folosita pentru schimbarea de scene 
        //fiind setata la indexul din Built 
        AsyncOperation operatiune = SceneManager.LoadSceneAsync(indexscene);
        //activeaza variabila de loading screen(canvas)
        loadingscreen.SetActive(true);
        //cat timp operatiunea nu este terminata 
        while (operatiune.isDone == false)
        {//creeaza o variabila progres care realizeaza calcule matematice, cu raspunsul intre 0 si 1
            //progresul actiunii fiin impartit la 0.9, pentru a da rezultate inclusiv cu 1
            float progres = Mathf.Clamp01(operatiune.progress / 0.9f);
            //sliderul ia valoarea progresului, schimbandu-se in functie de el
            loadin.value = progres;
            //textul realizeaza un calcul matematic , care rotunjeste progresul
            //il inmulteste cu 100 pentru ca progresul sa fie intre 0% si 100%
            //Transforma variabila in data de tip String si adauga semnul"%"
            pro.text = Mathf.Round(progres * 100f).ToString() + "%";

            //returneaza argumentul null
            yield return null;

        }

    }
}

//Script pentru pozitii random cheie

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class random : MonoBehaviour
{//variabila de tip obiect, si variabile pentru pozitii
    //variabila de tip ind pentru preluarea de valori
    public GameObject key;
    private float pozX;
    private float pozY;
    private float pozZ;
    public int Rand;
    //metoda care apeleaza alt subprogram imediat ce intri in scena inaintea Updatului
    void Start()
    {
        Spawn();
    }
    //subprogram care alege una din pozitiile random si transforma cheia la o pozitie 
    void Spawn()
    {
        RandomPoz();
        key.transform.position = new Vector3(pozX, pozY, pozZ);
    }
    //subprogram care randomizeaza pozitiile posibile alea cheii
    public void RandomPoz()
    {
       Rand = Random.Range(1, 8);
        if (Rand == 1)
        {
            pozX = -11.65f;
            pozY = 1f;
            pozZ = 23.58f;
        }
        else if (Rand == 2)
        {
            pozX = -10.3f;
            pozY = 1f;
            pozZ = 5.5f;
        }
        else if (Rand == 3)
        {
            pozX = -14.5f;
            pozY = 1f;
            pozZ = -22.76f;
        }
        else if (Rand == 4)
        {
            pozX = 11f;
            pozY = 1f;
            pozZ = -22.76f;
        }
        else if (Rand == 5)
        {
            pozX = 9.9f;
            pozY = 1f;
            pozZ = -0.85f;
        }
        else if (Rand == 6)
        {
            pozX = -4.03f;
            pozY = 1f;
            pozZ = -10f;
        }
        else if (Rand == 7)
        {
            pozX = -7.215f;
            pozY = 1f;
            pozZ = -2.8f;
        }
        else if (Rand == 8)
        {
            pozX = 7.572f;
            pozY = 1f;
            pozZ = 12.313f;
        }
    }
}


//Script de Pick Up / Ridicare de obiecte 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform dest;  //O variabila care denumeste destinatia unde vom putea tine obiectele
    public bool cheie;   //o variabila de tip bool pentru cheie
    void OnMouseDown()
    {   //Atunci cand apasam pe cheie si cand o ridicam
        cheie = true;   //Cheia va deveni true
        GetComponent<Rigidbody>().useGravity = false;  //Gravitatia va deveni falsa
        GetComponent<MeshCollider>().enabled = false;  //Nu vom avea collider
        GetComponent<Rigidbody>().freezeRotation = true; //Obiectul(cheia) nu se va roti
        this.transform.position = dest.position;  //Pozitia obiectului va fi la destinatia noastra
        this.transform.parent = GameObject.Find("Obiect").transform; //obiectul va intra intr-un parinte cu destinatia
        GetComponent<Rigidbody>().isKinematic = true;  //Fortele pot actiona asupra obiectului
    }

    void OnMouseUp()
    {   //Atunci cand lasam obiectul, acesta va pica, iar conditiile viitoare vor fi indeplinite:
        cheie = false; //Cheia va deveni false
        this.transform.parent = null;  //Vom desfiinta parintele, astfel cheia va fi Singura in ierarhie
        GetComponent<Rigidbody>().useGravity = true;  //Gravitatia va fi ON, astfel obiectul va putea pica
        GetComponent<MeshCollider>().enabled = true;  //Obiectul nu va trece prin pamant, dar va intra in coliziune cu acesta
        GetComponent<Rigidbody>().freezeRotation = false; //Obiectul va putea sa fie rotit cand pica
        GetComponent<Rigidbody>().isKinematic = false; //Fortele nu vor actiona asupra obiectului
    }

//Script pentru Miscare

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miscare : MonoBehaviour
{   //Variabile drept referinta pentru obiecte
    public CharacterController controller;   //Aici ne va trebui un character controller, asa ca am declarat o variabila pt aceasta

    public GameObject Player;   //Aici vom pune player-ul

    //Variabile pentru viteza, gravitatie si saritura
    public float viteza = 4f;
    public float gravitatie = -10f;
    public float saritura = 1f;

    Vector3 velocitate;

    //Variabile pentru picioare, distanta si un LayerMask care face referinta la straturile pe care jucatorul le va intalni, acesta este pamantul
    public Transform Picioare;
    public float distanta = 0.4f;
    public LayerMask Pamant;
    bool PePamant;  //variabila aceasta este una pt a verifica daca player ul are picioarele pe pamant
    void Update()
    {
        PePamant = Physics.CheckSphere(Picioare.position, distanta, Pamant); //Aici vom vedea daca jucatorul se afla pe pamant

        if(PePamant && velocitate.y <0)
        {   //Daca jucatorul se afla pe pamant si viteza de pe oY este mai mica decat 0, viteza de pe Oy va lua valoarea -2f
            velocitate.y = -2f;
        }

        
        //Aici denumim niste variabile de tip float pentru valori de pe  Axele Orizontala si Verticala
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 miscare = transform.right * x + transform.forward * z;


        //Functia Move contribuie la miscarea unui obiect a carui componenta este un CharacterController
        controller.Move(miscare * viteza *Time.deltaTime);

        if (Input.GetButtonDown("Jump") && PePamant)
                {//Aici daca jucatorul va apasa tasta Space si daca se afla pe pamant, jucatorul va putea sari
            velocitate.y = Mathf.Sqrt(saritura * -2f * gravitatie);
        }
        //Altfel, daca jucatorul se afla pePamant, acesta nu va sari
            velocitate.y += gravitatie * Time.deltaTime;

        controller.Move(velocitate * Time.deltaTime);
    }
}


//Script pentru Privire/Camera/Look

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class look : MonoBehaviour
{
    public float senzitivitate = 100f; //Aici denumim o variabila care reprezinta cat de sensibila este camera jucatorului

    public Transform corp;  //Aici vom denumi o variabila pentru corpul a carui camera o vom modifica, jucatorul in cazul nostru

    float Rotatiex = 0f; //Aceasta este o variabila care denumeste Rotatia pe axa Ox
    void Start()
    {   //Functia aceasta blocheaza cursorul in camera jucatorului
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {      //Aici am declarat 2 variabile pentru coordonate precum X si Y
        float coordx = Input.GetAxis("Mouse X") * senzitivitate * Time.deltaTime;
        float coordy = Input.GetAxis("Mouse Y") * senzitivitate * Time.deltaTime;
        //Rotatia de pe Ox va fi egala cu diferenta dintre el si coordonata de pe Oy * senzivitate si cu timpul in care se desfasoara
        Rotatiex -= coordy;
        Rotatiex = Mathf.Clamp(Rotatiex, -75f, 75f); //Functia aceasta returneaza un rezultat real dintre minimul nostru(Rotatiex) si maximul -75f

        transform.localRotation = Quaternion.Euler(Rotatiex, 0f, 0f);
        //Functiile acestea desemneaza rotatiile de pe axe
        corp.Rotate(Vector3.up * coordx);
    }
}

// Script pentru Excalibur LVL5

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume subprogram
public class ScriptExcalibur : MonoBehaviour
{//variabile de tip obiecte (canvas,text,etc.)
    //variabile pentru verificare
    public GameObject sabie;
    private bool razwan = false;
    private bool odata = false;
    private bool apare = false;
    public GameObject cufar;
    public GameObject text;
    public GameObject audem;

    void Update()
    {//conditii, daca este apasata tasta 'e' si exista coliziune  
        //si variabila odata , folosita pentru repetarea actiunii o singura data e falsa
        if (Input.GetKey("e") && razwan == true && odata == false)
        {//in obiectul sabie se acceseaza componenta animatie , si se activeaza
            sabie.GetComponent<Animation>().Play("anim");
            //variabila devine adevarata pentru a stopa repetarea
            odata = true;
            //Componenta AudioManager activeaza sunetul cu numele respectiv
            audem.GetComponent<AudioManager>().Play("Boom");
            //variabila apare devuine adevarata
            apare = true;
            //textul se activeaza , si din componente se activeaza animatia
            text.SetActive(true);
            text.GetComponent<Animation>().Play("Stefanelenes");
            //comanda de delay pentru subprogramul respectiv
            Invoke("mana", 3);
        }
        //conditie care face cufarul sa apara
        if(apare == true)
        {
            cufar.SetActive(true);
          
        }
        
    }      
    //subprogram care dezactiveaza textul
    void mana()
    {
        text.SetActive(false);
    }
                                  //subprogram care verifica coliziunea    
    private void OnTriggerEnter(Collider other)
    {                   
        razwan = true;
    }
    private void OnTriggerExit(Collider other)
    {
        razwan = false;
    }

   
}

//Script pentru baza de date 

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;

public class SaveManager : MonoBehaviour
{//Apeleaza o funtie predefinita , dand o variabila instanta, care seteaza o lista privata si care ea fiecare funtie
    public static SaveManager instance { get; private set; }
    //Secrete

    public bool secret1 = false;
    public bool secret22 = false;
    public bool secret3 = false;
    public bool secret4 = false;
    public bool secret5 = false;
    //Meniu Nivele
    public bool tut = false;
    public bool lvl1 = false;
    public bool lvl2 = false;
    public bool lvl3 = false;
    public bool lvl4 = false;
    public bool lvl5 = false;
    //Lvl2
    public bool placa1;
    public bool placa2;
    public bool placa3;
    public bool placa4;
    public bool placa5;
    //canvas Meniu
    public bool second = false;
    public bool aparut = false;
    //subprogram care la apelarea scriptului , verifica variabila
    //daca nu e goala si e diferita de precedenta se distruge obiectul
    //altfel instanta ia valoarea listei din momentul respectiv
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
        //comanda care nu distruge la incarcare obiectul pe care este pus scriptul
  
        DontDestroyOnLoad(gameObject);
        //subprogram apelat
        Load();
    }

    public void Load()
    {//Conditii, daca Fila exista , variabilele din aplicatie pot fi ridicate din baza de date
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {//comanda predefinita de unity care reprezinta un reformator binar, realizand o variabila,in care datele se stocheaza in forme de cifre
            BinaryFormatter bf = new BinaryFormatter();
            //comanda predefinita care creaza o variabila noua si care deschide fila de salvari si o lasa deschisa pentru extragere
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            //comanda predefinita care creeaza o variabila in care datele stocate sunt trimise din fila in variabila dupa reformatare
            PlayerData_Storage data = (PlayerData_Storage)bf.Deserialize(file);

            //variabilele iau datele stocate din variabila data 
            secret1 = data.secret1;
            secret22 = data.secret22;
            secret3 = data.secret3;
            secret4 = data.secret4;
            secret5 = data.secret5;
            tut = data.tut;
            lvl1 = data.lvl1;
            lvl2 = data.lvl2;
            lvl3 = data.lvl3;
            lvl4 = data.lvl4;
            lvl5 = data.lvl5;
            placa1 = data.placa1;
            placa2 = data.placa2;
            placa3 = data.placa3;
            placa4 = data.placa4;
            placa5 = data.placa5;
            aparut = data.aparut;
            second = data.second;
            //inchide fila dupa ridicarea informatiei
            file.Close();
        }
    }
    //subprogram folosit in salvarea datelor
    public void Save()
    {//comanda predefinita pentru crearea unei variabile noi de tip reformator binar
        //aceasta formatand informatiile in cifre pentru usurare si pentru scaderea memoriei(mai putina utilizata)
        BinaryFormatter bf = new BinaryFormatter();
        //comanda predefinita care realizeaza o variabila , in care se creaza o fila si in care se stocheaza datele aplicatiei
        //datele aplicatiei reprezinta datele introduce de noi
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        //comanda care creaza o variabila , care ia forma unui Storage Nou de date
        PlayerData_Storage data = new PlayerData_Storage();
        //datele cuprinse de-a lungul actiunii fiind slalvate in variabile si contopite in cod mai tarziu
        data.secret4 = secret4;
        data.secret1 = secret1;
        data.secret3 = secret3;
        data.secret22 = secret22;
        data.secret5 = secret5;
        data.tut = tut;
        data.lvl1 = lvl1;
        data.lvl2 = lvl2;
        data.lvl3 = lvl3;
        data.lvl4 = lvl4;
        data.lvl5 = lvl5;
        data.placa1 = placa1;
        data.placa2 = placa2;
        data.placa3 = placa3;
        data.placa4 = placa4;
        data.placa5 = placa5;
        data.aparut = aparut;
        data.second = second;
        //serializeaza statusul obiectului stocat si numele acestuia in forma de bytes
        bf.Serialize(file, data);
        file.Close();
    }
}
//Camp predefinit care explica posibilitatea clasei de a ii fi luat statutul si de a fi stocat in forma de bytes
[Serializable]
class PlayerData_Storage
{
    public bool secret1;
    public bool secret22;
    public bool secret3;
    public bool secret4;
    public bool secret5;
    public bool tut;
    public bool lvl1;
    public bool lvl2;
    public bool lvl3;
    public bool lvl4;
    public bool lvl5;
    public bool placa1;
    public bool placa2;
    public bool placa3;
    public bool placa4;
    public bool placa5;
    public bool aparut;
    public bool second;
}

//Script pentru secretul1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class secret1 : MonoBehaviour
{//variabile de verificare si variabile de tip obiect(canvas & text)
    private bool mere = false;
    private bool odata = false;
    public GameObject text;
    public GameObject can;
//variabila care verifica daca exista coliziune , in collider
    private void OnTriggerEnter(Collider other)
    {
        mere = true;
    }
    private void OnTriggerExit(Collider other)
    {
        mere = false;
    }
    private void Update()
    {//conditii, care verifica daca actiunea a fost facuta si daca , colliderul e activ
        if (mere == true && odata == false)
        {//instanta secret1 , se salveaza in Baza de Date 
            SaveManager.instance.secret1 = true;
            SaveManager.instance.Save();
            //comanda de delay utilizata pentru subprogramul respectiv
            Invoke("papa", 4);
            //variabila care realizeaza actiunea isi schimba valoarea pentru a nu se incepe iar actiunea
            odata = true;
            //canvasul este activat , iar in obiectul text se cauta componenta animatie , care se activeaza
            can.SetActive(true);
            text.GetComponent<Animation>().Play("glow");
        }
    }

    
    //script care distruge obiectul pe care se afla scriptul si care dezactiveaza canvasul
void papa()
    {
        Destroy(gameObject);
        can.SetActive(false);
    }
}

//Script secret2

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class secret2 : MonoBehaviour
{//variabila care transforma pozitia
    //variabile de tip obiecte
    //variabile folosite pentri verificare
    public Transform destin;
    public GameObject canvas;
    public GameObject text;
    private bool gata = false;
    //metoda predefinita care actioneaza la click
    void OnMouseDown()
    {//cauta componenta "Rigidbody" a obiectului pe care se afla scriptul si dezactiveaza gravitatia
        //Cauta componenta Mesh-ului Colliderului  si o dezactiveaza. 
        //cauta componenta obiectului si blocheaza rotatia
        //transforma pozitia obiectului la "Obiect" si il face 'Child'
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<MeshCollider>().enabled = false;
        GetComponent<Rigidbody>().freezeRotation = true;
        this.transform.position = destin.position;
        this.transform.parent = GameObject.Find("Obiect").transform;
        //se salveaza in baza de date ca secretul a fost descoperit
        SaveManager.instance.secret22 = true;
        SaveManager.instance.Save();
        //comanda de delay , cu numele subprogramului respectiv
        Invoke("papa", 4);
        //conditie care activeaza comanda de delay 
        if (gata == false)
        {
            Invoke("mere", 1);
        }
    }
    //subprogram care distruge obiectul cu scriptul
    void papa()
    {
        Destroy(gameObject);
    }
    //subprogram care dezactiveaza canvasul
    void gg()
    {
        canvas.SetActive(false);
    }
    //subprogram care activeaza canvasul, activeaza animatia textului
    //transforma variabila gata adevarata, pentru a nu se putea repeta campul
    
    void mere()
    {
        canvas.SetActive(true);
        text.GetComponent<Animation>().Play("aparities");
        gata = true;
        //comanda folosita pentru delay pentru subprogramul respectiv
        Invoke("gg", 3);
    }
}


//Script Secret 3

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class secret3 : MonoBehaviour
{//variabila care transforma pozitia
    //variabile de tip obiecte
    //variabile folosite pentri verificare
    public Transform destinatie3;
    public GameObject canvas;
    public GameObject text;
    private bool gata = false;
    //metoda predefinita care actioneaza la click
    void OnMouseDown()
    {//cauta componenta "Rigidbody" a obiectului pe care se afla scriptul si dezactiveaza gravitatia
        //Cauta componenta Mesh-ului Colliderului  si o dezactiveaza. 
        //cauta componenta obiectului si blocheaza rotatia
        //transforma pozitia obiectului la "Obiect" si il face 'Child'
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<MeshCollider>().enabled = false;
        GetComponent<Rigidbody>().freezeRotation = true;
        this.transform.position = destinatie3.position;
        this.transform.parent = GameObject.Find("Obiect").transform;
        //se salveaza in baza de date ca secretul a fost descoperit
        SaveManager.instance.secret3 = true;
        SaveManager.instance.Save();
        //comanda de delay , cu numele subprogramului respectiv
        Invoke("papa", 4);
        //conditie care activeaza comanda de delay 
        if (gata == false)
        {
            Invoke("mere", 1);
        }
    }
    //subprogram care distruge obiectul cu scriptul
    void papa()
    {
        Destroy(gameObject);
    }
    //subprogram care dezactiveaza canvasul
    void gg()
    {
        canvas.SetActive(false);
    }
    //subprogram care activeaza canvasul, activeaza animatia textului
    //transforma variabila gata adevarata, pentru a nu se putea repeta campul

    void mere()
    {
        canvas.SetActive(true);
        text.GetComponent<Animation>().Play("an1");
        gata = true;
        //comanda folosita pentru delay pentru subprogramul respectiv
        Invoke("gg", 3);
    }
}

//Script secret 4

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class secret4 : MonoBehaviour
{//variabila care transforma pozitia
    //variabile de tip obiecte
    //variabile folosite pentri verificare
    public Transform destinatie;
    public GameObject canvas;
    public GameObject text;
    private bool gata = false;
    //metoda predefinita care actioneaza la click
    void OnMouseDown()
    {//cauta componenta "Rigidbody" a obiectului pe care se afla scriptul si dezactiveaza gravitatia
        //Cauta componenta Mesh-ului Colliderului  si o dezactiveaza. 
        //cauta componenta obiectului si blocheaza rotatia
        //transforma pozitia obiectului la "Obiect" si il face 'Child'
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<MeshCollider>().enabled = false;
        GetComponent<Rigidbody>().freezeRotation = true;
        this.transform.position = destinatie.position;
        this.transform.parent = GameObject.Find("Obiect").transform;
        //se salveaza in baza de date ca secretul a fost descoperit
        SaveManager.instance.secret4 = true;
        SaveManager.instance.Save();
        //comanda de delay , cu numele subprogramului respectiv
        Invoke("papa", 4);
        //conditie care activeaza comanda de delay 
        if (gata == false)
        {
            Invoke("mere", 1);
        }
    }
    //subprogram care distruge obiectul cu scriptul
    void papa()
    {
        Destroy(gameObject);
    }
    //subprogram care dezactiveaza canvasul
    void gg()
    {
        canvas.SetActive(false);
    }
    //subprogram care activeaza canvasul, activeaza animatia textului
    //transforma variabila gata adevarata, pentru a nu se putea repeta campul

    void mere()
    {
        canvas.SetActive(true);
        text.GetComponent<Animation>().Play("take");
        gata = true;
        //comanda folosita pentru delay pentru subprogramul respectiv
        Invoke("gg", 3);
    }
}

//Script secret 5

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class secret5 : MonoBehaviour
{//variabile folosite pentru verificare si de tip obiect
    private bool apasat = false;
    private bool ini = false;
    public GameObject text;
    public GameObject canv;
    //verificare daca exista coliziune cu un collider
    private void OnTriggerEnter(Collider other)
    {
        ini = true;
    }
    private void OnTriggerExit(Collider other)
    {
        ini = false;
    }

    void Update()
    {//conditii, daca 'e' este apasat, variabila apasat este false
        //apasas fiind o variabila care realizeaza decat o data actiunea
        //si exista coliziune
        if (Input.GetKeyDown("e") && apasat == false && ini == true)
        {//se salveaza completarea secretului 5
            SaveManager.instance.secret5 = true;
            SaveManager.instance.Save();
            //se activeaza canvasul
            canv.SetActive(true);
            //se cauta si se activeaza componenta animation
            text.GetComponent<Animation>().Play("hehe");
            //se foloseste comanda pentru delay cu numele subprogramului respectiv
            Invoke("mana", 2);
            //variabila devine adevarata pentru a stope reluarea actiunii
            apasat = true;
        }
    }
    //subprogram care dezactiveaza canvasul(element UI)
    void mana()
    {
        canv.SetActive(false);
    }
}

//Script meniu secret

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class Secretmeniu : MonoBehaviour
{//variabila de tim obiect si pentru verificare
    public GameObject men;
    private bool odata = false;
    void Update()
    {//verificare conditii, daca obiectul pe care este scriptul este activ si daca actiunea s-a intamplat odata
        if (gameObject.activeSelf == true && odata == false)
        {
            //se opreste muzica meniului principal si se porneste cea a celui secret
            men.GetComponent<AudioManager>().Stop("Meniustart");
            men.GetComponent<AudioManager>().Play("ricardo");
            odata = true;
        }
        
    }
        
}

//Script pentru meniul de setari

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
//nume script
public class Setari : MonoBehaviour
{//comanda predefinita , creaza o variabila
    public AudioMixer audiomixer;
    //Camp Care acceseaza rezolutiile suportate de unity
    Resolution[] resolutions;
    //variabila de tip dropdown
    public Dropdown rezolutie;
    //metoda care se activeaza la start inaintea oricarei metode Update
    void Start()
    {//variabila ia marimea ecranului, si curata toate rezolutiile adaugate in text
        resolutions = Screen.resolutions;

        rezolutie.ClearOptions();
        //creaza o lista noua de stringuri
        List<string> optiuni = new List<string>();
        //creaza o variabila care inregistreaza rezolutia ecranului (intai incepe cu val 0)
        int rezolutiestart = 0;
        //Pentru fiecare valoare incepand cu 0 si ajungand la lungimea numarului de rezolutii , valoarea creste
        for ( int i = 0;i <  resolutions.Length; i++)
        {
            //creeaza o variabila de tip string , care ia masura fiecarei rezolutii gasite (Lungime , Inaltime si refreshrate-ul)
            string optiune = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            //Si le adauga ca optiuni  posibile
            optiuni.Add(optiune);
            //functii predefinite de la unity, compararea directa nu merge scrisa direct, fiind necesara scrierea pe bucati
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height && resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                //rezolutia ia valoarea fiecarei rezolutii stocate
                rezolutiestart = i;
            }
        }
        //se adauga in dropdawn optiunile posibile, la inceput intrand cu rezolutia ecranului
        //se reinprospateaza valorile afisate
        rezolutie.AddOptions(optiuni);
        rezolutie.value = rezolutiestart;
        rezolutie.RefreshShownValue();
    }
    //subprogram care foloseste sliderul si care seteaza volumul
    public void Volum(float volum)
    {
        audiomixer.SetFloat("volum", volum);
    }
    //subprogram care afiseaza toate optiunile de calitate
    public void Quality(int calitate)
    {
        QualitySettings.SetQualityLevel(calitate);
    }
    //subprogram care activeaza si dezactiveaza fullscreenul
    public void fullscreen(bool este)
    {
        Screen.fullScreen = este;
    }
    //subprogram care activeaza si dezactiveaza butonul de mute
    public void farasunet(bool mut)
    {
        if(mut == true)
        {
            AudioListener.volume = 0;
        }
        if (mut == false)
        {
            AudioListener.volume = 1;
        }
    }
    //subprogram care seteaza rezolutia , prin campiisetati
    public void rezset(int rez)
    {
        Resolution resolution = resolutions[rez];
        //rezolutia ia valoarea lungimii , inaltimii, este setat by default pe fullscreen si refreshrate-ul
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen, resolution.refreshRate);
    }
}

//Script pentru intoarcere din meniu de Sfarsit

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//nume script
public class Sfarsit : MonoBehaviour
{//subprogram utilizat prin butoane care te trimite inapoi in meniu
    public void lameniu()
    {
        AudioListener.volume = 0;
        SceneManager.LoadScene(0);
    }
}


//Script utilizat pentru sound

using UnityEngine.Audio;
using UnityEngine;
[System.Serializable] //Pentru a aparea in unity
//nume script
public class Sound
{
    //seteaza un nume de tip string si gaseste clipul cu numele respectiv
    public string name;
    public AudioClip clip;

    [Range(0f,1f)] //Sliders pt volum
    public float volume;
    [Range(.1f, 3f)]
    public float pitch; //Sliders pt pitch

    public bool loop;

[HideInInspector] //Nu apare in inspector
    public AudioSource source;

}

//Script pentru activare text

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class start3 : MonoBehaviour
{//variabile de tip obiecte si pentru verificare
    public GameObject canvas;
    public GameObject text;
    private bool afost= false;

    private void Update()
    {//conditie, variabila este utilizata doar o singura data,aceasta fiin falsa
        if (afost == false)
        {//comanda de delay cu nume subprogramului respectiv
            Invoke("canva", 2);
        }
    }
    //subprogram utilizat pentru activarea obiectului de tip canvas
    //cautarea si activarea componentei de tip animation a textului
    //transformarea variabilei , in adevarata
    //invokarea subprogramului cu numele respectiv
void canva()
    {
        canvas.SetActive(true);
        text.GetComponent<Animation>().Play("animeisan");
        afost = true;
        Invoke("ies", 3);
    }
    //sugprogram care dezactiveaza obiectul de tip canvas
    void ies()
    {
        canvas.SetActive(false);
    }
}


//Script Pentru Start al textului

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class startullabaiat : MonoBehaviour
{//variabile de tip obiect si pentru verificare
    public GameObject canvas;
    public GameObject text;
    private bool merge = false;
    //subprogram care activeaza obiectul de ti canvas
    //cauta si activeaza componenta Animation a textului
    
    void mana ()
    {
        canvas.SetActive(true);
        text.GetComponent<Animation>().Play("start2");
        //comanda de delay cu numele subprogramului respectiv
        Invoke("stop", 3);
    }
    //subprogram care dezactiveaza canvasul
    void stop()
    {
        canvas.SetActive(false);
    }
    //metoda care verifica conditia , invoke subprogramul mana si transforma variabila de verificat adevarata
    //variabila este transformata pentru a impiedica repetarea procesului de catre metoda
    private void Update()
    {
        if (merge == false)
        {
            Invoke("mana", 1);
            merge = true;
        }
    }
}

//Script pentru deschiderea muntelui

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class TestScr : MonoBehaviour
{
   //referinta la un script extern,variabile de tip obiect si pentru verificare
    public GameObject munte;
    public DamageScript bs;
    public bool gigel = false;
    public Damage2 cl;
    public Damage3 nt;
   

   
    void Update()
    {//conditii, daca in scriptul extern distrus e adevarat si variabila gigel este false
        //gigel este folosit pentru repetarea programului o singura data
        if (bs.distrus == true && gigel == false )
        {  //gigel devine adevarat pentru a impiedica repetitia
            gigel = true;
            //se ia componenta de tip animation a muntelui si se activeaza
            munte.GetComponent<Animation>().Play("AnimMunte");
            //se cauta si se porneste sunetul , prin AudioManager
            FindObjectOfType<AudioManager>().Play("mountainsound");
        }


    }
}

//Scripturi Tragere pentru Levere

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class trage : MonoBehaviour
{//variabila de tip obiect, variabila cu referinta la un script extern 
    //variabile pentru verificare
    public bool Lvr1;
    public Lever lever;
    public bool edat = false;
    public GameObject partelever;
    //metoda care verifica daca exista vreun collider 
    private void OnTriggerEnter(Collider other)
    {
        Lvr1 = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Lvr1 = false;
    }
    void Update()
    {//conditii, daca se apasa tasta 'e' si exista un colider si variabila l1 a scriptului extern este adevarata
        if ( Input.GetKeyDown("e") && Lvr1 == true && lever.l1 == true)
        {//variabila devine adevarata si se activeaza componenta animation a obiectului
            edat = true;
            partelever.GetComponent<Animation>().Play("lvrjos");
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class trage2 : MonoBehaviour
{//variabila de tip obiect, variabila cu referinta la un script extern 
    //variabile pentru verificare
    public bool Lvr2;
    public Lever lever2;
    public bool edat1 = false;
    public GameObject partelever2;
    //metoda care verifica daca exista vreun collider 
    private void OnTriggerEnter(Collider other)
    {
        Lvr2 = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Lvr2 = false;
    }
    void Update()
    {//conditii, daca se apasa tasta 'e' si exista un colider si variabila l2 a scriptului extern este adevarata
        if ( Input.GetKeyDown("e") && Lvr2 == true && lever2.l2 == true)
        {//variabila devine adevarata si se activeaza componenta animation a obiectului
            edat1 = true;
            partelever2.GetComponent<Animation>().Play("lvrjos2");
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class trage3 : MonoBehaviour
{//variabila de tip obiect, variabila cu referinta la un script extern 
    public bool Lvr3;
    public Lever lever3;
    public bool edat2 = false;
    public GameObject partelever3;
    //metoda care verifica daca exista vreun collider 
    private void OnTriggerEnter(Collider other)
    {
        Lvr3 = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Lvr3 = false;
    }
    void Update()
    {//conditii, daca se apasa tasta 'e' si exista un colider si variabila l3 a scriptului extern este adevarata
        if ( Input.GetKeyDown("e") && Lvr3 == true && lever3.l3 == true)
        {//variabila devine adevarata si se activeaza componenta animation a obiectului
            edat2 = true;
            partelever3.GetComponent<Animation>().Play("lvrjos3");
        }
    }
}


//Scriptu pentru trecere perete

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class trece : MonoBehaviour
{//variabila de tip obiect si pentru verificare
    private bool odata = false;
    public GameObject chest;
    //metoda care verifica colide-ul cu un al collider
    private void OnTriggerEnter(Collider other)
    {//daca actiunea nu s-a realizat
        if (odata == false)
        {//se gaseste componenta de tip Animation a chestului si se activeaza
            chest.GetComponent<Animation>().Play("chest apare");
            //variabila devine adevarata pentru a prevenii  reinceperii metodei
            odata = true;
        }
        
    }
}

//Script pentru Tutorial

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class tutorialstart : MonoBehaviour
{//parte 1
    //variabile de tip obiect si pentru verificare
    public GameObject pp;
    public GameObject txt;
    private bool aparut = false;
    //parte 2
    public GameObject pick;
    public GameObject dial;
    public GameObject blockrosu;
    private bool aparut2 = false;
    //metoda
    private void Update()
    {//daca conditia este falsa atunci se activeaza
        if (aparut == false)
        {//se foloseste comanda de delay cu nume subprogramului respectiv
            Invoke("mana", 2);
            //variabila devina adevarata pentru a preveni reinceperea
            aparut = true;
        }
        if (aparut2 == false)
        {//se foloseste comanda de delay cu nume subprogramului respectiv
            Invoke("pickup", 12);
            //variabila devina adevarata pentru a preveni reinceperea
            aparut2 = true;
        }
    }
    //parte 1
    //subprogram care activeaza obiectul de tip canvas si de tip text , activand animatia
    //cauta Audiomanagerul si activeaza Sunetul respectiv
    void mana()
    {
        pp.SetActive(true);
        txt.GetComponent<Animation>().Play("pop");
        FindObjectOfType<AudioManager>().Play("tutorial");
        Invoke("inchide", 9);
    }
    //subprogram opreste canvasul si Sunetul
    void inchide()
    {
        pp.SetActive(false);
        FindObjectOfType<AudioManager>().Stop("tutorial");
    }
    //subprogram care activeaza obiectul de tip canvas si de tip text , activand animatia
    //cauta Audiomanagerul si activeaza Sunetul respectiv
    void pickup()
    {
        pick.SetActive(true);
        dial.GetComponent<Animation>().Play("dial");
        FindObjectOfType<AudioManager>().Play("tut2");
        //comenzile de delay cu numele subprogramelor respective
        Invoke("spawn", 2);
        Invoke("gata", 9.5f);
    }
    //dezactiveaza sunetul si canvasul
    void gata()
    {
        pick.SetActive(false);
        FindObjectOfType<AudioManager>().Stop("tut2");
    }
    //Spawneaza un block rosu pe harta 
    void spawn()
    {
        blockrosu.SetActive(true);
    }     
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class tutorialstart2 : MonoBehaviour
{    //variabile de tip obiect si pentru verificare
    //parte 3
    public GameObject pick;
    public GameObject dial;
    public GameObject usa;
    private bool aparut2 = false;
    private void Update()
    {//daca conditia este falsa atunci se activeaza
        if (aparut2 == false)
        {//se foloseste comanda de delay cu nume subprogramului respectiv
            Invoke("pickup", 24);
            //variabila devina adevarata pentru a preveni reinceperea
            aparut2 = true;
        }
    }
    //parte 3
    //subprogram care activeaza obiectul de tip canvas si de tip text , activand animatia
    //cauta Audiomanagerul si activeaza Sunetul respectiv
    void pickup()
    {
        pick.SetActive(true);
        dial.GetComponent<Animation>().Play("spawnat");
        FindObjectOfType<AudioManager>().Play("tut3");
        Invoke("spawn", 7);
        Invoke("gata", 11f);
    }
    //subprogram opreste canvasul
    void gata()
    {
        pick.SetActive(false);
    }
    //Spawneaza o usa pe harta 
    void spawn()
    {
        usa.SetActive(true);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class tutorialfinal : MonoBehaviour
{//variabile de tip obiect si pentru verificare
    //parte 4
    public GameObject gatat;
    public GameObject text;
    public GameObject chest;
    private bool aparut3 = false;
    private void Update()
    {//daca conditia este falsa atunci se activeaza
        if (aparut3 == false)
        {//se foloseste comanda de delay cu nume subprogramului respectiv
            Invoke("dai", 37);
            //variabila devina adevarata pentru a preveni reinceperea
            aparut3 = true;
        }
    }
    //subprogram care activeaza obiectul de tip canvas si de tip text , activand animatia
    //cauta Audiomanagerul si activeaza Sunetul respectiv
    void dai()
    {
        gatat.SetActive(true);
        text.GetComponent<Animation>().Play("lase");
        FindObjectOfType<AudioManager>().Play("tut4");
        Invoke("bag", 11);
        Invoke("fin", 13);
    }
    //subprogram opreste canvasul
    void fin()
    {
        gatat.SetActive(false);
    }
    //subprogramul spawneaza chestul final
    void bag()
    {
        chest.SetActive(true);
    }
}

//Script iesire joc

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class iesi : MonoBehaviour
{//subprogram folosit in buton pentru iesirea din aplicatie si inchiderea acesteia
public void exit()
    {
        Application.Quit();
    }
}


//Script incarcare

using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
//nume script
public class loading : MonoBehaviour
{//nume variabile de tip obiecte (loadingscreen),text si slider
    public GameObject loadingscreen;
    public Slider loadin;
    public Text pro;
    //subprogram folosit prin butoan pentru intrarea in nivele
public void Loading()
    {
        //incepe corutina si seteaza volumul audiolistenerului la 0;
        StartCoroutine(incarca());
        AudioListener.volume = 0f;
    }
        IEnumerator incarca()
    {
        if (SaveManager.instance.tut == true)
        {
            //comanda predefinita care creeaza o variabila ce face asincron operatiunea cu derularea jocului
            //incarca actionand pe fundal
            //operatiune folosita pentru schimbarea de scene 
            //fiind setata la indexul din Built 
            AsyncOperation operatiune = SceneManager.LoadSceneAsync(1);
            //activeaza variabila de loading screen(canvas)
            loadingscreen.SetActive(true);
            //cat timp operatiunea nu este terminata 
            while (operatiune.isDone == false)
            {//creeaza o variabila progres care realizeaza calcule matematice, cu raspunsul intre 0 si 1
             //progresul actiunii fiin impartit la 0.9, pentru a da rezultate inclusiv cu 1
                float progres = Mathf.Clamp01(operatiune.progress / 0.9f);
                //sliderul ia valoarea progresului, schimbandu-se in functie de el
                loadin.value = progres;
                //textul realizeaza un calcul matematic , care rotunjeste progresul
                //il inmulteste cu 100 pentru ca progresul sa fie intre 0% si 100%
                //Transforma variabila in data de tip String si adauga semnul"%"
                pro.text = Mathf.Round(progres * 100f).ToString() + "%";

                //returneaza argumentul null
                yield return null;

            }
        }
        if (SaveManager.instance.tut == false)
        {
            //comanda predefinita care creeaza o variabila ce face asincron operatiunea cu derularea jocului
            //incarca actionand pe fundal
            //operatiune folosita pentru schimbarea de scene 
            //fiind setata la indexul din Built 
            AsyncOperation operatiune = SceneManager.LoadSceneAsync(7);
            //activeaza variabila de loading screen(canvas)
            loadingscreen.SetActive(true);
            //cat timp operatiunea nu este terminata 
            while (operatiune.isDone == false)
            {//creeaza o variabila progres care realizeaza calcule matematice, cu raspunsul intre 0 si 1
             //progresul actiunii fiin impartit la 0.9, pentru a da rezultate inclusiv cu 1
                float progres = Mathf.Clamp01(operatiune.progress / 0.9f);
                //sliderul ia valoarea progresului, schimbandu-se in functie de el
                loadin.value = progres;
                //textul realizeaza un calcul matematic , care rotunjeste progresul
                //il inmulteste cu 100 pentru ca progresul sa fie intre 0% si 100%
                //Transforma variabila in data de tip String si adauga semnul"%"
                pro.text = Mathf.Round(progres * 100f).ToString() + "%";

                //returneaza argumentul null
                yield return null;

            }
        }
    }
        
}
