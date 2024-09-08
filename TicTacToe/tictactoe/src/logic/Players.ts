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

export default Players;