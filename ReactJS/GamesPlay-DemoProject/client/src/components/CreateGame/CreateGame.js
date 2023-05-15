import { useContext } from "react";
import { useForm } from "../../hooks/useForm";
import { GameContext } from "../../contexts/GameContext";

export const CreateGame = () => {

    const {onCreateGameSubmit} = useContext(GameContext);

    const initialValues = {
        title: '',
        category: '',
        maxLevel: '',
        imageUrl: '',
        summary: '',
    };

    const [values, onChange, onSubmit] = useForm(onCreateGameSubmit, initialValues);
    
    return(
        <section id="create-page" className="auth">
            <form onSubmit={onSubmit} id="create">
                <div className="container">

                    <h1>Create Game</h1>
                    <label htmlFor="leg-title">Legendary title:</label>
                    <input
                        onChange={onChange}
                        value={values.title}
                        type="text"
                        id="title"
                        name="title"
                        placeholder="Enter game title..." 
                    />

                    <label htmlFor="category">Category:</label>
                    <input
                        onChange={onChange}
                        value={values.category}
                        type="text"
                        id="category"
                        name="category"
                        placeholder="Enter game category..." 
                    />

                    <label htmlFor="levels">MaxLevel:</label>
                    <input
                        onChange={onChange}
                        value={values.maxLevel}
                        type="number"
                        id="maxLevel"
                        name="maxLevel"
                        min="1"
                        placeholder="1" 
                    />

                    <label htmlFor="game-img">Image:</label>
                    <input
                        onChange={onChange}
                        value={values.imageUrl}
                        type="text"
                        id="imageUrl"
                        name="imageUrl"
                        placeholder="Upload a photo..." 
                    />

                    <label htmlFor="summary">Summary:</label>
                    <textarea
                        onChange={onChange}
                        value={values.summary}
                        name="summary"
                        id="summary">
                    </textarea>
                    <input className="btn submit" type="submit" value="Create Game" />
                </div>
            </form>
        </section>
    );
};