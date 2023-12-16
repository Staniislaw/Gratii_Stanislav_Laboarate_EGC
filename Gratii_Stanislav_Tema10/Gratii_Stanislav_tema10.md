Modificați aplicația oferită astfel încât să realizați texturarea pe diverse
obiecte 3D (volumetrice) sau pe suprafețe non-rectangulare. Ce observați?
se observa ca textura  întinsă pe suprafața obiectului în funcție de cum sunt specificate coordonatele texturii. Modificarea coordonatelor texturii poate duce la întinderea, compresia sau deformarea texturii pe obiect.
  
Utilizați pentru texturare imagini cu transparență și fără. Ce observați?
Când adăugăm o imagine cu transparență, numai zona transparentă a imaginii este afișată, restul rămânând nevăzut. În schimb, atunci când utilizăm o imagine fără transparență, întregul obiect este vizibil, înconjurat de imaginea respectivă.

Ce formate de imagine pot fi aplicate în procesul de texturare în
OpenGL?
bitmap,jpg,png,jpeg,

Specificați ce se întâmplă atunci când se modifică culoarea (prin
manipularea canalelor RGB) obiectului texturat.
Atunci cand modificam culoare se creaza  efecte de tonuri și umbre ca de exemplu daca afisam obiectul cu RGB albastru imaginea noastra se intuneca Prin ajustarea valorilor din canalele R, G și B, putem mări sau micșora intensitatea fiecărei culori individual.De exemplu, creșterea valorii din canalul roșu va face obiectul să arate mai intens în roșu.

Ce deosebiri există între scena ce utilizează obiecte texturate în modul
iluminare activat, respectiv dezactivat?

Atunci cand modul de iluminare este dezactivat culorile sunt constante,nu există efecte de umbră sau atenuare iar atunci cand modul de iluminare este activat apar umbre și atenuare,se poate crea reflecția luminii.