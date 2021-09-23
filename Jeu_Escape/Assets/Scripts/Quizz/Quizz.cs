using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Quizz : MonoBehaviour
{
    private Text TextQuestion;
    private Text TextScore;
    private Text TextFini;
    private Text TextBoutonReponse1;
    private Text TextBoutonReponse2;
    private Text TextBoutonReponse3;
    private Text TextBoutonReponse4;
    private int Nr; //Nb aléatoire 
    public string Reponse;
    public int Score = 0;
    public int TotalQuestion;
    public int NbQuestionPosees = 0;
    public GameObject panelFiniMiniJeux;
    public GameObject panelFiniEscape;
    public float difficulteMiniJeu;
    public float lieuDeLancement;
    public float questionSpeciale; // 1 question spéciale, 0 question de culture
    string[] QuizzTab = new string[17]; // déclaration du tableau des questions

    void Start()
    {
        TextQuestion = GameObject.Find("TextQuestion").GetComponent<Text>();
        TextBoutonReponse1 = GameObject.Find("Reponse1").GetComponent<Text>();
        TextBoutonReponse2 = GameObject.Find("Reponse2").GetComponent<Text>();
        TextBoutonReponse3 = GameObject.Find("Reponse3").GetComponent<Text>();
        TextBoutonReponse4 = GameObject.Find("Reponse4").GetComponent<Text>();
        difficulteMiniJeu = PlayerPrefs.GetFloat("DifficulteMiniJeu", 1);
        lieuDeLancement = PlayerPrefs.GetFloat("LieuDeLancement", 1);
        questionSpeciale = PlayerPrefs.GetFloat("questionSpeciale", 2);

        if (lieuDeLancement == 1)
        {
            TextScore = GameObject.Find("TextScore").GetComponent<Text>();
            TotalQuestion = 3;
            if (difficulteMiniJeu == 1)
            {
                bbdFacile();
            }
            if (difficulteMiniJeu == 2)
            {
                bbdMoyen();
            }
            if (difficulteMiniJeu == 3)
            {
                bbdDifficile();
            }
            if (difficulteMiniJeu == 4)
            {
                bbdExpert();
            }
        }
        else if (lieuDeLancement == 2)
        {
            TotalQuestion = 1;
            if (questionSpeciale == 1)
            {
                for (int i = 0; i < 17; i++)
                {
                    QuizzTab[i] = "De quelle couleur est l'arrosoir ?*Bleu*Rouge*Vert*Jaune*Vert";
                }
                PoseUneQuestion();
            }

            if (questionSpeciale == 6)
            {

                for (int i = 0; i < 17; i++)
                {
                    QuizzTab[i] = "Combien il y a-t-il de trophées dans la salle des trophées ?*27*28*29*30*29";
                }
                PoseUneQuestion();

            }
            if (questionSpeciale == 4)
            {
                TextScore = GameObject.Find("TextScore").GetComponent<Text>();
                TotalQuestion = 3;
                bbdMoyen();                        // difficulté pénalité
            }

            if (questionSpeciale == 0)
            {
                if (difficulteMiniJeu == 1)
                {
                    bbdFacile();
                }
                if (difficulteMiniJeu == 2)
                {
                    bbdMoyen();
                }
                if (difficulteMiniJeu == 3)
                {
                    bbdDifficile();
                }
                if (difficulteMiniJeu == 4)
                {
                    bbdExpert();
                }
            }
        }
    }

    void Update()
    {
        if (lieuDeLancement == 1)
        {
            TextScore.text = "Score : " + Score;
        }
        if (questionSpeciale == 4)
        {
            TextScore.text = "Score : " + Score;
        }
    }

    public void PoseUneQuestion()
    {
        if (NbQuestionPosees < TotalQuestion)
        {
            NbQuestionPosees += 1;
            Nr = Random.Range(0, QuizzTab.Length);
            string[] Col = QuizzTab[Nr].Split('*');
            TextQuestion.text = Col[0];
            TextBoutonReponse1.text = Col[1];
            TextBoutonReponse2.text = Col[2];
            TextBoutonReponse3.text = Col[3];
            TextBoutonReponse4.text = Col[4];
            Reponse = Col[5];
        }
        else
        {
            if (lieuDeLancement == 1)
            {
                panelFiniMiniJeux.SetActive(true);
                TextFini = GameObject.Find("TextFini").GetComponent<Text>();
                TextFini.text = "Quizz terminé, votre score : " + Score + "/" + TotalQuestion;
            }
            if (lieuDeLancement == 2)
            {
                if (Score == TotalQuestion)
                {
                    panelFiniEscape.SetActive(true);
                    //TextFini = GameObject.Find("TextFini").GetComponent<Text>();
                    //TextFini.text = "Félicitation ! Voici votre indice :";
                }
                else
                {
                    Score = 0;
                    NbQuestionPosees = 0;
                    PoseUneQuestion();
                }
            }
        }
    }

    public void OnMouseDown(GameObject ValCliquee)
    {
        if (GameObject.Find("QuizzCanvas").GetComponent<Quizz>().Reponse == GameObject.Find(ValCliquee.GetComponentInChildren(typeof(Text)).name).GetComponent<Text>().text)
        {

            GameObject.Find("QuizzCanvas").GetComponent<Quizz>().Score += 1;
        }
        else
        { }
        GameObject.Find("QuizzCanvas").GetComponent<Quizz>().PoseUneQuestion();

    }

    private void bbdFacile()
    {
        QuizzTab[0] = "Quel est le premier film de Disney ?*Fantasia*Blanche-Neige et les sept nains*Pinocchio*Saludos amigos*Blanche-Neige et les sept nains";
        QuizzTab[1] = "Dans quel pays peut-on trouver la Catalogne, l’Andalousie et la Castille ?*L'Italie* La France* L'Espagne* La Castille* L'Espagne";
        QuizzTab[2] = "Qui a dit : « Le sort en est jeté » (Alea jacta est) ?*César*Auguste*Vercingétorix*Attila*César";
        QuizzTab[3] = "Qui a écrit le mythe de la caverne ?*Aristote*Socrate*Kant*Platon*Platon";
        QuizzTab[4] = "Combien de temps dure un match de football ?*80 min*90 min*60 min*10 min*90 min";
        QuizzTab[5] = "Combien d'États y-a-t-il aux États-Unis ?*48 États*51 États*52 États*50 États*50 États";
        QuizzTab[6] = "En quelle année a été signée la déclaration des droits de l'homme et du citoyen ?*1789*1788*1790*1795*1789";
        QuizzTab[7] = "Où la première bombe atomique a-t-elle été utilisée ?*à Hirashima*à Nagasuki*à Hiroshima*à Nagasaki*à Hiroshima";
        QuizzTab[8] = "Quand la Seconde Guerre mondiale a-t-elle pris fin ?*En 1951*En 1918*En 1944*En 1945*En 1945";
        QuizzTab[9] = "Quel est le pays le plus peuplé du monde ?*L’Inde*La Chine*Les États-Unis*L’Indonésie*La Chine";
        QuizzTab[10] = "De quel groupe est la chanson 'Let it be' ?*Oasis*The Rolling Stones*The Beatles*The Who*The Beatles";
        QuizzTab[11] = "Quelle est l'oeuvre littéraire la plus célèbre de Antoine de Saint-Exupéry ?*Le petit prince*L’Aviateur*Terre des hommes*Citadelle*Le petit prince";
        QuizzTab[12] = "Qui est considéré comme le Roi du Rock ?*Chuck Berry*Michael Jackson*Bob Dylan*Elvis Presley*Elvis Presley";
        QuizzTab[13] = "Quelle est la nage la plus lente ?*Le crawl*Papillon*La brasse*Le chien*La brasse";
        QuizzTab[14] = "Quels sont les animaux les plus présents sur Terre ?*Les vers de terre*Les fourmis*Les mouches*Les moustiques*Les vers de terre";
        QuizzTab[15] = "Combien de ligue des champions a gagné Paris ?*0*1*2*3*0";
        QuizzTab[16] = "Dans quelle localité trouve-t-on les Mamoudzous ?*À Mayotte*En Guyane*En Guadeloupe*À la Réunion*À Mayotte";

        PoseUneQuestion();
    }

    private void bbdMoyen()
    {
        QuizzTab[0] = "À quel pays appartient Hawaï ?*France*États-Unis*Angleterre*Aucun*États-Unis";
        QuizzTab[1] = "Quelle langue n'est pas officielle en Belgique ?*français*wallon*allemand*néerlandais*wallon";
        QuizzTab[2] = "Qui a peint 'le cri' ?*Édouard Manet*Stéphane Mallarmé*Edvard Munch*Paul Gauguin*Edvard Munch";
        QuizzTab[3] = "Combien de point vaut un lancer franc au basket-ball ?*1*2*3*4*1";
        QuizzTab[4] = "Une seule de ces célébrités a été videur de boîte de nuit dans sa jeunesse, lequel ?*Steven Seagal*Guillaume Gallienne*Didier Deschamps*Le Pape François*Le Pape François";
        QuizzTab[5] = "Quel est le plus grand océan du monde ?*L'océan Atlantique*L'océan Indien*L'océan Arctique*L'océan Pacifique*L'océan Pacifique";
        QuizzTab[6] = "Quand le premier homme a-t-il atterri sur la lune ?*En 1969*En 1968*En 1972*En 1966*En 1969";
        QuizzTab[7] = "En quelle année a eu lieu la découverte de l'Amérique ?*En 1492*En 1592*En 1392*En 1292*En 1492";
        QuizzTab[8] = "Qui a écrit l'Odyssée ?*Homère*Damascios*Agathon*Télésille*Homère";
        QuizzTab[9] = "Laquelle de ces phrases contient toutes les lettres de l'alphabet ?*Servez ce whisky aux petits juges blonds qui fument*Goldorak a pété mon xylophone en peau de zèbre*Zorro et Xéna la guerrière font du kung-fu au Quatar*Wolfgang a crié «Qu’on amène le festin»*Servez ce whisky aux petits juges blonds qui fument";
        QuizzTab[10] = "Quel sport pratique-t-on si on a un autocollant en forme de poing sur sa voiture ?*Le taekwondo*La boxe anglaise*Le karaté*Wing chun*Le karaté";
        QuizzTab[11] = "Quelle est la langue d'origine du français ?*Le latin*Le franc*Le sanskrit*Le sumérien*Le latin";
        QuizzTab[12] = "D'où vient le rock ?*Du jazz*De la country*Du blues*De la variété*Du blues";
        QuizzTab[13] = "D'où viennent les jeux olympiques ? *Des jeux grecs dans la ville d'Olympe*Des compétitions d’athlétisme grecques*Des compétitions chevaleresques*Des combats entre villes grecques *Des jeux grecs dans la ville d'Olympe";
        QuizzTab[14] = "Combien de ligue des champions a gagné Marseille ?*0*1*2*3*1";
        QuizzTab[15] = "Combien de ligue des champions a gagné le Real Madrid ?*5*8*11*13*13";
        QuizzTab[16] = "Les habitants de Biarritz sont …*les Bitérois*les Briotins*les Biarrots*les Biarritzéens*les Biarrots";

        PoseUneQuestion();
    }

    private void bbdDifficile()
    {
        QuizzTab[0] = "Quel est le plus long fleuve en France ?*La loire*Le Rhône*La Garonne*Le Rhin*La Loire";
        QuizzTab[1] = "Qui a inventé l'avion ?*Thomas Savery et Denis Papin*Les frères Wright*Joseph Prietley*Benjamin Franklin*Les frères Wright";
        QuizzTab[2] = "A quelle date la Ve république a-t-elle été proclamée ?*4 octobre 1958*16 novembre 1955*12 septembre 1957*5 décembre 1960*4 octobre 1958";
        QuizzTab[3] = "Où a été inventé le volley ?*France*États-Unis*Angleterre*Italie*États-Unis";
        QuizzTab[4] = "Laquelle de ces propositions, n’est pas une appellation du « Pierre Feuille Ciseaux » dans le monde ?*Klet-Klat-Klout en Finlande*Schnick-Schnack-Schnuck en Allemagne*Kawi-Bawi-Bo en Corée*Chiam-Cham-Choum au Liban*Klet-Klat-Klout en Finlande";
        QuizzTab[5] = "Une seule de ces affirmations sur ces acteurs champions d'arts martiaux est complètement vraie, laquelle ?*Bruce Lee a écrit 20 livres*Steven Seagal a construit 20 maisons*Jackie Chan a enregistré 20 albums*Chuck Norris a peint 20 autoportraits avec ses poings*Jackie Chan a enregistré 20 albums";
        QuizzTab[6] = "Lequel de ces livres n'a pas réellement été publié ?*« L’extraordinaire voyage du Fakir qui était resté coincé dans une armoire Ikea »*« Le cercle littéraire des Amateurs d’Épluchures de Patates »*« Ne dites pas à mère que je suis voyante, elle me croit libraire à Vancouver »*« Le gratin de courgettes ne faisait pas partie du deal »*« Le gratin de courgettes ne faisait pas partie du deal »";
        QuizzTab[7] = "Laquelle de ces informations sur Gerard Depardieu est vraie ?*Il a été la voix française de Mel Gibson*Il a été la voix française de Kevin Costner*Il a été la voix française de John Travolta*Il a été la voix française de Bard Pitt*Il a été la voix française de Kevin Costner";
        QuizzTab[8] = "Qui a écrit ‘songe d'une nuit d'été’ ?*Baudelaire*Wolfgang Amadeus Mozart*William Shakespeare*Molière*William Shakespeare";
        QuizzTab[9] = "Qui a chanté la chanson 'Avec le temps' ?*Axel Bauer*Yves Duteil*Laurent Voulzy*Léo Ferré*Léo Ferré";
        QuizzTab[10] = "Quel est le sport de Tiger Woods ?*La boxe française*Le golf*Le tennis *Le catch*Le golf";
        QuizzTab[11] = "D'où sont les Pumas en Rugby ?*Nouvelle-Zélande*Russie*Ecosse*Argentine*Argentine";
        QuizzTab[12] = "Selon la légende, pourquoi la ligne ferroviaire Moscou - St Petersbourg fait-elle un détour de 17km ?*Parce que les ouvriers avaient trop bu*Parce que le froid a tordu les rails*Parce que le Tsar avait laissé un doigt dépasser de sa règle*Parce qu’avant il y avait un village qui a disparu depuis*Parce que le Tsar avait laissé un doigt dépasser de sa règle";
        QuizzTab[13] = "Qui a fait Big Fish ?*Tim Burton*Ken Loach*Sidney Lumet*Steven Spielberg* Tim Burton";
        QuizzTab[14] = "Comment s'appelle le stade de football du Real Madrid ?*Santiago Barnabeu*Camp Nou*Estadio Metropolitano*Mestalla*Santiago Barnabeu";
        QuizzTab[15] = "Quand la série 'Derrick' s'est arrêtée, quel âge avait son scénariste ?*64 ans*74 ans*84 ans*94 ans*84 ans";
        QuizzTab[16] = "Rimbaud était… *Carolopolitain*Mezerocharlotain*Carolomacérien*Charlerien*Carolopolitain";

        PoseUneQuestion();
    }

    private void bbdExpert()
    {
        QuizzTab[0] = "Quel est le nom de la capitale du Laos ?*Vientiane*Savannakhet*Naypyidaw*Phnom Penh*Vientiane";
        QuizzTab[1] = "Où sont les ruines d'Angkor ?*À Intramuros, Philippines*À Sam Neua, Laos*À Siem Reap, Cambodge*À Nishiki, Japon*À Siem Reap, Cambodge";
        QuizzTab[2] = "Combien d'années durent un lustre ?*5 ans*2 ans*10 ans*20 ans*5 ans";
        QuizzTab[3] = "Où a été inventé le ping-pong ?*France*Angleterre*États-Unis*Italie*Angleterre";
        QuizzTab[4] = "Combien pèse une pierre de curling, poignée comprise ?*3,4 kg*9,4 kg*12,6 kg*19,4 kg*19,4 kg";
        QuizzTab[5] = "En quelle année l'invasion arabe de l'Espagne a-t-elle commencé ?*En l'an 657*En l'an 593*En l'an 852*En l'an 711*En l'an 711";
        QuizzTab[6] = "Où est né l'écrivain Julio Cortázar ?*Pérou*Chilly*Brésil*Argentine*Argentine";
        QuizzTab[7] = "Qui a composé la musique du fabuleux destin d'Amélie Poulain ?*Henri Dutilleux* Yann Tiersen*Nicolas Bardey*Bruno Mantovani*Yann Tiersen";
        QuizzTab[8] = "Dans quel sport Toni Elias s'est particulièrement fait remarquer ?*En catch*En bmx*En moto*En padel*En moto";
        QuizzTab[9] = "Quel est le cri de l'aigle Milan ?*Il sept*Il huit*Il neuf*Il dix*Il huit";
        QuizzTab[10] = "Quel est le sport dans lequel a excellé Carl Lewis ?*L'athlétisme*La boxe française*Le judo*Le football américain*L'athlétisme";
        QuizzTab[11] = "Parmi ces affirmations sur les noms de villes, laquelle est correcte ?*Avignon est le croisement de la ville d’Avi et la ville de Gnon*Budapest est le croisement de la ville de Buda et la ville de Pest*Biarritz est le croisement de la ville de Biar avec l’hôtel « Le Ritz »*Amsterdam est le croisement d’un hamster et d’une dame*Budapest est le croisement de la ville de Buda et la ville de Pest";
        QuizzTab[12] = "Quel objet appartenant à Neil Armstrong s'est vendu 27 350$ aux enchères ?*Un chèque de 10,5$*Une maquette de fusée de son enfance*Une lettre qu’il avait laissé à sa femme avant de partir*Une carte de vœux de Noël*Un chèque de 10,5$";
        QuizzTab[13] = "Qui a chanté à la princesse Diana la chanson 'Candle in the wind' ?*John Lennon*Elton John*Bob Dylan*Elvis Presley*Elton John";
        QuizzTab[14] = "Une seule de ces affirmations est vraie, laquelle ?*John F. Kennedy a traversé la douane avec une mallette pleine de coke pour Elvis Presley*Barack Obama a traversé la douane avec une mallette pleine de LSD pour Jay-Z*Donald Trump a traversé la douane pour raccompagner un mexicain chez lui*Richard Nixon a traversé la douane avec une mallette pleine de weed pour Louis Armstrong*Richard Nixon a traversé la douane avec une mallette pleine de weed pour Louis Armstrong";
        QuizzTab[15] = "D'où vient l'expression 'Garde tes amis près de toi et tes ennemis encore plus près' ?*De Chin Tsé, général Chinois du XIème siècle avant JC*De Nicolas Machiavel, penseur humaniste italien de la renaissance*De Michael Corleone, dans « le Parrain II »*De Shakespeare dans « La nuit des rois »*De Michael Corleone, dans « le Parrain II »";
        QuizzTab[16] = "Comment nomme-t-on les habitants des Hauts-de-Seine ?*Les Altoséquanais*Les Sequanaltais*Les Canalosequains*Les hauts-Scéens*Les Altoséquanais";

        PoseUneQuestion();
    }

    public void PannelFermer(GameObject pannel)
    { pannel.SetActive(false); }
}