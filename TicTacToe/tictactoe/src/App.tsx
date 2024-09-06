import React from 'react';
import './App.css';
import { markAsUntransferable } from 'worker_threads';
import { error } from 'console';

function App() {
  return (
    <div>MyApp</div>
  );
}

enum MarkersEnum
{
  X,
  O, 
  Empty
}

class Players
{
  private score : number; 
  public mark: string

  constructor(_mark: string){
    this.score = 0;
    this.mark = _mark
  }

  private incrementScore(){
    this.score++;
  }
  
  public getScore(): number {
    return this.score;
  } 
}

class Squares 
{
  mark : MarkersEnum

  constructor(){
    this.mark = MarkersEnum.Empty;
  }  

  private getMark(){
    return this.mark;
  }

  public SelectSquare(_mark : MarkersEnum) : MarkersEnum{
    if (this.mark == MarkersEnum.O || this.mark == MarkersEnum.X){
      throw error("This square is already selected. Try a different one.")
    }
    this.mark = _mark;
    return this.mark;
  }
}

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

class Game {
  
  player1 : Players;
  player2 : Players;
  grid : Grid;

  private Game()
  {
    this.grid = new Grid();
    this.player1 = new Players();
    this.player2 = new Players();
  }

}

}

export default App;
