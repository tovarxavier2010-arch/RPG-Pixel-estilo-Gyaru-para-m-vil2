// Game State
let gameState = {
    playerHP: 100,
    playerMaxHP: 100,
    playerLevel: 1,
    playerATK: 15,
    playerDEF: 5,
    playerGyaruStyle: 15,

    enemyHP: 100,
    enemyMaxHP: 100,
    enemyName: 'Hater',
    enemyATK: 12,
    enemyDEF: 3,

    isPlayerTurn: true,
    battleActive: true,
    score: 0,
    gyaruLevel: 1,
    battleCount: 0
};

const enemyNames = ['Troll Fashion', 'Básica', 'Normie', 'Hater', 'Competidora', 'Fashionista Rival', 'Fake Gyaru'];

// Start Game
function startGame() {
    document.getElementById('mainMenu').style.display = 'none';
    document.getElementById('gameScreen').style.display = 'block';
    document.getElementById('gameOverScreen').style.display = 'none';
    
    resetBattle();
    updateUI();
}

function resetBattle() {
    gameState.battleCount++;
    gameState.playerHP = gameState.playerMaxHP;
    gameState.enemyHP = gameState.enemyMaxHP;
    gameState.isPlayerTurn = true;
    gameState.battleActive = true;
    
    // Random enemy
    gameState.enemyName = enemyNames[Math.floor(Math.random() * enemyNames.length)];
    gameState.enemyMaxHP = 80 + (gameState.playerLevel * 10);
    gameState.enemyHP = gameState.enemyMaxHP;
    gameState.enemyATK = 10 + (gameState.playerLevel * 1);
    
    clearLog();
    addLog('⚔️ ¡Comienza el combate contra ' + gameState.enemyName + '!');
    updateUI();
}

// Combat Functions
function playerAttack() {
    if (!gameState.isPlayerTurn || !gameState.battleActive) return;

    const damage = calculateDamage(gameState.playerATK, 5, gameState.playerGyaruStyle);
    gameState.enemyHP -= damage;
    gameState.enemyHP = Math.max(0, gameState.enemyHP);

    addLog(`<span class="log-entry damage">👘 Ataque: ${damage} de daño!</span>`);

    if (gameState.enemyHP <= 0) {
        endBattle(true);
        return;
    }

    gameState.isPlayerTurn = false;
    updateUI();
    setTimeout(enemyTurn, 1500);
}

function playerStyleBomb() {
    if (!gameState.isPlayerTurn || !gameState.battleActive) return;

    const damage = gameState.playerGyaruStyle + 10;
    gameState.enemyHP -= damage;
    gameState.enemyHP = Math.max(0, gameState.enemyHP);

    addLog(`<span class="log-entry skill">✨ STYLE BOMB! ${damage} de daño crítico!</span>`);

    if (gameState.enemyHP <= 0) {
        endBattle(true);
        return;
    }

    gameState.isPlayerTurn = false;
    updateUI();
    setTimeout(enemyTurn, 1500);
}

function playerHeal() {
    if (!gameState.isPlayerTurn || !gameState.battleActive) return;

    const healAmount = 30;
    gameState.playerHP += healAmount;
    gameState.playerHP = Math.min(gameState.playerHP, gameState.playerMaxHP);

    addLog(`<span class="log-entry heal">💚 Heal! +${healAmount} HP</span>`);

    gameState.isPlayerTurn = false;
    updateUI();
    setTimeout(enemyTurn, 1500);
}

function enemyTurn() {
    if (!gameState.battleActive) return;

    // 70% attack, 30% defend
    if (Math.random() > 0.3) {
        const damage = calculateDamage(gameState.enemyATK, 3);
        gameState.playerHP -= damage;
        gameState.playerHP = Math.max(0, gameState.playerHP);

        addLog(`🧛‍♀️ ${gameState.enemyName} ataca: ${damage} de daño!`);

        if (gameState.playerHP <= 0) {
            endBattle(false);
            return;
        }
    } else {
        addLog(`🧛‍♀️ ${gameState.enemyName} se defiende...`);
    }

    gameState.isPlayerTurn = true;
    updateUI();
}

function calculateDamage(atk, variance, bonus = 0) {
    const randomDamage = Math.floor(Math.random() * variance);
    const bonusDamage = Math.floor(bonus / 10);
    return atk + randomDamage + bonusDamage;
}

function endBattle(playerWon) {
    gameState.battleActive = false;

    if (playerWon) {
        const reward = 25 + (gameState.playerLevel * 5);
        gameState.score += reward;

        addLog(`<span class="log-entry skill">🎉 ¡VICTORIA! +${reward} puntos</span>`);

        // Level up after 3 battles
        if (gameState.battleCount % 3 === 0) {
            gameState.playerLevel++;
            gameState.playerMaxHP += 10;
            gameState.playerHP = gameState.playerMaxHP;
            gameState.playerATK += 2;
            gameState.playerGyaruStyle += 5;
            addLog(`<span class="log-entry skill">⬆️ ¡Level UP! Ahora eres nivel ${gameState.playerLevel}</span>`);
        }

        // Increase Gyaru Level
        if (gameState.score % 100 === 0 && gameState.score > 0) {
            gameState.gyaruLevel++;
            addLog(`<span class="log-entry skill">👘 ¡Nivel Gyaru ${gameState.gyaruLevel}!</span>`);
        }
    } else {
        addLog(`<span class="log-entry damage">💀 DERROTA... Game Over</span>`);
    }

    setTimeout(() => showGameOver(playerWon), 2000);
}

function showGameOver(playerWon) {
    document.getElementById('gameScreen').style.display = 'none';
    document.getElementById('gameOverScreen').style.display = 'block';

    const gameOverContent = document.querySelector('.game-over-content');
    gameOverContent.classList.remove('victory', 'defeat');

    if (playerWon) {
        gameOverContent.classList.add('victory');
        document.getElementById('gameOverTitle').textContent = '¡VICTORIA! ✨';
        document.getElementById('gameOverMessage').textContent = '¡Lo hiciste con estilo! 💅';
    } else {
        gameOverContent.classList.add('defeat');
        document.getElementById('gameOverTitle').textContent = '¡DERROTA! 💀';
        document.getElementById('gameOverMessage').textContent = 'Intenta de nuevo...';
    }

    document.getElementById('finalScore').textContent = gameState.score;
    document.getElementById('finalGyaruLevel').textContent = gameState.gyaruLevel;
}

function goToMenu() {
    document.getElementById('mainMenu').style.display = 'flex';
    document.getElementById('gameScreen').style.display = 'none';
    document.getElementById('gameOverScreen').style.display = 'none';
    
    // Reset game state
    gameState = {
        playerHP: 100,
        playerMaxHP: 100,
        playerLevel: 1,
        playerATK: 15,
        playerDEF: 5,
        playerGyaruStyle: 15,
        enemyHP: 100,
        enemyMaxHP: 100,
        enemyName: 'Hater',
        enemyATK: 12,
        enemyDEF: 3,
        isPlayerTurn: true,
        battleActive: true,
        score: 0,
        gyaruLevel: 1,
        battleCount: 0
    };
}

// UI Updates
function updateUI() {
    // Update names
    document.getElementById('playerName').textContent = 'Gyaru';
    document.getElementById('enemyName').textContent = gameState.enemyName;

    // Update health bars
    const playerHealthPercent = (gameState.playerHP / gameState.playerMaxHP) * 100;
    const enemyHealthPercent = (gameState.enemyHP / gameState.enemyMaxHP) * 100;

    document.getElementById('playerHealth').style.width = playerHealthPercent + '%';
    document.getElementById('enemyHealth').style.width = enemyHealthPercent + '%';

    // Update health text
    document.getElementById('playerHPText').textContent = gameState.playerHP + '/' + gameState.playerMaxHP;
    document.getElementById('enemyHPText').textContent = gameState.enemyHP + '/' + gameState.enemyMaxHP;

    // Update status
    document.getElementById('playerLevel').textContent = gameState.playerLevel;
    document.getElementById('gyaruStyle').textContent = gameState.playerGyaruStyle;
    document.getElementById('score').textContent = gameState.score;
}

// Log System
function addLog(message) {
    const logContent = document.getElementById('logContent');
    const entry = document.createElement('p');
    entry.innerHTML = message;
    logContent.appendChild(entry);
    logContent.scrollTop = logContent.scrollHeight;
}

function clearLog() {
    document.getElementById('logContent').innerHTML = '';
}

function showCredits() {
    alert('👘 GYARU RPG - Pixel Edition 👘\n\n' +
          '🎮 Un juego de RPG estilo Gyaru para navegadores\n\n' +
          'Desarrollo: GyaruGames Dev\n' +
          'Año: 2026\n\n' +
          '✨ Características:\n' +
          '- Combate por turnos\n' +
          '- Sistema de Gyaru Style\n' +
          '- Habilidades especiales\n' +
          '- Sistema de niveles\n' +
          '- Enemigos aleatorios\n\n' +
          '💅 ¡Hecho con estilo!');
}
