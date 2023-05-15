import { useParams } from "react-router-dom";
import { useService } from "../../hooks/useService";
import { gameServiceFactory } from "../../services/gameService";
import { useContext, useEffect } from "react";
import { useForm } from "../../hooks/useForm";
import { GameContext } from "../../contexts/GameContext";

export const EditGame = () => {

    const {onEditGameSubmit} = useContext(GameContext);

    const {gameId} = useParams();
    const gameService = useService(gameServiceFactory);

    const [values, onChange, onFormSubmit, onChangeValues] =  useForm(onEditGameSubmit, {
        title: '',
        category: '',
        maxLevel: '',
        imageUrl: '',
        summary: '',
        _id: '',
    });

    useEffect(() => {
        gameService.getOne(gameId)
            .then(g => onChangeValues(g));
    }, [gameId])

    return (
        <section id="edit-page" className="auth">
            <form id="edit" onSubmit={onFormSubmit}>
                <div className="container">

                    <h1>Edit Game</h1>
                    <label htmlFor="leg-title">Legendary title:</label>
                    <input
                        type="text"
                        id="title"
                        name="title"
                        value={values.title} 
                        onChange={onChange}
                    />

                    <label htmlFor="category">Category:</label>
                    <input
                        type="text"
                        id="category"
                        name="category"
                        value={values.category} 
                        onChange={onChange}
                    />

                    <label htmlFor="levels">MaxLevel:</label>
                    <input
                        type="number"
                        id="maxLevel"
                        name="maxLevel"
                        min="1"
                        value={values.maxLevel}
                        onChange={onChange}
                    />

                    <label htmlFor="game-img">Image:</label>
                    <input
                        type="text"
                        id="imageUrl"
                        name="imageUrl"
                        value={values.imageUrl} 
                        onChange={onChange}
                    />

                    <label htmlFor="summary">Summary:</label>
                    <textarea
                        name="summary"
                        id="summary"
                        value={values.summary}
                        onChange={onChange}
                    />

                    <input className="btn submit" type="submit" value="Edit Game" />

                </div>
            </form>
        </section>
    );
};