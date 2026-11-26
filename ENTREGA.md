# ENTREGA — Módulo 2: OpenSpec Sandbox (Spec-Driven Development)

Entregable único, consolidado según el apartado «Entregable» del README. El contenido de la Parte A y de la Parte C procede de `Parte A/ENTREGA.md` (se conserva sin cambios) y la captura de la Parte B se conserva en la raíz.

## 1. Evidencia de que OpenSpec está operativo

Salidas reales, ejecutadas el 2026-11-26 en Windows 11 (Git Bash) con Node v24.16.0, desde el directorio `openspec-sandbox/` donde se ejecutó `openspec init`.

**Comando:** `openspec --version`

```
1.10.0
```

**Comando:** `ls -R openspec/`

```
openspec/:
changes
config.yaml
specs

openspec/changes:
archive

openspec/changes/archive:

openspec/specs:
```

Notas:
- `changes/archive/` y `specs/` están vacíos (no se han escrito specs, según indica el ejercicio). Git no versiona directorios vacíos, por lo que en el repositorio solo aparece `openspec-sandbox/openspec/config.yaml`; la carpeta `.claude/` (skills y comandos de OpenSpec) sí está versionada.
- Captura de la instalación (Parte B): [Parte B — Instalación de OpenSpec en sandbox.png](<./Parte B — Instalación de OpenSpec en sandbox.png>)

![Parte B — Instalación de OpenSpec en sandbox](<./Parte B — Instalación de OpenSpec en sandbox.png>)

## 2. Plantilla de los 3 Pilares (Parte A)

Micro-tarea: Implementar un método estático puro en C# (.NET) que detecte si un string es un palíndromo.

Pilar 1 — Herramienta:

¿Cuál eliges? Antigravity IDE (utilizando el panel de chat lateral con el modelo Claude Sonnet 4.6).

¿Por qué esta y no otra? Porque la tarea cabe dentro de una sola función y un solo archivo, por lo que la decisión arquitectónica correcta es usar una herramienta IDE-integrated (Categoría A) en modo completion/chat. Utilizar un agente de terminal (modo Agentic) sería innecesario para esta micro-tarea. 

Pilar 2 — Contexto:
¿Qué información estás aportando? He creado manualmente un archivo AGENTS.md mínimo y de alta señal con el stack y las convenciones del proyecto. 

**Stack**
- C# / .NET
- Pruebas unitarias con xUnit

**Reglas y Convenciones**
- Métodos estáticos con naming PascalCase.
- No utilizar dependencias NuGet externas.
- Mantener el código en funciones puras y archivos aislados.

 ¿Hay algo del contexto que has decidido omitir conscientemente? Sí, no he incluido el archivo de la Solución, ni otros archivos del proyecto ni datos innecesarios para evitar la degradación del contexto

 Pilar 3 — Prompt:

¿Cómo lo estructuras? El prompt está orientado a resultados y define criterios de éxito explícitos y no he repetido las convenciones del contexto.

Prompt final que vas a lanzar:

"Implementa el método IsPalindrome(string text).

Criterios de éxito:
- Devuelve true si es palíndromo, false si no lo es.
- Ignora espacios, signos de puntuación y mayúsculas/minúsculas (ej: "Amo la paloma" -> true).
- Maneja casos extremos: si recibe null o un string vacío "", debe devolver false.

Escribe al menos 3 casos de prueba para validarlo."

Resultado:

¿Funcionó a la primera o tuviste que iterar? Cumplió estrictamente con el prompt a la primera (espacios, mayúsculas, nulos). Sin embargo, al hacer una prueba real con la cadena "Dábale arroz a la zorra el abad", falló porque las tildes ("á" vs "a") no coincidían. Tuve que iterar una vez más en el chat aceptando la sugerencia proactiva de Claude de aplicar normalización NFD.

Una mejora que harías si volvieras a hacerlo: Añadiría en el Pilar 3 (Prompt) un criterio de éxito explícito indicando: "Debe normalizar los diacríticos y tildes propios del idioma español (ej: á -> a)". De este modo reduciría la ambigüedad y evitaría la iteración.

## 3. Tres observaciones de la exploración (Parte C)

- Me llamó la atención cómo el archivo config.yaml asume la función de contexto global y reglas del proyecto reemplazando o asumiendo el papel del project.md o AGENTS.md.
- La estructura de carpetas y el ciclo de vida del flujo (propose -> apply -> archive) me recordó mucho a metodologías de procesamiento de correo como Inbox Zero: las propuestas entran en una bandeja de entrada, se procesan/aplican y, una vez completadas, se mueven a archive para mantener el espacio de trabajo limpio.
- Noté que todo lo que genera son archivos tipo markdown (.md). Lo veo bien porque no te obliga a aprender una sintaxis rara y es algo que se entiende facilmente.
