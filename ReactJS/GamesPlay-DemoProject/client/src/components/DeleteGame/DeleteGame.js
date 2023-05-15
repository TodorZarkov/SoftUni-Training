import { Navigate, useParams } from "react-router-dom";
import { useContext, useEffect } from "react";
import { GameContext } from "../../contexts/GameContext";

export const DeleteGame = () => {

        const { onDeleteGameClick } = useContext(GameContext);

        const {gameId} = useParams();

        useEffect(() => {
            onDeleteGameClick(gameId);
        }, [gameId]);
    
    return(
        <Navigate to={'/catalog'} />
    );
};