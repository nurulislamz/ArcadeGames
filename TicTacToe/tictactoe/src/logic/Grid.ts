// Grid.ts
import IGrid from "../interfaces/IGrid";
import MarkersEnum from "./MarkersEnum";

class Grid implements IGrid {
  public grid: MarkersEnum[][];

  constructor() {
    this.grid = Array.from({ length: 3 }, () =>
      Array.from({ length: 3 }, () => MarkersEnum.Empty)
    );
  }

  isSquareEmpty(row: number, col: number): boolean {
    return this.grid[row][col] === MarkersEnum.Empty;
  }

  getMarkAt(row: number, col: number): MarkersEnum {
    return this.grid[row][col];
  }

  setMarkAt(row: number, col: number, mark: MarkersEnum): void {
    if (!this.isSquareEmpty(row, col)) {
      throw new Error("Square is already occupied.");
    }
    this.grid[row][col] = mark;
  }

  checkWin(): MarkersEnum | null {
    // Check rows
    for (let i = 0; i < 3; i++) {
      if (
        this.grid[i][0] !== MarkersEnum.Empty &&
        this.grid[i][0] === this.grid[i][1] &&
        this.grid[i][1] === this.grid[i][2]
      ) {
        return this.grid[i][0];
      }
    }

    // Check columns
    for (let j = 0; j < 3; j++) {
      if (
        this.grid[0][j] !== MarkersEnum.Empty &&
        this.grid[0][j] === this.grid[1][j] &&
        this.grid[1][j] === this.grid[2][j]
      ) {
        return this.grid[0][j];
      }
    }

    // Check main diagonal
    if (
      this.grid[0][0] !== MarkersEnum.Empty &&
      this.grid[0][0] === this.grid[1][1] &&
      this.grid[1][1] === this.grid[2][2]
    ) {
      return this.grid[0][0];
    }

    // Check anti-diagonal
    if (
      this.grid[0][2] !== MarkersEnum.Empty &&
      this.grid[0][2] === this.grid[1][1] &&
      this.grid[1][1] === this.grid[2][0]
    ) {
      return this.grid[0][2];
    }

    // No winner
    return null;
  }

  isFull(): boolean {
    return this.grid.every((row) =>
      row.every((cell) => cell !== MarkersEnum.Empty)
    );
  }
}

export default Grid;
