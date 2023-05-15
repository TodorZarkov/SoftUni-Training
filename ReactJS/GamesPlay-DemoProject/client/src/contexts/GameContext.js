import { createContext, useContext } from "react";
import { useNavigate } from 'react-router-dom';
import { useEffect, useState } from 'react';
import { gameServiceFactory } from '../services/gameService';
import { UserContext } from '../contexts/UserContext';



export const GameContext = createContext();

export const GameProvider = ({ children }) => {

    const {token} = useContext(UserContext);

    const navigate = useNavigate();

    const [games, setGames] = useState([]);
    const gameService = gameServiceFactory(token);


    useEffect(() => {
        gameService.getAll().then(result => setGames(result));
    }, []);

    const onCreateGameSubmit = async (data) => {
        const newGame = await gameService.create(data);
        setGames(state => ([...state, newGame]));
        navigate('/catalog')
    };

    const onEditGameSubmit = async (data) => {
        const { _id, ...gameData } = data;
        const editedGame = await gameService.update(_id, gameData);
        setGames(state => state.map(g => g._id === _id ? editedGame : g));
        navigate(`/${data._id}`)
    };

    const onDeleteGameClick = (gameId) => {
        gameService.remove(gameId)
            .then(setGames(state => state.filter(g => g._id !== gameId)));
        // TODO: catch if server not responging!
    };

    const gameVariables = {
        games,
        onCreateGameSubmit,
        onEditGameSubmit,
        onDeleteGameClick
    }

    return (
        <GameContext.Provider value={gameVariables}>
            {children}
        </GameContext.Provider>
    );
};