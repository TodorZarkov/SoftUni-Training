import { useForm } from "../../hooks/useForm";

export const CreateComment = ({
    gameId,
    onCreateCommentSubmit,
}) => {

    const [values, onChange, onFormSubmit] = useForm(onCreateCommentSubmit, {
        gameId,
        text: '',
    });

    return (
        <article className="create-comment">
            <label>Add new comment:</label>
            <form className="form" onSubmit={onFormSubmit}>
                <textarea
                    name="text"
                    placeholder="Comment......"
                    value={values.text}
                    onChange={onChange}
                />
                <input className="btn submit" type="submit" value="Add Comment" />
            </form>
        </article>
    );
};