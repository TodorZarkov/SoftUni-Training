export const gameReducer = (state, action) => {
    switch (action.type) {
        case 'set-game':
            return {
                ...state,
                game: action.game,
            }

        case 'set-comments':
            return {
                ...state,
                comments: action.comments,
            }

        case 'add-comment':
            const newComment = action.newComment;
            newComment['user'] = {};
            newComment.user['email'] = action.userEmail;
            return {
                ...state,//game: state.game,
                comments: ([newComment, ...state.comments])
            }

        default:
            throw Error(`Unknown action: ${action.type}`)
    }
}