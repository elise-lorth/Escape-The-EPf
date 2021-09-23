# Escape the EPF

Git project 4A : Escape the EPF

Product Owner : Thomas 

Lead dev : Olivier

Dev : Ying, Lucas, Elise, Fanny 

Les merges sont faites uniquement par le lead dev.

**Template :**
Créez une nouvelle scène en prenant le Template comme template.
Pensez à mettre la nouvelle scène dans le buildSetting (dans file de unity) pour que les déplacements entre salle soient actifs. Les déplacements sont via des variables comme « sceneToLoad » (définies dans des GameObject comme Script).

**Description de Template :**
- Un canvas : là où on met tous les éléments, le canvas de Template s’appelle MenuConnecte (my bad) : il faut le renommer (c’est plus joli).
- Script : là où on met en component les scripts. Par défaut il y a celui de Template qui définit le bouton retour et tous les paramètres. Gardez celui de Template et rajoutez en des nouveaux.
- DonneesJoueur : a vocation à être comme l’inventaire des données de l’utilisateur (reconnu par IP je pense), actuellement il y a les infos des volumes. Les infos sont gardée entre chaque connexions et scènes.
- GameManager : lance le SaveAndLoadData, ce qui permet de charger et enregistrer des données ; et le DontDestroyOnLoadScene, si vous voulez que des infos soient gardées entre deux scène agrandissez sa size et glissez l’élément. Les deux scripts permettent de sauvegarder et charger le volume entre chaque scène et chaque connexion.
- AudioManager : C’est là qu'il y a la playlist et qu’on pourra surement mettre les sons des objets.

**Pour les sons et musiques :**
Dans le dossier audio glissez les fichiers dans les bons dossiers (musiques ou son objets), puis pour les musiques glissez les dans la playlist de AudioManager, attention les musiques seront toujours jouées dans l’ordre. Pour les sons des objets, créez une Audio sources (component) sur l’objet qui fera le bruit, retirez le play on awake, et ajoutez le son et l’audiosource dans le script, choisissez bien l’audio mixer son et non pas musique, et après faut coder 😊. (Exemple sur le bouton quitter de connecté même si je l’ai mis en commentaire)

**Pour les polices :** (svp suivez les :’( elles sont dans le fichier Import )
- Le titre du jeu est en crime ;
- Les titres des pannels et des bouttons sont en Endgame ;
- Les boutons « fermer » (les petites croix en haut) c’est un X en Game of Brush en taille 30 ;
- Tout le reste du contenu c’est en Dream orphans.

Je précise au cas où mais bon merci captain obvious : les scènes sont dans le dossier Scenes, les scripts dans le dossier Scripts, les images et polices dans le dossier Import et les trucs musicaux dans le dossier Audio.

**Commandes git :**
- Pour cloner le projet (master) : git clone https://gitlab.min.epf.fr/oabdelno/escape-the-epf.git <_Nom du dossier_> (Uniquement pour moi)
- Tout d'abord créer votre branche à partir de master dans le gitlab, puis vous faites les étapes suivantes.
- Pour cloner une branche spécifique du projet : git clone --branch <_Nom de la branche_> https://gitlab.min.epf.fr/oabdelno/escape-the-epf.git <_Nom du dossier_>
/!\ Vous n'avez pas besoin de faire de git init car le git clone s'en charger. 
- Modifier les fichiers comme bon vous semble en faisant attention à ne modifier que les votres. Vous pouvez rajoutez des fichiers aussi ; 
- Rentrer dans le dossier où vous avez rajouter vos fichiers (cd <_Nom du dossier_>)
- git add . (le point veut dire que vous ajouter tous les fichiers du dossier)
- git add <Nom_de_fichier/dossier> pour ajouter un dossier/fichier en particulier.
/!\ Si vous faites un git push cela supprimera le fichier/le dossier du git.
- git commit -am "Commentaire"
- git push/pull si vous avez cloné la branche sur laquelle vous travaillez. 
- git push/pull -u origin HEAD:<_Nom de la branche_> si vous voulez effectuer des modifications sur une autre branche que celle que vous avez cloné.
- Si jamais vous avez commit un fichier que vous ne voulez pas commit pas de pannique. /!\ NE SURTOUT PAS LE SUPPRIMER A PARTIR DU GESTIONNAIRE DE FICHIER ! Faites plutôt:
----> git rm (-r s'il s'agit d'un dossier) (--cache si vous voulez uniquement supprimer le dossier du stagging de git et non le supprimer totalement) <Nom_du_fichier/dossier>
- Puis un petit git commit -am "deletion"

- On utilise la version 2021.1.5f1 de Unity et on ne mettra pas les mises à jours suivantes (seulement si on se coordonne). https://unity3d.com/fr/get-unity/update


**Les playerPrefs :**
Ce sont des données qui s’enregistrent dans le registre windows (win+r pour ouvrit une fenêtre, vous entrez regedit et vous cherchez le dossier du jeu, il y aura tous les playersPrefs). Ce peut être des Float, Int ou String. Il faut les faire apparaitre (Get) dans DonneesJoueur qui est comme un inventaire. Elles peuvent être crées de n’importe où.
La valeur peut être une addition ; les lignes de Get se comportent comme des variables (peuvent être dans des calculs, des if etc.).
- Pour les créer : PlayerPrefs.SetFloat("Nom d’enregistrement du PlayerPref", valeur du playerPref);
- Pour les récupérer : PlayerPrefs.GetFloat("Nom d’enregistrement du PlayerPref", valeur du playerPref s’il n’existe pas encore ou n’est pas trouvé (optionnel));

J’en ai créé 8 pour l’instant : 
- VolumeJoueur et VolumeSonJoueur : enregistrement des paramètres volume de la musique et des objets.
- DifficulteMiniJeu : Difficulté des mini jeux, que ce soit dans le mode solo ou dans les escapes. 1 facile, 2 moyen, 3 difficile, 4 expert.
- LieuDeLancement : pour savoir d’où on a lancé le jeu, pour pouvoir paramétrer les écrans de fin par exemple. 1 si c’est depuis le menuConnecté, 2 depuis l'escape
- NombreJoueurs, NombrePaliers : défini pendant la création de la partie, serviront pour générer les scénarios.
- NomEquipe : le nom de l’équipe, pour afficher les scores publics.
- CodePartie : random généré, qui a vocation à servir pour que les joueurs rejoignent une partie.
- questionSpeciale : si dans une partie d’escape il faut qu’une version spécifique d’un jeu se lance on peut utiliser ça. Si elle vaut 0 le jeu normal se lance, si elle vaut 1 la question 1 se lance etc. (par exemple)



