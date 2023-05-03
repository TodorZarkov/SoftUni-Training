import { Navigate, useParams } from "react-router-dom";
import { useEffect } from "react";

export const DeleteGame = ({
        onDeleteGameClick,
    }) => {

        const {gameId} = useParams();

        useEffect(() => {
            onDeleteGameClick(gameId);
            console.log(gameId)
        }, [gameId])
    
    
    return(
        <Navigate to={'/catalog'} />
    );
};