# Gyaru RPG - Guía de Desarrollo

## 🎮 Características Implementadas

### Core
- ✅ Sistema de personajes con stats
- ✅ Gestor principal del juego
- ✅ Sistema de niveles y experiencia

### Jugador
- ✅ Movimiento en grid (teclado y táctil)
- ✅ Sistema de controles para móvil

### Combate
- ✅ Sistema de combate por turnos
- ✅ IA básica del enemigo
- ✅ Habilidades especiales (Style Bomb, Heal)
- ✅ Generación aleatoria de enemigos
- ✅ UI de combate con logs

### UI
- ✅ Interfaz de combate
- ✅ Sistema de salud visual
- ✅ Registro de acciones

## 📋 Próximos Pasos

### Corto Plazo (v0.2)
- [ ] Sistema de mapas con tiles
- [ ] Detección de colisiones
- [ ] Animaciones de personajes
- [ ] Efectos de sonido
- [ ] Pantalla de menú principal

### Mediano Plazo (v0.3)
- [ ] Sistema de equipo (4-6 personajes)
- [ ] Colección de personajes Gyaru
- [ ] Sistema de items y equipamiento
- [ ] Upgrades de personajes
- [ ] Misiones y objetivos

### Largo Plazo (v1.0)
- [ ] Modo historia
- [ ] Boss fights
- [ ] Multijugador local
- [ ] Sistema de guardar progreso
- [ ] Tienda de cosméticos

## 🎨 Especificaciones de Pixel Art

- **Tamaño Base**: 32x32 píxeles
- **Paleta**: Colores vibrantes y neón estilo Gyaru
- **Estilo**: 8-bit moderno con detalles

### Personajes Gyaru
- Uniforme escolar modificado
- Accesorios de moda (bolsas, zapatos)
- Diferentes peinados y colores de cabello
- Expresiones faciales animadas

## 🛠️ Setup Técnico

### Requisitos
- Unity 2022.3 LTS o superior
- TextMesh Pro (incluido)
- Input System moderno

### Carpetas de Assets
```
Assets/
├── Scripts/        # Código C#
├── Sprites/        # Pixel art
├── Prefabs/        # Prefabs reutilizables
├── Scenes/         # Escenas
├── Audio/          # Música y SFX
├── Resources/      # Datos de configuración
└── Animations/     # Clips de animación
```

## 📱 Optimizaciones para Móvil

- Object pooling para enemigos
- Culling de sprites fuera de pantalla
- Texturas comprimidas
- Batching automático
- UI escalable para diferentes resoluciones

## 🎵 Audio

### Música
- Tema principal (loop)
- Tema de combate (energético)
- Tema de victoria
- Tema de derrota

### Efectos de Sonido
- Ataque
- Skill especial
- Curación
- Victoria/Derrota
- UI clicks

---

**Estado**: Desarrollo Activo 🚀
**Última Actualización**: 2026-07-16