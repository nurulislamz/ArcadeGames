import React from 'react';

const LandingPage: React.FC = () => {
    return (
        <div className = "container">
            <header className = "header">
                <h1>Welcome to Tic Tac Toe</h1>
                <p>Play am exciting game of Tic-Tac-Toe!</p>
                <button className="button" onClick={() => window.location.href = '/game'}>
                    Start Game
                </button>
            </header>
        </div>
    )
}

export default LandingPage;