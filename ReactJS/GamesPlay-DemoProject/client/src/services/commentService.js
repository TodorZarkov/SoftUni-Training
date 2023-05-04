import { requestFactory } from "./dataServerService";

const endpoint = '/data/comments'


export const commentServiceFactory = (token) => {
    const requester = requestFactory(token);

    const getAll = async (gameId) => {


        const searchQuery = `where=${encodeURIComponent(`gameId="${gameId}"`)}`;
        const sortQuery = `sortBy=${encodeURIComponent(`_createdOn desc`)}`;
        const relationQuery = `load=${encodeURIComponent('user=_ownerId:users')}`
    
        const comments = await requester.get(`${endpoint}?${searchQuery}&${sortQuery}&${relationQuery}`)
    
        return comments;
    };

    const create = async (data) => {
        const newComment = await requester.post(endpoint, data);
        return newComment;
    };

    return {
        getAll,
        create,
    }
}