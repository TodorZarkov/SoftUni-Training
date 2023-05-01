import {requestFactory} from './dataServerService';

const endponint = "/data/games"



export const gameServiceFactory = (token) => {
    const request = requestFactory(token);

    const getAll = async () => {
        const games = await request.get(endponint);
        return Object.values(games);
    };
    
    const create = async (data) => {
        const newGame = await request.post(endponint, data);
        return newGame;
    };
    
    const getOne = async (gameId) => {
        const result =  await request.get(endponint + '/' + gameId);
        return result;
    };
    
    return {
        getAll,
        getOne,
        create,
    };

};