// src/components/Game.tsx
import React, { useState, useEffect } from "react";
import MarkersEnum from "../logic/MarkersEnum";
import Square from "./Square";

interface GameProps {
  player1Mark: MarkersEnum;
  player2Mark: MarkersEnum;
}

type GridState = MarkersEnum[][];

const Game: React.FC<GameProps> = ({ player1Mark, player2Mark }) => {
  const initialGrid: GridState = Array.from({ length: 3 }, () =>
    Array.from({ length: 3 }, () => MarkersEnum.Empty)
  );

  const [grid, setGrid] = useState<GridState>(initialGrid);
  const [currentPlayer, setCurrentPlayer] = useState<MarkersEnum>(player1Mark);
  const [winner, setWinner] = useState<MarkersEnum | null>(null);
  const [message, setMessage] = useState<string>(
    `Player ${currentPlayer}'s turn`
  );

  const checkWin = (grid: GridState): MarkersEnum | null => {
    // Check rows
    for (let i = 0; i < 3; i++) {
      if (
        grid[i][0] !== MarkersEnum.Empty &&
        grid[i][0] === grid[i][1] &&
        grid[i][1] === grid[i][2]
      ) {
        return grid[i][0];
      }
    }

    // Check columns
    for (let j = 0; j < 3; j++) {
      if (
        grid[0][j] !== MarkersEnum.Empty &&
        grid[0][j] === grid[1][j] &&
        grid[1][j] === grid[2][j]
      ) {
        return grid[0][j];
      }
    }

    // Check main diagonal
    if (
      grid[0][0] !== MarkersEnum.Empty &&
      grid[0][0] === grid[1][1] &&
      grid[1][1] === grid[2][2]
    ) {
      return grid[0][0];
    }

    // Check anti-diagonal
    if (
      grid[0][2] !== MarkersEnum.Empty &&
      grid[0][2] === grid[1][1] &&
      grid[1][1] === grid[2][0]
    ) {
      return grid[0][2];
    }

    return null;
  };

  const isFull = (grid: GridState): boolean => {
    return grid.every((row) => row.every((cell) => cell !== MarkersEnum.Empty));
  };

  const handleSquareClick = (row: number, col: number) => {
    if (grid[row][col] !== MarkersEnum.Empty || winner) {
      return;
    }

    const newGrid = grid.map((r, rowIndex) =>
      r.map((cell, colIndex) => {
        if (rowIndex === row && colIndex === col) {
          return currentPlayer;
        }
        return cell;
      })
    );

    setGrid(newGrid);

    const gameWinner = checkWin(newGrid);
    if (gameWinner) {
      setWinner(gameWinner);
      setMessage(`Player ${gameWinner} wins!`);
    } else if (isFull(newGrid)) {
      setWinner(MarkersEnum.Empty); // Indicate a draw
      setMessage("It's a draw!");
    } else {
      const nextPlayer =
        currentPlayer === player1Mark ? player2Mark : player1Mark;
      setCurrentPlayer(nextPlayer);
      setMessage(`Player ${nextPlayer}'s turn`);
    }
  };

  const resetGame = () => {
    setGrid(initialGrid);
    setWinner(null);
    setCurrentPlayer(player1Mark);
    setMessage(`Player ${player1Mark}'s turn`);
  };

  return (
    <div className="game-container">
      <h2>Tic-Tac-Toe</h2>
      <div className="status-message">{message}</div>
      <div className="grid">
        {grid.map((row, rowIndex) => (
          <div className="grid-row" key={rowIndex}>
            {row.map((cell, colIndex) => (
              <Square
                key={`${rowIndex}-${colIndex}`}
                value={cell}
                onClick={() => handleSquareClick(rowIndex, colIndex)}
              />
            ))}
          </div>
        ))}
      </div>
      {winner && (
        <button className="reset-button" onClick={resetGame}>
          Play Again
        </button>
      )}
    </div>
  );
};

export default Game;
