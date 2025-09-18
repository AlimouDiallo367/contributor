# Checklist - Travail Pratique 1

- [x] Création de la structure MVVM du projet 
- [x] Création de l'interface de base 
- [x] Chargement et affichage de la ressource election.ico
- [x] Permettre l'importation d'un fichier CSV en offrant un bouton qui ouvre "OpenFileDialog"
- [x]  L'importation alimente une ListView (ou bien autre composante qui vous permettra de satisfaire à l'ensemble des exigences de ce travail). 
Les champs doivent être segmentés (chacun dans leur "case"). 
Pour l'affichage de la case "Illégale?", vous devez impérativement utiliser un IValueConverter.
- [x] Advenant un fichier CSV non valide (exception), vous devez afficher un pop up d'erreur. L'application ne doit pas planter.
- [x] On peut voir un décompte du nombre de contributions présentes dans le ListView.
- [x] Il y a une case à cocher qui permet de visualiser seulement les contributions illégales.
Cette case à cocher est disponible seulement s'il y a des contributions dans la ListView. 
Il faut impérativement utiliser l'approche avec le CanExecute dans la RelayCommand. (à améliorer voir Fred)
- [ ] Dans le menu, il un a un option "Configuration". En cliquant dessus, ceci ouvre une nouvelle FENÊTRE.  