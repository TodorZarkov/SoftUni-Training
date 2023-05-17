import { useContext, useEffect, useReducer } from "react";
import { Link, useParams } from "react-router-dom";
import { gameServiceFactory } from "../../services/gameService";
import { useService } from "../../hooks/useService";
import { UserContext } from "../../contexts/UserContext";
import { ShowComments } from "./ShowComments";
import { CreateComment } from "./CreateComment";
import { commentServiceFactory } from "../../services/commentService";
import { gameReducer } from "../../reducers/gameReducer";

export const GameDetails = () => {

    const { gameId } = useParams();

    // const [game, setGame] = useState({});
    // const [comments, setComments] = useState([])
    const [state, dispatch] = useReducer(gameReducer, {game: {},  comments: []});

    const gameService = useService(gameServiceFactory);
    const commentService = useService(commentServiceFactory);

    const { userId, isLogged, userEmail } = useContext(UserContext);

    useEffect(() => {
        Promise
            .all([
                gameService.getOne(gameId),
                commentService.getAll(gameId)
            ])
            .then(([game, comments]) => ([
                dispatch({type: 'set-game', game}), //setGame(game),  
                dispatch({type: 'set-comments', comments}) //setComments(comments)
            ]))

    }, [gameId]);

    const onCreateCommentSubmit = async (commentData) => {
        const newComment = await commentService.create(commentData);
        // newComment['user'] = {};
        // newComment.user['email'] = userEmail;
        // setComments(state => ([newComment, ...state]));
        dispatch({type: 'add-comment', newComment, userEmail})
    };
    
    return (
        <section id="game-details">
            <h1>Game Details</h1>
            <div className="info-section">

                <div className="game-header">
                    <img className="game-img" src={state.game.imageUrl} alt="" />
                    <h1>{state.game.title}</h1>
                    <span className="levels">MaxLevel: {state.game.maxLevel}</span>
                    <p className="type">{state.game.category}</p>
                </div>

                <p className="text">
                    {state.game.summary}
                </p>

                <ShowComments comments={state.comments} />

                {
                    state.game._ownerId === userId
                    &&
                    <div className="buttons">
                        <Link to={'edit-game'} className="button">Edit</Link>
                        <Link to={'delete-game'} className="button">Delete</Link>
                    </div>
                }
            </div>

            {isLogged && userId !== state.game._ownerId
                &&
                <CreateComment  onCreateCommentSubmit={onCreateCommentSubmit}
                                gameId={gameId}
                />
            }

        </section>
    );
};