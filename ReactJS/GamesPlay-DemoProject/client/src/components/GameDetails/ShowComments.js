
export const ShowComments = ({
    comments,
}) => {

    return (
        <div className="details-comments">
            <h2>Comments:</h2>
            {
            comments && comments.length !== 0
                ?
                <ul>
                    {comments.map(c =>
                        <li className="comment" key={c._id}>
                            <h5>{c.user.email} says:</h5>
                            <p>{c.text}</p>
                        </li>
                    )}
                </ul>
                :
                <p className="no-comment">No comments.</p>
            }
        </div>
    );
};