// src/components/LandingPage.tsx
import React, { useEffect, useState } from "react";
import MarkersEnum from "../logic/MarkersEnum";
import Game from "./Game";
import "./LandingPage.css"; // Optional: For styling

interface GameState {
  gameOn: boolean;
  player1Mark: MarkersEnum;
  player2Mark: MarkersEnum;
}

const LandingPage: React.FC = () => {
  const [gameState, setGameState] = useState<GameState>({
    gameOn: false,
    player1Mark: MarkersEnum.Empty,
    player2Mark: MarkersEnum.Empty,
  });

  const [error, setError] = useState<string>("");

  const choosePlayer = (marker: MarkersEnum.X | MarkersEnum.O) => {
    const marker2 = marker === MarkersEnum.X ? MarkersEnum.O : MarkersEnum.X;

    setGameState({
      gameOn: false,
      player1Mark: marker,
      player2Mark: marker2,
    });

    setError(""); // Clear any existing errors
  };

  const checkValidGameState = (): boolean => {
    const { player1Mark, player2Mark } = gameState;

    // Valid if both players have selected a marker and they are different
    return (
      player1Mark !== MarkersEnum.Empty &&
      player2Mark !== MarkersEnum.Empty &&
      player1Mark !== player2Mark
    );
  };

  const startGame = () => {
    if (checkValidGameState()) {
      setGameState((prevState) => ({
        ...prevState,
        gameOn: true,
      }));
    } else {
      setError(
        "Invalid Game State. Please choose different markers for both players."
      );
    }
  };

  useEffect(() => {
    if (gameState.gameOn) {
      console.log(`${gameState.player1Mark} is Player 1`);
      console.log(`${gameState.player2Mark} is Player 2`);
    }
  }, [gameState.gameOn, gameState.player1Mark, gameState.player2Mark]);

  return (
    <div className="landing-page">
      {!gameState.gameOn ? (
        <div className="selection-container">
          <h1>Choose Your Marker</h1>
          <div className="buttons-container">
            <button
              className={`marker-button ${
                gameState.player1Mark === MarkersEnum.X ? "selected" : ""
              }`}
              onClick={() => choosePlayer(MarkersEnum.X)}
            >
              X
            </button>
            <button
              className={`marker-button ${
                gameState.player1Mark === MarkersEnum.O ? "selected" : ""
              }`}
              onClick={() => choosePlayer(MarkersEnum.O)}
            >
              O
            </button>
          </div>
          {error && <p className="error-message">{error}</p>}
          <button
            className="start-button"
            onClick={startGame}
            disabled={!checkValidGameState()}
          >
            Start Game
          </button>
        </div>
      ) : (
        <Game
          player1Mark={gameState.player1Mark}
          player2Mark={gameState.player2Mark}
        />
      )}
    </div>
  );
};

export default LandingPage;
