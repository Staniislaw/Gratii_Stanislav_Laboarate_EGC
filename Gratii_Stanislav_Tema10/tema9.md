1.Descrieți diferențele dintre iluminarea așa cum funcționează în lumea reală și modelul de iluminare utilizat de OpenGL?
    
  Lumina în lumea reală este extrem de complexă și implică multe fenomene optice diferite, cum ar fi reflexia, refracția, umbrirea, împrăștierea etc. Există multe surse de lumină în medii reale, inclusiv lumina directă a soarelui, lumina indirectă reflectată de diferite suprafețe și surse de lumină artificială. OpenGL folosește un model de iluminare simplificat pentru a simula efectele de iluminare în medii virtuale. Iluminarea în OpenGL depinde de un număr limitat de surse de lumină, cum ar fi lumina ambientală, lumina difuză și lumina reflectată.

2.Câte surse de lumină sunt suportate în implementarea curentă a OpenGL cu ajutorul framework-ului OpenTK?
  
    OpenGL oferă suport pentru cel puțin 8 surse de lumină simultane.
    
3.Definiți iluminarea de material și specificați unde și când este utilizată aceasta.
    
    
    Iluminarea fizică se referă la modul în care un obiect interacționează cu lumina prin absorbția sau reflectarea acesteia într-o scenă tridimensională. Iluminarea hardware este esențială pentru a face obiectele să pară mai realiste, reflectând proprietățile lor reflectorizante bazate pe poziție și orientare. Cu setările de iluminare a materialelor, puteți simula aspectul diferitelor materiale, cum ar fi metalul, sticla, lemnul sau plasticul.
    
4.Care este efectul asupra diverselor obiecte la activarea unei surse de lumină secundare (per pct. 3), comparativ cu utilizarea unei singure surse de lumină?

    Activarea unei surse de lumină secundară face umbrele mai clare, îmbunătățește detaliile și textura, mărește contrastul, oferă iluminare pe mai multe axe și oferă reflexii și luminanță suplimentare în comparație cu utilizarea unei singure surse de lumină secundare.