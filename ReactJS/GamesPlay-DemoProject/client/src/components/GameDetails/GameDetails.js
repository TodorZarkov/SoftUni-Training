import { useContext, useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import { gameServiceFactory } from "../../services/gameService";
import { useService } from "../../hooks/useService";
import { UserContext } from "../../contexts/UserContext";
import { ShowComments } from "./ShowComments";
import { CreateComment } from "./CreateComment";
import { commentServiceFactory } from "../../services/commentService";

export const GameDetails = () => {

    const { gameId } = useParams();

    const [game, setGame] = useState({});
    const [comments, setComments] = useState([])

    const gameService = useService(gameServiceFactory);
    const commentService = useService(commentServiceFactory);

    const { userId, isLogged } = useContext(UserContext);

    // useEffect(() => {
    //     gameService.getOne(gameId).then(g => setGame(g));
    // }, [gameId]);

    
    // useEffect(() => {
    //     commentService.getAll(gameId)
    //         .then(c => setComments(c));
    // }, [gameId]);

    useEffect(() => {
        Promise
            .all([
            gameService.getOne(gameId),
            commentService.getAll(gameId)
        ])
            .then(values =>([ 
            setGame(values[0]),
            setComments(values[1])]))

    }, [gameId]);

    return (
        <section id="game-details">
            <h1>Game Details</h1>
            <div className="info-section">

                <div className="game-header">
                    <img className="game-img" src={game.imageUrl} alt="" />
                    <h1>{game.title}</h1>
                    <span className="levels">MaxLevel: {game.maxLevel}</span>
                    <p className="type">{game.category}</p>
                </div>

                <p className="text">
                    {game.summary}
                </p>

                <ShowComments comments={comments} />

                {
                    game._ownerId === userId
                    &&
                    <div className="buttons">
                        <Link to={'edit-game'} className="button">Edit</Link>
                        <Link to={'delete-game'} className="button">Delete</Link>
                    </div>
                }
            </div>

            {isLogged && userId !== game._ownerId
                &&
                <CreateComment />
            }

        </section>
    );
};