# Jumper-box

## 1. Objetivo del Proyecto
**Jumper-box** es un prototipo funcional de un nivel de videojuego de plataformas 2D desarrollado en Unity. El jugador debe recorrer un escenario construido mediante Tilemap, sortear obstáculos físicos y recolectar la cantidad objetivo de monedas para alcanzar la victoria, evitando caer al vacío (condición de derrota).

## 2. Plataforma Objetivo y Justificación
* **Plataforma seleccionada:** PC (Windows 64-bit).
* **Justificación técnica y de despliegue:** Los controles de precisión mediante teclado (desplazamiento horizontal y salto instantáneo) ofrecen mejor respuesta que controles táctiles en un prototipo de plataformas 2D. Además, el despliegue mediante ejecutable nativo (`.exe`) garantiza estabilidad de rendimiento sin depender de emuladores ni fragmentación de dispositivos móviles.

## 3. Configuración Clave del Motor
* **Versión de Unity:** `6000.2.3f1`.
* **Render Pipeline:** Universal Render Pipeline (URP) 2D con iluminación global (`Global Light 2D`) y materiales 2D coherentes.
* **Quality Settings:** Configurado en perfil *High / PC* acorde al hardware objetivo.
* **Organización de carpetas:** Estructura modular bajo `Assets/` (`Audio`, `Materials`, `Prefabs`, `Scenes`, `Scripts`, `Sprites`, `Tilemaps`).
* **Físicas 2D:** `Rigidbody2D` con rotación Z bloqueada, gravedad ajustada, `Physics Material 2D` sin fricción para evitar atascos en paredes, detección de suelo por `Raycast` y colisiones tipo *Trigger* para recolección de monedas y zona de derrota.
* **Audio:** `AudioMixer` (`MainMixer`) con grupos separados para mezcla equilibrada (`BGM` en `-12 dB` y `SFX` en `0 dB`), persistencia entre escenas mediante `DontDestroyOnLoad` y 4 efectos de sonido (salto, recolección de moneda, derrota y clic de UI).

## 4. Instrucciones de Ejecución
### Desde el Build compilado (Recomendado)
1. Descargar o clonar este repositorio.
2. Ingresar a la carpeta `/Build`.
3. Ejecutar el archivo `Jumper-box.exe`.

### Desde Unity Editor
1. Abrir Unity Hub y añadir la carpeta `/Project` utilizando la versión **6000.2.3f1**.
2. Abrir la escena `Assets/Scenes/MainMenu.unity`.
3. Presionar el botón **Play**.

## 5. Controles
* **Mover izquierda / derecha:** `A` / `D` o `Flecha Izquierda` / `Flecha Derecha`.
* **Saltar:** `Barra Espaciadora`.
* **Navegación de Menús (UI):** `Mouse` (clic izquierdo).

## 6. Dependencias y Recursos
* **Paquetes de Unity:** Universal RP (URP 2D), 2D Tilemap Editor, TextMeshPro, Input Handling (Both).
* **Recursos externos (uso académico):**
  * **Audio (BGM y SFX):** Efectos de sonido y música de fondo recopilados de videos de YouTube.
  * **Gráficos e Imágenes:** Sprites y fondos obtenidos desde Google Imágenes y PNGWING.

## 7. Riesgos y Mitigaciones
| Riesgo identificado | Mitigación implementada |
| :--- | :--- |
| Personaje se queda pegado a paredes o bordes al saltar. | Aplicación de un `Physics Material 2D` con fricción `0` en el collider del jugador y movimiento mediante `Rigidbody2D.linearVelocity` en `FixedUpdate`. |
| Desbalance entre la música de fondo y los efectos de sonido. | Implementación de un `AudioMixer` separando los canales `BGM` (`-12 dB`) y `SFX` (`0 dB`). |
| Corte abrupto de música o pérdida del sonido de derrota al cambiar de escena. | Uso del patrón Singleton con `DontDestroyOnLoad` en `AudioManager` inicializado desde `MainMenu`. |
| Saltos infinitos en el aire. | Detección de suelo estricta con `Physics2D.Raycast` filtrado por `LayerMask` (`Ground`). |

## 8. Roles de la Dupla
* **Samuel Riquelme:** Arquitectura base del proyecto (URP 2D), físicas del personaje (`PlayerController`), diseño de nivel con Tilemap, Prefabs y compilación del Build final. Interfaz de usuario (UI, fondos y escenas), integración de audio (`AudioMixer`, `AudioManager`) y documentación técnica.
* **Camilo Caripán:** Lógica del Game Loop (`GameManager`, `DeathZone`, `SceneLoader`).
