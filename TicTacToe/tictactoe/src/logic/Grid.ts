import React from 'react';
import './App.css';
import Squares from './Square';
import Players from './Players';
import MarkersEnum from './MarkersEnum';
import { error } from 'console';

class Grid 
{

  rows = 3;
  cols = 3;
  grid : Squares[][];

  constructor(){
    this.grid = [];

    for (let i = 0; i < this.rows; i++){
      for (let j = 0; j < this.cols; j++){
        this.grid[i][j] = new Squares();
      }
    }
  }

  public CheckSquareEmpty(row: number, col: number): boolean {
    return this.grid[row][col].mark == MarkersEnum.Empty;
  }

  public GetGrid(row: number, col: number) : MarkersEnum {
    return this.grid[row][col].mark;
  }

  public SetGrid(row: number, col: number, playerSymbol : MarkersEnum) : void {
    if (this.CheckSquareEmpty(row, col)) throw error("Square is not empty. Pick another square.");
    this.grid[row][col].SelectSquare(playerSymbol);
  }

  public CheckWin(): MarkersEnum {
    
    let count = 0;
    // check column
    for (let i = 0; i < 3; i++){
      count = 0;
      for (let j  = 1; j < 3; j++){
        if (this.grid[i][j] == this.grid[i][j-1]) count++;
        if (count == 3) return this.grid[i][j].mark;
        else break;
      }
    }
    
    // check rows
    for (let j = 0; j < 3; j++){
      count = 0;
      for (let i = 1; i < 3; i++){
        if (this.grid[j][i] == this.grid[j][i-1]) count++;
        if (count == 3) return this.grid[j][i].mark;
        else break;
      }
    }

    // check diagonals
    count = 0;
    for (let i = 1; i < 3; i++){
      if (this.grid[i][i] == this.grid[i-1][i-1]) count++;
      if (count == 3) return this.grid[i][i].mark;
      else break;
    }

    // check anti-diagonals
    count = 0;
    for (let j = 2; j > 0; j--){
      for (let i = 0; i < 3; i++){
        if (this.grid[i][j] == this.grid[i-1][j-1]) count++;
        if (count == 3) return this.grid[i][j].mark;
        else break;
      }
    }

    return MarkersEnum.Empty;
  }
}

export default Grid;