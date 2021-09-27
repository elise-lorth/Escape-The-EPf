# Escape the EPF

Jeu de cohésion alliant mini-jeu et escape game par équipe. Plusieurs mini-jeu sont proposés en entrainement solo : sudoku, quizz, nonogramme, mémory, puzzles, morpion. Le jeu d'escape game peut être lancé seul ou en duo.

Pour lancer des escapes games à deux joueurs, commencez par créer une partie pour deux et lancez chacun la partie d'un joueur. Le lien à la base de donnée a été rompu, il vous faudra donc passer d'une pièce à l'autre manuellement, attendez votre cohéquipier avant de le faire, il aura besoin de vous !


**Commandes git :**
- Pour cloner le projet (master) : git clone https://gitlab.min.epf.fr/oabdelno/escape-the-epf.git <_Nom du dossier_>
- Tout d'abord créer votre branche à partir de master dans le gitlab, puis vous faites les étapes suivantes.
- Pour cloner une branche spécifique du projet : git clone --branch <_Nom de la branche_> https://gitlab.min.epf.fr/oabdelno/escape-the-epf.git <_Nom du dossier_>
/!\ Vous n'avez pas besoin de faire de git init car le git clone s'en charge. 
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

- On utilise la version 2021.1.5f1 de Unity. https://unity3d.com/fr/get-unity/update


