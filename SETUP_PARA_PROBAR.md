# 🎮 Setup para Probar Gyaru RPG

## ¿Cómo probar el juego?

### Paso 1: Clonar el repositorio
```bash
git clone https://github.com/tovarxavier2010-arch/RPG-Pixel-estilo-Gyaru-para-m-vil2.git
cd RPG-Pixel-estilo-Gyaru-para-m-vil2
```

### Paso 2: Abrir en Unity
1. Abre **Unity Hub**
2. Click en **"Open Project"**
3. Selecciona la carpeta descargada
4. Espera a que se compile (puede tomar 2-5 minutos en la primera carga)

### Paso 3: Abrir la escena de combate
1. En el proyecto abierto, ve a: `Assets/Scenes/`
2. Abre `CombatScene` (doble click)
3. ¡Dale Play! (Presiona SPACE o el botón de Play)

## 🎮 Controles

### En el Editor de Unity:
- **SPACE**: Jugar/Pausar
- **Teclas de Flecha**: Mover (si está en modo exploración)
- **Mouse**: Click en los botones de combate

### En Móvil (cuando compiles a Android/iOS):
- **Toques en pantalla**: Interactuar con botones
- **Desliza**: Para mover (futuro)

## 🎯 Qué hacer en el juego

1. **Aparecerá una pantalla de combate** con:
   - Tu personaje vs Enemigo
   - Barras de salud
   - 3 botones: **Ataque**, **Style Bomb**, **Heal**

2. **Presiona los botones**:
   - **Ataque**: Golpe normal
   - **Style Bomb** ✨: Ataque especial que usa el stat "Gyaru Style"
   - **Heal**: Cúrate 30 HP

3. **El enemigo atacará automáticamente** después de tu turno

4. **Gana o pierde** según quien llegue a 0 HP primero

## 🐛 Si hay errores:

### "No encuentra los Scripts"
- Asegúrate de que la carpeta `Assets/Scripts/` existe
- Si no, crea la carpeta manualmente

### "No ve la escena"
- Ve a `File > New Scene > Save As`
- Guarda como `Assets/Scenes/CombatScene`

### "Errores de compilación"
- Asegúrate de usar **Unity 2022.3 LTS** o superior
- Click derecho en `Assets` > Reimport All

## 📱 Para compilar a móvil:

1. **Android**:
   - `File > Build Settings`
   - Select `Android`
   - Click `Build`

2. **iOS**:
   - `File > Build Settings`
   - Select `iOS`
   - Click `Build`

## ✨ Próximas mejoras:

- [ ] Animaciones de personajes
- [ ] Efectos visuales mejorados
- [ ] Múltiples enemigos
- [ ] Sistema de mapas
- [ ] Tienda y upgrades

---

¿Problemas? Revisa el console de Unity (Window > General > Console) para mensajes de error.

**¡Diviértete! 🎮💅**