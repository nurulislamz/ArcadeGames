import React from 'react';
import './App.css';
import { markAsUntransferable } from 'worker_threads';

function App() {
  return (
    <div>MyApp</div>
  );
}

enum MarkersEnum
{
  X,
  O
}

class Players
{
  private score : number; 
  public mark: string

  constructor(_score: number, _mark: string){
    this.score = _score;
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
  mark? : MarkersEnum

  constructor(){
    this.mark = undefined;
  }  

  private getMark(){
    return this.mark;
  }

  public SelectSquare(_mark : MarkersEnum) : MarkersEnum{
    this.mark = _mark;
    return this.mark;
  }

}

class Grid 
{
  rows = 3;
  cols = 3;
  grid? : Squares[][];

  constructor(){
    this.grid = [];

    for (let i = 0; i < this.rows; i++){
      for (let j = 0; j < this.cols; j++){
        this.grid[i][j] = new Squares();
      }
    }




  }
}



export default App;
