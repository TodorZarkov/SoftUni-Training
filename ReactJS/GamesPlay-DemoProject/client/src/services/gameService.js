import * as dataApi from './dataServerService';

const endponint = "/jsonstore/games"

export const getAllGames = async () => {
    const games = await dataApi.get(endponint);
    return games;
}

export const createGame = async (data) => {
    const newGame = await dataApi.post(endponint, data);
    return newGame;
}