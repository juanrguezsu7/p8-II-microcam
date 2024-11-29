# Práctica 8 de Interfaces Inteligentes: Micrófono y Cámara en Unity
## Autor
* Nombre: Juan Rodríguez Suárez
* Correo: alu0101477596@ull.edu.es
## Descripción simulación desde el editor
### 1.-
![GIF](./assets/first.gif)
Se ha implementado una escena con 4 arañas y 1 extra que es una depredadora. La depredadora busca a la araña más cercana y va a por ella. Cuando llega, se destruye la víctima y se emite un sonido usando AudioSource. Véase el script `PredatorChasing.cs`.
### 2.-
En este caso, se ha creado una escena con dos altavoces, cada uno configurado para emitir o bien el canal izquierdo o el derecho. Se ha implementado un script que empieza a grabar el micrófono durante 3 segundos y si se pulsa R se reproduce en los altavoces. Si se pulsa S se para la grabación. Véase el script `MicRecorder.cs`.
### 3.-
Para la captura de la cámara, primero se comprueban los dipositivos disponibles y se selecciona el primero y se crea un objeto WebCamTexture con el nombre de ese dispositivo y una resolución de 640x480 a 30fps. Cuando el usuario pulsa la tecla S, la cámara se activa y se asigna la textura al material del plano que actúa como reproductor en la escena. Si se pulsa la P se para la cámara y cuando se pulsa X, se guarda el fotograma actual recuperando la información de los píxeles con GetPixels y se guarda la textura con esa información. Véase el script `CamTexture.cs`.