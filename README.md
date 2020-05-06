# Cavalier
Projet réalisé en binôme.
Langage : C#
IDE : Visual Studio

Le but de cette application graphique WinForms (C#), est de faire parcourir à un cavalier l'ensemble d'un échiquier sans passer deux fois sur la même case.
La méthode à utiliser, basée sur une heuristique due à Euler, consiste à choisir comme case de fuite, en partant de l'étape N, la case de l'étape N+1 qui, à l'étape N+2, présente le MINIMUM de case de fuites possibles. Si l'on applique cette méthode dès le départ, cela revient à choisir n’importe quelle case comme case de départ. 
L’application finale devrait être composée d’au moins 2 fenêtres : Une fenêtre pour montrer toute l’efficacité de l’euristique d’Euler et une autre fenêtre permettant de jouer. 
