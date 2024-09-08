import React, { useState } from 'react';
import MarkersEnum from '../logic/MarkersEnum';

interface GameState {
    gameOn: boolean;
    player1Mark : MarkersEnum.O | MarkersEnum.X | MarkersEnum.Empty
    player2Mark : MarkersEnum.O | MarkersEnum.X | MarkersEnum.Empty
}

const LandingPage =  () => {    

    const [gameState, setGameState] = useState<GameState>({
        gameOn : false,
        player1Mark : MarkersEnum.Empty,
        player2Mark : MarkersEnum.Empty,
    });
    
    const handleStartGame = (marker: MarkersEnum.O | MarkersEnum.X) => {

        let marker2 = MarkersEnum.Empty;
        switch (marker){
            case MarkersEnum.O:
                marker2 = MarkersEnum.X;
                break;
            case MarkersEnum.X:
                marker2 = MarkersEnum.O;
                break;
        };

        setGameState({
            gameOn: true,
            player1Mark: marker,
            player2Mark: marker2
        });
    };

    return (
        <div>
           {!gameState.gameOn ? (
            <div>
                <h1>Choose a Marker</h1>
                <button onClick={() => handleStartGame(MarkersEnum.X)}>X</button>
                <button onClick={() => handleStartGame(MarkersEnum.O)}>O</button>
            </div>
            ) : (
                <div>GameComponent</div>
            )} 
        </div>
    );
};

export default LandingPage;